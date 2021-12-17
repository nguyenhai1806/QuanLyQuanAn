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

        public List<HoaDon> LayDsHoaDon()
        {
            List<HoaDon> danhSach = new List<HoaDon>();

            string query = "EXEC P_LayHoaDons"; 

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new HoaDon(item));
            }
            return danhSach;
        }


        //Tim hóa đơn theo tên bàn

        public List<HoaDon> TimHoaDon(string value)
        {
            List<HoaDon> danhSach = new List<HoaDon>();
            int maHD = -1;
            int.TryParse(value, out maHD);
            string query = "EXEC dbo.P_TimHoaDon @MaHD , @TenKH , @TenNV";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new Object[] { maHD, "%" + value + "%", "%" + value + "%" });

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new HoaDon(item));
            }
            return danhSach;
        }
        public int TaoHoaDon(int maBan, int maKH, int maNV)
        {
            string query = "EXEC dbo.P_TaoHoaDon @MaBan , @MaKH , @MaNV ";
            DataProvider.Instance.ExcuteNonQuery(query, new Object[] { maBan, maKH, maNV });
            string query2 = "SELECT TOP 1 MaHD FROM dbo.HoaDon ORDER BY MaHD";
            return int.Parse(DataProvider.Instance.ExecuteScalar(query2).ToString());
        }
    }
}
