using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype_SEP_Team3.Educational_Program
{
    class Montienquyet_dtgv
    {
        public int id { get; set; }
        public string mamh { get; set; }
        public string name { get; set; }
        public string namees { get; set; }
        public string teacher { get; set; }
        public bool check { set; get; }
        public Montienquyet_dtgv(int iid,string imanh, string iname, string inamees, string iteacher, bool icheck)
        {
            this.id = iid;
            this.mamh = imanh;
            this.name = iname;
            this.namees = inamees;
            this.teacher = iteacher;
            this.check = icheck;
        }
    }
}
