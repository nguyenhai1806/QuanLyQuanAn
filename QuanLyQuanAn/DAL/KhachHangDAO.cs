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
    class KhachHangDAO
    {
        #region instance
        private static KhachHangDAO instance;

        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }

        private KhachHangDAO()
        {
        }
        #endregion


        //Lấy danh sách khách hàng từ CSDL

        public List<KhachHang> LayDsKhachHang()
        {
            List<KhachHang> danhSach = new List<KhachHang>();

            string query = "SELECT * FROM KhachHang";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new KhachHang(item));
            }
            return danhSach;
        }


        //Tim khách hàng theo số điện thoại

        public List<KhachHang> TimKH(string value)
        {
            List<KhachHang> danhSach = new List<KhachHang>();

            string query = String.Format("SELECT * FROM KhachHang where SDT like N'%{0}%' or TenKH Like N'%{1}%' ", value, value);
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new KhachHang(item));
            }
            return danhSach;
        }


        //Thêm khách hàng

        public bool themKH(string tenKH, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, bool trangThai)
        {
            string sql = "EXEC dbo.P_ThemKhachHang @TenKH , @NgaySinh , @GioiTinh , @DiaChi , @SDT , @TrangThai ";
            int result = DataProvider.Instance.ExcuteNonQuery(sql,new Object[] {tenKH,ngaySinh,gioiTinh,diaChi,sdt,trangThai});
            return result > 0;
        }


        //Kiểm tra trùng

        public string KTKhachHangtheoSDT(string sdt)
        {
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM KhachHang WHERE SDT = '" + sdt + "'");
            foreach (DataRow row in table.Rows)
            {
                KhachHang kt = new KhachHang(row);
                return kt.SDT.Trim(); ;
            }
            return "";
        }

        //Sửa khách hàng

        public bool suaKHBangSDT(string tenKH, DateTime ngaySinh, string gioiTinh, string diaChi, string sdt, bool trangThai)
        {
            string query = "EXEC dbo.P_SuaKhachHang @TenKH , @NgaySinh , @GioiTinh , @DiaChi , @TrangThai , @SDT ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new Object[] { tenKH,ngaySinh,gioiTinh,diaChi,trangThai,sdt});
            return result > 0;
        }
    }
}
