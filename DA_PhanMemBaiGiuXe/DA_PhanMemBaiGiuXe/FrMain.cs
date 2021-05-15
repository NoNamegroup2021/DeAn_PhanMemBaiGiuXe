﻿using System;
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
        QLXMDataContext data = new QLXMDataContext();
        private FilterInfoCollection dscam;
        private VideoCaptureDevice cam;
        private string chucvu;
        private CascadeClassifier carLicense_classifier;
        private Rectangle[] rects_area;
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
                this.tp_NV.Enabled = true;
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            rects_area = detect_object();
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (rects_area != null)
            {
                for (int i = 0; i < rects_area.Count(); i++)
                {
                    Rectangle rect = new Rectangle();
                    rect.Location = rects_area[i].Location;
                    rect.Size = rects_area[i].Size;
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
                string path = Application.StartupPath + "\\carLincense.xml";
                carLicense_classifier = new CascadeClassifier(path);
                
                Bitmap transfr = pictureBox1.Image as Bitmap;
                Image<Bgr,Byte> img_transfr_frame = new Image<Bgr,byte>(transfr);
                Image<Gray,Byte> imgTransf_grayScale = img_transfr_frame.Convert<Gray,Byte>();
                
                Rectangle[] rects = carLicense_classifier.DetectMultiScale(imgTransf_grayScale, 1.1, 2, Size.Empty);

                return rects;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                nv.HoTen = txtTenNV.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.GioiTinh = txtGT.Text;
                nv.SoCMND = txtCMND.Text;
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
                nv.HoTen = txtTenNV.Text;
                nv.GioiTinh = txtGT.Text;
                nv.SoCMND = txtCMND.Text;
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
    }
}
