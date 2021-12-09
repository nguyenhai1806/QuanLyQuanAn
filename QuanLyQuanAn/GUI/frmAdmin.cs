using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
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
        BindingSource DSMonAn = new BindingSource();
        public frmAdmin()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load();
            
        }

        void Load()
        {
            dgv_MonAn.DataSource = DSMonAn;
            LoadLoaiMon();
            LoadMonAn();
            AddLoaiMonBinding();
            AddMonAnBinding();
            LoadLoaiMonLenCombobox(cbb_MonAn_LoaiMon);
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

        void LoadLoaiMon()
        {
            dgv_LoaiMon.DataSource = LoaiMonDAO.Instance.LayDSLoaiMon();
        }

        void LoadMonAn()
        {
            DSMonAn.DataSource = MonAnDAO.Instance.LayDSMonAn();
        }

        void LoadLoaiMonLenCombobox(ComboBox cbb)
        {
            cbb.DataSource = LoaiMonDAO.Instance.LayDSLoaiMon();
            cbb.DisplayMember = "TenLoai";
        }

        void AddLoaiMonBinding()
        {
            txt_LoaiMon_MaLoai.DataBindings.Add(new Binding("Text", dgv_LoaiMon.DataSource, "MaLoai", true,DataSourceUpdateMode.Never));
            txt_LoaiMon_Ten.DataBindings.Add(new Binding("Text", dgv_LoaiMon.DataSource, "TenLoai", true, DataSourceUpdateMode.Never));
            rdb_LoaiMon_HienThi.DataBindings.Add(new Binding("Checked", dgv_LoaiMon.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }

        void AddMonAnBinding()
        {
            txt_MonAn_Ten.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "TenMon", true, DataSourceUpdateMode.Never));
            txt_MonAn_GiaBan.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "GiaBan", true, DataSourceUpdateMode.Never));
            txt_MonAn_Ma.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "MaMon", true, DataSourceUpdateMode.Never));
            rdb_MonAn_HienThi.DataBindings.Add(new Binding("Checked", dgv_MonAn.DataSource, "TrangThai", true, DataSourceUpdateMode.Never));
        }

        private void panel47_Paint(object sender, PaintEventArgs e)
        {

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
            int maLoai =Convert.ToInt32(txt_LoaiMon_MaLoai.Text);
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

        private void rdb_LoaiMon_HienThi_CheckedChanged(object sender, EventArgs e)
        {
            rdb_LoaiMon_KhongHienThi.Checked = !rdb_LoaiMon_HienThi.Checked;
        }
    }
}
