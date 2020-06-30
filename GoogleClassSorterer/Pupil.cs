using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleClassSorterer
{
    [Serializable]
    public class Pupil:ICloneable
    {
        public string TrueName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        string NickName
        {
            get
            {
                return String.Format($"{FirstName} {LastName}");
            }
        }

        public object Clone()
        {
            return new Pupil()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
                TrueName = this.TrueName,
                Email = this.Email
            };
        }
    }
}
