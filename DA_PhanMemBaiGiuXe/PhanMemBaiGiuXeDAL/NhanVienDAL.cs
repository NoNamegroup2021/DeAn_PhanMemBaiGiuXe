using System;
using System.Collections.Generic;
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
            return data.NhanViens.Select(t=>t);
        }
        public bool KTKhoaChinh(string manv)
        {
            NhanVien nv = data.NhanViens.Where(t => t.MaNV == manv).SingleOrDefault();
            if (nv == null)
                return true;
            return false; 
        }
        public bool ThemNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi)
        {
            try {
                NhanVien NV = new NhanVien();
                NV.MaNV = manv;
                NV.TenNV = tennv;
                NV.GioiTinh = gtinh;
                NV.SDT = sdt;
                NV.NgaySinh = ngaysinh;
                NV.DiaChi = diachi;
                data.NhanViens.InsertOnSubmit(NV);
                return true;
            }
            catch {
                return false;
            }    
        }

        public bool SuaNhanVien(string manv, string tennv, string gtinh, string sdt, DateTime ngaysinh, string diachi)
        {
            try
            {
                NhanVien NV = data.NhanViens.Where(t => t.MaNV == manv).SingleOrDefault();
                NV.TenNV = tennv;
                NV.GioiTinh = gtinh;
                NV.SDT = sdt;
                NV.NgaySinh = ngaysinh;
                NV.DiaChi = diachi;
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNhanVien(string manv)
        {
            try {
                NhanVien h = data.NhanViens.Where(t => t.MaNV == manv).SingleOrDefault();
                data.NhanViens.DeleteOnSubmit(h);
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
            catch
            {
                return false;
            }
        }
    }
}
