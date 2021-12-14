
namespace QuanLyQuanAn.GUI
{
    partial class frmTableManger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableManger));
            this.cbb_Ban = new System.Windows.Forms.ComboBox();
            this.btn_ChuyenBan = new System.Windows.Forms.Button();
            this.cbb_ThanhToan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbb_SoLuong = new System.Windows.Forms.NumericUpDown();
            this.btn_ThemMon = new System.Windows.Forms.Button();
            this.cbb_MonAn = new System.Windows.Forms.ComboBox();
            this.ccb_LoaiMon = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_SoLuong)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_Ban
            // 
            this.cbb_Ban.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Ban.FormattingEnabled = true;
            this.cbb_Ban.Location = new System.Drawing.Point(858, 813);
            this.cbb_Ban.Name = "cbb_Ban";
            this.cbb_Ban.Size = new System.Drawing.Size(162, 30);
            this.cbb_Ban.TabIndex = 6;
            // 
            // btn_ChuyenBan
            // 
            this.btn_ChuyenBan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChuyenBan.Location = new System.Drawing.Point(858, 768);
            this.btn_ChuyenBan.Name = "btn_ChuyenBan";
            this.btn_ChuyenBan.Size = new System.Drawing.Size(162, 39);
            this.btn_ChuyenBan.TabIndex = 7;
            this.btn_ChuyenBan.Text = "Chuyển bàn";
            this.btn_ChuyenBan.UseVisualStyleBackColor = true;
            // 
            // cbb_ThanhToan
            // 
            this.cbb_ThanhToan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ThanhToan.Location = new System.Drawing.Point(1308, 768);
            this.cbb_ThanhToan.Name = "cbb_ThanhToan";
            this.cbb_ThanhToan.Size = new System.Drawing.Size(156, 71);
            this.cbb_ThanhToan.TabIndex = 5;
            this.cbb_ThanhToan.Text = "THANH TOÁN";
            this.cbb_ThanhToan.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(858, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(606, 603);
            this.panel3.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbb_SoLuong);
            this.panel2.Controls.Add(this.btn_ThemMon);
            this.panel2.Controls.Add(this.cbb_MonAn);
            this.panel2.Controls.Add(this.ccb_LoaiMon);
            this.panel2.Location = new System.Drawing.Point(854, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(610, 112);
            this.panel2.TabIndex = 7;
            // 
            // cbb_SoLuong
            // 
            this.cbb_SoLuong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_SoLuong.Location = new System.Drawing.Point(4, 76);
            this.cbb_SoLuong.Name = "cbb_SoLuong";
            this.cbb_SoLuong.Size = new System.Drawing.Size(450, 30);
            this.cbb_SoLuong.TabIndex = 3;
            // 
            // btn_ThemMon
            // 
            this.btn_ThemMon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemMon.Location = new System.Drawing.Point(459, 4);
            this.btn_ThemMon.Name = "btn_ThemMon";
            this.btn_ThemMon.Size = new System.Drawing.Size(148, 100);
            this.btn_ThemMon.TabIndex = 4;
            this.btn_ThemMon.Text = "Thêm món";
            this.btn_ThemMon.UseVisualStyleBackColor = true;
            // 
            // cbb_MonAn
            // 
            this.cbb_MonAn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_MonAn.FormattingEnabled = true;
            this.cbb_MonAn.Location = new System.Drawing.Point(4, 40);
            this.cbb_MonAn.Name = "cbb_MonAn";
            this.cbb_MonAn.Size = new System.Drawing.Size(449, 30);
            this.cbb_MonAn.TabIndex = 2;
            // 
            // ccb_LoaiMon
            // 
            this.ccb_LoaiMon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccb_LoaiMon.FormattingEnabled = true;
            this.ccb_LoaiMon.Location = new System.Drawing.Point(4, 4);
            this.ccb_LoaiMon.Name = "ccb_LoaiMon";
            this.ccb_LoaiMon.Size = new System.Drawing.Size(449, 30);
            this.ccb_LoaiMon.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpTable);
            this.panel1.Location = new System.Drawing.Point(12, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(836, 810);
            this.panel1.TabIndex = 6;
            // 
            // flpTable
            // 
            this.flpTable.Location = new System.Drawing.Point(4, 4);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(822, 803);
            this.flpTable.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinCáNhânToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1498, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem1,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Người đăng nhập";
            // 
            // thôngTinCáNhânToolStripMenuItem1
            // 
            this.thôngTinCáNhânToolStripMenuItem1.Name = "thôngTinCáNhânToolStripMenuItem1";
            this.thôngTinCáNhânToolStripMenuItem1.Size = new System.Drawing.Size(210, 26);
            this.thôngTinCáNhânToolStripMenuItem1.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem1.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem1_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(100, 24);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // frmTableManger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 855);
            this.Controls.Add(this.cbb_Ban);
            this.Controls.Add(this.btn_ChuyenBan);
            this.Controls.Add(this.cbb_ThanhToan);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTableManger";
            this.Text = "Phần mềm quản lý quán cafe An Nhiên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTableManger_FormClosing);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbb_SoLuong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_Ban;
        private System.Windows.Forms.Button btn_ChuyenBan;
        private System.Windows.Forms.Button cbb_ThanhToan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown cbb_SoLuong;
        private System.Windows.Forms.Button btn_ThemMon;
        private System.Windows.Forms.ComboBox cbb_MonAn;
        private System.Windows.Forms.ComboBox ccb_LoaiMon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
    }
}