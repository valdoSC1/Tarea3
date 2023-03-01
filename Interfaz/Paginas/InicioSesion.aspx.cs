using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.FriendlyUrls;
using Negocios;
using System;
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
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string contrasena = txtContrasena.Value;
                string usuario = txtUsuario.Value;
                Usuarios iUsuarios = new Usuarios();
                
                // Patrones SQL
                if (Regex.IsMatch(contrasena.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(contrasena.ToUpper(), "\'|\""))
                {
                    // Mostrar un mensaje de error y limpiar el textbox
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Usuario y/o contraseña incorrectos.');", true);

                    txtContrasena.Value = "";
                }
                else if (contrasena.Trim().Length == 0 || usuario.Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Usuario y/o contraseña no pueden estar vacíos.');", true);
                }
                else
                {
                    iUsuarios.Identificacion = txtUsuario.Value;
                    iUsuarios.Contrasena = txtContrasena.Value;
                    iUsuarios.InicioSesion();
                    if (iUsuarios.CredencialValida == true)
                    {
                        Session["LogueoValido"] = iUsuarios;
                        Response.Redirect("~/Default", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Usuario y/o contraseña incorrectos.');", true);
                        Session["LogueoValido"] = null;
                    }
                }    
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }
    }
}