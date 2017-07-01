using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Educational_Program
{
    class BUS_Course
    {
        //Lấy Course theo id
        public MonHoc getCourse(int id)
        {
            DBEntities db = new DBEntities();
            return db.MonHocs.Single(x => x.Id == id);
        }

        //Check lỗi input trước khi thêm Môn học
        public string checkCourse(TextBox txtQuảnlí_tên, TextBox txtQuảnlí_tênES, TextBox txtQuảnlí_mã,
                                    ComboBox cboQuảnlí_loạikt_1, ComboBox cboQuảnlí_loạikt_2, ComboBox cboQuảnlí_loạikt_3,
                                            NumericUpDown nQuảnlí_sốtínchỉ, NumericUpDown nQuảnlí_sốgiờlýthuyết, NumericUpDown nQuảnlí_sốgiờthựchành,
                                                  ComboBox cboQuảnlí_họckỳ, ComboBox cboQuảnlí_giáoviên, TextBox txtQuảnlí_nộidungvắntắt)
        {

            string result = "";
            if (txtQuảnlí_tên.Text == "")
            {
                result += "\nTên không được để trống";
            }
            if (txtQuảnlí_tênES.Text == "")
            {
                result += "\nTên tiếng Anh không được để trống";
            }
            if (txtQuảnlí_mã.Text == "")
            {
                result += "\nMã môn học không được để trống";
            }
            if (txtQuảnlí_nộidungvắntắt.Text == "")
            {
                result += "\nNội dung vắn tắt của môn học không được để trống";
            }
            if ((cboQuảnlí_loạikt_1.Text == "") || (cboQuảnlí_loạikt_2.Text == ""))
            {
                result += "\nLoại kiến thức chưa đầy đủ";
            }
            if (nQuảnlí_sốtínchỉ.Value == 0)
            {
                result += "\nSố tín chỉ phải lớn hơn không";
            }
            if (nQuảnlí_sốgiờlýthuyết.Value == 0)
            {
                result += "\nSố giờ lý thuyết phải lớn hơn không";
            }
            if (nQuảnlí_sốtínchỉ.Value != (nQuảnlí_sốgiờlýthuyết.Value / 15 + nQuảnlí_sốgiờthựchành.Value / 30))
            {
                result += "\nSố giờ lý thuyết, Số giờ thực hành chưa phù hợp với Số tín chỉ";
            }

            return result;


        }

        //Check học kì môn học
        public bool checkCourseHK(int id, int nhk)
        {
            DBEntities db = new DBEntities();
            if (nhk == db.MonHocs.Single(x => x.Id == id).HocKy)
            {
                return true;
            }
            return false;
        }

        //Thêm mới môn học vào bảng Môn học và Môn tiên quyết vào bàng Montienquyet
        public string addCourse(int idctdt, int hkc, TextBox txtQuảnlí_tên, TextBox txtQuảnlí_tênES, TextBox txtQuảnlí_mã,
                                    ComboBox cboQuảnlí_loạikt_1, ComboBox cboQuảnlí_loạikt_2, ComboBox cboQuảnlí_loạikt_3,
                                            NumericUpDown nQuảnlí_sốtínchỉ, NumericUpDown nQuảnlí_sốgiờlýthuyết, NumericUpDown nQuảnlí_sốgiờthựchành,
                                                  ComboBox cboQuảnlí_họckỳ, ComboBox cboQuảnlí_giáoviên, TextBox txtQuảnlí_nộidungvắntắt, DataGridView dtgwQuảnlí_môntiênquyết)
        {
            string checkrs = checkCourse(txtQuảnlí_tên, txtQuảnlí_tênES, txtQuảnlí_mã,
                                cboQuảnlí_loạikt_1, cboQuảnlí_loạikt_2, cboQuảnlí_loạikt_3,
                                    nQuảnlí_sốtínchỉ, nQuảnlí_sốgiờlýthuyết, nQuảnlí_sốgiờthựchành,
                                       cboQuảnlí_họckỳ, cboQuảnlí_giáoviên, txtQuảnlí_nộidungvắntắt);
            if (checkrs == "")
            {
                //Thêm mới thông tin
                string ten = txtQuảnlí_tên.Text;
                string tenes = txtQuảnlí_tênES.Text;
                string mamh = txtQuảnlí_mã.Text;
                int lkt = 0;
                if (cboQuảnlí_loạikt_3.Text == "")
                {
                    lkt = (cboQuảnlí_loạikt_1.SelectedIndex + 1) * 100 + (cboQuảnlí_loạikt_2.SelectedIndex + 1) * 10;
                }
                else
                {
                    lkt = (cboQuảnlí_loạikt_1.SelectedIndex + 1) * 100 + (cboQuảnlí_loạikt_2.SelectedIndex + 1) * 10 + (cboQuảnlí_loạikt_3.SelectedIndex + 1);
                }

                int stc = (int)nQuảnlí_sốtínchỉ.Value;
                int lt = (int)nQuảnlí_sốgiờlýthuyết.Value;
                int th = (int)nQuảnlí_sốgiờthựchành.Value;
                int hk = cboQuảnlí_họckỳ.SelectedIndex + 1;
                int giaovienid = (int)cboQuảnlí_giáoviên.SelectedValue;
                string ndvt = txtQuảnlí_nộidungvắntắt.Text;


                DBEntities db = new DBEntities();

                MonHoc add = new MonHoc();

                add.ChuongTrinhDaoTao_Id = idctdt;
                add.TenMonHoc = ten;
                add.TenTiengAnh = tenes;
                add.MonHoc_Id = mamh;
                add.LoaiKienThuc = lkt;
                add.SoTinChi = stc;
                add.SoGioLyThuyet = lt;
                add.SoGioThucHanh = th;
                add.HocKy = hk;
                add.GiangVienPhuTrach_Id = giaovienid;
                add.NoiDungVanTat = ndvt;
                db.MonHocs.Add(add);
                db.SaveChanges();

                int id = db.MonHocs.Single(x => x.MonHoc_Id == mamh && x.ChuongTrinhDaoTao_Id == idctdt).Id;
                List<SP_MONTIENQUYET_GET_Result> find = db.SP_MONTIENQUYET_GET(idctdt, hk, id).ToList();
                //thêm mới môn tiên quyết
                for (int i = 0; i < dtgwQuảnlí_môntiênquyết.RowCount; i++)
                {
                    if (dtgwQuảnlí_môntiênquyết.Rows[i].Cells["Check"].Value != null)
                    {
                        if ((bool)dtgwQuảnlí_môntiênquyết.Rows[i].Cells["Check"].Value == true)
                        {
                            MonTienQuyet mtq = new MonTienQuyet();
                            mtq.MonHoc_Id = id;
                            mtq.MonTienQuyet_Id = find[i].Id;
                            mtq.Status = true;
                            db.MonTienQuyets.Add(mtq);
                            db.SaveChanges();
                        }

                    }
                    else
                    {
                        MonTienQuyet mtq = new MonTienQuyet();
                        mtq.MonHoc_Id = id;
                        mtq.MonTienQuyet_Id = find[i].Id;
                        mtq.Status = false;
                        db.MonTienQuyets.Add(mtq);
                        db.SaveChanges();
                    }
                }
                updateAddfn(id, hk);
                return checkrs;
            }
            else
            {
                return checkrs;
            }

        }
        //Update lại danh sách môn tiên quyết
        private void updateAddfn(int id, int hk)
        {
            DBEntities db = new DBEntities();
            List<MonHoc> uplst = db.MonHocs.Where(x => x.HocKy > hk).ToList();

            for (int i = 0; i < uplst.Count; i++)
            {
                MonTienQuyet uprow = new MonTienQuyet();
                uprow.MonHoc_Id = uplst[i].Id;
                uprow.MonTienQuyet_Id = id;
                uprow.Status = false;
                db.MonTienQuyets.Add(uprow);
                db.SaveChanges();
            }
        }



        //Edit môn học và môn tiên quyết của môn học đó
        public string editCourse(int idctdt, int id, TextBox txtQuảnlí_tên, TextBox txtQuảnlí_tênES, TextBox txtQuảnlí_mã,
                                    ComboBox cboQuảnlí_loạikt_1, ComboBox cboQuảnlí_loạikt_2, ComboBox cboQuảnlí_loạikt_3,
                                            NumericUpDown nQuảnlí_sốtínchỉ, NumericUpDown nQuảnlí_sốgiờlýthuyết, NumericUpDown nQuảnlí_sốgiờthựchành,
                                                  ComboBox cboQuảnlí_họckỳ, ComboBox cboQuảnlí_giáoviên, TextBox txtQuảnlí_nộidungvắntắt, DataGridView dtgwQuảnlí_môntiênquyết)
        {
            string checkrs = checkCourse(txtQuảnlí_tên, txtQuảnlí_tênES, txtQuảnlí_mã,
                                cboQuảnlí_loạikt_1, cboQuảnlí_loạikt_2, cboQuảnlí_loạikt_3,
                                    nQuảnlí_sốtínchỉ, nQuảnlí_sốgiờlýthuyết, nQuảnlí_sốgiờthựchành,
                                       cboQuảnlí_họckỳ, cboQuảnlí_giáoviên, txtQuảnlí_nộidungvắntắt);
            if (checkrs == "")
            {
                checkrs = "";
                //edit thông tin chung
                string ten = txtQuảnlí_tên.Text;
                string tenes = txtQuảnlí_tênES.Text;
                string mamh = txtQuảnlí_mã.Text;
                int lkt = 0;
                if (cboQuảnlí_loạikt_3.Text == "")
                {
                    lkt = (cboQuảnlí_loạikt_1.SelectedIndex + 1) * 100 + (cboQuảnlí_loạikt_2.SelectedIndex + 1) * 10;
                }
                else
                {
                    lkt = (cboQuảnlí_loạikt_1.SelectedIndex + 1) * 100 + (cboQuảnlí_loạikt_2.SelectedIndex + 1) * 10 + (cboQuảnlí_loạikt_3.SelectedIndex + 1);
                }

                int stc = (int)nQuảnlí_sốtínchỉ.Value;
                int lt = (int)nQuảnlí_sốgiờlýthuyết.Value;
                int th = (int)nQuảnlí_sốgiờthựchành.Value;
                int hk = cboQuảnlí_họckỳ.SelectedIndex + 1;
                int giaovienid = (int)cboQuảnlí_giáoviên.SelectedValue;
                string ndvt = txtQuảnlí_nộidungvắntắt.Text;


                DBEntities db = new DBEntities();

                MonHoc edit = db.MonHocs.Single(x => x.Id == id);

                int oldhk = edit.HocKy;

                edit.ChuongTrinhDaoTao_Id = idctdt;
                edit.TenMonHoc = ten;
                edit.TenTiengAnh = tenes;
                edit.MonHoc_Id = mamh;
                edit.LoaiKienThuc = lkt;
                edit.SoTinChi = stc;
                edit.SoGioLyThuyet = lt;
                edit.SoGioThucHanh = th;
                edit.HocKy = hk;
                edit.GiangVienPhuTrach_Id = giaovienid;
                edit.NoiDungVanTat = ndvt;



                //edit môn tiên quyết
                if (checkCourseHK(id, hk) == true)
                {
                    editMTQ_Id(id, dtgwQuảnlí_môntiênquyết, db);
                    db.SaveChanges();
                }
                else
                {
                    db.SaveChanges();

                    List<MonTienQuyet> delllst = db.MonTienQuyets.Where(x => x.MonHoc_Id == id || x.MonTienQuyet_Id == id).ToList();
                    foreach (MonTienQuyet a in delllst)
                    {
                        db.MonTienQuyets.Remove(a);
                        db.SaveChanges();
                    }

                    List<MonHoc> editlowerlst = db.MonHocs.Where(x => x.HocKy < hk).ToList();
                    for (int i = 0; i < editlowerlst.Count; i++)
                    {
                        MonTienQuyet a = new MonTienQuyet();
                        a.MonHoc_Id = id;
                        a.MonTienQuyet_Id = editlowerlst[i].Id;
                        a.Status = false;
                        db.MonTienQuyets.Add(a);
                        db.SaveChanges();
                    }

                    List<MonHoc> edithigherlst = db.MonHocs.Where(x => x.HocKy > hk).ToList();
                    for (int i = 0; i < edithigherlst.Count; i++)
                    {
                        MonTienQuyet a = new MonTienQuyet();
                        a.MonHoc_Id = edithigherlst[i].Id;
                        a.MonTienQuyet_Id = id;
                        a.Status = false;
                        db.MonTienQuyets.Add(a);
                        db.SaveChanges();
                    }


                    //Set true, false cho trong bảng Montienquyet theo id
                    editMTQ_Id(id, dtgwQuảnlí_môntiênquyết, db);
                }


                return checkrs;
            }
            else
            {
                return checkrs;
            }

        }

        private static void editMTQ_Id(int id, DataGridView dtgwQuảnlí_môntiênquyết, DBEntities db)
        {
            try
            {
                MonTienQuyet del = db.MonTienQuyets.Single(x => x.MonHoc_Id == id && x.MonTienQuyet_Id == id);
                db.MonTienQuyets.Remove(del);
            }
            catch
            {

            }
            for (int i = 0; i < dtgwQuảnlí_môntiênquyết.RowCount; i++)
            {
                if (dtgwQuảnlí_môntiênquyết.Rows[i].Cells[5].Value != null)
                {
                    if ((bool)dtgwQuảnlí_môntiênquyết.Rows[i].Cells[5].Value == true)
                    {
                        int idmtq = int.Parse(dtgwQuảnlí_môntiênquyết.Rows[i].Cells[0].Value.ToString());
                        MonTienQuyet mtq = db.MonTienQuyets.Single(x => x.MonTienQuyet_Id == idmtq && x.MonHoc_Id == id);
                        mtq.Status = true;
                        db.SaveChanges();
                    }
                    else
                    {
                        int idmtq = int.Parse(dtgwQuảnlí_môntiênquyết.Rows[i].Cells[0].Value.ToString());
                        MonTienQuyet mtq = db.MonTienQuyets.Single(x => x.MonTienQuyet_Id == idmtq && x.MonHoc_Id == id);
                        mtq.Status = false;
                        db.SaveChanges();
                    }
                }

            }
        }


    }
}
