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
        public static FrLogin login = null;
        public static Welcome welcome_screen = null;
        public static QLy qly = null;
        public static ChuongTrinhChinh ctr = null;
        public static MainForm main_from = null;
        public static DangKy dk = null;
        public static XeVao frmXevao = null;
        public static DangKy frmDKy = null;
        public static XeRa frmXeRa = null;
        public static LapBienBan lbp = null;
        public static QL_The the= null;
        public static QuanLyNhanVien qlnv = null;
        public static XemThe xemthe = null;
        public static LichSuDangNhap lsdn = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new XeRa());
        }
    }
}
