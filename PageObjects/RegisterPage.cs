using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.PageComponentObjects;
using OpenQA.Selenium;
namespace OLX_Selenium_Tests.PageObjects
{
    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver webDriver) : base(webDriver)
        { registerFormComponent = new Lazy<EmailPasswordFormComponent>(() => new EmailPasswordFormComponent(driver, RegisterForm)); }
        private Lazy<EmailPasswordFormComponent> registerFormComponent;
        public EmailPasswordFormComponent RegisterFormComponent { get { return registerFormComponent.Value; } }
        public IWebElement RegisterForm => driver.FindElementByDataTestID("register-form");
        public IWebElement OlxLegalFields => RegisterForm.FindElementByDataTestID("olx-legal-fields");
        public IWebElement TermsOfUseLink => OlxLegalFields.FindElementByDataTestID("terms-of-use");
        public IWebElement TermsConditionsPolicyLink => OlxLegalFields.FindElementByDataTestID("terms-conditions-policy");
        public IWebElement TermsConditionsCookiesLink => OlxLegalFields.FindElementByDataTestID("terms-conditions-cookies");
        public IWebElement UserConsentCheckBox => OlxLegalFields.FindElement(By.Id("user-consent"));
        public IWebElement RegisterButton => RegisterForm.FindElementByDataTestID("register-button");
        public IWebElement LoginTabButton => RegisterFormComponent.PageTabs[0];
        public void Register(string userEmail, string password)
        {
            RegisterFormComponent.EmailInput.EnterText(userEmail);
            RegisterFormComponent.PasswordInput.EnterText(password);
            UserConsentCheckBox.Click();
            RegisterForm.Submit();
        }
    }
}
