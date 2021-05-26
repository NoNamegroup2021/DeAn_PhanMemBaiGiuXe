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
    public partial class MainForm : Form
    {
        private string tendn;
        public string tenDN
        {
            get { return tendn; }
            set { tendn = value; }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void QLY_Click(object sender, EventArgs e)
        {
            Program.qly = new QLy();
            Program.qly.tenDN = tendn;
            if(Program.qly != null)
            {
                this.mainPanel.Show();
                this.mainPanel.Controls.Clear();
                Program.qly.TopLevel = false;
                Program.qly.Dock = DockStyle.Fill;
                this.mainPanel.Controls.Add(Program.qly);
                Program.qly.Show();
            }    
        }


        private void mainActivity_Click(object sender, EventArgs e)
        {
            Program.ctr = new ChuongTrinhChinh();
            if(Program.ctr != null)
            {
                this.mainPanel.Show();
                this.mainPanel.Controls.Clear();
                Program.ctr.TopLevel = false;
                Program.ctr.Dock = DockStyle.Fill;
                this.mainPanel.Controls.Add(Program.ctr);
                Program.ctr.Show();
            }    
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(tendn != null)
            {
                tendn = tendn.ToUpper();
                this.Text += "            WELCOME " + tendn;
            }    
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
