using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleClassSorterer
{
    class RowOfMark
    {
        public RowOfMark(List<string> cells)
        {
            Cells = cells;
        }

        public RowOfMark() : this(new List<string>())
        { }

        public List<string> Cells { get; set; }

        public Pupil GetPupil()
        {
            return new Pupil
            {
                FirstName = Cells[0],
                LastName = Cells[1],
                Email = Cells[2]
            };
        }

        public List<string> GetMarks()
        {
            string[] marks = new string[Cells.Count-3];
            Cells.CopyTo(3, marks, 0, marks.Length);
            return new List<string>(marks);
        }
    }
}
