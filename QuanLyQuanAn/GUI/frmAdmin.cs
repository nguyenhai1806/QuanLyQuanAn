using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
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

namespace QuanLyQuanAn.GUI
{
    public partial class frmAdmin : Form
    {
        BindingSource DSLoaiMon = new BindingSource();
        BindingSource DSMonAn = new BindingSource();
        BindingSource DSNhomNV = new BindingSource();
        BindingSource DSNhanVien = new BindingSource();

        public frmAdmin()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load();
            Makeup.DataGridView(dgv_LoaiMon);
            Makeup.DataGridView(dgv_MonAn);
            Makeup.DataGridView(dgv_NhanVien);
            Makeup.DataGridView(dgv_MonAn);
            Makeup.DataGridView(dgv_NhomNV);
            Makeup.DataGridView(dgv_ThongKe);
        }
        
        void Load()
        {
            dgv_MonAn.DataSource = DSMonAn;
            dgv_NhanVien.DataSource = DSNhanVien;
            dgv_LoaiMon.DataSource = DSLoaiMon;
            dgv_NhomNV.DataSource = DSNhomNV;
            
            LoadLoaiMon();
            LoadMonAn();
            LoadNhomNhanVien();
            LoadNhanVien();

            NhomNVBinding();
            NhanVienBinding();
            AddLoaiMonBinding();
            AddMonAnBinding();
            LoadLoaiMonLenCombobox(cbb_MonAn_LoaiMon);

            dgv_NhanVien.Columns["NgaySinh"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv_NhanVien.Columns["MatKhau"].Visible = false;
        }

        #region Nhóm NV
        private void btn_NNV_Reset_Click(object sender, EventArgs e)
        {
            txt_NNV_Ma.Text = null;
            txt_NNV_Ten.Text = null;
            rdb_NNV_HienThi.Checked = true;
            txt_NNV_Ten.Focus();
        }
        void LoadNhomNhanVien()
        {
            DSNhomNV.DataSource = NhomNVDAO.Instance.LayDSNhomNV();
        }
        private void NhomNVBinding()
        {
            txt_NNV_Ma.DataBindings.Add(new Binding("Text", dgv_NhomNV.DataSource, "MaNhom", true, DataSourceUpdateMode.Never));
            txt_NNV_Ten.DataBindings.Add(new Binding("Text", dgv_NhomNV.DataSource, "TenNhom", true, DataSourceUpdateMode.Never));
            rdb_NNV_HienThi.DataBindings.Add(new Binding("Checked", dgv_NhomNV.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }
        private void rdb_NNV_HienThi_CheckedChanged(object sender, EventArgs e)
        {
            rdb_NNV_KhongHienThi.Checked = !rdb_NNV_HienThi.Checked;
        }

        private void btn_NNV_Them_Click(object sender, EventArgs e)
        {
            string tenNhom = txt_NNV_Ten.Text.Trim();
            bool trangThai = rdb_NNV_HienThi.Checked;
            if (tenNhom.Length != 0)
            {
                if (NhomNVDAO.Instance.LayNNVTheoTenNhom(tenNhom) != null)
                {
                    if (NhomNVDAO.Instance.ThemNhomNV(tenNhom,trangThai))
                    {
                        MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhomNhanVien();
                    }
                    else
                        MessageBox.Show("Thêm không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Tên nhóm đã tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Vui lòng điền đày đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_NNV_Sua_Click(object sender, EventArgs e)
        {
            int maNhom = int.Parse(txt_NNV_Ma.Text);
            string tenNhom = txt_NNV_Ten.Text.Trim();
            bool trangThai = rdb_NNV_HienThi.Checked;
            if (tenNhom.Length != 0)
            {
                NhomNhanVien nhomNhanVien = NhomNVDAO.Instance.LayNNVTheoTenNhom(tenNhom);
                if (nhomNhanVien == null|| nhomNhanVien.MaNhom == maNhom)
                {
                    if (NhomNVDAO.Instance.SuaNhomNV(maNhom,tenNhom, trangThai))
                    {
                        MessageBox.Show("Sửa thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNhomNhanVien();
                    }
                    else
                        MessageBox.Show("Sửa không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Tên nhóm đã tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Nhân Viên
        private void btn_NV_Reset_Click(object sender, EventArgs e)
        {
            txt_NV_Ma.Text = null;
            txt_NV_Ten.Text = null;
            rdb_NV_Nam.Checked = true;
            mtxt_NV_NgaySinh.Text = null;
            txt_NV_DiaChi.Text = null;
            txt_NV_SDT.Text = null;
            rdb_NV_HienThi.Checked = true;
            txt_NV_Username.Text = null;
            txt_NV_Username.Focus();
            txt_NV_Username.ReadOnly = false;
        }
        private void LoadNhanVien()
        {
            DSNhanVien.DataSource = NhanVienDAO.Instance.LayDSNhanVien();
        }
        private void NhanVienBinding()
        {
            txt_NV_Ma.DataBindings.Add(new Binding("Text", dgv_NhanVien.DataSource, "MaNV", true, DataSourceUpdateMode.Never));
            txt_NV_Username.DataBindings.Add(new Binding("Text", dgv_NhanVien.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txt_NV_Ten.DataBindings.Add(new Binding("Text", dgv_NhanVien.DataSource, "HoTen", true, DataSourceUpdateMode.Never));
            lblGioiTinh.DataBindings.Add(new Binding("Text", dgv_NhanVien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));
            txt_NV_DiaChi.DataBindings.Add(new Binding("Text", dgv_NhanVien.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
            txt_NV_SDT.DataBindings.Add(new Binding("Text", dgv_NhanVien.DataSource, "Sdt", true, DataSourceUpdateMode.Never));
            mtxt_NV_NgaySinh.DataBindings.Add("Text", dgv_NhanVien.DataSource, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged, null, "dd/MM/yyyy");

        }
        private void lblGioiTinh_TextChanged(object sender, EventArgs e)
        {
            if (lblGioiTinh.Text.Trim().Equals(rdb_NV_Nam.Text))
                rdb_NV_Nam.Checked = true;
            else
                rdb_NV_Nu.Checked = true;
        }

        private void rdb_NV_HienThi_CheckedChanged(object sender, EventArgs e)
        {
            rdb_NV_KhongHienThi.Checked = !rdb_NV_HienThi.Checked;
        }
        private void dgv_NhanVien_Click(object sender, EventArgs e)
        {
            txt_NV_Username.ReadOnly = true;
        }
        private void btn_NV_Them_Click(object sender, EventArgs e)
        {
            string userName = txt_NV_Username.Text.Trim();
            string tenNV = txt_NV_Ten.Text.Trim();
            string gioiTinh = rdb_NV_Nam.Checked ? rdb_NV_Nam.Text : rdb_NV_Nu.Text;
            string diaChi = txt_NV_DiaChi.Text;
            string soDienThoai = txt_NV_SDT.Text;
            bool trangThai = rdb_NV_HienThi.Checked;

            DateTime ngaySinh;
            if (Date.laNgayHopLe(mtxt_NV_NgaySinh.Text))
            {
                ngaySinh = Date.StringToDate(mtxt_NV_NgaySinh.Text);
            }
            else
                MessageBox.Show("Định dạng ngày tháng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_NV_Sua_Click(object sender, EventArgs e)
        {

        }

        private void btn_NV_CapLaiMK_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txt_NV_Username.Text;
                if (userName.Length != 0)
                {
                    string pass = MaHoa.MD5Encrypt("1");
                    if (NhanVienDAO.Instance.UpdatePassword(userName, pass))
                    {
                        MessageBox.Show("Đã reset về mật khẩu mặc định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Reset không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Bạn chưa chọn nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mtxt_NV_NgaySinh_Leave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;

            if (!Date.laNgayHopLe(mtxt_NV_NgaySinh.Text))
            {
                this.errorProvider1.SetError(ctr, "Ngày tháng không hợp lệ");
            }
            else
                this.errorProvider1.Clear();
        }

        #endregion

        #region Loại món
        private void btn_LoaiMon_Reset_Click(object sender, EventArgs e)
        {
            txt_LoaiMon_MaLoai.Text = null;
            txt_LoaiMon_Ten.Text = null;
            rdb_LoaiMon_HienThi.Checked = true;
            txt_LoaiMon_Ten.Focus();
        }
        void LoadLoaiMon()
        {
            DSLoaiMon.DataSource = LoaiMonDAO.Instance.LayDSLoaiMon();
        }
        private void rdb_LoaiMon_HienThi_CheckedChanged(object sender, EventArgs e)
        {
            rdb_LoaiMon_KhongHienThi.Checked = !rdb_LoaiMon_HienThi.Checked;
        }
        #endregion

        #region Mon An
        private void rdb_MonAn_Reset_Click(object sender, EventArgs e)
        {
            txt_MonAn_Ma.Text = null;
            txt_MonAn_Ten.Text = null;
            txt_MonAn_GiaBan.Text = null;
            cbb_MonAn_LoaiMon.Text = null;
            txt_MonAn_Ten.Focus();
        }
        void LoadMonAn()
        {
            DSMonAn.DataSource = MonAnDAO.Instance.LayDSMonAn();
        }
        private void btn_LoaiMon_Them_Click(object sender, EventArgs e)
        {
            string tenLoai = txt_LoaiMon_Ten.Text;
            bool trangThai = rdb_LoaiMon_HienThi.Checked;

            if (LoaiMonDAO.Instance.ThemLoaiMon(tenLoai, trangThai))
            {
                MessageBox.Show("Thêm loại món thành công!");
                LoadLoaiMon();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm loại món mới!");
            }
        }

        private void btn_LoaiMon_Sua_Click(object sender, EventArgs e)
        {
            int maLoai = Convert.ToInt32(txt_LoaiMon_MaLoai.Text);
            string tenLoai = txt_LoaiMon_Ten.Text;
            bool trangThai = rdb_LoaiMon_HienThi.Checked;

            if (LoaiMonDAO.Instance.SuaLoaiMon(maLoai, tenLoai, trangThai))
            {
                MessageBox.Show("Sửa loại món thành công!");
                LoadLoaiMon();

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa loại món mới!");
            }
        }
        void AddLoaiMonBinding()
        {
            txt_LoaiMon_MaLoai.DataBindings.Add(new Binding("Text", dgv_LoaiMon.DataSource, "MaLoai", true, DataSourceUpdateMode.Never));
            txt_LoaiMon_Ten.DataBindings.Add(new Binding("Text", dgv_LoaiMon.DataSource, "TenLoai", true, DataSourceUpdateMode.Never));
            rdb_LoaiMon_HienThi.DataBindings.Add(new Binding("Checked", dgv_LoaiMon.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }
        void LoadLoaiMonLenCombobox(ComboBox cbb)
        {
            cbb.DataSource = LoaiMonDAO.Instance.LayDSLoaiMon();
            cbb.DisplayMember = "TenLoai";
        }
        void AddMonAnBinding()
        {
            txt_MonAn_Ten.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "TenMon", true, DataSourceUpdateMode.Never));
            txt_MonAn_GiaBan.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "GiaBan", true, DataSourceUpdateMode.Never));
            txt_MonAn_Ma.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "MaMon", true, DataSourceUpdateMode.Never));
            rdb_MonAn_HienThi.DataBindings.Add(new Binding("Checked", dgv_MonAn.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }
        private void txt_MonAn_Ma_TextChanged(object sender, EventArgs e)
        {
            if (dgv_MonAn.SelectedCells.Count > 0)
            {
                int id = (int)dgv_MonAn.SelectedCells[0].OwningRow.Cells["MaLoai"].Value;

                LoaiMon loai = LoaiMonDAO.Instance.LayLoaiMonTheoID(id);

                cbb_MonAn_LoaiMon.SelectedItem = loai;

                int index = -1;
                int i = 0;
                foreach (LoaiMon item in cbb_MonAn_LoaiMon.Items)
                {
                    if (item.MaLoai == loai.MaLoai)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbb_MonAn_LoaiMon.SelectedIndex = index;
            }
        }
        //Thêm, sửa
        private void btn_MonAn_Them_Click(object sender, EventArgs e)
        {
            string tenMon = txt_MonAn_Ten.Text;
            string giaBan = txt_MonAn_GiaBan.Text;
            int maLoai = (cbb_MonAn_LoaiMon.SelectedItem as LoaiMon).MaLoai;
            bool trangThai = rdb_MonAn_HienThi.Checked;

            if (MonAnDAO.Instance.ThemMonAn(tenMon, giaBan, maLoai, trangThai))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadMonAn();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm!");
            }
        }
        private void btn_MonAn_Sua_Click(object sender, EventArgs e)
        {
            int maMon = Convert.ToInt32(txt_MonAn_Ma.Text);
            string tenMon = txt_MonAn_Ten.Text;
            string giaBan = txt_MonAn_GiaBan.Text;
            int maLoai = (cbb_MonAn_LoaiMon.SelectedItem as LoaiMon).MaLoai;
            bool trangThai = rdb_MonAn_HienThi.Checked;

            if (MonAnDAO.Instance.SuaMonAn(maMon, tenMon, giaBan, maLoai, trangThai))
            {
                MessageBox.Show("Sửa món thành công!");
                DSMonAn.ResetBindings(false);
                LoadMonAn();

            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa!");
            }
        }
        private void rdb_MonAn_HienThi_CheckedChanged(object sender, EventArgs e)
        {
            rdb_MonAn_KhongHienThi.Checked = !rdb_MonAn_HienThi.Checked;
        }




        #endregion

    }
}
