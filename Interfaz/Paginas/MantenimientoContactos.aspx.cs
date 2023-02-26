using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class MantenimientoContactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            string idContacto = Request.QueryString["idContacto"];
            Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
            StringBuilder infoContacto = new StringBuilder();
            StringBuilder infotelefonos = new StringBuilder();
            StringBuilder infoCorreos = new StringBuilder();
            Contacto iContacto = new Contacto();
            ArrayList infoContactos = iContacto.consultarInfoContacto(int.Parse(idContacto));
            ArrayList telefonos = iContacto.ConsultarTelefonos(int.Parse(idContacto));
            ArrayList correos = iContacto.ConsultarCorreos(int.Parse(idContacto));
            
            foreach (Contacto ctn in infoContactos)
            {
                txtNombre.Text = ctn.Nombre;
                txtPrimerApellido.Text = ctn.PrimerApellido;
                txtSegundoApellido.Text = ctn.SegundoApellido;
                txtFacebook.Text = ctn.Facebook;
                txtInstagram.Text = ctn.Instragram;
                txtTwitter.Text = ctn.Twitter;

                infoContacto.Append("<h4><b>" + ctn.Nombre + " " + ctn.PrimerApellido + " " + ctn.SegundoApellido + "</b></h4>");
                infoContacto.Append("<h5><b>Teléfono:</b></h5>");

                infotelefonos.Append("<label>");
                infotelefonos.Append("Teléfono:");
                infotelefonos.Append("<input type = \"image\" src=\"../recursos/simboloMas.png\" alt=\"Agregar\" id=\"btnAgregarTelefono\"><br/>");
                infotelefonos.Append("</label>");

                foreach (Contacto ctnTel in telefonos)
                {
                    infotelefonos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                    infotelefonos.Append("<input type=\"text\" name=\"ctl00$MainContent$Telefono\" maxlength=\"20\" required pattern=\"[+()0 - 9]+\" placeholder=\"85644664\" value='" + ctnTel.Telefono + "'>");
                    infotelefonos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"eliminar(this, 1)\">");
                    infotelefonos.Append("</div>");

                    infoContacto.Append("<p>" + ctnTel.Telefono + "</p>");
                }

                infoContacto.Append("<h5><b>Correo eléctronico:</b></h5>");

                infoCorreos.Append("<label>");
                infoCorreos.Append("Correo eléctronico:");
                infoCorreos.Append("<input type = \"image\" src=\"../recursos/simboloMas.png\" alt=\"Agregar\" id=\"btnAgregarCorreo\"><br/>");
                infoCorreos.Append("</label>");

                foreach (Contacto ctnCorreo in correos)
                {
                    infoCorreos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                    infoCorreos.Append("<input type=\"text\" name=\"ctl00$MainContent$Correo\" maxlength=\"20\" placeholder=\"ejemplo@gmail.com\" value='" + ctnCorreo.Correo + "'>");
                    infoCorreos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"eliminar(this, 2)\">");
                    infoCorreos.Append("</div>");

                    infoContacto.Append("<p>" + ctnCorreo.Correo + "</p>");
                }

                infoContacto.Append("<h5><b>Facebook:</b></h5>");
                infoContacto.Append("<p>" + ctn.Facebook + "</p>");

                infoContacto.Append("<h5><b>Instagram:</b></h5>");
                infoContacto.Append("<p>" + ctn.Instragram + "</p>");

                infoContacto.Append("<h5><b>Twitter:</b></h5>");
                infoContacto.Append("<p>" + ctn.Twitter + "</p>");
            }

            this.infoContacto.InnerHtml = infoContacto.ToString();      
            this.telefonos.InnerHtml = infotelefonos.ToString();
            this.correos.InnerHtml = infoCorreos.ToString();
        }
    }
}