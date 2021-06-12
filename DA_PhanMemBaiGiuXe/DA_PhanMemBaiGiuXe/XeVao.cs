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
using PhanMemBaiGiuXeBLL;
using WindowsFormsControlLibrary1;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using ImageProcessing;
using System.Drawing.Imaging;
using System.IO;

namespace DA_PhanMemBaiGiuXe
{
    public partial class XeVao : Form
    {
        QuanLyXeVaoBLL QLXEV = new QuanLyXeVaoBLL();
        private FilterInfoCollection dscam;
        private VideoCaptureDevice cam;
        private List<Rectangle> rects = new List<Rectangle>();
        private string tenDN;
        private Rectangle[] rects_area;
        int numKH;
        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }
        public XeVao()
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
            txt_BienSo.Focus();
        }




        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = bitmap;
        }

        private void txt_MaThe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                if (e.KeyChar == 13  && txt_BienSo.Text.Trim().Length >0)
                {
                    if (String.IsNullOrEmpty(txt_MaThe.Text) || String.IsNullOrEmpty(txt_BienSo.Text))
                    {

                    }
                    else if (!QLXEV.ktKhoaChinh(txt_MaThe.Text, txt_BienSo.Text))
                    {
                        MessageBox.Show("Mã này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //BangThe the = data.BangThes.Where(t => t.MaThe == textBox1.Text).SingleOrDefault();
                        bool kq;
                        if (QLXEV.ktTinhTrang(txt_MaThe.Text) != null)
                            kq = QLXEV.ktTinhTrang(txt_MaThe.Text).TinhTrang;
                        else
                            kq = true;
                        if (kq == false)
                        {
                            string bienso = txt_BienSo.Text.Trim().ToString();
                            bienso.Replace("\r", "");
                            bienso.Replace("\n", "");
                            if (QLXEV.LuuGiaoTac(txt_MaThe.Text, bienso, DateTime.Parse(userControl11.Ngay + " " + userControl11.Gio), tenDN, 1))
                            {
                                QLXEV.SetTT(txt_MaThe.Text);
                                //MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                label3.BackColor = Color.LightGreen;
                                MessageBox.Show("Them thanh cong");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Tinh trang true");
                        }
                    }
                    pictureBox2.Image = null;
                    timer1.Enabled = true;
                    txt_MaThe.Text = "";
                    txt_BienSo.Text = "";
                    txt_BienSo.Focus();
                    label3.BackColor = Color.Red;
                    numKH++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void XeVao_Load(object sender, EventArgs e)
        {
            //if (cam != null && cam.IsRunning)
            //{
            //    cam.Stop();
            //}
            //cam = Program.ctr.Cam;
            //cam.NewFrame += Cam_NewFrame;
            //cam.Start();
            numKH =  QLXEV.getCountKH();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rects_area = ImageProcessing.DetectPlate.detect(pictureBox1.Image);
            
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


        private Image<Bgr, Byte> resizeImage(Image<Bgr, Byte> original, int width, int height)
        {
            Image<Bgr, Byte> img_resized = original.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear);
            return img_resized;
        }

        private void XeVao_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            if (cam.IsRunning || cam != null)
                cam.Stop();
        }
        private void txt_BienSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && pictureBox1.Image != null)
            {
                int count = rects_area.Count();
                if (count > 0)
                {
                    var boundingBox = rects_area[count - 1];

                    Bitmap src = pictureBox1.Image as Bitmap;
                    Bitmap crop = new Bitmap(boundingBox.Width, boundingBox.Height);
                    using (Graphics g = Graphics.FromImage(crop))
                    {
                        g.DrawImage(src, new Rectangle(0, 0, crop.Width, crop.Height), boundingBox, GraphicsUnit.Pixel);
                    }
                    Image<Bgr, Byte> img_crop = new Image<Bgr, byte>(crop);
                    img_crop = resizeImage(img_crop, pictureBox2.Width, pictureBox2.Height);
                    Bitmap bm = img_crop.ToBitmap();
                    pictureBox2.Image = bm;
                    pictureBox2.Invalidate();

                    var filename = Directory.GetCurrentDirectory() + @"\result";
                    using (var mem = new MemoryStream())
                    {
                        Image src_img = pictureBox2.Image;
                        Bitmap src_bm = src_img as Bitmap;
                        src_bm.Save(mem, ImageFormat.Jpeg);
                        var img = Image.FromStream(mem);
                        numKH++;
                        string bien = @"\KH" + numKH + ".jpg";
                        string file_img = filename + @"\KH" + numKH  + ".jpg";
                        img.Save(file_img);
                        txt_BienSo.Text = file_img;
                    }
                }
            }
        }
    }
}
