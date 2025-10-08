using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    internal class CN
    {
    }

    public static class ConexionDB
    {
        private static string connectionString = "server=EDISON\\SQLEXPRESS; database=Tutorial;integrated security=true";



        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(connectionString);
        }
    }
}

