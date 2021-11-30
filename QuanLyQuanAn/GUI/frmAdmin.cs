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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btn_NNV_Reset_Click(object sender, EventArgs e)
        {
            txt_NNV_Ten.Text = null;
            rdb_NNV_HienThi.Checked = true;
            txt_NNV_Ten.Focus();
        }
    }
}
