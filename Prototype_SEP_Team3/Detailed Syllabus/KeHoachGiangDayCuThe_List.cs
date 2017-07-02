using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    public class KeHoachGiangDayCuThe_List
    {
        public int buoi;
        public int tiet;
        public string noiDung;
        public string hoatDong;
        public string taiLieu;

        public KeHoachGiangDayCuThe_List(int ibuoi, int tiet, string noiDung, string hoatDong, string taiLieu)
        {
            this.buoi = ibuoi;
            this.tiet = tiet;
            this.noiDung = noiDung;
            this.hoatDong = hoatDong;
            this.taiLieu = taiLieu;
        }
    }
}