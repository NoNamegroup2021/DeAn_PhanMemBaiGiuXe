using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class XeVaoDAL
    {
        DataClassesPMBGXDataContext data = new DataClassesPMBGXDataContext();
        public XeVaoDAL()
        {

        }

        public IQueryable load()
        {
            IQueryable kq = data.BangThes.Select(t => t);
            return kq;
        }

        public void SetTT(string ma)
        {
            BangThe bt = data.BangThes.Where(t => t.MaThe == ma).SingleOrDefault();
            bt.TinhTrang = true;
            data.SubmitChanges();
        }

        public bool ktKhoaChinh(string ma, string bienso)
        {

            QuetXe qx = data.QuetXes.Where(t => t.IDThe == ma && t.BIENSO == bienso).SingleOrDefault();
            if (qx != null)
            {
                return false;
            }
            return true;
        }

        public bool LuuTheXe(string maThe, string bienso, string anhThe)
        {
            try
            {

                BangThe the = data.BangThes.Where(t => t.MaThe == maThe).SingleOrDefault();

                if (the.TinhTrang == false)
                {

                    QuetXe qx = new QuetXe();
                    qx.IDThe = maThe;
                    qx.BIENSO = bienso;
                    qx.AnhThe = anhThe;
                    data.QuetXes.InsertOnSubmit(qx);
                    data.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
