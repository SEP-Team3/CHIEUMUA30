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
    public partial class GUI_Admin : Form
    {
        public GUI_Admin()
        {
            InitializeComponent();

            LoadList();
        }

        private void LoadList()
        {
            DBEntities model = new DBEntities();

            lstCTDT.DataSource = model.Admin_Select_Sang();
            lstCTDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btnTaoCTDT_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Admin_CTĐT main = new GUI_Admin_CTĐT();
            main.Closed += (s, args) => this.Close();
            main.ShowDialog();
        }

        private void lblDX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            GUI_Login main = new GUI_Login();
            main.Closed += (s, args) => this.Close();
            main.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            lstCTDT.DataSource = model.Admin_Search(txtSearch.Text);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_TaiKhoan main = new GUI_TaiKhoan();
            main.Closed += (s, args) => this.Close();
            main.ShowDialog();
        }
    }
}
