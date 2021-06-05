using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class TheDAL
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        public IQueryable showInfoThe(string mathe)
        {
            try
            {
                return data.TheXes.Select(t => t.MaThe.Equals(mathe));
            }
            catch
            {
                return null;
            }
        }
        public IQueryable loadDSThe()
        {
            try
            {
                return data.TheXes.Select(t => t);
            }
            catch
            {
                return null;
            }
        }
    }
}
