using OpenQA.Selenium;
namespace OLX_Selenium_Tests.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver { get; }
        protected BasePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }
        public void ClickTrustAccept()
        {
            oneTrustAcceptButton.Click();
        }
        /// <summary>
        /// Property represents accept button which appears along with cookies information every time when there are no site cookies saved in the browser.
        /// </summary>
        private IWebElement oneTrustAcceptButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));
    }
}
