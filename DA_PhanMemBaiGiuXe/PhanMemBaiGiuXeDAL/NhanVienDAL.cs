using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    
    public class NhanVienDAL
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        public NhanVienDAL()
        {

        }
        public IQueryable loadNhanVien()
        {
            IQueryable ds = from nv in data.NhanViens select new { nv.MaNV, nv.TenNV, nv.GioiTinh, nv.SDT, nv.NgaySinh, nv.DiaChi, nv.SoCMND};
            //IQueryable ds = data.NhanViens.Select(t=>t);
            return ds;
        }
        public bool KTKhoaChinh(string manv)
        {
            NhanVien nv = data.NhanViens.Where(t => t.MaNV == manv).SingleOrDefault();
            if (nv == null)
                return true;
            return false; 
        }
        public bool ThemNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi, string cmnd)
        {
            try {
                NhanVien NV = new NhanVien();
                NV.MaNV = manv;
                NV.TenNV = tennv;
                NV.GioiTinh = gtinh;
                NV.SDT = sdt;
                NV.NgaySinh = ngaysinh;
                NV.DiaChi = diachi;
                NV.SoCMND = cmnd;
                data.NhanViens.InsertOnSubmit(NV);
                data.SubmitChanges();
                return true;
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }    
        }

        public bool SuaNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi, string cmnd)
        {
            try
            {
                NhanVien NV = data.NhanViens.Where(t => t.MaNV == manv).SingleOrDefault();
                NV.TenNV = tennv;
                NV.GioiTinh = gtinh;
                NV.SDT = sdt;
                NV.NgaySinh = ngaysinh;
                NV.DiaChi = diachi;
                NV.SoCMND = cmnd;
                data.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool XoaNhanVien(string manv)
        {
            try {
                NhanVien h = data.NhanViens.Where(t => t.MaNV == manv).SingleOrDefault();
                data.NhanViens.DeleteOnSubmit(h);
                data.SubmitChanges();
                return true;
            } 
            catch
            {
                return false;
            }
    }
        public bool LuuNhanVien()
        {
            try
            {
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
