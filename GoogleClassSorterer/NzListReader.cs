using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleClassSorterer
{
    class NzListReader
    {
        public static List<string> GetList(string fileName)
        {
            List<string> strings = new List<string>();
            StreamReader streamReader = new StreamReader(fileName);

            var workbook = new XLWorkbook(fileName);
            var worksheet = workbook.Worksheet(1);

            var row = 3;
            string curr = worksheet.Cell(row, 2).GetValue<string>();
            while (curr!="")
            {
                strings.Add(curr);
                row++;
                curr = worksheet.Cell(row, 2).GetValue<string>();   

            }

            streamReader.Close();
            return strings;
        }
    }
}
