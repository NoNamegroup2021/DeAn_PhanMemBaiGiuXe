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
        CascadeClassifier carLicense_class;
        string haarcascade_file = Application.StartupPath + "\\car_lp_cascade.xml";
        private List<Rectangle> rects = new List<Rectangle>();
        private string tenDN;
        private Rectangle[] rects_area;

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
            cam = new VideoCaptureDevice(dscam[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            pictureBox1.Image = bitmap;

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private Rectangle[] detect()
        {
            try
            {
                Bitmap bm = pictureBox1.Image as Bitmap;
                if (bm != null)
                {
                    carLicense_class = new CascadeClassifier(haarcascade_file);
                    Bitmap bm2 = pictureBox1.Image as Bitmap;
                    Image<Bgr, Byte> img = new Image<Bgr, byte>(bm2);
                    Image<Gray, Byte> gray = img.Convert<Gray, Byte>();
                    Bitmap transfr = pictureBox1.Image as Bitmap;
                    Image<Bgr, Byte> img_transfr_frame = new Image<Bgr, byte>(transfr);
                    Image<Gray, Byte> imgTransf_grayScale = img_transfr_frame.Convert<Gray, Byte>();

                    Rectangle[] rects = carLicense_class.DetectMultiScale(imgTransf_grayScale, 1.2, 3, Size.Empty);
                    return rects;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (rects_area != null)
            {
                int count = rects_area.Count();
                if (count > 0)
                {
                    Rectangle rect = new Rectangle();
                    rect.Location = rects_area[count - 1].Location;
                    rect.Size = rects_area[count - 1].Size;
                    if (rect != null && rect.Height > 0 && rect.Width > 0)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Red, 3), rect);
                    }
                }
            }
        }
        private Mat medianSmooth(Image<Gray, Byte> img)
        {
            Mat src = img.Mat;
            CvInvoke.MedianBlur(src, src, 3);
            return src;
        }
        private Image<Bgr, Byte> resizeImage(Image<Bgr, Byte> original, int width, int height)
        {
            Image<Bgr, Byte> img_resized = original.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear);
            return img_resized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rects_area = detect();
            if (rects_area != null)
                foreach (Rectangle rect in rects_area)
                    rects.Add(rect);
        }
    }
}
