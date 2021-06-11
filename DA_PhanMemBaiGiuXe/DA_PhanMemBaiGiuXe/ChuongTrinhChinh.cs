using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Windows.Forms;

namespace DA_PhanMemBaiGiuXe
{
    public partial class ChuongTrinhChinh : Form
    {
        private FilterInfoCollection dscam;
        private VideoCaptureDevice cam;
        private string tendn;

        public string Tendn
        {
            get { return tendn; }
            set { tendn = value; }
        }

        public VideoCaptureDevice Cam { get =>  cam; set => cam = value; }

        public ChuongTrinhChinh()
        {
            InitializeComponent();
            cam = Program.main_from.Cam;
            
        }


        private void xeVàoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Program.frmXevao  = new XeVao();
            if(Program.frmXevao != null)
            {
                this.Hide();
                Program.frmXevao.TenDN = tendn;
                Program.frmXevao.Validate();
                Program.frmXevao.Show();
   

            }    

        }

        private void xeRaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.frmXeRa = new XeRa();
            if (Program.frmXeRa != null)
            {
                Program.frmXeRa.TenDN = tendn;
                Program.frmXeRa.Validate();
                Program.frmXeRa.Show();
                this.Hide();

            }

        }

        private void xemLịchSửGửiXeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Program.lsgx = new LichSuRaVao();
            if (Program.lsgx != null)
            {
                this.panel1.Controls.Clear();
                Program.lsgx.TopLevel = false;
                Program.lsgx.Dock = DockStyle.Fill;
                Program.lsgx.TenDN = tendn;
                this.panel1.Controls.Add(Program.lsgx);
                Program.lsgx.Validate();
                Program.lsgx.Show();

            }
        }

        private void xemTinhTrangTheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.xemthe = new XemThe();
            if (Program.xemthe != null)
            {
                this.panel1.Controls.Clear();
                Program.xemthe.TopLevel = false;
                Program.xemthe.Dock = DockStyle.Fill;
                Program.xemthe.TenDN = tendn;
                this.panel1.Controls.Add(Program.xemthe);
                Program.xemthe.Validate();
                Program.xemthe.Show();

            }
        }
    }
}
