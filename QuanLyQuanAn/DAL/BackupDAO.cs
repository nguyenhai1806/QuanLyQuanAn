using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanAn.DAO;

namespace QuanLyQuanAn.DAL
{
    class BackupDAO
    {
        #region instance

        private static BackupDAO instance;

        public static BackupDAO Instance
        {
            get
            {
                if (instance == null) instance = new BackupDAO();
                return instance;
            }
            private set { instance = value; }
        }

        private BackupDAO()
        {
        }

        #endregion

        public bool FullBackup(string address)
        {
            try
            {
                DataProvider.Instance.ExcuteQuery("EXEC dbo.P_FullBackup @link ", new Object[] {address});
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DiffBackup(string address)
        {
            try
            {
                DataProvider.Instance.ExcuteQuery("EXEC dbo.P_DiffBackup @link ", new Object[] { address });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool LogBackup(string address)
        {
            try
            {
                DataProvider.Instance.ExcuteNonQuery("EXEC dbo.P_LogBackup @link ", new Object[] { address });
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Recovery(string databaseName, string fileFull, string fileDiff, string fileLog)
        {
            DataProvider.RunQueryOnMaster("EXEC dbo.P_Recovery @database , @fullBackup , @diffBackup , @logBackup ", new Object[] { databaseName, fileFull, fileDiff, fileLog });
            return true;
        }
    }


}
