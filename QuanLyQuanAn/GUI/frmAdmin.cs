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
        BindingSource DSLoaiMon = new BindingSource();
        public frmAdmin()
        {
            InitializeComponent();
            this.CenterToScreen();
            Load();
            
        }

        void Load()
        {
            LoadLoaiMon();
            LoadMonAn();
            AddLoaiMonBinding();
            AddMonAnBinding();
            BindingCombobox();
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
            dgv_MonAn.DataSource = MonAnDAO.Instance.LayDSMonAn();
        }

        void LoadLoaiMonLenCombobox(ComboBox cbb)
        {
            cbb.DataSource = LoaiMonDAO.Instance.LayDSLoaiMon();
            cbb.DisplayMember = "TenLoai";
        }

        void BindingCombobox()
        {
            if (dgv_MonAn.SelectedCells.Count>0)
            {
                int id = (int)dgv_MonAn.SelectedCells[0].OwningRow.Cells["MaLoai"].Value;

                LoaiMon loai = LoaiMonDAO.Instance.LayLoaiMonTheoID(id);

                cbb_MonAn_LoaiMon.SelectedItem = loai.TenLoai;

                //int index = -1;
                //int i = 0;
                //foreach (LoaiMon item in cbb_MonAn_LoaiMon.Items)
                //{
                //    if (item.MaLoai==loai.MaLoai)
                //    {
                //        index = i;
                //        break;
                //    }
                //    i++;
                //}

                //cbb_MonAn_LoaiMon.SelectedIndex = index;
            }
        }

        void AddLoaiMonBinding()
        {
            txt_LoaiMon_Ten.DataBindings.Add(new Binding("Text", dgv_LoaiMon.DataSource, "TenLoai"));
        }

        void AddMonAnBinding()
        {
            txt_MonAn_Ten.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "TenMon"));
            txt_MonAn_GiaBan.DataBindings.Add(new Binding("Text", dgv_MonAn.DataSource, "GiaBan"));
            if (dgv_MonAn.SelectedCells.Count > 0)
            {
                int id = (int)dgv_MonAn.SelectedCells[0].OwningRow.Cells["MaLoai"].Value;

                LoaiMon loai = LoaiMonDAO.Instance.LayLoaiMonTheoID(id);

                cbb_MonAn_LoaiMon.SelectedItem = loai.TenLoai;

                //int index = -1;
                //int i = 0;
                //foreach (LoaiMon item in cbb_MonAn_LoaiMon.Items)
                //{
                //    if (item.MaLoai==loai.MaLoai)
                //    {
                //        index = i;
                //        break;
                //    }
                //    i++;
                //}

                //cbb_MonAn_LoaiMon.SelectedIndex = index;
            }
        }
    }
}
