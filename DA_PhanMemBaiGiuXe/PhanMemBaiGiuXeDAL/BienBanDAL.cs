using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class BienBanDAL
    {
        public BienBanDAL() { }

        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        public IQueryable getBienBan()
        {
            return data.NgoaiLes.Select(t => t);
        }

        public NgoaiLe getBienBanbyMaNL(int manl)
        {
            NgoaiLe nl = data.NgoaiLes.Where(t => t.MaNL == manl).SingleOrDefault();
            return nl;
        }
        public IQueryable getBienBanbyID(int manl)
        {
            IQueryable ds = from k in data.NgoaiLes where k.MaNL == manl select new { k };
            return ds;
        }
        public bool KTKhoaChinh(int manl)
        {
            NgoaiLe nl = data.NgoaiLes.Where(t => t.MaNL == manl).SingleOrDefault();
            if (nl == null)
                return true;
            return false;
        }
        public bool addNL(int makh, string tenkh, string cmnd, string diachi, string sdt, string tennv, DateTime ngay, string noidung)
        {
            try
            {
                NgoaiLe nl = new NgoaiLe();
                nl.MaKH = makh;
                nl.HoTenKH = tenkh;
                nl.CMND = cmnd;
                nl.DiaChi = diachi;
                nl.SDT = sdt;
                nl.TenNV = tennv;
                nl.ThoiGian = ngay;
                nl.NoiDung = noidung;
                data.NgoaiLes.InsertOnSubmit(nl);
                data.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public bool deleteNL(int manl)
        {
            try
            {
                NgoaiLe nl = data.NgoaiLes.Where(t => t.MaNL == manl).FirstOrDefault();
                if (nl == null)
                    return false;
                else
                {
                    data.NgoaiLes.DeleteOnSubmit(nl);
                    data.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool updateNL(int manl, int makh, string tenkh, string cmnd, string diachi, string sdt, string tennv, DateTime ngay, string noidung)
        {
            try
            {
                NgoaiLe nl = data.NgoaiLes.Where(t => t.MaNL == manl).FirstOrDefault();
                if (nl == null)
                    return false;
                else
                {

                    nl.MaKH = makh;
                    nl.HoTenKH = tenkh;
                    nl.CMND = cmnd;
                    nl.DiaChi = diachi;
                    nl.SDT = sdt;
                    nl.TenNV = tennv;
                    nl.ThoiGian = ngay.Date;
                    nl.NoiDung = noidung;
                    data.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
