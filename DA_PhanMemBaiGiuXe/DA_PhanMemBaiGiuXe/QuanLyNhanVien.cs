using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBaiGiuXeBLL;
namespace DA_PhanMemBaiGiuXe
{
    public partial class QuanLyNhanVien : Form
    {
        NhanVienBLL NV = new NhanVienBLL();
        private string tenDN;
        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }
        public void reload()
        {
            dataGridView1.DataSource = NV.loadNhanVien();
        }
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            int day = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            txtNS.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            reload();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text;
                string tennv = txtTenNV.Text;
                string gt = txtGT.Text;
                string sdt = txtSDT.Text;
                string ns = txtNS.Text;
                string diachi = txtDiaChi.Text;
                string socmnd = txtCMND.Text;
                if (String.IsNullOrEmpty(manv) || String.IsNullOrEmpty(tennv) || String.IsNullOrEmpty(gt) || String.IsNullOrEmpty(sdt) || String.IsNullOrEmpty(ns) || String.IsNullOrEmpty(diachi) || String.IsNullOrEmpty(socmnd))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!NV.KTKhoaChinh(manv))
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NV.ThemNhanVien(manv, tennv, gt, sdt, DateTime.Parse(ns.ToString()), diachi,socmnd))
                    {
                        dataGridView1.DataSource = NV.loadNhanVien();
                        MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        dataGridView1.DataSource = NV.loadNhanVien();
                        MessageBox.Show("Thêm không thành công", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column1"].Value.ToString();
                if (String.IsNullOrEmpty(manv))
                {
                    MessageBox.Show("Vui lòng nhập mã nhân viên  muốn xóa, hoặc chọn trên lưới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NV.XoaNhanVien(manv))
                    {
                        reload();
                        MessageBox.Show("Xoa Thành Công");
                    }
                    else
                    {
                        reload();
                        MessageBox.Show("Xoa Thất Bại");
                    }

                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên  muốn xóa, hoặc chọn trên lưới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = txtMaNV.Text;
                string tennv = txtTenNV.Text;
                string gt = txtGT.Text;
                string sdt = txtSDT.Text;
                string ns = txtNS.Text;
                string diachi = txtDiaChi.Text;
                string socmnd = txtCMND.Text;
                if (String.IsNullOrEmpty(manv) || String.IsNullOrEmpty(tennv) || String.IsNullOrEmpty(gt) || String.IsNullOrEmpty(sdt) || String.IsNullOrEmpty(ns) || String.IsNullOrEmpty(diachi) || String.IsNullOrEmpty(socmnd))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NV.SuaNhanVien(manv, tennv, gt, sdt, DateTime.Parse(ns.ToString()), diachi, socmnd))
                    {
                        dataGridView1.DataSource = NV.loadNhanVien();
                        MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        dataGridView1.DataSource = NV.loadNhanVien();
                        MessageBox.Show("Sửa không thành công", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaNV.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column1"].FormattedValue.ToString();
                txtTenNV.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column2"].FormattedValue.ToString();
                txtGT.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column3"].FormattedValue.ToString();
                txtSDT.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column4"].FormattedValue.ToString();
                txtNS.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column5"].FormattedValue.ToString();
                txtDiaChi.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column6"].FormattedValue.ToString();
                txtCMND.Text = dataGridView1.SelectedCells[0].OwningRow.Cells["Column7"].FormattedValue.ToString();
            }
            catch { }
           
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }


        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
                e.Handled = true;
            /*if (!char.IsNumber(e.KeyChar))
             {
                 MessageBox.Show("Chỉ nhập kí tự số");
                 e.Handled = true;
             }*/
        }

        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' )
                e.Handled = true;
            /*if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar == ' ') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == (char)8))
                e.Handled = true;*/
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void txtNS_ValueChanged(object sender, EventArgs e)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(txtNS.Value.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            if (age < 18)
            {
                MessageBox.Show("Tuổi phải lớn hơn 18");
            }
        }
    }
}
