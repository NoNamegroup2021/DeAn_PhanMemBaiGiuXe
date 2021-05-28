using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class LuuThongTinDNDAL
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        public LuuThongTinDNDAL()
        {

        }

        public bool ThemTTDN(string tendn, DateTime ngaydangnhap, DateTime ngaydangxuat)
        {
            try
            {
                DangNhap dn = new DangNhap();
                dn.TenTaiKhoan = tendn;
                dn.ThoiGianDangNhap = ngaydangnhap;
                dn.ThoiGianDangXuat = ngaydangxuat;
                data.DangNhaps.InsertOnSubmit(dn);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaTTDN(string tendn, DateTime ngaydangnhap, DateTime ngaydangxuat)
        {
            try
            {
                DangNhap dn = data.DangNhaps.Where(t => t.TenTaiKhoan == tendn && t.ThoiGianDangNhap == ngaydangnhap).SingleOrDefault();
                DangNhap new_dn = dn;
                new_dn.ThoiGianDangXuat = ngaydangxuat;
    
                data.DangNhaps.DeleteOnSubmit(dn);

                data.DangNhaps.InsertOnSubmit(new_dn);

                data.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
