using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP6_Grupo19
{
    public partial class MostrarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["TablaProductos"] != null)
            {
                gvSeleccionados.DataSource = (DataTable)Session["TablaProductos"];
                gvSeleccionados.DataBind();
            }
        }
    }
}