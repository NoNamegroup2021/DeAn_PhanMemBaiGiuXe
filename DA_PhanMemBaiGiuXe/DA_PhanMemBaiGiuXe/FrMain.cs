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


namespace DA_PhanMemBaiGiuXe
{
    public partial class FrMain : Form
    {
        //DataClasses1DataContext data = new DataClasses1DataContext();
        private FilterInfoCollection dscam;
        private VideoCaptureDevice cam;
        private string chucvu;
        private CascadeClassifier carLicense_classifier;
        private Rectangle[] rects_area;

        private string _TenNV;

        public string TenNV
        {
            get { return _TenNV; }
            set { _TenNV = value; }
        }
        
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
            label15.Text = _TenNV;   
            if (chucvu == "Nhân Viên")
            {
                this.tp_QL.Enabled = true;
                this.tp_XeVao.Enabled = false;
                this.tp_XeRa.Enabled = false;
            }
            else
            {
                this.tp_XeVao.Enabled = true;
                this.tp_XeRa.Enabled = true;
                this.tp_QL.Enabled = true;
            }
            this.timer1.Interval = 100;
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            //bitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
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


        private void timer1_Tick(object sender, EventArgs e)
        {
                rects_area = detect_object();
            
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

        private Rectangle[] detect_object()
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    string path = Application.StartupPath + "\\car_lp_cascade.xml";
                    carLicense_classifier = new CascadeClassifier(path);

                    Bitmap transfr = pictureBox1.Image as Bitmap;
                    Image<Bgr, Byte> img_transfr_frame = new Image<Bgr, byte>(transfr);
                    Image<Gray, Byte> imgTransf_grayScale = img_transfr_frame.Convert<Gray, Byte>();

                    Rectangle[] rects = carLicense_classifier.DetectMultiScale(imgTransf_grayScale, 1.2, 3, Size.Empty);
                    return rects;

                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void reLoad()
        {
            var monHoc = from mh in data.NhanViens select mh;
            dataGridView1.DataSource = monHoc;
        }
        public bool ktKhoaChinh(string ma)
        {
            NhanVien nv = data.NhanViens.Where(t => t.MaNV == ma).SingleOrDefault();
            if (nv != null)
            {
                return false;
            }
            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text) || String.IsNullOrEmpty(txtTenNV.Text) || String.IsNullOrEmpty(txtDiaChi.Text) || String.IsNullOrEmpty(txtGT.Text) || String.IsNullOrEmpty(txtCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!ktKhoaChinh(txtMaNV.Text))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NhanVien nv = new NhanVien();
                nv.MaNV = txtMaNV.Text;
                
                nv.DiaChi = txtDiaChi.Text;
                nv.GioiTinh = txtGT.Text;
                
                data.NhanViens.InsertOnSubmit(nv);
                data.SubmitChanges();
                reLoad();
                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên  muốn xóa, hoặc chọn trên lưới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string maNV = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                NhanVien nv = data.NhanViens.Where(t => t.MaNV == maNV).SingleOrDefault();
                data.NhanViens.DeleteOnSubmit(nv);
                data.SubmitChanges();
                reLoad();
                MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên muốn cập nhật, hoặc chọn trên lưới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string maNV = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                NhanVien nv = data.NhanViens.Where(t => t.MaNV == maNV).SingleOrDefault();
                
                nv.GioiTinh = txtGT.Text;
                
                nv.DiaChi = txtDiaChi.Text;
                data.SubmitChanges();
                reLoad();
                MessageBox.Show("Cập nhật thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận thoát chương trình ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtMaNV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void FrMain_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && pictureBox1.Image != null)
            {
                int count = rects_area.Count();
                if (count > 0)
                {
                    var boundingBox = rects_area[count - 1];

                    Bitmap src = pictureBox1.Image as Bitmap;
                    Bitmap crop = new Bitmap(boundingBox.Width, boundingBox.Height);
                    using(Graphics g = Graphics.FromImage(crop))
                    {
                        g.DrawImage(src, new Rectangle(0, 0, crop.Width, crop.Height), boundingBox, GraphicsUnit.Pixel);
                    }
                    

                    pictureBox2.Image = crop;
                    pictureBox2.Invalidate();
                }
            }
        }

        private void txt_MaThe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {

            }
        }
    }
}
