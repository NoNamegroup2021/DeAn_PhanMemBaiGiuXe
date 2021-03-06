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
using PhanMemBaiGiuXeDAL;
namespace DA_PhanMemBaiGiuXe
{
    public partial class FrLogin : Form
    {
        LoginBLL log_functs = new LoginBLL();
        public FrLogin()
        {
            InitializeComponent();
        }

        private void FrLogin_Load(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
        }

        

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                int type = 0;
                foreach(Control ctr in tableLayoutPanel1.Controls)
                {
                    if(ctr.GetType() == typeof(RadioButton))
                    {
                        RadioButton rd = ctr as RadioButton;
                        if(rd.Checked)
                        {
                            if (rd.Name.Equals("rdo_NV"))
                                type = 1;
                            else if(rd.Name.Equals("rdo_QL"))
                                type = 2;
                        }
                        if (type != 0)
                            break;
                    }    
                }
                string user = this.txt_Login.Text;
                string mk = this.txt_Password.Text;
                bool kq = log_functs.log(user, mk, type);
                if(kq)
                {
                    Program.main_from = new MainForm();
                    this.Hide();
                    if(type ==1)
                    {
                        Control ctr = Program.main_from.Controls["tableLayoutPanel1"];
                        if(ctr != null)
                        {
                            foreach(Control item in ctr.Controls)
                            {
                                if(item.GetType() == typeof(GroupBox))
                                {
                                    MenuStrip mnu = item.Controls["menuStrip2"] as MenuStrip;
                                    if (mnu == null)
                                        return;
                                    else
                                    {
                                        ToolStripMenuItem tagItem = mnu.Items["QLY"] as ToolStripMenuItem;
                                        if (tagItem != null)
                                            tagItem.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    Program.main_from.tenDN = user;
                    Program.main_from.Show();
                    MessageBox.Show("Dang nhap thanh cong");
                }
                else
                    MessageBox.Show("Dang nhap that bai");
            }
            catch
            {
                MessageBox.Show("Dang nhap that bai");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận thoát chương trình ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        private void checkEmptyText(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text.Trim().Length <= 0)
            {
                this.errorProvider1.SetError(txt, "Vui lòng không để trống mục này");
                txt.Focus();
            }
            else
            {
                this.errorProvider1.Clear();
            }
        }

        private void txt_TK_Leave(object sender, EventArgs e)
        {
            checkEmptyText(sender, e);
        }

        private void txt_MK_Leave(object sender, EventArgs e)
        {
            checkEmptyText(sender, e);
        }

        private void txt_Login_Enter(object sender, EventArgs e)
        {
            {
                if (txt_Login.Text == "Username")
                {
                    txt_Login.Text = "";
                    txt_Login.ForeColor = Color.Black;
                }
            }

        }

        private void txt_Login_Leave(object sender, EventArgs e)
        {

        }

        private void txt_Password_Enter(object sender, EventArgs e)
        {
            {
                if (txt_Password.Text == "Password")
                {
                    txt_Password.Text = "";
                    txt_Password.ForeColor = Color.Black;
                }
            }
        }

        private void txt_Password_Leave(object sender, EventArgs e)
        {
            {
                if (txt_Password.Text == "")
                {
                    txt_Password.Text = "Password";
                    txt_Password.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


        ////private void txt_Login_Click(object sender, EventArgs e)
        ////{
        ////    //txt_Login.Text = "";
        ////}

    }
}








