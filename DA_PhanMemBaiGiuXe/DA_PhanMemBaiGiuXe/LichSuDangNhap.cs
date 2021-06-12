using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBaiGiuXeBLL;
namespace DA_PhanMemBaiGiuXe
{

    public partial class LichSuDangNhap : Form
    {
        LichSuDangNhapBLL LSu = new LichSuDangNhapBLL();
        public LichSuDangNhap()
        {
            InitializeComponent();
        }

        private void LichSuDangNhap_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LSu.loadDN();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LSu.timKiem(txtTimKiem.Text);
        }
    }
}
