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
using Emgu.CV.Structure;
using PhanMemBaiGiuXeBLL;

namespace DA_PhanMemBaiGiuXe
{
    public partial class XeRa : Form
    {
        QuanLyXeRaBLL QLXR = new QuanLyXeRaBLL();
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
            rects_area = ImageProcessing.DetectPlate.detect(pictureBox1.Image);

        }

        private void XeRa_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            if (cam.IsRunning || cam != null)
                cam.Stop();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    if (rects != null && rects.Count() > 0)
                    {
                        var boundingBox = rects[rects.Count() - 1];

                        Bitmap src = pictureBox1.Image as Bitmap;
                        Bitmap crop = new Bitmap(boundingBox.Width, boundingBox.Height);


                        using (Graphics g = Graphics.FromImage(crop))
                        {
                            g.DrawImage(src, new Rectangle(0, 0, crop.Width, crop.Height), boundingBox, GraphicsUnit.Pixel);
                        }


                        Image<Bgr, Byte> img_cropped = new Image<Bgr, byte>(crop);
                        img_cropped = resizeImage(img_cropped, pictureBox2.Width, pictureBox2.Height);
                        pictureBox2.Image = img_cropped.ToBitmap();
                    }
                    if (String.IsNullOrEmpty(txt_MaThe.Text) || String.IsNullOrEmpty(txt_BienSo.Text))
                    {

                    }
                    else
                    {
                        //BangThe the = data.BangThes.Where(t => t.MaThe == textBox1.Text).SingleOrDefault();
                        bool kq = QLXR.ktTinhTrang(txt_MaThe.Text).TinhTrang;

                        if (kq == true)
                        {
                            if (QLXR.SuaLoaiGiaoTac(txt_MaThe.Text, DateTime.Parse(userControl12.Ngay + " " + userControl12.Gio), tenDN))
                            {
                                QLXR.SetTT(txt_MaThe.Text);
                                //MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                label1.BackColor = Color.LightGreen;
                                label1.Text = "Thanh Cong";
                            }

                        }
                        else
                        {
                            MessageBox.Show("Tinh trang false");
                        }
                    }
                    txt_MaThe.Text = "";
                    txt_BienSo.Text = "";
                    txt_MaThe.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
