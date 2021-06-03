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
            try
            {
                this.panel1.Controls.Clear();
                DangKy qltk = new DangKy();
                qltk.TopLevel = false;
                qltk.Dock = DockStyle.Fill;
                this.panel1.Controls.Add(qltk);
                qltk.Show();
            }
            catch
            {  }
        }

        private void thẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.the = new QL_The();
            if (Program.the != null)
            {
                this.panel1.Controls.Clear();
                Program.the.TopLevel = false;
                Program.the.Dock = DockStyle.Fill;
                Program.the.TenTk = tendn;
                this.panel1.Controls.Add(Program.the);
                Program.the.Validate();
                Program.the.Show();

            }

        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.qlnv = new QuanLyNhanVien();
            if (Program.qlnv != null)
            {
                this.panel1.Controls.Clear();
                Program.qlnv.TopLevel = false;
                Program.qlnv.Dock = DockStyle.Fill;
                Program.qlnv.TenDN = tendn;
                this.panel1.Controls.Add(Program.qlnv);
                Program.qlnv.Validate();
                Program.qlnv.Show();

            }
        }

        private void lậpBiênBảnXửLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.lbp= new LapBienBan();
            if (Program.lbp != null)
            {
                this.panel1.Controls.Clear();
                Program.lbp.TopLevel = false;
                Program.lbp.Dock = DockStyle.Fill;
                Program.lbp.TenDN = tendn;
                this.panel1.Controls.Add(Program.lbp);
                Program.lbp.Validate();
                Program.lbp.Show();

            }

        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xemLịchSửĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
