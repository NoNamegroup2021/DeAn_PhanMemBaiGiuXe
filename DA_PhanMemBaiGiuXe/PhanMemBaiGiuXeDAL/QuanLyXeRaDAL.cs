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
                    ChiTietLanXe tx = HTBGX.ChiTietLanXes.Where(t => t.MaThe == mathe && t.KhachHang.BienSo == bienso).SingleOrDefault();
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
                ChiTietLanXe gt = HTBGX.ChiTietLanXes.Where(t => t.MaThe == mathe).SingleOrDefault();
                gt.TenTaiKhoan = tentk;
                gt.MaKH = gt.MaKH;
                gt.MaLoaiLanXe = 2;
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

        public void SetTT(string ma)
        {
            TheXe bt = HTBGX.TheXes.Where(t => t.MaThe == ma).SingleOrDefault();
            bt.TinhTrang = false;
            HTBGX.SubmitChanges();
        }

        public TheXe ktTinhTrang(string ma)
        {
            TheXe bt = HTBGX.TheXes.Where(t => t.MaThe == ma).SingleOrDefault();
            return bt;
        }
        public string getBienSo(string ma)
        {
            try
            {
                ChiTietLanXe ct_lx = HTBGX.ChiTietLanXes.Where(t => t.MaThe == ma).SingleOrDefault();
                KhachHang kh = ct_lx.KhachHang;
                return kh.BienSo;

            }
            catch
            {
                return "";
            }
        }
    }

}
