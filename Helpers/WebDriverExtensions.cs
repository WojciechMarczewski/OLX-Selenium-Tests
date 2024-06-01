using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace OLX_Selenium_Tests.Helpers
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
        public static int ConvertTextToInt(this IWebElement webElement)
        {
            var text = webElement.Text;
            if (text.IndexOf(".") != -1)
            {
                text = text.Substring(0, text.IndexOf("."));
            }
            if (text.IndexOf(",") != -1)
            {
                text = text.Substring(0, text.IndexOf(","));
            }
            Regex regex = new Regex("[^0-9]");
            text = regex.Replace(text, "");
            return Convert.ToInt32(text);
        }


    }
}
