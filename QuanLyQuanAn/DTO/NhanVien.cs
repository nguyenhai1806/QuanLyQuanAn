using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    class NhanVien
    {
        private int maNV;
        private int maNhomNV;
        private string tenDangNhap;
        private string matKhau;
        private string hoTen;
        private string gioiTinh;
        private string diaChi;
        private string sdt;
        private bool trangThai;
        private DateTime ngaySinh;

        public int MaNV
        {
            get => maNV;
            set => maNV = value;
        }

        public string TenDangNhap
        {
            get => tenDangNhap.Trim();
            set => tenDangNhap = value.Trim();
        }

        public string MatKhau
        {
            get => matKhau;
            set => matKhau = value.Trim();
        }

        public string HoTen
        {
            get => hoTen.Trim();
            set => hoTen = value.Trim();
        }

        public string GioiTinh
        {
            get => gioiTinh.Trim();
            set => gioiTinh = value.Trim();
        }

        public string DiaChi
        {
            get => diaChi.Trim();
            set => diaChi = value.Trim();
        }

        public string Sdt
        {
            get => sdt.Trim();
            set => sdt = value.Trim();
        }

        public bool TrangThai
        {
            get => trangThai;
            set => trangThai = value;
        }

        public DateTime NgaySinh
        {
            get => ngaySinh;
            set => ngaySinh = value;
        }

        public int MaNhomNV
        {
            get => maNhomNV;
            set => maNhomNV = value;
        }

        public NhanVien(int maNV, string tenDangNhap, string matKhau, string hoTen, string diaChi, string sdt,
            bool trangThai, DateTime ngaySinh, int maNhomNV)
        {
            this.MaNV = maNV;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
            this.HoTen = hoTen;
            this.DiaChi = diaChi;
            this.Sdt = sdt;
            this.TrangThai = trangThai;
            this.NgaySinh = ngaySinh;
            this.MaNhomNV = maNhomNV;
        }

        public NhanVien(DataRow row)
        {
            MaNV = int.Parse(row["MaNV"].ToString());
            MaNhomNV = int.Parse(row["MaNhomNV"].ToString());
            TenDangNhap = row["TenDangNhap"].ToString();
            HoTen = row["HoTen"].ToString();
            GioiTinh = row["GioiTinh"].ToString();
            ngaySinh = DateTime.Parse(row["NgaySinh"].ToString());
            DiaChi = row["DiaChi"].ToString();
            Sdt = row["SDT"].ToString();
            TrangThai = Boolean.Parse(row["TrangThai"].ToString());
        }
    }
}