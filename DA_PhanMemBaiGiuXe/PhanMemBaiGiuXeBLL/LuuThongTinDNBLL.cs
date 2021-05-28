using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class LuuThongTinDNBLL
    {
        LuuThongTinDNDAL LTT = new LuuThongTinDNDAL();
        public LuuThongTinDNBLL()
        {

        }
        public bool ThemTTDN(string tendn, DateTime ngaydangnhap, DateTime ngaydangxuat)
        {
            return LTT.ThemTTDN(tendn, ngaydangnhap, ngaydangxuat);
        }

        public bool SuaTTDN(string tendn, DateTime ngaydangnhap, DateTime ngaydangxuat)
        {
            return LTT.SuaTTDN(tendn, ngaydangnhap, ngaydangxuat);
        }
    }
}
