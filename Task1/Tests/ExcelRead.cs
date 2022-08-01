using MySqlX.XDevAPI;
using NPOI.SS.UserModel;
using NPOI.Util;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Tests
{
    class ExcelRead
    {
        [Test]
        public void ReadExcel()
        {
            string excelFilePath = @"C:\Users\ashwa\source\repos\FLIPKART2\Task1\ExcelData.xlsx";
            FileStream inputstream = new FileStream(excelFilePath,FileMode.Open,FileAccess.Read);
            XSSFWorkbook workbook = new XSSFWorkbook(inputstream);
           ISheet sheet= workbook.GetSheetAt(0);

            int rows = sheet.LastRowNum;
            int cols = sheet.GetRow(0).LastCellNum;

            for(int r=0;r<=rows;r++)
            {
                IRow row= sheet.GetRow(r);

                for(int c=0;c<cols;c++)
                {
                  ICell cell= row.GetCell(c);

                    switch(cell.CellType)
                    {
                        case CellType.String : TestContext.Progress.Write(cell.StringCellValue); break;
                        case CellType.Numeric: TestContext.Progress.Write(cell.NumericCellValue); break;
                        case CellType.Boolean: TestContext.Progress.Write(cell.BooleanCellValue); break;
                    }
                    TestContext.Progress.Write(" | ");
                }
                TestContext.Progress.WriteLine();

            }
        }
    }
}
