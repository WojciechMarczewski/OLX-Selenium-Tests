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
            page.Click_TrustAccept();
            return page;
        }

        [Theory]
        [InlineData("100")]
        [InlineData("100000")]
        [InlineData("-100")]
        [InlineData("1000000000")]
        public void Price_Range_From_X_Returns_Expected_Results(string priceFrom)
        {
            UITest(nameof(this.Price_Range_From_X_Returns_Expected_Results), () =>
            {
                //Arrange
                var resultsPage = PageInit();
                //Act 
                resultsPage.Set_PriceRange_From(priceFrom);
                DriverWaitForRedirection();
                var priceList = resultsPage.Get_AdvertPriceList();
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
            });

        }
        [Theory]
        [InlineData("test")]
        [InlineData("$^%^H")]
        [InlineData("")]
        [InlineData(" ")]
        public void Price_Range_From_X_When_Invalid_Price_Entered_Should_Stay_On_The_Same_Page(string price)
        {
            UITest(nameof(this.Price_Range_From_X_When_Invalid_Price_Entered_Should_Stay_On_The_Same_Page), () =>
            {
                //Arrange
                var resultsPage = PageInit();
                //Act
                resultsPage.Set_PriceRange_From(price);
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(url + "/", driver?.Url);
            });
        }



        [Theory]
        [InlineData("toyota yaris", "/oferty/q-toyota-yaris/")]
        [InlineData("spawacz praca", "/oferty/q-spawacz-praca/")]
        public void SearchBox_Valid_Query_Redirects_To_Expected_Url(string query, string expectedResult)
        {
            UITest(nameof(this.SearchBox_Valid_Query_Redirects_To_Expected_Url), () =>
            {
                //Arrange
                var resultsPage = PageInit();
                //Act
                resultsPage.SearchBox.EnterQueryText_And_Click_SearchButton(query);
                DriverWaitForRedirection();
                //Assert
                Assert.Equal(baseUrl + expectedResult, driver?.Url);
            });
        }

        [Theory]
        [InlineData("Lubelskie", "Adamów", "/adamow_2217/")]
        [InlineData("Mazowieckie", "Otwock", "/otwock/")]
        public void SearchBox_Location_Query_Redirects_To_Expected_Url(string region, string city, string expectedUrl)
        {
            UITest(nameof(this.SearchBox_Location_Query_Redirects_To_Expected_Url), () =>
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
                Assert.Equal(baseUrl + expectedUrl, driver?.Url);
            });

        }

        [Theory]
        [InlineData("Mazowieckie", "Wołomin", "Buty Damskie", "/wolomin/q-Buty-Damskie/")]
        [InlineData("Pomorskie", "Pruszcz Gdański", "Truskawki", "/pruszcz-gdanski/q-Truskawki/")]
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
                Assert.Equal(baseUrl + expectedUrl, driver?.Url);
            });

        }

    }
}
