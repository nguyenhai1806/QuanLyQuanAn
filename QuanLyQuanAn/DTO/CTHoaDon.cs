using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class pCTHoaDon
    {
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public string ThanhTien { get; set; }

        public pCTHoaDon(string tenMon, int soLuong, string thanhTien)
        {
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
        }

        public pCTHoaDon(DataRow row)
        {
            this.TenMon = row["tenMon"].ToString();
            this.SoLuong = int.Parse(row["soLuong"].ToString());
            this.ThanhTien = row["thanhTien"].ToString();
        }
    }
}
