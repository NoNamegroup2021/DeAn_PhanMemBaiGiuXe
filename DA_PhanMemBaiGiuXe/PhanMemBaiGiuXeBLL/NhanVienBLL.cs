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
        public string getTenNhanVienbyMaNV(string manv)
        {
            return NV.getTenNhanVienbyMaNV(manv);
        }
        public IQueryable loadNhanVien()
        {
            return NV.loadNhanVien();
        }
        public bool KTKhoaChinh(string manv)
        {
            return NV.KTKhoaChinh(manv);
        }
        public bool ThemNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi, string cmnd)
        {
            return NV.ThemNhanVien(manv, tennv, gtinh, sdt, ngaysinh, diachi,cmnd);
        }

        public bool SuaNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi, string cmnd)
        {
            try
            {
                return NV.SuaNhanVien(manv, tennv, gtinh, sdt, ngaysinh, diachi, cmnd);
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
