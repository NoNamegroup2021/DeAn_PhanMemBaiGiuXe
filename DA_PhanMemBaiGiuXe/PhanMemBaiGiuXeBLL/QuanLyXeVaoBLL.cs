using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class QuanLyXeVaoBLL
    {
        QuanLyXeVaoDAL QLXV = new QuanLyXeVaoDAL();
        public QuanLyXeVaoBLL()
        {

        }

        public IQueryable load()
        {
            return QLXV.load();
        }

        public void SetTT(string ma)
        {
           QLXV.SetTT(ma);
        }

        public TheXe ktTinhTrang(string ma)
        {
            if (QLXV.ktTinhTrang(ma) != null)
                return QLXV.ktTinhTrang(ma);
            else
                return null;
        }

        public bool ktKhoaChinh(string ma, string bienso)
        {

            return QLXV.ktKhoaChinh(ma, bienso);
        }

        public bool LuuGiaoTac(string maThe, string bienso, DateTime thoigian, string tenNV, int loaigt)
        {
            return QLXV.LuuGiaoTac(maThe, bienso, thoigian, tenNV, loaigt);
        }
        public int getCountKH()
        {
            return QLXV.count();
        }
    }
}
