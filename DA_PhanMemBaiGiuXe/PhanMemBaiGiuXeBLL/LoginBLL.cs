using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class LoginBLL
    {
        private LoginDAL data = new LoginDAL();

        public LoginBLL()
        {
            
        }

         public bool log(string user,string mk,int type)
        {
            return data.LoginType(user, mk, type);
        }
    }
}
