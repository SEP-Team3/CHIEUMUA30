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
        int idcourse;
        int idctdt;
        int hkc;

        BUS_Course buscourse = new BUS_Course();

        DBEntities editconnect;
        MonHoc editobject;
        public GUI_Course(int id, int ctdt, int hk)
        {
            InitializeComponent();
            //Set up khi form
            DBEntities db = new DBEntities();
            cboQuảnlí_giáoviên.DataSource = db.TaiKhoans.ToList();
            cboQuảnlí_giáoviên.ValueMember = "Id";
            cboQuảnlí_giáoviên.DisplayMember = "Ten";

            List<string> lhk = new List<string>(hk);
            for (int i = 0; i < hk; i++)
            {
                lhk.Add("Học kì " + (i + 1));
            }
            cboQuảnlí_họckỳ.DataSource = lhk.ToList();
            btnQuảnlí_xóa.Visible = false;
            idcourse = id;
            //Set up khi form len là form edit
            if (id != 0)
            {
                //Load thong tin cac truong                
                editconnect = new DBEntities();
                editobject = buscourse.getCourse(idcourse);

                txtQuảnlí_tên.Text = editobject.TenMonHoc;
                txtQuảnlí_tênES.Text = editobject.TenTiengAnh;
                txtQuảnlí_mã.Text = editobject.MonHoc_Id;
                cboQuảnlí_loạikt_1.SelectedIndex = int.Parse(editobject.LoaiKienThuc.ToString().Substring(0, 1)) - 1;
                cboQuảnlí_loạikt_2.SelectedIndex = int.Parse(editobject.LoaiKienThuc.ToString().Substring(1, 1)) - 1;
                int lkt3 = int.Parse(editobject.LoaiKienThuc.ToString().Substring(2, 1)) - 1;
                if (lkt3 >= 0)
                {
                    cboQuảnlí_loạikt_3.SelectedIndex = lkt3;
                }
                nQuảnlí_sốtínchỉ.Value = (decimal)editobject.SoTinChi;
                nQuảnlí_sốgiờlýthuyết.Value = (decimal)editobject.SoGioLyThuyet;
                nQuảnlí_sốgiờthựchành.Value = (decimal)editobject.SoGioThucHanh;
                cboQuảnlí_họckỳ.SelectedIndex = (int)editobject.HocKy - 1;
                cboQuảnlí_giáoviên.SelectedValue = editobject.GiangVienPhuTrach_Id;
                txtQuảnlí_nộidungvắntắt.Text = editobject.NoiDungVanTat;

                btnQuảnlí_lưu.Text = "Cập nhật";
                txtQuảnlí_mã.ReadOnly = true;
                btnQuảnlí_xóa.Visible = true;
            }

            idctdt = ctdt;
            hkc = hk;
            
        }


        private void cboQuảnlí_loạikt_1_SelectedValueChanged(object sender, EventArgs e)
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
                List<string> arr = new List<string> { "Kiến thức cơ sở", 
                    "Kiến thức chung của ngành chính", "Kiến thức chuyên sâu của ngành chính", 
                        "Kiến thức ngành thứ hai", "Kiến thức bổ trợ tự do", "Thực tập tốt nghiệp và làm khóa luận" };
                cboQuảnlí_loạikt_2.DataSource = arr.ToList();
            }
        }

        private void cboQuảnlí_loạikt_2_SelectedValueChanged(object sender, EventArgs e)
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

        private void btnQuảnlí_lưu_Click(object sender, EventArgs e)
        {
            if (btnQuảnlí_lưu.Text == "Lưu")
            {
                string rs = buscourse.addCourse(idctdt, hkc, txtQuảnlí_tên, txtQuảnlí_tênES, txtQuảnlí_mã,
                                    cboQuảnlí_loạikt_1, cboQuảnlí_loạikt_2, cboQuảnlí_loạikt_3,
                                        nQuảnlí_sốtínchỉ, nQuảnlí_sốgiờlýthuyết, nQuảnlí_sốgiờthựchành,
                                             cboQuảnlí_họckỳ, cboQuảnlí_giáoviên, txtQuảnlí_nộidungvắntắt, dtgwQuảnlí_môntiênquyết);

                if (rs == "")
                {
                    MessageBox.Show("Thêm mới môn học thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(rs, "Lỗi nhập dữ liệu");
                }

            }
            if (btnQuảnlí_lưu.Text == "Cập nhật")
            {
                string rs = buscourse.editCourse(idctdt, idcourse, txtQuảnlí_tên, txtQuảnlí_tênES, txtQuảnlí_mã,
                                    cboQuảnlí_loạikt_1, cboQuảnlí_loạikt_2, cboQuảnlí_loạikt_3,
                                        nQuảnlí_sốtínchỉ, nQuảnlí_sốgiờlýthuyết, nQuảnlí_sốgiờthựchành,
                                             cboQuảnlí_họckỳ, cboQuảnlí_giáoviên, txtQuảnlí_nộidungvắntắt, dtgwQuảnlí_môntiênquyết);

                if (rs == "")
                {
                    MessageBox.Show("Cập nhật môn học thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show(rs, "Lỗi nhập dữ liệu");
                }
            }

        }

        //Xử lí load lại các môn học tiên quyết khi chọn học kì
        private void cboQuảnlí_họckỳ_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Khi thay đổi trong quá trình tạo mới môn học
            if (idcourse == 0)
            {
                loadMTQtoDGV(idcourse);
            }

            //Khi thay đổi trong quá trình edit môn học
            if (idcourse != 0)
            {
                //Khi hk mới là hk cũ
                if (buscourse.checkCourseHK(idcourse, cboQuảnlí_họckỳ.SelectedIndex + 1) == true)
                {
                    //Xóa các cột có sẵn trong bảng cho đẹp
                    try
                    {
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Id"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["MonHoc_Id"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Tenmonhoc"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["TenTiengAnh"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Ten"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Check"]);
                    }
                    catch
                    {
                    }
                    try
                    {
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Status"]);
                    }
                    catch
                    {

                    }
                    //Load lại môn tiên quyết
                    loadMTQtoDGV_Id_Id(idcourse);
                }
                //Khi học kì mới khác học kì cũ
                else
                {

                    //Xóa các cột có sẵn trong bảng
                    try
                    {
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Id"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["MonHoc_Id"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Tenmonhoc"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["TenTiengAnh"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Ten"]);
                        dtgwQuảnlí_môntiênquyết.Columns.Remove(dtgwQuảnlí_môntiênquyết.Columns["Check"]);
                    }
                    catch
                    {
                    }
                    //Load lại dnah sách môn học theo học kì
                    loadMTQtoDGV(idcourse);
                }

            }

            //Canh chỉnh cho bảng nó đẹp
            dtgwQuảnlí_môntiênquyết.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgwQuảnlí_môntiênquyết.AllowUserToAddRows = false;
        }

        //Hàm load danh sách môn tiên quyết của môn học theo id
        private void loadMTQtoDGV_Id_Id(int id)
        {
            DBEntities db = new DBEntities();
            dtgwQuảnlí_môntiênquyết.DataSource = db.SP_TEXT(id).ToList();
            dtgwQuảnlí_môntiênquyết.Columns[0].Visible = false;
            dtgwQuảnlí_môntiênquyết.Columns[1].HeaderText = "Mã môn học";
            dtgwQuảnlí_môntiênquyết.Columns[2].HeaderText = "Tên môn học";
            dtgwQuảnlí_môntiênquyết.Columns[3].HeaderText = "Tên tiếng Anh";
            dtgwQuảnlí_môntiênquyết.Columns[4].HeaderText = "Giảng viên phụ trách";
            dtgwQuảnlí_môntiênquyết.Columns[5].HeaderText = "Môn tiên quyết";
        }

        //Hàm load danh sách môn học phù hợp học kì
        private void loadMTQtoDGV(int id)
        {
            DBEntities db = new DBEntities();
            int inputarrhk = cboQuảnlí_họckỳ.SelectedIndex + 1;
            List<SP_MONTIENQUYET_GET_Result> arr = db.SP_MONTIENQUYET_GET(idctdt, inputarrhk, id).ToList();
            dtgwQuảnlí_môntiênquyết.DataSource = arr;
            dtgwQuảnlí_môntiênquyết.Columns["Id"].Visible = false;
            dtgwQuảnlí_môntiênquyết.Columns["MonHoc_Id"].HeaderText = "Mã môn học";
            dtgwQuảnlí_môntiênquyết.Columns["Tenmonhoc"].HeaderText = "Tên môn học";
            dtgwQuảnlí_môntiênquyết.Columns["TenTiengAnh"].HeaderText = "Tên tiếng Anh";
            dtgwQuảnlí_môntiênquyết.Columns["Ten"].HeaderText = "Giảng viên phụ trách";
            if (dtgwQuảnlí_môntiênquyết.Columns.Count == 5)
            {
                DataGridViewCheckBoxColumn ck = new DataGridViewCheckBoxColumn();
                ck.HeaderText = "Môn tiên quyết";
                ck.Name = "Check";
                dtgwQuảnlí_môntiênquyết.Columns.Add(ck);
            }

            dtgwQuảnlí_môntiênquyết.Columns["MonHoc_Id"].ReadOnly = true;
            dtgwQuảnlí_môntiênquyết.Columns["Tenmonhoc"].ReadOnly = true;
            dtgwQuảnlí_môntiênquyết.Columns["TenTiengAnh"].ReadOnly = true;
            dtgwQuảnlí_môntiênquyết.Columns["Ten"].ReadOnly = true;
        }

        private void btnQuảnlí_xóa_Click(object sender, EventArgs e)
        {
            DialogResult rs =  MessageBox.Show("Bạn muốn xóa môn học này?","Thông báo",MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                DBEntities db = new DBEntities();
                db.SP_MONHOC_DELETE(idcourse);
                MessageBox.Show("Xóa môn học thành công");
                this.Close();
            }
        }




    }
}
