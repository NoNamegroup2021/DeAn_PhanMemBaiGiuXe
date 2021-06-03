using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
   public class DangKyBLL
    {
       DangKyDAL DK = new DangKyDAL();
       public DangKyBLL()
       {

       }
        public IQueryable LoadTKTimKiem(string pTuKhoa)
        {
            return DK.loadTKTimKiem(pTuKhoa);
        }
        public bool DangKy(string TenTK, string Pw, string manv, int loaitk)
       {
           return DK.DangKy(TenTK, Pw, manv, loaitk);
       }
       public bool XoaTK(string manv)
       {
           return DK.XoaTK(manv);
       }
       public bool SuaTK(string TenTK, string Pw, string manv, int loaitk)
       {
           return DK.SuaTK(TenTK, Pw, manv, loaitk);
       }
       public bool KTKhoaChinh(string manv)
       {
           return DK.KTKhoaChinh(manv);
       }
    }
}
