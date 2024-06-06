using OLX_Selenium_Tests.PageComponentObjects;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
namespace OLX_Selenium_Tests.PageObjects
{
    public class LandingPage : BasePage
    {
        public LandingPage(IWebDriver webDriver, SearchBoxComponent searchBoxComponent) : base(webDriver)
        {
            SearchBox = searchBoxComponent;
        }
        public SearchBoxComponent SearchBox;
        public IWebElement MainCategoryContainer => driver.FindElement(By.ClassName("css-1rwzo2t"));
        public ReadOnlyCollection<IWebElement> MainCategoryLinks => MainCategoryContainer.FindElements(By.TagName("a"));
        public ReadOnlyCollection<IWebElement> MainCategorySubLinks => MainCategoryContainer.FindElements(By.ClassName("css-f0mzyq"));
        public IWebElement MainCategoryRootLink => MainCategoryContainer.FindElement(By.ClassName("css-30858w"));
        public IWebElement AdContainer => driver.FindElement(By.ClassName("css-127xiqh"));
        public ReadOnlyCollection<IWebElement> AdContainerElementFavorites => AdContainer.FindElements(By.ClassName("css-wfo1e3"));
        public void Click_MainCategory(string testID)
        {
            string url = driver.Url.ToString();
            MainCategoryLinks.First(x => x.GetAttribute("data-testid") == testID).Click();
            if (driver.Url == url)
            {
                MainCategoryRootLink.Click();
            }
        }
        public void Click_MainCategory_Then_SubCategory(string categoryTestID, string subCategoryName)
        {
            string url = driver.Url.ToString();
            MainCategoryLinks.First(x => x.GetAttribute("data-testid") == categoryTestID).Click();
            if (driver.Url == url)
            {
                MainCategorySubLinks.First(x => x.Text == subCategoryName).Click();
            }
        }
        public void ClickFirst_AdvertAddToFavorite() => AdContainerElementFavorites.First().Click();

    }
}
