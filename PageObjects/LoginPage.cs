using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.PageComponentObjects;
using OpenQA.Selenium;
namespace OLX_Selenium_Tests.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver)
        { loginFormComponent = new Lazy<EmailPasswordFormComponent>(() => new EmailPasswordFormComponent(webDriver, LoginForm)); }
        private Lazy<EmailPasswordFormComponent> loginFormComponent;
        public EmailPasswordFormComponent LoginFormComponent { get { return loginFormComponent.Value; } }
        public IWebElement LoginForm => driver.FindElementByDataTestID("login-form");
        public IWebElement ForgotPasswordLinkButton => LoginForm.FindElement(By.ClassName("css-1w1v00v"));
        public IWebElement LoginSubmitButton => LoginForm.FindElementByDataTestID("login-submit-button");
        public IWebElement RegisterTabButton => LoginFormComponent.PageTabs[1];
        public void Login(string userEmail, string password)
        {
            LoginFormComponent.EmailInput.EnterText(userEmail);
            LoginFormComponent.PasswordInput.EnterText(password);
            LoginForm.Submit();
        }


    }
}
