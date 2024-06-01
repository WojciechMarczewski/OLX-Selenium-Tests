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
