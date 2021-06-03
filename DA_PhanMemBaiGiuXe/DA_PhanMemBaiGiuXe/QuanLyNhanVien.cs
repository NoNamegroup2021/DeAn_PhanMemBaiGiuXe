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
            reload();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //string manv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column1"].Value.ToString();
                //string tennv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column2"].Value.ToString();
                //string gt = dataGridView1.SelectedCells[0].OwningRow.Cells["Column3"].Value.ToString();
                //string sdt = dataGridView1.SelectedCells[0].OwningRow.Cells["Column4"].Value.ToString();
                //string ns = dataGridView1.SelectedCells[0].OwningRow.Cells["Column5"].Value.ToString();
                //string diachi = dataGridView1.SelectedCells[0].OwningRow.Cells["Column6"].Value.ToString();
                //string socmnd = dataGridView1.SelectedCells[0].OwningRow.Cells["Column7"].Value.ToString();
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
            this.Close();
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
            /* if(e.RowIndex >= 0){
                 DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                 txtMaNV.Text = row.Cells[0].Value.ToString();
                 txtTenNV.Text = row.Cells[1].Value.ToString();
                 txtGT.Text = row.Cells[3].Value.ToString();
                 txtSDT.Text = row.Cells[4].Value.ToString();
                 txtNS.Text = row.Cells[5].Value.ToString();
                 txtDiaChi.Text = row.Cells[6].Value.ToString();
                 txtCMND.Text = row.Cells[7].Value.ToString();
                 txtMaNV.Enabled = false;

             }*/

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
            catch (Exception ex)
            {
                MessageBox.Show("");
            }
            //if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    dataGridView1.CurrentCell.Selected = true;
            //    txtMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    txtTenNV.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    txtGT.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    txtSDT.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    txtNS.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //    txtCMND.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            //}
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
