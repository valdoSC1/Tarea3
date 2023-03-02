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
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);

                    txtContrasena.Value = "";
                }
                else if (contrasena.Trim().Length == 0 || usuario.Trim().Length == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "CredencialesVacias()", true);
                }
                else
                {
                    iUsuarios.Identificacion = txtUsuario.Value;
                    iUsuarios.Contrasena = txtContrasena.Value;
                    ArrayList objetoUsuario = iUsuarios.InicioSesion();
                    if (objetoUsuario.Count > 0)
                    {
                        foreach(Usuarios user in objetoUsuario)
                        {
                            Session["CredencialesValidas"] = user;
                            Response.Redirect("~/Paginas/Authenticator", false);
                        }                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "Credenciales()", true);
                        Session["CredencialesValidas"] = null;
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