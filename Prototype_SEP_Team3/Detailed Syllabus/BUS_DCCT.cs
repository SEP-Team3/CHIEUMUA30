using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    class BUS_DCCT
    {
        public void LoadDCCT(int id, int ctdt_Id, TextBox TenChuongTrinh, TextBox TenTiengAnh, TextBox MaHocPhan, ComboBox KhoiKienThuc_1, ComboBox KhoiKienThuc_2, ComboBox KhoiKienThuc_3,
                            TextBox GVPTMH, TextBox DiaChiCoQuan, TextBox DiaChiLienHe, TextBox Email, TextBox GVTG, NumericUpDown SoTinChi, TextBox TrinhDo, DataGridView ListHocPhanTruoc,
                            ListBox ListMucTieuMonHoc, ListBox ListChuanDauRa,
                            ComboBox MaTran_CDRMH_CDRCTDT, DataGridView ListMaTran_CDRMH_CDRCTDT, TextBox MoTaVanTan, ComboBox MaTran_CDRMH_HD,
                            ListBox List_MaTran_CDRMH_HDGD, ListBox ListTaiLieu,
                            ListBox ListPPDanhGiaKQHT, ListBox ListKeHoachKiemTra, ListBox ListKeHoachGiangDay)
        {


            DBEntities model = new DBEntities();

            DeCuongChiTiet dcct = model.DeCuongChiTiets.Single(x => x.Id == id);
            DeCuongChiTiet mh = model.DeCuongChiTiets.Single(x => x.MonHoc.Id == dcct.MonHoc_Id);

            TenChuongTrinh.Text = mh.TenDCCT;
            TenTiengAnh.Text = mh.TenTiengAnh;
            MaHocPhan.Text = mh.MonHoc.MonHoc_Id;
            KhoiKienThuc_1.SelectedIndex = int.Parse(model.MonHocs.Single(x => x.Id == mh.MonHoc_Id).LoaiKienThuc.ToString().Substring(0, 1)) - 1;
            KhoiKienThuc_2.SelectedIndex = int.Parse(model.MonHocs.Single(x => x.Id == mh.MonHoc_Id).LoaiKienThuc.ToString().Substring(1, 1)) - 1;
            int lkt3 = int.Parse(model.MonHocs.Single(x => x.Id == mh.MonHoc_Id).LoaiKienThuc.ToString().Substring(2, 1)) - 1;
            if (lkt3 >= 0)
            {
                KhoiKienThuc_3.SelectedIndex = lkt3;
            }

            GVGD gv = model.GVGDs.FirstOrDefault(x => x.DCCT_Id == mh.Id);
            if (gv != null)
            {
                GVPTMH.Text = gv.TenGV;
                DiaChiCoQuan.Text = gv.DiaChi;
                DiaChiLienHe.Text = gv.DienThoai;
                Email.Text = gv.Email;
                GVTG.Text = gv.TroGiang;
            }

            //ListGVDT.Text = dcct
            SoTinChi.Value = model.MonHocs.FirstOrDefault(x => x.Id == mh.MonHoc_Id).SoTinChi;
            TrinhDo.Text = mh.TrinhDo;
            //PhanBoThoiGian.DocumentText = dcct.PhanBoThoiGian;
            //ListHocPhanTruoc.DataSource = model.MonTienQuyets.Where(x => x.MonHoc_Id == dcct.MonHoc_Id).ToList();

            ListHocPhanTruoc.DataSource = model.MonTienQuyet_Select_Sang(mh.MonHoc_Id);
            ListHocPhanTruoc.Columns[0].HeaderText = "Mã";
            ListHocPhanTruoc.Columns[1].HeaderText = "Tên môn học";
            ListHocPhanTruoc.Columns[2].HeaderText = "Mã môn tiên quyết";
            ListHocPhanTruoc.Columns[3].HeaderText = "Chọn";
            ListHocPhanTruoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            try
            {
                MaTran_CDRMH_CDRCTDT.DataSource = model.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == mh.Id).ToList();
                MaTran_CDRMH_CDRCTDT.DisplayMember = "NoiDung";
                MaTran_CDRMH_CDRCTDT.ValueMember = "Id";

                ListMaTran_CDRMH_CDRCTDT.DataSource = model.MucTieuDaoTaos.Where(x => x.ChuongTrinhDaoTao_Id == ctdt_Id && x.Loai!="Chung").ToList();
                //ListMaTran_CDRMH_CDRCTDT.Columns["Id"].Visible = false;
                //ListMaTran_CDRMH_CDRCTDT.Columns["ChuongTrinhDaoTao_Id"].Visible = false;
                //ListMaTran_CDRMH_CDRCTDT.Columns["Loai"].Visible = false;
                //ListMaTran_CDRMH_CDRCTDT.Columns["ChuongTrinhDaoTao"].Visible = false;
                //ListMaTran_CDRMH_CDRCTDT.Columns["MaTran_CDRMH_CDRCTDT"].Visible = false;

                MaTran_CDRMH_HD.DataSource = model.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == mh.Id).ToList();
                MaTran_CDRMH_HD.DisplayMember = "NoiDung";
                MaTran_CDRMH_HD.ValueMember = "Id";

                MoTaVanTan.Text = model.MonHocs.FirstOrDefault(x => x.Id == mh.MonHoc_Id).NoiDungVanTat;

            }
            catch
            {

            }
        }

        DBEntities model = new DBEntities();

        public bool Add_MucTieuMonHoc(int deCuongChiTiet_Id, string loai, string noiDung, double STT)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_CreateMTMH_Sang(deCuongChiTiet_Id,  loai,  noiDung,  STT);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Add_ChuanDauRaMonHoc(int deCuongChiTiet_Id, int STT, string noiDung)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_updateDetailedSyllabus_ChuanDauRaMonHoc_Thinh(deCuongChiTiet_Id, STT, noiDung);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Add_MaTran_CDR_HD(int CDRMH_Id, string ppdg, string hddg)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_CreateDetailedSyllabus_MaTranCDRHDDG_Sang(CDRMH_Id, ppdg, hddg);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Add_MaTran_2CDR(int dcct_Id, int cdrMH_Id, int cdrCTDT_Id, bool map)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_CreateDetailedSyllabus_MaTran2CDR_Sang(dcct_Id, cdrMH_Id, cdrCTDT_Id, map);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Add_TaiLieu(int dcct_Id, string loai, string noiDung, double stt)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_updateDetailedSyllabus_TaiLieuMonHoc_Thinh(dcct_Id, loai, noiDung, stt);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Add_PPGD(int dcct_Id, string loaiND, string soLan, int trongSo, string hinhThuc)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_CreatePPDGKQHT(dcct_Id, loaiND, soLan, trongSo, hinhThuc);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Add_KHKT(int dcct_Id, string hinhThuc, string noiDung, string thoiDiem, string congCu)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_CreateKHKT(dcct_Id, hinhThuc, noiDung, thoiDiem, congCu);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_ChuanDauRaMonHoc(int deCuongChiTiet_Id, string noiDung)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_deleteDetailedSyllabus_ChuanDauRaMonHoc_Sang(deCuongChiTiet_Id, noiDung);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_MucTieuMonHoc(int deCuongChiTiet_Id, string loai, string noiDung, double STT)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_DeleteMTMH_Sang(deCuongChiTiet_Id, loai, noiDung, STT);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_MaTranCDRHD(int mt_Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_DeleteMaTranCDRHD_Sang(mt_Id);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_TaiLieu(int mt_Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_deleteTaiLieu_Sang(mt_Id);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_PPDG(int mt_Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_DeletePPDGKQHT(mt_Id);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_KHKT(int mt_Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_DeleteKHKT(mt_Id);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_MucTieuMonHoc(int deCuongChiTiet_Id, string loai, string noiDung, double STT)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateMTMH_Sang(deCuongChiTiet_Id, loai, noiDung, STT);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool UpdateSTT_ChuanDauRaMonHoc(int deCuongChiTiet_Id, int stt, string noiDung)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_updateSTTDetailedSyllabus_ChuanDauRaMonHoc_Sang(deCuongChiTiet_Id, stt, noiDung);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_ChuanDauRaMonHoc(int deCuongChiTiet_Id, int stt, string noiDung)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_updateDetailedSyllabus_ChuanDauRaMonHoc_Sang(deCuongChiTiet_Id, stt, noiDung);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_HocPhan(int id, int monHoc_ID, int monTQ_ID, bool status)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateDetailedSyllabus_HPHT_Sang(id, monHoc_ID, monTQ_ID, status);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_MaTran_2CDR(int deCuongChiTiet_Id, int cdrMH_Id, int cdrCTDT_Id, bool map)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateDetailedSyllabus_MaTran2CDR_Sang(deCuongChiTiet_Id, cdrMH_Id, cdrCTDT_Id, map);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_DCCT(int getId, string tenChuongTrinh, string tenTiengAnh, string trinhDo)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateDetailedSyllabus_Sang(getId, tenChuongTrinh, tenTiengAnh, trinhDo);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_Course(int MonHoc_Id, string tenChuongTrinh, string tenTiengAnh, string vanTat, string maHocPhan)
        {
            bool flag = false;
            try
            {
                model.Course_Update_Sang(MonHoc_Id, tenChuongTrinh, tenTiengAnh, vanTat, maHocPhan);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_MaTranCDRHD(int mT_Id, string noiDung)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateMaTranCDRHD_Sang(mT_Id, noiDung);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_TaiLieu(int Id, string noiDung)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateTaiLieu_Sang(Id, noiDung);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_PPDG(int Id, int dcct_Id, string loaiND, string soLan, int trongSo, string hinhThuc)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdatePPDGKQHT(Id, dcct_Id, loaiND, soLan, trongSo, hinhThuc);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_KHKT(int Id, int dcct_Id, string hinhThuc, string noiDung, string thoiDiem, string congCu)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateKHKT(Id, dcct_Id, hinhThuc, noiDung, thoiDiem, congCu);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Update_Finish(int Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_HoanThanh_Sang(Id);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }


        public bool CreateGVGD(int getId, string diachi, string sdt, string email, string troGiang, string GVPTMH)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_CreateGVGD_Sang(getId, diachi, sdt, email, troGiang, GVPTMH);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool UpdateGVGD(int getId, string diachi, string sdt, string email, string troGiang, string GVPTMH)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_UpdateGVGD_Sang(getId, diachi, sdt, email, troGiang, GVPTMH);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_MaTran_2CDR(int deCuongChiTiet_Id, int cdrMH_Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_DeleteDetailedSyllabus_MaTran2CDR_Sang(deCuongChiTiet_Id, cdrMH_Id);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool Delete_MaTran_HDGD(int cdrMH_Id)
        {
            bool flag = false;
            try
            {
                model.DetailedSyllabus_DeleteDetailedSyllabus_MaTranCDRvsHDGD_Sang(cdrMH_Id);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public TableLayoutPanel Draw_MT_CDRMH_HD(List<ChuanDauRaMonHoc> ilst1, List<MaTran_ChuanDauRaMH_HDGDPPDG> ilst2)
        {
            TableLayoutPanel rs = new TableLayoutPanel();
            int row = 0;
            rs.Controls.Add(new Label() { Text = "Mục tiêu", Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 0, row);
            rs.Controls.Add(new Label() { Text = "CĐR", Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 1, row);
            rs.Controls.Add(new Label() { Text = "Các hoạt động dạy và học", Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 2, row);
            rs.Controls.Add(new Label() { Text = "Phương pháp kiểm tra, đánh giá sinh viên", Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 3, row);
            row++;
            int sttint = 1;
            foreach (ChuanDauRaMonHoc a in ilst1)
            {
                rs.Controls.Add(new Label() { Text = sttint.ToString(), Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 0, row);
                rs.Controls.Add(new Label() { Text = a.STT.ToString(), Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 1, row);
                string hdstr = "";
                string ppstr = "";
                foreach (MaTran_ChuanDauRaMH_HDGDPPDG b in ilst2)
                {
                    if (a.Id == b.ChuanDauRaMonHoc_Id)
                    {
                        if (b.Loai == "Các hoạt động dạy và học")
                        {
                            hdstr += "- " + b.NoiDung + "\n";
                        }
                        if (b.Loai == "Phương pháp kiểm tra, đánh giá sinh viên")
                        {
                            ppstr += "- " + b.NoiDung + "\n";
                        }
                    }
                }
                rs.Controls.Add(new Label() { Text = hdstr.Trim(), Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 2, row);
                rs.Controls.Add(new Label() { Text = ppstr.Trim(), Anchor = AnchorStyles.None, AutoSize = true, BackColor = Color.White }, 3, row);
                sttint++;
                row++;
            }

            return rs;
        }

        public TableLayoutPanel Draw_MT_2CDR(List<MaTran_CDRMH_CDRCTDT> ilst, int id)
        {
            DBEntities model = new DBEntities();

            TableLayoutPanel rs = new TableLayoutPanel();
            List<MaTran_CDRMH_CDRCTDT> lst1 = ilst.Where(x => x.CDRMH_Id == ilst[0].CDRMH_Id).ToList();
            int col = 0;
            int row = 0;
            rs.Controls.Add(new Label() { Text = "CĐR", Anchor = AnchorStyles.None, BackColor = Color.White, AutoSize = true, Dock = DockStyle.Fill }, col, row);
            col++;

            List<string> sttLst = new List<string>();
            foreach (MaTran_CDRMH_CDRCTDT a in lst1)
            {

                string sttrs = model.MucTieuDaoTaos.Single(x => x.Id == a.CDRCTDT_Id).STT.ToString();
                sttLst.Add(sttrs);
            }
            foreach (string a in sttLst)
            {
                rs.Controls.Add(new Label() { Text = a, Anchor = AnchorStyles.None, BackColor = Color.White, Dock = DockStyle.Fill }, col, row);
                col++;
            }
            col = 0;
            row++;
            sttLst.Clear();
            List<MaTran_CDRMH_CDRCTDT> lst2 = ilst.Where(x => x.CDRCTDT_Id == lst1[0].CDRCTDT_Id).ToList();
            foreach (MaTran_CDRMH_CDRCTDT a in lst2)
            {

                string sttrs = model.ChuanDauRaMonHocs.Single(x => x.Id == a.CDRMH_Id).STT.ToString();
                sttLst.Add(sttrs);
            }
            foreach (string a in sttLst)
            {
                rs.Controls.Add(new Label() { Text = a, Anchor = AnchorStyles.None, BackColor = Color.White, Dock = DockStyle.Fill }, col, row);
                row++;
            }
            row = 1;
            for (int i = 0; i < lst2.Count; i++)
            {
                col = 1;
                List<MaTran_CDRMH_CDRCTDT> lst3 = ilst.Where(x => x.CDRMH_Id == lst2[i].CDRMH_Id).ToList();
                foreach (MaTran_CDRMH_CDRCTDT a in lst3)
                {
                    string mapstr = "";
                    if (a.Mapped == true)
                    {
                        mapstr = "X";
                    }
                    rs.Controls.Add(new Label() { Text = mapstr, Anchor = AnchorStyles.None, BackColor = Color.White, Dock = DockStyle.Fill }, col, row);
                    col++;

                }
                row++;
            }
            return rs;

        }
    }
}
