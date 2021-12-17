using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
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
using Menu = QuanLyQuanAn.DTO.Menu;

namespace QuanLyQuanAn.GUI
{
    public partial class frmTableManger : Form
    {
        CultureInfo culture = new CultureInfo("vi");
        BindingSource dsBan = new BindingSource();
        private Button btnSelected = null;
        public frmTableManger()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            thôngTinCáNhânToolStripMenuItem.Text = BienToanCuc.NguoiDangNhap.TenDangNhap;
            hienthiDanhSachBan();
            LoadLoaiMonTM();
            LoadBanLenCombobox();
        }

        #region Nối form

        private void thôngTinCáNhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void thôngTinCáNhânToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan f = new frmThongTinCaNhan();
            f.ShowDialog();
            this.Hide();
            this.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau f = new frmDoiMatKhau();
            f.ShowDialog();
            this.Hide();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangXuat();
        }

        private void DangXuat()
        {
            if (MessageBox.Show("Bạn thật sự muốn đăng xuất ?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                BienToanCuc.NguoiDangNhap = null;
                this.Dispose();
            }
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
            this.Hide();
            this.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout f = new frmAbout();
            f.ShowDialog();
            this.Hide();
            this.Show();
        }

        private void frmTableManger_FormClosing(object sender, FormClosingEventArgs e)
        {
            DangXuat();
        }

        private void mónĂnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLy f = new frmQuanLy();
            this.Hide();
            f.ShowDialog();
            LoadLoaiMonTM();
            cbb_LoaiMon.SelectedIndex = -1;
            this.Show();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoanhThu f = new frmDoanhThu();
            f.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup f = new frmBackup();
            f.ShowDialog();
        }

        #endregion

        #region Load loại món, Món ăn

        void LoadLoaiMonTM()
        {
            List<LoaiMon> loaiMons = LoaiMonDAO.Instance.LayDSLoaiMonTM();
            cbb_LoaiMon.DataSource = loaiMons;
            cbb_LoaiMon.DisplayMember = "TenLoai";
        }

        void LoaiMonAnTheoMaLoaiMon(int id)
        {
            List<MonAn> monAns = MonAnDAO.Instance.LayDSMonAnTheoMa(id);
            cbb_MonAn.DataSource = monAns;
            cbb_MonAn.DisplayMember = "TenMon";
        }

        private void ccb_LoaiMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            cbb_MonAn.SelectedIndex = -1;
            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
            {
                return;
            }

            LoaiMon selected = cb.SelectedItem as LoaiMon;
            id = selected.MaLoai;
            LoaiMonAnTheoMaLoaiMon(id);
        }

        #endregion

        #region Load bàn
        /// <summary>
        /// Nếu bàn rỗng sẽ return về false. bàn có người return true
        /// </summary>
        /// <param name="maBan"></param>
        bool checkBan(int maBan)
        {
            List<Menu> listMenu = MenuDAO.Instance.LayDSMenuTheoMaBan(maBan);
            if (listMenu.Count > 0)
                return true;
            return false;
        }
        void hienthiDanhSachBan()
        {
            List<Ban> tableList = BanDAO.Instance.LayDSBan();
            flpTable.Controls.Clear();
            foreach (Ban item in tableList)
            {
                Button btn = new Button() {Width = BanDAO.TableWidth, Height = BanDAO.TableHeight};
                btn.MouseUp += Btn_Click;
                btn.Tag = item;

                switch (checkBan(item.MaBan))
                {
                    case true:
                        btn.Text = item.TenBan + Environment.NewLine + "Có người";
                        btn.BackColor = Color.FromArgb(223, 215, 192);
                        break;

                    case false:
                        btn.Text = item.TenBan + Environment.NewLine + "Trống";
                        btn.BackColor = Color.FromArgb(252, 243, 210);
                        break;
                }
                flpTable.Controls.Add(btn);
            }
            LoadBanLenCombobox();
        }

        private void Btn_Click(object sender, MouseEventArgs e)
        {
            btnSelected = (sender as Button);
            Ban banSelected = btnSelected.Tag as Ban;
            if (banSelected == null)
                return;
            if (banSelected.MaBan != -1)
            {
                lblMaBan.Text = banSelected.MaBan.ToString();
            }
            else
            {
                lblMaBan.Text = null;
            }
            hienThiMenuLenListView(banSelected.MaBan);
        }


         int hienThiMenuLenListView(int id)
        {
            lsvMenu.Items.Clear();
            List<QuanLyQuanAn.DTO.Menu> listMenu = MenuDAO.Instance.LayDSMenuTheoMaBan(id);
            float tongTien = 0;
            foreach (QuanLyQuanAn.DTO.Menu item in listMenu)
            {
                ListViewItem lsvItem = new ListViewItem(item.MaMon.ToString());
                lsvItem.SubItems.Add(item.TenMon.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.GiaBan.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString("C0", culture));
                tongTien += item.ThanhTien;

                lsvMenu.Items.Add(lsvItem);
            }
            lblTongTien.Text = tongTien.ToString("C0", culture);
            return listMenu.Count;
        }

        #endregion

        #region Thêm món, chuyển bàn, thanh toán
        private void btn_ThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                int maMon = 0;
                int soLuong = int.Parse(cbb_SoLuong.Text);
                if (cbb_MonAn.SelectedItem != null)
                {
                    maMon = (cbb_MonAn.SelectedItem as MonAn).MaMon;
                }

                if (btnSelected != null && maMon != 0)
                {
                    Ban banSelected = btnSelected.Tag as Ban;
                    if (MenuDAO.Instance.ThemMon(banSelected.MaBan, maMon, soLuong))
                    {
                        if (hienThiMenuLenListView(banSelected.MaBan) == 0)
                        {
                            banSelected = btnSelected.Tag as Ban;
                            banSelected.TrangThai = true;
                            btnSelected.Text = banSelected.TenBan + Environment.NewLine + "Rỗng";
                            btnSelected.BackColor =  Color.FromArgb(252, 243, 210);
                        }
                        else
                        {
                            banSelected = btnSelected.Tag as Ban;
                            banSelected.TrangThai = false;
                            btnSelected.Text = banSelected.TenBan + Environment.NewLine + "Có người";
                            btnSelected.BackColor = Color.FromArgb(223, 215, 192);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn bàn", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LoadBanLenCombobox()
        {
            List<Ban> tableList = BanDAO.Instance.LayDSBan();
            List<Ban> banRong = new List<Ban>();
            foreach (Ban item in tableList)
            {
                if (checkBan(item.MaBan) == false)
                {
                    banRong.Add(item);
                }
            }
            cbb_Ban.DataSource = banRong;
            cbb_Ban.DisplayMember = "TenBan";
        }
        #endregion

        private void lsvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (lsvMenu.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = lsvMenu.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    int maMon = 0;
                    maMon = int.Parse(lsvMenu.Items[intselectedindex].Text);
                    ListViewItem.ListViewSubItemCollection subItemCollection = lsvMenu.SelectedItems[0].SubItems;
                    int soLuong = int.Parse(subItemCollection[2].Text);
                    

                    foreach (LoaiMon loaiMon in cbb_LoaiMon.Items)
                    {
                        LoaiMonAnTheoMaLoaiMon(loaiMon.MaLoai);
                        foreach (MonAn monAn in cbb_MonAn.Items)
                        {
                            if (monAn.MaMon == maMon)
                            {
                                cbb_LoaiMon.SelectedItem = loaiMon;
                                cbb_MonAn.SelectedItem = monAn;
                                cbb_SoLuong.Value = soLuong;
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ChuyenBan_Click(object sender, EventArgs e)
        {
            try
            {
                Ban banSelected = btnSelected.Tag as Ban;
                int maBanCu = banSelected.MaBan;
                int maBanMoi = (cbb_Ban.SelectedItem as Ban).MaBan;

                if (MenuDAO.Instance.ChuyenBan(maBanCu, maBanMoi))
                {
                    MessageBox.Show("Chuyển từ bàn " + banSelected.TenBan + " sang bàn " + (cbb_Ban.SelectedItem as Ban).TenBan + " thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthiDanhSachBan();
                }
                else
                    MessageBox.Show("Chuyển từ bàn " + banSelected.TenBan + " sang bàn " + (cbb_Ban.SelectedItem as Ban).TenBan + " không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbb_ThanhToan_Click(object sender, EventArgs e)
        {
            if (btnSelected != null)
            {
                Ban banSelected = btnSelected.Tag as Ban;
                if (checkBan(banSelected.MaBan) == true)
                {
                    
                    //Khách vô danh
                    if (txtTenKhach.Text.Length == 0)
                    {
                        if (MenuDAO.Instance.ThanhToan(banSelected.MaBan,1, BienToanCuc.NguoiDangNhap.MaNV))
                        {
                            hienthiDanhSachBan();
                            lsvMenu.Items.Clear();
                            MessageBox.Show("Thanh toán thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        string soDienThoai = txtSoDienThoai.Text;
                        KhachHang khachHang = KhachHangDAO.Instance.TimKhachHangBangSDT(soDienThoai);
                        if (khachHang != null)
                        {
                            if (khachHang.TrangThai != false)
                            {
                                if (MenuDAO.Instance.ThanhToan(banSelected.MaBan, int.Parse(khachHang.MaKH), BienToanCuc.NguoiDangNhap.MaNV))
                                {
                                    hienthiDanhSachBan();
                                    lsvMenu.Items.Clear();
                                    txtTenKhach.Text = null;
                                    txtSoDienThoai.Text = null;
                                    lblTongTien.Text = 0.ToString("C0", culture);
                                    btnSelected = null;
                                    MessageBox.Show("Thanh toán thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Thanh toán không thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                                MessageBox.Show("Khách hàng này không được phép", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Số điện thoại chưa đăng ký", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Bàn đang trống", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Bạn chưa chọn bàn", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtSoDienThoai_Leave(object sender, EventArgs e)
        {
            txtTenKhach.Text = null;
            string soDienThoai = txtSoDienThoai.Text;
            KhachHang khachHang = KhachHangDAO.Instance.TimKhachHangBangSDT(soDienThoai);
            if (khachHang != null)
            {
                if (khachHang.TrangThai != false)
                {
                    txtTenKhach.Text = khachHang.TenKH;
                }
                else
                    MessageBox.Show("Khách hàng này không được phép", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Số điện thoại chưa đăng ký", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoDienThoai.Text = null;
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbb_MonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_SoLuong.Value = 0;
        }
    }
}