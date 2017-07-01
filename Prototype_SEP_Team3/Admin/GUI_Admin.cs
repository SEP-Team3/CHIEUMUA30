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

            lstCTDT.DataSource = model.ChuongTrinhDaoTaos.ToList();

        }

        private void btnTaoCTDT_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Admin_CTĐT main = new GUI_Admin_CTĐT();
            main.Closed += (s, args) => this.Close();
            main.ShowDialog();
        }
    }
}
