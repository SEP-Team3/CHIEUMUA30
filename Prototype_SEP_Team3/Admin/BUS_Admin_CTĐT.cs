using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype_SEP_Team3.Admin
{
    class BUS_Admin_CTĐT
    {
        DBEntities db = new DBEntities();
        public void loadNguoiTaoCTDT(ComboBox cbbNguoiTaoCTDT)
        {
            DBEntities db = new DBEntities();
            List<PhanQuyenTaiKhoan> lstpq = db.PhanQuyenTaiKhoans.Where(x => x.ChucVu == "Ban soạn thảo").ToList();
            if (lstpq.Count > 0)
            {
                List<TaiKhoan> c = new List<TaiKhoan>();
                foreach (PhanQuyenTaiKhoan a in lstpq)
                {
                    TaiKhoan b = db.TaiKhoans.Single(x => x.Id == a.TaiKhoan_Id);
                    c.Add(b);
                    cbbNguoiTaoCTDT.DataSource = c;

                    cbbNguoiTaoCTDT.ValueMember = "id";
                    cbbNguoiTaoCTDT.DisplayMember = "Ten";
                }
            }
            
            


        }
        public void loadInfo(TextBox txtCTDT, ComboBox cbbNguoiTaoCTDT, CheckBox chkEnable, ComboBox cbbCopyCTDT, DataGridView lstCTDT)
        {
            DBEntities db = new DBEntities();
            ChuongTrinhDaoTao ctdt = new ChuongTrinhDaoTao();
            if (lstCTDT.SelectedRows.Count == 1)
            {
                var row = lstCTDT.SelectedRows[0];
                var cell = row.Cells["id"];
                int ID = (int)cell.Value;

                ctdt = db.ChuongTrinhDaoTaos.Single(st => st.Id == ID);
                txtCTDT.Text = ctdt.TenCTDT.ToString();
                cbbNguoiTaoCTDT.SelectedValue = ctdt.NguoiPhuTrach_Id;

                if (ctdt.CopyTuCTDT == null)
                {
                    chkEnable.Checked = false;
                    cbbCopyCTDT.Enabled = false;
                    
                }
                else
                {
                    chkEnable.Checked = true;
                    cbbCopyCTDT.Enabled = true;
                    cbbCopyCTDT.SelectedValue = ctdt.CopyTuCTDT;
                }
            }
        }
        public void loadCopyCTDT(ComboBox cbbCopyCTDT)
        {
            DBEntities db = new DBEntities();
            cbbCopyCTDT.DataSource = db.ChuongTrinhDaoTaos.ToList();
            cbbCopyCTDT.ValueMember = "id";
            cbbCopyCTDT.DisplayMember = "TenCTDT";


        }
        public List<Admin_CTDTSelectAll_Result> loadListCTDT()
        {
            DBEntities db = new DBEntities();

            return db.Admin_CTDTSelectAll().ToList();
        }

        public bool createCTDT(String TenCTDT, int NguoiPhucTrachID, Nullable<int> CopyTuCTDT)
        {
            bool flag = false;
            try
            {
                db.Admin_createCTDT_Thinh(TenCTDT, NguoiPhucTrachID, CopyTuCTDT);
                db.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool updateCTDT(int id, String TenCTDT, int NguoiPhucTrachID, int CopyTuCTDT)
        {
            bool flag = false;
            try
            {
                db.Admin_updateCTDT_Thinh(id, TenCTDT, NguoiPhucTrachID, CopyTuCTDT);
                db.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        public List<Admin_CTDTSearch_Result> searchCTDT(String keyword)
        {
            DBEntities db = new DBEntities();
            return db.Admin_CTDTSearch(keyword).ToList();
        }
    }
}
