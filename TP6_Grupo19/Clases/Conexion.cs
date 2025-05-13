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
        private string _cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True";
        private readonly SqlConnection _sqlConnection;
        // private string _consultaSQL;

        public Conexion()
        {
            _sqlConnection = new SqlConnection(_cadenaConexion);

        }

        public DataTable TraerTabla(string consultaSQL, string nombreTabla)
        {
            //_consultaSQL = "SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos";

            _sqlConnection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(consultaSQL, _sqlConnection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, nombreTabla);

            _sqlConnection.Close();

            return dataSet.Tables[nombreTabla];
        }


        public int EjecutarProcesamientoAlmacenado(SqlCommand comandoSQL, string nombreProcesamientoAlmacenado)
        {

            int FilasCambiadas;
            SqlConnection conexion = _sqlConnection;
            SqlCommand sqlCommand = new SqlCommand();
            conexion.Open();
            sqlCommand = comandoSQL;
            sqlCommand.Connection = conexion;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = nombreProcesamientoAlmacenado;
            FilasCambiadas = sqlCommand.ExecuteNonQuery();
            conexion.Close();
            return FilasCambiadas; 
        }

    }
}
    
