using Allegro_Selenium_Tests.Helpers;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
namespace Allegro_Selenium_Tests.PageObjects
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver webDriver) : base(webDriver)
        {
        }
        /// <summary>
        /// Property represents search box used to search for products and service on the site.
        /// </summary>
        private IWebElement userSearchInput => driver.FindElement(By.Id("search"));
        /// <summary>
        /// Property represents button which is used to submit entered text in the <see cref="userSearchInput"/>.
        /// </summary>
        private IWebElement userSearchButton => driver.FindElement(By.Name("searchBtn"));
        /// <summary>
        /// Property represents accept button which appears along with cookies information every time when there are no site cookies saved in the browser.
        /// </summary>
        private IWebElement oneTrustAcceptButton => driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        /// <summary>
        /// Property represents input box used to narrow search results by location.
        /// </summary>
        private IWebElement locationSearchInput => driver.FindElement(By.Id("location-input"));
        /// <summary>
        /// Property represents container of clickable elements in dropdown list triggered to open when <see cref="locationSearchInput"/> is clicked focused (clicked).
        /// </summary>
        private IWebElement locationRegionContainer => driver.FindElement(By.ClassName("css-1amhcb2"));
        /// <summary>
        /// Property represents every element of <see cref="locationSearchInput"/> list.
        /// </summary>
        private ReadOnlyCollection<IWebElement> regionListElements => locationRegionContainer.FindElements(By.TagName("li"));
        /// <summary>
        /// Property represents each city in selected region in the <see cref="regionListElements"/>.
        /// </summary>
        private ReadOnlyCollection<IWebElement> regionCityListElements => locationRegionContainer.FindElements(By.ClassName("css-11ogzbo"));
        /// <summary>
        /// Property represents container with suggested locations that are displayed when user types any keyword in <see cref="locationSearchInput"/>
        /// </summary>
        private IWebElement locationSuggestionContainer => driver.FindElement(By.ClassName("css-yz55v6"));
        /// <summary>
        /// Property represents every element in <see cref="locationSuggestionContainer"/>.
        /// </summary>
        private ReadOnlyCollection<IWebElement> locationSuggestionElements => locationSuggestionContainer.FindElements(By.XPath("//*[@data-testid='suggestion-item']"));
        /// <summary>
        /// Property represents container of clickable links leading to appropriate category page
        /// </summary>
        private IWebElement mainCategoryContainer => driver.FindElement(By.ClassName("css-1rwzo2t"));
        /// <summary>
        /// Property represents every link in <see cref="mainCategoryContainer"/>
        /// </summary>
        private ReadOnlyCollection<IWebElement> mainCategoryLinks => mainCategoryContainer.FindElements(By.TagName("a"));
        /// <summary>
        /// Property represents every link under category element
        /// </summary>
        private ReadOnlyCollection<IWebElement> mainCategorySubLinks => mainCategoryContainer.FindElements(By.ClassName("css-f0mzyq"));
        /// <summary>
        /// Property represents link to general category page
        /// </summary>
        private IWebElement mainCategoryRootLink => mainCategoryContainer.FindElement(By.ClassName("css-30858w"));
        /// <summary>
        /// Property represents container of direct links to ads on the site
        /// </summary>
        private IWebElement adContainer => driver.FindElement(By.ClassName("css-127xiqh"));
        /// <summary>
        /// Property represents list of add favorite buttons related with ad in the <see cref="adContainer"/>
        /// </summary>
        private ReadOnlyCollection<IWebElement> adContainerElementFavorites => adContainer.FindElements(By.ClassName("css-wfo1e3"));
        public void ClickSearch()
        {
            userSearchButton.Click();
        }
        public void PerformSearchBoxQuery(string query)
        {
            userSearchInput.EnterText(query);
            userSearchButton.Click();
        }
        public void ClickTrustAccept()
        {
            oneTrustAcceptButton.Click();
        }
        public void ClickLocationInput()
        {
            locationSearchInput.Click();
        }
        public void PerformLocationSearchWithFirstResultClicked(string query)
        {
            ClickLocationInput();
            locationSearchInput.EnterText(query);
            locationSuggestionElements[0].Click();
        }
        private void ClickRegionItem(string region)
        {
            ClickLocationInput();
            regionListElements.First(x => x.Text == region).Click();
        }
        public void ClickRegionAndCity(string region, string city)
        {
            ClickRegionItem(region);
            ClickCityItem(city);
        }
        private void ClickCityItem(string city)
        {
            regionCityListElements.First(x => x.Text == city).Click();
        }
        public void ClickMainCategory(string testID)
        {
            string url = driver.Url.ToString();
            mainCategoryLinks.First(x => x.GetAttribute("data-testid") == testID).Click();
            if (driver.Url == url)
            {
                mainCategoryRootLink.Click();
            }
        }
        public void ClickMainCategoryWithSubCategory(string categoryTestID, string subCategoryName)
        {
            string url = driver.Url.ToString();
            mainCategoryLinks.First(x => x.GetAttribute("data-testid") == categoryTestID).Click();
            if (driver.Url == url)
            {
                mainCategorySubLinks.First(x => x.Text == subCategoryName).Click();
            }
        }
        public void ClickAdElementFavorite()
        {
            adContainerElementFavorites.First().Click();
        }
    }
}
