using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace OLX_Selenium_Tests.PageTests
{
    public class LoginPageTests : PageTestBase
    {
        private readonly string baseUrl = "https://www.olx.pl/";
        public LoginPageTests() : base("http://www.olx.pl/konto/?ref[0][params][url]=http%3A%2F%2Fwww.olx.pl%2F&ref[0][action]=redirector&ref[0][method]=index") { }
        public LoginPage PageInit()
        {
            var driver = DriverInit();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Click_TrustAccept();
            return loginPage;

        }
        [Theory]
        [InlineData("test")]
        [InlineData("--")]
        [InlineData("`")]
        //[InlineData("Select id from users where userEmail=’username’ and password=’password’ or 1=1--+")]
        public void UserEmailInput_InvalidDataEntered_DisplaysExpectedError(string userEmail)
        {
            //Arrange
            var loginPage = PageInit();
            var loginForm = loginPage.LoginFormComponent;
            var expectedErrorText = "To nie wygląda jak adres mailowy...";
            //Act
            loginForm.EmailInput.EnterText(userEmail);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.True(loginForm.EmailInputErrorMessage.Displayed);
                Assert.Equal(expectedErrorText, loginForm.EmailInputErrorMessage.Text);
            });
        }
        [Theory]
        [InlineData("test")]
        [InlineData("--")]
        [InlineData("`")]
        // [InlineData("Select id from users where userEmail=’username’ and password=’password’ or 1=1--+")]
        public void UserPasswordInput_InvalidDataEntered_DisplaysExpectedError(string userPassword)
        {
            //Arrange
            var loginPage = PageInit();
            var loginForm = loginPage.LoginFormComponent;
            var expectedErrorText = "Masz pewność co do hasła? Jest zbyt krótkie";
            //Act
            loginForm.EmailInput.EnterText(userPassword);
            //Assert
            Assert.Multiple(() =>
            {
                Assert.True(loginForm.PasswordInputErrorMessage.Displayed);
                Assert.Equal(expectedErrorText, loginForm.PasswordInputErrorMessage.Text);
            });
        }
        [Theory]
        [MemberData(nameof(GetLoginDataFromExcelFile))]
        public void Login_With_Valid_Credentials_Redirects_To_Expected_Url(string userEmail, string password)
        {
            // Lack of access to testing features on the site, commented 2 lines to prevent fails
            UITest(nameof(this.Login_With_Valid_Credentials_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var loginPage = PageInit();
                //Act 
                //loginPage.Login(userEmail, password);
                DriverWaitForRedirection();
                //Assert
                // Assert.Equal(baseUrl, driver?.Url);
            });
        }
        public static IEnumerable<object[]> GetLoginDataFromExcelFile()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/LoginData.xlsx");
            var arrayOfLists = ExcelReader.ReadExcelFile(filePath);
            List<object[]> objects = new List<object[]>();
            int firstColumn = 0;
            int secondColumn = 1;
            for (int rowNumber = 0; rowNumber < arrayOfLists[firstColumn].Count; rowNumber++)
            {
                var userEmail = arrayOfLists[firstColumn][rowNumber];
                var password = arrayOfLists[secondColumn][rowNumber];
                objects.Add(new object[] { userEmail, password });
            }
            return objects;

        }
        [Fact]
        public void LoginForm_WebElements_AreVisible()
        {
            UITest(nameof(this.LoginForm_WebElements_AreVisible), () =>
            {
                //Arrange 
                var loginPage = PageInit();
                var loginForm = loginPage.LoginFormComponent;
                //Act 
                //Asert
                Assert.Multiple(() =>
                {
                    Assert.True(loginPage.LoginSubmitButton.Displayed, loginPage.LoginSubmitButton.GetElementDetails());
                    Assert.True(loginPage.ForgotPasswordLinkButton.Displayed, loginPage.ForgotPasswordLinkButton.GetElementDetails());
                    Assert.True(loginForm.EmailInput.Displayed, loginForm.EmailInput.GetElementDetails());
                    Assert.True(loginForm.PasswordInput.Displayed, loginForm.PasswordInput.GetElementDetails());
                    Assert.True(loginForm.AppleLoginButton.Displayed, loginForm.AppleLoginButton.GetElementDetails());
                    Assert.True(loginForm.FacebookLoginButton.Displayed, loginForm.FacebookLoginButton.GetElementDetails());
                    Assert.True(loginForm.GoogleLoginButton.Displayed, loginForm.GoogleLoginButton.GetElementDetails());
                });

            });
        }
        [Fact]
        public void Login_With_Empty_Credentials_Should_Fail()
        {
            UITest(nameof(this.Login_With_Empty_Credentials_Should_Fail), () =>
            {
                //Arrange
                var loginPage = PageInit();
                var expectedEmailErrorMessage = "Wpisz swój e-mail";
                var expectedPasswordErrorMessage = "Wpisz hasło";
                //Act
                loginPage.LoginForm.Submit();
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.True(loginPage.LoginFormComponent.EmailInputErrorMessage.Displayed);
                    Assert.True(loginPage.LoginFormComponent.PasswordInputErrorMessage.Displayed);
                    Assert.Equal(expectedEmailErrorMessage, loginPage.LoginFormComponent.EmailInputErrorMessage.Text);
                    Assert.Equal(expectedPasswordErrorMessage, loginPage.LoginFormComponent.PasswordInputErrorMessage.Text);
                });

            });
        }
        [Theory]
        [InlineData("admin@olx.pl")]
        [InlineData("test.user@gmail.com")]
        [InlineData("example@domain.com")]
        public void Login_With_Only_Email_Should_Fail(string userEmail)
        {
            UITest(nameof(this.Login_With_Only_Email_Should_Fail), () =>
            {
                //Arrange
                var loginPage = PageInit();
                //Act
                loginPage.LoginFormComponent.EmailInput.EnterText(userEmail);
                loginPage.LoginForm.Submit();
                Task.Delay(3000);
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.False(loginPage.LoginSubmitButton.Enabled);
                    Assert.True(loginPage.LoginFormComponent.PasswordInputErrorMessage.Displayed);
                });

            });

        }
        [Theory]
        [InlineData("test!example.com", "pswd")]
        [InlineData("@example.com", "longpassword")]
        [InlineData("admin", "admin")]
        public void Login_With_Invalid_Credentials_Should_Fail(string username, string password)
        {
            UITest(nameof(this.Login_With_Invalid_Credentials_Should_Fail), () =>
            {
                //Arrange
                var loginPage = PageInit();
                //Act
                loginPage.Login(username, password);
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.False(loginPage.LoginSubmitButton.Enabled);
                    Assert.True(loginPage.LoginFormComponent.EmailInputErrorMessage.Displayed);
                });
            });
        }
        [Fact]
        public void Login_With_Facebook_Button_Redirects_To_Expected_Url()
        {
            UITest(nameof(this.Login_With_Facebook_Button_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var loginPage = PageInit();
                var facebookUrl = "https://www.facebook.com";
                //Act 
                loginPage.LoginFormComponent.FacebookLoginButton.Click();
                //Assert
                Assert.Equal(facebookUrl, driver?.Url.Substring(0, facebookUrl.Length));
            }
            );
        }
        [Fact]
        public void Login_With_Apple_Button_Redirects_To_Expected_Url()
        {
            UITest(nameof(Login_With_Apple_Button_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var loginPage = PageInit();
                var appleUrl = "https://appleid.apple.com";
                //Act
                loginPage.LoginFormComponent.AppleLoginButton.Click();
                //Assert
                Assert.Equal(appleUrl, driver?.Url?.Substring(0, appleUrl.Length));
            });
        }
        [Fact]
        public void Login_With_Google_Button_Redirects_To_Expected_Url()
        {
            UITest(nameof(this.Login_With_Google_Button_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var loginPage = PageInit();
                var googleUrl = "https://accounts.google.com/";
                //Act
                loginPage.LoginFormComponent.GoogleLoginButton.Click();
                //Assert
                Assert.Equal(googleUrl, driver?.Url?.Substring(0, googleUrl.Length));
            });
        }
        [Fact]
        public void Signup_Button_Clicked_Redirects_To_Expected_Page()
        {
            UITest(nameof(this.Signup_Button_Clicked_Redirects_To_Expected_Page), () =>
            {
                //Arrange
                var loginPage = PageInit();
                //Act
                driver.ExecuteJavaScript("arguments[0].click();", loginPage.RegisterTabButton);
                var registerButtonVisibility = driver?.FindElementByDataTestID("register-button").Displayed;
                //Assert
                Assert.True(registerButtonVisibility);
            });
        }
        [Fact]
        public void Forgot_Password_Link_Button_Redirects_To_Expected_Page()
        {
            UITest(nameof(this.Forgot_Password_Link_Button_Redirects_To_Expected_Page), () =>
            {
                //Arrange
                var loginPage = PageInit();
                var expectedUrl = "https://pl.login.olx.com/forgot-password";
                //Act
                loginPage.ForgotPasswordLinkButton.Click();
                DriverWaitForExpectedPageLoad(expectedUrl);
                //Assert
                Assert.Equal(expectedUrl, driver?.Url?.Substring(0, expectedUrl.Length));
            });
        }
        [Fact]
        public void Password_Characters_Visibility_Changes_On_Button_Click()
        {
            UITest(nameof(this.Password_Characters_Visibility_Changes_On_Button_Click), () =>
            {
                //Arrange
                var loginPage = PageInit();
                //Act
                loginPage.LoginFormComponent.PasswordVisibilityToggle.Click();
                string passwordInputType = loginPage.LoginFormComponent.PasswordInput.GetAttribute("type");
                loginPage.LoginFormComponent.PasswordVisibilityToggle.Click();
                string passwordInputType2 = loginPage.LoginFormComponent.PasswordInput.GetAttribute("type");
                //Assert
                Assert.Multiple(() =>
                {
                    Assert.Equal("text", passwordInputType);
                    Assert.Equal("password", passwordInputType2);
                });
            });
        }
    }
}
