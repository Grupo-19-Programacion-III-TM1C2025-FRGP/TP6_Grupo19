using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP6_Grupo19.Clases
{

    public class Producto
    {
        private int _idProducto;
        private string _nombreProducto;
        private string _cantidadUnidad;
        private decimal _precioUnidad;

        public Producto()
        {

        }

        public Producto(int idProdcuto, string nombreProducto, string cantidadUnidad, decimal precioUnidad)
        {
            _idProducto = idProdcuto;
            _nombreProducto = nombreProducto;
            _cantidadUnidad = cantidadUnidad;
            _precioUnidad = precioUnidad;
        }

        public int IdProducto
        {
            get { return _idProducto; }
            set { _idProducto = value; }
        }

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        public string CantidadUnidad
        {
            get { return _cantidadUnidad; }
            set { _cantidadUnidad = value; }
        }

        public decimal PrecioUnidad
        {
            get { return _precioUnidad; }
            set { _precioUnidad = value; }
        }
    }
}
