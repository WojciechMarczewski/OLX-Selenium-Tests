using OLX_Selenium_Tests.Helpers;
using OpenQA.Selenium;
namespace OLX_Selenium_Tests.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }
        private IWebElement loginForm => driver.FindElement(By.XPath("//*[@data-testid='login-form']"));
        private IWebElement emailFormContainer => loginForm.FindElement(By.ClassName("css-1a74nwz"));
        private IWebElement passwordFormContainer => loginForm.FindElement(By.ClassName("css-jl1cuj"));
        private IWebElement emailInput => emailFormContainer.FindElement(By.Name("username"));
        private IWebElement passwordInput => passwordFormContainer.FindElement(By.Name("password"));
        private IWebElement emailInputErrorMessage => emailFormContainer.FindElement(By.ClassName("css-2t3wbf"));
        private IWebElement passwordInputErrorMessage => passwordFormContainer.FindElement(By.ClassName("css-2t3wbf"));
        public void Login(string userEmail, string password)
        {
            emailInput.EnterText(userEmail);
            passwordInput.EnterText(password);
            loginForm.Submit();
        }
        public void EnterUserEmail(string userEmail)
        {
            emailInput.EnterText(userEmail);
        }
        public void EnterUserPassword(string password)
        {
            passwordInput.EnterText(password);
        }
        public bool IsEmailInputErrorMessageVisible()
        {
            try { return emailInputErrorMessage.Displayed; }
            catch (InvalidElementStateException ex) { return false; }
        }
        public bool IsPasswordInputErrorMessageVisible()
        {
            try { return passwordInputErrorMessage.Displayed; }
            catch (InvalidElementStateException ex) { return false; }
        }
        public string GetEmaiInputErrorMessage()
        {
            return emailInputErrorMessage.Text;
        }
        public string GetPasswordInputErrorMessage()
        {
            return passwordInputErrorMessage.Text;
        }
    }
}
