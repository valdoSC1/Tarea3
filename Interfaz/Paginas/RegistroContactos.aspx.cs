using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class RegistroContactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String telefonos = Request.Form["ctl00$MainContent$Telefono"];
            String correos = Request.Form["ctl00$MainContent$Correo"];

            if (telefonos != null && correos != null)
            {
                registrarContacto(telefonos, correos);
            }
        }

        private void registrarContacto(String telefonos, String correos)
        {
            Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
            Contacto iContacto = new Contacto
            {
                Nombre = txtNombre.Text,
                PrimerApellido = txtPrimerApellido.Text,
                SegundoApellido = txtSegundoApellido.Text,
                Facebook = txtFacebook.Text,
                Instragram = txtInstagram.Text,
                Twitter = txtTwitter.Text
            };
            iContacto.registrarContactos(iUsuario.Identificacion);
            ArrayList infoIdContacto = iContacto.consultarUltimoContacto();
            int idContacto = (int)infoIdContacto[0];

            String[] telefono = telefonos.Split(',');
            String[] correo = correos.Split(',');

            foreach (String t in telefono)
            {
                iContacto.registrarTelefonos(idContacto, t);
            }

            foreach (String c in correo)
            {
                iContacto.registrarCorreos(idContacto, c);
            }

            txtNombre.Text = "";
            txtPrimerApellido.Text = "";
            txtSegundoApellido.Text = "";
            txtFacebook.Text = "";
            txtInstagram.Text = "";
            txtTwitter.Text = "";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaRegistro()", true);
        }
    }
}