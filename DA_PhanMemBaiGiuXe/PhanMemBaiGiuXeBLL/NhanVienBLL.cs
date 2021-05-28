using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class NhanVienBLL
    {
        NhanVienDAL NV = new NhanVienDAL();
        public NhanVienBLL()
        {

        }
        public IQueryable loadNhanVien()
        {
            return NV.loadNhanVien();
        }
        public bool KTKhoaChinh(string manv)
        {
            return NV.KTKhoaChinh(manv);
        }
        public bool ThemNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi)
        {
            return NV.ThemNhanVien(manv, tennv, gtinh, sdt, ngaysinh, diachi,null);
        }

        public bool SuaNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi)
        {
            try
            {
                return NV.SuaNhanVien(manv, tennv, gtinh, sdt, ngaysinh, diachi,null);
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNhanVien(string manv)
        {
            return NV.XoaNhanVien(manv);
        }
        public bool LuuNhanVien()
        {
            return NV.LuuNhanVien();
        }
    }
}
