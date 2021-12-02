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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                this.errorProvider1.SetError(ctr, "Ô này chỉ được phép nhập số !");
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                this.errorProvider1.Clear();
            }
        }

        private void btn_Reset_KH_Click(object sender, EventArgs e)
        {
            txtTenKhach.Text = null;
            mtxt_NgaySinh.Text = null;
            rdb_Nam.Checked = true;
            txt_DiaChi.Text = null;
            txtDienThoai.Text = null;
            rdb_HienThi.Checked = true;
            txtTenKhach.Focus();
        }
    }
}
