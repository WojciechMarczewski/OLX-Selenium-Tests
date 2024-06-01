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
        private IWebElement priceRangeFromInput => driver.FindElement(By.Name("range-from-input"));
        private IWebElement priceRangeToInput => driver.FindElement(By.Name("range-to-input"));
        private IWebElement advertListContainer => driver.FindElement(By.ClassName("css-j0t2x2"));
        private ReadOnlyCollection<IWebElement> advertList => advertListContainer.FindElements(By.XPath("//*[@data-testid='l-card']"));
        private ReadOnlyCollection<IWebElement> advertPriceList => advertListContainer.FindElements(By.XPath("//*[@data-testid='ad-price']"));

        public void SetPriceRangeFrom(string price)
        {
            priceRangeFromInput.EnterText(price);
            priceRangeFromInput.SendKeys(Keys.Enter);

        }
        public void SetPriceRangeTo(string price)
        {
            priceRangeToInput.EnterText(price);

        }
        public List<int> GetAdvertPriceList()
        {

            return advertPriceList.Select(x => x.ConvertTextToInt()).ToList();
        }
    }
}
