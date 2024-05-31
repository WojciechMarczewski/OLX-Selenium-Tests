using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Allegro_Selenium_Tests.Helpers
{
    public static class WebDriverExtensions
    {

        public static void EnterText(this IWebElement webElement, string text)
        {
            webElement.Clear();
            webElement.SendKeys(text);
        }
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

    }
}
