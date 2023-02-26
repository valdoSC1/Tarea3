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
            String url = Request.Form["ctl00$MainContent$id"];

            string idContacto = Request.QueryString["idContacto"];
            Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
            StringBuilder infoContacto = new StringBuilder();
            Contacto iContacto = new Contacto();
            ArrayList infoContactos = iContacto.consultarInfoContacto(int.Parse(idContacto));
            ArrayList telefonos = iContacto.ConsultarTelefonos(int.Parse(idContacto));
            ArrayList correos = iContacto.ConsultarCorreos(int.Parse(idContacto));

            foreach (Contacto ctn in infoContactos)
            {
                infoContacto.Append("<h4><b>" + ctn.Nombre + " " + ctn.PrimerApellido + " " + ctn.SegundoApellido + "</b></h4>");
                infoContacto.Append("<h5><b>Teléfono:</b></h5>");

                foreach (Contacto ctnTel in telefonos)
                {
                    infoContacto.Append("<p>" + ctnTel.Telefono + "</p>");
                }

                infoContacto.Append("<h5><b>Correo eléctronico:</b></h5>");

                foreach (Contacto ctnCorreo in correos)
                {
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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
           
        }
    }
}