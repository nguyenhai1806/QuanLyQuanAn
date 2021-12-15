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
    public partial class frmDoanhThu : Form
    {
        BindingSource dsHoaDon = new BindingSource();
        BindingSource dsCTHoaDon = new BindingSource();

        public frmDoanhThu()
        {
            InitializeComponent();
            CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            //Makeup.DataGridView(dgvHoaDon);
            dgvHoaDon.DataSource = dsHoaDon;
            LoadHoaDon();

            dgvHoaDon.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        void LoadHoaDon()
        {
            dsHoaDon.DataSource = HoaDonDAO.Instance.LayDsHoaDon();
            dgvHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgvHoaDon.Columns[1].HeaderText = "Tên Khách Hàng";
            dgvHoaDon.Columns[2].HeaderText = "Tên Nhân Viên";
            dgvHoaDon.Columns[3].HeaderText = "Bàn";
            dgvHoaDon.Columns[4].HeaderText = "Ngày Lập";
            dgvHoaDon.Columns[5].HeaderText = "Tổng Tiền";

            dgvHoaDon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        void LoadCTHoaDon()
        {
            dsCTHoaDon.DataSource = CTHoaDonDAO.Instance.LayDsCTHoaDon();
            dgvCTHoaDon.Columns[0].HeaderText = "Tên Món Ăn";
            dgvCTHoaDon.Columns[1].HeaderText = "Số Lượng";
            dgvCTHoaDon.Columns[2].HeaderText = "Thành Tiền";

            dgvCTHoaDon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCTHoaDon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCTHoaDon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mahd = int.Parse(dgvHoaDon.CurrentRow.Cells[0].Value.ToString());

            dgvCTHoaDon.DataSource = CTHoaDonDAO.Instance.LayTheoMaHD(mahd);

            LoadCTHoaDon();
        }

        private void btn_HD_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string hd = txt_HD_Search.Text;
                List<pHoaDon> ds = HoaDonDAO.Instance.TimHoaDon(hd);
                dgvHoaDon.DataSource = ds;
                LoadHoaDon();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi định dạng nhập! Vui lòng kiểm tra lại", "Tìm mã bàn của hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
