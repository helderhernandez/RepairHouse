using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RepairHouse.Daos
{
    public class Connection
    {
        string connectionString = ConfigurationManager.ConnectionStrings["casaReparadoraDbConnection"].ConnectionString;
        SqlConnection sqlConnection;

        public void openConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }


        public void closeConnection()
        {
            sqlConnection.Close();
        }


        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}