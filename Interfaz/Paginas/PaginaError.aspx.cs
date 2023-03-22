using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class PaginaError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Exception ex = (Exception)Session["Error"];
                this.lblMensaje.Text = ex.Message;
                this.lblErrorTecnico.Text = ex.StackTrace;
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.lblErrorTecnico.Text = ex.StackTrace;
            }
        }
    }
}