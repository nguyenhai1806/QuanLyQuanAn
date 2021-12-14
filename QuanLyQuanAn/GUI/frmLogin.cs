using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string pass = txtPassword.Text.Trim();
                if (username.Length != 0 && pass.Length != 0)
                {
                    pass = Lib.MaHoa.MD5Encrypt(pass);

                    NhanVien nhanVien = NhanVienDAO.Instance.LayNhanVienDangNhap(username, pass);
                    if (nhanVien != null)
                    {
                        if (nhanVien.TrangThai != false)
                        {
                            BienToanCuc.NguoiDangNhap = nhanVien;
                            txtUsername.Text = null;
                            txtPassword.Text = null;
                            frmTableManger f = new frmTableManger();
                            this.Hide();
                            f.ShowDialog();
                            this.Show();
                        }
                        else
                            MessageBox.Show("Bạn không được phép đăng nhập", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Tên tài khoản và mật khẩu không được trông", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiServer_Click(object sender, EventArgs e)
        {
            frmDoiServer f = new frmDoiServer();
            this.Hide();
            f.ShowDialog();
            try
            {
                this.Show();
            }
            catch (Exception) { }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát chương trình ?", "Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void lbl_Hide_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                lbl_Invisible.BringToFront();
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void lbl_Invisible_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                lbl_Hide.BringToFront();
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
