using QuanLyQuanAn.DAO;
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

namespace QuanLyQuanAn
{
    public partial class frmDoiServer : Form
    {
        string connectionstr = null;
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
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {
            string tenServer = txtTenServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (chkQuyenWindows.Checked)
            {
                if (tenServer.Length != 0 && database.Length != 0)
                {
                    connectionstr = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", tenServer, database);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (tenServer.Length != 0 && userName.Length != 0 && password.Trim().Length != 0 && database.Length != 0)
                {
                    connectionstr = String.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}",tenServer,database,userName,password);
                }
                else
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (DataProvider.IsServerConnected(connectionstr))
            {
                MessageBox.Show("Kết nối thành công", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLuu.Enabled = true;
            }
            else
            {
                MessageBox.Show("Kết nối không thành công", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLuu.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string key = "PYcFGNKuMEQzxpyC";
            
            string address = @"..//..//DAL\\connectionString.ini";
            DocGhiFile.GhiFile(address, new string[] { MaHoa.RSAEncrypt(connectionstr, key)});
            if(MessageBox.Show("Thay đổi server thành công, khởi động lại chương trình để áp dụng", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}
