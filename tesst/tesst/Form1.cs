using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tesst
{
    public partial class Form1 : Form
    {
        SqlConnection cnn = new SqlConnection(Properties.Settings.Default.KNDL);
        DataSet QLBaiXe = new DataSet();
        SqlDataAdapter tb_QuetThe;
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }
        //DataClasses1DataContext data = new DataClasses1DataContext();


        public bool ktKhoaChinhQX(string id, string bienso)
        {
            int kq = 0;
            tb_QuetThe = new SqlDataAdapter("SELECT COUNT(*) FROM QuetXe WHERE IDThe='" + id + "' AND BienSo='" + bienso + "' ", cnn);
            tb_QuetThe.Fill(QLBaiXe, "TT");
            DataTable ds = QLBaiXe.Tables["TT"];
            foreach (DataRow row in ds.Rows)
            {
                kq = int.Parse(row[0].ToString());
            }
            if(kq==1)
            {
                return false;
            }
            return true;
        }

        //public bool ktKhoaChinhQX1(string bienso)
        //{
        //    int kq = 0;
        //    tb_QuetThe = new SqlDataAdapter("SELECT COUNT(*) FROM BangThe WHERE MaThe='" + bienso + "'", cnn);
        //    tb_QuetThe.Fill(QLBaiXe, "TT");
        //    DataTable ds = QLBaiXe.Tables["TT"];
        //    foreach (DataRow row in ds.Rows)
        //    {
        //        kq = int.Parse(row[0].ToString());
        //    }
        //    if (kq == 1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


        public bool Them(string id, string bienso, string anhthe)
        {
            string sql = "insert into QuetXe values(@IDThe,@BIENSO,@AnhThe)";
            try
            {
                cmd =new   SqlCommand(sql, cnn);
                cnn.Open();
                cmd.Parameters.Add("@IDThe", SqlDbType.NVarChar).Value = id;
                cmd.Parameters.Add("@BIENSO", SqlDbType.NVarChar).Value = bienso;
                cmd.Parameters.Add("@AnhThe", SqlDbType.NVarChar).Value = anhthe;
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public string KiemTraTinhtrang(string mathe)
        {
            string kq = "";
            tb_QuetThe = new SqlDataAdapter("SELECT TinhTrang FROM BangThe WHERE MaThe='" + mathe + "'", cnn);
            tb_QuetThe.Fill(QLBaiXe, "TT");
            DataTable ds = QLBaiXe.Tables["TT"];
            foreach (DataRow row in ds.Rows)
            {
                kq = row[0].ToString();
            }
            return kq;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            try
            {
          
                
                if (e.KeyChar == 13)
                {

                    if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text))
                    {
                        MessageBox.Show("Vui lòng nhập mã môn học và tên môn học", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (!ktKhoaChinhQX(textBox1.Text,textBox2.Text))
                    {
                        MessageBox.Show("Mã này đã tồn tại! Xin vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //BangThe the = data.BangThes.Where(t => t.MaThe == textBox1.Text).SingleOrDefault();
                        string kq = KiemTraTinhtrang(textBox1.Text);

                        if ( kq== "False")
                        {
                            if(Them(textBox1.Text,textBox2.Text,textBox3.Text))
                            {
                                //QuetXe qx = new QuetXe();
                                //qx.IDThe = textBox1.Text;
                                //qx.BIENSO = textBox2.Text;
                                //qx.AnhThe = textBox3.Text;
                                //data.QuetXes.InsertOnSubmit(qx);

                                //data.SubmitChanges();
                                MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Tinh trang true");
                        }
                        }
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
