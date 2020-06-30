using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleClassSorterer
{
    class XlsxSerialiser
    {
        private MarkTable markTable;
        private List<string> trueNames;

        public XlsxSerialiser(MarkTable markTable, List<string> trueName)
        {
            this.markTable = markTable;
            trueNames = new List<string>();
            foreach (var item in trueName)
            {
                trueNames.Add(item);
            }
        }

        internal void Serialize(FileStream fs)
        {
            var workbook = new XLWorkbook();

            List<Pupil> pupilsForWriting = markTable.Pupils.Where(x => x.TrueName != null && trueNames.IndexOf(x.TrueName)!=-1).ToList();

            var ws = workbook.Worksheets.Add("Grades");
            for (int i = 0; i < markTable.Lessons.Count; i++)
            {
                ws.Cell(1, i + 4).Value = markTable.Lessons[i].Date;
                ws.Cell(2, i + 4).Value = markTable.Lessons[i].Theme;
            }

            for (int i = 0; i < pupilsForWriting.Count; i++)
            {
                ws.Cell(i + 3, 1).Value = pupilsForWriting[i].FirstName;
                ws.Cell(i + 3, 2).Value = pupilsForWriting[i].LastName;
                ws.Cell(i + 3, 3).Value = pupilsForWriting[i].TrueName;
                trueNames.Remove(pupilsForWriting[i].TrueName);
                for (int j = 0; j < markTable.Lessons.Count; j++)
                {
                    ws.Cell(i + 3, j + 4).Value = markTable[pupilsForWriting[i], markTable.Lessons[j]];
                }
            }
            int lastRowNum = ws.LastRowUsed().RowNumber()+1;
            foreach (var notNamedPupil in trueNames)
            {
                ws.Cell(lastRowNum, 3).Value = notNamedPupil;
                lastRowNum++;
            }

            var firstCell = ws.Cell(3, 1);
            var lastCell = ws.LastCellUsed();
            var range = ws.Range(firstCell, lastCell);
            //range.Sort(3);

            workbook.SaveAs(fs);
        }
    }
}
