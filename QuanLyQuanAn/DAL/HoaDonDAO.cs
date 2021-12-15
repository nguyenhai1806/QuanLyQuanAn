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
    class HoaDonDAO
    {
        #region instance
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set { instance = value; }
        }

        private HoaDonDAO()
        {
        }
        #endregion


        //Lấy danh sách hóa đơn từ CSDL

        public List<pHoaDon> LayDsHoaDon()
        {
            List<pHoaDon> danhSach = new List<pHoaDon>();

            string query = "select * from pHoaDon order by MaHD desc"; 

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new pHoaDon(item));
            }
            return danhSach;
        }


        //Tim hóa đơn theo tên bàn

        public List<pHoaDon> TimHoaDon(string value)
        {
            List<pHoaDon> danhSach = new List<pHoaDon>();

            string query = String.Format("SELECT * FROM pHoaDon where TenBan Like N'%{0}%' ", value);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new pHoaDon(item));
            }
            return danhSach;
        }

    }
}
