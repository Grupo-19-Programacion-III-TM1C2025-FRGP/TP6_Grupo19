using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP6_Grupo19.Clases;

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

        protected void gvProductos_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            gvProductos.PageIndex = e.NewPageIndex;
            CargarGridViewProductos();
        }
    }
}