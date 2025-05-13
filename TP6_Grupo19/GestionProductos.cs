using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TP6_Grupo19.Clases;

namespace TP6_Grupo19
{
	public class GestionProductos
	{
		Conexion conexion = new Conexion();	
		public DataTable ObtenerTodosLosProductos()
		{
			return conexion.TraerTabla("SELECT IdProducto, NombreProducto, CantidadPorUnidad, PrecioUnidad FROM Productos", "Productos");

        }
        public void ArmarParametrosProductoEliminar(ref SqlCommand Comando, Producto producto)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProducto", SqlDbType.Int);
            SqlParametros.Value = producto.IdProducto; 
        }
        public bool EliminarProducto(Producto producto)
        {
            SqlCommand sqlCommand = new SqlCommand();
            ArmarParametrosProductoEliminar(ref sqlCommand, producto);
            Conexion conexion = new Conexion();
            int FilasInsertadas = conexion.EjecutarProcedimientoAlmacenado(sqlCommand, "spEliminarProducto");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}