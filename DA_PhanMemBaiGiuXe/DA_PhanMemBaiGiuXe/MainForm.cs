using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using PhanMemBaiGiuXeBLL;

namespace DA_PhanMemBaiGiuXe
{
    public partial class MainForm : Form
    {
        LuuThongTinDNBLL LTT = new LuuThongTinDNBLL();
        private string tendn;
        string dateDN;
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
                Program.ctr.Tendn = tendn;
                this.mainPanel.Controls.Add(Program.ctr);
                Program.ctr.Show();
            }    
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (tendn != null)
            {
                tendn = tendn.ToUpper();
                this.Text += "            WELCOME " + tendn;
            }
            dateDN = DateTime.Now.ToString("");
            string[] date = dateDN.Split(' ');
            dateDN = date[0] +" "+ date[1];

            LTT.ThemTTDN(tenDN, DateTime.Parse(dateDN), DateTime.Parse(DateTime.Now.ToString()));
            Program.ctr = new ChuongTrinhChinh();
            if (Program.ctr != null)
            {
                this.mainPanel.Show();
                this.mainPanel.Controls.Clear();
                Program.ctr.TopLevel = false;
                Program.ctr.Dock = DockStyle.Fill;
                Program.ctr.Tendn = tendn;
                this.mainPanel.Controls.Add(Program.ctr);
                Program.ctr.Show();
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            LTT.SuaTTDN(tenDN, DateTime.Parse(dateDN), DateTime.Parse(DateTime.Now.ToString()));

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
   
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
     
            Application.Exit();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
