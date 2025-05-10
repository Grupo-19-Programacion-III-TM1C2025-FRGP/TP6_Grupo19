using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TP6_Grupo19.Clases
{
    public class Conexion
    {
        private string _cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        private readonly SqlConnection _sqlConnection;
        private string _consultaSQL;

        public Conexion()
        {
            _sqlConnection = new SqlConnection(_cadenaConexion);

        }

        public DataTable TraerTabla(string consultaSql, string nombreTabla)
        {
            _consultaSQL = "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos";

            _sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(_consultaSQL, _sqlConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, nombreTabla);

            _sqlConnection.Close();

            return dataSet.Tables[nombreTabla];
        }
    }
}
    
