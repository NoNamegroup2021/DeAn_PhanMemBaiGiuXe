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

namespace DA_PhanMemBaiGiuXe
{
    public partial class XeVao : Form
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
        public XeVao()
        {
            InitializeComponent();
            dscam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

        }
        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            pictureBox1.Image = bitmap;
            pictureBox2.Image = bitmap;
        }

        private void txt_MaThe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                
                if (e.KeyChar == 13)
                {

                    if (String.IsNullOrEmpty(txt_MaThe.Text) || String.IsNullOrEmpty(txt_BienSo.Text) )
                    {
                        MessageBox.Show("Vui lòng nhập mã môn học và tên môn học", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!QLXEV.ktKhoaChinh(txt_MaThe.Text,txt_BienSo.Text))
                    {
                        MessageBox.Show("Mã này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //BangThe the = data.BangThes.Where(t => t.MaThe == textBox1.Text).SingleOrDefault();
                        bool kq = QLXEV.ktTinhTrang(txt_MaThe.Text).TinhTrang;

                        if (kq == false)
                        {
                            if (QLXEV.LuuGiaoTac(txt_MaThe.Text, txt_BienSo.Text, DateTime.Parse(userControl11.Ngay + " " + userControl11.Gio), tenDN, 1))
                            {
                                QLXEV.SetTT(txt_MaThe.Text);
                                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Tinh trang true");
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

        private void XeVao_Load(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(dscam[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }

        private void XeVao_Enter(object sender, EventArgs e)
        {
            if (cam != null && cam.IsRunning)
            {
                cam.Stop();
            }
            cam = new VideoCaptureDevice(dscam[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();
        }

        private void XeVao_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
