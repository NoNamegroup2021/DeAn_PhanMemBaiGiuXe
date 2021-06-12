using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class LichSuDangNhapDAL
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        public LichSuDangNhapDAL()
        { }
        public IQueryable loadDN()
        {
            IQueryable ds = from nv in data.DangNhaps select new { nv.TenTaiKhoan, nv.ThoiGianDangNhap, nv.ThoiGianDangXuat };
            return ds;
        }

        public IQueryable timKiem(string txtTK)
        {
            IQueryable ds = from nv in data.DangNhaps where nv.TenTaiKhoan.Contains(txtTK) || nv.ThoiGianDangNhap.ToString().Contains(txtTK) || nv.ThoiGianDangXuat.ToString().Contains(txtTK) select new { nv.TenTaiKhoan, nv.ThoiGianDangNhap, nv.ThoiGianDangXuat };
            return ds;
        }
    }
}
