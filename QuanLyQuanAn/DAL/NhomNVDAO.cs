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
    class NhomNVDAO
    {
        #region instance
        private static NhomNVDAO instance;

        public static NhomNVDAO Instance
        {
            get { if (instance == null) instance = new NhomNVDAO(); return instance; }
            private set { instance = value; }
        }

        private NhomNVDAO()
        {
        }
        #endregion

        public List<NhomNhanVien> LayDSNhomNV()
        {
            List<NhomNhanVien> danhSach = new List<NhomNhanVien>();

            string query = "SELECT MaNhomNV,TenNhom,TrangThai FROM dbo.NhomNhanVien";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new NhomNhanVien(item));
            }
            return danhSach;
        }
        public NhomNhanVien LayNNVTheoTenNhom(string tenNhom)
        {
            string sql = "SELECT * FROM dbo.NhomNhanVien WHERE TenNhom = N'" + tenNhom + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                return new NhomNhanVien(item);
            }
            return null;
        }
        public NhomNhanVien LayNNVTheoID(int id)
        {
            string sql = "SELECT * FROM dbo.NhomNhanVien WHERE MaNhomNV = " + id.ToString();
            DataTable data = DataProvider.Instance.ExcuteQuery(sql);
            foreach (DataRow item in data.Rows)
            {
                return new NhomNhanVien(item);
            }
            return null;
        }
        public bool ThemNhomNV(string tenNhom, bool trangThai)
        {
            string sql = "EXEC dbo.P_ThemNhomNV @TenNhom , @TrangThai ";
            int result = DataProvider.Instance.ExcuteNonQuery(sql, new Object[] {tenNhom,trangThai});
            return result > 0;
        }
        public bool SuaNhomNV(int maNhom,string tenNhom, bool trangThai)
        {
            string query = "EXEC dbo.P_SuaNhomNV @MaNhom , @TenNhom , @TrangThai ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new Object[] { maNhom , tenNhom , trangThai });
            return result > 0;
        }


        public List<NhomNhanVien> TimNhomNV(string value)
        {
            List<NhomNhanVien> danhSach = new List<NhomNhanVien>();

            string query = String.Format("SELECT * FROM NhomNhanVien where TenNhom Like N'%{0}%' ", value);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new NhomNhanVien(item));
            }
            return danhSach;
        }
    }
}
