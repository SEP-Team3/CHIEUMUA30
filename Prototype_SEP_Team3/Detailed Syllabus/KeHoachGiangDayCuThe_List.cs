using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    public class KeHoachGiangDayCuThe_List
    {
        public string buoi;
        public int tiet;
        public List<string> noiDung;
        public List<string> hoatDong;
        public List<string> taiLieu;

        public KeHoachGiangDayCuThe_List(string buoi, int tiet, List<string> noiDung, List<string> hoatDong, List<string> taiLieu)
        {
            this.buoi = buoi;
            this.tiet = tiet;
            this.noiDung = noiDung;
            this.hoatDong = hoatDong;
            this.taiLieu = taiLieu;
        }
    }
}