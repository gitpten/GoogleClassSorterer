using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleClassSorterer
{
    class Mark
    {
        public Mark(Pupil pupil, Lesson lesson, string value)
        {
            this.pupil = pupil;
            this.lesson = lesson;
            Value = value;
        }

        public Pupil pupil { get; set; }
        public Lesson lesson { get; set; }
        public string Value { get; set; }
    }
}
