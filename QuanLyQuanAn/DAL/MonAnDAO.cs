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
    class MonAnDAO
    {
        #region instance
        private static MonAnDAO instance;
        public static MonAnDAO Instance
        {
            get { if (instance == null) instance = new MonAnDAO(); return MonAnDAO.instance; }
            private set { MonAnDAO.instance = value; }
        }

        private MonAnDAO()
        {
        }
        #endregion

        public List<MonAn> LayDSMonAn()
        {
            List<MonAn> list = new List<MonAn>();
            string query = "select * from MonAn";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MonAn monAn = new MonAn(item);
                list.Add(monAn);
            }

            return list;
        }
    }
}
