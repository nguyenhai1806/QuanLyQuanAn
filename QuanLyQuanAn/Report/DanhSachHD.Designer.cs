
namespace QuanLyQuanAn.Report
{
    partial class DanhSachHD
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboMaHD = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn:";
            // 
            // cboMaHD
            // 
            this.cboMaHD.FormattingEnabled = true;
            this.cboMaHD.Location = new System.Drawing.Point(336, 44);
            this.cboMaHD.Name = "cboMaHD";
            this.cboMaHD.Size = new System.Drawing.Size(181, 24);
            this.cboMaHD.TabIndex = 1;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnShow.Location = new System.Drawing.Point(717, 33);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(161, 38);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(13, 96);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1072, 529);
            this.crystalReportViewer1.TabIndex = 3;
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnReturn.Location = new System.Drawing.Point(902, 33);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(161, 38);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // DanhSachHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 654);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cboMaHD);
            this.Controls.Add(this.label1);
            this.Name = "DanhSachHD";
            this.Text = "Danh Sách Hóa Đơn";
            this.Load += new System.EventHandler(this.DanhSachHD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboMaHD;
        private System.Windows.Forms.Button btnShow;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnReturn;
    }
}