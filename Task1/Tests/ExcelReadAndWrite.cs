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
    class ExcelReadAndWrite
    {
        [Test]
        public void ReadExcel()
        {
            string excelFilePath = @"C:\Users\ashwa\source\repos\FLIPKART2\Task1\ExcelReadData.xlsx";
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

        [Test]
        public void WriteExcel()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Emp data");

            dynamic[,] empdata = {
             {"EmpId","Name","Job"},
             {101,"shashvath","Engineer"},
             {102,"Ashwath","Manager"},
             {103,"Sumanth","Analyst"}
             };
     
            int rows = empdata.GetLength(0);
            TestContext.Progress.WriteLine(rows);
            int cols = empdata.GetLength(1);
            TestContext.Progress.WriteLine(cols);

            for (int r=0;r<rows;r++)
            {
                IRow row = sheet.CreateRow(r);
                for (int c=0;c<cols;c++)
                {
                    ICell cell = row.CreateCell(c);
                    Object value = empdata[r, c];

                    if (value is string)
                        cell.SetCellValue((string)value);
                    if (value is double)
                        cell.SetCellValue((double)value);
                    if (value is Boolean)
                        cell.SetCellValue((Boolean)value);
                    if (value is Int32)
                        cell.SetCellValue((Int32)value);
                }
            }

            String filePath = @"C:\Users\ashwa\source\repos\FLIPKART2\Task1\ExcelWriteData.xlsx";
            FileStream fo = new FileStream(filePath, FileMode.Create);
            workbook.Write(fo);
            fo.Close();
        }
    }
    
}
