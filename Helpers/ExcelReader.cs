using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace OLX_Selenium_Tests.Helpers
{
    public static class ExcelReader
    {
        public static List<string>[] ReadExcelFile(string path)
        {
            Workbook workbook;
            Worksheet worksheet;
            var excel = new Application();
            workbook = excel.Workbooks.Open(path, ReadOnly: true);
            worksheet = workbook.Worksheets[1];
            Range range = worksheet.UsedRange;
            int rows = range.Rows.Count;
            int columns = range.Columns.Count;
            List<string>[] arrayOfLists = new List<string>[columns];
            for (int i = 1; i <= columns; i++)
            {
                List<string> strings = new List<string>();
                for (int j = 1; j <= rows; j++)
                {
                    strings.Add(Convert.ToString(worksheet.Cells[j, i].Value));
                }
                arrayOfLists[i - 1] = strings;
            }
            workbook.Close();
            return arrayOfLists;

        }
    }
}
