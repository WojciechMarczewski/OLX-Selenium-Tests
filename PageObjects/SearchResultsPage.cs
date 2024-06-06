using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.PageComponentObjects;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
namespace OLX_Selenium_Tests.PageObjects
{
    public class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver webDriver, SearchBoxComponent searchBoxComponent) : base(webDriver)
        {
            SearchBox = searchBoxComponent;
        }
        public SearchBoxComponent SearchBox;
        public IWebElement PriceRangeFromInput => driver.FindElement(By.Name("range-from-input"));
        public IWebElement PriceRangeToInput => driver.FindElement(By.Name("range-to-input"));
        public IWebElement AdvertListContainer => driver.FindElement(By.ClassName("css-j0t2x2"));
        public ReadOnlyCollection<IWebElement> AdvertList => AdvertListContainer.FindElements(By.XPath("//*[@data-testid='l-card']"));
        public ReadOnlyCollection<IWebElement> AdvertPriceList => AdvertListContainer.FindElements(By.XPath("//*[@data-testid='ad-price']"));

        public void Set_PriceRange_From(string price)
        {
            PriceRangeFromInput.EnterText(price);
            PriceRangeFromInput.SendKeys(Keys.Enter);

        }
        public void Set_PriceRange_To(string price) => PriceRangeToInput.EnterText(price);

        public List<int> Get_AdvertPriceList() => AdvertPriceList.Select(x => x.ConvertTextToInt()).ToList();

    }
}
