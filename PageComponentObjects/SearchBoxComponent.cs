using OLX_Selenium_Tests.Helpers;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
namespace OLX_Selenium_Tests.PageComponentObjects
{
    public class SearchBoxComponent : BaseComponent
    {
        public SearchBoxComponent(IWebDriver webDriver) : base(webDriver) { }

        public IWebElement UserSearchInput => driver.FindElement(By.Id("search"));

        public IWebElement UserSearchButton => driver.FindElement(By.Name("searchBtn"));

        public IWebElement LocationRegionContainer => driver.FindElement(By.ClassName("css-1amhcb2"));

        public IWebElement LocationSearchInput => driver.FindElement(By.Id("location-input"));

        public ReadOnlyCollection<IWebElement> RegionListElements => LocationRegionContainer.FindElements(By.TagName("li"));

        public ReadOnlyCollection<IWebElement> RegionCityListElements => LocationRegionContainer.FindElements(By.ClassName("css-11ogzbo"));

        public IWebElement LocationSuggestionContainer => driver.FindElement(By.ClassName("css-yz55v6"));

        public ReadOnlyCollection<IWebElement> LocationSuggestionElements => LocationSuggestionContainer.FindElements(By.XPath("//*[@data-testid='suggestion-item']"));

        public void EnterQueryText_And_Click_SearchButton(string query)
        {
            UserSearchInput.EnterText(query);
            UserSearchButton.Click();
        }
        public void Click_LocationInput() => LocationSearchInput.Click();

        public void Perform_LocationSearch_And_Click_FirstResult(string query)
        {
            Click_LocationInput();
            LocationSearchInput.EnterText(query);
            LocationSuggestionElements[0].Click();
        }
        private void Click_RegionItem(string region)
        {
            Click_LocationInput();
            RegionListElements.First(x => x.Text == region).Click();
        }
        public void Click_Region_Then_City(string region, string city)
        {
            Click_RegionItem(region);
            Click_CityItem(city);
        }
        private void Click_CityItem(string city) => RegionCityListElements.First(x => x.Text == city).Click();

    }
}
