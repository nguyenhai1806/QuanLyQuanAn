using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class Menu
    {
        int maMon;
        int soLuong;
        string tenMon;
        double donGia;
        double thanhTien;

        public Menu()
        {
            int maMon = -1;
            int soLuong = 0;
            TenMon = null;
            DonGia = 0;
            ThanhTien = 0;
        }

        public Menu(int maMon, int soLuong, string tenMon, double donGia, double thanhTien)
        {
            this.maMon = maMon;
            this.soLuong = soLuong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public int MaMon
        {
            get => maMon;
            set => maMon = value;
        }

        public int SoLuong
        {
            get => soLuong;
            set => soLuong = value;
        }

        public string TenMon
        {
            get => tenMon;
            set => tenMon = value;
        }

        public double DonGia
        {
            get => donGia;
            set => donGia = value;
        }

        public double ThanhTien
        {
            get => thanhTien;
            set => thanhTien = value;
        }
    }
}