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
        public void Click_TrustAccept()
        {
            OneTrustAcceptButton.Click();
        }
        public IWebElement OneTrustAcceptButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));
    }
}
