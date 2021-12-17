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


        //Lấy danh sách ct hóa đơn theo mã hd

        public List<CTHoaDon> LayTheoMaHD(int maHD)
        {
            List<CTHoaDon> ds = new List<CTHoaDon>();

            string query = "EXEC dbo.P_LayCTHDTheoMaHD @MaHD ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new Object[] { maHD});

            foreach (DataRow item in data.Rows)
                ds.Add(new CTHoaDon(item));
            return ds;
        }
        public void ThemCTHD(int maHD)
        {
            string query = "EXEC dbo.P_ThemCTHD @MaHD ";
            DataProvider.Instance.ExcuteNonQuery(query, new Object[] { maHD });
        }
    }
}
