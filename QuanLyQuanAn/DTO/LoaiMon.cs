using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    class LoaiMon
    {
        public LoaiMon(int maloai, string tenloai, string trangthai)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
            this.TrangThai = trangthai;
        }
        
        public LoaiMon (DataRow row)
        {
            this.MaLoai = (int)row["MaLoai"];
            this.TenLoai = row["TenLoai"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }

        private string trangThai;

        private string tenLoai;

        private int maLoai;

        public int MaLoai { get => maLoai; set => maLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
