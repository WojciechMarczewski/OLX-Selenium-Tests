using OLX_Selenium_Tests.Helpers;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
namespace OLX_Selenium_Tests.PageComponentObjects
{
    public class SearchBoxComponent : BaseComponent
    {
        public SearchBoxComponent(IWebDriver webDriver) : base(webDriver) { }
        /// <summary>
        /// Property represents search box used to search for products and service on the site.
        /// </summary>
        private IWebElement userSearchInput => driver.FindElement(By.Id("search"));
        /// <summary>
        /// Property represents button which is used to submit entered text in the <see cref="userSearchInput"/>.
        /// </summary>
        private IWebElement userSearchButton => driver.FindElement(By.Name("searchBtn"));
        /// <summary>
        /// Property represents container of clickable elements in dropdown list triggered to open when <see cref="locationSearchInput"/> is clicked focused (clicked).
        /// </summary>
        private IWebElement locationRegionContainer => driver.FindElement(By.ClassName("css-1amhcb2"));
        /// <summary>
        /// Property represents input box used to narrow search results by location.
        /// </summary>
        private IWebElement locationSearchInput => driver.FindElement(By.Id("location-input"));
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
        public void ClickSearch()
        {
            userSearchButton.Click();
        }
        public void PerformSearchBoxQuery(string query)
        {
            userSearchInput.EnterText(query);
            userSearchButton.Click();
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
    }
}
