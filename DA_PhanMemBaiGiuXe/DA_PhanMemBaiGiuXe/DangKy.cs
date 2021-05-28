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
    public partial class DangKy : Form
    {
        DataClasses1DataContext data = new DataClasses1DataContext();
        public DangKy()
        {
            InitializeComponent();
        }
        public void reload()
        {
            var TK = from tk in data.TaiKhoans select new { TenTaiKhoan = tk.TenTaiKhoan, Password = tk.Password, LoaiTaiKhoan = tk.LoaiTaiKhoan,MaNV = tk.MaNV };
            dtgv_TK.DataSource = TK;
        }
        public bool ktkhoachinh(string ttk)
        {
            TaiKhoan tk = data.TaiKhoans.Where(t => t.TenTaiKhoan == ttk).SingleOrDefault();
            if (tk != null)
            {
                return false;
            }
            return true;
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            try
            {
                reload();
            }
            catch
            {

            }
        }

        private void dtgv_TK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgv_TK.CurrentRow != null)
                {
                    txt_Username.Text = dtgv_TK.CurrentRow.Cells[0].Value.ToString();
                    txt_Password.Text = dtgv_TK.CurrentRow.Cells[1].Value.ToString();
                    txt_ConfirmPW.Text = dtgv_TK.CurrentRow.Cells[1].Value.ToString();
                    txt_MaNV.Text = dtgv_TK.CurrentRow.Cells["MaNV"].Value.ToString();
                    int type = int.Parse(dtgv_TK.CurrentRow.Cells["LoaiTK"].Value.ToString());
                    if (type == 1)
                    {
                        Control ctr = pn_LTK.Controls["rdo_NhanVien"];
                        RadioButton rd = ctr as RadioButton;
                        rd.Checked = true;

                    }
                    else
                    {
                        Control ctr = pn_LTK.Controls["rdo_QuanLy"];
                        RadioButton rd = ctr as RadioButton;
                        rd.Checked = true;
                    }
                }
            }
            catch
            {           
            }
        }
        public bool ktCheck(Panel p)
        {
            for (int i = 0; i < p.Controls.Count; i++)
            {
                RadioButton rd = (RadioButton)p.Controls[i];
                if (rd.Checked)
                {
                    return true;
                }
            }
            return false;
        }
        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            if (ktkhoachinh(txt_Username.Text.ToString()))
            {
                if(String.IsNullOrEmpty(txt_Username.Text) || String.IsNullOrEmpty(txt_Password.Text) || String.IsNullOrEmpty(txt_MaNV.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                else 
                    {
                    TaiKhoan tk = new TaiKhoan();
                    tk.TenTaiKhoan = txt_Username.Text;
                    tk.Password = txt_Password.Text;
                    tk.MaNV = txt_MaNV.Text;
                    int LoaiTK = 0;
                    if (ktCheck(pn_LTK))
                    {
                        for (int i = 0; i < pn_LTK.Controls.Count; i++)
                        {
                            RadioButton rd = (RadioButton)pn_LTK.Controls[i];
                            if (rd.Checked)
                            {
                                switch (rd.Text)
                                {
                                    case "Nhân Viên":
                                        LoaiTK = 1;
                                        break;
                                    case "Quản Lý":
                                        LoaiTK = 2;
                                        break;
                                }
                            }
                        }
                     }
                  else
                    {
                        MessageBox.Show("Bạn phải check vào loại tài khoản muốn tạo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tk.LoaiTaiKhoan = LoaiTK;
                    data.TaiKhoans.InsertOnSubmit(tk);
                    data.SubmitChanges();
                    reload();
                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else
            {
                MessageBox.Show("Username này đã tồn tại! Hãy thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_Username.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string us = dtgv_TK.CurrentRow.Cells[0].Value.ToString();
                TaiKhoan tk = data.TaiKhoans.Where(t => t.TenTaiKhoan == us).SingleOrDefault();
                data.TaiKhoans.DeleteOnSubmit(tk);
                data.SubmitChanges();
                reload();
                MessageBox.Show("Xóa thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_Username.Text) || String.IsNullOrEmpty(txt_Password.Text) || String.IsNullOrEmpty(txt_MaNV.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string us = dtgv_TK.CurrentRow.Cells[0].Value.ToString();
                    TaiKhoan tk = new TaiKhoan();
                    tk.TenTaiKhoan = txt_Username.Text;
                    tk.Password = txt_Password.Text;
                    tk.MaNV = txt_MaNV.Text;
                    int LoaiTK = 0;
                    if (ktCheck(pn_LTK))
                    {                        
                        for (int i = 0; i < pn_LTK.Controls.Count; i++)
                        {
                            RadioButton rd = (RadioButton)pn_LTK.Controls[i];
                            if (rd.Checked)
                            {
                                switch (rd.Text)
                                {
                                    case "Nhân Viên":
                                        LoaiTK = 1;
                                        break;
                                    case "Quản Lý":
                                        LoaiTK = 2;
                                        break;
                                }
                            }
                        }
                      }
                    else
                    {
                        MessageBox.Show("Bạn phải check vào loại tài khoản muốn tạo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    tk.LoaiTaiKhoan = LoaiTK;
                    data.SubmitChanges();
                    reload();
                    MessageBox.Show("Sửa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
