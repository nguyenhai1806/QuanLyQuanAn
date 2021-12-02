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
            this.CenterToScreen();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

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
            Control ctr = (Control)sender;
            e.Handled = (e.KeyChar == (char)Keys.Space);
            this.errorProvider1.SetError(ctr, "Mật khẩu không được phép nhập khoảng trắng !");
        }

        private void txt_NewPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            e.Handled = (e.KeyChar == (char)Keys.Space);
            this.errorProvider1.SetError(ctr, "Mật khẩu không được phép nhập khoảng trắng !");
        }

        private void txt_RepeatPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            e.Handled = (e.KeyChar == (char)Keys.Space);
            this.errorProvider1.SetError(ctr, "Mật khẩu không được phép nhập khoảng trắng !");
        }
    }
}
