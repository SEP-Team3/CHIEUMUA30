﻿using Prototype_SEP_Team3.Detailed_Syllabus;
using Prototype_SEP_Team3.Educational_Program;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3
{
    public partial class GUI_Chinh_BST_GVGD : Form
    {
        BUS_DCCT bus = new BUS_DCCT();
        int getTK_ID;

        public GUI_Chinh_BST_GVGD(int re)
        {
            InitializeComponent();

            getTK_ID = re;

            LoadList(re);

        }

        private void LoadList(int re)
        {
            DBEntities model = new DBEntities();

            PhanQuyenTaiKhoan pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == re);

            if (pq != null)
            {
                if (pq.ChucVu == "Ban soạn thảo")
                {
                    lstMain.DataSource = model.CTDT_Select_Sang(re);
                    lstMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                if (pq.ChucVu == "Giảng viên")
                {
                    lstMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    lstMain.DataSource = model.DCCT_Select_Sang(re);
                }


            }
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            GUI_Login login = new GUI_Login();
            login.Closed += (s, args) => this.Close();
            login.ShowDialog();
        }

        private void lstMain_DoubleClick(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            DeCuongChiTiet dcct = new DeCuongChiTiet();
            ChuongTrinhDaoTao ctdt = new ChuongTrinhDaoTao();

            if (lstMain.SelectedRows.Count == 1)
            {
                string pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == getTK_ID).ChucVu;

                if (pq == "Giảng viên")
                {
                    var row = lstMain.SelectedRows[0];
                    var cell = row.Cells[0];
                    int dcctID = (int)cell.Value;
                    dcct = model.DeCuongChiTiets.FirstOrDefault(x => x.Id == dcctID);
                    int ctdt_ID = dcct.MonHoc.ChuongTrinhDaoTao_Id;

                    GUI_DS ds = new GUI_DS(dcctID, ctdt_ID);
                    ds.ShowDialog();
                }
                else if (pq == "Ban soạn thảo")
                {
                    var row = lstMain.SelectedRows[0];
                    var cell = row.Cells[0];
                    int ctdtID = (int)cell.Value;
                    ThongTinChung_CTDT a = model.ThongTinChung_CTDT.Single(x => x.ChuongTrinhDaoTao_Id == ctdtID);
                    if (a.Finish == true)
                    {
                        GUI_EP ds = new GUI_EP(ctdtID, 1,0);
                        ds.ShowDialog();
                    }
                    else
                    {
                        GUI_EP ds = new GUI_EP(ctdtID, 0,0);
                        ds.ShowDialog();
                    }
                    
                }
               
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn đổi trạng thái hoàn thành của ĐCCT này không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {
                DBEntities model = new DBEntities();

                DeCuongChiTiet dcct = new DeCuongChiTiet();
                ThongTinChung_CTDT ttc = new ThongTinChung_CTDT();

                if (lstMain.SelectedRows.Count == 1)
                {
                    string pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == getTK_ID).ChucVu;

                    if (pq == "Giảng viên")
                    {
                        var row = lstMain.SelectedRows[0];
                        var cell = row.Cells[0];
                        int dcctID = (int)cell.Value;
                        dcct = model.DeCuongChiTiets.FirstOrDefault(x => x.Id == dcctID);
                        if (dcct.TenDCCT != null && dcct.TenTiengAnh != null && dcct.MonHoc_Id != null && dcct.TrinhDo != null && dcct.PhanBoThoiGian != null && dcct.YeuCauMonHoc != null && dcct.KhoiKienThuc != null)
                        {
                            if (dcct.Finish == true)
                            {
                                bool flag = bus.Update_Finish_2(dcctID, false);
                                if (flag == true)
                                {
                                    MessageBox.Show("Cập nhật thành công");
                                }
                                lstMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                lstMain.DataSource = model.DCCT_Select_Sang(getTK_ID);
                            }
                            else
                            {
                                bool flag = bus.Update_Finish_2(dcctID, true);
                                if (flag == true)
                                {
                                    MessageBox.Show("Cập nhật thành công");
                                }
                                lstMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                lstMain.DataSource = model.DCCT_Select_Sang(getTK_ID);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đề cương chi tiết chưa đủ các thông tin cần thiết", "Thông báo");
                        }
                        
                    }

                    else if (pq == "Ban soạn thảo")
                    {
                        var row = lstMain.SelectedRows[0];
                        var cell = row.Cells[0];
                        int ctdtID = (int)cell.Value;
                        ttc = model.ThongTinChung_CTDT.FirstOrDefault(x => x.ChuongTrinhDaoTao_Id==ctdtID);
                        if((ttc.TenChuongTrinh!=null)&&(ttc.TenTiengAnh!=null)&&ttc.TrinhDo!=null&&ttc!=null&&ttc.LoaiHinh!=null&&ttc.ThoiGianDaoTao!=0
                            && ttc.ThangDiem != 0 && ttc.KhoiLuongKienThucToanKhoa != null && ttc.DoiTuongTuyenSinh != null && ttc.QuyTrinhDaoTao != null && ttc.CoSoVatChat != null)
                        {
                            if (ttc.Finish == true)
                            {
                                bool flag = bus.Update_Finish_CTDT(ctdtID, false);
                                if (flag == true)
                                {
                                    MessageBox.Show("Cập nhật thành công");
                                }
                                lstMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                lstMain.DataSource = model.CTDT_Select_Sang(getTK_ID);
                            }
                            else
                            {
                                bool flag = bus.Update_Finish_CTDT(ctdtID, true);
                                if (flag == true)
                                {
                                    MessageBox.Show("Cập nhật thành công");
                                }
                                lstMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                lstMain.DataSource = model.CTDT_Select_Sang(getTK_ID);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Chương trình đào tạo chưa đủ các thông tin cần thiết","Thông báo");
                        }
                        
                    }
                    
                }
            }
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            string pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == getTK_ID).ChucVu;

            if (pq == "Giảng viên")
            {
                if (cboLoc.SelectedItem == "Đã hoàn thành")
                {
                    lstMain.DataSource = model.DCCT_SelectFinishTrue_Sang(getTK_ID);
                }
                else if (cboLoc.SelectedItem == "Chưa hoàn thành")
                {
                    lstMain.DataSource = model.DCCT_SelectFinishFalse_Sang(getTK_ID);
                }
                else if (cboLoc.SelectedItem == "Tất cả")
                {
                    lstMain.DataSource = model.DCCT_Select_Sang(getTK_ID);
                }
            }

            else if (pq == "Ban soạn thảo")
            {
                if (cboLoc.SelectedItem == "Đã hoàn thành")
                {
                    lstMain.DataSource = model.CTDT_SelectFinishTrue_Sang(getTK_ID);
                }
                else if (cboLoc.SelectedItem == "Chưa hoàn thành")
                {
                    lstMain.DataSource = model.CTDT_SelectFinishFalse_Sang(getTK_ID);
                }
                else if (cboLoc.SelectedItem == "Tất cả")
                {
                    lstMain.DataSource = model.CTDT_Select_Sang(getTK_ID);
                }
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DBEntities model = new DBEntities();

            string pq = model.PhanQuyenTaiKhoans.FirstOrDefault(x => x.TaiKhoan_Id == getTK_ID).ChucVu;

            if (pq == "Giảng viên")
            {
                lstMain.DataSource = model.Search_DCCT_Sang(textBox1.Text, getTK_ID);
            }
            else if (pq == "Ban soạn thảo")
            {
                lstMain.DataSource = model.Search_CTDT_Sang(textBox1.Text, getTK_ID);
            }
        }
    }
}
