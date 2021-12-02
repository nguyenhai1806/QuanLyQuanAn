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

        private void btn_NV_Reset_Click(object sender, EventArgs e)
        {
            txt_NV_Ten.Text = null;
            rdb_NV_Nam.Checked = true;
            mtxt_NV_NgaySinh.Text = null;
            txt_NV_DiaChi.Text = null;
            txt_NV_SDT.Text = null;
            rdb_NV_HienThi.Checked = true;
            txt_NV_Username.Text = null;
            txt_NV_Ten.Focus();
        }

        private void btn_LoaiMon_Reset_Click(object sender, EventArgs e)
        {
            txt_LoaiMon_Ten.Text = null;
            rdb_LoaiMon_HienThi.Checked = true;
            txt_LoaiMon_Ten.Focus();
        }

        private void rdb_MonAn_Reset_Click(object sender, EventArgs e)
        {
            txt_MonAn_Ten.Text = null;
            txt_MonAn_GiaBan.Text = null;
            cbb_MonAn_LoaiMon.Text = null;
            txt_MonAn_Ten.Focus();
        }
    }
}
