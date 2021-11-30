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
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmTableManger f = new frmTableManger();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnDoiServer_Click(object sender, EventArgs e)
        {
            frmDoiServer f = new frmDoiServer();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát chương trình ?", "Thông báo",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }
    }
}
