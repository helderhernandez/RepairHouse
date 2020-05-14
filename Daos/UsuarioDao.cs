using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RepairHouse.Daos
{
    public class UsuarioDao
    {
        Connection connection = new Connection();

        public bool buscarPorCredenciales(string usuario, string contrasena)
        {
            string query = "select count(*) from Usuario where usuario ='"
            + usuario + "' And contrasena ='"
            + contrasena + "'";

            bool correcto;
            try
            {
                connection.openConnection();
                SqlCommand sqlCommand = new SqlCommand(query, connection.getConnection());
                correcto = int.Parse(sqlCommand.ExecuteScalar().ToString()) > 0;

                return correcto;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.closeConnection();
            }
        }

    }
}