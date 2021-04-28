using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace DA_PhanMemBaiGiuXe
{
    public partial class FrMain : Form
    {
        private FilterInfoCollection dscam;
        private VideoCaptureDevice cam;
        private string chucvu;

        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        public FrMain()
        {
            InitializeComponent();
            dscam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void FrMain_Load(object sender, EventArgs e)
        {
            if (chucvu == "Nhân Viên")
            {
                this.tp_NV.Enabled = true;
                this.tp_XeVao.Enabled = false;
                this.tp_XeRa.Enabled = false;
            }
            else
            {
                this.tp_XeVao.Enabled = true;
                this.tp_XeRa.Enabled = true;
                this.tp_NV.Enabled = false;
            }
            
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = bitmap;
            pictureBox3.Image = bitmap;
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                pictureBox2.Image = pictureBox1.Image;                
            }
        }

        

        private void tp_XeVao_Enter(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(dscam[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                pictureBox4.Image = pictureBox3.Image;
            }
        }
    }
}
