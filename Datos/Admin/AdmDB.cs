using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos.Admin
{
    internal static class AdmDB
    {
        internal static SqlConnection ConectarDB()
        {
            string cadena = Datos.Properties.Settings.Default.Key;

            SqlConnection connection = new SqlConnection(cadena);

            connection.Open();
            return connection;
        }
    }
}
