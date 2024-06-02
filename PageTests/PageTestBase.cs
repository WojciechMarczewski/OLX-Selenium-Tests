using OLX_Selenium_Tests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace OLX_Selenium_Tests.PageTests
{
    public abstract class PageTestBase : IDisposable
    {
        protected PageTestBase(string pageUrl)
        {
            url = pageUrl ?? throw new ArgumentNullException(nameof(pageUrl));
        }
        protected IWebDriver? driver;
        protected readonly string url;
        protected IWebDriver DriverInit()
        {
            driver = WebDriverFactory.Init(WebDriverType.CHROME);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
        protected void DriverWaitForPageLoad()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url != url);
        }
        public void Dispose()
        {
            driver?.Close();
            GC.SuppressFinalize(this);
        }

    }
}
