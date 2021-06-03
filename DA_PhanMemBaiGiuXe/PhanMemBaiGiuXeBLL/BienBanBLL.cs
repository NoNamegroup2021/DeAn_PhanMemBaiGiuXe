using PhanMemBaiGiuXeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeBLL
{
    public class BienBanBLL
    {
        BienBanDAL bienBanDAL = new BienBanDAL();
        public BienBanBLL() { }

        public IQueryable getBienBan()
        {
            return bienBanDAL.getBienBan();
        }
        public NgoaiLe getBienBanbyMaNL(int manl)
        {
            return bienBanDAL.getBienBanbyMaNL(manl);
        }
        public bool ktraKhoaChinh(int manl)
        {
            return bienBanDAL.KTKhoaChinh(manl);
        }
        public bool addNL(int makh, string tenkh, string cmnd, string diachi, string sdt, string tennv, DateTime ngay, string noidung)
        {
            return bienBanDAL.addNL(makh, tenkh, cmnd, diachi, sdt, tennv, ngay, noidung);
        }

        public bool updateNL(int manl, int makh, string tenkh, string cmnd, string diachi, string sdt, string tennv, DateTime ngay, string noidung)
        {
            return bienBanDAL.updateNL(manl, makh, tenkh, cmnd, diachi, sdt, tennv, ngay, noidung);
        }
        public bool deleteNL(int manl)
        {
            return bienBanDAL.deleteNL(manl);
        }
    }
}
