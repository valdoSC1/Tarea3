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
    public partial class Contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios iUsuario = (Usuarios)Session["LogueoValido"];            
            Contacto iContacto = new Contacto();

            ArrayList infoContactos = new ArrayList();
            infoContactos = iContacto.ConsultarContactos(iUsuario.Identificacion);

            StringBuilder Contactos = new StringBuilder();            
            foreach (Contacto ctn in infoContactos)
            {
                Contactos.Append("<div class=\"col-md-4\" style=\"background-color:bisque;margin:20px;width:280px\">");
                Contactos.Append("<div class=\"card\">");
                Contactos.Append("<p>Nombre: " + ctn.Nombre + "</p>");
                Contactos.Append("<p>Primer apellido: " + ctn.PrimerApellido + "</p>");
                Contactos.Append("<p>Segundo apellido: " + ctn.SegundoApellido + "</p>");
                Contactos.Append("<a class=\"editar\" href='MantenimientoContactos?idContacto=" + ctn.IdContacto + "'>Ver información</a>");
                Contactos.Append("</div>");
                Contactos.Append("</div>");
            }

            contactosInfo.InnerHtml = Contactos.ToString();
        }
    }
}