using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    class NhomNhanVien
    {
        int maNhom;
        string tenNhom;
        bool trangThai;
        public string TenNhom { get => tenNhom.Trim(); set => tenNhom = value.Trim(); }
        public int MaNhom { get => maNhom; set => maNhom = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }

        public NhomNhanVien(int maNhom, string tenNhom, bool trangThai)
        {
            MaNhom = maNhom;
            TenNhom = tenNhom;
            TrangThai = trangThai;
        }
        public NhomNhanVien(DataRow row)
        {
            MaNhom = int.Parse(row["MaNhomNV"].ToString());
            TenNhom = row["TenNhom"].ToString();
            TrangThai = Boolean.Parse(row["TrangThai"].ToString());
        }
    }
}
