using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_PhanMemBaiGiuXe
{
    
    public partial class Form1 : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reLoad();
        }
        public void reLoad()
        {
            var NV = from nv in data.NhanViens select nv;
            dataGridView1.DataSource = NV;
        }
        public bool KTKC(string ma)
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
            else if (!KTKC(txtMaNV.Text))
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
            this.Close();
        }
    }
}
