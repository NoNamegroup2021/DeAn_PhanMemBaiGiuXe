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
        Rectangle rect = new Rectangle();
        Bitmap img;
        Bitmap crop_img;
        string haarcascade_file = Application.StartupPath + "\\carLincense.xml";
        CascadeClassifier carLicense_class;
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
        private void detect()
        {
            Bitmap bm = pictureBox1.Image as Bitmap;
            if(bm != null)
            {
                try{
                    carLicense_class = new CascadeClassifier(haarcascade_file);
                    Bitmap bm2 = pictureBox1.Image as Bitmap;
                    Image<Bgr,Byte> img = new Image<Bgr,byte>(bm2);
                    Image<Gray, Byte> gray = img.Convert<Gray, Byte>();
                    
                    Rectangle[] carLicenses = carLicense_class.DetectMultiScale(gray, 1.2, 2, Size.Empty);
                    foreach (var carLicense in carLicenses)
                    {
                        img.Draw(carLicense, new Bgr(Color.Green), 3);
                    }
                    pictureBox1.Image = img.ToBitmap();
                    MessageBox.Show("Detected");
                }
                catch(Exception ex)
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
            detect();
        }

    }
}
