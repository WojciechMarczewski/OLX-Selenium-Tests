using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
namespace OLX_Selenium_Tests.Helpers
{
    public static class WebDriverFactory
    {
        public static IWebDriver Init(WebDriverType? driverType)
        {
            switch (driverType)
            {
                case WebDriverType.CHROME:
                    return new ChromeDriver();
                case WebDriverType.FIREFOX:
                    return new FirefoxDriver();
                case WebDriverType.IE:
                    return new InternetExplorerDriver();
            }
            IWebDriver defaultBrowser = new ChromeDriver();
            return defaultBrowser;
        }
    }
    public enum WebDriverType
    {
        CHROME,
        FIREFOX,
        IE
    }
}
