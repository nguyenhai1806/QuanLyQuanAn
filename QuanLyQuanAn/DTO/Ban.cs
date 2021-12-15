using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanAn.DTO
{
    public class Ban
    {
        public string MaBan { get; set; }
        public string TenBan { get; set; }
        public bool TrangThai { get; set; }

        public List<Menu> MenuBan { get; set; }

        public Ban(string maBan, string tenBan, bool trangThai)
        {
            this.MaBan = maBan;
            this.TenBan = tenBan;
            this.TrangThai = trangThai;
            this.MenuBan = new List<Menu>();
        }

        public Ban(DataRow row)
        {
            MaBan = row["MaBan"].ToString();
            TenBan = row["TenBan"].ToString();
            TrangThai = Boolean.Parse(row["TrangThai"].ToString());
            this.MenuBan = new List<Menu>();
        }
    }
}
