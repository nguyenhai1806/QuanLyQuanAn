﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;

namespace QuanLyQuanAn.DAO
{
    public class DataProvider
    {
        #region instance
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set { instance = value; }
        }

        private DataProvider()
        {
        }
        #endregion

        public String connectionStr = "Data Source=localhost;Initial Catalog=QLTiecQuanAn;Integrated Security=True";

        public DataTable ExcuteQuery(String query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String item in listPara)
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExcuteNonQuery(String query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String item in listPara)
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                }

                data = command.ExecuteNonQuery();
            }
            return data;
        }

        public Object ExecuteScalar(String query, object[] parameters = null)
        {
            Object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameters != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String item in listPara)
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameters[i]);
                            i++;
                        }
                }

                data = command.ExecuteScalar();
            }
            return data;
        }

        public DataSet ExcuteGirdView(String query)
        {
            DataSet data = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(data);
            }
            return data;
        }
    }
}