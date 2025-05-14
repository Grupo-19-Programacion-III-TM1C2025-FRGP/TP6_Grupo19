using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo19.Clases;
using System.Data.SqlClient;

namespace TP6_Grupo19
{
    public partial class SeleccionarP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGridViewProductos();
            }
        }

        private void CargarGridViewProductos()
        {
            GestionProductos gestionProductos = new GestionProductos();
            gvProductos.DataSource = gestionProductos.ObtenerTodosLosProductosEjercicio2();
            gvProductos.DataBind();
        }

        protected void gvProductos_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridViewProductos();
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string idProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProducto")).Text;
            string nombreProducto = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_NombreProducto")).Text;
            string idProveedor = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_IdProveedor")).Text;
            string precioUnidad = ((Label)gvProductos.Rows[e.NewSelectedIndex].FindControl("lbl_it_PrecioUnidad")).Text;
            
            dynamic itemSeleccionado = new { idProducto, nombreProducto, idProveedor, precioUnidad };

            ActualizarDTSession(itemSeleccionado);

            ProductoSeleccionado.Text = "Producto agregado: " + nombreProducto;
        }


        private void ActualizarDTSession(dynamic obj)
        {

            if (Session["TablaProductos"] == null)
            {
                Session["TablaProductos"] = CrearDataTable();
            }

            AgregarFilaDT((DataTable)Session["TablaProductos"], obj);

        }

        private DataTable CrearDataTable()
        {
            DataTable dt = new DataTable();

            DataColumn dataColumn = new DataColumn("IdProducto", System.Type.GetType("System.Int32"));
            dt.Columns.Add(dataColumn);

            dataColumn = new DataColumn("NombreProducto", System.Type.GetType("System.String"));
            dt.Columns.Add(dataColumn);

            dataColumn = new DataColumn("IdProveedor", System.Type.GetType("System.String"));
            dt.Columns.Add(dataColumn);

            dataColumn = new DataColumn("PrecioUnidad", System.Type.GetType("System.Decimal"));
            dt.Columns.Add(dataColumn);


            return dt;
        }

        private DataTable AgregarFilaDT(DataTable dt, dynamic nuevoProducto)
        {
            DataRow dr = dt.NewRow();

            foreach (var propiedad in nuevoProducto.GetType().GetProperties())
            {
                dr[$"{propiedad.Name}"] = propiedad.GetValue(nuevoProducto, null);
            }

            dt.Rows.Add(dr);

            return dt;
        }
    }
}