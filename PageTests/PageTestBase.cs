﻿using OLX_Selenium_Tests.Helpers;
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
        protected void DriverWaitForRedirection()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Url != url);

        }
        protected void DriverWaitForExpectedPageLoad(string pageUrl)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(d => d.Url.Substring(0, pageUrl.Length) == pageUrl.Substring(0, pageUrl.Length)); ;



        }
        public void Dispose()
        {
            driver?.Close();
            GC.SuppressFinalize(this);
        }
        protected void TakeScreenshot(string testMethodName)
        {
            ITakesScreenshot? driverScreenshot = driver as ITakesScreenshot;
            Screenshot? screenshot = driverScreenshot.GetScreenshot();
            var directoryPath = $"./Screenshots";
            if (!Directory.Exists(directoryPath)) { Directory.CreateDirectory(directoryPath); }
            int filesCount = Directory.GetFiles(directoryPath).Length;
            screenshot.SaveAsFile($"{directoryPath}\\{testMethodName}-{filesCount + 1}.png");
        }
        protected void UITest(string testMethodName, Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                TakeScreenshot(testMethodName);
                throw;
            }
        }
    }
}
