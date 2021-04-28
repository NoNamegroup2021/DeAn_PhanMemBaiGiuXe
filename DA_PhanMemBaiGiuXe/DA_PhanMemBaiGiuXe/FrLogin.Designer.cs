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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_Login = new System.Windows.Forms.TextBox();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.rdo_QL = new System.Windows.Forms.RadioButton();
            this.rdo_NV = new System.Windows.Forms.RadioButton();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // txt_Login
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_Login, 2);
            this.txt_Login.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Login.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Login.Location = new System.Drawing.Point(87, 85);
            this.txt_Login.Multiline = true;
            this.txt_Login.Name = "txt_Login";
            this.txt_Login.Size = new System.Drawing.Size(438, 33);
            this.txt_Login.TabIndex = 0;
            this.txt_Login.Text = "Username";
            this.txt_Login.Enter += new System.EventHandler(this.txt_Login_Enter);
            this.txt_Login.Leave += new System.EventHandler(this.txt_Login_Leave);
            // 
            // txt_Password
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txt_Password, 2);
            this.txt_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Password.ForeColor = System.Drawing.Color.DarkOrange;
            this.txt_Password.Location = new System.Drawing.Point(87, 124);
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(438, 32);
            this.txt_Password.TabIndex = 1;
            this.txt_Password.Text = "Password";
            this.txt_Password.Enter += new System.EventHandler(this.txt_Password_Enter);
            this.txt_Password.Leave += new System.EventHandler(this.txt_Password_Leave);
            // 
            // rdo_QL
            // 
            this.rdo_QL.AutoSize = true;
            this.rdo_QL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdo_QL.ForeColor = System.Drawing.Color.Blue;
            this.rdo_QL.Location = new System.Drawing.Point(87, 162);
            this.rdo_QL.Name = "rdo_QL";
            this.rdo_QL.Size = new System.Drawing.Size(227, 50);
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
            this.rdo_NV.Location = new System.Drawing.Point(320, 162);
            this.rdo_NV.Name = "rdo_NV";
            this.rdo_NV.Size = new System.Drawing.Size(205, 50);
            this.rdo_NV.TabIndex = 3;
            this.rdo_NV.TabStop = true;
            this.rdo_NV.Text = "Nhân viên";
            this.rdo_NV.UseVisualStyleBackColor = true;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(320, 218);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(205, 35);
            this.btn_Thoat.TabIndex = 4;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(87, 218);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(227, 35);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "Đăng Nhập";
            this.btn_Login.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.63043F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.36957F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.Controls.Add(this.rdo_NV, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.rdo_QL, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btn_Thoat, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btn_Login, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txt_Login, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_Password, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.28925F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.71074F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(623, 266);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(87, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 74);
            this.label1.TabIndex = 6;
            this.label1.Text = "Đăng Nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Navy;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrLogin";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.FrLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.TextBox txt_Login;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.RadioButton rdo_QL;
        private System.Windows.Forms.RadioButton rdo_NV;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}