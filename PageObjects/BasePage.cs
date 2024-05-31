using OpenQA.Selenium;

namespace Allegro_Selenium_Tests.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver { get; }

        protected BasePage(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }

    }
}
