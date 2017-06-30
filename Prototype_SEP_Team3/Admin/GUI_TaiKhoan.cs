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
    public partial class GUI_TaiKhoan : Form
    {
        int idtk = 0;
        BUS_TaiKhoan bus = new BUS_TaiKhoan();
        public GUI_TaiKhoan()
        {
            InitializeComponent();
            loadfr();
        }

        //Nút save,edit
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "TẠO")
            {
                string rs = bus.SaveTK(txtName.Text.Trim(), txtEmail.Text.Trim(), txtMK.Text.Trim(), txtRMK.Text.Trim());
                if (rs == "")
                {
                    MessageBox.Show("Thêm mới thành công");
                    loadfr();
                    txtEmail.Text = "";
                    txtName.Text = "";
                    txtMK.Text = "";
                    txtRMK.Text = "";
                }
                else
                {
                    MessageBox.Show(rs);
                }
            }
            if (btnSave.Text == "Cập nhật")
            {
                DBEntities db = new DBEntities();
                TaiKhoan edit = db.TaiKhoans.Single(x => x.Id == idtk);
                string check = bus.Checkdata(txtName.Text.Trim(), txtEmail.Text.Trim(), txtMK.Text.Trim(), txtRMK.Text.Trim());
                check = check.Replace("\nMật khẩu và Xác nhận mật khẩu không trùng khớp", "").Replace("\nXác nhận mật khẩu không được để trống", "").Replace("\nEmail đã tồn tại", "");
                if (check == "")
                {
                    edit.Email = txtEmail.Text.Trim();
                    edit.MatKhau = txtMK.Text.Trim();
                    edit.Ten = txtName.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    loadfr();
                    txtEmail.Text = "";
                    txtName.Text = "";
                    txtMK.Text = "";
                    txtRMK.Text = "";
                    txtRMK.Visible = true;
                    label5.Visible = true;
                    btnSave.Text = "TẠO";
                }
                else
                {
                    MessageBox.Show(check);
                }
            }

        }

        //Loadform
        private void loadfr()
        {
            DBEntities db = new DBEntities();
            dtgvTK.DataSource = db.TaiKhoans.ToList();
            dtgvTK.Columns["Id"].Visible = false;
            dtgvTK.Columns["Chuongtrinhdaotaos"].Visible = false;
            dtgvTK.Columns["Phanquyentaikhoans"].Visible = false;
            dtgvTK.Columns["MatKhau"].Visible = false;
            dtgvTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvTK.ReadOnly = true;
            txtSearch.Text = "";
        }

        //get taikhoan
        private void dtgvTK_DoubleClick(object sender, EventArgs e)
        {
            if (dtgvTK.SelectedRows.Count == 1)
            {
                int id = (int)dtgvTK.SelectedRows[0].Cells["Id"].Value;
                TaiKhoan edit = bus.EditTK(id);
                txtEmail.Text = edit.Email;
                txtName.Text = edit.Ten;
                txtMK.Text = edit.MatKhau;
                txtRMK.Visible = false;
                btnSave.Text = "Cập nhật";
                label5.Visible = false;
                idtk = id;
            }
        }

        //tim kiem
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DBEntities db = new DBEntities();
                dtgvTK.DataSource = db.SP_TAIKHOAN_SEARCH(txtSearch.Text).ToList();
                dtgvTK.Columns["Id"].Visible = false;
                dtgvTK.Columns["Chuongtrinhdaotaos"].Visible = false;
                dtgvTK.Columns["Phanquyentaikhoans"].Visible = false;
                dtgvTK.Columns["MatKhau"].Visible = false;
                dtgvTK.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvTK.ReadOnly = true;
            }
            catch
            {

            }

        }


    }
}
