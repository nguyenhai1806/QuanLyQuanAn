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
    public partial class frmDoanhThu : Form
    {
        BindingSource dsHoaDon = new BindingSource();
        BindingSource dsCTHoaDon = new BindingSource();

        public frmDoanhThu()
        {
            InitializeComponent();
            CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
            Makeup.DataGridView(dgvHoaDon);
            Makeup.DataGridView(dgvCTHoaDon);
            
            dgvHoaDon.DataSource = dsHoaDon;
            dgvCTHoaDon.DataSource = dsCTHoaDon;
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

            dgvHoaDon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dgvHoaDon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHoaDon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHoaDon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvHoaDon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        void LoadCTHoaDon()
        {
            dgvCTHoaDon.DataSource = dsCTHoaDon;
            dgvCTHoaDon.Columns[0].HeaderText = "Mã món";
            dgvCTHoaDon.Columns[1].HeaderText = "Tên Món Ăn";
            dgvCTHoaDon.Columns[2].HeaderText = "Số Lượng";
            dgvCTHoaDon.Columns[3].HeaderText = "Thành Tiền";

            dgvCTHoaDon.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCTHoaDon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCTHoaDon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCTHoaDon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mahd = int.Parse(dgvHoaDon.CurrentRow.Cells[0].Value.ToString());
            dsCTHoaDon.DataSource = CTHoaDonDAO.Instance.LayTheoMaHD(mahd);
            LoadCTHoaDon();
        }

        private void btn_HD_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string hd = txt_HD_Search.Text;
                List<HoaDon> ds = HoaDonDAO.Instance.TimHoaDon(hd);
                dgvHoaDon.DataSource = ds;
                LoadHoaDon();
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi định dạng nhập! Vui lòng kiểm tra lại","", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            
        }
    }
}