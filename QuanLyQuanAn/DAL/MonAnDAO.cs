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
            get
            {
                if (instance == null) instance = new MonAnDAO();
                return MonAnDAO.instance;
            }
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

        //Hàm lấy danh sách Món Ăn theo Mã Loại Món
        public List<MonAn> LayDSMonAnTheoMa(int id)
        {
            List<MonAn> ds = new List<MonAn>();

            string query = "select * from MonAn where MaLoai = " + id + "and TrangThai = 1";

            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                ds.Add(monAn);
            }

            return ds;
        }

        //Hàm thêm món ăn
        public bool ThemMonAn(string tenMon, string giaBan, int maLoai, bool trangThai)
        {
            string query = string.Format("exec insert_MonAn N'{0}', {1}, {2}, {3}", tenMon, giaBan, maLoai, trangThai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        //Hàm KT trùng tên Món Ăn
        public MonAn LayMonAnTheoTen(string tenMon)
        {
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM MonAn WHERE TenMon = N'" + tenMon + "'");
            foreach (DataRow row in table.Rows)
            {
                MonAn ktTenMon = new MonAn(row);
                return ktTenMon;
            }

            return null;
        }

        //Hàm sửa món ăn
        public bool SuaMonAn(int maMon, string tenMon, string giaBan, int maLoai, bool trangThai)
        {
            string query = string.Format("exec update_MonAn {0}, N'{1}', {2}, {3}, {4}", maMon, tenMon, giaBan, maLoai,
                trangThai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }
        public List<MonAn> TimMonAn(string value)
        {
            List<MonAn> danhSach = new List<MonAn>();

            string query = String.Format("SELECT * FROM MonAn where TenMon like N'%{0}%' or MaLoai Like N'%{1}%' ", value, value);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new MonAn(item));
            }
            return danhSach;
        }
    }
}