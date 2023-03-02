using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.FriendlyUrls;
using Negocios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interfaz.Paginas
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    Session["codigo"] = null;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string contrasena = txtContrasena.Value;
                string usuario = txtUsuario.Value;
                Administradores iAdmin = new Administradores();

                // Patrones SQL
                if (Regex.IsMatch(contrasena.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(contrasena.ToUpper(), "\'|\""))
                {                    
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);

                    txtContrasena.Value = "";
                }
                else if (contrasena.Trim().Length == 0 || usuario.Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "CredencialesVacias()", true);
                }
                else
                {
                    iAdmin.CodigoUsuario = txtUsuario.Value;
                    iAdmin.Contrasena = txtContrasena.Value;
                    ArrayList objetoAdmin = iAdmin.InicioSesion();
                    if (objetoAdmin.Count > 0)
                    {
                        foreach (Administradores admin in objetoAdmin)
                        {
                            Session["CredencialesValidasAdmin"] = admin;
                            Response.Redirect("~/Paginas/Authenticator", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "Credenciales()", true);
                        Session["CredencialesValidasAdmin"] = null;
                    }
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