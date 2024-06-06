using OLX_Selenium_Tests.Helpers;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace OLX_Selenium_Tests.PageComponentObjects
{
    public class EmailPasswordFormComponent : BaseComponent
    {
        public EmailPasswordFormComponent(IWebDriver driver, IWebElement formContainer) : base(driver) { this.formContainer = formContainer; }
        private IWebElement formContainer;

        private ReadOnlyCollection<IWebElement> errorMessages => formContainer.FindElements(By.ClassName("css-2t3wbf"));
        public IWebElement EmailInput => formContainer.FindElement(By.Name("username"));
        public IWebElement EmailInputErrorMessage => errorMessages[0];
        public IWebElement PasswordInput => formContainer.FindElement(By.Name("password"));
        public IWebElement PasswordInputErrorMessage => errorMessages.Last();
        public IWebElement PasswordVisibilityToggle => formContainer.FindElementByDataTestID("toggle-password");
        public IWebElement FacebookLoginButton => driver.FindElementByDataTestID("facebook-button");
        public IWebElement AppleLoginButton => driver.FindElementByDataTestID("apple-button");
        public IWebElement GoogleLoginButton => driver.FindElementByDataTestID("google-button");
        private IWebElement tabsContainer => driver.FindElementByDataTestID("tabs");
        public ReadOnlyCollection<IWebElement> PageTabs => new ReadOnlyCollection<IWebElement>(new List<IWebElement>()
        {
            tabsContainer.FindElement(By.ClassName("css-vz18bh")),
            tabsContainer.FindElement(By.ClassName("css-ocbo9b"))
        });

    }
}
