namespace DA_PhanMemBaiGiuXe
{
    partial class FrLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrLogin));
            this.rdo_QL = new System.Windows.Forms.RadioButton();
            this.rdo_NV = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_Login = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdo_QL
            // 
            this.rdo_QL.AutoSize = true;
            this.rdo_QL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_QL.ForeColor = System.Drawing.Color.Blue;
            this.rdo_QL.Location = new System.Drawing.Point(491, 158);
            this.rdo_QL.Name = "rdo_QL";
            this.rdo_QL.Size = new System.Drawing.Size(114, 50);
            this.rdo_QL.TabIndex = 2;
            this.rdo_QL.TabStop = true;
            this.rdo_QL.Text = "Quản lý";
            this.rdo_QL.UseVisualStyleBackColor = true;
            // 
            // rdo_NV
            // 
            this.rdo_NV.AutoSize = true;
            this.rdo_NV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_NV.ForeColor = System.Drawing.Color.Blue;
            this.rdo_NV.Location = new System.Drawing.Point(611, 158);
            this.rdo_NV.Name = "rdo_NV";
            this.rdo_NV.Size = new System.Drawing.Size(131, 50);
            this.rdo_NV.TabIndex = 3;
            this.rdo_NV.TabStop = true;
            this.rdo_NV.Text = "Nhân viên";
            this.rdo_NV.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Controls.Add(this.rdo_NV, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.rdo_QL, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_Login, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txt_Password, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_Login, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_Thoat, 4, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.28926F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.71074F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(754, 266);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(347, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 71);
            this.label1.TabIndex = 6;
            this.label1.Text = "Đăng Nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 5);
            this.pictureBox1.Size = new System.Drawing.Size(330, 243);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // txt_Login
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_Login, 3);
            this.txt_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Login.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Login.Location = new System.Drawing.Point(347, 82);
            this.txt_Login.Multiline = true;
            this.txt_Login.Name = "txt_Login";
            this.txt_Login.Size = new System.Drawing.Size(395, 32);
            this.txt_Login.TabIndex = 8;
            this.txt_Login.Text = "Username";
            this.txt_Login.Enter += new System.EventHandler(this.txt_Login_Enter);
            this.txt_Login.Leave += new System.EventHandler(this.txt_Login_Leave);
            // 
            // txt_Password
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_Password, 3);
            this.txt_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Password.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Password.Location = new System.Drawing.Point(347, 120);
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(395, 32);
            this.txt_Password.TabIndex = 9;
            this.txt_Password.Text = "Password";
            this.txt_Password.Enter += new System.EventHandler(this.txt_Password_Enter);
            this.txt_Password.Leave += new System.EventHandler(this.txt_Password_Leave);
            // 
            // btn_Login
            // 
            this.btn_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Login.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Login.ImageOptions.Image")));
            this.btn_Login.Location = new System.Drawing.Point(491, 214);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(114, 40);
            this.btn_Login.TabIndex = 10;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.ImageOptions.Image")));
            this.btn_Thoat.Location = new System.Drawing.Point(611, 214);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(131, 40);
            this.btn_Thoat.TabIndex = 11;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.FrLogin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rdo_QL;
        private System.Windows.Forms.RadioButton rdo_NV;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txt_Login;
        private System.Windows.Forms.TextBox txt_Password;
        private DevExpress.XtraEditors.SimpleButton btn_Login;
        private DevExpress.XtraEditors.SimpleButton btn_Thoat;
    }
}