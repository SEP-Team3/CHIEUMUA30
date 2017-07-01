using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Educational_Program
{
    class BUS_EP
    {
        //kiểm tra thời gian đào tạo
        public bool getThoigiandaotao(double newtime, int ctdt)
        {
            DBEntities db = new DBEntities();
            ThongTinChung_CTDT check = db.ThongTinChung_CTDT.Single(x => x.ChuongTrinhDaoTao_Id == ctdt);
            if (newtime == check.ThoiGianDaoTao)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //kiem tra khi thời gian đào tạo thay đổi
        public string checkThoigiandaotao(double newtime, int ctdt)
        {
            DBEntities db = new DBEntities();
            if (newtime != 0)
            {


                ThongTinChung_CTDT find = db.ThongTinChung_CTDT.Single(x => x.ChuongTrinhDaoTao_Id == ctdt);
                List<MonHoc> findcourse = db.MonHocs.Where(x => x.ChuongTrinhDaoTao_Id == ctdt).ToList();
                if ((newtime != find.ThoiGianDaoTao) && (findcourse.Count > 0))
                {
                    return "false";
                }
                else
                {
                    ThongTinChung_CTDT edit = db.ThongTinChung_CTDT.Single(x => x.ChuongTrinhDaoTao_Id == ctdt);
                    edit.ThoiGianDaoTao = newtime;
                    db.SaveChanges();
                    return "true";
                }
            }
            else
            {
                return "null";
            }

        }

        // xu li khi thoi gian thay doi
        public void handleThoigiandaotao(int ctdt, double tgdt)
        {
            DBEntities db = new DBEntities();
            db.SP_THOIGIANDAOTAO_HANDLE(ctdt, tgdt);
        }

        // ve table
        public TableLayoutPanel drawTableNoidung(List<MonHoc> ilst)
        {
            //Nội dung chương trình
            //Set up cái ô tiêu đề cho từng cột
            TableLayoutPanel Tablepanel = new TableLayoutPanel { Dock = DockStyle.Fill };
            Tablepanel.Size = new Size(1280, 480);
            Tablepanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1000));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            Tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            Tablepanel.Controls.Add(new Label() { Text = "STT", AutoSize = true, Anchor = AnchorStyles.None }, 0, 0);
            Tablepanel.Controls.Add(new Label() { Text = "MÃ MH", AutoSize = true, Anchor = AnchorStyles.None }, 1, 0);
            Tablepanel.Controls.Add(new Label() { Text = "Môn học", AutoSize = true, Anchor = AnchorStyles.None }, 2, 0);
            Tablepanel.Controls.Add(new Label() { Text = "TC", AutoSize = true, Anchor = AnchorStyles.None }, 3, 0);
            Tablepanel.Controls.Add(new Label() { Text = "Học kỳ", AutoSize = true, Anchor = AnchorStyles.None }, 4, 0);


            //Kiến thức giáo dục đại cươnh
            // Lý luận Mac
            Label lblktdc = new Label();
            lblktdc.Dock = DockStyle.Fill;
            lblktdc.AutoSize = true;
            lblktdc.Text = "Kiến thức giáo dục đại cương";
            lblktdc.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc, 0, 1);
            Tablepanel.SetColumnSpan(lblktdc, 3);
            Label lblktdc1 = new Label();
            lblktdc1.Dock = DockStyle.Fill;
            lblktdc1.AutoSize = true;
            lblktdc1.Text = "Lý luận Mac-Lenin và tư tưởng Hồ Chí Minh";
            lblktdc1.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc1, 1, 2);
            Tablepanel.SetColumnSpan(lblktdc1, 2);
            int totaltc = 0;
            int stt = 1;
            int tc = 0;
            int row = 3;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 1))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Tablepanel.AutoScroll = true;
            Label lbltc1 = new Label();
            lbltc1.Text = tc.ToString();
            lbltc1.Dock = DockStyle.Fill;
            lbltc1.AutoSize = true;
            lbltc1.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc1, 3, 2);
            Tablepanel.SetColumnSpan(lbltc1, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục đại cươnh
            //Khoa học xả hội
            Label lblktdc2 = new Label();
            lblktdc2.Text = "Khoa học xã hội";
            lblktdc2.Dock = DockStyle.Fill;
            lblktdc2.AutoSize = true;
            Tablepanel.Controls.Add(lblktdc2, 1, row);
            Tablepanel.SetColumnSpan(lblktdc2, 2);
            int rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 2))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc2 = new Label();
            lbltc2.Text = tc.ToString();
            lbltc2.Dock = DockStyle.Fill;
            lbltc2.AutoSize = true;
            lbltc2.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc2, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc2, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục đại cươnh
            //Nhân văn, nghệ thuật
            Label lblktdc3 = new Label();
            lblktdc3.Text = "Nhân văn - Nghệ thuật";
            lblktdc3.Dock = DockStyle.Fill;
            lblktdc3.AutoSize = true;
            lblktdc3.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc3, 1, row);
            Tablepanel.SetColumnSpan(lblktdc3, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 3))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc3 = new Label();
            lbltc3.Text = tc.ToString();
            lbltc3.Dock = DockStyle.Fill;
            lbltc3.AutoSize = true;
            lbltc3.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc3, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc3, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục đại cươnh
            //Ngoại ngữ
            Label lblktdc4 = new Label();
            lblktdc4.Text = "Ngoại ngữ";
            lblktdc4.Dock = DockStyle.Fill;
            lblktdc4.AutoSize = true;
            lblktdc4.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc4, 1, row);
            Tablepanel.SetColumnSpan(lblktdc4, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 4))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc4 = new Label();
            lbltc4.Text = tc.ToString();
            lbltc4.Dock = DockStyle.Fill;
            lbltc4.AutoSize = true;
            lbltc4.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc4, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc4, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục đại cươnh
            //Toán tin
            Label lblktdc5 = new Label();
            lblktdc5.Text = "Toán-Tin học-Khoa học tự nhiên-Công nghệ-Môi trường";
            lblktdc5.Dock = DockStyle.Fill;
            lblktdc5.AutoSize = true;
            lblktdc5.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc5, 1, row);
            Tablepanel.SetColumnSpan(lblktdc5, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 5))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc5 = new Label();
            lbltc5.Text = tc.ToString();
            lbltc5.Dock = DockStyle.Fill;
            lbltc5.AutoSize = true;
            lbltc5.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc5, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc5, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục đại cương
            //Giaó dục thể chất
            Label lblktdc6 = new Label();
            lblktdc6.Text = "Giáo dục thể chất";
            lblktdc6.Dock = DockStyle.Fill;
            lblktdc6.AutoSize = true;
            lblktdc6.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc6, 1, row);
            Tablepanel.SetColumnSpan(lblktdc6, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 6))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc6 = new Label();
            lbltc6.Text = tc.ToString();
            lbltc6.Dock = DockStyle.Fill;
            lbltc6.AutoSize = true;
            lbltc6.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc6, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc6, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục đại cương
            //Giáo dục Quốc Phòng- an ninh
            Label lblktdc7 = new Label();
            lblktdc7.Text = "Giáo dục Quốc Phòng - an ninh";
            lblktdc7.Dock = DockStyle.Fill;
            lblktdc7.AutoSize = true;
            lblktdc7.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc7, 1, row);
            Tablepanel.SetColumnSpan(lblktdc7, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 1) && (check2 == 7))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc7 = new Label();
            lbltc7.Text = tc.ToString();
            lbltc7.Dock = DockStyle.Fill;
            lbltc7.AutoSize = true;
            lbltc7.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc7, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc7, 2);
            totaltc += tc;
            tc = 0;
            Label lbltc8 = new Label();
            lbltc8.Text = totaltc.ToString();
            lbltc8.Dock = DockStyle.Fill;
            lbltc8.AutoSize = true;
            lbltc8.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc8, 3, 1);
            Tablepanel.SetColumnSpan(lbltc8, 2);


            //Kiến thức giáo dục chuyên nghiệp
            //Kiến thức cơ sở
            Label lblktdc9 = new Label();
            lblktdc9.Text = "Kiến thức giáo dục chuyên nghiệp";
            lblktdc9.Dock = DockStyle.Fill;
            lblktdc9.AutoSize = true;
            lblktdc9.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc9, 0, row);
            Tablepanel.SetColumnSpan(lblktdc9, 3);
            int rowlv2 = row;
            row++;
            Label lblktdc10 = new Label();
            lblktdc10.Text = "Kiến thức cơ sở";
            lblktdc10.Dock = DockStyle.Fill;
            lblktdc10.AutoSize = true;
            lblktdc10.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc10, 1, row);
            Tablepanel.SetColumnSpan(lblktdc10, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 2) && (check2 == 1))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc10 = new Label();
            lbltc10.Text = tc.ToString();
            lbltc10.Dock = DockStyle.Fill;
            lbltc10.AutoSize = true;
            lbltc10.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc10, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc10, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục chuyên nghiệp
            //Kiến thức chuyên ngành chính
            //Kiến thức chung
            Label lblktdc11 = new Label();
            lblktdc11.Text = "Kiến thức ngành chính";
            lblktdc11.Dock = DockStyle.Fill;
            lblktdc11.AutoSize = true;
            lblktdc11.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc11, 1, row);
            Tablepanel.SetColumnSpan(lblktdc11, 2);
            int rowtcnc = row;
            row++;
            Label lblktdc12 = new Label();
            lblktdc12.Text = "Kiến thức chung của ngành chính";
            lblktdc12.Dock = DockStyle.Fill;
            lblktdc12.AutoSize = true;
            lblktdc12.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc12, 2, row);
            rowtc = row;
            row++;

            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 2) && (check2 == 2))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc12 = new Label();
            lbltc12.Text = tc.ToString();
            lbltc12.Dock = DockStyle.Fill;
            lbltc12.AutoSize = true;
            lbltc12.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc12, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc12, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục chuyên nghiệp
            //Kiến thức chuyên ngành chính
            //Kiến thức chuyện sâu
            Label lblktdc13 = new Label();
            lblktdc13.Text = "Kiến thức chuyên sâu của ngành chính ";
            lblktdc13.Dock = DockStyle.Fill;
            lblktdc13.AutoSize = true;
            lblktdc13.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc13, 2, row);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 2) && (check2 == 3))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc13 = new Label();
            lbltc13.Text = tc.ToString();
            lbltc13.Dock = DockStyle.Fill;
            lbltc13.AutoSize = true;
            lbltc13.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc13, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc13, 2);
            Label lbltc14 = new Label();
            lbltc14.Text = (int.Parse(lbltc12.Text) + int.Parse(lbltc13.Text)).ToString();
            lbltc14.Dock = DockStyle.Fill;
            lbltc14.AutoSize = true;
            lbltc14.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc14, 3, rowtcnc);
            Tablepanel.SetColumnSpan(lbltc14, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục chuyên nghiệp
            //Kiến thức chuyên ngành thứ 2
            Label lblktdc15 = new Label();
            lblktdc15.Text = "Kiến thức chuyên ngành thứ hai";
            lblktdc15.Dock = DockStyle.Fill;
            lblktdc15.AutoSize = true;
            lblktdc15.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc15, 1, row);
            Tablepanel.SetColumnSpan(lblktdc15, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 2) && (check2 == 4))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc15 = new Label();
            lbltc15.Text = tc.ToString();
            lbltc15.Dock = DockStyle.Fill;
            lbltc15.AutoSize = true;
            lbltc15.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc15, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc15, 2);
            totaltc += tc;
            tc = 0;

            //Kiến thức giáo dục chuyên nghiệp
            //Kiến thức bổ trợ tự do
            Label lblktdc16 = new Label();
            lblktdc16.Text = "Kiến thức bổ trợ tự do";
            lblktdc16.Dock = DockStyle.Fill;
            lblktdc16.AutoSize = true;
            lblktdc16.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc16, 1, row);
            Tablepanel.SetColumnSpan(lblktdc16, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 2) && (check2 == 5))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            ilst.RemoveAll(x => x.LoaiKienThuc == 0);
            Label lbltc16 = new Label();
            lbltc16.Text = tc.ToString();
            lbltc16.Dock = DockStyle.Fill;
            lbltc16.AutoSize = true;
            lbltc16.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc16, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc16, 2);
            totaltc += tc;
            tc = 0;


            //Kiến thức giáo dục chuyên nghiệp
            //Thực tập tốt nghiệp và làm khóa luận
            Label lblktdc17 = new Label();
            lblktdc17.Text = "Thực tập tốt nghiệp và làm khóa luận";
            lblktdc17.Dock = DockStyle.Fill;
            lblktdc17.AutoSize = true;
            lblktdc17.Anchor = AnchorStyles.Left;
            Tablepanel.Controls.Add(lblktdc17, 1, row);
            Tablepanel.SetColumnSpan(lblktdc17, 2);
            rowtc = row;
            row++;
            foreach (MonHoc a in ilst)
            {
                int check1 = int.Parse(a.LoaiKienThuc.ToString().Substring(0, 1));
                int check2 = int.Parse(a.LoaiKienThuc.ToString().Substring(1, 1));
                if ((check1 == 2) && (check2 == 6))
                {
                    Tablepanel.Controls.Add(new Label() { Text = stt.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.HocKy.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    stt++;
                    tc += int.Parse(a.SoTinChi.ToString());
                    row++;
                    a.LoaiKienThuc = 0;
                }
            }
            Label lbltc17 = new Label();
            lbltc17.Text = tc.ToString();
            lbltc17.Dock = DockStyle.Fill;
            lbltc17.AutoSize = true;
            lbltc17.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc17, 3, rowtc);
            Tablepanel.SetColumnSpan(lbltc17, 2);
            totaltc += tc;
            Label lbltc18 = new Label();
            lbltc18.Text = (totaltc - int.Parse(lbltc8.Text)).ToString();
            lbltc18.Dock = DockStyle.Fill;
            lbltc18.AutoSize = true;
            lbltc18.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc18, 3, rowlv2);
            Tablepanel.SetColumnSpan(lbltc18, 2);
            Label lblktdc19 = new Label();
            lblktdc19.Text = "TỔNG";
            lblktdc19.Dock = DockStyle.Fill;
            lblktdc19.AutoSize = true;
            lblktdc19.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lblktdc19, 0, row);
            Tablepanel.SetColumnSpan(lblktdc19, 3);
            Label lbltc19 = new Label();
            lbltc19.Text = totaltc.ToString();
            lbltc19.Dock = DockStyle.Fill;
            lbltc19.AutoSize = true;
            lbltc19.Anchor = AnchorStyles.None;
            Tablepanel.Controls.Add(lbltc19, 3, row);
            Tablepanel.SetColumnSpan(lbltc19, 2);
            return Tablepanel;

        }


        public FlowLayoutPanel drawKHGD(List<MonHoc> ilst, int ihk)
        {
            FlowLayoutPanel rs = new FlowLayoutPanel();
            rs.FlowDirection = FlowDirection.TopDown;
            rs.Width = 1350;
            int sumheight = 0;
            for (int i = 0; i < ihk; i++)
            {
                int heighttb = 0;
                Label hki = new Label();
                hki.Text = "HỌC KÌ " + (i + 1);
                hki.Width = rs.Width;
                rs.Controls.Add(hki);
                TableLayoutPanel Tablepanel = new TableLayoutPanel();
                Tablepanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500));
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
                Tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                Label a1 = new Label() { Text = "STT", AutoSize = true, Anchor = AnchorStyles.None };
                Tablepanel.Controls.Add(a1, 0, 0);
                Tablepanel.SetRowSpan(a1, 2);
                Label a2 = new Label() { Text = "MMH", AutoSize = true, Anchor = AnchorStyles.None };
                Tablepanel.Controls.Add(a2, 1, 0);
                Tablepanel.SetRowSpan(a2, 2);
                Label a3 = new Label() { Text = "TÊN MÔN HỌC", AutoSize = true, Anchor = AnchorStyles.None };
                Tablepanel.Controls.Add(a3, 2, 0);
                Tablepanel.SetRowSpan(a3, 2);
                Tablepanel.Controls.Add(new Label() { Text = "SỐ", AutoSize = true, Anchor = AnchorStyles.None }, 3, 0);
                Label a4 = new Label() { Text = "SỐ TIẾT", AutoSize = true, Anchor = AnchorStyles.None };
                Tablepanel.Controls.Add(a4, 4, 0);
                Tablepanel.SetColumnSpan(a4, 3);
                Tablepanel.Controls.Add(new Label() { Text = "TC", AutoSize = true, Anchor = AnchorStyles.None }, 3, 1);
                Tablepanel.Controls.Add(new Label() { Text = "TS", AutoSize = true, Anchor = AnchorStyles.None }, 4, 1);
                Tablepanel.Controls.Add(new Label() { Text = "LT", AutoSize = true, Anchor = AnchorStyles.None }, 5, 1);
                Tablepanel.Controls.Add(new Label() { Text = "TH/BT", AutoSize = true, Anchor = AnchorStyles.None }, 6, 1);

                List<MonHoc> drawlst = ilst.Where(x => x.HocKy == (i + 1)).ToList();
                int row = 2;
                int sttint = 1;
                int tcint = 0;
                int tsint = 0;
                for (int m = 0; m < drawlst.Count; m++)
                {
                    Tablepanel.Controls.Add(new Label() { Text = sttint.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = drawlst[m].MonHoc_Id.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = drawlst[m].TenMonHoc.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = drawlst[m].SoTinChi.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = drawlst[m].SoGioLyThuyet.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 5, row);
                    Tablepanel.Controls.Add(new Label() { Text = drawlst[m].SoGioThucHanh.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 6, row);
                    string b = (drawlst[m].SoGioLyThuyet + drawlst[m].SoGioThucHanh).ToString();
                    Tablepanel.Controls.Add(new Label() { Text = b, AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    tcint += drawlst[m].SoTinChi;
                    tsint += (drawlst[m].SoGioLyThuyet + drawlst[m].SoGioThucHanh);
                    sttint++;
                    row++;
                }
                Label lblts = new Label();
                lblts.Text = "TỔNG";
                lblts.Dock = DockStyle.Fill;
                lblts.AutoSize = true;
                lblts.Anchor = AnchorStyles.None;
                Tablepanel.Controls.Add(lblts, 0, row);
                Tablepanel.SetColumnSpan(lblts, 3);
                Label lblts1 = new Label();
                lblts1.Text = tcint.ToString();
                lblts1.Dock = DockStyle.Fill;
                lblts1.AutoSize = true;
                lblts1.Anchor = AnchorStyles.None;
                Tablepanel.Controls.Add(lblts1, 3, row);
                Label lblts2 = new Label();
                lblts2.Text = tsint.ToString();
                lblts2.Dock = DockStyle.Fill;
                lblts2.AutoSize = true;
                lblts2.Anchor = AnchorStyles.None;
                Tablepanel.Controls.Add(lblts2, 4, row);
                heighttb = row;
                Tablepanel.Width = 1350;
                Tablepanel.Height = heighttb * 30 + 30;
                sumheight += Tablepanel.Height + 30 * 2 + hki.Height;
                rs.Controls.Add(Tablepanel);
            }
            rs.Height = sumheight;
            return rs;

        }

        public TableLayoutPanel drawDSGD(List<MonHoc> ilst, List<TaiKhoan> itk)
        {
            TableLayoutPanel Tablepanel = new TableLayoutPanel();
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250));
            Tablepanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500));
            Tablepanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            Label a1 = new Label() { Text = "STT", AutoSize = true, Anchor = AnchorStyles.None };
            Tablepanel.Controls.Add(a1, 0, 0);
            Label a2 = new Label() { Text = "Họ và tên", AutoSize = true, Anchor = AnchorStyles.None };
            Tablepanel.Controls.Add(a2, 1, 0);
            Label a3 = new Label() { Text = "Năm sinh", AutoSize = true, Anchor = AnchorStyles.None };
            Tablepanel.Controls.Add(a3, 2, 0);
            Label a4 = new Label() { Text = "Văn bằng cao nhất, ngành đào tạo", AutoSize = true, Anchor = AnchorStyles.None };
            Tablepanel.Controls.Add(a4, 3, 0);
            Label a5 = new Label() { Text = "Các môn đảm trách", AutoSize = true, Anchor = AnchorStyles.None };
            Tablepanel.Controls.Add(a5, 4, 0);
            int sttint = 1;
            int row = 1;
            foreach (TaiKhoan a in itk)
            {
                List<MonHoc> drlst = ilst.Where(x => x.GiangVienPhuTrach_Id == a.Id).ToList();
                string coursestr = "";
                foreach (MonHoc b in drlst)
                {
                    coursestr += b.TenMonHoc.ToString() + " ,";
                }
                if (drlst.Count > 0)
                {
                    string coursers = coursestr.Substring(0, coursestr.Length - 2);
                    Tablepanel.Controls.Add(new Label() { Text = sttint.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.Ten.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = "", AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = "", AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = coursers, AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    sttint++;
                    row++;
                }
                else
                {
                    Tablepanel.Controls.Add(new Label() { Text = sttint.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 0, row);
                    Tablepanel.Controls.Add(new Label() { Text = a.Ten.ToString(), AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 1, row);
                    Tablepanel.Controls.Add(new Label() { Text = "", AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 2, row);
                    Tablepanel.Controls.Add(new Label() { Text = "", AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 3, row);
                    Tablepanel.Controls.Add(new Label() { Text = "", AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.None }, 4, row);
                    sttint++;
                    row++;
                }

            }
            return Tablepanel;

        }

        public TableLayoutPanel drawNDVT(List<MonHoc> ilst, int ihk,List<SP_MONTIENQUYET_GETTRUE_Result>imtq)
        {
            TableLayoutPanel rs = new TableLayoutPanel();
            int row = 0;
            for (int i = 0; i < ihk; i++)
            {
                Label hki = new Label();
                hki.Text = "HỌC KÌ " + (i + 1);
                hki.Width = rs.Width;
                rs.Controls.Add(hki,0,row);
                row = row + 2;
                List<MonHoc> drawlst = ilst.Where(x => x.HocKy == (i + 1)).ToList();

                for (int m = 0; m < drawlst.Count; m++)
                {
                    string addstr = "   "+drawlst[m].TenMonHoc+"        ("+drawlst[m].SoTinChi+"TC:"+drawlst[m].SoGioLyThuyet+"lt+"+drawlst[m].SoGioThucHanh+"th)"+"\n Môn tiên quyết: ";
                    if (imtq.Count != 0)
                    {
                        foreach (SP_MONTIENQUYET_GETTRUE_Result b in imtq)
                        {
                            if (b.MonHoc_Id == drawlst[m].Id)
                            {
                                addstr += b.TenMonHoc + ", ";
                            }
                        }
                        addstr.Trim();
                    }
                    if (addstr.Substring(addstr.Length-2,2)==", ")
                    {
                        addstr.Trim();
                        addstr.Remove(addstr.Length-2);
                    }
                    if (addstr.Substring(addstr.Length - 2, 2) == ": ")
                    {
                        addstr += "không có";
                    }
                    addstr += "\n Nội dung: " + drawlst[m].NoiDungVanTat.Trim();
                    rs.Controls.Add(new Label() { Text = addstr, AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.Left,Dock =DockStyle.Left }, 0, row);
                    addstr = "";
                    rs.Controls.Add(new Label() { Text = "", AutoSize = true, BackColor = Color.White, Anchor = AnchorStyles.Left, Dock = DockStyle.Left }, 0, row);
                }
                row = row + 2;
                
            }
            return rs;


        }

    }
}
