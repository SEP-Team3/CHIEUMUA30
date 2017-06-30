using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    public class KeHoachKiemTra_List
    {
        public string hinhThuc;
        public string noiDung;
        public string thoiDiem;
        public string congCuKiemTra;

        public KeHoachKiemTra_List(string hinhThuc, string noiDung, string thoiDiem, string congCuKiemTra)
        {
            this.hinhThuc = hinhThuc;
            this.noiDung = noiDung;
            this.thoiDiem = thoiDiem;
            this.congCuKiemTra = congCuKiemTra;
        }
    }
}
