using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace OLX_Selenium_Tests.PageTests
{
    public class RegisterPageTests : PageTestBase
    {
        private readonly string baseUrl = "https://www.olx.pl/";
        public RegisterPageTests() : base("http://www.olx.pl/konto/?ref[0][params][url]=http%3A%2F%2Fwww.olx.pl%2F&ref[0][action]=redirector&ref[0][method]=index") { }

        public RegisterPage PageInit()
        {
            var driver = DriverInit();

            LoginPage? loginPage = new LoginPage(driver);
            loginPage.Click_TrustAccept();

            driver.ExecuteJavaScript("arguments[0].click();", loginPage.RegisterTabButton);

            loginPage = null;
            RegisterPage registerPage = new RegisterPage(driver);
            return registerPage;
        }
        [Fact]
        public void RegisterForm_WebElements_Are_Visible()
        {
            UITest(nameof(this.RegisterForm_WebElements_Are_Visible), () =>
            {
                //Arrange
                var registerPage = PageInit();
                //Act
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.True(registerPage.OlxLegalFields.Displayed);
                    Assert.True(registerPage.RegisterButton.Displayed);
                    Assert.True(registerPage.TermsConditionsPolicyLink.Displayed);
                    Assert.True(registerPage.TermsConditionsCookiesLink.Displayed);
                    Assert.True(registerPage.TermsOfUseLink.Displayed);
                    Assert.True(registerPage.UserConsentCheckBox.Displayed);
                    Assert.True(registerPage.RegisterFormComponent.PasswordInput.Displayed);
                    Assert.True(registerPage.RegisterFormComponent.EmailInput.Displayed);
                    Assert.True(registerPage.RegisterFormComponent.PasswordVisibilityToggle.Displayed);
                    Assert.True(registerPage.RegisterFormComponent.PageTabs[0].Displayed);
                    Assert.True(registerPage.RegisterFormComponent.PageTabs[1].Displayed);
                });
            });
        }
        [Fact]
        public void Register_With_Empty_Credentials_Should_Fail()
        {
            UITest(nameof(this.Register_With_Empty_Credentials_Should_Fail), () =>
            {
                //Arrange
                var registerPage = PageInit();
                var expectedEmailErrorMessage = "Wpisz swój e-mail";
                var expectedPasswordErrorMessage = "Wpisz hasło";
                //Act
                registerPage.RegisterForm.Submit();
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.True(registerPage.RegisterFormComponent.EmailInputErrorMessage.Displayed);
                    Assert.True(registerPage.RegisterFormComponent.PasswordInputErrorMessage.Displayed);
                    Assert.Equal(expectedEmailErrorMessage, registerPage.RegisterFormComponent.EmailInputErrorMessage.Text);
                    Assert.Equal(expectedPasswordErrorMessage, registerPage.RegisterFormComponent.PasswordInputErrorMessage.Text);
                });
            });
        }
        [Theory]
        [InlineData("admin@olx.pl")]
        [InlineData("test.user@gmail.com")]
        [InlineData("example@domain.com")]
        public void Register_With_Only_Valid_Email_Should_Fail(string userEmail)
        {
            UITest(nameof(this.Register_With_Only_Valid_Email_Should_Fail), () =>
            {
                //Arrange
                var registerPage = PageInit();
                var expectedPasswordErrorMessage = "Wpisz hasło";
                //Act
                registerPage.RegisterFormComponent.EmailInput.EnterText(userEmail);
                registerPage.RegisterForm.Submit();
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.True(registerPage.RegisterFormComponent.PasswordInputErrorMessage.Displayed);
                    Assert.Equal(expectedPasswordErrorMessage, registerPage.RegisterFormComponent.PasswordInputErrorMessage.Text);
                    Assert.False(registerPage.RegisterButton.Enabled);
                });
            });
        }
        [Theory]
        [InlineData("test!example.com", "pswd")]
        [InlineData("@example.com", "longpassword")]
        [InlineData("admin", "admin")]
        public void Register_With_Invalid_Credentials_Should_Fail(string userEmail, string password)
        {
            UITest(nameof(this.Register_With_Invalid_Credentials_Should_Fail), () =>
            {
                //Arrange
                var registerPage = PageInit();
                //Act
                registerPage.Register(userEmail, password);
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.False(registerPage.RegisterButton.Enabled);
                    Assert.True(registerPage.RegisterFormComponent.EmailInputErrorMessage.Displayed);
                });
            });
        }
        [Theory]
        [InlineData("letters-and-numbers123@example.com", "LuckyPants532")]
        [InlineData("with.longname@andevenverylongsurname.example.com", "IllBeBack21Terminator")]
        public void Register_With_Valid_Credentials_Redirects_To_Expected_Url(string userEmail, string password)
        {
            UITest(nameof(this.Register_With_Valid_Credentials_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var registerPage = PageInit();
                //Act
                registerPage.Register(userEmail, password);
                //Assert
                Assert.Equal(baseUrl, driver?.Url);

            });
        }
        [Fact]
        public void Login_With_Facebook_Button_Redirects_To_Expected_Url()
        {
            UITest(nameof(this.Login_With_Facebook_Button_Redirects_To_Expected_Url), () =>
            {
                //Arrange 
                var registerPage = PageInit();
                var facebookUrl = "https://www.facebook.com";
                //Act
                registerPage.RegisterFormComponent.FacebookLoginButton.Click();
                //Assert
                Assert.Equal(facebookUrl, driver?.Url.Substring(0, facebookUrl.Length));
            });
        }
        [Fact]
        public void Login_With_Apple_Button_Redirects_To_Expected_Url()
        {
            UITest(nameof(this.Login_With_Apple_Button_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var registerPage = PageInit();
                var appleUrl = "https://appleid.apple.com";
                //Act
                registerPage.RegisterFormComponent.FacebookLoginButton.Click();
                //Assert
                Assert.Equal(appleUrl, driver?.Url.Substring(0, appleUrl.Length));
            });
        }
        [Fact]
        public void Login_With_Google_Button_Redirects_To_Expected_Url()
        {
            UITest(nameof(this.Login_With_Google_Button_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var registerPage = PageInit();
                var googleUrl = "https://accounts.google.com/";
                //Act
                registerPage.RegisterFormComponent?.GoogleLoginButton.Click();
                //Assert
                Assert.Equal(googleUrl, driver?.Url.Substring(0, googleUrl.Length));
            });
        }
        [Fact]
        public void Password_Characters_Visibility_Changes_On_Button_Click()
        {
            UITest(nameof(this.Password_Characters_Visibility_Changes_On_Button_Click), () =>
            {
                //Arrange
                var registerPage = PageInit();
                //Act
                registerPage.RegisterFormComponent.PasswordVisibilityToggle.Click();
                string passwordInputType = registerPage.RegisterFormComponent.PasswordInput.GetAttribute("type");
                registerPage.RegisterFormComponent.PasswordVisibilityToggle.Click();
                string passwordInputType2 = registerPage.RegisterFormComponent.PasswordInput.GetAttribute("type");
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.Equal("text", passwordInputType);
                    Assert.Equal("password", passwordInputType2);
                });
            });
        }
        [Fact]
        public void User_Consent_CheckBox_Is_Selected_On_Click()
        {
            UITest(nameof(this.User_Consent_CheckBox_Is_Selected_On_Click), () =>
            {
                //Arrange
                var registerPage = PageInit();
                //Act
                registerPage.UserConsentCheckBox.Click();
                var checkBoxSelected = registerPage.UserConsentCheckBox.Selected;
                registerPage.UserConsentCheckBox.Click();
                var checkBoxUnselected = registerPage.UserConsentCheckBox.Selected;
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.True(checkBoxSelected);
                    Assert.True(!checkBoxUnselected);
                });
            });
        }
    }
}

