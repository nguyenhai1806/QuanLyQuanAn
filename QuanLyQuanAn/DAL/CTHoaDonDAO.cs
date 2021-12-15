using QuanLyQuanAn.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DTO;
using System.Data;

namespace QuanLyQuanAn.DAL
{
    class CTHoaDonDAO
    {
        #region instance
        private static CTHoaDonDAO instance;

        public static CTHoaDonDAO Instance
        {
            get { if (instance == null) instance = new CTHoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        private CTHoaDonDAO()
        {
        }
        #endregion


        //Lấy danh sách chi tiết hóa đơn từ CSDL

        public List<pCTHoaDon> LayDsCTHoaDon()
        {
            List<pCTHoaDon> danhSach = new List<pCTHoaDon>();

            string query = "SELECT * from pCTHoaDon";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new pCTHoaDon(item));
            }
            return danhSach;
        }


        //Lấy danh sách ct hóa đơn theo mã hd

        public List<pCTHoaDon> LayTheoMaHD(int maHD)
        {
            List<pCTHoaDon> ds = new List<pCTHoaDon>();

            string query = "SELECT * FROM pCTHoaDon WHERE MaHD ='" + maHD + "' ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
                ds.Add(new pCTHoaDon(item));
            return ds;
        }
    }
}
