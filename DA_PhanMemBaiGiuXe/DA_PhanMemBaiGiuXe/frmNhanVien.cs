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
    public partial class frmNhanVien : Form
    {
        NhanVienBLL NV = new NhanVienBLL();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        public void reload()
        {
            dataGridView1.DataSource = NV.loadNhanVien();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column1"].Value.ToString();
                string tennv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column2"].Value.ToString();
                string gt = dataGridView1.SelectedCells[0].OwningRow.Cells["Column3"].Value.ToString();
                string sdt = dataGridView1.SelectedCells[0].OwningRow.Cells["Column4"].Value.ToString();
                string ns = dataGridView1.SelectedCells[0].OwningRow.Cells["Column5"].Value.ToString();
                string diachi = dataGridView1.SelectedCells[0].OwningRow.Cells["Column6"].Value.ToString();
                if (String.IsNullOrEmpty(manv) || String.IsNullOrEmpty(manv) || String.IsNullOrEmpty(tennv) || String.IsNullOrEmpty(gt) || String.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!NV.KTKhoaChinh(manv))
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NV.ThemNhanVien(manv, tennv, gt, sdt, DateTime.Parse(ns.ToString()), diachi))
                    {
                        //reload();
                        MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //reload();
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
                    if(NV.XoaNhanVien(manv))
                    {
                        //reload();
                        MessageBox.Show("Xoa Thành Công");
                    }
                    else
                    //reload();
                    MessageBox.Show("Xoa Thất Bại");
                    
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên  muốn xóa, hoặc chọn trên lưới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column1"].Value.ToString();
                string tennv = dataGridView1.SelectedCells[0].OwningRow.Cells["Column2"].Value.ToString();
                string gt = dataGridView1.SelectedCells[0].OwningRow.Cells["Column3"].Value.ToString();
                string sdt = dataGridView1.SelectedCells[0].OwningRow.Cells["Column4"].Value.ToString();
                string ns = dataGridView1.SelectedCells[0].OwningRow.Cells["Column5"].Value.ToString();
                string diachi = dataGridView1.SelectedCells[0].OwningRow.Cells["Column6"].Value.ToString();
                if (NV.SuaNhanVien(manv, tennv, gt, sdt, DateTime.Parse(ns.ToString()), diachi))
                {
                    reload();
                    MessageBox.Show("Sửa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    reload();
                    MessageBox.Show("Sửa không thành công", "Thất Bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (NV.LuuNhanVien())
            {
                reload();
                MessageBox.Show("Lưu Thành Công");
            }
            else
            {
                reload();
                MessageBox.Show("Lưu Thất Bại");
            }
        }
    }
}
