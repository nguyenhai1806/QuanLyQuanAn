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
    class LoaiMonDAO
    {
        #region instance
        private static LoaiMonDAO instance;
        public static LoaiMonDAO Instance
        {
            get { if (instance == null) instance = new LoaiMonDAO(); return LoaiMonDAO.instance; }
            private set { LoaiMonDAO.instance = value; }
        }

        private LoaiMonDAO()
        {
        }
        #endregion

        public List<LoaiMon> LayDSLoaiMon()
        {
            List<LoaiMon> list = new List<LoaiMon>();
            string query = "select * from LoaiMonAn";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiMon loaiMon = new LoaiMon(item);
                list.Add(loaiMon);
            }

            return list;
        }

        public LoaiMon LayLoaiMonTheoID(int id)
        {
            LoaiMon loai = null;

            string query = "select * from MonAn where id = " +id;
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                loai = new LoaiMon(item);
                return loai;
            }

            return loai;
        }
    }
}
