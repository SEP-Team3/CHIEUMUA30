using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Admin
{
    public partial class GUI_PhanQuyen : Form
    {
        BUS_PhanQuyen bus = new BUS_PhanQuyen();

        public GUI_PhanQuyen()
        {
            DBEntities model = new DBEntities();

            InitializeComponent();

            LoadListPQ();

            cboTaiKhoan.DataSource = model.TaiKhoans.ToList();
            cboTaiKhoan.DisplayMember = "Ten";
            cboTaiKhoan.ValueMember = "Id";

            btnCapNhat.Visible = false;
        }

        public void LoadListPQ()
        {
            DBEntities model = new DBEntities();

            lstPhanQuyen.DataSource = model.Authorize_Select_Sang();
            lstPhanQuyen.Columns[1].HeaderText = "Tên tài khoản";
            lstPhanQuyen.Columns[1].Width = 500;
            lstPhanQuyen.Columns[2].HeaderText = "Chức vụ";
            lstPhanQuyen.Columns[2].Width = 300;
        }


        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            int taikhoan_ID = int.Parse(cboTaiKhoan.SelectedValue.ToString());
            string chucVu = cboChucVu.SelectedItem.ToString();

            bool flag = bus.TaoPhanQuyen(taikhoan_ID, chucVu);

            if (flag == true)
                MessageBox.Show("Phân quyền thành công");
            else
                MessageBox.Show("Phân quyền thất bại");

            LoadListPQ();
        }

        private void lstPhanQuyen_DoubleClick(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();
            PhanQuyenTaiKhoan acc = new PhanQuyenTaiKhoan();

            if (lstPhanQuyen.SelectedRows.Count == 1)
            {
                var row = lstPhanQuyen.SelectedRows[0];
                var cell = row.Cells["Id"];

                int ID = (int)cell.Value;

                acc = model.PhanQuyenTaiKhoans.Single(x => x.Id == ID);
                
                cboTaiKhoan.SelectedValue = acc.TaiKhoan_Id;
                cboChucVu.SelectedItem = acc.ChucVu;

                btnCapNhat.Visible = true;
                btnPhanQuyen.Visible = false;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            int taikhoan_ID = int.Parse(cboTaiKhoan.SelectedValue.ToString());
            string chucVu = cboChucVu.SelectedItem.ToString();

            PhanQuyenTaiKhoan pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == taikhoan_ID);

            if (pq != null)
            {
                bool flag = bus.CapNhatPhanQuyen(taikhoan_ID, chucVu);

                if (flag == true)
                    MessageBox.Show("Cập nhật thành công");
                else
                    MessageBox.Show("Cập nhật thất bại");

                LoadListPQ();
            }
            else
                MessageBox.Show("Tài khoản này đã được phân quyền");
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstPhanQuyen.DataSource = bus.Search(txtSearch.Text);
        }

        private void bACKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_TaiKhoan main = new GUI_TaiKhoan();
            main.Closed += (s, args) => this.Close();
            main.ShowDialog();
        }

        //private void cboTaiKhoan_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    DBEntities model = new DBEntities();

        //    string taikhoan_IDSrt = cboTaiKhoan.SelectedValue.ToString();

        //    int taikhoan_ID = int.Parse(taikhoan_IDSrt);

        //    PhanQuyenTaiKhoan pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == taikhoan_ID);

        //    if (pq != null)
        //    {
        //        cboChucVu.SelectedItem = pq.ChucVu;
        //    }
        //    else
        //    {
        //        btnCapNhat.Visible = false;
        //        btnPhanQuyen.Visible = true;
        //    }
        //}

    }
}
