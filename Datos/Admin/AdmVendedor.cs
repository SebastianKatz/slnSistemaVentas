using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Datos.Admin
{
    public static class AdmVendedor
    {
        public static List<Vendedor> Listar()
        {
            SqlConnection connection = AdmDB.ConectarDB();
            string ConsultaSql = "SELECT Id,Nombre,Apellido,DNI,Comision From dbo.Vendedor";
            SqlCommand command= new SqlCommand(ConsultaSql, connection);
            SqlDataReader reader;
            reader = command.ExecuteReader();
            List<Vendedor> listaVendedores = new List<Vendedor>();
            while (reader.Read())
            {
                listaVendedores.Add(new Vendedor()
                {
                    Id = (int)reader["Id"],
                    Nombre = (string)reader["Nombre"],
                    Apellido = (string)reader["Apellido"],
                    DNI = (string)reader["DNI"],
                    Comision = (decimal)reader["Comision"]
                });
            }
            connection.Close();
            reader.Close();
            return listaVendedores;
        }

        public static DataTable ListarVendedoresID()
        {
            SqlConnection connection = AdmDB.ConectarDB();
            string querySql = "SELECT distinct Comision FROM dbo.Vendedor ";
            SqlDataAdapter adapter = new SqlDataAdapter(querySql, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Comision");
            connection.Close();
            return ds.Tables["Comision"];
        }

        public static DataTable TraerPorID(int Id) {
            SqlConnection connection = AdmDB.ConectarDB();
            string ConsultaSql = "SELECT Id,Nombre,Apellido,DNI,Comision From dbo.Vendedor WHERE Id=@Id";
            SqlDataAdapter adapter = new SqlDataAdapter(ConsultaSql, connection);
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "ID");
            connection.Close();
            return ds.Tables["ID"];
        }

        public static int Insertar(Vendedor vendedor)
        {
            SqlConnection connection = AdmDB.ConectarDB();
            string insertSQL = "INSERT dbo.Vendedor (Nombre,Apellido,DNI,Comision) VALUES (@Nombre,@Apellido,@DNI,@Comision)";
            SqlCommand command = new SqlCommand(insertSQL, connection);
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            command.Parameters.Add("@DNI", SqlDbType.Int).Value = vendedor.DNI;
            command.Parameters.Add("@Comision", SqlDbType.Int).Value = vendedor.Comision;
            int filasAfectadas = command.ExecuteNonQuery();
            connection.Close();
            return filasAfectadas;
        }

        public static DataTable TraerPorComision(int Comision)
        {
            SqlConnection connection = AdmDB.ConectarDB();
            string ConsultaSql = "SELECT Id,Nombre,Apellido,DNI,Comision From dbo.Vendedor WHERE Comision=@Comision";
            SqlDataAdapter adapter = new SqlDataAdapter(ConsultaSql, connection);
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Decimal).Value = Comision;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Comision");
            connection.Close();
            return ds.Tables["Comision"];
        }

        public static int Modificar(Vendedor vendedor)
        {
            SqlConnection connection = AdmDB.ConectarDB();
            string ConsultaSql = "UPDATE dbo.Vendedor SET Nombre=@Nombre,Apellido=@Apellido,DNI=@DNI,Comision=@Comision WHERE Id=@Id";
            SqlCommand command = new SqlCommand(ConsultaSql, connection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = vendedor.Id;
            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            command.Parameters.Add("@DNI", SqlDbType.Int).Value = vendedor.DNI;
            command.Parameters.Add("@Comision", SqlDbType.Int).Value = vendedor.Comision;
            int filasAfectadas = command.ExecuteNonQuery();
            connection.Close();
            return filasAfectadas;
        }
        public static int Eliminar(int id)
        {
            SqlConnection connection = AdmDB.ConectarDB();
            string insertSQL = "DELETE FROM dbo.Vendedor WHERE Id=@Id";
            SqlCommand command = new SqlCommand(insertSQL, connection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            int filasAfectadas = command.ExecuteNonQuery();
            connection.Close();
            return filasAfectadas;

        }
    }
}
