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
    }
}
