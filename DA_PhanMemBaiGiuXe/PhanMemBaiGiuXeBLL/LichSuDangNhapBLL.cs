using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class LichSuDangNhapBLL
    {
        LichSuDangNhapDAL LSu = new LichSuDangNhapDAL();
        public LichSuDangNhapBLL()
        { }
        public IQueryable loadDN()
        {
            return LSu.loadDN();
        }
        public IQueryable timKiem(string txtTK)
        {
            return LSu.timKiem(txtTK);
        }
    }
}
