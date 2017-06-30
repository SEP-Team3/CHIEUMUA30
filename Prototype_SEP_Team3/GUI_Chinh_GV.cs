using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3
{
    public partial class GUI_Chinh_GV : Form
    {
        int getTK_ID;

        public GUI_Chinh_GV(int re)
        {
            InitializeComponent();

            getTK_ID = re;

            LoadList(re);
        }

        private void LoadList(int re)
        {
            DBEntities model = new DBEntities();

            PhanQuyenTaiKhoan pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == re);

            if (pq != null)
            {
                if (pq.ChucVu == "Giáo vụ")
                {

                    lstMainCTDT.DataSource = model.ChuongTrinhDaoTaos.ToList();
                    lstMainCTDT.Columns["NguoiPhuTrach_Id"].Visible = false;
                    lstMainCTDT.Columns["CopyTuCTDT"].Visible = false;
                    lstMainCTDT.Columns["TaiKhoan"].Visible = false;
                    lstMainCTDT.Columns["MonHocs"].Visible = false;
                    lstMainCTDT.Columns["MucTieuDaoTaos"].Visible = false;
                    lstMainCTDT.Columns["ThongTinChung_CTDT"].Visible = false;
                    lstMainCTDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    lstMainDCCT.DataSource = model.DeCuongChiTiets.Where(x => x.Finish == true).ToList();
                    lstMainDCCT.Columns["MonHoc_Id"].Visible = false;
                    lstMainDCCT.Columns["TrinhDo"].Visible = false;
                    lstMainDCCT.Columns["PhanBoThoiGian"].Visible = false;
                    lstMainDCCT.Columns["MonTienQuyet_Id"].Visible = false;
                    lstMainDCCT.Columns["YeuCauMonHoc"].Visible = false;
                    lstMainDCCT.Columns["GiangVienPhuTrach"].Visible = false;
                    lstMainDCCT.Columns["KhoiKienThuc"].Visible = false;
                    lstMainDCCT.Columns["Editing"].Visible = false;
                    lstMainDCCT.Columns["Finish"].Visible = false;
                    lstMainDCCT.Columns["ChuanDauRaMonHocs"].Visible = false;
                    lstMainDCCT.Columns["MonHoc"].Visible = false;
                    //lstMainDCCT.Columns["GVGDs"].Visible = false;
                    lstMainDCCT.Columns["KeHoachGDHTCuThes"].Visible = false;
                    //lstMainDCCT.Columns["KeHoachKiemTras"].Visible = false;
                    lstMainDCCT.Columns["MaTran_CDRMH_CDRCTDT"].Visible = false;
                    lstMainDCCT.Columns["MucTieuMonHocs"].Visible = false;
                    lstMainDCCT.Columns["PPDanhGiaKQHTs"].Visible = false;
                    lstMainDCCT.Columns["TaiLieuMonHocs"].Visible = false;
                    lstMainDCCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
        }


    }
}
