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
            string input = txtContrasena.Value;

            // Patrones SQL
            if (Regex.IsMatch(input.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(input.ToUpper(), "\'|\""))
            {
                // Mostrar un mensaje de error y limpiar el textbox
                //MessageBox.Show("Entrada no válida, no se permiten caracteres SQL.");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Usuario y/o contraseña incorrectos.');", true);

                txtContrasena.Value = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('¡Bienvenido!');", true);
            }


        }
    }
}