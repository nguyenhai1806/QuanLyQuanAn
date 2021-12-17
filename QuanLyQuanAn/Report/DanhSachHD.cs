using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyQuanAn.DAL;
using QuanLyQuanAn.DTO;
using QuanLyQuanAn.GUI;

namespace QuanLyQuanAn.Report
{
    public partial class DanhSachHD : Form
    {
        public DanhSachHD()
        {
            InitializeComponent();
        }

        //void LoaiMonAnTheoMaLoaiMon(int id)
        //{
        //    List<CTHoaDon> ds = CTHoaDonDAO.Instance.LayTheoMaHD(id);
        //    cboMaHD.DataSource = ds;
        //    cboMaHD.DisplayMember = "MaHD";
        //}

        void hienThiMaHD(int id)
        {
            List<HoaDon> dshd = HoaDonDAO.Instance.LayDsHoaDon();
            cboMaHD.DataSource = dshd;
            cboMaHD.DisplayMember = "maHD";
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            rptXuatHD rpt = new rptXuatHD();
            rpt.SetDatabaseLogon("", "", "localhost", "QLTiecQuanAn");

            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            cboMaHD.ValueMember = "MaHD";
            rpt.SetParameterValue("LocMaHD", cboMaHD.SelectedValue.ToString());
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmDoanhThu f = new frmDoanhThu();
            f.Show();
            this.Dispose(false);
        }

        private void DanhSachHD_Load(object sender, EventArgs e)
        {
            int id = 0;
            hienThiMaHD(id);
        }
    }
}
