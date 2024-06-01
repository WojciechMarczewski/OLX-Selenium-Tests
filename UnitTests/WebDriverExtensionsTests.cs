using OLX_Selenium_Tests.Helpers;
using OLX_Selenium_Tests.UnitTests.Dummies;
using OpenQA.Selenium;

namespace OLX_Selenium_Tests.UnitTests
{
    public class WebDriverExtensionsTests
    {
        [Theory]
        [InlineData("100 zł", 100)]
        [InlineData("$134,43", 134)]
        [InlineData("356.43", 356)]
        public void ConvertTextToInt_ReturnsExpectedValue(string inputValue, int expectedValue)
        {
            //Arrange
            var driver = new WebDriverDummy();
            IWebElement webElement = new WebElementDummy(inputValue);
            //Act
            int result = WebDriverExtensions.ConvertTextToInt(webElement);
            //Asert
            Assert.Equal(expectedValue, result);
        }
    }
}
