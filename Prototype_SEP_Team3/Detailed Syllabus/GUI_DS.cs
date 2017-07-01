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
        DBEntities model = new DBEntities();
        BUS_DCCT bus = new BUS_DCCT();

        List<List<string>> mtmhlist;
        List<List<string>> taiLieuList;
        List<MaTran_CDR_HD_NoiDungList> CDR_noidung_lst;
        List<PhuongPhapDanhGiaKQHT_List> PPDG_Lst;
        List<string> ppgd_AddCBox;
        List<KeHoachKiemTra_List> khkt_Lst;
        List<KeHoachGiangDayCuThe_List> khgd_Lst;
        List<string> ndgd;
        List<string> hdgd;
        List<string> tlcd;

        string itemcontent = "";
        int itemposition = 0;

        int oldcboCDR = 0;
        string oldcboCDRstr = "";
        string oldloai = "";
        string oldnd = "";

        int getId;
        int getCTDT_ID;

        ////kiem tra load ck
        //int checkck = 0;

        public GUI_DS(int id, int ctdt_Id)
        {
            InitializeComponent();
            getId = id;
            getCTDT_ID = ctdt_Id;
            this.WindowState = FormWindowState.Maximized;

            string c = Directory.GetCurrentDirectory();
            //wbPhanbothoigian.Navigate(Path.Combine(c, "Detailed Syllabus\\DSCkeditor.html"));
            //wbYeuCauMH.Navigate(Path.Combine(c, "Detailed Syllabus\\DSCkeditor.html"));
            //wbThoiGianHoc.Navigate(Path.Combine(c, "Detailed Syllabus\\DSCkeditor.html"));

            //bus.LoadDCCT(id, ctdt_Id, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
            //             nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
            //             lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
            //             lstKHKT, wbYeuCauMH, lstKHGDCT);

            bus.LoadDCCT(id, ctdt_Id, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);

            DataGridViewCheckBoxColumn chkMapping = new DataGridViewCheckBoxColumn();
            chkMapping.HeaderText = "Mapping";
            lstMaTran_ChuanDauRaCTDT.Columns.Add(chkMapping);

            // load datagridview Ma tran 2 cai CDR
            //try
            //{
            //    int cdrmh_Id = int.Parse(cboMaTran_ChuanDauRaMonHoc.SelectedValue.ToString());

            //    int stt_CDRMH = model.ChuanDauRaMonHocs.FirstOrDefault(x => x.Id == cdrmh_Id).STT.Value;

            //    loadListCDRCTDT_2(stt_CDRMH);
            //}
            //catch
            //{

            //}

            #region VISIBLE CÁC BUTTON SỬA-HỦY
            btnMụctiêu_sửa.Visible = false;
            btnMụctiêu_hủy.Visible = false;
            btnCDR_Sua.Visible = false;
            btnCDR_Huy.Visible = false;
            btnTaiLieu_Sua.Visible = false;
            btnTaiLieu_Huy.Visible = false;
            btnPPDG_Sua.Visible = false;
            btnPPDG_Huy.Visible = false;
            btnKHKiemTra_Sua.Visible = false;
            btnKHKiemTra_Huy.Visible = false;
            btnMatranCDRvsHD_Sua.Visible = false;
            btnMatranCDRvsHD_Huy.Visible = false;
            //btnKHGDCT_SuaND.Visible = false;
            //btnKHGDCT_HuyND.Visible = false;
            //btnKHGDCT_SuaHD.Visible = false;
            //btnKHGDCT_HuyHD.Visible = false;
            //btnKHGDCT_SuaTL.Visible = false;
            //btnKHGDCT_HuyTL.Visible = false;
            btnKHGDCT_Sua.Visible = false;
            btnKHGDCT_Huy.Visible = false;
            btnMT2CDR_Update.Visible = false;
            #endregion

            #region NEW CÁC LIST
            mtmhlist = new List<List<string>>();

            //Muc tieu mon hoc list
            mtmhlist.Add(new List<string>()); //0
            mtmhlist.Add(new List<string>()); //1
            mtmhlist.Add(new List<string>()); //2

            //Chuan dau ra list
            mtmhlist.Add(new List<string>()); //3

            //KHGDCT - Noi dung mon hoc list
            mtmhlist.Add(new List<string>()); //4

            //KHGDCT - Hoat dong day va hoc list
            mtmhlist.Add(new List<string>()); //5

            //KHGDCT - Tai lieu can doc list
            mtmhlist.Add(new List<string>()); //6

            //Tai lieu list
            taiLieuList = new List<List<string>>();
            taiLieuList.Add(new List<string>());
            taiLieuList.Add(new List<string>());
            taiLieuList.Add(new List<string>());

            CDR_noidung_lst = new List<MaTran_CDR_HD_NoiDungList>();
            PPDG_Lst = new List<PhuongPhapDanhGiaKQHT_List>();

            ppgd_AddCBox = new List<string>();
            ppgd_AddCBox.Add("Dự lớp");
            ppgd_AddCBox.Add("Kiểm tra tại lớp");
            ppgd_AddCBox.Add("Thảo luận");
            ppgd_AddCBox.Add("Tự học online");
            ppgd_AddCBox.Add("Bài tập lớn");
            ppgd_AddCBox.Add("Thi cuối học phần");

            khkt_Lst = new List<KeHoachKiemTra_List>();
            khgd_Lst = new List<KeHoachGiangDayCuThe_List>();

            ndgd = new List<string>();
            hdgd = new List<string>();
            tlcd = new List<string>();
            #endregion

            #region LOAD DATA LEN LIST
            try
            {
                DBEntities db = new DBEntities();

                List<MucTieuMonHoc> mtmhobj = db.MucTieuMonHocs.Where(x => x.DeCuongChiTiet_Id == getId).ToList();
                foreach (MucTieuMonHoc a in mtmhobj)
                {
                    if (a.Loai == "Kiến thức")
                    {
                        mtmhlist[0].Add(a.NoiDung);
                    }
                    if (a.Loai == "Kỹ năng")
                    {
                        mtmhlist[1].Add(a.NoiDung);
                    }
                    if (a.Loai == "Thái độ")
                    {
                        mtmhlist[2].Add(a.NoiDung);
                    }
                }

                List<ChuanDauRaMonHoc> cdrmh = db.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == id).ToList();

                foreach (ChuanDauRaMonHoc cdr in cdrmh)
                {
                    mtmhlist[3].Add(cdr.NoiDung);
                }

                List<TaiLieuMonHoc> tlmh = db.TaiLieuMonHocs.Where(x => x.DeCuongChiTiet_Id == getId).ToList();
                foreach (TaiLieuMonHoc tl in tlmh)
                {
                    if (tl.Loai == "Sách/Giáo trình chính")
                        taiLieuList[0].Add(tl.NoiDung);

                    if (tl.Loai == "Sách/Giáo trình tham khảo")
                        taiLieuList[1].Add(tl.NoiDung);

                    if (tl.Loai == "Tư liệu trực tuyến")
                        taiLieuList[2].Add(tl.NoiDung);
                }

                List<MaTran_ChuanDauRaMH_HDGDPPDG> mt_CDR_HDGD = db.MaTran_ChuanDauRaMH_HDGDPPDG.Where(x => x.ChuanDauRaMonHoc.DeCuongChiTiet_Id == id).ToList();
                foreach (MaTran_ChuanDauRaMH_HDGDPPDG item in mt_CDR_HDGD)
                {
                    MaTran_CDR_HD_NoiDungList mt;

                    if (item.Loai != "Các hoạt động dạy và học")
                    {
                        mt = new MaTran_CDR_HD_NoiDungList(item.ChuanDauRaMonHoc.NoiDung, item.Loai, item.NoiDung);
                        CDR_noidung_lst.Add(mt);
                    }

                    if (item.Loai != "Phương pháp kiểm tra, đánh giá sinh viên")
                    {
                        mt = new MaTran_CDR_HD_NoiDungList(item.ChuanDauRaMonHoc.NoiDung, item.Loai, item.NoiDung);
                        CDR_noidung_lst.Add(mt);
                    }
                }

                List<PPDanhGiaKQHT> ppdg = db.PPDanhGiaKQHTs.Where(x => x.DeCuongChiTiet_Id == id).ToList();
                PhuongPhapDanhGiaKQHT_List pp;
                foreach (PPDanhGiaKQHT item in ppdg)
                {
                    pp = new PhuongPhapDanhGiaKQHT_List(item.LoaiNoiDung, item.SoLanDanhGia, item.TrongSo.Value, item.HinhThucDanhGia);
                    PPDG_Lst.Add(pp);
                }

                List<KeHoanKiemTra> khkt = db.KeHoanKiemTras.Where(x => x.DeCuongChiTiet_Id == id).ToList();
                KeHoachKiemTra_List kh;
                foreach (KeHoanKiemTra item in khkt)
                {
                    kh = new KeHoachKiemTra_List(item.HinhThuc, item.NoiDung, item.ThoiDiem, item.CongCuKT);
                    khkt_Lst.Add(kh);
                }

            }
            catch
            {

            }
            showMuctieumonhoc();
            showChuanDauRaMonHoc();
            showTaiLieu();
            showMaTran_CDR_HD();
            showPPDG();
            showKeHoachKiemTra();
            #endregion
        }

        #region NUT DIEU HUONG CAC TAP
        //NÚT PREVIOUS
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DBEntities db = new DBEntities();
            DeCuongChiTiet dc = db.DeCuongChiTiets.FirstOrDefault(x => x.Id == getId);
            GVGD gd = db.GVGDs.FirstOrDefault(x => x.DCCT_Id == getId);
            if (tclMain.SelectedIndex > 0)
            {
                tclMain.SelectedIndex = tclMain.SelectedIndex - 1;
            }
            //if (checkck == 0)
            //{
            //    WebBrowser[] iarr = new WebBrowser[] { wbPhanbothoigian, wbThoiGianHoc, wbYeuCauMH };
            //    readCK(iarr, getId);
            //    checkck = 1;
            //    checkck = 1;
            //}

        }

        //NÚT NEXT
        private void btnNext_Click(object sender, EventArgs e)
        {
            DBEntities db = new DBEntities();
            DeCuongChiTiet dc = db.DeCuongChiTiets.FirstOrDefault(x => x.Id == getId);
            GVGD gd = db.GVGDs.FirstOrDefault(x => x.DCCT_Id == getId);
            if (tclMain.SelectedIndex < 15)
            {
                tclMain.SelectedIndex = tclMain.SelectedIndex + 1;
            }
            //if (checkck == 0)
            //{
            //    WebBrowser[] iarr = new WebBrowser[] {wbPhanbothoigian,wbThoiGianHoc,wbYeuCauMH };
            //    readCK(iarr, getId);
            //    checkck = 1;
            //}

        }
        #endregion

        #region SET UP MỤC LỤC
        private void toolStripStatusLabel2_MouseHover(object sender, EventArgs e)
        {
            msMụclục.ShowDropDown();
            //if (checkck == 0)
            //{
            //    WebBrowser[] iarr = new WebBrowser[] { wbPhanbothoigian, wbThoiGianHoc, wbYeuCauMH };
            //    readCK(iarr, getId);
            //    checkck = 1;
            //    checkck = 1;
            //}
        }

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
            tclMain.SelectedIndex = 1;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 1;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 1;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 1;
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            DBEntities db = new DBEntities();
            DeCuongChiTiet dc = db.DeCuongChiTiets.FirstOrDefault(x => x.Id == getId);
            GVGD gd = db.GVGDs.FirstOrDefault(x => x.DCCT_Id == getId);
            tclMain.SelectedIndex = 2;
            //if (checkck == 0)
            //{
            //    try
            //    {
            //        object[] ob1 = new object[1] { dc.PhanBoThoiGian };
            //        object[] ob2 = new object[1] { gd.ThoiGian };
            //        object[] ob3 = new object[1] { dc.YeuCauMonHoc };
            //        object l1 = wbPhanbothoigian.Document.InvokeScript("setcontent", ob1);
            //        object l2 = wbThoiGianHoc.Document.InvokeScript("setcontent", ob2);
            //        object l3 = wbYeuCauMH.Document.InvokeScript("setcontent", ob3);
            //    }
            //    catch
            //    {

            //    }
            //    checkck = 1;
            //}
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 3;
        }

        private void maTrậnTíchHợpGiữaChuẩnĐầuRaMônHọcVàChuẩnĐầuRaCủaChươngTrìnhĐàoTạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 4;
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 5;
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 5;
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 6;
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 7;
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 7;
        }

        private void yêuCầuMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBEntities db = new DBEntities();
            DeCuongChiTiet dc = db.DeCuongChiTiets.FirstOrDefault(x => x.Id == getId);
            GVGD gd = db.GVGDs.FirstOrDefault(x => x.DCCT_Id == getId);
            tclMain.SelectedIndex = 8;
            //if (checkck == 0)
            //{
            //    try
            //    {
            //        object[] ob1 = new object[1] { dc.PhanBoThoiGian };
            //        object[] ob2 = new object[1] { gd.ThoiGian };
            //        object[] ob3 = new object[1] { dc.YeuCauMonHoc };
            //        object l1 = wbPhanbothoigian.Document.InvokeScript("setcontent", ob1);
            //        object l2 = wbThoiGianHoc.Document.InvokeScript("setcontent", ob2);
            //        object l3 = wbYeuCauMH.Document.InvokeScript("setcontent", ob3);
            //    }
            //    catch
            //    {

            //    }
            //    checkck = 1;
            //}
        }

        private void kếHoạchGiảngDạyVàHọcTậpCụThểToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tclMain.SelectedIndex = 8;
        }
        #endregion

        #region SET NOI DUNG CHO COMBOBOX
        private void cboQuảnlí_loạikt_1_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboKhoiKienThuc_1.SelectedItem.ToString() == "Kiến thức giáo dục đại cương")
            {
                List<string> arr = new List<string> { "Lý luận chính trị", "Khoa học xã hội", 
                    "Nhân văn-Nghệ thuật", "Ngoại ngữ", "Toán-Tin học-Khoa học tự nhiên-Công nghệ-Môi trường", 
                        "Giáo dục thể chất", "Giáo dục Quốc Phòng- an ninh" };
                cboKhoiKienThuc_2.DataSource = arr.ToList();
            }
            if (cboKhoiKienThuc_1.SelectedItem.ToString() == "Kiến thức giáo dục chuyên nghiệp")
            {
                List<string> arr = new List<string> { "Kiến thức cơ sở", "Kiến thức ngành chính", 
                    "Kiến thức chung của ngành chính", "Kiến thức chuyên sâu của ngành chính", 
                        "Kiến thức ngành thứ hai", "Kiến thức bổ trợ tự do", "Thực tập tốt nghiệp và làm khóa luận" };
                cboKhoiKienThuc_2.DataSource = arr.ToList();
            }
        }

        private void cboQuảnlí_loạikt_2_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if ((cboKhoiKienThuc_2.SelectedItem.ToString() == "Khoa học xã hội")
               || (cboKhoiKienThuc_2.SelectedItem.ToString() == "Nhân văn-Nghệ thuật")
                   || (cboKhoiKienThuc_2.SelectedItem.ToString() == "Toán-Tin học-Khoa học tự nhiên-Công nghệ-Môi trường")
                       || (cboKhoiKienThuc_2.SelectedItem.ToString() == "Kiến thức chuyên sâu của ngành chính")
                            || (cboKhoiKienThuc_2.SelectedItem.ToString() == "Kiến thức ngành thứ hai"))
            {
                List<string> arr = new List<string> { "Bắt buộc", "Tự chọn" };
                cboKhoiKienThuc_3.DataSource = arr.ToList();
            }
            else
            {
                List<string> arr = new List<string> { "" };
                cboKhoiKienThuc_3.DataSource = arr.ToList();
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            DeCuongChiTiet dcct = model.DeCuongChiTiets.Single(x => x.Id == getId);
            //if (checkck == 1)
            //{

            //dcct
            string tenChuongTrinh = txtTenChuongTrinh.Text;
            string tenTiengAnh = txtTenTiengAnh.Text;
            string trinhDo = txtTrinhDo.Text;

            // BUS 
            bool flag = bus.Update_DCCT(getId, tenChuongTrinh, tenTiengAnh, trinhDo);

            //mon hoc
            string maHocPhan = txtMaHocPhan.Text;
            string vanTat = txtMoTaVanTat.Text;

            // BUS 
            bool flag1 = bus.Update_Course(dcct.MonHoc_Id.Value, tenChuongTrinh, tenTiengAnh, vanTat, maHocPhan);

            //?????????????????????????????????
            int tinChi = int.Parse(nbrSoTinChi.Value.ToString());


            //gvgd
            string GVPTMH = txtGVPTMH.Text;
            string diachi = txtDCCQ.Text;
            string sdt = txtDCLH.Text;
            string email = txtDCLH.Text;
            string troGiang = txtGVTG.Text;

            GVGD gv = model.GVGDs.FirstOrDefault(x => x.DCCT_Id == getId);

            // BUS
            bool flag2 = false;
            bool flag3 = false;

            if (gv == null)
            {
                flag2 = bus.CreateGVGD(getId, diachi, sdt, email, troGiang, GVPTMH);

            }
            else
            {
                flag3 = bus.UpdateGVGD(getId, diachi, sdt, email, troGiang, GVPTMH);

            }

            if ((flag == true) && (flag1 == true) && ((flag2 == true) || (flag3 == true)))
            {
                MessageBox.Show("Đã lưu");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }

            //object ob1 = wbPhanbothoigian.Document.InvokeScript("getcontent");
            //object ob2 = wbThoiGianHoc.Document.InvokeScript("getcontent");
            //object ob3 = wbYeuCauMH.Document.InvokeScript("getcontent");

            //string[] hdarr = new string[] { ob1.ToString(), ob2.ToString(), ob3.ToString() };

            //handleCK(hdarr, getId);

            //DBEntities db = new DBEntities();
            //DeCuongChiTiet add = db.DeCuongChiTiets.Single(x => x.Id == getId);
            //add.PhanBoThoiGian = ConvertUnicdoe(ob1.ToString());
            //GVDG add2 = db.GVDGs.Single(x => x.DCCT_Id == getId);
            //add2.ThoiGian = ConvertUnicdoe(ob2.ToString());
            //add.YeuCauMonHoc = ConvertUnicdoe(ob3.ToString());
            //db.SaveChanges();

            int getMH_ID = model.DeCuongChiTiets.FirstOrDefault(x => x.Id == getId).MonHoc_Id.Value;

            foreach (DataGridViewRow row in lstHocPhanTruoc.Rows)
            {
                int ma = int.Parse(row.Cells[0].Value.ToString());
                int mtq = int.Parse(row.Cells[2].Value.ToString());
                bool flagUpdate = bus.Update_HocPhan(ma, getMH_ID, mtq, (bool)row.Cells[3].Value);
            }

            //}




        }

        ////CKEDITOR CONVERT
        //private string ConvertUnicdoe(string istr)
        //{
        //    istr = System.Net.WebUtility.HtmlDecode(istr);
        //    istr = istr.Replace("<ul>", "").Replace("</ul>", "").Replace("<li>", "\n").Replace("</li>", "\n").
        //        Replace("<ol>", "").Replace("</ol>", "\n").Replace("<em>", "").Replace("</em>", "").
        //            Replace("<s>", "").Replace("</s>", "").Replace("<strong>", "").Replace("</strong>", "").
        //                Replace("<p>", "").Replace("</p>", "").Replace("<br>", "").Replace("/br", "").Replace("\t", "").Trim();
        //    istr = istr.Replace("\n\n", "");
        //    return istr;
        //}

        #region MUC TIEU MON HOC LIST
        //MUC TIEU MON HOC LIST
        // NUT NHAP
        // NUT XOA
        private void btnMụctiêu_thêm_Click(object sender, EventArgs e)
        {
            //kiem tra chức năng
            if (btnMụctiêu_thêm.Text == ">>>")
            {
                //làm sạch view
                lstMucTieuMonHoc.Items.Clear();
                // lấy, kiểm tra dữ liệu
                string lv = cboMucTieuMonHoc_Loai.Text;

                if (lv != "")
                {
                    if (txtMucTieuMonHoc_NoiDung.Text != "")
                    {
                        if (lv == "Kiến thức")
                        {
                            string add = txtMucTieuMonHoc_NoiDung.Text.Trim();

                            mtmhlist[0].Add(add);

                            double stt = 0;
                            if (mtmhlist[0].Count == 0)
                                stt = stt + 1.0;
                            else
                                stt = 1 + mtmhlist[0].Count * 0.1;

                            bool flagKT = bus.Add_MucTieuMonHoc(getId, lv, add, stt);

                            if (flagKT == false)
                            {
                                MessageBox.Show("Thêm mục tiêu vào CSDL thất bại");
                                mtmhlist[0].Remove(add);
                            }
                        }

                        if (lv == "Kĩ năng")
                        {
                            mtmhlist[1].Add(txtMucTieuMonHoc_NoiDung.Text.Trim());

                            double stt = 0;
                            if (mtmhlist[1].Count == 0)
                                stt = stt + 2.0;
                            else
                                stt = 2 + mtmhlist[1].Count * 0.1;

                            bool flagKN = bus.Add_MucTieuMonHoc(getId, lv, txtMucTieuMonHoc_NoiDung.Text.Trim(), stt);

                            if (flagKN == false)
                            {
                                MessageBox.Show("Thêm mục tiêu vào CSDL thất bại");
                                mtmhlist[1].Remove(txtMucTieuMonHoc_NoiDung.Text.Trim());
                            }
                        }

                        if (lv == "Thái độ")
                        {
                            mtmhlist[2].Add(txtMucTieuMonHoc_NoiDung.Text.Trim());

                            double stt = 0;
                            if (mtmhlist[2].Count == 0)
                                stt = stt + 3.0;
                            else
                                stt = 3 + mtmhlist[2].Count * 0.1;

                            bool flagTD = bus.Add_MucTieuMonHoc(getId, lv, txtMucTieuMonHoc_NoiDung.Text.Trim(), stt);

                            if (flagTD == false)
                            {
                                MessageBox.Show("Thêm mục tiêu vào CSDL thất bại");
                                mtmhlist[2].Remove(txtMucTieuMonHoc_NoiDung.Text.Trim());
                            }
                        }
                        //show list view 
                        showMuctieumonhoc();
                        txtMucTieuMonHoc_NoiDung.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Hãy điền nội dung");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn mục cần điền");
                }
            }
            //Xóa item
            if (btnMụctiêu_thêm.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {

                    //thuc hien xoa
                    bus.Delete_MucTieuMonHoc(getId, cboMucTieuMonHoc_Loai.Text, txtMucTieuMonHoc_NoiDung.Text, getSTT);
                    deleteItem(itemcontent, itemposition);

                    //vẽ lại view
                    lstMucTieuMonHoc.Items.Clear();
                    showMuctieumonhoc();

                    //làm sạch content
                    txtMucTieuMonHoc_NoiDung.Text = "";

                    //visible 2 nút sửa, hủy
                    btnMụctiêu_sửa.Visible = false;
                    btnMụctiêu_hủy.Visible = false;
                    btnMụctiêu_thêm.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã xóa đối tượng thành công");
                }


            }
        }

        //MỤC TIÊU MÔN HỌC
        //Hàm vẽ list view
        private void showMuctieumonhoc()
        {
            lstMucTieuMonHoc.Items.Add("+ Kiến thức: ");
            for (int i = 0; i < mtmhlist[0].Count; i++)
            {
                lstMucTieuMonHoc.Items.Add("\n         1." + (i + 1) + "  " + mtmhlist[0][i]);
            }
            lstMucTieuMonHoc.Items.Add("+ Kĩ năng: ");
            for (int i = 0; i < mtmhlist[1].Count; i++)
            {
                lstMucTieuMonHoc.Items.Add("\n         2." + (i + 1) + "  " + mtmhlist[1][i]);
            }

            lstMucTieuMonHoc.Items.Add("+ Thái độ: ");
            for (int i = 0; i < mtmhlist[2].Count; i++)
            {
                lstMucTieuMonHoc.Items.Add("\n         3." + (i + 1) + "  " + mtmhlist[2][i]);
            }
        }

        //MỤC TIÊU MÔN HỌC
        //load dữ liệu item dc chọn trong view

        double getSTT = 0;

        private void lwĐàotạo_view_DoubleClick(object sender, EventArgs e)
        {
            if (lstMucTieuMonHoc.SelectedItems.Count == 1)
            {
                if ((lstMucTieuMonHoc.SelectedItem.ToString() != "+ Kĩ năng: ") && (lstMucTieuMonHoc.SelectedItem.ToString() != "+ Thái độ: ") && (lstMucTieuMonHoc.SelectedItem.ToString() != "+ Kiến thức: "))
                {
                    cboMucTieuMonHoc_Loai.Enabled = false;
                    btnMụctiêu_sửa.Visible = true;
                    btnMụctiêu_hủy.Visible = true;
                    btnMụctiêu_thêm.Text = "Xóa";

                    itemposition = lstMucTieuMonHoc.SelectedIndex;

                    int s1 = 0;
                    int s2 = mtmhlist[0].Count + 1;
                    int s3 = s2 + mtmhlist[1].Count + 1;


                    int[] arr = new[] { s1, s2, s3 };

                    int selectindex = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        if ((itemposition > arr[i]) && (itemposition < arr[i + 1]))
                        {
                            if (i == 0)
                            {
                                selectindex = 0;
                                txtMucTieuMonHoc_NoiDung.Text = lstMucTieuMonHoc.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtMucTieuMonHoc_NoiDung.Text.Substring(3, 1) == " ")
                                {
                                    txtMucTieuMonHoc_NoiDung.Text = txtMucTieuMonHoc_NoiDung.Text.Substring(5, txtMucTieuMonHoc_NoiDung.Text.Length - 5);
                                }
                                else
                                {
                                    txtMucTieuMonHoc_NoiDung.Text = txtMucTieuMonHoc_NoiDung.Text.Substring(6, txtMucTieuMonHoc_NoiDung.Text.Length - 6);
                                }
                                break;
                            }
                            if (i == 1)
                            {
                                selectindex = 1;
                                txtMucTieuMonHoc_NoiDung.Text = lstMucTieuMonHoc.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtMucTieuMonHoc_NoiDung.Text.Substring(3, 1) == " ")
                                {
                                    txtMucTieuMonHoc_NoiDung.Text = txtMucTieuMonHoc_NoiDung.Text.Substring(5, txtMucTieuMonHoc_NoiDung.Text.Length - 5);
                                }
                                else
                                {
                                    txtMucTieuMonHoc_NoiDung.Text = txtMucTieuMonHoc_NoiDung.Text.Substring(6, txtMucTieuMonHoc_NoiDung.Text.Length - 6);
                                }
                                break;
                            }
                        }
                        else
                        {
                            if (i == 1)
                            {
                                selectindex = 2;
                                txtMucTieuMonHoc_NoiDung.Text = lstMucTieuMonHoc.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtMucTieuMonHoc_NoiDung.Text.Substring(3, 1) == " ")
                                {
                                    txtMucTieuMonHoc_NoiDung.Text = txtMucTieuMonHoc_NoiDung.Text.Substring(5, txtMucTieuMonHoc_NoiDung.Text.Length - 5);
                                }
                                else
                                {
                                    txtMucTieuMonHoc_NoiDung.Text = txtMucTieuMonHoc_NoiDung.Text.Substring(6, txtMucTieuMonHoc_NoiDung.Text.Length - 6);
                                }
                            }
                        }
                    }

                    itemcontent = txtMucTieuMonHoc_NoiDung.Text.Trim();

                    cboMucTieuMonHoc_Loai.SelectedIndex = selectindex;

                    DBEntities model = new DBEntities();

                    double mt = model.MucTieuMonHocs.FirstOrDefault(x => x.DeCuongChiTiet_Id == getId && x.Loai == cboMucTieuMonHoc_Loai.Text && x.NoiDung == itemcontent).STT.Value;

                    getSTT = mt;
                }

            }
        }

        //MỤC TIÊU MÔN HỌC
        //Nút hủy edit/xóa trong view

        private void btnMụctiêu_hủy_Click(object sender, EventArgs e)
        {
            btnMụctiêu_thêm.Text = ">>>";
            btnMụctiêu_sửa.Visible = false;
            btnMụctiêu_hủy.Visible = false;

            txtMucTieuMonHoc_NoiDung.Text = "";
        }

        //MỤC TIÊU ĐÀO TẠO
        //Thuật toán xóa
        private void deleteItem(string item, int local)
        {
            int s1 = 0;
            int s2 = mtmhlist[0].Count + 1;
            int s3 = s2 + mtmhlist[1].Count + 1;

            int[] arr = new[] { s1, s2, s3 };

            for (int i = 0; i < 2; i++)
            {
                if ((local > arr[i]) && (local < arr[i + 1]))
                {
                    if (i == 0)
                    {
                        mtmhlist[0].Remove(item);
                        break;
                    }
                    if (i == 1)
                    {
                        mtmhlist[1].Remove(item);
                        break;
                    }

                }
                else
                {
                    if (i == 1)
                    {
                        mtmhlist[2].Remove(item);
                    }
                }
            }

        }

        private void editItem(string item, int position, ComboBox cbo)
        {

            // tìm ra list cũ
            int s1 = 0;
            int s2 = mtmhlist[0].Count + 1;
            int s3 = s2 + mtmhlist[1].Count + 1;

            int[] arr = new[] { s1, s2, s3 };

            //List<List<string>> sum_arr = new List<List<string>> { mtc, mtct_pc, mtct_kt, mtct_kn, mtct_td };

            List<string> work = new List<string>();

            int editint = 0;

            for (int g = 0; g < 2; g++)
            {
                if ((position > arr[g]) && (position < arr[g + 1]))
                {
                    work = mtmhlist[g];
                    editint = g;
                    break;
                }
                else
                {
                    if (g == 1)
                    {
                        work = mtmhlist[g + 1];
                        editint = g + 1;
                    }
                }
            }

            //Trường hợp edit list cũ
            if ((cbo.SelectedIndex == editint) && (editint == 0))
            {
                work[position - 1] = txtMucTieuMonHoc_NoiDung.Text.Trim();
            }
            else
            {
                if ((cbo.SelectedIndex == editint) && (editint == 1))
                {
                    work[position - (2 + mtmhlist[0].Count)] = txtMucTieuMonHoc_NoiDung.Text.Trim();
                }
                else
                {
                    if ((cbo.SelectedIndex == editint) && (editint == 2))
                    {
                        work[position - (3 + mtmhlist[0].Count + mtmhlist[1].Count)] = txtMucTieuMonHoc_NoiDung.Text.Trim();
                    }
                }
            }
        }

        //MỤC TIÊU MÔN HỌC
        //Nút sửa
        private void btnMụctiêu_sửa_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtMucTieuMonHoc_NoiDung.Text != "")
                {
                    //Xóa sach item trong view
                    lstMucTieuMonHoc.Items.Clear();

                    //Chạy thuật toán edit
                    editItem(itemcontent, itemposition, cboMucTieuMonHoc_Loai);
                    bool flagUpdate = bus.Update_MucTieuMonHoc(getId, cboMucTieuMonHoc_Loai.Text, txtMucTieuMonHoc_NoiDung.Text, getSTT);

                    showMuctieumonhoc();

                    //xóa content
                    txtMucTieuMonHoc_NoiDung.Text = "";

                    //vẽ lại view
                    //showMuctieumonhoc();

                    //visible 2 nút sửa, hủy           
                    btnMụctiêu_sửa.Visible = false;
                    btnMụctiêu_hủy.Visible = false;
                    btnMụctiêu_thêm.Text = ">>>";
                    cboMucTieuMonHoc_Loai.Enabled = true;

                    //thông báo
                    MessageBox.Show("Đã sửa đối tượng thành công");
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }
        }
        #endregion

        #region CHUAN DAU RA MON HOC LIST
        //CHUAN DAU RA MON HOC LIST
        // NUT NHAP
        // NUT XOA
        private void btnCDR_Them_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();
            //kiem tra chức năng
            if (btnCDR_Them.Text == ">>>")
            {
                //làm sạch view
                lstChuanDauRa.Items.Clear();

                if (txtChuanDauRaMonHoc_NoiDung.Text != "")
                {
                    string add = txtChuanDauRaMonHoc_NoiDung.Text.Trim();

                    List<ChuanDauRaMonHoc> lstCDR = model.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == getId).ToList();
                    bool notAllowToAdd = lstCDR.Any(x => x.NoiDung == add);
                    if (!notAllowToAdd)
                    {
                        mtmhlist[3].Add(add);

                        bool flag = bus.Add_ChuanDauRaMonHoc(getId, mtmhlist[3].Count, add);
                        if (flag == true)
                        {
                            //bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
                            //                nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                            //                lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                            //                lstKHKT, wbYeuCauMH, lstKHGDCT);

                            bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);

                        }
                        else MessageBox.Show("Thêm chuẩn đầu ra thất bại");

                        // load datagridview CDR CTDT
                        //int stt_CDRMH = int.Parse(cboMaTran_ChuanDauRaMonHoc.SelectedValue.ToString());
                        //loadListCDRCTDT_2(stt_CDRMH);

                        //show list view 
                        showChuanDauRaMonHoc();
                        txtChuanDauRaMonHoc_NoiDung.Text = "";
                    }
                    else MessageBox.Show("Chuẩn đầu ra đã tồn tại");

                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }
            //Xóa item
            if (btnCDR_Them.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {

                    //thuc hien xoa
                    deleteChuanDauRaItem(itemcontent);
                    if (flagNotAllowToDelete == false)
                    {
                        //vẽ lại view
                        lstChuanDauRa.Items.Clear();
                        showChuanDauRaMonHoc();

                        //làm sạch content
                        txtChuanDauRaMonHoc_NoiDung.Text = "";

                        //visible 2 nút sửa, hủy
                        btnCDR_Sua.Visible = false;
                        btnCDR_Huy.Visible = false;
                        btnCDR_Them.Text = ">>>";

                        //thông báo
                        MessageBox.Show("Đã xóa đối tượng thành công");
                    }
                    else
                    {

                    }
                }
            }
        }

        //CHUAN DAU RA MON HOC LIST
        //Hàm vẽ list view
        private void showChuanDauRaMonHoc()
        {
            lstChuanDauRa.Items.Add("+ Chuẩn đầu ra môn học: ");
            for (int i = 0; i < mtmhlist[3].Count; i++)
            {
                lstChuanDauRa.Items.Add("\n         " + (i + 1) + ".  " + mtmhlist[3][i]);
            }
        }

        //CHUAN DAU RA MON HOC LIST
        //Thuật toán xóa
        bool flagNotAllowToDelete = false;
        private void deleteChuanDauRaItem(string item)
        {
            DBEntities model = new DBEntities();

            MaTran_CDRMH_CDRCTDT mt1 = model.MaTran_CDRMH_CDRCTDT.FirstOrDefault(x => x.ChuanDauRaMonHoc.NoiDung == item);
            MaTran_ChuanDauRaMH_HDGDPPDG mt2 = model.MaTran_ChuanDauRaMH_HDGDPPDG.FirstOrDefault(x => x.ChuanDauRaMonHoc.NoiDung == item);

            bool allowToDelete_1 = false;
            bool allowToDelete_2 = false;

            if (mt1 != null && mt2 == null)
            {
                DialogResult a = MessageBox.Show("CĐR môn học này đang có liên kết với CĐR CTĐT, bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    // Delete MT2CDR
                    bool flagDelete = bus.Delete_MaTran_2CDR(getId, mt1.CDRMH_Id);

                    if (flagDelete == true)
                    {
                        allowToDelete_1 = true;

                        bool flagDelete_2 = bus.Delete_ChuanDauRaMonHoc(getId, getCDR_NoiDung);

                        if (flagDelete_2 == true)
                        {
                            mtmhlist[3].Remove(mtmhlist[3][lstChuanDauRa.SelectedIndex - 1]);

                            //bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
                            //                nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                            //                lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                            //lstKHKT, wbYeuCauMH, lstKHGDCT);

                            bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);

                            updateSTTChuanDauRaMonHoc();
                        }
                    }
                    else
                        allowToDelete_1 = false;
                }
            }

            if (mt1 == null && mt2 != null)
            {
                DialogResult a = MessageBox.Show("CĐR môn học này đang có liên kết với HĐGD-PPĐG, bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    // Delete MT HDGD
                    bool flagDelete = bus.Delete_MaTran_HDGD(mt2.ChuanDauRaMonHoc_Id.Value);

                    if (flagDelete == true)
                    {
                        allowToDelete_2 = true;

                        bool flagDelete_2 = bus.Delete_ChuanDauRaMonHoc(getId, getCDR_NoiDung);

                        if (flagDelete_2 == true)
                        {
                            mtmhlist[3].Remove(mtmhlist[3][lstChuanDauRa.SelectedIndex - 1]);

                            //bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
                            //                nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                            //                lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                            //                lstKHKT, wbYeuCauMH, lstKHGDCT);

                            bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);

                            updateSTTChuanDauRaMonHoc();

                            // load lai list MT HDGD

                        }
                    }
                    else
                        allowToDelete_2 = false;
                }
            }

            if (mt1 != null && mt2 != null)
            {
                DialogResult a = MessageBox.Show("CĐR môn học này đang có liên kết với CĐR CTĐT và HĐGD-PPĐG, bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    // Delete MT2CDR
                    bool flagDelete_2 = bus.Delete_MaTran_HDGD(mt2.ChuanDauRaMonHoc_Id.Value);

                    // Delete MT HDGD
                    bool flagDelete_1 = bus.Delete_MaTran_2CDR(getId, mt1.CDRMH_Id);

                    if (flagDelete_2 == true && flagDelete_1 == true)
                    {
                        allowToDelete_1 = true;
                        allowToDelete_2 = true;

                        bool flagDelete_3 = bus.Delete_ChuanDauRaMonHoc(getId, getCDR_NoiDung);

                        if (flagDelete_3 == true)
                        {
                            mtmhlist[3].Remove(mtmhlist[3][lstChuanDauRa.SelectedIndex - 1]);

                            //bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
                            //                nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                            //                lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                            //                lstKHKT, wbYeuCauMH, lstKHGDCT);

                            bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);

                            updateSTTChuanDauRaMonHoc();
                        }
                    }
                    else
                    {
                        allowToDelete_1 = false;
                        allowToDelete_2 = false;
                    }

                }
            }

            if (mt1 == null && mt2 == null)
            {

                mtmhlist[3].Remove(mtmhlist[3][lstChuanDauRa.SelectedIndex - 1]);

                bool flag = bus.Delete_ChuanDauRaMonHoc(getId, getCDR_NoiDung);
                if (flag == true)
                {
                    //bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
                    //                nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                    //                lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                    //                lstKHKT, wbYeuCauMH, lstKHGDCT);

                    bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);

                    updateSTTChuanDauRaMonHoc();
                }
                else
                {
                    //confirm xóa

                }
            }
        }

        //CHUAN DAU RA MON HOC LIST
        //load dữ liệu item dc chọn trong view
        string getCDR_NoiDung = "";
        ChuanDauRaMonHoc cdr;
        private void lstChuanDauRa_DoubleClick(object sender, EventArgs e)
        {
            if (lstChuanDauRa.SelectedItems.Count == 1)
            {
                if ((lstChuanDauRa.SelectedItem.ToString() != "+ Chuẩn đầu ra môn học: "))
                {
                    btnCDR_Sua.Visible = true;
                    btnCDR_Huy.Visible = true;
                    btnCDR_Them.Text = "Xóa";

                    txtChuanDauRaMonHoc_NoiDung.Text = lstChuanDauRa.SelectedItem.ToString().Replace("\n         ", "");

                    if (txtChuanDauRaMonHoc_NoiDung.Text.Substring(3, 1) == " ")
                    {
                        txtChuanDauRaMonHoc_NoiDung.Text = txtChuanDauRaMonHoc_NoiDung.Text.Substring(4, txtChuanDauRaMonHoc_NoiDung.Text.Length - 4);

                        getCDR_NoiDung = txtChuanDauRaMonHoc_NoiDung.Text;
                        cdr = model.ChuanDauRaMonHocs.FirstOrDefault(x => x.DeCuongChiTiet_Id == getId && x.NoiDung == getCDR_NoiDung.Trim());
                    }
                    else
                    {
                        txtChuanDauRaMonHoc_NoiDung.Text = txtChuanDauRaMonHoc_NoiDung.Text.Substring(5, txtChuanDauRaMonHoc_NoiDung.Text.Length - 5);
                        getCDR_NoiDung = txtChuanDauRaMonHoc_NoiDung.Text;
                    }

                    itemcontent = txtChuanDauRaMonHoc_NoiDung.Text.Trim();
                }

            }
        }

        //CHUAN DAU RA MON HOC LIST
        //Thuật toán sửa item trong view
        private void editItem(string item)
        {
            mtmhlist[3][lstChuanDauRa.SelectedIndex - 1] = item.Trim();

            int stt = cdr.STT.Value;
            bool flag = bus.Update_ChuanDauRaMonHoc(getId, stt, item.Trim());
            if (flag == true)
            {
                //bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG, wbThoiGianHoc,
                //                nbrSoTinChi, txtTrinhDo, wbPhanbothoigian, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                //                lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                //                lstKHKT, wbYeuCauMH, lstKHGDCT);

                bus.LoadDCCT(getId, getCTDT_ID, txtTenChuongTrinh, txtTenTiengAnh, txtMaHocPhan, cboKhoiKienThuc_1, cboKhoiKienThuc_2, cboKhoiKienThuc_3, txtGVPTMH, txtDCCQ, txtDCLH, txtEmail, txtGVTG,
                         nbrSoTinChi, txtTrinhDo, lstHocPhanTruoc, lstMucTieuMonHoc, lstChuanDauRa, cboMaTran_ChuanDauRaMonHoc,
                         lstMaTran_ChuanDauRaCTDT, txtMoTaVanTat, cboMaTranCDRvsHD_ChuanDauRa, lstMaTranCDRvsHD, lstTaiLieu, lstPPDanhGiaKQHT,
                         lstKHKT, lstKHGDCT);
            }
            else MessageBox.Show("Cập nhật chuẩn đầu ra xuống database thất bại");
        }

        private void btnCDR_Sua_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtChuanDauRaMonHoc_NoiDung.Text != "")
                {
                    //Chạy thuật toán edit
                    editItem(txtChuanDauRaMonHoc_NoiDung.Text);

                    //xóa content
                    txtChuanDauRaMonHoc_NoiDung.Text = "";

                    //vẽ lại view
                    lstChuanDauRa.Items.Clear();
                    showChuanDauRaMonHoc();

                    //visible 2 nút sửa, hủy           
                    btnCDR_Sua.Visible = false;
                    btnCDR_Huy.Visible = false;
                    btnCDR_Them.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã sửa đối tượng thành công");
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }
        }

        public void updateSTTChuanDauRaMonHoc()
        {
            DBEntities model = new DBEntities();
            List<ChuanDauRaMonHoc> cdr = model.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == getId).ToList();
            int stt = 0;
            foreach (var i in cdr)
            {
                stt++;
                bool flag_UpdateSTT = bus.UpdateSTT_ChuanDauRaMonHoc(getId, stt, i.NoiDung);
                if (flag_UpdateSTT == false) MessageBox.Show("Cập nhật stt thất bại");
            }
        }
        #endregion

        #region TAI LIEU PHUC VU MON HOC LIST
        //TAI LIEU PHUC VU MON HOC LIST
        // NUT NHAP
        // NUT XOA
        private void btnTailLieu_Them_Click(object sender, EventArgs e)
        {
            //kiem tra chức năng
            if (btnTailLieu_Them.Text == ">>>")
            {
                //làm sạch view
                lstTaiLieu.Items.Clear();
                // lấy, kiểm tra dữ liệu
                string lv = cboTaiLieu_Loai.Text;

                if (lv != "")
                {
                    if (txtTaiLieu_NoiDung.Text != "")
                    {
                        if (lv == "Sách/Giáo trình chính")
                        {
                            bool checkDup = false;

                            string add = txtTaiLieu_NoiDung.Text.Trim();

                            for (int i = 0; i < taiLieuList[0].Count; i++)
                            {
                                if (taiLieuList[0][i] == add)
                                {
                                    checkDup = true;
                                    break;
                                }
                            }

                            if (checkDup == false)
                            {
                                taiLieuList[0].Add(add);

                                double stt = 0;
                                if (taiLieuList[0].Count == 0)
                                    stt = stt + 1.0;
                                else
                                    stt = 1 + taiLieuList[0].Count * 0.1;

                                bool flagKT = bus.Add_TaiLieu(getId, lv, add, stt);

                                if (flagKT == false)
                                {
                                    MessageBox.Show("Thêm mục tiêu vào CSDL thất bại");
                                    taiLieuList[0].Remove(add);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Trùng nội dung");
                            }

                        }
                        if (lv == "Sách/Giáo trình tham khảo")
                        {
                            bool checkDup = false;

                            for (int i = 0; i < taiLieuList[1].Count; i++)
                            {
                                if (taiLieuList[1][i] == txtTaiLieu_NoiDung.Text.Trim())
                                {
                                    checkDup = true;
                                    break;
                                }
                            }

                            if (checkDup == false)
                            {
                                taiLieuList[1].Add(txtTaiLieu_NoiDung.Text.Trim());

                                double stt = 0;
                                if (taiLieuList[1].Count == 0)
                                    stt = stt + 2.0;
                                else
                                    stt = 2 + taiLieuList[1].Count * 0.1;

                                bool flagKT = bus.Add_TaiLieu(getId, lv, txtTaiLieu_NoiDung.Text.Trim(), stt);

                                if (flagKT == false)
                                {
                                    MessageBox.Show("Thêm mục tiêu vào CSDL thất bại");
                                    taiLieuList[1].Remove(txtTaiLieu_NoiDung.Text.Trim());
                                }
                            }
                            else
                            {
                                MessageBox.Show("Trùng nội dung");
                            }

                        }
                        if (lv == "Tư liệu trực tuyến")
                        {
                            bool checkDup = false;

                            for (int i = 0; i < taiLieuList[2].Count; i++)
                            {
                                if (taiLieuList[2][i] == txtTaiLieu_NoiDung.Text.Trim())
                                {
                                    checkDup = true;
                                    break;
                                }
                            }

                            if (checkDup == false)
                            {
                                taiLieuList[2].Add(txtTaiLieu_NoiDung.Text.Trim());

                                double stt = 0;
                                if (taiLieuList[2].Count == 0)
                                    stt = stt + 3.0;
                                else
                                    stt = 3 + taiLieuList[2].Count * 0.1;

                                bool flagKT = bus.Add_TaiLieu(getId, lv, txtTaiLieu_NoiDung.Text.Trim(), stt);

                                if (flagKT == false)
                                {
                                    MessageBox.Show("Thêm mục tiêu vào CSDL thất bại");
                                    taiLieuList[2].Remove(txtTaiLieu_NoiDung.Text.Trim());
                                }
                            }
                            else
                            {
                                MessageBox.Show("Trùng nội dung");
                            }
                        }
                        //show list view 
                        showTaiLieu();
                        txtTaiLieu_NoiDung.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Hãy điền nội dung");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn mục cần điền");
                }
            }
            //Xóa item
            if (btnTailLieu_Them.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {

                    //thuc hien xoa
                    bool flag = bus.Delete_TaiLieu(getTL_ID);
                    if (flag == true)
                    {
                        deleteTaiLieuItem(itemcontent, itemposition);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }

                    //vẽ lại view
                    lstTaiLieu.Items.Clear();
                    showTaiLieu();

                    //làm sạch content
                    txtTaiLieu_NoiDung.Text = "";

                    //visible 2 nút sửa, hủy
                    btnTaiLieu_Sua.Visible = false;
                    btnTaiLieu_Huy.Visible = false;
                    btnTailLieu_Them.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã xóa đối tượng thành công");
                }


            }
        }

        //TAI LIEU LIST
        //Hàm vẽ list view
        private void showTaiLieu()
        {
            lstTaiLieu.Items.Add("+ Sách/Giáo trình chính: ");
            for (int i = 0; i < taiLieuList[0].Count; i++)
            {
                lstTaiLieu.Items.Add("\n         1." + (i + 1) + "  " + taiLieuList[0][i]);
            }
            lstTaiLieu.Items.Add("+ Sách/Giáo trình tham khảo: ");
            for (int i = 0; i < taiLieuList[1].Count; i++)
            {
                lstTaiLieu.Items.Add("\n         2." + (i + 1) + "  " + taiLieuList[1][i]);
            }

            lstTaiLieu.Items.Add("+ Tư liệu trực tuyến: ");
            for (int i = 0; i < taiLieuList[2].Count; i++)
            {
                lstTaiLieu.Items.Add("\n         3." + (i + 1) + "  " + taiLieuList[2][i]);
            }
        }

        //TAI LIEU LIST
        //load dữ liệu item dc chọn trong view

        int getTL_ID = 0;

        private void lstTaiLieu_DoubleClick(object sender, EventArgs e)
        {
            if (lstTaiLieu.SelectedItems.Count == 1)
            {
                if ((lstTaiLieu.SelectedItem.ToString() != "+ Sách/Giáo trình chính: ") && (lstTaiLieu.SelectedItem.ToString() != "+ Sách/Giáo trình tham khảo: ") && (lstTaiLieu.SelectedItem.ToString() != "+ Tư liệu trực tuyến: "))
                {
                    btnTaiLieu_Sua.Visible = true;
                    btnTaiLieu_Huy.Visible = true;
                    btnTailLieu_Them.Text = "Xóa";

                    itemposition = lstTaiLieu.SelectedIndex;

                    int s1 = 0;
                    int s2 = taiLieuList[0].Count + 1;
                    int s3 = s2 + taiLieuList[1].Count + 1;


                    int[] arr = new[] { s1, s2, s3 };

                    int selectindex = 0;

                    for (int i = 0; i < 2; i++)
                    {
                        if ((itemposition > arr[i]) && (itemposition < arr[i + 1]))
                        {
                            if (i == 0)
                            {
                                selectindex = 0;
                                txtTaiLieu_NoiDung.Text = lstTaiLieu.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtTaiLieu_NoiDung.Text.Substring(3, 1) == " ")
                                {
                                    txtTaiLieu_NoiDung.Text = txtTaiLieu_NoiDung.Text.Substring(5, txtTaiLieu_NoiDung.Text.Length - 5);
                                }
                                else
                                {
                                    txtTaiLieu_NoiDung.Text = txtTaiLieu_NoiDung.Text.Substring(6, txtTaiLieu_NoiDung.Text.Length - 6);
                                }
                                break;
                            }
                            if (i == 1)
                            {
                                selectindex = 1;
                                txtTaiLieu_NoiDung.Text = lstTaiLieu.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtTaiLieu_NoiDung.Text.Substring(3, 1) == " ")
                                {
                                    txtTaiLieu_NoiDung.Text = txtTaiLieu_NoiDung.Text.Substring(5, txtTaiLieu_NoiDung.Text.Length - 5);
                                }
                                else
                                {
                                    txtTaiLieu_NoiDung.Text = txtTaiLieu_NoiDung.Text.Substring(6, txtTaiLieu_NoiDung.Text.Length - 6);
                                }
                                break;
                            }
                        }
                        else
                        {
                            if (i == 1)
                            {
                                selectindex = 2;
                                txtTaiLieu_NoiDung.Text = lstTaiLieu.SelectedItem.ToString().Replace("\n         ", "");
                                if (txtTaiLieu_NoiDung.Text.Substring(3, 1) == " ")
                                {
                                    txtTaiLieu_NoiDung.Text = txtTaiLieu_NoiDung.Text.Substring(5, txtTaiLieu_NoiDung.Text.Length - 5);
                                }
                                else
                                {
                                    txtTaiLieu_NoiDung.Text = txtTaiLieu_NoiDung.Text.Substring(6, txtTaiLieu_NoiDung.Text.Length - 6);
                                }
                            }
                        }
                    }

                    itemcontent = txtTaiLieu_NoiDung.Text.Trim();

                    cboTaiLieu_Loai.SelectedIndex = selectindex;

                    DBEntities model = new DBEntities();

                    int tl_Id = model.TaiLieuMonHocs.FirstOrDefault(x => x.Loai == cboTaiLieu_Loai.SelectedItem && x.NoiDung == itemcontent && x.DeCuongChiTiet_Id==getId).Id;

                    getTL_ID = tl_Id;
                }

            }
        }

        //TAI LIEU LIST
        //Nút hủy edit/xóa trong view
        private void btnTaiLieu_Huy_Click(object sender, EventArgs e)
        {
            btnTailLieu_Them.Text = ">>>";
            btnTaiLieu_Sua.Visible = false;
            btnTaiLieu_Huy.Visible = false;

            txtTaiLieu_NoiDung.Text = "";
        }

        //TAI LIEU LIST
        //Thuật toán xóa
        private void deleteTaiLieuItem(string item, int local)
        {
            int s1 = 0;
            int s2 = taiLieuList[0].Count + 1;
            int s3 = s2 + taiLieuList[1].Count + 1;

            int[] arr = new[] { s1, s2, s3 };

            for (int i = 0; i < 2; i++)
            {
                if ((local > arr[i]) && (local < arr[i + 1]))
                {
                    if (i == 0)
                    {
                        taiLieuList[0].Remove(item);
                        break;
                    }
                    if (i == 1)
                    {
                        taiLieuList[1].Remove(item);
                        break;
                    }

                }
                else
                {
                    if (i == 1)
                    {
                        taiLieuList[2].Remove(item);
                    }
                }
            }

        }

        //TAI LIEU LIST
        //Thuật toán sửa item trong view
        private void editTaiLieuItem(string item, int position, ComboBox cbo)
        {

            // tìm ra list cũ
            int s1 = 0;
            int s2 = taiLieuList[0].Count + 1;
            int s3 = s2 + taiLieuList[1].Count + 1;

            int[] arr = new[] { s1, s2, s3 };

            //List<List<string>> sum_arr = new List<List<string>> { mtc, mtct_pc, mtct_kt, mtct_kn, mtct_td };

            List<string> work = new List<string>();

            int editint = 0;

            for (int g = 0; g < 2; g++)
            {
                if ((position > arr[g]) && (position < arr[g + 1]))
                {
                    work = taiLieuList[g];
                    editint = g;
                    break;
                }
                else
                {
                    if (g == 2)
                    {
                        work = taiLieuList[g + 1];
                        editint = g + 1;
                    }
                }
            }

            //Trường hợp edit list cũ


            if ((cbo.SelectedIndex == editint) && (editint == 0))
            {
                work[position - 1] = txtTaiLieu_NoiDung.Text.Trim();
            }
            else
            {
                if ((cbo.SelectedIndex == editint) && (editint == 1))
                {
                    work[position - (2 + taiLieuList[0].Count)] = txtTaiLieu_NoiDung.Text.Trim();
                }
                else
                {
                    if ((cbo.SelectedIndex == editint) && (editint == 2))
                    {
                        work[position - (3 + taiLieuList[0].Count + taiLieuList[1].Count)] = txtTaiLieu_NoiDung.Text.Trim();
                    }
                }

            }

            //Trường hợp edit list khác
            if (cbo.SelectedIndex != editint)
            {
                deleteTaiLieuItem(itemcontent, itemposition);
                taiLieuList[cbo.SelectedIndex].Add(txtTaiLieu_NoiDung.Text.Trim());

            }
        }

        //TAI LIEU LIST
        //Nút sửa
        private void btnTaiLieu_Sua_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtTaiLieu_NoiDung.Text != "")
                {
                    //Xóa sach item trong view
                    lstTaiLieu.Items.Clear();

                    //Chạy thuật toán edit
                    bool flag = bus.Update_TaiLieu(getTL_ID, txtTaiLieu_NoiDung.Text.Trim());
                    if (flag == true)
                    {
                        editTaiLieuItem(itemcontent, itemposition, cboTaiLieu_Loai);
                    }

                    //xóa content
                    txtTaiLieu_NoiDung.Text = "";

                    //vẽ lại view
                    showTaiLieu();

                    //visible 2 nút sửa, hủy           
                    btnTaiLieu_Sua.Visible = false;
                    btnTaiLieu_Huy.Visible = false;
                    btnTailLieu_Them.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã sửa đối tượng thành công");
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }



        }
        #endregion

        #region MA TRAN TICH HOP GIUA CHUAN DAU RA - HD GIANG DAY VA PP DANH GIA LIST
        // MA TRAN TICH HOP GIUA CHUAN DAU RA - HD GIANG DAY VA PP DANH GIA LIST
        // NUT NHAP
        // NUT XOA
        private void btnMatranCDRvsHD_Them_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            //kiem tra chức năng
            if (btnMatranCDRvsHD_Them.Text == ">>>")
            {
                //làm sạch view
                lstMaTranCDRvsHD.Items.Clear();

                // lấy, kiểm tra dữ liệu
                string lv = cboMaTranCDRvsHD_ChuanDauRa.Text;
                int lv_Id = int.Parse(cboMaTranCDRvsHD_ChuanDauRa.SelectedValue.ToString());

                string loai = cboMatranCDRvsHD_Loai.Text;

                if (lv != "" && loai != "")
                {
                    if (txtMaTranCDRvsHD_NoiDung.Text != "")
                    {
                        MaTran_CDR_HD_NoiDungList add = new MaTran_CDR_HD_NoiDungList(lv, loai, txtMaTranCDRvsHD_NoiDung.Text);
                        CDR_noidung_lst.Add(add);

                        //List<MaTran_ChuanDauRaMH_HDGDPPDG> mt = model.MaTran_ChuanDauRaMH_HDGDPPDG.Where(x => x.ChuanDauRaMonHoc_Id == lv_Id).ToList();

                        bool flag = bus.Add_MaTran_CDR_HD(lv_Id, loai, txtMaTranCDRvsHD_NoiDung.Text);
                        if (flag == false) MessageBox.Show("Thêm dữ liệu vào CSDL thất bại");

                        //show list view 
                        showMaTran_CDR_HD();
                        txtMaTranCDRvsHD_NoiDung.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Hãy điền nội dung");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn mục cần điền");
                }
            }
            //Xóa item
            if (btnMatranCDRvsHD_Them.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    int delposition = lstMaTranCDRvsHD.SelectedIndex;
                    //thuc hien xoa
                    string delloai = "";
                    string dellv = "";
                    int delloaiposition = 0;

                    #region Lay dc cai cdr
                    for (int i = delposition - 1; i >= 0; i--)
                    {
                        if (lstMaTranCDRvsHD.Items[i].ToString().Substring(0, 6) != "\n     ") // check 
                        {
                            delloai = lstMaTranCDRvsHD.Items[i].ToString();
                            delloaiposition = i;
                            break;
                        }
                    }
                    for (int i = delloaiposition; i >= 0; i--)
                    {
                        if (lstMaTranCDRvsHD.Items[i].ToString().Substring(0, 6) != "\n     ")
                        {
                            if ((lstMaTranCDRvsHD.Items[i].ToString() != "    + Các hoạt động dạy và học: ")
                                && (lstMaTranCDRvsHD.Items[i].ToString() != "    + Phương pháp kiểm tra, đánh giá sinh viên: "))
                            {
                                dellv = lstMaTranCDRvsHD.Items[i].ToString();
                                break;
                            }
                        }
                    }
                    #endregion

                    bool flagDelete = bus.Delete_MaTranCDRHD(getMT_ID);
                    if (flagDelete == true)
                    {
                        string dell1 = delloai.Replace("    + ", "").Replace(": ", "");
                        string dell2 = dellv.Replace("+ Chuẩn đầu ra", "").Replace(": ", "");
                        MaTran_CDR_HD_NoiDungList dell = CDR_noidung_lst.Single(x => x.chuandaura == dell2 && x.loai == dell1 && x.noiDung == txtMaTranCDRvsHD_NoiDung.Text);
                        CDR_noidung_lst.Remove(dell);
                        //vẽ lại view
                        lstMaTranCDRvsHD.Items.Clear();
                        showMaTran_CDR_HD();

                        //làm sạch content
                        txtMaTranCDRvsHD_NoiDung.Text = "";

                        //visible 2 nút sửa, hủy
                        btnMatranCDRvsHD_Sua.Visible = false;
                        btnMatranCDRvsHD_Huy.Visible = false;
                        btnMatranCDRvsHD_Them.Text = ">>>";

                        //thông báo
                        MessageBox.Show("Đã xóa đối tượng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Đã xóa đối tượng thất bại");
                    }

                }
            }
        }

        //MA TRAN TICH HOP GIUA CHUAN DAU RA - HD GIANG DAY VA PP DANH GIA LIST
        //Hàm vẽ list view
        private void showMaTran_CDR_HD()
        {
            foreach (string a in mtmhlist[3])
            {
                lstMaTranCDRvsHD.Items.Add("+ Chuẩn đầu ra: " + a);
                try
                {
                    List<MaTran_CDR_HD_NoiDungList> alst = CDR_noidung_lst.Where(x => x.chuandaura == a.ToString() && x.loai == "Các hoạt động dạy và học").ToList();
                    lstMaTranCDRvsHD.Items.Add("    + Các hoạt động dạy và học: ");
                    foreach (MaTran_CDR_HD_NoiDungList aa in alst)
                    {
                        lstMaTranCDRvsHD.Items.Add("\n         " + "  " + aa.noiDung);
                    }

                }
                catch
                {
                    lstMaTranCDRvsHD.Items.Add("    + Các hoạt động dạy và học: ");
                }
                try
                {
                    List<MaTran_CDR_HD_NoiDungList> blst = CDR_noidung_lst.Where(x => x.chuandaura == a.ToString() && x.loai == "Phương pháp kiểm tra, đánh giá sinh viên").ToList();
                    lstMaTranCDRvsHD.Items.Add("    + Phương pháp kiểm tra, đánh giá sinh viên: ");
                    foreach (MaTran_CDR_HD_NoiDungList aa in blst)
                    {
                        lstMaTranCDRvsHD.Items.Add("\n         " + "  " + aa.noiDung);
                    }
                }
                catch
                {
                    lstMaTranCDRvsHD.Items.Add("    + Phương pháp kiểm tra, đánh giá sinh viên: ");
                }

                lstMaTranCDRvsHD.Items.Add("\n");
            }
        }

        ////MA TRAN TICH HOP GIUA CHUAN DAU RA - HD GIANG DAY VA PP DANH GIA LIST
        ////load dữ liệu item dc chọn trong view

        int getMT_ID = 0;

        private void lstMaTranCDRvsHD_DoubleClick(object sender, EventArgs e)
        {
            if (lstMaTranCDRvsHD.SelectedItems.Count == 1)
            {
                if (lstMaTranCDRvsHD.SelectedItem.ToString() != "\n")
                {
                    Point point = btnMatranCDRvsHD_Them.Location;

                    btnMatranCDRvsHD_Sua.Location = new Point(point.X, point.Y - 80);
                    btnMatranCDRvsHD_Sua.Visible = true;

                    btnMatranCDRvsHD_Huy.Location = new Point(point.X, point.Y + 80);
                    btnMatranCDRvsHD_Huy.Visible = true;

                    btnMatranCDRvsHD_Them.Text = "Xóa";

                    if ((lstMaTranCDRvsHD.SelectedItem.ToString().Substring(0, 6) == "\n     "))
                    {
                        txtMaTranCDRvsHD_NoiDung.Text = lstMaTranCDRvsHD.SelectedItem.ToString().Replace("\n           ", "");
                        string delloai = "";
                        string dellv = "";
                        int delloaiposition = 0;
                        int dellvposition = 0;

                        for (int i = lstMaTranCDRvsHD.SelectedIndex - 1; i >= 0; i--)
                        {
                            if (lstMaTranCDRvsHD.Items[i].ToString().Substring(0, 6) != "\n     ")
                            {
                                delloai = lstMaTranCDRvsHD.Items[i].ToString();
                                delloaiposition = i;
                                break;
                            }
                        }
                        for (int i = delloaiposition; i >= 0; i--)
                        {
                            if (lstMaTranCDRvsHD.Items[i].ToString().Substring(0, 6) != "\n     ")
                            {
                                if ((lstMaTranCDRvsHD.Items[i].ToString() != "    + Các hoạt động dạy và học: ")
                                    && (lstMaTranCDRvsHD.Items[i].ToString() != "    + Phương pháp kiểm tra, đánh giá sinh viên: "))
                                {
                                    dellv = lstMaTranCDRvsHD.Items[i].ToString();
                                    dellvposition = i;
                                    break;
                                }
                            }
                        }
                        cboMaTranCDRvsHD_ChuanDauRa.Text = dellv.Replace("+ Chuẩn đầu ra", "").Replace(": ", "");
                        cboMatranCDRvsHD_Loai.SelectedItem = delloai.Replace("    + ", "").Replace(": ", "");
                        //btnMatranCDRvsHD_Them.Text = "Xóa";

                        oldcboCDR = cboMaTranCDRvsHD_ChuanDauRa.SelectedIndex;
                        oldcboCDRstr = dellv.Replace("+ Chuẩn đầu ra", "").Replace(": ", "");
                        oldloai = delloai.Replace("    + ", "").Replace(": ", "");
                        oldnd = txtMaTranCDRvsHD_NoiDung.Text;

                        cboMaTranCDRvsHD_ChuanDauRa.Enabled = false;
                        cboMatranCDRvsHD_Loai.Enabled = false;

                        DBEntities model = new DBEntities();

                        int getCDRMH_Id = model.ChuanDauRaMonHocs.FirstOrDefault(x => x.NoiDung == cboMaTranCDRvsHD_ChuanDauRa.Text).Id;

                        int mt_Id = model.MaTran_ChuanDauRaMH_HDGDPPDG.FirstOrDefault(x => x.NoiDung == oldnd && x.Loai == cboMatranCDRvsHD_Loai.SelectedItem && x.ChuanDauRaMonHoc_Id == getCDRMH_Id).Id;
                        getMT_ID = mt_Id;
                    }
                }
            }
        }

        int test3 = 0;
        private void cboMaTranCDRvsHD_ChuanDauRa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int test = cboMaTranCDRvsHD_ChuanDauRa.SelectedIndex;
            test3 = test;
        }

        ////MA TRAN TICH HOP GIUA CHUAN DAU RA - HD GIANG DAY VA PP DANH GIA LIST
        ////Nút hủy edit/xóa trong view
        private void btnMatranCDRvsHD_Huy_Click(object sender, EventArgs e)
        {
            btnMatranCDRvsHD_Them.Text = ">>>";
            btnMatranCDRvsHD_Sua.Visible = false;
            btnMatranCDRvsHD_Huy.Visible = false;

            txtChuanDauRaMonHoc_NoiDung.Text = "";
        }

        ////MA TRAN TICH HOP GIUA CHUAN DAU RA - HD GIANG DAY VA PP DANH GIA LIST
        ////Nút sửa
        private void btnMatranCDRvsHD_Sua_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtMaTranCDRvsHD_NoiDung.Text != "")
                {
                    //Xóa sach item trong view
                    lstMaTranCDRvsHD.Items.Clear();

                    //Chạy thuật toán edit

                    bool flagUpdate = bus.Update_MaTranCDRHD(getMT_ID, txtMaTranCDRvsHD_NoiDung.Text);

                    if (flagUpdate == false)
                    {
                        MessageBox.Show("Cập nhật vào CSDL thất bại");
                    }

                    MaTran_CDR_HD_NoiDungList newedit = CDR_noidung_lst.Single(x => x.chuandaura == oldcboCDRstr && x.loai == oldloai && x.noiDung == oldnd);
                    newedit.chuandaura = cboMaTranCDRvsHD_ChuanDauRa.Text;
                    newedit.loai = cboMatranCDRvsHD_Loai.Text;
                    newedit.noiDung = txtMaTranCDRvsHD_NoiDung.Text;

                    //xóa content
                    txtMaTranCDRvsHD_NoiDung.Text = "";

                    //vẽ lại view
                    showMaTran_CDR_HD();

                    //visible 2 nút sửa, hủy           
                    btnMatranCDRvsHD_Sua.Visible = false;
                    btnMatranCDRvsHD_Huy.Visible = false;
                    btnMatranCDRvsHD_Them.Text = ">>>";

                    //thông báo
                    MessageBox.Show("Đã sửa đối tượng thành công");
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }
        }
        #endregion

        #region PHUONG PHAP DANH GIA KET QUA HOC TAP LIST
        ////TAI LIEU PHUC VU MON HOC LIST
        //// NUT NHAP
        //// NUT XOA
        private void btnPPDG_Them_Click(object sender, EventArgs e)
        {
            //kiem tra chức năng
            if (btnPPDG_Them.Text == ">>>")
            {
                //làm sạch view
                lstPPDanhGiaKQHT.Items.Clear();

                // lấy, kiểm tra dữ liệu
                string lv = cboPPDG_NoiDungDG.Text;
                string soLanDG = txtPPDG_SoLanDG.Text;
                int trongSo = int.Parse(txtPPDG_TrongSo.Text);
                string hinhThuc = txtPPDG_HinhThucDanhGia.Text;

                if (lv != "")
                {
                    if (txtPPDG_SoLanDG.Text != "" && txtPPDG_HinhThucDanhGia.Text != "" && txtPPDG_TrongSo.Text != null)
                    {
                        bool flag = bus.Add_PPGD(getId, lv, soLanDG, trongSo, hinhThuc);

                        if (flag == true)
                        {
                            PhuongPhapDanhGiaKQHT_List ppdg = new PhuongPhapDanhGiaKQHT_List(lv, soLanDG, trongSo, hinhThuc);
                            PPDG_Lst.Add(ppdg);

                            //show list view 
                            showPPDG();
                            cboPPDG_NoiDungDG.Items.Remove(cboPPDG_NoiDungDG.SelectedItem);
                            txtPPDG_SoLanDG.Text = "";
                            txtPPDG_TrongSo.Value = 0;
                            txtPPDG_HinhThucDanhGia.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Hãy điền nội dung");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn mục cần điền");
                }
            }
            //Xóa item
            if (btnPPDG_Them.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    DBEntities model = new DBEntities();

                    int ppID = model.PPDanhGiaKQHTs.FirstOrDefault(x => x.DeCuongChiTiet_Id == getId && x.LoaiNoiDung == cboPPDG_NoiDungDG.Text && x.SoLanDanhGia == soLan && x.TrongSo
                        == trongSo && x.HinhThucDanhGia == hinhThucDG).Id;

                    bool flag = bus.Delete_PPDG(ppID);

                    if (flag == true)
                    {
                        //thuc hien xoa
                        PhuongPhapDanhGiaKQHT_List ppdg = PPDG_Lst.Single(x => x.noiDung == noiDung);
                        PPDG_Lst.Remove(ppdg);

                        cboPPDG_NoiDungDG.Items.Clear();
                        foreach (var item in ppgd_AddCBox)
                        {
                            try
                            {
                                List<PhuongPhapDanhGiaKQHT_List> findlst = PPDG_Lst.Where(x => x.noiDung == item).ToList();

                                if (findlst.Count == 0)
                                {
                                    cboPPDG_NoiDungDG.Items.Add(item);
                                }
                            }
                            catch
                            {
                                cboPPDG_NoiDungDG.Items.Add(item);
                            }
                        }

                        //vẽ lại view
                        lstPPDanhGiaKQHT.Items.Clear();
                        showPPDG();

                        //làm sạch content
                        //cboPPDG_NoiDungDG
                        txtPPDG_SoLanDG.Text = "";
                        txtPPDG_TrongSo.Value = 1;
                        txtPPDG_HinhThucDanhGia.Text = "";

                        //visible 2 nút sửa, hủy
                        btnPPDG_Sua.Visible = false;
                        btnPPDG_Huy.Visible = false;
                        btnPPDG_Them.Text = ">>>";

                        //thông báo
                        MessageBox.Show("Đã xóa đối tượng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa đối tượng thất bại");
                    }
                    
                }
            }
        }

        ////TAI LIEU LIST
        ////Hàm vẽ list view
        private void showPPDG()
        {
            foreach (PhuongPhapDanhGiaKQHT_List ppdg in PPDG_Lst)
            {
                lstPPDanhGiaKQHT.Items.Add("+ Nội dung đánh giá: " + ppdg.noiDung);
                lstPPDanhGiaKQHT.Items.Add("    + Số lần đánh giá: " + ppdg.soLanDanhGia);
                lstPPDanhGiaKQHT.Items.Add("    + Trọng số: " + ppdg.trongSo);
                lstPPDanhGiaKQHT.Items.Add("    + Hình thức đánh giá: " + ppdg.hinhThucDanhGia);
                lstPPDanhGiaKQHT.Items.Add("\n");
            }
        }

        ////TAI LIEU LIST
        ////load dữ liệu item dc chọn trong view
        string noiDung = "";
        string soLan = "";
        int trongSo = 0;
        string hinhThucDG = "";
        private void lstPPDanhGiaKQHT_DoubleClick(object sender, EventArgs e)
        {
            if (lstPPDanhGiaKQHT.SelectedItems.Count == 1)
            {
                if (lstPPDanhGiaKQHT.SelectedItem.ToString() != "\n")
                {
                    try
                    {
                        if ((lstPPDanhGiaKQHT.SelectedItem.ToString().Substring(2, 19) == "Nội dung đánh giá: "))
                        {
                            int length = lstPPDanhGiaKQHT.SelectedItem.ToString().Length;
                            noiDung = lstPPDanhGiaKQHT.SelectedItem.ToString().Substring(21, length - 21);
                        }
                    }
                    catch
                    {

                    }

                    cboPPDG_NoiDungDG.Items.Clear();

                    foreach (PhuongPhapDanhGiaKQHT_List ppdg in PPDG_Lst)
                    {
                        if (ppdg.noiDung == noiDung)
                        {
                            cboPPDG_NoiDungDG.Items.Add(noiDung);
                            cboPPDG_NoiDungDG.Text = noiDung;
                            txtPPDG_SoLanDG.Text = ppdg.soLanDanhGia;
                            txtPPDG_TrongSo.Value = ppdg.trongSo;
                            txtPPDG_HinhThucDanhGia.Text = ppdg.hinhThucDanhGia;
                        }
                    }

                    soLan = txtPPDG_SoLanDG.Text;
                    trongSo = int.Parse(txtPPDG_TrongSo.Value.ToString());
                    hinhThucDG = txtPPDG_HinhThucDanhGia.Text;

                    btnPPDG_Sua.Visible = true;
                    btnPPDG_Them.Text = "Xóa";
                    btnPPDG_Huy.Visible = true;
                }
            }
        }

        ////TAI LIEU LIST
        ////Nút hủy edit/xóa trong view
        private void btnPPDG_Sua_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtPPDG_SoLanDG.Text != "" && txtPPDG_HinhThucDanhGia.Text != "" && txtPPDG_TrongSo.Text != null)
                {
                    //Xóa sach item trong view
                    lstPPDanhGiaKQHT.Items.Clear();

                    //Chạy thuật toán edit

                    DBEntities model = new DBEntities();

                    int ppID = model.PPDanhGiaKQHTs.FirstOrDefault(x => x.DeCuongChiTiet_Id == getId && x.LoaiNoiDung == cboPPDG_NoiDungDG.Text && x.SoLanDanhGia == soLan && x.TrongSo
                        == trongSo && x.HinhThucDanhGia == hinhThucDG).Id;

                    bool flag = bus.Update_PPDG(ppID, getId, cboPPDG_NoiDungDG.Text, txtPPDG_SoLanDG.Text, int.Parse(txtPPDG_TrongSo.Text), txtPPDG_HinhThucDanhGia.Text);

                    if (flag == true)
                    {
                        PhuongPhapDanhGiaKQHT_List newedit = PPDG_Lst.Single(x => x.noiDung == noiDung);
                        newedit.noiDung = cboPPDG_NoiDungDG.Text;
                        newedit.soLanDanhGia = txtPPDG_SoLanDG.Text;
                        newedit.trongSo = int.Parse(txtPPDG_TrongSo.Text);
                        newedit.hinhThucDanhGia = txtPPDG_HinhThucDanhGia.Text;

                        //xóa content
                        txtPPDG_HinhThucDanhGia.Text = "";
                        txtPPDG_SoLanDG.Text = "";
                        txtPPDG_TrongSo.Value = 1;

                        cboPPDG_NoiDungDG.Items.Clear();

                        foreach (var item in ppgd_AddCBox)
                        {
                            try
                            {
                                List<PhuongPhapDanhGiaKQHT_List> findlst = PPDG_Lst.Where(x => x.noiDung == item).ToList();

                                if (findlst.Count == 0)
                                {
                                    cboPPDG_NoiDungDG.Items.Add(item);
                                }
                            }
                            catch
                            {
                                cboPPDG_NoiDungDG.Items.Add(item);
                            }
                        }

                        //vẽ lại view
                        showPPDG();

                        //visible 2 nút sửa, hủy           
                        btnPPDG_Sua.Visible = false;
                        btnPPDG_Huy.Visible = false;
                        btnPPDG_Them.Text = ">>>";

                        //thông báo
                        MessageBox.Show("Đã sửa đối tượng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa đối tượng thất bại");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }
        }

        private void btnPPDG_Huy_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region KE HOACH KIEM TRA LIST
        ////KE HOACH KIEM TRA LIST
        //// NUT NHAP
        //// NUT XOA
        private void btnKHKT_Them_Click(object sender, EventArgs e)
        {
            bool flag = false;
            //kiem tra chức năng
            if (btnKHKT_Them.Text == ">>>")
            {
                //làm sạch view
                lstKHKT.Items.Clear();

                // lấy, kiểm tra dữ liệu
                string hinhThuc = txtKHKT_HinhThuc.Text;
                string noiDung = txtKHKT_NoiDung.Text;
                string thoiDiem = txtKHKT_ThoiDiem.Text;
                string congCuKiemTra = txtKHKT_CongCuKT.Text;


                if (txtKHKT_HinhThuc.Text != "" && txtKHKT_NoiDung.Text != "" && txtKHKT_ThoiDiem.Text != "" && txtKHKT_CongCuKT.Text != "")
                {
                    flag = khkt_Lst.Any(x => x.noiDung == hinhThuc);

                    if (flag == false)
                    {
                        bool flagAdd = bus.Add_KHKT(getId, hinhThuc, noiDung, thoiDiem, congCuKiemTra);

                        if (flagAdd == true)
                        {
                            KeHoachKiemTra_List khkt = new KeHoachKiemTra_List(hinhThuc, noiDung, thoiDiem, congCuKiemTra);
                            khkt_Lst.Add(khkt);
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                        
                    }
                    else MessageBox.Show("Trùng hình thức kiểm tra");

                    //show list view 
                    showKeHoachKiemTra();

                    txtKHKT_HinhThuc.Text = "";
                    txtKHKT_NoiDung.Text = "";
                    txtKHKT_ThoiDiem.Text = "";
                    txtKHKT_CongCuKT.Text = "";
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }
            }
            //Xóa item
            if (btnKHKT_Them.Text == "Xóa")
            {
                //confirm xóa
                DialogResult a = MessageBox.Show("Bạn có muốn xóa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
                if (a == DialogResult.OK)
                {
                    bool flagDelete = bus.Delete_KHKT(getKH_ID);

                    if (flagDelete == true)
                    {
                        //thuc hien xoa
                        KeHoachKiemTra_List khkt = khkt_Lst.Single(x => x.hinhThuc == hinhThuc);
                        khkt_Lst.Remove(khkt);

                        //vẽ lại view
                        lstKHKT.Items.Clear();
                        showKeHoachKiemTra();

                        //làm sạch content
                        txtKHKT_HinhThuc.Text = "";
                        txtKHKT_NoiDung.Text = "";
                        txtKHKT_ThoiDiem.Text = "";
                        txtKHKT_CongCuKT.Text = "";

                        //visible 2 nút sửa, hủy
                        btnKHKiemTra_Sua.Visible = false;
                        btnKHKiemTra_Huy.Visible = false;
                        btnKHKT_Them.Text = ">>>";

                        //thông báo
                        MessageBox.Show("Đã xóa đối tượng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa đối tượng thất bại");
                    }
                    
                }
            }
        }

        ////TAI LIEU LIST
        ////Hàm vẽ list view
        private void showKeHoachKiemTra()
        {
            foreach (KeHoachKiemTra_List khkt in khkt_Lst)
            {
                lstKHKT.Items.Add("+ Hình thức kiểm tra: " + khkt.hinhThuc);
                lstKHKT.Items.Add("    + Nội dung: " + khkt.noiDung);
                lstKHKT.Items.Add("    + Thời điểm: " + khkt.thoiDiem);
                lstKHKT.Items.Add("    + Công cụ kiểm tra: " + khkt.congCuKiemTra);
                lstKHKT.Items.Add("\n");
            }
        }

        ////TAI LIEU LIST
        ////load dữ liệu item dc chọn trong view
        string hinhThuc = "";
        int getKH_ID=0;
        private void lstKHKT_DoubleClick(object sender, EventArgs e)
        {
            if (lstKHKT.SelectedItems.Count == 1)
            {
                if (lstKHKT.SelectedItem.ToString() != "\n")
                {
                    try
                    {
                        if ((lstKHKT.SelectedItem.ToString().Substring(2, 20) == "Hình thức kiểm tra: "))
                        {
                            int length = lstKHKT.SelectedItem.ToString().Length;
                            hinhThuc = lstKHKT.SelectedItem.ToString().Substring(22, length - 22);
                        }
                    }
                    catch
                    {

                    }

                    foreach (KeHoachKiemTra_List kh in khkt_Lst)
                    {
                        if (kh.hinhThuc == hinhThuc)
                        {
                            txtKHKT_HinhThuc.Text = hinhThuc;
                            txtKHKT_NoiDung.Text = kh.noiDung;
                            txtKHKT_ThoiDiem.Text = kh.thoiDiem;
                            txtKHKT_CongCuKT.Text = kh.congCuKiemTra;
                        }
                    }

                    DBEntities model = new DBEntities();

                    int khID = model.KeHoanKiemTras.FirstOrDefault(x => x.DeCuongChiTiet_Id == getId && x.HinhThuc == txtKHKT_HinhThuc.Text && x.NoiDung == txtKHKT_NoiDung.Text && x.ThoiDiem == txtKHKT_ThoiDiem.Text && x.CongCuKT == txtKHKT_CongCuKT.Text).Id;
                    getKH_ID = khID;

                    Point point = btnKHKT_Them.Location;

                    btnKHKiemTra_Sua.Location = new Point(point.X, point.Y - 80);
                    btnKHKiemTra_Sua.Visible = true;

                    btnKHKT_Them.Text = "Xóa";

                    btnKHKiemTra_Huy.Location = new Point(point.X, point.Y + 80);
                    btnKHKiemTra_Huy.Visible = true;
                }
            }
        }

        private void btnKHKiemTra_Sua_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                if (txtKHKT_HinhThuc.Text != "" && txtKHKT_NoiDung.Text != "" && txtKHKT_ThoiDiem.Text != "" && txtKHKT_CongCuKT.Text != "")
                {
                    //Xóa sach item trong view
                    lstKHKT.Items.Clear();

                    //Chạy thuật toán edit
                    bool flagUpdate = bus.Update_KHKT(getKH_ID, getId, txtKHKT_HinhThuc.Text, txtKHKT_NoiDung.Text, txtKHKT_ThoiDiem.Text, txtKHKT_CongCuKT.Text);

                    if (flagUpdate == true)
                    {
                        KeHoachKiemTra_List newedit = khkt_Lst.Single(x => x.hinhThuc == hinhThuc);
                        newedit.hinhThuc = txtKHKT_HinhThuc.Text;
                        newedit.noiDung = txtKHKT_NoiDung.Text;
                        newedit.thoiDiem = txtKHKT_ThoiDiem.Text;
                        newedit.congCuKiemTra = txtKHKT_CongCuKT.Text;

                        //xóa content
                        txtKHKT_HinhThuc.Text = "";
                        txtKHKT_NoiDung.Text = "";
                        txtKHKT_ThoiDiem.Text = "";
                        txtKHKT_CongCuKT.Text = "";

                        //vẽ lại view
                        showKeHoachKiemTra();

                        //visible 2 nút sửa, hủy           
                        btnKHKiemTra_Sua.Visible = false;
                        btnKHKiemTra_Huy.Visible = false;
                        btnKHKT_Them.Text = ">>>";

                        //thông báo
                        MessageBox.Show("Đã sửa đối tượng thành công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa đối tượng thất bại");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Hãy điền nội dung");
                }

            }
        }
        #endregion

        #region KE HOACH KIEM TRA CU THE LIST



        //// NUT NHAP
        //// NUT XOA

        string getBuoi;

        List<string> lstNoiDung;
        List<string> lstHoatDong;
        List<string> lstTaiLieuCanDoc;

        private void btnKHGDCT_Them_Click(object sender, EventArgs e)
        {

        }

        ////TAI LIEU LIST
        ////Hàm vẽ list view
        private void showKeHoachGiangDay()
        {
            foreach (KeHoachGiangDayCuThe_List khgd in khgd_Lst)
            {
                lstKHGDCT.Items.Add("+ Buổi/Tuần/ngày: " + khgd.buoi);
                lstKHGDCT.Items.Add("    + Số tiết trên lớp: " + khgd.tiet);

                List<KeHoachGiangDayCuThe_List> khgd_ND = khgd_Lst.Where(x => x.buoi == khgd.buoi).ToList();

                lstKHGDCT.Items.Add("    + Nội dung bài học:");
                foreach (var ndItem in khgd_ND)
                {
                    for (int i = 0; i < ndItem.noiDung.Count; i++)
                        lstKHGDCT.Items.Add("           - " + ndItem.noiDung[i]);
                }

                lstKHGDCT.Items.Add("    + Hoạt động dạy và học:");
                foreach (var hdItem in khgd_ND)
                {
                    for (int i = 0; i < hdItem.hoatDong.Count; i++)
                        lstKHGDCT.Items.Add("           - " + hdItem.hoatDong[i]);
                }

                lstKHGDCT.Items.Add("    + Tài liệu cần đọc:");
                foreach (var tlItem in khgd_ND)
                {
                    for (int i = 0; i < tlItem.taiLieu.Count; i++)
                        lstKHGDCT.Items.Add("           - " + tlItem.taiLieu[i]);
                }

                lstKHGDCT.Items.Add("\n");
            }
        }

        ////TAI LIEU LIST
        ////load dữ liệu item dc chọn trong view
        string buoiLength = "";
        string getBuoi_FDelete = ""; // lúc xóa lstKHGD từ dưới lên tới cái trên cùng bị lỗi
        private void lstKHGDCT_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnKHGDCT_Sua_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn sửa đối tượng này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {


            }
        }
        #endregion

        #region MA TRAN CDR MH - CDR CTDT

        private void btnMaTran_2CDR_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();
            //List<ChuanDauRaMonHoc> lstCDRMH = model.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == getId).ToList();

            //bool flagAdd = false;

            //foreach (var item in lstCDRMH)
            //{
            //    foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
            //    {
            //        flagAdd = bus.Add_MaTran_2CDR(getId, item.STT.Value, int.Parse(row.Cells["STT"].Value.ToString()), false);
            //    }
            //}

            //if (flagAdd == false) MessageBox.Show("Thêm dữ liệu vào CSDL thất bại");
            //else MessageBox.Show("Đã lưu");

            int cdrmh_Id = int.Parse(cboMaTran_ChuanDauRaMonHoc.SelectedValue.ToString());

            int stt_CDRMH = model.ChuanDauRaMonHocs.FirstOrDefault(x => x.Id == cdrmh_Id).STT.Value;

            bool flagAdd = false;

            List<bool> lstCheckDelete = new List<bool>();

            foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
            {
                if (row.Cells[0].Value == null)
                {
                    row.Cells[0].Value = false;
                }
                lstCheckDelete.Add((bool)row.Cells[0].Value);
            }

            bool flagAllowToAdd = false;

            for (int i = 0; i < lstCheckDelete.Count; i++)
            {
                if (lstCheckDelete[i] == true)
                {
                    flagAllowToAdd = true;
                }
            }

            if (flagAllowToAdd)
            {
                foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
                {
                    bool map;

                    if ((bool)row.Cells[0].Value == false)
                    {
                        map = false;
                    }
                    else
                    {
                        map = true;
                    }

                    int stt_CDRCTDT = (int)row.Cells["STT"].Value;

                    int cdrCTDT_Id = model.MucTieuDaoTaos.FirstOrDefault(x => x.ChuongTrinhDaoTao_Id == getCTDT_ID && x.STT == stt_CDRCTDT).Id;

                    flagAdd = bus.Add_MaTran_2CDR(getId, cdrmh_Id, cdrCTDT_Id, map);

                }
                if (flagAdd == false) MessageBox.Show("Cập nhật dữ liệu vào CSDL thất bại");
                else MessageBox.Show("Đã lưu");
            }
            else
            {
                MessageBox.Show("Chuẩn đầu ra môn học chưa được liên kết với chuẩn đầu ra chương trình đào tạo!");
            }

        }

        private void btnMT2CDR_Update_Click(object sender, EventArgs e)
        {
            int cdrmh_Id = int.Parse(cboMaTran_ChuanDauRaMonHoc.SelectedValue.ToString());

            //int stt_CDRMH = model.ChuanDauRaMonHocs.FirstOrDefault(x => x.Id == cdrmh_Id).STT.Value;

            List<bool> lstCheckDelete = new List<bool>();

            foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
            {
                if ((bool)row.Cells[0].Value == false)
                {
                    row.Cells[0].Value = false;
                }
                lstCheckDelete.Add((bool)row.Cells[0].Value);
            }

            bool flagAllowToUpdate = false;

            for (int i = 0; i < lstCheckDelete.Count; i++)
            {
                if (lstCheckDelete[i] == true)
                {
                    flagAllowToUpdate = true;
                }
            }

            if (flagAllowToUpdate)
            {
                bool flagUpdate = false;

                foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
                {
                    bool map;

                    if ((bool)row.Cells[0].Value == false)
                        map = false;
                    else
                        map = true;

                    int stt_CDRCTDT = (int)row.Cells["STT"].Value;

                    int cdrCTDT_Id = model.MucTieuDaoTaos.FirstOrDefault(x => x.ChuongTrinhDaoTao_Id == getCTDT_ID && x.STT == stt_CDRCTDT).Id;

                    flagUpdate = bus.Update_MaTran_2CDR(getId, cdrmh_Id, cdrCTDT_Id, map);

                }
                if (flagUpdate == false) MessageBox.Show("Cập nhật dữ liệu vào CSDL thất bại");
                else MessageBox.Show("Đã lưu");
            }
            else
            {
                MessageBox.Show("Chuẩn đầu ra môn học chưa được liên kết với chuẩn đầu ra chương trình đào tạo!");
            }

        }

        public void loadListCDRCTDT()
        {
            DBEntities model = new DBEntities();

            string cdrmh_Idstr = cboMaTran_ChuanDauRaMonHoc.SelectedValue.ToString();



            foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
            {
                int cdrmh_Id = int.Parse(cdrmh_Idstr);

                int stt_CDRMH = model.ChuanDauRaMonHocs.FirstOrDefault(x => x.Id == cdrmh_Id).STT.Value;

                int stt_CDRCTDT = int.Parse(row.Cells["STT"].Value.ToString());

                int cdrCTDT_Id = model.MucTieuDaoTaos.FirstOrDefault(x => x.ChuongTrinhDaoTao_Id == getCTDT_ID && x.STT == stt_CDRCTDT).Id;

                try
                {
                    // so sánh cái stt_CDRMH + so sánh cái stt_CDRCTDT
                    MaTran_CDRMH_CDRCTDT maTran = model.MaTran_CDRMH_CDRCTDT.FirstOrDefault(x => x.DCCT_Id == getId && x.CDRMH_Id == cdrmh_Id && x.CDRCTDT_Id == cdrCTDT_Id);

                    if (maTran != null)
                    {
                        bool mt = model.MaTran_CDRMH_CDRCTDT.FirstOrDefault(x => x.DCCT_Id == getId && x.CDRMH_Id == cdrmh_Id && x.CDRCTDT_Id == cdrCTDT_Id).Mapped;

                        if (mt == true) row.Cells[0].Value = mt;
                        else row.Cells[0].Value = false;

                        btnMaTran_2CDR.Visible = false;
                        btnMT2CDR_Update.Visible = true;
                    }
                    else
                    {
                        row.Cells[0].Value = null;
                        btnMaTran_2CDR.Visible = true;
                        btnMT2CDR_Update.Visible = false;
                    }
                }
                catch
                {

                }

            }
        }

        private void loadListCDRCTDT_2(int cdrmh_Id)
        {
            DBEntities model = new DBEntities();

            //DataGridViewCheckBoxColumn chkMapping = new DataGridViewCheckBoxColumn();
            //chkMapping.HeaderText = "Mapping";
            //lstMaTran_ChuanDauRaCTDT.Columns.Add(chkMapping);

            foreach (DataGridViewRow row in lstMaTran_ChuanDauRaCTDT.Rows)
            {
                int stt_CDRCTDT = int.Parse(row.Cells["STT"].Value.ToString());

                int cdrCTDT_Id = model.MucTieuDaoTaos.FirstOrDefault(x => x.ChuongTrinhDaoTao_Id == getCTDT_ID && x.STT == stt_CDRCTDT).Id;

                // so sánh cái stt_CDRMH + so sánh cái stt_CDRCTDT
                MaTran_CDRMH_CDRCTDT maTran = model.MaTran_CDRMH_CDRCTDT.FirstOrDefault(x => x.DCCT_Id == getId && x.CDRMH_Id == cdrmh_Id && x.CDRCTDT_Id == cdrCTDT_Id);

                if (maTran != null)
                {
                    bool mt = model.MaTran_CDRMH_CDRCTDT.FirstOrDefault(x => x.DCCT_Id == getId && x.CDRMH_Id == cdrmh_Id && x.CDRCTDT_Id == cdrCTDT_Id).Mapped;

                    if (mt == true)
                        row.Cells[6].Value = true;
                    else
                        row.Cells[6].Value = null;
                }
                //for (int i = 0; i < row.Cells.Count; i++)
                //{
                //    MessageBox.Show(row.Cells[i].Value.ToString());
                //}
            }

        }

        private void cboMaTran_ChuanDauRaMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadListCDRCTDT();
        }

        private void btnMatranCDRMHvaCDRCTDT_xem_Click(object sender, EventArgs e)
        {
            pnMT2CDR.Controls.Clear();
            DBEntities db = new DBEntities();
            List<MaTran_CDRMH_CDRCTDT> i1 = db.MaTran_CDRMH_CDRCTDT.ToList();
            TableLayoutPanel rs = bus.Draw_MT_2CDR(i1, getId);
            rs.Dock = DockStyle.Fill;
            rs.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            pnMT2CDR.Controls.Add(rs);
        }
        #endregion

        private void btnMatranCDRvsHD_xem_Click(object sender, EventArgs e)
        {
            pnMatran_CDRMH_HD.Controls.Clear();
            DBEntities db = new DBEntities();
            List<ChuanDauRaMonHoc> i1 = db.ChuanDauRaMonHocs.ToList();
            List<MaTran_ChuanDauRaMH_HDGDPPDG> i2 = db.MaTran_ChuanDauRaMH_HDGDPPDG.ToList();
            TableLayoutPanel rs = bus.Draw_MT_CDRMH_HD(i1, i2);
            rs.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            rs.AutoScroll = true;
            rs.Dock = DockStyle.Fill;
            pnMatran_CDRMH_HD.Controls.Add(rs);
        }

        ////CKEDITOR save file
        //private void handleCK(string[] arr, int iddcct)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        string path = Application.StartupPath + @"\Detailed Syllabus\CK_" + iddcct + "_" + i + ".txt";
        //        if (System.IO.File.Exists(path))
        //        {
        //            File.Delete(path);
        //        }
        //        System.IO.FileStream fs = new FileStream(path, System.IO.FileMode.Create);
        //        StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
        //        sWriter.Write(arr[i].ToString());
        //        sWriter.Flush();
        //        fs.Close();
        //    }
        //}

        ////CKEDITOR READ
        //private void readCK(WebBrowser[] iarr, int iddcct)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        string path = Application.StartupPath + @"\Detailed Syllabus\CK_" + iddcct + "_" + i + ".txt";
        //        if (System.IO.File.Exists(path))
        //        {
        //            FileStream fs = new FileStream(path, FileMode.Open);
        //            StreamReader sR = new StreamReader(fs, Encoding.UTF8);
        //            string a = sR.ReadToEnd();
        //            fs.Close();
        //            object[] arr = new object[] { a.ToString() };
        //            object c = iarr[i].Document.InvokeScript("setcontent", arr);
        //        }
        //    }
        //}

        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            DeCuongChiTiet dcct = model.DeCuongChiTiets.Single(x => x.Id == getId);
            //if (checkck == 1)
            //{

            //dcct
            string tenChuongTrinh = txtTenChuongTrinh.Text;
            string tenTiengAnh = txtTenTiengAnh.Text;
            string trinhDo = txtTrinhDo.Text;

            // BUS 
            bool flag = bus.Update_DCCT(getId, tenChuongTrinh, tenTiengAnh, trinhDo);

            //mon hoc
            string maHocPhan = txtMaHocPhan.Text;
            string vanTat = txtMoTaVanTat.Text;

            // BUS 
            bool flag1 = bus.Update_Course(dcct.MonHoc_Id.Value, tenChuongTrinh, tenTiengAnh, vanTat, maHocPhan);

            //?????????????????????????????????
            int tinChi = int.Parse(nbrSoTinChi.Value.ToString());


            //gvgd
            string GVPTMH = txtGVPTMH.Text;
            string diachi = txtDCCQ.Text;
            string sdt = txtDCLH.Text;
            string email = txtDCLH.Text;
            string troGiang = txtGVTG.Text;

            GVGD gv = model.GVGDs.FirstOrDefault(x => x.DCCT_Id == getId);

            // BUS
            bool flag2 = false;
            bool flag3 = false;

            if (gv == null)
            {
                flag2 = bus.CreateGVGD(getId, diachi, sdt, email, troGiang, GVPTMH);

            }
            else
            {
                flag3 = bus.UpdateGVGD(getId, diachi, sdt, email, troGiang, GVPTMH);

            }

            if ((flag == true) && (flag1 == true) && ((flag2 == true) || (flag3 == true)))
            {
                MessageBox.Show("Đã lưu");
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }

            //object ob1 = wbPhanbothoigian.Document.InvokeScript("getcontent");
            //object ob2 = wbThoiGianHoc.Document.InvokeScript("getcontent");
            //object ob3 = wbYeuCauMH.Document.InvokeScript("getcontent");

            //string[] hdarr = new string[] { ob1.ToString(), ob2.ToString(), ob3.ToString() };

            //handleCK(hdarr, getId);

            //DBEntities db = new DBEntities();
            //DeCuongChiTiet add = db.DeCuongChiTiets.Single(x => x.Id == getId);
            //add.PhanBoThoiGian = ConvertUnicdoe(ob1.ToString());
            //GVDG add2 = db.GVDGs.Single(x => x.DCCT_Id == getId);
            //add2.ThoiGian = ConvertUnicdoe(ob2.ToString());
            //add.YeuCauMonHoc = ConvertUnicdoe(ob3.ToString());
            //db.SaveChanges();

            int getMH_ID = model.DeCuongChiTiets.FirstOrDefault(x => x.Id == getId).MonHoc_Id.Value;

            foreach (DataGridViewRow row in lstHocPhanTruoc.Rows)
            {
                int ma = int.Parse(row.Cells[0].Value.ToString());
                int mtq = int.Parse(row.Cells[2].Value.ToString());
                bool flagUpdate = bus.Update_HocPhan(ma, getMH_ID, mtq, (bool)row.Cells[3].Value);
            }

            bus.Update_Finish(getId);
        }

    }
}
