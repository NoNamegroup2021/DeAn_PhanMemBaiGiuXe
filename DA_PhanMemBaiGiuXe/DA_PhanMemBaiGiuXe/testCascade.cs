using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;




namespace DA_PhanMemBaiGiuXe
{
    public partial class testCascade : Form
    {
        Bitmap img;
        Bitmap crop_img;
        string haarcascade_file = Application.StartupPath + "\\cascade.xml";
        CascadeClassifier carLicense_class;
        List<Rectangle> rect_found = new List<Rectangle>();
        List<Rectangle> firstLine = new List<Rectangle>();
        List<Rectangle> secondLine = new List<Rectangle>();
        int firstX_Line1,firstX_Line2;

        public testCascade()
        {
            InitializeComponent();
        }

        private void testCascade_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                Bitmap img = new Bitmap(textBox1.Text);
                pictureBox1.Image = (Image)img;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }

        }
        bool success;
        float scale = 0;
        private void detect(ref Rectangle[] rects)
        {
            Bitmap bm = pictureBox1.Image as Bitmap;
            if (bm != null)
            {
                try {
                    carLicense_class = new CascadeClassifier(haarcascade_file);
                    Bitmap bm2 = pictureBox1.Image as Bitmap;
                    Image<Bgr, Byte> img = new Image<Bgr, byte>(bm2);
                    Image<Gray, Byte> gray = img.Convert<Gray, Byte>();

                    Rectangle[] carLicenses = carLicense_class.DetectMultiScale(gray,1.1, 4, new Size(40, 30));
                    foreach (var carLicense in carLicenses)
                    {
                        img.Draw(carLicense, new Bgr(Color.Green), 1);
                    }
                    pictureBox1.Image = img.ToBitmap();
                    rects = carLicenses;
                    MessageBox.Show("Detected");
                }
                catch (Exception ex)
                {
                    success = false;
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Rectangle [] rects = null;
            detect(ref rects);
            if(rects != null && rects.Count() >0)
            {
                var boundingBox = rects[rects.Count() - 1];

                Bitmap src = pictureBox1.Image as Bitmap;
                Bitmap crop = new Bitmap(boundingBox.Width, boundingBox.Height);
               

                using(Graphics g = Graphics.FromImage(crop))
                {
                    g.DrawImage(src, new Rectangle(0, 0, crop.Width, crop.Height), boundingBox, GraphicsUnit.Pixel);
                }


                Image<Bgr, Byte> img_cropped = new Image<Bgr, byte>(crop);
                img_cropped = resizeImage(img_cropped, pictureBox2.Width, pictureBox2.Height);
                pictureBox2.Image = img_cropped.ToBitmap();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            scale = (float)trackBar1.Value / 10 + 1;
            this.label1.Text = scale.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private Image<Bgr, Byte> resizeImage(Image<Bgr, Byte> original, int width, int height)
        {
            Image<Bgr, Byte> img_resized = original.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear);
            return img_resized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = pictureBox2.Image as Bitmap;
                Image<Bgr, Byte> ori_img = new Image<Bgr, byte>(bm);
                ori_img = resizeImage(ori_img, pictureBox3.Width, pictureBox3.Height);
                Image<Gray, Byte> gray_scale = new Image<Gray, byte>(ori_img.ToBitmap());
                Bitmap gray_bm = gray_scale.ToBitmap();
                pictureBox3.Image = gray_bm;
            }
            catch
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = pictureBox2.Image as Bitmap;
                Image<Bgr, Byte> ori_img = new Image<Bgr, byte>(bm);
                ori_img = resizeImage(ori_img, pictureBox2.Width, pictureBox2.Height);

                Image<Gray, Byte> gray_scale = new Image<Gray, byte>(ori_img.ToBitmap());

                //Can bang sang anh 
                //CvInvoke.EqualizeHist(gray_scale,gray_scale);

                //Lam tron anh

                //Gaussian
                //Mat gaussian = Gaussianblur(gray_scale);

                
                //Median
                Mat gaussian = medianSmooth(gray_scale);

                Image<Gray, Byte> gray_gua_scale = gaussian.ToImage<Gray, Byte>();

                //gray_gua_scale = gray_gua_scale.ThresholdBinary(new Gray(150), new Gray(255));
                CvInvoke.Canny(gaussian, gray_gua_scale, 50, 300);
                CvInvoke.AdaptiveThreshold(gaussian, gaussian, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.BinaryInv, 7,7);


                Bitmap gray_bm = gray_gua_scale.ToBitmap();

                pictureBox4.Image = gray_bm;
            }
            catch
            {

            }
        }

        private Mat Gaussianblur(Image<Gray, Byte> img)
        {
            Mat src = img.Mat;
            CvInvoke.GaussianBlur(src, src, new Size(7,7),6,4);
            return src;
        }

        private Mat medianSmooth(Image<Gray,Byte>img)
        {
            Mat src = img.Mat;
            CvInvoke.MedianBlur(src, src, 3);
            return src;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap src_bm = pictureBox4.Image as Bitmap;
                Image<Gray, Byte> src_img = new Image<Gray, byte>(src_bm);
                Emgu.CV.Util.VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();
                CvInvoke.FindContours(src_img, contours, hier, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                CvInvoke.DrawContours(src_img, contours, -1, new MCvScalar(255, 0, 0));
                pictureBox5.Image = src_img.ToBitmap();

                // draw Rectangle for each contour is number
                
                int count = contours.Size;
                rect_found = new List<Rectangle>();
                Image<Bgr, Byte> img_brg_draw = new Image<Bgr, byte>(pictureBox2.Image as Bitmap);
                for (int i = 0; i < count; i++)
                {
                    int width = CvInvoke.BoundingRectangle(contours[i]).Width;
                    int height = CvInvoke.BoundingRectangle(contours[i]).Height;
                    int x = CvInvoke.BoundingRectangle(contours[i]).X;
                    int y = CvInvoke.BoundingRectangle(contours[i]).Y;



                    if ( height >= 40 && height <= 66  && width >= 12 && width <= 26 && (float)width / height > 0.2 && (float)width / height < 0.5)
                    {

                        Rectangle rect = new Rectangle(x, y, width, height);
                        CvInvoke.Rectangle(img_brg_draw, rect, new MCvScalar(0, 0, 255), 2);
                        int index = -1;
                        index = rect_found.FindIndex(r => r.X == rect.X && r.Y == rect.Y);
                        if(index <0)
                            rect_found.Add(rect);
                    }
                }

                pictureBox6.Image = img_brg_draw.ToBitmap();
                firstLine = new List<Rectangle>();
                secondLine = new List<Rectangle>();
                getLines(rect_found, ref firstLine, ref secondLine);
                firstLine = firstLine.OrderBy(r => r.X).ToList();
                firstX_Line1 = firstLine[0].X;
                secondLine = secondLine.OrderBy(r => r.X).ToList();
                firstX_Line2 = secondLine[0].X;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getLines(List<Rectangle> rects,ref List<Rectangle> firstline,ref List<Rectangle> secondline)
        {
            rects = rects.OrderBy(r => r.Y).ThenBy(r=> r.X).ToList();
            firstLine.Add(rects[0]);
            for(int i = 1 ; i <rects.Count ; i++)
            {
                if ((rects[i].Y - firstLine[0].Y) < 10)
                    firstLine.Add(rects[i]);
                else
                    secondLine.Add(rects[i]);
            }
        }
        

        private Rectangle getAreaRect_Line1(List<Rectangle> rects)
        {
            int count = rects.Count;
            Rectangle frect = rects[0];
            Rectangle lrect = rects[count-1];
            int maxH = rects.Max(r => r.Height);

            Rectangle[] bg_hr = rects.Where(r => r.Height == maxH).ToArray();
            bg_hr = bg_hr.OrderByDescending(t => t.X).ToArray();
            return new Rectangle(new Point(firstX_Line1, bg_hr[0].Y), new Size(Math.Abs(lrect.X + lrect.Width - firstX_Line1), bg_hr[0].Height+1));
        }

        private Rectangle getAreaRect_Line2(List<Rectangle> rects)
        {
            int count = rects.Count;
            Rectangle frect = rects[0];
            Rectangle lrect = rects[count - 1];
            int maxH = rects.Max(r => r.Height);

            Rectangle[] bg_hr = rects.Where(r => r.Height == maxH).ToArray();
            bg_hr = bg_hr.OrderByDescending(t => t.X).ToArray();
            return new Rectangle(new Point(firstX_Line2, bg_hr[0].Y), new Size(Math.Abs(lrect.X + lrect.Width - firstX_Line2), bg_hr[0].Height + 1));
        }



        private Image<Bgr,Byte> drawCropImage(Bitmap bitmap)
        {
            Image<Bgr, Byte> img = new Image<Bgr, byte>(bitmap);
            return img;
        }

        private PointF getPoint(float x,float y)
        {
            return new PointF(x, y);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_File = new SaveFileDialog();
            save_File.Filter = "(*.jpg)|*.jpg";
            if(save_File.ShowDialog() == DialogResult.OK)
            {
                pictureBox7.Image.Save(save_File.FileName);
            }    
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var boundingBox1 = getAreaRect_Line1(firstLine);
            var boundingBox2 = getAreaRect_Line2(secondLine);
            if (boundingBox1 == null || boundingBox2 == null)
                return;
            Bitmap draw = pictureBox2.Image as Bitmap;
            Bitmap crop1 = new Bitmap(boundingBox1.Width, boundingBox1.Height);
            Bitmap crop2 = new Bitmap(boundingBox2.Width, boundingBox2.Height);

            using (Graphics g = Graphics.FromImage(crop1))
            {
                g.DrawImage(draw, new Rectangle(0, 0, crop1.Width, crop1.Height), boundingBox1, GraphicsUnit.Pixel);
            }
            Image<Bgr, Byte> img_cropped1 = new Image<Bgr, byte>(crop1);
            pictureBox7.Image = img_cropped1.ToBitmap();

            using (Graphics g = Graphics.FromImage(crop2))
            {
                g.DrawImage(draw, new Rectangle(0, 0, crop2.Width, crop2.Height), boundingBox2, GraphicsUnit.Pixel);
            }
            Image<Bgr, Byte> img_cropped2 = new Image<Bgr, byte>(crop2);
            pictureBox8.Image = img_cropped2.ToBitmap();

        }
    }
}
