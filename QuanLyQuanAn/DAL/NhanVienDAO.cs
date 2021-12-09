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
    class NhanVienDAO
    {
        #region instance
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }

        private NhanVienDAO()
        {
        }
        #endregion

        public NhanVien LayNhanVienDangNhap(string userName, string password)
        {
            NhanVien nhanVien = null;

            string query = "EXEC dbo.P_LayNhanVienDangNhap @Username , @MatKhau ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { userName,password});

            foreach (DataRow item in data.Rows)
            {
                nhanVien = new NhanVien(item);
                return nhanVien;
            }
            return nhanVien;
        }
        public bool UpdatePassword(string userName, string password)
        {
            bool result = false;
            string query = "EXEC dbo.P_UpdatePassword @Username , @MatKhau ";
            result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName, password }) > 0;
            return result;
        }
        public bool UpdateInfo(int maNV, string gioiTinh, DateTime ngaySinh, string DiaChi, string sdt)
        {
            bool result = false;
            string query = "EXEC dbo.P_UpdateNV @MaNV , @GioiTinh , @NgaySinh , @DiaChi , @SDT ";
            result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { maNV, gioiTinh, ngaySinh, DiaChi, sdt }) > 0;
            return result;
        }
    }
}
