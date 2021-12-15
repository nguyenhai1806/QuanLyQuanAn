using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public string TenKH { get; set; }
        public string HoTen { get; set; }
        public string TenBan { get; set; }
        public DateTime NgayLap { get; set; }
        public string TongTien { get; set; }

        public HoaDon(int maHD, string tenKH, string hoTen, string tenBan, DateTime ngayLap, string tongTien)
        {
            this.MaHD = maHD;
            this.TenKH = tenKH;
            this.HoTen = hoTen;
            this.TenBan = tenBan;
            this.NgayLap = ngayLap;
            this.TongTien = tongTien;
        }

        public HoaDon(DataRow row)
        {
            this.MaHD = int.Parse(row["maHD"].ToString());
            this.TenKH = row["tenKH"].ToString();
            this.HoTen = row["hoTen"].ToString();
            this.TenBan = row["tenBan"].ToString();
            this.NgayLap = DateTime.Parse(row["ngayLap"].ToString());
            this.TongTien = row["tongTien"].ToString();
        }
    }
}
