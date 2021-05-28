using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class QuanLyXeRaDAL
    {
        DataClassesHTBGXDataContext HTBGX = new DataClassesHTBGXDataContext();
        public QuanLyXeRaDAL()
        {

        }
        //kiem tra the xe
        public bool ktTheXe(string mathe ,string bienso)
        {
            try
            {
                TheXe the = HTBGX.TheXes.Where(t => t.MaThe == mathe).SingleOrDefault();
                if (the.TinhTrang == true)
                {
                    GiaoTac tx = HTBGX.GiaoTacs.Where(t => t.MaThe == mathe && t.KhachHang.BienSo == bienso).SingleOrDefault();
                    if (tx == null)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool SuaLoaiGiaoTac(string mathe, DateTime thoigian, string tentk)
        {
            try
            {
                GiaoTac gt = HTBGX.GiaoTacs.Where(t => t.MaThe == mathe).SingleOrDefault();
                gt.TenTaiKhoan = tentk;
                gt.MaKH = gt.MaKH;
                gt.MaLoaiGiaoTac = 2;
                gt.ThoiGIan = thoigian;
                HTBGX.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

}
