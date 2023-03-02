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
                Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
                Administradores iAdmin = (Administradores)Session["LogueoValidoAdmin"];

                if (iUsuario == null && iAdmin == null)
                {
                    Response.Redirect("~/Paginas/InicioSesion", false);
                }
                else
                {
                    Exception ex = (Exception)Session["Error"];
                    this.lblMensaje.Text = ex.Message;
                    this.lblErrorTecnico.Text = ex.StackTrace;
                }
            }
            catch (Exception ex)
            {
                this.lblMensaje.Text = ex.Message;
                this.lblErrorTecnico.Text = ex.StackTrace;
            }
        }
    }
}