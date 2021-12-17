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
using QuanLyQuanAn.DTO;
using QuanLyQuanAn.Lib;

namespace QuanLyQuanAn.GUI
{
    public partial class frmKhachHang : Form
    {
        BindingSource dsKhachHang = new BindingSource();

        public frmKhachHang()
        {
            InitializeComponent();
            this.CenterToScreen();
            Makeup.DataGridView(dgvKhachHang);
            dgvKhachHang.DataSource = dsKhachHang;
            hienthiDanhSachKhachHang();
            taorangbuoc();

            dgvKhachHang.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        void hienthiDanhSachKhachHang()
        {
            dsKhachHang.DataSource = KhachHangDAO.Instance.LayDsKhachHang();
            dgvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            dgvKhachHang.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvKhachHang.Columns[2].HeaderText = "Ngày Sinh";
            dgvKhachHang.Columns[3].HeaderText = "Giới Tính";
            dgvKhachHang.Columns[4].HeaderText = "Địa Chỉ";
            dgvKhachHang.Columns[5].HeaderText = "Số Điện Thoại";
            dgvKhachHang.Columns[6].HeaderText = "Trạng Thái";

            dgvKhachHang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgvKhachHang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhachHang.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            dgvKhachHang.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhachHang.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhachHang.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhachHang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        void taorangbuoc()
        {
            txtMaKhach.DataBindings.Add("text", dgvKhachHang.DataSource, "MaKH", true, DataSourceUpdateMode.Never);
            txtTenKhach.DataBindings.Add("text", dgvKhachHang.DataSource, "tenKH", true, DataSourceUpdateMode.Never);
            lblNgaySinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "ngaySinh", true,
                DataSourceUpdateMode.OnPropertyChanged, null, "dd/MM/yyyy");
            lblGioiTinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "gioiTinh", true, DataSourceUpdateMode.Never);
            txt_DiaChi.DataBindings.Add("Text", dgvKhachHang.DataSource, "diaChi", true, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Add("Text", dgvKhachHang.DataSource, "sdt", true, DataSourceUpdateMode.Never);
            rdb_HienThi.DataBindings.Add("Checked", dgvKhachHang.DataSource, "trangThai", true,
                DataSourceUpdateMode.Never);
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control) sender;
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
            txtMaKhach.Text = null;
            txtTenKhach.Text = null;
            mtxt_NgaySinh.Text = null;
            rdb_Nam.Checked = true;
            txt_DiaChi.Text = null;
            txtDienThoai.Text = null;
            rdb_HienThi.Checked = true;
            txtDienThoai.ReadOnly = false;
            txtTenKhach.Focus();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string value = txt_Search.Text;
                List<KhachHang> ds = KhachHangDAO.Instance.TimKhachHang(value);
                dgvKhachHang.DataSource = ds;
                hienthiDanhSachKhachHang();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi định dạng nhập! Vui lòng kiểm tra lại", "Tìm số điện thoại khách hàng",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.ResetText();
            dgvKhachHang.DataSource = dsKhachHang;
            hienthiDanhSachKhachHang();
        }

        public void ThemKhachHang()
        {
            try
            {
                string tenKH = txtTenKhach.Text;

                DateTime ngaySinh = Date.StringToDate(mtxt_NgaySinh.Text);
                string gioiTinh = rdb_Nam.Checked ? rdb_Nam.Text : rdb_Nu.Text;
                string diaChi = txt_DiaChi.Text;
                string sdt = txtDienThoai.Text;
                bool trangThai = rdb_HienThi.Checked;


                string kq = KhachHangDAO.Instance.KTKhachHangtheoSDT(sdt).ToLower();
                if (kq == sdt.ToLower())
                {
                    MessageBox.Show("Lỗi!! Trùng mã khách hàng!!", "Thêm Khách Hàng", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                else
                {
                    if (KhachHangDAO.Instance.themKH(tenKH, ngaySinh, gioiTinh, diaChi, sdt, trangThai))
                    {
                        MessageBox.Show("Thêm thành công!", "Thêm Khách Hàng", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        hienthiDanhSachKhachHang();
                    }
                    else
                        MessageBox.Show("Thêm không thành công!", "Thêm Khách Hàng", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            ThemKhachHang();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                string tenKH = txtTenKhach.Text;
                DateTime ngaySinh = Date.StringToDate(mtxt_NgaySinh.Text);
                string gioiTinh = rdb_Nam.Checked ? rdb_Nam.Text : rdb_Nu.Text;
                string diaChi = txt_DiaChi.Text;
                string sdt = txtDienThoai.Text.Trim();
                bool trangThai = rdb_HienThi.Checked;


                string kq = KhachHangDAO.Instance.KTKhachHangtheoSDT(sdt).ToLower().Trim();
                if (kq != sdt.ToLower())
                {
                    MessageBox.Show("Số điện thoại chưa được đăng ký", "Sửa Khách Hàng", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    if (KhachHangDAO.Instance.suaKHBangSDT(tenKH, ngaySinh, gioiTinh, diaChi, sdt, trangThai))
                    {
                        MessageBox.Show("Sửa thành công!", "Sửa Khách Hàng", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        hienthiDanhSachKhachHang();
                    }
                    else
                        MessageBox.Show("Sửa không thành công!", "Sửa Khách Hàng", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdb_Nam_CheckedChanged(object sender, EventArgs e)
        {
            rdb_Nu.Checked = !rdb_Nam.Checked;
        }

        private void rdb_HienThi_CheckedChanged(object sender, EventArgs e)
        {
            rdb_KhongHienThi.Checked = !rdb_HienThi.Checked;
        }

        private void lblGioiTinh_TextChanged(object sender, EventArgs e)
        {
            if (lblGioiTinh.Text.Trim().Equals(rdb_Nam.Text))
                rdb_Nam.Checked = true;
            else
                rdb_Nu.Checked = true;
        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            txtDienThoai.ReadOnly = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.SelectAll();
            txt_Search.Focus();
        }

        private void lblNgaySinh_TextChanged(object sender, EventArgs e)
        {
            mtxt_NgaySinh.Text = lblNgaySinh.Text;
        }

        private void btn_XuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < dgvKhachHang.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = dgvKhachHang.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhachHang.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = dgvKhachHang.Rows[i].Cells[j].Value.ToString();
                    }
                }

                xcelApp.Columns.AutoFit();
                xcelApp.Rows[1].Font.Bold = true;
                xcelApp.Visible = true;
            }
        }
    }
}