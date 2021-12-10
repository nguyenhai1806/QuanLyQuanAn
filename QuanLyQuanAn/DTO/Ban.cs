using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class Ban
    {
        public string MaBan { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }


        public Ban(string maBan, string tenBan, string trangThai)
        {
            this.MaBan = maBan;
            this.TenBan = tenBan;
            this.TrangThai = trangThai;
        }

        public Ban(DataRow row)
        {
            MaBan = row["maKH"].ToString();
            TenBan = row["tenKH"].ToString();
            TrangThai = row["TrangThai"].ToString();
        }
    }
}
