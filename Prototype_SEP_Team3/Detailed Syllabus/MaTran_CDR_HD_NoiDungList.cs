using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    public class MaTran_CDR_HD_NoiDungList
    {
        public string chuandaura;
        public string loai;
        public string noiDung;

        public MaTran_CDR_HD_NoiDungList(string ic, string il, string inoidung)
        {
            this.chuandaura = ic;
            this.loai = il;
            this.noiDung = inoidung;
        }
    }
}
