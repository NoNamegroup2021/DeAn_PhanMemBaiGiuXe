using PhanMemBaiGiuXeBLL;
using System;
using System.Windows.Forms;
namespace DA_PhanMemBaiGiuXe
{
    public partial class frmNVien : Form
    {
        NhanVienBLL nvien = new NhanVienBLL();
        public frmNVien()
        {
            InitializeComponent();
        }

        private void frmNVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = nvien.loadNhanVien();
        }
    }
}
