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
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.Structure;
using PhanMemBaiGiuXeBLL;

namespace DA_PhanMemBaiGiuXe
{
    public partial class XeRa : Form
    {
        QuanLyXeVaoBLL QLXEV = new QuanLyXeVaoBLL();
        private FilterInfoCollection dscam;
        private VideoCaptureDevice cam;
        private string chucvu;
        private CascadeClassifier carLicense_classifier;
        private List<Rectangle> rects_area = new List<Rectangle>();
        private string tenDN;

        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }
        public XeRa()
        {
            InitializeComponent();
            dscam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = Program.main_from.Cam;
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = bitmap;
            pictureBox2.Image = bitmap;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
