using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
using QuanLyQuanAn.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.GUI
{
    public partial class frmThongTinCaNhan : Form
    {
        public frmThongTinCaNhan()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load();
        }
        private void Load()
        {
            NhanVien nhanVien = BienToanCuc.NguoiDangNhap;
            txt_MaNV.Text = nhanVien.MaNV.ToString();
            txt_TenNV.Text = nhanVien.HoTen;
            txtTenDangNhap.Text = nhanVien.TenDangNhap;
            txt_NgaySinh.Text = Date.DateToString(nhanVien.NgaySinh);
            txt_DiaChi.Text = nhanVien.DiaChi;
            txt_SDT.Text = nhanVien.Sdt;
            txt_NhomNV.Text = nhanVien.MaNhomNV.ToString();
            rdb_Nam.Checked = nhanVien.GioiTinh == "Nam" ? true : false;
            rdb_Nu.Checked = !rdb_Nam.Checked;
        }
        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_NgaySinh_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            int ngay, thang, nam;
            string[] temp = txt_NgaySinh.Text.Split('/');

            int.TryParse(temp[0],out ngay);
            int.TryParse(temp[1], out thang);
            int.TryParse(temp[2], out nam);

            if (!Date.laNgayHopLe(ngay, thang, nam))
            {
                this.errorProvider1.SetError(ctr, "Ngày tháng không hợp lệ");
            }
            else
                this.errorProvider1.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int ngay, thang, nam;
                string[] temp = txt_NgaySinh.Text.Split('/');

                int.TryParse(temp[0], out ngay);
                int.TryParse(temp[1], out thang);
                int.TryParse(temp[2], out nam);

                if (Date.laNgayHopLe(ngay, thang, nam) || txt_NgaySinh.Text == null)
                {
                    int maNV = int.Parse(txt_MaNV.Text);
                    string gioiTinh = rdb_Nam.Checked ? rdb_Nam.Text : rdb_Nu.Text;
                    DateTime ngaySinh = Date.StringToDate(txt_NgaySinh.Text);
                    string diaChi = txt_DiaChi.Text.Trim();
                    string sdt = txt_SDT.Text.Trim();
                    if (NhanVienDAO.Instance.UpdateInfo(maNV, gioiTinh, ngaySinh, diaChi, sdt))
                    {
                        MessageBox.Show("Thay đổi thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Thay đổi thông tin không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
