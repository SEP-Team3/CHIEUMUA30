using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Prototype_SEP_Team3.Educational_Program
{
    class ExportDocument
    {
        public ExportDocument(int ChuongTrinhDaoTao_ID, String url)
        {
            ChuongTrinhDaoTao = ChuongTrinhDaoTao_ID;
            path = url;
        }
        String path;
        static int ChuongTrinhDaoTao;
        static DBEntities entity = new DBEntities();
        static Word.Application WordApp = new Word.Application();
        static Word.Document doc = null;
        static Word.Bookmarks bookmarks = null;
        static Word.Bookmark myBookmark = null;
        static Word.Range bookmarkRange = null;
        int HK;
        public Boolean exportWord()
        {
            try
            {
                HK = ((int)((float)entity.ThongTinChung_CTDT.Single(i => i.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao).ThoiGianDaoTao.Value) * 2);
                WordApp.Visible = false;
                string c = Directory.GetCurrentDirectory();
                WordApp.Documents.Open(Path.Combine(c, "Educational Program\\ChuongTrinhDaoTaoTemplate.docx"));
                doc = WordApp.ActiveDocument;
                bookmarks = doc.Bookmarks;
                addInfo();
                createTableNDCT("tableNoiDungChuongTrinh");
                createCoSoVatChat("prCoSoVatChat");
                createDanhSachGiaoVien("tableDanhSachGiangVien");
                createBookMarkKeHoachGiangDay();
                for (int i = 1; i <= HK; i++)
                {
                    String bookM = "KH_HK" + i;
                    createKeHoachGiangDay(bookM, ChuongTrinhDaoTao, i);

                }
                createBookMarkNoiDungVanTat();
                createMoTaVangTat();
                doc.SaveAs2(path);
                WordApp.Documents.Close();
                WordApp.Quit();
                return true;
            }
            catch
            {
                return false;
            }
        }
        void style(Word.Table table)
        {
            table.Range.Font.Name = "Times New Roman";
            table.Range.Font.Size = 12;
            table.Borders.Enable = 1;
        }
        void addBookMark(String bookmakeName, String data)
        {
            myBookmark = bookmarks[bookmakeName];
            bookmarkRange = myBookmark.Range;
            bookmarkRange.Text = data;
        }
        void addInfo()
        {
            List<ThongTinChung_CTDT> listThongTinChung = entity.ThongTinChung_CTDT.Where(i => i.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao).ToList();
            addBookMark("txtTenChuongTrinh", listThongTinChung[0].TenChuongTrinh);
            addBookMark("txtTrinhDo", listThongTinChung[0].TrinhDo);
            addBookMark("txtNganhDaoTao", listThongTinChung[0].Nganh);
            addBookMark("txtLoaiHinhDaoTao", listThongTinChung[0].LoaiHinh);
            addBookMark("txtNamDaoTao", listThongTinChung[0].ThoiGianDaoTao + "");
            addBookMark("txtSohocki", HK + "");
            addBookMark("txKhoiLuongKienThucToanKhoa", "   " + listThongTinChung[0].KhoiLuongKienThucToanKhoa);
            addBookMark("txtDoiTuongTuyenSinh", listThongTinChung[0].DoiTuongTuyenSinh);
            addBookMark("txtDKTotNghiep", listThongTinChung[0].QuyTrinhDaoTao);
            addBookMark("txtThangDiem", listThongTinChung[0].ThangDiem + "");
            List<MucTieuDaoTao> listMucTieu = entity.MucTieuDaoTaos.Where(i => i.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao).Where(i => i.Loai.Contains("Chung")).ToList();
            myBookmark = bookmarks["prMucTieuDaoTao"];
            bookmarkRange = myBookmark.Range;
            for (int i = 0; i < listMucTieu.Count; i++)
            {
                bookmarkRange.Text += ((i + 1) + ".  " + listMucTieu[i].NoiDung + "\r");
            }

        }

        void createCoSoVatChat(String bookmarkName)
        {
            List<ThongTinChung_CTDT> ThongTinChung = entity.ThongTinChung_CTDT.Where(i => i.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao).ToList();
            myBookmark = bookmarks[bookmarkName];
            bookmarkRange = myBookmark.Range;
            bookmarkRange.Text = ThongTinChung[0].CoSoVatChat + "\r";
        }
        void createDanhSachGiaoVien(String bookmarkName)
        {
            List<TaiKhoan> list = entity.TaiKhoans.ToList();
            int rowNum = list.Count() + 1;
            int columNum = 5;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks[bookmarkName];
            bookmarkRange = myBookmark.Range;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            style(firstTable);
            firstTable.Columns[1].PreferredWidth = 48;
            firstTable.Columns[2].PreferredWidth = 160;
            firstTable.Columns[3].PreferredWidth = 70;
            firstTable.Columns[4].PreferredWidth = 100;
            firstTable.Columns[5].PreferredWidth = 120;
            firstTable.Rows[1].Cells[1].Range.Text = "STT";
            firstTable.Rows[1].Cells[2].Range.Text = "Họ và tên";
            firstTable.Rows[1].Cells[3].Range.Text = "Năm sinh";
            firstTable.Rows[1].Cells[4].Range.Text = "Văn bằng cao nhất, ngành đào tạo";
            firstTable.Rows[1].Cells[5].Range.Text = "Các môn sẽ đảm trách (*)";
            firstTable.Range.Font.Bold = 1;
            List<MonHoc> list1 = entity.MonHocs.Where(m => m.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao).ToList();
            int row = 2;
            int sttint = 1;
            foreach (TaiKhoan a in list)
            {
                string mhstr = "";
                foreach (MonHoc b in list1)
                {
                    if (b.GiangVienPhuTrach_Id == a.Id)
                    {
                        mhstr += b.TenMonHoc + "\r";
                    }
                }
                string rs = mhstr.Trim();
                firstTable.Rows[row].Cells[1].Range.Text = sttint.ToString();
                firstTable.Rows[row].Cells[2].Range.Text = a.Ten;
                firstTable.Rows[row].Cells[5].Range.Text = rs;
                row++;
                sttint++;
            }
        }
        void styleNDCT(Word.Table table)
        {
            table.Columns[1].PreferredWidth = 45;
            table.Columns[2].PreferredWidth = 110;
            table.Columns[3].PreferredWidth = 270;
            table.Columns[4].PreferredWidth = 35;
            table.Columns[5].PreferredWidth = 46;
            table.Rows[1].Range.Font.Bold = 1;
            table.Range.Font.Name = "Times New Roman";
            table.Range.Font.Size = 11;
            table.Borders.Enable = 1;
        }
        void mergeNDCT(Word.Table table, int row)
        {
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[2].Merge(table.Rows[row].Cells[3]);
        }
        void mergelv1NDCT(Word.Table table, int row)
        {
            table.Rows[row].Cells[2].Merge(table.Rows[row].Cells[3]);
            table.Rows[row].Cells[3].Merge(table.Rows[row].Cells[4]);
        }
        void createTableNDCT(String bookmarksName)
        {
            myBookmark = bookmarks[bookmarksName];
            bookmarkRange = myBookmark.Range;
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listLyLuan = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "11").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listKHXaHoi = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "12").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listNhanVanNgheThuat = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "13").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listNgoaiNgu = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "14").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listTinHoc = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "15").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listGDTC = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "16").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listGDQP = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "17").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listCoSo = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "21").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listChungNC = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "22").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listSauNC = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "23").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listKienThucNganhThu2 = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "24").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listBoTroTuDo = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "25").ToList();
            List<Load_NoiDungChuongTrinh_MonHoc_Thinh_Result> listTotNghiep = entity.Load_NoiDungChuongTrinh_MonHoc_Thinh(ChuongTrinhDaoTao, "26").ToList();
            List<MonHoc> listMH = entity.MonHocs.Where(i => i.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao).ToList();
            int numLyLuan = listLyLuan.Count;
            int numXaHoi = listKHXaHoi.Count;
            int numNhanVanNgheThuat = listNhanVanNgheThuat.Count;
            int numNgoaiNgu = listNgoaiNgu.Count;
            int numTinHoc = listTinHoc.Count;
            int numGDTC = listGDTC.Count;
            int numGDQP = listGDQP.Count;
            int numCoSo = listCoSo.Count;
            int numChungNC = listChungNC.Count;
            int numSauNC = listSauNC.Count;
            int numKienThucNganhThu2 = listKienThucNganhThu2.Count;
            int numBoTroTuDo = listBoTroTuDo.Count;
            int numTotNghiep = listTotNghiep.Count;

            int lineXaHoi = 4 + numLyLuan;
            int lineNhanVanNgheThuat = lineXaHoi + numXaHoi + 1;
            int lineNgoaiNgu = lineNhanVanNgheThuat + numNhanVanNgheThuat + 1;
            int lineTinHoc = lineNgoaiNgu + numNgoaiNgu + 1;
            int lineGDTC = lineTinHoc + numTinHoc + 1;
            int lineGDQP = lineGDTC + numGDTC + 1;
            int lineGDChuyenNghiep = lineGDQP + numGDQP + 1;
            int lineCoso = lineGDChuyenNghiep + 1;
            int lineChungNC = lineCoso + numCoSo + 1;
            int lineSauNC = lineChungNC + numChungNC + 1;
            int lineKienThucNganhThu2 = lineSauNC + numSauNC + 1;
            int lineBoTro = lineKienThucNganhThu2 + numKienThucNganhThu2 + 1;
            int lineTotNghiep = lineBoTro + numBoTroTuDo + 1;

            int sumLyLuan = 0;
            int sumXaHoi = 0;
            int sumNhanVan = 0;
            int sumNgoaiNgu = 0;
            int sumTinHoc = 0;
            int sumGDTC = 0;
            int sumGDQP = 0;
            int sumKTCS = 0;
            int sumKTChung = 0;
            int sumKTChuyen = 0;
            int sumKTChuyen2 = 0;
            int sumKTBoTro = 0;
            int sumTotNghiep = 0;

            int rowNum = listMH.Count() + 16;
            int columNum = 5;
            object missing = System.Reflection.Missing.Value;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            styleNDCT(firstTable);
            mergeNDCT(firstTable, 2);
            mergeNDCT(firstTable, lineGDChuyenNghiep);
            mergelv1NDCT(firstTable, lineXaHoi);
            mergelv1NDCT(firstTable, 3);
            mergelv1NDCT(firstTable, lineNgoaiNgu);
            mergelv1NDCT(firstTable, lineTinHoc);
            mergelv1NDCT(firstTable, lineNhanVanNgheThuat);
            mergelv1NDCT(firstTable, lineGDTC);
            mergelv1NDCT(firstTable, lineGDQP);
            mergelv1NDCT(firstTable, lineCoso);
            mergelv1NDCT(firstTable, lineChungNC);
            mergelv1NDCT(firstTable, lineSauNC);
            mergelv1NDCT(firstTable, lineKienThucNganhThu2);
            mergelv1NDCT(firstTable, lineBoTro);
            mergelv1NDCT(firstTable, lineTotNghiep);
            int countMH = 0;
            int k = -1;
            for (int i = 4; i < lineXaHoi; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listLyLuan[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listLyLuan[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listLyLuan[k].SoTinChi + ""; sumLyLuan += listLyLuan[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listLyLuan[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }

                }

            }
            k = -1;
            for (int i = lineXaHoi + 1; i < lineNhanVanNgheThuat; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listKHXaHoi[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listKHXaHoi[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listKHXaHoi[k].SoTinChi + ""; sumXaHoi += listKHXaHoi[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listKHXaHoi[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineNhanVanNgheThuat + 1; i < lineNgoaiNgu; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listNhanVanNgheThuat[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listNhanVanNgheThuat[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listNhanVanNgheThuat[k].SoTinChi + ""; sumNhanVan += listNhanVanNgheThuat[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listNhanVanNgheThuat[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineNgoaiNgu + 1; i < lineTinHoc; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listNgoaiNgu[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listNgoaiNgu[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listNgoaiNgu[k].SoTinChi + ""; sumNgoaiNgu += listNgoaiNgu[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listNgoaiNgu[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineTinHoc + 1; i < lineGDTC; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listTinHoc[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listTinHoc[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listTinHoc[k].SoTinChi + ""; sumTinHoc += listTinHoc[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listTinHoc[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineGDTC + 1; i < lineGDQP; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDTC[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDTC[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDTC[k].SoTinChi + ""; sumGDTC += listGDTC[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDTC[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineGDQP + 1; i < lineGDChuyenNghiep; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDQP[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDQP[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDQP[k].SoTinChi + ""; sumGDQP += listGDQP[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listGDQP[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineCoso + 1; i < lineChungNC; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listCoSo[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listCoSo[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listCoSo[k].SoTinChi + ""; sumKTCS += listCoSo[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listCoSo[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineChungNC + 1; i < lineSauNC; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listChungNC[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listChungNC[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listChungNC[k].SoTinChi + ""; sumKTChung += listChungNC[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listChungNC[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineSauNC + 1; i < lineKienThucNganhThu2; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listSauNC[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listSauNC[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listSauNC[k].SoTinChi + ""; sumKTChuyen += listSauNC[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listSauNC[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineKienThucNganhThu2 + 1; i < lineBoTro; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listKienThucNganhThu2[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listKienThucNganhThu2[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listKienThucNganhThu2[k].SoTinChi + ""; sumKTChuyen2 += listKienThucNganhThu2[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listKienThucNganhThu2[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineBoTro + 1; i < lineTotNghiep; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listBoTroTuDo[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listBoTroTuDo[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listBoTroTuDo[k].SoTinChi + ""; sumKTBoTro += listBoTroTuDo[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listBoTroTuDo[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            k = -1;
            for (int i = lineTotNghiep + 1; i <= rowNum; i++)
            {
                k++; countMH++;
                for (int j = 1; j <= 5; j++)
                {
                    switch (j)
                    {
                        case 1:
                            firstTable.Rows[i].Cells[j].Range.Text = countMH + "";
                            break;
                        case 2:
                            firstTable.Rows[i].Cells[j].Range.Text = listTotNghiep[k].MonHoc_Id;
                            break;
                        case 3:
                            firstTable.Rows[i].Cells[j].Range.Text = listTotNghiep[k].TenMonHoc;
                            break;
                        case 4:
                            firstTable.Rows[i].Cells[j].Range.Text = listTotNghiep[k].SoTinChi + ""; sumTotNghiep += listTotNghiep[k].SoTinChi;
                            break;
                        case 5:
                            firstTable.Rows[i].Cells[j].Range.Text = listTotNghiep[k].HocKy + "";
                            break;
                        default:
                            firstTable.Rows[i].Cells[j].Range.Text = "";
                            break;
                    }
                }
            }
            int numTC = sumLyLuan + sumXaHoi + sumNhanVan + sumNgoaiNgu + sumTinHoc + sumGDQP + sumGDTC + sumKTCS + sumKTChung + sumKTChuyen + sumKTChuyen2 + sumKTBoTro + sumTotNghiep;
            addBookMark("txtTongSo", "                                                Total                                                                          " + numTC);
            int x = -1;
            foreach (Word.Row row in firstTable.Rows)
            {
                x++;
                foreach (Word.Cell cell in row.Cells)
                {
                    int rowIndex = cell.RowIndex;
                    if (rowIndex == 1)
                    {
                        int columnIndex = cell.ColumnIndex;
                        switch (columnIndex)
                        {
                            case 1:
                                cell.Range.Text = "STT";
                                break;
                            case 2:
                                cell.Range.Text = "Mã MH";
                                break;
                            case 3:
                                cell.Range.Text = "Môn Học";
                                break;
                            case 4:
                                cell.Range.Text = "TC";
                                break;
                            case 5:
                                cell.Range.Text = "Học Kỳ";
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                        cell.Range.Font.Bold = 1;
                        x = -1;
                    }
                    else if (rowIndex == 2)
                    {
                        if (cell.ColumnIndex == 1) { cell.Range.Text = "Kiến thức giáo dục đại cương"; }
                        if (cell.ColumnIndex == 2) { cell.Range.Text = (sumLyLuan + sumXaHoi + sumNhanVan + sumNgoaiNgu + sumTinHoc + sumGDQP + sumGDTC) + ""; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; }
                        x = -1;
                    }
                    else if (rowIndex == 3)
                    {
                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Lý luận Mac-Lenin và Tư tưởng Hồ Chí Minh"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumLyLuan + ""; }
                    }
                    else if (rowIndex == lineXaHoi)
                    {
                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Khoa học Xã hội"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumXaHoi + ""; }
                    }
                    else if (rowIndex == lineNhanVanNgheThuat)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Nhân Văn - Nghệ thuật"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumNhanVan + ""; }

                    }
                    else if (rowIndex == lineNgoaiNgu)
                    {
                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Ngoại ngữ"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumNgoaiNgu + ""; }

                    }
                    else if (rowIndex == lineTinHoc)
                    {
                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Toán - Tin - Khoa học Tự Nhiên - Công Nghệ - Môi trường"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumTinHoc + ""; }
                    }
                    else if (rowIndex == lineGDTC)
                    {
                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Giáo Dục Thể Chất"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumGDTC + ""; }

                    }
                    else if (rowIndex == lineGDQP)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Giáo dục Quốc phòng - An ninh "; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumGDQP + ""; }
                    }
                    else if (rowIndex == lineGDChuyenNghiep)
                    {

                        if (cell.ColumnIndex == 1) { cell.Range.Text = "Kiến thức giáo dục chuyên nghiệp"; }
                        if (cell.ColumnIndex == 2) { cell.Range.Text = (sumKTCS + sumKTChung + sumKTChuyen + sumKTChuyen2 + sumKTBoTro + sumTotNghiep) + ""; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; }
                    }
                    else if (rowIndex == lineCoso)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Kiến thức cơ sở"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumKTCS + ""; }

                    }
                    else if (rowIndex == lineChungNC)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Kiến thức chung của ngành chính"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumKTChung + ""; }

                    }
                    else if (rowIndex == lineSauNC)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Kiến thức chuyên sâu của ngành chính"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumKTChuyen + ""; }

                    }
                    else if (rowIndex == lineKienThucNganhThu2)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Kiến thức chuyên ngành thứ hai"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumKTChuyen2 + ""; }
                    }
                    else if (rowIndex == lineBoTro)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Kiến thức bổ trợ tự do"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumKTBoTro + ""; }

                    }
                    else if (rowIndex == lineTotNghiep)
                    {

                        if (cell.ColumnIndex == 2) { cell.Range.Text = "Thực tập tốt nghiệp và làm khoá luận"; }
                        if (cell.ColumnIndex == 3) { cell.Range.Text = sumTotNghiep + ""; }

                    }
                }
            }
        }
        void createBookMarkKeHoachGiangDay()
        {
            myBookmark = bookmarks["tableKeHoachGiangDay"];
            bookmarkRange = myBookmark.Range;
            Microsoft.Office.Interop.Word.Paragraph para = doc.Paragraphs.Add(bookmarkRange);
            for (int i = 1; i <= HK; i++)
            {
                Microsoft.Office.Interop.Word.Range r = para.Range;
                r.Text = "\r";
                r.Bookmarks.Add("KH_HK" + i);
                r.InsertParagraphAfter();
            }

        }
        void mergeKeHoachGiangDay(Word.Table table, int row)
        {
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);
            table.Rows[row].Cells[1].Merge(table.Rows[row].Cells[2]);

        }
        void styleTabe(Word.Table table)
        {
            table.Range.Font.Name = "Times New Roman";
            table.Range.Font.Size = 12;
            table.Borders.Enable = 1;
        }
        void createKeHoachGiangDay(String bookmarksName, int ID_ChuongTrinhDaoTao, int HK)
        {
            List<Load_KetHoachGiangDay_MonHoc_Thinh_Result> list = entity.Load_KetHoachGiangDay_MonHoc_Thinh(ID_ChuongTrinhDaoTao, HK).ToList();
            int rowNum = list.Count + 3;
            int columNum = 7;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks[bookmarksName];
            bookmarkRange = myBookmark.Range;
            Microsoft.Office.Interop.Word.Paragraph para = doc.Paragraphs.Add(bookmarkRange);
            Microsoft.Office.Interop.Word.Range r = para.Range;
            r.InsertParagraphBefore();
            Word.Table firstTable = doc.Tables.Add(r, rowNum, columNum, ref missing, ref missing);
            styleTabe(firstTable);
            firstTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
            mergeKeHoachGiangDay(firstTable, 1);
            int x = -1;
            int sum = 0;
            int sumTongSo = 0;
            foreach (Word.Row row in firstTable.Rows)
            {
                x++;
                foreach (Word.Cell cell in row.Cells)
                {
                    int rowIndex = cell.RowIndex;
                    if (rowIndex == 1)
                    {
                        int columnIndex = cell.ColumnIndex;
                        switch (columnIndex)
                        {
                            case 1:
                                cell.Range.Text = "HỌC KÌ " + HK;
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }

                        cell.Range.Font.Bold = 1;
                    }
                    else if (rowIndex == 2)
                    {
                        int columnIndex = cell.ColumnIndex;
                        switch (columnIndex)
                        {
                            case 1:
                                cell.Range.Text = "STT";

                                break;
                            case 2:
                                cell.Range.Text = "MMH";
                                break;
                            case 3:
                                cell.Range.Text = "TÊN MÔN HỌC";
                                break;
                            case 4:
                                cell.Range.Text = "TC";
                                break;
                            case 5:
                                cell.Range.Text = "TS";
                                break;
                            case 6:
                                cell.Range.Text = "LT";
                                break;
                            case 7:
                                cell.Range.Text = "TH/BT";
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                        x = -1;
                        cell.Range.Font.Bold = 1;
                        cell.Range.Font.ColorIndex = Word.WdColorIndex.wdBlue;
                    }
                    else if (rowIndex == rowNum)
                    {
                        int columnIndex = cell.ColumnIndex;
                        switch (columnIndex)
                        {
                            case 3:
                                cell.Range.Text = "TỔNG SỐ"; cell.Range.Font.Bold = 1;
                                break;
                            case 4:
                                cell.Range.Text = sum + ""; cell.Range.Font.Bold = 1;
                                break;
                            case 5:
                                cell.Range.Text = sumTongSo + ""; cell.Range.Font.ColorIndex = Word.WdColorIndex.wdRed;
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        int column_Index = cell.ColumnIndex;
                        switch (column_Index)
                        {
                            case 1:
                                cell.Range.Text = (x + 1) + ""; cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                break;
                            case 2:
                                cell.Range.Text = list[x].MonHoc_Id;
                                break;
                            case 3:
                                cell.Range.Text = list[x].TenMonHoc + "";
                                break;
                            case 4:
                                cell.Range.Text = list[x].SoTinChi + ""; sum += list[x].SoTinChi;
                                break;
                            case 5:
                                cell.Range.Text = list[x].SoGioLyThuyet + list[x].SoGioThucHanh + ""; sumTongSo += list[x].SoGioLyThuyet + list[x].SoGioThucHanh;
                                break;
                            case 6:
                                cell.Range.Text = list[x].SoGioLyThuyet + "";
                                break;
                            case 7:
                                cell.Range.Text = list[x].SoGioThucHanh + "";
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                    }
                }
            }
        }
        void createBookMarkNoiDungVanTat()
        {
            myBookmark = bookmarks["prMoTaVanTatNoiDung"];
            bookmarkRange = myBookmark.Range;
            Microsoft.Office.Interop.Word.Paragraph para = doc.Paragraphs.Add(bookmarkRange);
            for (int i = 1; i <= HK; i++)
            {

                Microsoft.Office.Interop.Word.Range r = para.Range;
                r.Text = " HỌC KỲ " + i + "\r";
                r.Bookmarks.Add("ND" + i);
                r.Font.Size = 13;
                r.Font.Name = "Times New Roman";
                r.InsertParagraphAfter();
            }

        }
        void createMoTaVangTat()
        {
            for (int i = 1; i <= HK; i++)
            {
                List<Load_NoiDungVanTat_MonHoc_Thinh_Result> listNDVT = entity.Load_NoiDungVanTat_MonHoc_Thinh(ChuongTrinhDaoTao, i).ToList();
                List<SP_MONTIENQUYET_GETTRUE_Result> truelst = entity.SP_MONTIENQUYET_GETTRUE(ChuongTrinhDaoTao).ToList();
                
                String HKNum = "ND" + i;
                myBookmark = bookmarks[HKNum];
                bookmarkRange = myBookmark.Range;
                
                for (int j = 0; j < listNDVT.Count; j++)
                {
                    string textTienQuyet = "";
                    foreach (SP_MONTIENQUYET_GETTRUE_Result a in truelst)
                    {
                        if (listNDVT[0].Id == a.MonHoc_Id)
                        {
                            textTienQuyet += a.TenMonHoc+" ; ";
                        }
                    }
                    if (textTienQuyet == "")
                    {
                        textTienQuyet = "không có";
                    }
                    bookmarkRange.Text += ("* " + listNDVT[j].TenMonHoc + "                             (" + listNDVT[j].SoTinChi + "TC:" + listNDVT[j].SoGioLyThuyet + "lt+" + listNDVT[j].SoGioThucHanh + "th)" + "\r " + "   Môn tiên quyết: " + textTienQuyet + "\r " + "   Nội dung môn học: " + listNDVT[j].NoiDungVanTat + "\r\r");
                    bookmarkRange.Font.Size = 12;
                }
            }
            FindAndReplace(WordApp, "HỌC KỲ 1", true, true);
            for (int k = 1; k <= HK; k++)
            {
                FindAndReplace(WordApp, "HỌC KỲ " + k, true, true);

            }
        }
        void FindAndReplace(Word.Application WordApp,
                                    object findText,
                                    bool boldIt, bool underline)
        {
            object missing = Type.Missing;

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;


            WordApp.Selection.Find.Execute(ref findText,
                                           ref matchCase,
                                           ref matchWholeWord,
                                           ref matchWildCards,
                                           ref matchSoundLike,
                                           ref nmatchAllWordForms,
                                           ref forward,
                                           ref wrap,
                                           ref format,
                /*ref replaceWithText,*/ ref missing,
                /*ref replace,*/         ref missing,
                                           ref matchKashida,
                                           ref matchDiacritics,
                                           ref matchAlefHamza,
                                           ref matchControl);


            if (boldIt)
            {
                WordApp.Application.Selection.Font.Bold = 1;
            }
            if (underline)
            {
                WordApp.Application.Selection.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            }

            WordApp.Application.Selection.Font.Italic = 0;
            WordApp.Application.Selection.Font.Color = Word.WdColor.wdColorBlack;
        }

    }
    
}
