using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    public class PhuongPhapDanhGiaKQHT_List
    {
        public string noiDung;
        public string soLanDanhGia;
        public int trongSo;
        public string hinhThucDanhGia;

        public PhuongPhapDanhGiaKQHT_List(string noiDung, string soLanDanhGia, int trongSo, string hinhThucDanhGia)
        {
            this.noiDung = noiDung;
            this.soLanDanhGia = soLanDanhGia;
            this.trongSo = trongSo;
            this.hinhThucDanhGia = hinhThucDanhGia;
        }
    }
}
