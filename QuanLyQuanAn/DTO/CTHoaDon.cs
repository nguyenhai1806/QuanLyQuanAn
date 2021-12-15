using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class CTHoaDon
    {
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public string ThanhTien { get; set; }
        public int MaMon { get; set; }

        public CTHoaDon(string maMon,string tenMon, int soLuong, string thanhTien)
        {
            this.MaMon = MaMon;
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.ThanhTien = thanhTien;
        }

        public CTHoaDon(DataRow row)
        {
            this.MaMon = int.Parse(row["MaMon"].ToString());
            this.TenMon = row["tenMon"].ToString();
            this.SoLuong = int.Parse(row["soLuong"].ToString());
            this.ThanhTien = row["thanhTien"].ToString();
        }
    }
}
