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

        public List<NhanVien> LayDSNhanVien()
        {
            List<NhanVien> danhSach = new List<NhanVien>();

            string query = "SELECT * FROM dbo.NhanVien";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new NhanVien(item));
            }
            return danhSach;
        }
        public bool ThemNhanVien(int maNhomNV, string tenDanhNhap,string matKhau, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string soDienThoai, bool trangThai )
        {
            string sql = "EXEC dbo.P_ThemNhanVien @MaNhomNV , @TenDanhNhap , @MatKhau , @HoTen , @GioiTinh , @NgaySinh , @DiaChi , @SDT , @TrangThai ";
            int result = DataProvider.Instance.ExcuteNonQuery(sql, new Object[] { maNhomNV, tenDanhNhap, matKhau, hoTen, gioiTinh, ngaySinh, diaChi, soDienThoai, trangThai });
            return result > 0;
        }
        public bool SuaNhanVien(int maNV,int maNhomNV, string hoTen, string gioiTinh, DateTime ngaySinh, string diaChi, string soDienThoai, bool trangThai)
        {
            bool result = false;
            string query = "EXEC dbo.P_SuaNhanVien @MaNV , @MaNhomNV , @HoTen , @GioiTinh , @NgaySinh , @DiaChi , @SDT , @TrangThai ";
            result = DataProvider.Instance.ExcuteNonQuery(query, new object[] {maNV,maNhomNV,hoTen, gioiTinh, ngaySinh, diaChi, soDienThoai, trangThai}) > 0;
            return result;
        }
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
        public NhanVien LayNhanVienTheoUsername(string userName)
        {
            NhanVien nhanVien = null;

            string query = "SELECT * FROM dbo.NhanVien WHERE TenDangNhap = '" + userName + "'";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

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


        public List<NhanVien> TimNhanVien(string value)
        {
            List<NhanVien> danhSach = new List<NhanVien>();

            string query = String.Format("SELECT * FROM NhanVien where SDT like N'%{0}%' or HoTen Like N'%{1}%' ", value, value);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new NhanVien(item));
            }
            return danhSach;
        }
    }
}
