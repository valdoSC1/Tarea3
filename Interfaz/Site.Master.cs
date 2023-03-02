using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
namespace Interfaz
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
                Administradores iAdmin = (Administradores)Session["LogueoValidoAdmin"];

                if (iUsuario != null)
                {
                    RegistroContactos.Visible = true;
                    Contactos.Visible = true;
                    lnkCerrarSesion.Visible = true;

                    RegistroUsuarios.Visible = false;
                    LoginAdmin.Visible = false;                    
                }
                else if (iAdmin != null)
                {
                    RegistroUsuarios.Visible = true;
                    LoginAdmin.Visible = false;
                    lnkCerrarSesion.Visible = true;

                    RegistroContactos.Visible = false;
                    Contactos.Visible = false;
                }
                else
                {
                    lnkCerrarSesion.Visible = false;
                    LoginAdmin.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void lnkInicio_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
                Administradores iAdmin = (Administradores)Session["LogueoValidoAdmin"];

                if (iUsuario != null || iAdmin != null)
                {
                    Response.Redirect("~/Default", false);
                }
                else
                {
                    Response.Redirect("~/Paginas/InicioSesion", false);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session["LogueoValido"] = null;
                Session["LogueoValidoAdmin"] = null;
                Session["CredencialesValidas"] = null;
                Session["CredencialesValidasAdmin"] = null;

                Response.Redirect("~/Paginas/InicioSesion", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }
    }
}