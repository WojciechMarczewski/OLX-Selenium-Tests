using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
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
        public static IWebElement FindElementByDataTestID(this IWebDriver webDriver, string testID)
        {
            return webDriver.FindElement(By.XPath($"//*[@data-testid='{testID}']"));
        }
        public static IWebElement FindElementByDataTestID(this IWebElement webElement, string testID)
        {
            return webElement.FindElement(By.XPath($"//*[@data-testid='{testID}']"));
        }
        public static ReadOnlyCollection<IWebElement> FindElementsByDataTestID(this IWebDriver webDriver, string testID)
        {
            return webDriver.FindElements(By.XPath($"//*[@data-testid='{testID}']"));
        }
        public static ReadOnlyCollection<IWebElement> FindElementsByDataTestID(this IWebElement webElement, string testID)
        {
            return webElement.FindElements(By.XPath($"//*[@data-testid='{testID}']"));
        }
        public static string GetElementDetails(this IWebElement element)
        {
            try
            {
                return $"Tag: {element.TagName},\n Text: {element.Text},\n Class: {element.GetAttribute("class")}";
            }
            catch (Exception ex)
            {
                return $"Element not found. Exception: {ex.Message}";
            }
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
