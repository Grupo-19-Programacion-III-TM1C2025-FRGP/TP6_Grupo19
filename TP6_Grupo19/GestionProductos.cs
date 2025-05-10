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
	}
}