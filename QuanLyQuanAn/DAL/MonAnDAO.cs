using QuanLyQuanAn.DAO;
using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAL
{
    class MonAnDAO
    {
        #region instance
        private static MonAnDAO instance;
        public static MonAnDAO Instance
        {
            get { if (instance == null) instance = new MonAnDAO(); return MonAnDAO.instance; }
            private set { MonAnDAO.instance = value; }
        }

        private MonAnDAO()
        {
        }
        #endregion

        //Hàm lấy danh sách món ăn
        public List<MonAn> LayDSMonAn()
        {
            List<MonAn> list = new List<MonAn>();
            string query = "select * from MonAn";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                list.Add(monAn);
            }

            return list;
        }

        //Hàm thêm món ăn
        public bool ThemMonAn(string tenMon, string giaBan, int maLoai, bool trangThai)
        {
            string query = string.Format("exec insert_MonAn N'{0}', {1}, {2}, {3}", tenMon, giaBan, maLoai, trangThai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        //Hàm sửa món ăn
        public bool SuaMonAn(int maMon, string tenMon, string giaBan, int maLoai, bool trangThai)
        {
            string query = string.Format("exec update_MonAn {0}, N'{1}', {2}, {3}, {4}", maMon, tenMon, giaBan, maLoai, trangThai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            
            return result > 0;
        }
    }
}
