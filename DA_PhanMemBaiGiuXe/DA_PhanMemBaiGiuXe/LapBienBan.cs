using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using PhanMemBaiGiuXeBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA_PhanMemBaiGiuXe
{
    public partial class LapBienBan : Form
    {
        BienBanBLL bienBanBLL = new BienBanBLL();
        public LapBienBan()
        {
            InitializeComponent();
        }
        int manl = -1;

        private string tenDN;
        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }


        private void LapBienBan_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(151, 202, 219), 1);
            Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(151, 202, 219), Color.FromArgb(214, 232, 238), LinearGradientMode.ForwardDiagonal);
            graphics.FillRectangle(lgb, area);
            graphics.DrawRectangle(pen, area);
        }
        private void loadDT()
        {
            dataGridView1.DataSource = bienBanBLL.getBienBan();
        }
        private void LapBienBan_Load(object sender, EventArgs e)
        {
            loadDT();
            txtMaKH.Enabled = txtTenKH.Enabled = txtDC.Enabled = txtCMND.Enabled = txtSDT.Enabled = txtTenNV.Enabled = txtND.Enabled = date.Enabled = btnLuu.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKH.Focus();
            txtMaKH.Enabled = txtTenKH.Enabled = txtDC.Enabled = txtCMND.Enabled = txtSDT.Enabled = txtTenNV.Enabled = txtND.Enabled = date.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKH.Text) || String.IsNullOrEmpty(txtTenKH.Text) || String.IsNullOrEmpty(txtCMND.Text) || String.IsNullOrEmpty(txtDC.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtTenNV.Text) || String.IsNullOrEmpty(txtND.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int makh = int.Parse(txtMaKH.Text);
                string tenkh = txtTenKH.Text;
                string cmnd = txtCMND.Text;
                string diachi = txtDC.Text;
                string sdt = txtSDT.Text;
                string tennv = txtTenNV.Text;
                DateTime ngay = date.Value;
                string noidung = txtND.Text;
                if (bienBanBLL.addNL(makh, tenkh, cmnd, diachi, sdt, tennv, ngay, noidung))
                {
                    MessageBox.Show("Thêm thành công", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadDT();
                    btnLuu.Enabled = false;
                    txtMaKH.Text = txtTenKH.Text = txtDC.Text = txtCMND.Text = txtSDT.Text = txtTenNV.Text = txtND.Text = ""; date.Value = DateTime.Now;
                    txtMaKH.Enabled = txtTenKH.Enabled = txtDC.Enabled = txtCMND.Enabled = txtSDT.Enabled = txtTenNV.Enabled = txtND.Enabled = date.Enabled = false;

                }
                else
                {
                    MessageBox.Show("tThêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaKH.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[1].Value.ToString();
                txtTenKH.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[2].Value.ToString();
                txtCMND.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[3].Value.ToString();
                txtDC.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[4].Value.ToString();
                txtSDT.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[5].Value.ToString();
                txtTenNV.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[6].Value.ToString();
                txtND.Text = dataGridView1.SelectedCells[0].OwningRow.Cells[8].Value.ToString();
                date.Value = DateTime.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells[7].Value.ToString());
                txtMaKH.Enabled = txtTenKH.Enabled = txtDC.Enabled = txtCMND.Enabled = txtSDT.Enabled = txtTenNV.Enabled = txtND.Enabled = date.Enabled = btnXoa.Enabled = btnSua.Enabled = true;
                manl = int.Parse(dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value.ToString());
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (manl == -1)
            {
                MessageBox.Show("Vui lòng chọn biên bản cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bienBanBLL.ktraKhoaChinh(manl))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (bienBanBLL.deleteNL(manl))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadDT();
                    manl = -1;
                    txtMaKH.Text = txtTenKH.Text = txtDC.Text = txtCMND.Text = txtSDT.Text = txtTenNV.Text = txtND.Text = ""; date.Value = DateTime.Now;
                    txtMaKH.Enabled = txtTenKH.Enabled = txtDC.Enabled = txtCMND.Enabled = txtSDT.Enabled = txtTenNV.Enabled = txtND.Enabled = date.Enabled = btnXoa.Enabled = btnSua.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (manl == -1)
            {
                MessageBox.Show("Vui lòng chọn biên bản cần sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (bienBanBLL.ktraKhoaChinh(manl))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int makh = int.Parse(txtMaKH.Text);
                string tenkh = txtTenKH.Text;
                string cmnd = txtCMND.Text;
                string diachi = txtDC.Text;
                string sdt = txtSDT.Text;
                string tennv = txtTenNV.Text;
                DateTime ngay = date.Value;
                string noidung = txtND.Text;
                if (bienBanBLL.updateNL(manl, makh, tenkh, cmnd, diachi, sdt, tennv, ngay, noidung))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadDT();
                    manl = -1;
                    txtMaKH.Text = txtTenKH.Text = txtDC.Text = txtCMND.Text = txtSDT.Text = txtTenNV.Text = txtND.Text = ""; date.Value = DateTime.Now;
                    txtMaKH.Enabled = txtTenKH.Enabled = txtDC.Enabled = txtCMND.Enabled = txtSDT.Enabled = txtTenNV.Enabled = txtND.Enabled = date.Enabled = btnXoa.Enabled = btnSua.Enabled = false;

                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //XtraReport1 xtraReport1 = new XtraReport1();
            //xtraReport1.DataSource = bienBanBLL.getBienBanbyMaNL(manl);
            //xtraReport1.ShowPreviewDialog();
            rpBienBan xtraReport2 = new rpBienBan() { Name = manl.ToString() };
            xtraReport2.DataSource = bienBanBLL.getBienBanbyMaNL(manl);
            string docxExportFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\" + xtraReport2.Name + ".docx";
            DocxExportOptions docxExportOptions = new DocxExportOptions() { ExportMode = DocxExportMode.SingleFile };

            xtraReport2.ExportToDocx(docxExportFile, docxExportOptions);
            xtraReport2.ShowPreviewDialog();
            dataGridView1.DataSource = bienBanBLL.getBienBanbyMaNL(manl);
        }
    }
}
