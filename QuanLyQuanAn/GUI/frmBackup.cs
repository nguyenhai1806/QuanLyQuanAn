using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanAn.DAL;

namespace QuanLyQuanAn.GUI
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
            CenterToParent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btn_GetFull_Click(object sender, EventArgs e)
        {
            try
            {
                ofdg.Filter = "Backup files (*.bak)|*.bak";
                ofdg.Title = "Lấy file Full backup";
                ofdg.FileName = "";
                if (ofdg.ShowDialog() == DialogResult.OK)
                {
                    //Hiển thị file lên txt_FileFull
                    txt_FileFull.Text = ofdg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy file không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_BackupFul_Click(object sender, EventArgs e)
        {
            try
            {
                fbd.Description = "Chọn Thư mực chứa file";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string address = fbd.SelectedPath;
                    if (BackupDAO.Instance.FullBackup(address))
                        MessageBox.Show("Backup Full thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("Backup Full không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_BackupDiff_Click(object sender, EventArgs e)
        {
            try
            {
                fbd.Description = "Chọn Thư mực chứa file";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string address = fbd.SelectedPath;
                    if (BackupDAO.Instance.DiffBackup(address))
                        MessageBox.Show("Backup Diff thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("Backup Diff không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_BackupLog_Click(object sender, EventArgs e)
        {
            try
            {
                fbd.Description = "Chọn Thư mực chứa file";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string address = fbd.SelectedPath;
                    if (BackupDAO.Instance.LogBackup(address))
                        MessageBox.Show("Backup Log thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("Backup Log không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GetDiff_Click(object sender, EventArgs e)
        {
            try
            {
                ofdg.Filter = "Backup files (*.bak)|*.bak";
                ofdg.Title = "Lấy file Diff backup";
                ofdg.FileName = "";
                if (ofdg.ShowDialog() == DialogResult.OK)
                {
                    //Hiển thị file lên txt_GetDiff
                    txt_GetDiff.Text = ofdg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy file không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GetLog_Click(object sender, EventArgs e)
        {
            try
            {
                ofdg.Filter = "Log backup files (*.trn)|*.trn";
                ofdg.Title = "Lấy file log backup";
                ofdg.FileName = "";
                if (ofdg.ShowDialog() == DialogResult.OK)
                {
                    //Hiển thị file lên txt_GetDiff
                    txt_GetLog.Text = ofdg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lấy file không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Restorse_Click(object sender, EventArgs e)
        {

            if (txt_FileFull.Text.Trim().Length != 0)
            {
                try
                {
                    BackupDAO.Instance.Recovery("QLTiecQuanAn", txt_FileFull.Text, txt_GetDiff.Text, txt_GetLog.Text);
                    if (MessageBox.Show("Khôi phục thành công, bạn khởi động lại chương trình để áp dụng", "", MessageBoxButtons.OK, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                    {
                        System.Windows.Forms.Application.ExitThread();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Khôi phục không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Chưa có file Full Backup", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}