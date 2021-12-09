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

        public List<KhachHangDTO> LayDsKhachHang()
        {
            List<KhachHangDTO> danhSach = new List<KhachHangDTO>();

            string query = "SELECT * FROM KhachHang";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new KhachHangDTO(item));
            }
            return danhSach;
        }


        //Tim khách hàng theo số điện thoại

        public List<KhachHangDTO> TimSDT(string sdt)
        {
            List<KhachHangDTO> danhSach = new List<KhachHangDTO>();

            string query = "SELECT * FROM KhachHang where SDT = '" + sdt + "' ";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                danhSach.Add(new KhachHangDTO(item));
            }
            return danhSach;
        }


        //Thêm khách hàng

        public bool themKH(string tenKH, string ngaySinh, string gioiTinh, string diaChi, string sdt, bool trangThai)
        {
            int result = DataProvider.Instance.ExcuteNonQuery("insert into KhachHang(TenKH, NgaySinh, GioiTinh, DiaChi, SDT, TrangThai) Values( N'" + tenKH + "', '" + ngaySinh + "', N'" + gioiTinh + "', N'" + diaChi + "', '" + sdt + "', '" + trangThai + "')");

            return result > 0;
        }


        //Kiểm tra trùng

        public string KTKhachHangtheoSDT(string sdt)
        {
            DataTable table = DataProvider.Instance.ExcuteQuery("SELECT * FROM KhachHang WHERE SDT = '" + sdt + "'");
            foreach (DataRow row in table.Rows)
            {
                KhachHangDTO kt = new KhachHangDTO(row);
                return kt.SDT;
            }
            return "";
        }


        //Sửa khách hàng

        public bool suaKHBangSDT(string tenKH, string ngaySinh, string gioiTinh, string diaChi, string sdt, bool trangThai)
        {
            string query = "UPDATE KhachHang SET TenKH = N'" + tenKH + "', NgaySinh = '" + ngaySinh + "', GioiTinh = N'" + gioiTinh + "', DiaChi = N'" + diaChi + "', TrangThai = '" + trangThai + "'  WHERE SDT = " + sdt;
            int result = DataProvider.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
