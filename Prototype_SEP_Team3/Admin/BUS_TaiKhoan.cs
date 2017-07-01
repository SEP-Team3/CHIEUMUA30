using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prototype_SEP_Team3.Admin
{
    class BUS_TaiKhoan
    {
        //check data
        public string Checkdata(string iname, string iemail, string imk, string irmk)
        {
            string rs = "";
         
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            
            if(iemail==""){
                rs+="\nEmail không được đế trống";
            }
            else{
                if (!re.IsMatch(iemail)){
                rs+="\nEmail không đúng định dạng";
                }
                else{
                    DBEntities db = new DBEntities();
                    try
                    {
                        TaiKhoan a = db.TaiKhoans.Single(x => x.Email == iemail);
                        rs += "\nEmail đã tồn tại";
                    }
                    catch
                    {

                    }
                }

            }
            if (iname == "")
            {
                rs += "\nTên không được để trống";
            }
            if (imk == "")
            {
                rs += "\nMật khẩu không được để trống";
            }
            else{
                if(imk!=irmk){
                    rs += "\nMật khẩu và Xác nhận mật khẩu không trùng khớp";
                }
            }
            if (irmk == "")
            {
                rs += "\nXác nhận mật khẩu không được để trống";
            }
            return rs;
        }
        //save
        public string SaveTK(string iname, string iemail, string imk,string irmk)
        {
            string ckrs = Checkdata(iname, iemail, imk, irmk);
            if (ckrs == "")
            {
                DBEntities db = new DBEntities();
                TaiKhoan add = new TaiKhoan();
                add.Email = iemail;
                add.Ten = iname;
                add.MatKhau = imk;
                db.TaiKhoans.Add(add);
                db.SaveChanges();
                return ckrs;
            }
            else
            {
                return ckrs;
            }
        }

        //edit
        public TaiKhoan EditTK(int id)
        {
            DBEntities db = new DBEntities();
            return db.TaiKhoans.Single(x => x.Id == id);
        }
    }
}
