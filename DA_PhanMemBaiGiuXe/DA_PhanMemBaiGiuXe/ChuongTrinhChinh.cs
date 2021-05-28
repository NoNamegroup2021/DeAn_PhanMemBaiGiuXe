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
    public partial class ChuongTrinhChinh : Form
    {
        private string tendn;

        public string Tendn
        {
            get { return tendn; }
            set { tendn = value; }
        }

        public ChuongTrinhChinh()
        {
            InitializeComponent();
        }

        private void xeVàoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.frmXevao  = new XeVao();
            if(Program.frmXevao != null)
            {
                this.panel1.Controls.Clear();
                Program.frmXevao.TopLevel = false;
                Program.frmXevao.Dock = DockStyle.Fill;
                Program.frmXevao.TenDN = tendn;
                this.panel1.Controls.Add(Program.frmXevao);
                Program.frmXevao.Show();
            }    
        }
    }
}
