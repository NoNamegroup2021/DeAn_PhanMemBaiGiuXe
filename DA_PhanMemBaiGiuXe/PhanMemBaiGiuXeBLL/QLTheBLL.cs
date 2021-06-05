using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBaiGiuXeDAL;

namespace PhanMemBaiGiuXeBLL
{
    public class QLTheBLL
    {
        TheDAL qlyThe = new TheDAL();
        public IQueryable getInfoThe(string mathe)
        {
            try
            {

                return qlyThe.showInfoThe(mathe);
            }
            catch
            {
                return null;
            }
        }
        public IQueryable loadDS()
        {
            try
            {

                return qlyThe.loadDSThe();
            }
            catch
            {
                return null;
            }
        }
    }
}
