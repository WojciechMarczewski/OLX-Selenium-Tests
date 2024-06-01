using OpenQA.Selenium;
namespace OLX_Selenium_Tests.PageComponentObjects
{
    public abstract class BaseComponent
    {
        protected IWebDriver driver;
        protected BaseComponent(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
