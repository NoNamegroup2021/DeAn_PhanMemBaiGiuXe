using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
   public class DangKyDAL
    {
       DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
       public DangKyDAL()
       {

       }

       public bool DangKy(string TenTK, string Pw, string manv, int loaitk)
       {
           try
           {
               TaiKhoan tk = new TaiKhoan();
               tk.TenTaiKhoan = TenTK;
               tk.Password = Pw;
               tk.MaNV = manv;
               tk.LoaiTaiKhoan = loaitk;
               data.TaiKhoans.InsertOnSubmit(tk);
               data.SubmitChanges();
               return true;
           }
           catch(Exception ex)
           {
               Console.WriteLine(ex.Message);
               return false;
           }
       }
       public bool XoaTK(string manv)
       {
           try
           {
               TaiKhoan tk = data.TaiKhoans.Where(t => t.TenTaiKhoan == manv).SingleOrDefault();
               data.TaiKhoans.DeleteOnSubmit(tk);
               data.SubmitChanges();
               return true;
           }
           catch
           {
               return false;
           }
       }
       public bool SuaTK(string TenTK, string Pw, string manv, int loaitk)
       {
           try
           {
               TaiKhoan tk = new TaiKhoan();
               tk.TenTaiKhoan = TenTK;
               tk.Password = Pw;
               tk.MaNV = manv;
               tk.LoaiTaiKhoan = loaitk;
               data.SubmitChanges();
               return true;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               return false;
           }
       }
       public bool KTKhoaChinh(string manv)
       {
           TaiKhoan tk = data.TaiKhoans.Where(t => t.TenTaiKhoan == manv).SingleOrDefault();
           if (manv == null)
               return true;
           return false;
       }
        public IQueryable loadTKTimKiem(string pTuKhoa)
        {
            IQueryable ds = from k in data.TaiKhoans where k.TenTaiKhoan.Contains(pTuKhoa) || k.Password.Contains(pTuKhoa) || k.MaNV.Contains(pTuKhoa) select new { k.TenTaiKhoan, k.Password, k.MaNV};
            return ds;
        }
    }
}
