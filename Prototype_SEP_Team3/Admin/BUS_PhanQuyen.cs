using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Admin
{
    class BUS_PhanQuyen
    {
        DBEntities model = new DBEntities();

        public bool TaoPhanQuyen(int tk_ID, string chucVu)
        {
            bool flag = false;
            try
            {
                model.Authorize_Create_Sang(tk_ID, chucVu);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool CapNhatPhanQuyen(int tk_ID, string chucVu)
        {
            bool flag = false;
            try
            {
                model.Authorize_Update_Sang(tk_ID, chucVu);
                model.SaveChanges();
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public List<Authorize_Search_Sang_Result> Search(string input)
        {
            DBEntities model = new DBEntities();
            return model.Authorize_Search_Sang(input).ToList();
        }
    }
}
