using Prototype_SEP_Team3.Admin;
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
    public partial class GUI_Login : Form
    {
        public GUI_Login()
        {
            InitializeComponent();
        }

        public TaiKhoan Find(string email)
        {
            DBEntities db = new DBEntities();
            TaiKhoan acc = new TaiKhoan();
            return db.TaiKhoans.FirstOrDefault(x => x.Email == email);
        }

        public int Test()
        {
            TaiKhoan kq = null;

            var nv = Find(txtEmail.Text);

            if ((nv != null) && (nv.MatKhau.Equals(txtMatKhau.Text)))
            {
                kq = nv;
            }

            int re = kq.Id;
            return re;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            var nv = Find(txtEmail.Text);

            if (nv == null)
            {
                MessageBox.Show("Incorrect email");
            }
            else
            {
                if (!nv.MatKhau.Equals(txtMatKhau.Text))
                {
                    MessageBox.Show("Incorrect Password");
                }
            }

            if ((nv != null) && (nv.MatKhau.Equals(txtMatKhau.Text)))
            {
                PhanQuyenTaiKhoan pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == nv.Id);

                if (pq.ChucVu == "Admin")
                {
                    this.Hide();
                    GUI_Admin main = new GUI_Admin();
                    main.Closed += (s, args) => this.Close();
                    main.ShowDialog();
                }
                else if (pq.ChucVu == "Giáo vụ")
                {
                    this.Hide();
                    GUI_Chinh_GV main = new GUI_Chinh_GV(Test());
                    main.Closed += (s, args) => this.Close();
                    main.ShowDialog();
                }
                else
                {
                    this.Hide();
                    GUI_Chinh_BST_GVGD main = new GUI_Chinh_BST_GVGD(Test());
                    main.Closed += (s, args) => this.Close();
                    main.ShowDialog();
                }
            }
        }
    }
}
