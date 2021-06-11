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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            //Title
            Label title = new Label();
            title.Text = "WELCOME TO MOTORBIKE PARK";
            title.Font = new Font(new FontFamily("Times new roman"), 14, FontStyle.Bold);
            title.TextAlign = ContentAlignment.TopCenter;
            title.BackColor = Color.Transparent;
            title.Dock = DockStyle.Fill;
            title.ForeColor = Color.Gold;
            //Picturebox
            this.pictureBox1.Controls.Add(title);

            //Progressbar
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 5;
            //this.progressBarControl1.Properties.Step = 1;
            //this.progressBarControl1.Properties.PercentView = true;
            //this.progressBarControl1.Properties.ShowTitle = true;
            //for (int i = 0; i < 100; i++)
            //{
            //    //Thread.Sleep(100);
            //    this.progressBarControl1.PerformStep();
            //    this.progressBarControl1.Update();
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Value++;
            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(100);
            //    this.progressBarControl1.PerformStep();
            //    this.progressBarControl1.Update();
            //    this.progressBarControl1.Properties.EditValueChangedDelay++;
            if (this.progressBar1.Value == this.progressBar1.Maximum)
            {
                this.timer1.Enabled = false;
                Program.login = new FrLogin();
                this.Hide();
                Program.login.Show();
            }
            //}
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
