using OLX_Selenium_Tests.PageComponentObjects;
using OLX_Selenium_Tests.PageObjects;
using OpenQA.Selenium;
namespace OLX_Selenium_Tests.PageTests
{
    public class LandingPageTests : PageTestBase
    {
        public LandingPageTests() : base("https://www.olx.pl") { }
        private LandingPage PageInit()
        {
            var driver = DriverInit();
            SearchBoxComponent searchBox = new SearchBoxComponent(driver);
            LandingPage landingPage = new LandingPage(driver, searchBox);
            landingPage.Click_TrustAccept();
            return landingPage;
        }
        [Theory]
        [InlineData("toyota yaris", "/oferty/q-toyota-yaris/")]
        [InlineData("spawacz praca", "/oferty/q-spawacz-praca/")]
        public void SearchBox_Query_Redirects_To_Expected_Url(string query, string expectedResult)
        {
            UITest(nameof(this.SearchBox_Query_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var landingPage = PageInit();
                //Act
                landingPage.SearchBox.EnterQueryText_And_Click_SearchButton(query);
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + expectedResult, driver?.Url);
            });
        }
        [Theory]
        [InlineData("Lubelskie", "Adamów", "/adamow_2217/")]
        [InlineData("Mazowieckie", "Otwock", "/otwock/")]
        public void SearchBox_Location_Query_Redirects_ToExpected_Url(string region, string city, string expectedUrl)
        {
            UITest(nameof(this.SearchBox_Location_Query_Redirects_ToExpected_Url), () =>
            {
                //Arrange
                var landingPage = PageInit();
                var searchBox = landingPage.SearchBox;
                //Act
                searchBox.Click_LocationInput();
                searchBox.Click_Region_Then_City(region, city);
                searchBox.UserSearchButton.Click();
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + expectedUrl, driver?.Url);
            });
        }
        [Theory]
        [InlineData("Mazowieckie", "Wo³omin", "Buty Damskie", "/wolomin/q-Buty-Damskie/")]
        [InlineData("Pomorskie", "Pruszcz Gdañski", "Truskawki", "/pruszcz-gdanski/q-Truskawki/")]
        public void SearchBox_Combined_Query_Redirects_To_Expected_Url(string region, string city, string query, string expectedUrl)
        {
            UITest(nameof(this.SearchBox_Combined_Query_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var landingPage = PageInit();
                var searchBox = landingPage.SearchBox;
                //Act
                searchBox.Click_LocationInput();
                searchBox.Click_Region_Then_City(region, city);
                searchBox.EnterQueryText_And_Click_SearchButton(query);
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + expectedUrl, driver?.Url);
            });
        }
        [Theory]
        [InlineData("cat-4042", "/antyki-i-kolekcje/")]
        [InlineData("cat-3", "/nieruchomosci/")]
        public void Category_Link_Redirects_To_Expected_Url(string testID, string expectedUrl)
        {
            UITest(nameof(this.Category_Link_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var landingPage = PageInit();
                //Act
                landingPage.Click_MainCategory(testID);
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + expectedUrl, driver?.Url);
            });
        }
        [Theory]
        [InlineData("cat-4371", "Obs³uga imprez", "/uslugi/obsluga-imprez/")]
        [InlineData("cat-3018", "Jachty, ³odzie i sporty wodne", "/wypozyczalnia/czartery-jachty-i-lodzie/")]
        public void Category_And_SubCategory_Link_Redirects_To_Expected_Url(string categoryTestID, string subCategoryName, string expectedUrl)
        {
            UITest(nameof(this.Category_And_SubCategory_Link_Redirects_To_Expected_Url), () =>
            {
                //Arrange 
                var landingPage = PageInit();
                //Act
                landingPage.Click_MainCategory_Then_SubCategory(categoryTestID, subCategoryName);
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + expectedUrl, driver?.Url);
            });
        }
        [Theory]
        [InlineData("krak", "/krakow/")]
        [InlineData("war", "/warszawa/")]
        public void SearchBox_Location_Input_Suggestion_Redirects_To_Expected_Url(string query, string expectedUrl)
        {
            UITest(nameof(this.SearchBox_Location_Input_Suggestion_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var landingPage = PageInit();
                var searchBox = landingPage.SearchBox;
                //Act
                searchBox.Perform_LocationSearch_And_Click_FirstResult(query);
                searchBox.UserSearchButton.Click();
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + expectedUrl, driver?.Url);
            });
        }
        [Theory]
        [InlineData("css-mf7uyd")]
        public void Ad_Favorite_Button_Click_Pops_Expected_Modal(string modalClassName)
        {
            UITest(nameof(this.Ad_Favorite_Button_Click_Pops_Expected_Modal), () =>
            {
                //Arrange 
                var landingPage = PageInit();
                //Act
                landingPage.ClickFirst_AdvertAddToFavorite();
                var modal = driver?.FindElement(By.ClassName(modalClassName));
                //Assert
                Assert.NotNull(modal);
            });
        }


    }
}