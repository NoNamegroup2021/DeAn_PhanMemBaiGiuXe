using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBaiGiuXeDAL;
namespace DA_PhanMemBaiGiuXe
{
    public partial class QL_The : Form
    {
        DataClassesHTBGXDataContext data = new DataClassesHTBGXDataContext();
        private string tentk;

        public string TenTk
        {
            get { return tentk; }
            set { tentk = value; }
        }
        public QL_The()
        {
            InitializeComponent();
        }

        private void QL_The_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = tentk;
            this.textBox2.Enabled = false;
            var The = from the in data.TheXes select new { MaThe = the.MaThe, TinhTrang = the.TinhTrang };
            this.dataGridView1.DataSource = The;
        }
    }
}
