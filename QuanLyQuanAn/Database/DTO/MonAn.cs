using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    class MonAn
    {
        public MonAn(int mamon, string tenmon, string giaban, int maloai, string trangthai)
        {
            this.MaMon = mamon;
            this.TenMon = tenmon;
            this.GiaBan = giaban;
            this.MaLoai = maloai;
            this.TrangThai = trangthai;
        }

        public MonAn(DataRow row)
        {
            this.MaMon = (int)row["MaMon"];
            this.TenMon = row["TenMon"].ToString();
            this.GiaBan = row["GiaBan"].ToString();
            this.MaLoai = (int)row["MaLoai"];
            this.TrangThai = row["TrangThai"].ToString();
        }

        private int maMon;
        private string tenMon;
        private string giaBan;
        private int maLoai;
        private string trangThai;

        public int MaMon { get => maMon; set => maMon = value; }
        public string TenMon { get => tenMon; set => tenMon = value; }
        public string GiaBan { get => giaBan; set => giaBan = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
