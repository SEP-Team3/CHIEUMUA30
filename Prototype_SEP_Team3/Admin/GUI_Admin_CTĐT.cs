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
    public partial class GUI_Admin_CTĐT : Form
    {
        BUS_Admin_CTĐT bus = new BUS_Admin_CTĐT();
        private int id;
        public GUI_Admin_CTĐT()
        {
            InitializeComponent();

            bus.loadNguoiTaoCTDT(cbbNguoiTaoCTDT);

            lstCTDT.DataSource = bus.loadListCTDT();
            lstCTDT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bus.loadCopyCTDT(cbbCopyCTDT);

            //cbbCopyCTDT.Enabled = false;
            if (chkCopyTu.Checked == true)
                cbbCopyCTDT.Enabled = true;
            else
                cbbCopyCTDT.Enabled = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Admin guiAdmin = new GUI_Admin();
            guiAdmin.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lstCTDT.DataSource = bus.searchCTDT(txtSearch.Text);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            String TenCTDT = txtCTDT.Text;

            int NguoiPhucTrachID = (int)cbbNguoiTaoCTDT.SelectedValue;

            Nullable<int> CopyTuCTDT;

            if (chkCopyTu.Checked == true)
            {
                CopyTuCTDT = (int)cbbCopyCTDT.SelectedValue;
            }
            else
            {
                CopyTuCTDT = null;
            }

            bool flag = bus.createCTDT(TenCTDT, NguoiPhucTrachID, CopyTuCTDT);

            if (flag == true)
            {
                MessageBox.Show("Insert success");
            }
            else
            {
                MessageBox.Show("Insert Fail");
            }
            lstCTDT.DataSource = bus.loadListCTDT();

        }

        private void lstCTDT_DoubleClick(object sender, EventArgs e)
        {
            btnSua.Visible = true;
            btnCreate.Visible = false;
            if (lstCTDT.SelectedRows.Count == 1)
            {
                var row = lstCTDT.SelectedRows[0];
                var cell = row.Cells["id"];
                int ID = (int)cell.Value;
                id = ID;
                bus.loadInfo(txtCTDT, cbbNguoiTaoCTDT, chkCopyTu, cbbCopyCTDT, lstCTDT);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            String TenCTDT = txtCTDT.Text;
            int NguoiPhucTrachID = (int)cbbNguoiTaoCTDT.SelectedValue;
            int CopyTuCTDT = (int)cbbCopyCTDT.SelectedValue;
            bool flag = bus.updateCTDT(id, TenCTDT, NguoiPhucTrachID, CopyTuCTDT);
            if (flag == true)
            {
                MessageBox.Show("Insert success");
                btnSua.Visible = false;
                btnCreate.Visible = true;
            }
            else
            {
                MessageBox.Show("Insert Fail");
            }
            lstCTDT.DataSource = bus.loadListCTDT();
        }

        private void chkCopyTu_Click(object sender, EventArgs e)
        {
            if (chkCopyTu.Checked == true)
                cbbCopyCTDT.Enabled = true;
            else
                cbbCopyCTDT.Enabled = false;
        }

    }
}
