using Allegro_Selenium_Tests.PageObjects;
using OpenQA.Selenium;

namespace OLX_Selenium_Tests.Tests
{
    public class LandingPageTests : PageTestBase
    {
        public LandingPageTests() : base("https://www.olx.pl")
        {

        }
        private LandingPage PageInit()
        {
            var driver = DriverInit();
            LandingPage landingPage = new LandingPage(driver);
            landingPage.ClickTrustAccept();
            return landingPage;
        }

        [Theory]
        [InlineData("toyota yaris", "/oferty/q-toyota-yaris/")]
        [InlineData("spawacz praca", "/oferty/q-spawacz-praca/")]
        public void SearchBoxQuery_RedirectsToExpectedUrl(string query, string expectedResult)
        {

            //Arrange
            var landingPage = PageInit();
            //Act
            landingPage.PerformSearchBoxQuery(query);
            DriverWaitForPageLoading();
            //Assert
            Assert.Equal(url + expectedResult, driver?.Url);
        }

        [Theory]
        [InlineData("Lubelskie", "Adamów", "/adamow_2217/")]
        [InlineData("Mazowieckie", "Otwock", "/otwock/")]
        public void SearchBoxLocationQuery_RedirectsToExpectedUrl(string region, string city, string expectedUrl)
        {
            //Arrange
            var landingPage = PageInit();
            //Act
            landingPage.ClickLocationInput();
            landingPage.ClickRegionAndCity(region, city);
            landingPage.ClickSearch();
            DriverWaitForPageLoading();
            //Assert
            Assert.Equal(url + expectedUrl, driver?.Url);

        }

        [Theory]
        [InlineData("Mazowieckie", "Wo³omin", "Buty Damskie", "/wolomin/q-Buty-Damskie/")]
        [InlineData("Pomorskie", "Pruszcz Gdañski", "Truskawki", "/pruszcz-gdanski/q-Truskawki/")]
        public void SearchBoxCombinedQuery_RedirectsToExpectedUrl(string region, string city, string query, string expectedUrl)
        {
            //Arrange
            var landingPage = PageInit();
            //Act
            landingPage.ClickLocationInput();
            landingPage.ClickRegionAndCity(region, city);
            landingPage.PerformSearchBoxQuery(query);
            DriverWaitForPageLoading();
            //Assert
            Assert.Equal(url + expectedUrl, driver?.Url);

        }
        [Theory]
        [InlineData("cat-4042", "/antyki-i-kolekcje/")]
        [InlineData("cat-3", "/nieruchomosci/")]
        public void CategoryLink_RedirectsToExpectedUrl(string testID, string expectedUrl)
        {
            //Arrange
            var landingPage = PageInit();
            //Act
            landingPage.ClickMainCategory(testID);
            DriverWaitForPageLoading();
            //Assert
            Assert.Equal(url + expectedUrl, driver?.Url);
        }
        [Theory]
        [InlineData("cat-4371", "Obs³uga imprez", "/uslugi/obsluga-imprez/")]
        [InlineData("cat-3018", "Jachty, ³odzie i sporty wodne", "/wypozyczalnia/czartery-jachty-i-lodzie/")]
        public void CategoryAndSubCategoryLink_RedirectsToExpectedUrl(string categoryTestID, string subCategoryName, string expectedUrl)
        {
            //Arrange 
            var landingPage = PageInit();
            //Act
            landingPage.ClickMainCategoryWithSubCategory(categoryTestID, subCategoryName);
            DriverWaitForPageLoading();
            //Assert
            Assert.Equal(url + expectedUrl, driver?.Url);
        }
        [Theory]
        [InlineData("krak", "/krakow/")]
        [InlineData("war", "/warszawa/")]
        public void SearchBoxLocationInputWithSuggestion_RedirectsToExpectedUrl(string query, string expectedUrl)
        {
            //Arrange
            var landingPage = PageInit();
            //Act
            landingPage.PerformLocationSearchWithFirstResultClicked(query);
            landingPage.ClickSearch();
            DriverWaitForPageLoading();
            //Assert
            Assert.Equal(url + expectedUrl, driver?.Url);
        }

        [Theory]
        [InlineData("css-mf7uyd")]
        public void AdContainerFavoriteClick_PopsExpectedModal(string modalClassName)
        {
            //Arrange 
            var landingPage = PageInit();
            //Act
            landingPage.ClickAdElementFavorite();
            var modal = driver?.FindElement(By.ClassName(modalClassName));

            //Assert
            Assert.NotNull(modal);
        }

    }
}