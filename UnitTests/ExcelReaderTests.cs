using OLX_Selenium_Tests.Helpers;

namespace OLX_Selenium_Tests.UnitTests
{
    public class ExcelReaderTests
    {
        [Fact]
        public void ReadExcelFileMethod_ReturnsCorrectData()
        {
            //Arrange
            var filePath = "E:\\Selenium Tests\\OLX\\UnitTests\\TestFile.xlsx";
            List<string> expectedColumnA = new List<string>()
            {
                "Test1A",
                "Test2A"
            };
            List<string> expectedColumnB = new List<string>()
            {
                "Test1B",
                "Test2B"
            };
            //Act 
            var arrayOfLists = ExcelReader.ReadExcelFile(filePath);
            bool testFailed = false;
            for (int i = 0; i < arrayOfLists[0].Count; i++)
            {
                if (expectedColumnA[i] != arrayOfLists[0][i])
                {
                    testFailed = true;
                }
            }
            for (int i = 0; i < arrayOfLists[0].Count; i++)
            {
                if (expectedColumnB[i] != arrayOfLists[1][i])
                {
                    testFailed = true;
                }
            }
            //Assert
            Assert.False(testFailed);



        }
    }
}
