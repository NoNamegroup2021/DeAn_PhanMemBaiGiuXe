﻿
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
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xeVàoToolStripMenuItem,
            this.xeRaToolStripMenuItem,
            this.xemLịchSửGửiXeToolStripMenuItem,
            this.xemTinhTrangTheToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // xeVàoToolStripMenuItem
            // 
            this.xeVàoToolStripMenuItem.Name = "xeVàoToolStripMenuItem";
            this.xeVàoToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.xeVàoToolStripMenuItem.Text = "Xe Vào";
            this.xeVàoToolStripMenuItem.Click += new System.EventHandler(this.xeVàoToolStripMenuItem_Click);
            // 
            // xeRaToolStripMenuItem
            // 
            this.xeRaToolStripMenuItem.Name = "xeRaToolStripMenuItem";
            this.xeRaToolStripMenuItem.Size = new System.Drawing.Size(61, 24);
            this.xeRaToolStripMenuItem.Text = "Xe Ra";
            // 
            // xemLịchSửGửiXeToolStripMenuItem
            // 
            this.xemLịchSửGửiXeToolStripMenuItem.Name = "xemLịchSửGửiXeToolStripMenuItem";
            this.xemLịchSửGửiXeToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.xemLịchSửGửiXeToolStripMenuItem.Text = "Xem Lịch Sử Gửi Xe";
            // 
            // xemTinhTrangTheToolStripMenuItem
            // 
            this.xemTinhTrangTheToolStripMenuItem.Name = "xemTinhTrangTheToolStripMenuItem";
            this.xemTinhTrangTheToolStripMenuItem.Size = new System.Drawing.Size(154, 24);
            this.xemTinhTrangTheToolStripMenuItem.Text = "Xem Tinh Trang The";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 420);
            this.panel1.TabIndex = 1;
            // 
            // ChuongTrinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
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