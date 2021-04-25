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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.rd_QL = new System.Windows.Forms.RadioButton();
            this.rd_NV = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TK = new System.Windows.Forms.TextBox();
            this.txt_MK = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.89743F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.10256F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Thoat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rd_QL, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rd_NV, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_TK, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txt_MK, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Login, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(751, 427);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Thoat.Location = new System.Drawing.Point(15, 389);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(249, 34);
            this.btn_Thoat.TabIndex = 0;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // rd_QL
            // 
            this.rd_QL.AutoSize = true;
            this.rd_QL.Dock = System.Windows.Forms.DockStyle.Right;
            this.rd_QL.ForeColor = System.Drawing.Color.Red;
            this.rd_QL.Location = new System.Drawing.Point(182, 312);
            this.rd_QL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rd_QL.Name = "rd_QL";
            this.rd_QL.Size = new System.Drawing.Size(83, 71);
            this.rd_QL.TabIndex = 2;
            this.rd_QL.TabStop = true;
            this.rd_QL.Text = "Quản Lý";
            this.rd_QL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rd_QL.UseVisualStyleBackColor = false;
            // 
            // rd_NV
            // 
            this.rd_NV.AutoSize = true;
            this.rd_NV.Dock = System.Windows.Forms.DockStyle.Right;
            this.rd_NV.ForeColor = System.Drawing.Color.Red;
            this.rd_NV.Location = new System.Drawing.Point(629, 312);
            this.rd_NV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rd_NV.Name = "rd_NV";
            this.rd_NV.Size = new System.Drawing.Size(95, 71);
            this.rd_NV.TabIndex = 3;
            this.rd_NV.TabStop = true;
            this.rd_NV.Text = "Nhân Viên";
            this.rd_NV.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 155);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên đăng nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(15, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 155);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_TK
            // 
            this.txt_TK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_TK.Location = new System.Drawing.Point(271, 62);
            this.txt_TK.Margin = new System.Windows.Forms.Padding(3, 62, 3, 2);
            this.txt_TK.Name = "txt_TK";
            this.txt_TK.Size = new System.Drawing.Size(453, 22);
            this.txt_TK.TabIndex = 6;
            this.txt_TK.Leave += new System.EventHandler(this.txt_TK_Leave);
            // 
            // txt_MK
            // 
            this.txt_MK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MK.Location = new System.Drawing.Point(271, 217);
            this.txt_MK.Margin = new System.Windows.Forms.Padding(3, 62, 3, 2);
            this.txt_MK.Name = "txt_MK";
            this.txt_MK.PasswordChar = '*';
            this.txt_MK.Size = new System.Drawing.Size(453, 22);
            this.txt_MK.TabIndex = 7;
            this.txt_MK.Leave += new System.EventHandler(this.txt_MK_Leave);
            // 
            // btn_Login
            // 
            this.btn_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Login.Location = new System.Drawing.Point(272, 389);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(451, 34);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "Đăng Nhập";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // FrLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 457);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrLogin";
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.FrLogin_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.RadioButton rd_QL;
        private System.Windows.Forms.RadioButton rd_NV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TK;
        private System.Windows.Forms.TextBox txt_MK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}