using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_PhanMemBaiGiuXe
{
    public partial class QLy : Form
    {
        private string tendn;
        public string tenDN
        {
            get { return tendn; }
            set { tendn = value; }
        }
        public QLy()
        {
            InitializeComponent();
        }
        public void QLy_Load(object sender,EventArgs e)
        {

        }
        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            DangKy qltk = new DangKy();
            qltk.TopLevel = false;
            qltk.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(qltk);
            qltk.Show();
        }

        private void thẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            QL_The the = new QL_The();
            the.TenTk = tendn;
            the.TopLevel = false;
            this.panel1.Controls.Add(the);
            the.Show();

        }
    }
}
