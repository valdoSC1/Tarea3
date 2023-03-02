using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Interfaz
{
    public partial class _Default : Page
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
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);                
            }          
        }
    }
}