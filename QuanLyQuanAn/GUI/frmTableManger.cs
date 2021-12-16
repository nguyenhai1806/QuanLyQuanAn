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

namespace QuanLyQuanAn.GUI
{
    public partial class frmTableManger : Form
    {
        BindingSource dsBan = new BindingSource();

        public frmTableManger()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            thôngTinCáNhânToolStripMenuItem.Text = BienToanCuc.NguoiDangNhap.TenDangNhap;
            hienthiDanhSachBan();
            LoadLoaiMonTM();
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

        void hienthiDanhSachBan()
        {
            List<Ban> tableList = BanDAO.Instance.LayDSBan();

            foreach (Ban item in tableList)
            {
                Button btn = new Button() {Width = BanDAO.TableWidth, Height = BanDAO.TableHeight};
                btn.Text = item.TenBan + Environment.NewLine + item.TrangThai;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.TrangThai)
                {
                    case false:
                        btn.BackColor = Color.FromArgb(223, 215, 192);
                        break;

                    default:
                        btn.BackColor = Color.FromArgb(252, 243, 210);
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Ban).MaBan;
            if (tableID != -1)
            {
                lblMaBan.Text = tableID.ToString();
            }
            else
            {
                lblMaBan.Text = null;
            }
            hienThiMenuLenListView(tableID);
        }

        void hienThiMenuLenListView(int id)
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
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                tongTien += item.ThanhTien;

                lsvMenu.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            lblTongTien.Text = tongTien.ToString("c", culture);
        }

        #endregion

        #region Thêm món, chuyển bàn, thanh toán
        private void btn_ThemMon_Click(object sender, EventArgs e)
        {
            int maBan = -1;
            int maMon = -1;
            int soLuong;
            if (cbb_MonAn.SelectedItem != null)
            {
                maMon = (cbb_MonAn.SelectedItem as MonAn).MaMon;
            }

            int.TryParse(lblMaBan.Text, out maBan);
            if (maBan != -1)
            {
                if (MenuDAO.Instance.ThemMon())
                {
                    
                }
                else
                {
                    
                }
                
            }
        }
        #endregion


    }
}