using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class LoginDAL
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();

        public LoginDAL()
        {
        }

        public IQueryable loadAccount()
        {
            return data.TaiKhoans.Select(t => t);
        }
        
        public bool LoginType(string user,string pass,int type)
        {
            try
            {
                TaiKhoan tk = Login(user, pass);
                if (tk != null)
                {
                    int typeAcc = int.Parse(tk.LoaiTaiKhoan.ToString());
                    if (typeAcc == type)
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private TaiKhoan Login(string user,string pass)
        {
            try
            {
                TaiKhoan tk = data.TaiKhoans.Where(t => t.TenTaiKhoan.ToLower().Equals(user.ToLower()) && t.Password.ToLower().Equals(pass.ToLower())).SingleOrDefault();
                return tk;
            }
            catch
            {
                return null;
            }
        }
        
    }
}
