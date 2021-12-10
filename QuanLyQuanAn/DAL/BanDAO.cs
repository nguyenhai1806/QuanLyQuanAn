using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DAO;
using QuanLyQuanAn.DTO;

namespace QuanLyQuanAn.DAL
{
    class BanDAO
    {
        #region instance
        private static BanDAO instance;

        public static BanDAO Instance
        {
            get { if (instance == null) instance = new BanDAO(); return instance; }
            private set { instance = value; }
        }

        private BanDAO()
        {
        }
        #endregion

        public static int TableWidth = 130;
        public static int TableHeight = 130;

        public List<Ban> LayDSBan()
        {
            List<Ban> danhSach = new List<Ban>();

            string query = "SELECT * FROM Ban";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new Ban(item));
            }
            return danhSach;
        }
    }
}
