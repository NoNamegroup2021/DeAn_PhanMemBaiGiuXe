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
    public partial class XemThe : Form
    {
        QLTheBLL qlthe = new QLTheBLL();
        private string tenDN;
        public string TenDN
        {
            get { return tenDN; }
            set { tenDN = value; }
        }
        public XemThe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length <=0)
            {
                DataTable data =(DataTable)dataGridView1.DataSource;
                if (data != null)
                    data.Clear();
                var thes = qlthe.loadDS();
                dataGridView1.DataSource = thes;
            }
            else
            {
                var the = qlthe.getInfoThe(textBox1.Text.Trim());
                if (the != null)
                    dataGridView1.DataSource = the;

            }
        }

        private void XemThe_Load(object sender, EventArgs e)
        {
            var thes = qlthe.loadDS();
            dataGridView1.DataSource = thes;
        }
    }
}
