using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo19.Clases;
using System.Data.SqlClient;


namespace TP6_Grupo19
{
    public partial class Ejercicio1 : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarGridViewProductos();
            }
        }

        private void CargarGridViewProductos()
        {
            GestionProductos gestionProductos = new GestionProductos();
            gvProductos.DataSource = gestionProductos.ObtenerTodosLosProductos();
            gvProductos.DataBind();
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridViewProductos();
        }

        protected void gvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_it_IdProducto")).Text;
            Producto producto = new Producto(Convert.ToInt32(idProducto));
            GestionProductos gestion = new GestionProductos();
            gestion.EliminarProducto(producto);

            CargarGridViewProductos();
         }

        protected void gvProductos_RowEditing(Object sender, GridViewEditEventArgs e)
        {
            gvProductos.EditIndex = e.NewEditIndex;
            CargarGridViewProductos();
        }

        protected void gvProductos_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
        {
            gvProductos.EditIndex = -1;
            CargarGridViewProductos();
        }

        protected void gvProductos_RowUpdating(Object sender, GridViewUpdateEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.RowIndex].FindControl("lbl_eit_IdProducto")).Text;
            string nombreProducto = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_NombreProducto")).Text;
            string cantidadUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_CantidadUnidad")).Text;
            string precioUnidad = ((TextBox)gvProductos.Rows[e.RowIndex].FindControl("txt_eit_PrecioUnidad")).Text;

           // int idProdcuto, char nombreProducto, char cantidadUnidad, decimal precioUnidad

            Producto producto = new Producto(Convert.ToInt32(idProducto), nombreProducto, cantidadUnidad, Convert.ToDecimal(precioUnidad));
            GestionProductos gestionProductos = new GestionProductos();
            gestionProductos.ActualizarProducto(producto);
            gvProductos.EditIndex = -1;
            CargarGridViewProductos();

        }
    }
}