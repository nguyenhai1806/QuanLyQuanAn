using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DTO
{
    class BienToanCuc
    {
        private static NhanVien nguoiDangNhap = null;

        public static NhanVien NguoiDangNhap
        {
            get => nguoiDangNhap;
            set => nguoiDangNhap = value;
        }
    }
}