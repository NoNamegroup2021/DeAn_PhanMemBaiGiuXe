using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class QuanLyXeVaoDAL
    {
        DataClassesHTBGXDataContext HTBGX = new DataClassesHTBGXDataContext();
        public QuanLyXeVaoDAL()
        {

        }

        public IQueryable load()
        {
            IQueryable kq = HTBGX.ChiTietLanXes.Select(t => t);
            return kq;
        }

        public void SetTT(string ma)
        {
            TheXe bt = HTBGX.TheXes.Where(t => t.MaThe == ma).SingleOrDefault();
            bt.TinhTrang = true;
            HTBGX.SubmitChanges();
        }

        public TheXe ktTinhTrang(string ma)
        {
            TheXe bt = HTBGX.TheXes.Where(t => t.MaThe == ma).SingleOrDefault();
            return bt;
        }

        public bool ktKhoaChinh(string ma, string bienso)
        {

            ChiTietLanXe qx = HTBGX.ChiTietLanXes.Where(t => t.MaThe == ma && t.KhachHang.BienSo == bienso).SingleOrDefault();
            if (qx != null)
            {
                return false;
            }
            return true;
        }
        public int count()
        {
            try
            {
                return HTBGX.ChiTietLanXes.Count();
            }
            catch
            {
                return 0;
            }
        }

        public bool LuuGiaoTac(string maThe, string bienso, DateTime thoigian, string tenNV, int loaigt)
        {
            try
            {

                TheXe the = HTBGX.TheXes.Where(t => t.MaThe == maThe).SingleOrDefault();
                if (the.TinhTrang == false)
                {
                    KhachHang kh = new KhachHang();
                    kh.BienSo = bienso;
                    HTBGX.KhachHangs.InsertOnSubmit(kh);
                    HTBGX.SubmitChanges();
                    ChiTietLanXe gt = new ChiTietLanXe();
                    gt.MaThe = maThe;
                    gt.TenTaiKhoan = tenNV;
                    gt.MaLoaiLanXe = loaigt;
                    gt.ThoiGIan = thoigian;
                    gt.MaKH = kh.MaKH;
                    HTBGX.ChiTietLanXes.InsertOnSubmit(gt);
                    HTBGX.SubmitChanges();
                }
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
