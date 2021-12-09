using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class KhachHangDTO
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public bool TrangThai { get; set; }


        public KhachHangDTO(string maKH, string tenKH, string ngaySinh, string gioiTinh, string diaChi, string sdt, bool trangThai)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH.Trim();
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh.Trim();
            this.DiaChi = diaChi.Trim();
            this.SDT = sdt.Trim();
            this.TrangThai = trangThai;
        }

        public KhachHangDTO(DataRow row)
        {
            this.MaKH = row["maKH"].ToString();
            this.TenKH = row["tenKH"].ToString();
            this.NgaySinh = row["ngaySinh"].ToString();
            this.GioiTinh = row["gioiTinh"].ToString();
            this.DiaChi = row["diaChi"].ToString();
            this.SDT = row["sdt"].ToString();
            this.TrangThai = (bool)row["trangThai"];
        }
    }
}
