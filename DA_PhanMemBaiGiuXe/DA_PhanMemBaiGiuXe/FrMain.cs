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
    public partial class FrMain : Form
    {
        private string chucvu;

        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        public FrMain()
        {
            InitializeComponent();
        }

        private void FrMain_Load(object sender, EventArgs e)
        {
            if (chucvu == "Nhân Viên")
            {
                this.tp_NV.Enabled = true;
                this.tp_XeVao.Enabled = false;
                this.tp_XeRa.Enabled = false;
            }
            else
            {
                this.tp_XeVao.Enabled = true;
                this.tp_XeRa.Enabled = true;
                this.tp_NV.Enabled = false;
            }
        }


        

    }
}
