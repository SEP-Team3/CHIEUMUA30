using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Educational_Program
{
    public partial class GUI_Course : Form
    {
        public GUI_Course(string id)
        {
            InitializeComponent();
            
        }

        private void cboQuảnlí_loạikt_1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboQuảnlí_loạikt_1_SelectedValueChanged(object sender, EventArgs e)
        {          
            if (cboQuảnlí_loạikt_1.SelectedItem.ToString()=="Kiến thức giáo dục đại cương")
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

        private void cboQuảnlí_loạikt_2_SelectedValueChanged(object sender, EventArgs e)
        {
           
            if((cboQuảnlí_loạikt_2.SelectedItem.ToString() =="Khoa học xã hội")
                ||(cboQuảnlí_loạikt_2.SelectedItem.ToString() =="Nhân văn-Nghệ thuật")
                    ||(cboQuảnlí_loạikt_2.SelectedItem.ToString() =="Toán-Tin học-Khoa học tự nhiên-Công nghệ-Môi trường")
                        ||(cboQuảnlí_loạikt_2.SelectedItem.ToString() =="Kiến thức chuyên sâu của ngành chính")
                             || (cboQuảnlí_loạikt_2.SelectedItem.ToString() == "Kiến thức ngành thứ hai"))
                                    {
                                        List<string> arr = new List<string> {"Bắt buộc","Tự chọn"};
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
