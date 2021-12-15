using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
using QuanLyQuanAn.Lib;
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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
            this.CenterToParent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtUsername.Text = BienToanCuc.NguoiDangNhap.TenDangNhap;
        }

        private void lbl_Hide_Click(object sender, EventArgs e)
        {
            if (txt_Pass.UseSystemPasswordChar == true)
            {
                lbl_Invisible.BringToFront();
                txt_Pass.UseSystemPasswordChar = false;
                txt_NewPass.UseSystemPasswordChar = false;
                txt_RepeatPass.UseSystemPasswordChar = false;
            }
        }

        private void lbl_Invisible_Click(object sender, EventArgs e)
        {
            if (txt_Pass.UseSystemPasswordChar == false)
            {
                lbl_Hide.BringToFront();
                txt_Pass.UseSystemPasswordChar = true;
                txt_NewPass.UseSystemPasswordChar = true;
                txt_RepeatPass.UseSystemPasswordChar = true;
            }
        }

        private void txt_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control) sender;
            e.Handled = (e.KeyChar == (char) Keys.Space);
        }

        private void txt_NewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control) sender;
            e.Handled = (e.KeyChar == (char) Keys.Space);
        }

        private void txt_RepeatPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control) sender;
            e.Handled = (e.KeyChar == (char) Keys.Space);
        }

        private void txt_RepeatPass_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control) sender;
            if (!txt_NewPass.Text.Equals(txt_RepeatPass.Text))
                errorProvider1.SetError(ctr, "Mật khẩu mới không khớp");
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUsername.Text.Trim();
                string newPass = txt_NewPass.Text.Trim();
                string pass = txt_Pass.Text.Trim();
                string repeatPass = txt_RepeatPass.Text.Trim();
                if (userName.Length != 0 && newPass.Length != 0 && pass.Length != 0)
                {
                    pass = MaHoa.MD5Encrypt(pass);
                    Control ctr = (Control) sender;
                    NhanVien nhanVien = NhanVienDAO.Instance.LayNhanVienDangNhap(userName, pass);
                    if (nhanVien != null)
                    {
                        if (repeatPass.Equals(newPass))
                        {
                            newPass = MaHoa.MD5Encrypt(newPass);
                            if (NhanVienDAO.Instance.UpdatePassword(userName, newPass))
                            {
                                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Đổi mật khẩu không thành công", "Thông báo", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Hai mật khẩu mới không khớp", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}