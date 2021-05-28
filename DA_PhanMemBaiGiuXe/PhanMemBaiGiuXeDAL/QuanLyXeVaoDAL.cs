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
            IQueryable kq = HTBGX.GiaoTacs.Select(t => t);
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

            GiaoTac qx = HTBGX.GiaoTacs.Where(t => t.MaThe == ma && t.KhachHang.BienSo == bienso).SingleOrDefault();
            if (qx != null)
            {
                return false;
            }
            return true;
        }
        public int count()
        {
            return HTBGX.GiaoTacs.Count();
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
                    GiaoTac gt = new GiaoTac();
                    gt.MaThe = maThe;
                    gt.TenTaiKhoan = tenNV;
                    gt.MaLoaiGiaoTac = loaigt;
                    gt.ThoiGIan = thoigian;
                    gt.MaKH = kh.MaKH;
                    HTBGX.GiaoTacs.InsertOnSubmit(gt);
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
