using QuanLyQuanAn.DAO;
using QuanLyQuanAn.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.DAL
{
    public class MenuDAO
    {
        #region instance
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() 
        {
        }
        #endregion

        public List<Menu> LayDSMenuTheoMaBan(int id)
        {
            List<Menu> listMenu = new List<Menu>();

            string query = "SELECT f.MaMon, f.TenMon, bf.SoLuong, f.GiaBan, f.GiaBan*bf.SoLuong AS thanhTien FROM CTHoaDon AS bf, HoaDon AS b, MonAn AS f WHERE bf.MaHD = b.MaHD AND bf.MaMon = f.MaMon AND b.MaBan = " + id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
