using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class XeVaoBLL
    {
        XeVaoDAL xeVao = new XeVaoDAL();
        public XeVaoBLL()
        {

        }

        public IQueryable load()
        {
            return xeVao.load();
        }

        public void SetTT(string ma)
        {
             xeVao.SetTT(ma);
        }

        public bool ktKhoaChinh(string ma, string bienso)
        {

            return ktKhoaChinh(ma, bienso);
        }

        public bool LuuTheXe(string maThe, string bienso, string anhThe)
        {
            return LuuTheXe(maThe, bienso, anhThe);
        }
    }
}
