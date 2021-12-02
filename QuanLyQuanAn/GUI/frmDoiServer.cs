using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn
{
    public partial class frmDoiServer : Form
    {
        public frmDoiServer()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void frmDoiServer_Load(object sender, EventArgs e)
        {

        }

        private void chkQuyenWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuyenWindows.Checked)
            {
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
            }
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
            this.errorProvider1.SetError(ctr, "Mật khẩu không được phép nhập khoảng trắng !");
        }
    }
}
