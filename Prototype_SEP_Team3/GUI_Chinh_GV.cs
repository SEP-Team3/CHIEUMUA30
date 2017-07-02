using Prototype_SEP_Team3.Detailed_Syllabus;
using Prototype_SEP_Team3.Educational_Program;
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
                    lstMainCTDT.DataSource = model.CTDT_SelectForGV_Sang();
                    lstMainCTDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    lstMainDCCT.DataSource = model.DCCT_SelectForGV_Sang();
                    lstMainDCCT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                }
            }
        }

        private void lstMainCTDT_DoubleClick(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            ChuongTrinhDaoTao ctdt = new ChuongTrinhDaoTao();

            if (lstMainCTDT.SelectedRows.Count == 1)
            {
                string pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == getTK_ID).ChucVu;

                if (pq == "Giáo vụ")
                {
                    var row = lstMainCTDT.SelectedRows[0];
                    var cell = row.Cells[0];
                    int ctdtID = (int)cell.Value;

                    GUI_EP ds = new GUI_EP(ctdtID,1);
                    ds.ShowDialog();
                }
            }
        }

        private void txtSearchCTDT_TextChanged(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();
            lstMainCTDT.DataSource = model.Search_CTDTForGV_Sang(txtSearchCTDT.Text);
        }

        private void txtSearchDCCT_TextChanged(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();
            lstMainDCCT.DataSource = model.Search_DCCTForGV_Sang(txtSearchDCCT.Text);
        }

        private void lstMainDCCT_DoubleClick(object sender, EventArgs e)
        {
            if (lstMainDCCT.SelectedRows.Count == 1)
            {
                DBEntities model = new DBEntities();
                string pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == getTK_ID).ChucVu;

                if (pq == "Giáo vụ")
                {
                    var row = lstMainDCCT.SelectedRows[0];
                    var cell = row.Cells[0];
                    int dcctID = (int)cell.Value;

                    DeCuongChiTiet dc = model.DeCuongChiTiets.FirstOrDefault(x => x.Id == dcctID);
                    int ctdt_ID = dc.MonHoc.ChuongTrinhDaoTao_Id;

                    GUI_DS ds = new GUI_DS(dcctID, ctdt_ID);
                    ds.ShowDialog();
                }
            }
        }

        private void lblDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            GUI_Login login = new GUI_Login();
            login.Closed += (s, args) => this.Close();
            login.ShowDialog();
        }


    }
}
