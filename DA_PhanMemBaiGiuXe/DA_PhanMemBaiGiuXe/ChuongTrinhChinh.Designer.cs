
namespace DA_PhanMemBaiGiuXe
{
    partial class ChuongTrinhChinh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.xeVàoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xeRaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemLịchSửGửiXeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemTinhTrangTheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xeVàoToolStripMenuItem,
            this.xeRaToolStripMenuItem,
            this.xemLịchSửGửiXeToolStripMenuItem,
            this.xemTinhTrangTheToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(900, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xeVàoToolStripMenuItem
            // 
            this.xeVàoToolStripMenuItem.Name = "xeVàoToolStripMenuItem";
            this.xeVàoToolStripMenuItem.Size = new System.Drawing.Size(83, 29);
            this.xeVàoToolStripMenuItem.Text = "Xe Vào";
            this.xeVàoToolStripMenuItem.Click += new System.EventHandler(this.xeVàoToolStripMenuItem_Click);
            // 
            // xeRaToolStripMenuItem
            // 
            this.xeRaToolStripMenuItem.Name = "xeRaToolStripMenuItem";
            this.xeRaToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.xeRaToolStripMenuItem.Text = "Xe Ra";
            this.xeRaToolStripMenuItem.Click += new System.EventHandler(this.xeRaToolStripMenuItem_Click);
            // 
            // xemLịchSửGửiXeToolStripMenuItem
            // 
            this.xemLịchSửGửiXeToolStripMenuItem.Name = "xemLịchSửGửiXeToolStripMenuItem";
            this.xemLịchSửGửiXeToolStripMenuItem.Size = new System.Drawing.Size(182, 29);
            this.xemLịchSửGửiXeToolStripMenuItem.Text = "Xem Lịch Sử Gửi Xe";
            this.xemLịchSửGửiXeToolStripMenuItem.Click += new System.EventHandler(this.xemLịchSửGửiXeToolStripMenuItem_Click);
            // 
            // xemTinhTrangTheToolStripMenuItem
            // 
            this.xemTinhTrangTheToolStripMenuItem.Name = "xemTinhTrangTheToolStripMenuItem";
            this.xemTinhTrangTheToolStripMenuItem.Size = new System.Drawing.Size(183, 29);
            this.xemTinhTrangTheToolStripMenuItem.Text = "Xem Tinh Trang The";
            this.xemTinhTrangTheToolStripMenuItem.Click += new System.EventHandler(this.xemTinhTrangTheToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 529);
            this.panel1.TabIndex = 1;
            // 
            // ChuongTrinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChuongTrinhChinh";
            this.Text = "ChuongTrinhChinh";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xeVàoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xeRaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemLịchSửGửiXeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem xemTinhTrangTheToolStripMenuItem;
    }
}