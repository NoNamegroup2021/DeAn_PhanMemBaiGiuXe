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
using WindowsFormsControlLibrary1;

namespace DA_PhanMemBaiGiuXe
{
    public partial class XeVao : Form
    {
        QuanLyXeVaoBLL QLXEV = new QuanLyXeVaoBLL();
        private string tenDN;

        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }
        public XeVao()
        {
            InitializeComponent();
            
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
    }
}
