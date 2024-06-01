using OLX_Selenium_Tests.PageComponentObjects;
using OLX_Selenium_Tests.PageObjects;

namespace OLX_Selenium_Tests.PageTests
{
    public class SearchResultsPageTests : PageTestBase
    {

        public SearchResultsPageTests() : base("https://www.olx.pl/oferty") { }
        private string baseUrl = "https://www.olx.pl";
        public SearchResultsPage PageInit()
        {
            var driver = DriverInit();
            var searchBoxComponent = new SearchBoxComponent(driver);
            SearchResultsPage page = new SearchResultsPage(driver, searchBoxComponent);
            page.ClickTrustAccept();
            return page;
        }

        [Theory]
        [InlineData("100")]
        [InlineData("100000")]
        [InlineData("-100")]
        [InlineData("1000000000")]
        public void PriceRangeFrom_ReturnsExpectedResults(string priceFrom)
        {
            //Arrange
            var resultsPage = PageInit();
            //Act 
            resultsPage.SetPriceRangeFrom(priceFrom);
            DriverWaitForPageLoad();
            var priceList = resultsPage.GetAdvertPriceList();
            List<int> outOfScopePrice = new List<int>();
            foreach (var price in priceList)
            {
                if (price < Convert.ToInt32(priceFrom))
                {
                    outOfScopePrice.Add(price);
                }
            }
            //Assert
            Assert.Empty(outOfScopePrice);

        }
        [Theory]
        [InlineData("test")]
        [InlineData("$^%^H")]
        [InlineData("")]
        [InlineData(" ")]
        public void PriceRangeFrom_WhenInvalidPriceEntered_ShouldStayOnSamePage(string price)
        {
            //Arrange
            var resultsPage = PageInit();
            //Act
            resultsPage.SetPriceRangeFrom(price);
            DriverWaitForPageLoad();
            //Assert
            Assert.Equal(url + "/", driver?.Url);
        }



        [Theory]
        [InlineData("toyota yaris", "/oferty/q-toyota-yaris/")]
        [InlineData("spawacz praca", "/oferty/q-spawacz-praca/")]
        public void SearchBoxQuery_RedirectsToExpectedUrl(string query, string expectedResult)
        {

            //Arrange
            var resultsPage = PageInit();
            //Act
            resultsPage.SearchBox.PerformSearchBoxQuery(query);
            DriverWaitForPageLoad();
            //Assert
            Assert.Equal(baseUrl + expectedResult, driver?.Url);
        }

        [Theory]
        [InlineData("Lubelskie", "Adamów", "/adamow_2217/")]
        [InlineData("Mazowieckie", "Otwock", "/otwock/")]
        public void SearchBoxLocationQuery_RedirectsToExpectedUrl(string region, string city, string expectedUrl)
        {
            //Arrange
            var landingPage = PageInit();
            var searchBox = landingPage.SearchBox;
            //Act
            searchBox.ClickLocationInput();
            searchBox.ClickRegionAndCity(region, city);
            searchBox.ClickSearch();
            DriverWaitForPageLoad();
            //Assert
            Assert.Equal(baseUrl + expectedUrl, driver?.Url);

        }

        [Theory]
        [InlineData("Mazowieckie", "Wołomin", "Buty Damskie", "/wolomin/q-Buty-Damskie/")]
        [InlineData("Pomorskie", "Pruszcz Gdański", "Truskawki", "/pruszcz-gdanski/q-Truskawki/")]
        public void SearchBoxCombinedQuery_RedirectsToExpectedUrl(string region, string city, string query, string expectedUrl)
        {
            //Arrange
            var landingPage = PageInit();
            var searchBox = landingPage.SearchBox;
            //Act
            searchBox.ClickLocationInput();
            searchBox.ClickRegionAndCity(region, city);
            searchBox.PerformSearchBoxQuery(query);
            DriverWaitForPageLoad();
            //Assert
            Assert.Equal(baseUrl + expectedUrl, driver?.Url);

        }

    }
}
