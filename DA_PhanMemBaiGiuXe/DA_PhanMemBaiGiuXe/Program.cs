using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_PhanMemBaiGiuXe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static FrMain main = null;
        public static FrLogin login = null;
        public static Form1 nhanvien = null;
        public static Welcome welcome_screen = null;
        public static QLy qly = null;
        public static NVien nv = null;
        public static ChuongTrinhChinh ctr = null;
        public static MainForm main_from = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new testCascade());
        }
    }
}
