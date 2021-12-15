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
    class LoaiMonDAO
    {
        #region instance
        private static LoaiMonDAO instance;
        public static LoaiMonDAO Instance
        {
            get { if (instance == null) instance = new LoaiMonDAO(); return LoaiMonDAO.instance; }
            private set { LoaiMonDAO.instance = value; }
        }

        private LoaiMonDAO()
        {
        }
        #endregion

        //Hàm lấy danh sách loại món
        public List<LoaiMon> LayDSLoaiMon()
        {
            List<LoaiMon> list = new List<LoaiMon>();
            string query = "select * from LoaiMonAn";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiMon loaiMon = new LoaiMon(item);
                list.Add(loaiMon);
            }

            return list;
        }

        public List<LoaiMon> LayDSLoaiMonTM()
        {
            List<LoaiMon> list = new List<LoaiMon>();
            string query = "select * from LoaiMonAn where TrangThai = 1";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiMon loaiMon = new LoaiMon(item);
                list.Add(loaiMon);
            }

            return list;
        }

        //Hàm lấy loại món theo Mã Loại Món
        public LoaiMon LayLoaiMonTheoID(int id)
        {
            LoaiMon loai = null;

            string query = "select * from LoaiMonAn where MaLoai = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                loai = new LoaiMon(item);
                return loai;
            }

            return loai;
        }



        //Hàm thêm Loại Món
        public bool ThemLoaiMon(string tenLoai, bool trangThai)
        {
            string query = string.Format("exec insert_LoaiMon N'{0}', {1}", tenLoai, trangThai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }

        //Hàm KT trùng tên Loại Món
        public LoaiMon LayLoaiMonTheoTen(string tenLoai)
        {
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM LoaiMonAn WHERE TenLoai = N'" + tenLoai + "'");
            foreach (DataRow row in table.Rows)
            {
                LoaiMon ktTen = new LoaiMon(row);
                return ktTen;
            }
            return null;
        }

        //Hàm sửa Loại Món
        public bool SuaLoaiMon(int maLoai, string tenLoai, bool trangThai)
        {
            string query = string.Format("exec update_LoaiMon {0}, N'{1}', {2}",maLoai, tenLoai, trangThai);
            int result = DataProvider.Instance.ExcuteNonQuery(query);

            return result > 0;
        }


        public List<LoaiMon> TimLoaiMonAn(string value)
        {
            List<LoaiMon> danhSach = new List<LoaiMon>();

            string query = String.Format("SELECT * FROM LoaiMonAn where TenLoai Like N'%{0}%' ", value);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new LoaiMon(item));
            }
            return danhSach;
        }
    }
}
