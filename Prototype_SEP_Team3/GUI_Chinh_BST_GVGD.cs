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
    public partial class GUI_Chinh_BST_GVGD : Form
    {
        int getTK_ID;

        public GUI_Chinh_BST_GVGD(int re)
        {
            InitializeComponent();

            getTK_ID = re;

            LoadList(re);

        }

        //Admin
        //Ban soạn thảo
        //Giảng viên
        //Giáo vụ

        private void LoadList(int re)
        {
            DBEntities model = new DBEntities();

            PhanQuyenTaiKhoan pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == re);

            if (pq != null)
            {
                if (pq.ChucVu == "Ban soạn thảo")
                {
                    lstMain.DataSource = model.ChuongTrinhDaoTaos.Where(x => x.NguoiPhuTrach_Id == re).ToList();

                    //DataGridViewCheckBoxColumn chkEditing = new DataGridViewCheckBoxColumn();
                    //chkEditing.HeaderText = "Đang làm";
                    //lstMain.Columns.Add(chkEditing);
                    //DataGridViewCheckBoxColumn chkFinish = new DataGridViewCheckBoxColumn();
                    //chkFinish.HeaderText = "Hoàn thành";
                    //lstMain.Columns.Add(chkFinish);
                }

                if (pq.ChucVu == "Giảng viên")
                {
                    lstMain.DataSource = model.DeCuongChiTiets.Where(x => x.MonHoc.GiangVienPhuTrach_Id == re).ToList();
                    //lstMain.

                    DataGridViewCheckBoxColumn chkEditing = new DataGridViewCheckBoxColumn();
                    chkEditing.HeaderText = "Đang làm";
                    lstMain.Columns.Add(chkEditing);
                    DataGridViewCheckBoxColumn chkFinish = new DataGridViewCheckBoxColumn();
                    chkFinish.HeaderText = "Hoàn thành";
                    lstMain.Columns.Add(chkFinish);

                }
            }
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Login login = new GUI_Login();
            login.Closed += (s, args) => this.Close();
            login.ShowDialog();
        }
    }
}
