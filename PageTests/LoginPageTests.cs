using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.PageObjects;

namespace OLX_Selenium_Tests.PageTests
{
    public class LoginPageTests : PageTestBase
    {
        private string baseUrl = "https://www.olx.pl/";
        public LoginPageTests() : base("http://www.olx.pl/konto/?ref[0][params][url]=http%3A%2F%2Fwww.olx.pl%2F&ref[0][action]=redirector&ref[0][method]=index") { }
        public LoginPage PageInit()
        {
            var driver = DriverInit();
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickTrustAccept();
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
            var expectedErrorText = "To nie wygląda jak adres mailowy...";
            //Act
            loginPage.EnterUserEmail(userEmail);
            //Assert
            Assert.True(loginPage.IsEmailInputErrorMessageVisible());
            Assert.Equal(expectedErrorText, loginPage.GetEmaiInputErrorMessage());
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
            var expectedErrorText = "Masz pewność co do hasła? Jest zbyt krótkie";
            //Act
            loginPage.EnterUserPassword(userPassword);
            //Assert
            Assert.True(loginPage.IsPasswordInputErrorMessageVisible());
            Assert.Equal(expectedErrorText, loginPage.GetPasswordInputErrorMessage());
        }
        [Theory]
        [MemberData(nameof(GetLoginData))]
        public void LoginForm_WhenCorrectDataSubmitted_RedirectsToExpectedURL(string userEmail, string password)
        {
            //Arrange
            var loginPage = PageInit();
            //Act 
            loginPage.Login(userEmail, password);
            DriverWaitForPageLoad();
            //Assert
            Assert.Equal(baseUrl, driver?.Url);
        }
        public static IEnumerable<object[]> GetLoginData()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/LoginData.xlsx");
            var arrayOfLists = ExcelReader.ReadExcelFile(filePath);
            List<object[]> objects = new List<object[]>();
            for (int i = 0; i < arrayOfLists[0].Count; i++)
            {
                var userEmail = arrayOfLists[0][i];
                var password = arrayOfLists[1][i];
                objects.Add(new object[] { userEmail, password });
            }
            return objects;

        }
    }
}
