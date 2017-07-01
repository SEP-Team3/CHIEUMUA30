using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
namespace Prototype_SEP_Team3.Detailed_Syllabus
{
    class ExportDocument
    {
        public ExportDocument(int decuongchitietId, int chuongtrinhdaotaoId, String path)
        {
            this.DeCuongChiTietID = decuongchitietId;
            this.ChuongTrinhDaoTao = chuongtrinhdaotaoId;
            this.path = path;
        }
        int DeCuongChiTietID = 1;
        int ChuongTrinhDaoTao = 1;
        String path;
        static Word.Application WordApp = new Word.Application();
        static Word.Document doc = null;
        static Word.Bookmarks bookmarks = null;
        static Word.Bookmark myBookmark = null;
        static Word.Range bookmarkRange = null;
        static DBEntities entity = new DBEntities();
        void checkLoaiKienThuc()
        {

            List<DeCuongChiTiet> list = entity.DeCuongChiTiets.Where(i => i.Id == DeCuongChiTietID).ToList();
            String kienthuc = list[0].KhoiKienThuc.ToString();
            if (kienthuc[0].Equals('1'))
            {
                myBookmark = bookmarks["cbDaiCuong"];
                bookmarkRange = myBookmark.Range;
                Word.FormField checkBox1 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                checkBox1.CheckBox.Value = true;
                if (kienthuc[2] == '1')
                {
                    myBookmark = bookmarks["cbDCBatBuot"];
                    bookmarkRange = myBookmark.Range;
                    Word.FormField checkBox2 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                    checkBox2.CheckBox.Value = true;
                }
                if (kienthuc[2] != '0' && kienthuc[2] != '1')
                {
                    myBookmark = bookmarks["cbDCTuChon"];
                    bookmarkRange = myBookmark.Range;
                    Word.FormField checkBox3 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                    checkBox3.CheckBox.Value = true;
                }
            }
            if (kienthuc[0].Equals('2') && kienthuc[1].Equals('1'))
            {
                myBookmark = bookmarks["cbGiaoDucChuyenNghiep"];
                bookmarkRange = myBookmark.Range;
                Word.FormField checkBoxChuyenNghiep = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                checkBoxChuyenNghiep.CheckBox.Value = true;
                myBookmark = bookmarks["cbCoSoNganh"];
                bookmarkRange = myBookmark.Range;
                Word.FormField checkBox1 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                checkBox1.CheckBox.Value = true;
                if (kienthuc[2] == '1')
                {
                    myBookmark = bookmarks["cbCoSoNganhBatBuoc"];
                    bookmarkRange = myBookmark.Range;
                    Word.FormField checkBox2 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                    checkBox2.CheckBox.Value = true;
                }
                if (kienthuc[2] != '0' && kienthuc[2] != '1')
                {
                    myBookmark = bookmarks["cbCoSoNganhTưChon"];
                    bookmarkRange = myBookmark.Range;
                    Word.FormField checkBox3 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                    checkBox3.CheckBox.Value = true;
                }
            }
            if (kienthuc[0].Equals('2'))
            {
                if (kienthuc[1].Equals('2') || kienthuc[1].Equals('3'))
                {
                    myBookmark = bookmarks["cbGiaoDucChuyenNghiep"];
                    bookmarkRange = myBookmark.Range;
                    Word.FormField checkBoxChuyenNghiep = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                    checkBoxChuyenNghiep.CheckBox.Value = true;
                    myBookmark = bookmarks["cbChuyenNganh"];
                    bookmarkRange = myBookmark.Range;
                    Word.FormField checkBox = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                    checkBox.CheckBox.Value = true;
                    if (kienthuc[2].Equals('1'))
                    {
                        myBookmark = bookmarks["cbChuyenNganhBatBuoc"];
                        bookmarkRange = myBookmark.Range;
                        Word.FormField checkBox1 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                        checkBox1.CheckBox.Value = true;
                    }
                    if (kienthuc[2] != '0' && kienthuc[2] != '1')
                    {
                        myBookmark = bookmarks["cbChuyenNganhTuChon"];
                        bookmarkRange = myBookmark.Range;
                        Word.FormField checkBox1 = doc.FormFields.Add(bookmarkRange, Word.WdFieldType.wdFieldFormCheckBox);
                        checkBox1.CheckBox.Value = true;
                    }
                }
            }
        }
        public Boolean exportWord()
        {
            try
            {
                WordApp.Visible = false;
                string c = Directory.GetCurrentDirectory();
                WordApp.Documents.Open(Path.Combine(c, "DCCTTemplate.docx"));
                doc = WordApp.ActiveDocument;
                bookmarks = doc.Bookmarks;
                insertInfomation();
                insertTableMaTranCDRMH_CTDT("tableMaTran_CDRMH_CTDT");
                insertParagraphTaiLieuMonHoc();
                insertParagraphChuanDauRa();
                insertParagraphMucTieuMonHoc();
                insertTablePPDanhGia(entity.Load_PPDanhGia_Thinh(DeCuongChiTietID).ToList());
                insertTableKeHoachGiangDay();
                insertTableKeHoachKiemTra(entity.Load_KeHoachKiemTra_Thinh(DeCuongChiTietID).ToList());
                insertTableMaTran_ChuanDauRaMH_HDGDPPDG();
                doc.SaveAs2(path);
                WordApp.Documents.Close();
                WordApp.Quit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        void insertInfomation()
        {
            List<Load_DCCT_Thinh_Result> list = entity.Load_DCCT_Thinh(DeCuongChiTietID).ToList();
            List<SP_MONTIENQUYET_GETTRUE_Result> truelst = entity.SP_MONTIENQUYET_GETTRUE(ChuongTrinhDaoTao).ToList();
            List<DeCuongChiTiet> listDeChuongChiTiet = entity.DeCuongChiTiets.Where(i => i.Id == DeCuongChiTietID).ToList();
            string textTienQuyet = "";
            foreach (SP_MONTIENQUYET_GETTRUE_Result a in truelst)
            {
                int n = listDeChuongChiTiet[0].MonHoc_Id.Value;
                if (n == a.MonHoc_Id)
                {
                    textTienQuyet += "- " + a.TenMonHoc + "\r";
                }
            }
            if (textTienQuyet == "")
            {
                textTienQuyet = "không có";
            }
            addBookMark("tenhocphan", list[0].TenDCCT);
            addBookMark("tentienganh", list[0].TenTiengAnh);
            addBookMark("mahocphan", list[0].MonHoc_Id);
            addBookMark("GiangVienPhuTrach", list[0].TenGV);
            addBookMark("DiaChiCoQuan", list[0].DiaChi + "");
            if (list[0].TroGiang == null)
            {
                addBookMark("TroGiang", "khong");
            }
            else
            {
                addBookMark("TroGiang", list[0].TroGiang);
            }
            addBookMark("DienThoaiLienHe", list[0].DienThoai);
            addBookMark("Email", list[0].Email + "");
            addBookMark("ThoiGianHoc", list[0].ThoiGian);
            addBookMark("Email2", list[0].Email + "");
            addBookMark("TC", list[0].SoTinChi + "");
            addBookMark("TrinhDo", list[0].TrinhDo);
            addBookMark("phanbo", list[0].PhanBoThoiGian);
            addBookMark("YeuCauMonHoc", list[0].YeuCauMonHoc);
            addBookMark("TienQuyet", textTienQuyet);
            addBookMark("MT_VanTatHocPhan", list[0].NoiDungVanTat);
            checkLoaiKienThuc();
        }
        void insertTableMaTranCDRMH_CTDT(String bookmarkName)
        {
            List<MaTran_CDRMH_CDRCTDT> ilst = entity.MaTran_CDRMH_CDRCTDT.Where(x => x.DCCT_Id == DeCuongChiTietID).ToList();
            List<MucTieuDaoTao> lst1 = entity.MucTieuDaoTaos.Where(x => x.ChuongTrinhDaoTao_Id == ChuongTrinhDaoTao && x.Loai != "Chung").ToList();
            List<ChuanDauRaMonHoc> lst2 = entity.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == DeCuongChiTietID).ToList();
            int columNum = lst1.Count + 1;
            int rowNum = lst2.Count + 1;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks[bookmarkName];
            bookmarkRange = myBookmark.Range;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            style(firstTable);
            firstTable.Rows[1].Cells[1].Range.Text = "CĐR";
            firstTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);

            for (int i = 0; i < lst1.Count; i++)
            {
                if (lst1[i].Loai == "Phẩm chất")
                {
                    firstTable.Rows[1].Cells[(i + 2)].Range.Text = "1." + lst1[i].STT.ToString() + "";
                };
                if (lst1[i].Loai == "Kiến thức")
                {
                    firstTable.Rows[1].Cells[(i + 2)].Range.Text = "2." + lst1[i].STT.ToString() + "";
                };
                if (lst1[i].Loai == "Kỹ năng")
                {
                    firstTable.Rows[1].Cells[(i + 2)].Range.Text = "3." + lst1[i].STT.ToString() + "";
                };
                if (lst1[i].Loai == "Thái độ")
                {
                    firstTable.Rows[1].Cells[(i + 2)].Range.Text = "4." + lst1[i].STT.ToString() + "";
                };
            }
            int row = 2;
            for (int i = 0; i < lst2.Count; i++)
            {
                int col = 1;
                firstTable.Rows[row].Cells[col].Range.Text = lst2[i].STT.ToString() + "";
                col++;
                foreach (MucTieuDaoTao a in lst1)
                {
                    int f1 = a.Id;
                    int f2 = lst2[i].Id;
                    List<MaTran_CDRMH_CDRCTDT> findlst = ilst.Where(x => x.CDRCTDT_Id == f1 && x.CDRMH_Id == f2).ToList();
                    string mapstr = "";
                    if (findlst.Count == 1)
                    {
                        if (findlst[0].Mapped == true)
                        {
                            mapstr = "X";
                        }
                        firstTable.Rows[row].Cells[col].Range.Text = mapstr + ""; firstTable.Rows[row].Cells[col].VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    }
                    if (findlst.Count == 0)
                    {
                        firstTable.Rows[row].Cells[col].Range.Text = mapstr + "";
                    }
                    col++;
                }
                row++;
            }
        }
        void insertParagraphTaiLieuMonHoc()
        {
            myBookmark = bookmarks["TL_GiaoTrinh"];
            bookmarkRange = myBookmark.Range;
            List<Load_TaiLieu_MonHoc_Thinh_Result> listTaiLieu = entity.Load_TaiLieu_MonHoc_Thinh(DeCuongChiTietID, "Sách/Giáo trình chính").ToList();
            for (int i = listTaiLieu.Count - 1; i >= 0; i--)
            {
                bookmarkRange.Text += (listTaiLieu[i].STT + ".  " + listTaiLieu[i].NoiDung + "\r");
            }
            myBookmark = bookmarks["TL_ThamKhao"];
            bookmarkRange = myBookmark.Range;
            List<Load_TaiLieu_MonHoc_Thinh_Result> listTaiLieuThamKhao = entity.Load_TaiLieu_MonHoc_Thinh(DeCuongChiTietID, "Sách/Giáo trình tham khảo").ToList();
            for (int i = 0; i < listTaiLieuThamKhao.Count; i++)
            {
                bookmarkRange.Text += (listTaiLieuThamKhao[i].STT + ".  " + listTaiLieuThamKhao[i].NoiDung + "\r");
            }
            myBookmark = bookmarks["TL_TrucTuyen"];
            bookmarkRange = myBookmark.Range;
            List<Load_TaiLieu_MonHoc_Thinh_Result> listTaiLieuTrucTuyen = entity.Load_TaiLieu_MonHoc_Thinh(DeCuongChiTietID, "Tư liệu trực tuyến").ToList();
            for (int i = 0; i < listTaiLieuTrucTuyen.Count; i++)
            {
                bookmarkRange.Text += (listTaiLieuTrucTuyen[i].STT + ".  " + listTaiLieuTrucTuyen[i].NoiDung + "\r");
            }

        }
        void insertParagraphChuanDauRa()
        {
            myBookmark = bookmarks["ChuanDauRaMH"];
            bookmarkRange = myBookmark.Range;
            List<ChuanDauRaMonHoc> listChuanDauRa = entity.ChuanDauRaMonHocs.Where(j => j.DeCuongChiTiet_Id == DeCuongChiTietID).ToList();
            for (int i = 0; i < listChuanDauRa.Count; i++)
            {
                bookmarkRange.Text += (listChuanDauRa[i].STT + ".  " + listChuanDauRa[i].NoiDung + "\r");
            }
        }
        void insertParagraphMucTieuMonHoc()
        {
            myBookmark = bookmarks["MT_KyNang"];
            bookmarkRange = myBookmark.Range;
            List<Load_MucTieuMonHoc_Thinh_Result> listMucTieu = entity.Load_MucTieuMonHoc_Thinh(DeCuongChiTietID, "Kỹ năng").ToList();
            for (int i = 0; i < listMucTieu.Count; i++)
            {
                bookmarkRange.Text += (listMucTieu[i].STT + ".  " + listMucTieu[i].NoiDung + "\r");
            }
            myBookmark = bookmarks["MT_KienThuc"];
            bookmarkRange = myBookmark.Range;
            List<Load_MucTieuMonHoc_Thinh_Result> listKienThuc = entity.Load_MucTieuMonHoc_Thinh(DeCuongChiTietID, "Kiến thức").ToList();
            for (int i = 0; i < listKienThuc.Count; i++)
            {
                bookmarkRange.Text += (listKienThuc[i].STT + ".  " + listKienThuc[i].NoiDung + "\r");
            }
            myBookmark = bookmarks["MT_ThaiDo"];
            bookmarkRange = myBookmark.Range;
            List<Load_MucTieuMonHoc_Thinh_Result> listThaiDo = entity.Load_MucTieuMonHoc_Thinh(DeCuongChiTietID, "Thái độ").ToList();
            for (int i = 0; i < listThaiDo.Count; i++)
            {
                bookmarkRange.Text += (listThaiDo[i].STT + ".  " + listThaiDo[i].NoiDung + "\r");
            }
        }
        void addBookMark(String bookmakeName, String data)
        {
            myBookmark = bookmarks[bookmakeName];
            bookmarkRange = myBookmark.Range;
            bookmarkRange.Text = data;
        }
        void style(Word.Table table)
        {
            table.Range.Font.Name = "Arial Unicode MS";
            table.Range.Font.Size = 12;
            table.Borders.Enable = 1;
        }
        void insertTablePPDanhGia(List<Load_PPDanhGia_Thinh_Result> list)
        {
            int rowNum = list.Count() + 2;
            int columNum = 4;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks["tablePPDanhGia"];
            bookmarkRange = myBookmark.Range;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            style(firstTable);
            firstTable.Columns[1].PreferredWidth = 170;
            firstTable.Columns[2].PreferredWidth = 100;
            firstTable.Columns[3].PreferredWidth = 90;
            firstTable.Columns[4].PreferredWidth = 130;
            int x = -1;
            int sumTrongSo = 0;
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
                                cell.Range.Text = "Những nội dung cần đánh giá";
                                break;
                            case 2:
                                cell.Range.Text = "Số lần đánh giá";
                                break;
                            case 3:
                                cell.Range.Text = "Trọng số (%)";
                                break;
                            case 4:
                                cell.Range.Text = "Hình thức đánh giá";
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                        cell.Range.Font.Bold = 1;
                        cell.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        x = -1;
                    }
                    else if (rowIndex == rowNum)
                    {
                        int column_Index = cell.ColumnIndex;
                        switch (column_Index)
                        {
                            case 3:
                                cell.Range.Text = sumTrongSo + " %"; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                    }

                    else
                    {
                        int column_Index = cell.ColumnIndex;
                        switch (column_Index)
                        {
                            case 1:
                                cell.Range.Text = list[x].LoaiNoiDung;
                                break;
                            case 2:
                                cell.Range.Text = list[x].SoLanDanhGia; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                break;
                            case 3:
                                cell.Range.Text = list[x].TrongSo + ""; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; sumTrongSo += list[x].TrongSo.Value;
                                break;
                            case 4:
                                cell.Range.Text = list[x].HinhThucDanhGia;
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                    }
                }
            }
        }
        void insertTableKeHoachGiangDay()
        {
            List<KeHoachGDHTCuThe> list = entity.KeHoachGDHTCuThes.Where(i => i.DeCuongChiTiet_Id == DeCuongChiTietID).ToList();
            int rowNum = list.Count + 1;
            int columNum = 5;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks["tableKHGG"];
            bookmarkRange = myBookmark.Range;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            style(firstTable);
            firstTable.Columns[1].PreferredWidth = 100;
            firstTable.Columns[2].PreferredWidth = 60;
            firstTable.Columns[3].PreferredWidth = 170;
            firstTable.Columns[4].PreferredWidth = 100;
            firstTable.Columns[5].PreferredWidth = 95;
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
                                cell.Range.Text = "Tuần/Ngày/Buôi";

                                break;
                            case 2:
                                cell.Range.Text = "Số tiết trên lớp";
                                break;
                            case 3:
                                cell.Range.Text = "Nội dung bài học";
                                break;
                            case 4:
                                cell.Range.Text = "Hoạt động dạy và học";
                                break;
                            case 5:
                                cell.Range.Text = "Tài tài liệu cần đọc";
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                        cell.Range.Font.Bold = 1;
                        cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        x = -1;
                    }
                    else
                    {
                        int column_Index = cell.ColumnIndex;
                        switch (column_Index)
                        {
                            case 1:
                                cell.Range.Text = list[x].Buoi; cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                break;
                            case 2:
                                cell.Range.Text = list[x].SoTietLenLop + ""; cell.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; cell.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                                break;
                            case 3:
                                cell.Range.Text = list[x].NoiDungBaiHoc;
                                break;
                            case 4:
                                cell.Range.Text = list[x].HoatDongDayVaHoc;
                                break;
                            case 5:
                                cell.Range.Text = list[x].TaiLieuCanDoc;
                                break;
                            default:
                                cell.Range.Text = "";
                                break;
                        }
                    }
                }
            }
        }
        void insertTableKeHoachKiemTra(List<Load_KeHoachKiemTra_Thinh_Result> list)
        {
            int rowNum = list.Count() + 1;
            int columNum = 4;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks["tableHinhThucKiemTra"];
            bookmarkRange = myBookmark.Range;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            style(firstTable);
            firstTable.Columns[1].PreferredWidth = 70;
            firstTable.Columns[2].PreferredWidth = 280;
            firstTable.Columns[3].PreferredWidth = 70;
            firstTable.Columns[4].PreferredWidth = 80;
            int x = -1;
            foreach (Word.Row row in firstTable.Rows)
            {
                x++;
                foreach (Word.Cell cell in row.Cells)
                {
                    int rowIndex = cell.RowIndex;
                    switch (rowIndex)
                    {
                        case 1:
                            int columnIndex = cell.ColumnIndex;
                            switch (columnIndex)
                            {
                                case 1:
                                    cell.Range.Text = "Hình thức";
                                    break;
                                case 2:
                                    cell.Range.Text = "Nội dung";
                                    break;
                                case 3:
                                    cell.Range.Text = "Thời điểm";
                                    break;
                                case 4:
                                    cell.Range.Text = "Công cụ KT";
                                    break;
                                default:
                                    cell.Range.Text = "";
                                    break;
                            }
                            cell.Range.Font.Bold = 1;
                            cell.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            x = -1;
                            break;
                        default:
                            int column_Index = cell.ColumnIndex;
                            switch (column_Index)
                            {
                                case 1:
                                    cell.Range.Text = list[x].HinhThuc;
                                    break;
                                case 2:
                                    cell.Range.Text = list[x].NoiDung;
                                    break;
                                case 3:
                                    cell.Range.Text = list[x].ThoiDiem;
                                    break;
                                case 4:
                                    cell.Range.Text = list[x].CongCuKT;
                                    break;
                                default:
                                    cell.Range.Text = "";
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        void insertTableMaTran_ChuanDauRaMH_HDGDPPDG()
        {
            List<MaTran_ChuanDauRaMH_HDGDPPDG> list = entity.MaTran_ChuanDauRaMH_HDGDPPDG.ToList();
            List<ChuanDauRaMonHoc> lst1 = entity.ChuanDauRaMonHocs.Where(x => x.DeCuongChiTiet_Id == DeCuongChiTietID).ToList();
            int rowNum = lst1.Count + 1;
            int columNum = 3;
            object missing = System.Reflection.Missing.Value;
            myBookmark = bookmarks["tableMaTran_CDRMH_HDGG"];
            bookmarkRange = myBookmark.Range;
            Word.Table firstTable = doc.Tables.Add(bookmarkRange, rowNum, columNum, ref missing, ref missing);
            style(firstTable);
            firstTable.Columns[1].PreferredWidth = 40;
            firstTable.Columns[2].PreferredWidth = 300;
            firstTable.Rows[1].Cells[1].Range.Text = "CĐR";
            firstTable.Rows[1].Cells[2].Range.Text = "Các hoạt động dạy và học";
            firstTable.Rows[1].Cells[3].Range.Text = "Phương pháp kiểm tra,đánh giá sinh viên";
            int rd = 2;
            foreach (ChuanDauRaMonHoc a in lst1)
            {
                int cd = 1;
                firstTable.Rows[rd].Cells[cd].Range.Text = a.STT + "";
                cd++;
                int aint = a.Id;
                List<MaTran_ChuanDauRaMH_HDGDPPDG> dlst = list.Where(x => x.ChuanDauRaMonHoc_Id == aint).ToList();
                string hdstr = "";
                string ppstr = "";
                if (dlst.Count > 0)
                {
                    foreach (MaTran_ChuanDauRaMH_HDGDPPDG b in dlst)
                    {
                        if (b.Loai == "Các hoạt động dạy và học")
                        {
                            hdstr += b.NoiDung + "\n";
                        }
                        else
                        {
                            ppstr += b.NoiDung + "\n";
                        }
                    }
                    firstTable.Rows[rd].Cells[cd].Range.Text = hdstr;
                    cd++;
                    firstTable.Rows[rd].Cells[cd].Range.Text = ppstr;
                }
                else
                {
                    firstTable.Rows[rd].Cells[cd].Range.Text = hdstr;
                    cd++;
                    firstTable.Rows[rd].Cells[cd].Range.Text = ppstr;
                }
                rd++;
            }

        }
    }
}
