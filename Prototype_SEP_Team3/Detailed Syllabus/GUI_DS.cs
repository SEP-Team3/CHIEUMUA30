using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    public partial class GUI_DS : Form
    {
        public GUI_DS()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            string c = Directory.GetCurrentDirectory();
            wbPhanbothoigian.Navigate(Path.Combine(c, "Educational Program\\EPCkeditor.html"));
            wbYCMH.Navigate(Path.Combine(c, "Educational Program\\EPCkeditor.html"));
        }

        private void toolStripStatusLabel2_MouseHover(object sender, EventArgs e)
        {
            msMụclục.ShowDropDown();
        }

        //NÚT PREVIOUS
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (tclMain.SelectedIndex > 0)
            {
                tclMain.SelectedIndex = tclMain.SelectedIndex - 1;
            }
        }

        //NÚT NEXT
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tclMain.SelectedIndex < 15)
            {
                tclMain.SelectedIndex = tclMain.SelectedIndex + 1;
            }
        }

        //SET UP MỤC LỤC
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 2;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 3;
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 4;
        }

        private void maTrậnTíchHợpGiữaChuẩnĐầuRaMônHọcVàChuẩnĐầuRaCủaChươngTrìnhĐàoTạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 5;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 6;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 6;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 7;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 8;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 9;
        }

        private void yêuCầuMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 10;
        }

        private void kếHoạchGiảngDạyVàHọcTậpCụThểToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 10;
        }


        //SETUP thông tin chung

        private void cboQuảnlí_loạikt_1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboQuảnlí_loạikt_1.SelectedItem.ToString() == "Kiến thức giáo dục đại cương")
            {
                List<string> arr = new List<string> { "Lý luận chính trị", "Khoa học xã hội", 
                    "Nhân văn-Nghệ thuật", "Ngoại ngữ", "Toán-Tin học-Khoa học tự nhiên-Công nghệ-Môi trường", 
                        "Giáo dục thể chất", "Giáo dục Quốc Phòng- an ninh" };
                cboQuảnlí_loạikt_2.DataSource = arr.ToList();
            }
            if (cboQuảnlí_loạikt_1.SelectedItem.ToString() == "Kiến thức giáo dục chuyên nghiệp")
            {
                List<string> arr = new List<string> { "Kiến thức cơ sở", "Kiến thức ngành chính", 
                    "Kiến thức chung của ngành chính", "Kiến thức chuyên sâu của ngành chính", 
                        "Kiến thức ngành thứ hai", "Kiến thức bổ trợ tự do", "Thực tập tốt nghiệp và làm khóa luận" };
                cboQuảnlí_loạikt_2.DataSource = arr.ToList();
            }
        }

        private void cboQuảnlí_loạikt_2_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if ((cboQuảnlí_loạikt_2.SelectedItem.ToString() == "Khoa học xã hội")
               || (cboQuảnlí_loạikt_2.SelectedItem.ToString() == "Nhân văn-Nghệ thuật")
                   || (cboQuảnlí_loạikt_2.SelectedItem.ToString() == "Toán-Tin học-Khoa học tự nhiên-Công nghệ-Môi trường")
                       || (cboQuảnlí_loạikt_2.SelectedItem.ToString() == "Kiến thức chuyên sâu của ngành chính")
                            || (cboQuảnlí_loạikt_2.SelectedItem.ToString() == "Kiến thức ngành thứ hai"))
            {
                List<string> arr = new List<string> { "Bắt buộc", "Tự chọn" };
                cboQuảnlí_loạikt_3.DataSource = arr.ToList();
            }
            else
            {
                List<string> arr = new List<string> { "" };
                cboQuảnlí_loạikt_3.DataSource = arr.ToList();
            }
        }





    }
}
