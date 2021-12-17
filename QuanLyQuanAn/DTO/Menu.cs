using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    public class Menu
    {
        public Menu(int maMon, string tenMon, int soLuong, float giaBan, float thanhTien = 0)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.GiaBan = giaBan;
            this.ThanhTien = thanhTien;
        }

        public Menu(DataRow row)
        {
            this.MaMon = (int)row["maMon"];
            this.TenMon = row["tenMon"].ToString();
            this.SoLuong = (int)row["soLuong"];
            this.GiaBan = (float)Convert.ToDouble(row["giaBan"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["thanhTien"].ToString());
        }
        
        private int maMon;
        private string tenMon;
        private int soLuong;
        private float giaBan;
        private float thanhTien;

        public string TenMon { get => tenMon; set => tenMon = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float GiaBan { get => giaBan; set => giaBan = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
        public int MaMon { get => maMon; set => maMon = value; }
    }
}