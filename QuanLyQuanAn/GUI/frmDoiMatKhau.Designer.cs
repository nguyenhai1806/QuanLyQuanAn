
namespace QuanLyQuanAn.GUI
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NewPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_RepeatPass = new System.Windows.Forms.TextBox();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_Invisible = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lbl_Hide = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(140, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(19, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pass.Location = new System.Drawing.Point(187, 145);
            this.txt_Pass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(256, 30);
            this.txt_Pass.TabIndex = 1;
            this.txt_Pass.UseSystemPasswordChar = true;
            this.txt_Pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Pass_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(19, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu mới";
            // 
            // txt_NewPass
            // 
            this.txt_NewPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NewPass.Location = new System.Drawing.Point(187, 194);
            this.txt_NewPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_NewPass.Name = "txt_NewPass";
            this.txt_NewPass.Size = new System.Drawing.Size(256, 30);
            this.txt_NewPass.TabIndex = 2;
            this.txt_NewPass.UseSystemPasswordChar = true;
            this.txt_NewPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_NewPass_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(19, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Mật khẩu mới";
            // 
            // txt_RepeatPass
            // 
            this.txt_RepeatPass.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RepeatPass.Location = new System.Drawing.Point(187, 251);
            this.txt_RepeatPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_RepeatPass.Name = "txt_RepeatPass";
            this.txt_RepeatPass.Size = new System.Drawing.Size(256, 30);
            this.txt_RepeatPass.TabIndex = 3;
            this.txt_RepeatPass.UseSystemPasswordChar = true;
            this.txt_RepeatPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RepeatPass_KeyPress);
            this.txt_RepeatPass.Leave += new System.EventHandler(this.txt_RepeatPass_Leave);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btn_DangNhap.Location = new System.Drawing.Point(240, 300);
            this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(203, 48);
            this.btn_DangNhap.TabIndex = 4;
            this.btn_DangNhap.Text = "Đổi mật khẩu";
            this.btn_DangNhap.UseVisualStyleBackColor = true;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(443, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 13;
            // 
            // lbl_Invisible
            // 
            this.lbl_Invisible.AutoSize = true;
            this.lbl_Invisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Invisible.Image = ((System.Drawing.Image)(resources.GetObject("lbl_Invisible.Image")));
            this.lbl_Invisible.Location = new System.Drawing.Point(449, 153);
            this.lbl_Invisible.Name = "lbl_Invisible";
            this.lbl_Invisible.Size = new System.Drawing.Size(24, 20);
            this.lbl_Invisible.TabIndex = 14;
            this.lbl_Invisible.Text = "   ";
            this.lbl_Invisible.Click += new System.EventHandler(this.lbl_Invisible_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(19, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 26);
            this.label6.TabIndex = 15;
            this.label6.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(187, 100);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(256, 30);
            this.txtUsername.TabIndex = 16;
            // 
            // lbl_Hide
            // 
            this.lbl_Hide.AutoSize = true;
            this.lbl_Hide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hide.Image = ((System.Drawing.Image)(resources.GetObject("lbl_Hide.Image")));
            this.lbl_Hide.Location = new System.Drawing.Point(449, 153);
            this.lbl_Hide.Name = "lbl_Hide";
            this.lbl_Hide.Size = new System.Drawing.Size(24, 20);
            this.lbl_Hide.TabIndex = 5;
            this.lbl_Hide.Text = "   ";
            this.lbl_Hide.Click += new System.EventHandler(this.lbl_Hide_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 402);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txt_RepeatPass);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_NewPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Hide);
            this.Controls.Add(this.lbl_Invisible);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmDoiMatKhau";
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_NewPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_RepeatPass;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_Invisible;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lbl_Hide;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}