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
    public partial class FrLogin : Form
    {
        QLXMDataContext data = new QLXMDataContext();
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
            string id = txt_Login.Text;
            string pw = txt_Password.Text;
            string chucvu = null;
            foreach (Control ctr in tableLayoutPanel1.Controls)
            {
                if (ctr.GetType() == typeof(RadioButton))
                {
                    RadioButton rd = ctr as RadioButton;
                    if (rd.Checked == true)
                    {
                        chucvu = rd.Text;
                        break;
                    }
                }
            }

            if (!ktKhoaChinh(txt_Login.Text,txt_Password.Text))
            {
                Program.main = new FrMain();
                foreach (Control ctr in Program.main.Controls)
                {
                    if (ctr.GetType() == typeof(TabControl))
                    {
                        TabControl tab = ctr as TabControl;
                        tab.SelectedTab = tab.TabPages["tp_XeVao"];
                        break;
                    }
                }

                Program.main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                return;
            }
        }
        public bool ktKhoaChinh(string ma, string mk)
        {
            Login tk = data.Logins.Where(t => t.Username == ma && t.Password == mk).SingleOrDefault();
          
            // LinQ 
            if (tk != null)
            {
                return false;
            }
            return true;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Xác nhận thoát chương trình ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Close();
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
            {
                if (txt_Login.Text == "")
                {
                    txt_Login.Text = "Username";
                    txt_Login.ForeColor = Color.DarkOrange;
                }
            }
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


        //private void txt_Login_Click(object sender, EventArgs e)
        //{
        //    //txt_Login.Text = "";
        //}

    }
}








