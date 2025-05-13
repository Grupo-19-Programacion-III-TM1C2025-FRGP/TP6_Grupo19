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


        private void ArmarParametrosProductoEliminar(ref SqlCommand Comando, Producto producto)
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
            int FilasInsertadas = conexion.EjecutarProcesamientoAlmacenado(sqlCommand, "spEliminarProducto");
            if (FilasInsertadas == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


		public DataTable ObtenerTodosLosProductosEjercicio2()
		{
			return conexion.TraerTabla("SELECT IdProducto, NombreProducto, IdProveedor, PrecioUnidad FROM Productos", "Productos");
		}


		private void ArmarParametrosProductos(ref SqlCommand Comando, Producto producto)
		{
			SqlParameter SqlParametros = new SqlParameter();
			SqlParametros = Comando.Parameters.Add("@IDPRODUCTO", SqlDbType.Int);
			SqlParametros.Value = producto.IdProducto;
            
            SqlParametros = Comando.Parameters.Add("@NOMBREPRODUCTO", SqlDbType.NVarChar, 50);
            SqlParametros.Value = producto.NombreProducto;
			
            SqlParametros = Comando.Parameters.Add("@CANTIDADUNIDAD", SqlDbType.Int);
            SqlParametros.Value = producto.CantidadUnidad;
			
            SqlParametros = Comando.Parameters.Add("@PRECIOUNIDAD", SqlDbType.Money);
            SqlParametros.Value = producto.PrecioUnidad;
            
        }

		public bool ActualizarProducto(Producto producto)
		{
			SqlCommand sqlCommand = new SqlCommand();
			ArmarParametrosProductos(ref sqlCommand, producto);
			Conexion conexion = new Conexion();
			int FilasInsertadas = conexion.EjecutarProcesamientoAlmacenado(sqlCommand, "spActualizarProducto");
			if(FilasInsertadas == 1)
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