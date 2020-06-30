using CsvHelper;
using CsvHelper.Configuration;
using DocumentFormat.OpenXml.Office2013.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleClassSorterer
{
    class MarkTable
    {
        public MarkTable(string fileName) : this()
        {
            SetFromFile(fileName);
        }

        public MarkTable()
        {
            Lessons = new List<Lesson>();
            Pupils = new List<Pupil>();
            marks = new string[0, 0];
        }

        public string Course { get; set; }
        public List<Lesson> Lessons { get; }
        public List<Pupil> Pupils { get; private set; }

        public string this[Pupil pupil, Lesson lesson]
        {
            get 
            {
                try
                {
                    return marks[Lessons.IndexOf(lesson), Pupils.IndexOf(pupil)];
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException("pupil or lesson haven't found");
                }
                
            }
            set 
            {
                try
                {
                    marks[Lessons.IndexOf(lesson), Pupils.IndexOf(pupil)] = value;
                }
                catch (Exception)
                {
                    throw new IndexOutOfRangeException("pupil or lesson haven't found");
                }
            }
        }

        string[,] marks;

        public void SetFromFile(string fileName)
        {

            DataTable dataTable;
            StreamReader streamReader = new StreamReader(fileName);

            using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            {
                using (var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    using (var dr = new CsvDataReader(csv))
                    {
                        dataTable = new DataTable();
                        dataTable.Load(dr);
                    }
                }
            }
            streamReader.Close();


            foreach (DataColumn column in dataTable.Columns)
            {
                if (column.ColumnName == "Last Name" || column.ColumnName == "First Name" || column.ColumnName =="Email Address")
                    continue;
                Lesson lesson = new Lesson
                {
                    Theme = column.ColumnName
                };

                Lessons.Add(lesson);
            }

            List<RowOfMark> rowMarks = new List<RowOfMark>();

            foreach (DataRow row in dataTable.Rows)
            {
                List<string> rowArray = new List<string>(row.ItemArray.Select(s => s.ToString()));
                if (rowArray[0]=="Date")
                {
                    rowArray.RemoveRange(0, 3);
                    for (int i = 0; i < rowArray.Count; i++)
                    {
                        Lessons[i].Date = rowArray[0];
                    }
                    continue;
                }

                if (rowArray[0] == "Points") continue;

                rowMarks.Add(new RowOfMark(new List<string>(row.ItemArray.Select(s => s.ToString()))));
            }
            SetPupils(rowMarks);

            Marks(rowMarks);

            JoinTheSamePupil();
        }

        public void JoinTheSamePupil()
        {
            for (int i = Pupils.Count-1; i >=0; i--)
            {
                Pupil theSame = Pupils.FirstOrDefault(x => x.TrueName!=null && x.TrueName == Pupils[i].TrueName);
                if (theSame!=null && Pupils[i] != theSame)
                {
                    theSame.FirstName += $" or {Pupils[i].FirstName}";
                    theSame.LastName += $" or {Pupils[i].LastName}";
                    theSame.Email += $" or {Pupils[i].Email}";
                    foreach (var lesson in Lessons)
                    {
                        this[theSame, lesson] += $" {this[Pupils[i], lesson]}";
                    }
                    RemoveRow(i);
                }
                
            }
        }

        private void RemoveRow(int i)
        {
            string[,] newMarks = new string[marks.GetLength(0), marks.GetLength(1)-1];

            for (int x = 0; x < newMarks.GetLength(0); x++)
            {
                for (int y = 0; y < newMarks.GetLength(1) + 1; y++)
                {
                    if (y < i) newMarks[x, y] = marks[x, y];
                    if (y > i) newMarks[x, y - 1] = marks[x, y];
                }
            }
            marks = newMarks;
            Pupils.RemoveAt(i);
        }

        private void Marks(List<RowOfMark> rowMarks)
        {
            marks = new string[Lessons.Count, Pupils.Count];
            for (int y = 0; y < Pupils.Count; y++)
            {
                for (int x = 0; x < Lessons.Count; x++)
                {
                    marks[x, y] = rowMarks[y].Cells[x + 3];
                }
            }
        }

        private void SetPupils(List<RowOfMark> rowMarks)
        {
            foreach (var rowMark in rowMarks)
            {
                Pupils.Add(rowMark.GetPupil());
            }
        }

    }
}
