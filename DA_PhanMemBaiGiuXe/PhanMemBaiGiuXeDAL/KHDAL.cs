using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBaiGiuXeDAL
{
    public class KHDAL
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        
        public bool themKH(string path_Bienso)
        {
            try
            {
                KhachHang kh = new KhachHang();
                kh.BienSo = path_Bienso;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
