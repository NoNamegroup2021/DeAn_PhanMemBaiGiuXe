using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary1
{
    public partial class UserControl1: UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private string _Ngay;

        public string Ngay
        {
            get { return _Ngay; }
            set { _Ngay = value; }
        }
        private string _Gio;

        public string Gio
        {
            get { return _Gio; }
            set { _Gio = value; }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToLongDateString();
            label1.Text = DateTime.Now.ToString("MM/dd/yyyy");
            label2.Text = DateTime.Now.ToLongTimeString();
            Ngay = label1.Text;
            Gio = label2.Text;
        }
    }
}
