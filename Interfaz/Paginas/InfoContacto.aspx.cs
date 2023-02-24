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
    public partial class InfoContacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idContacto = Request.QueryString["idContacto"];           
            Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
            Contacto iContacto = new Contacto();
            ArrayList infoContactos = new ArrayList();
            infoContactos = iContacto.ConsultarContactos(iUsuario.Identificacion);

            foreach (Contacto ctn in infoContactos)
            {
                txtNombre.Text = ctn.Nombre;
                txtPrimerApellido.Text = ctn.PrimerApellido;
                txtSegundoApellido.Text = ctn.SegundoApellido;
                txtFacebook.Text = ctn.Facebook;
                txtInstagram.Text = ctn.Instragram;
                txtTwitter.Text = ctn.Twitter;
            }
                       
            StringBuilder infoTelefonos = new StringBuilder();

            ArrayList telefonos = new ArrayList();
            telefonos = iContacto.ConsultarTelefonos(int.Parse(idContacto));

            foreach (Contacto ctn in telefonos)
            {
                infoTelefonos.Append("<tr>");
                infoTelefonos.Append("<td>" + ctn.Telefono + "</td>");
                infoTelefonos.Append("<td><a href='MantenimientoTelefono.aspx?accion=0&idTel=" + ctn.IdTelefono + "' Class='btn btn-success'>Modificar</a></td>");
                infoTelefonos.Append("<td><a href='MantenimientoTelefono.aspx?accion=1&idTel=" + ctn.IdTelefono + "' Class='btn btn-success'>Eliminar</a></td>");
                infoTelefonos.Append("</tr>");
            }
            lstTelefonos.InnerHtml = infoTelefonos.ToString();

            StringBuilder infoCorreos = new StringBuilder();
            ArrayList correos = new ArrayList();
            correos = iContacto.ConsultarCorreos(int.Parse(idContacto));
            foreach (Contacto ctn in correos)
            {
                infoCorreos.Append("<tr>");
                infoCorreos.Append("<td>" + ctn.Correo + "</td>");
                infoCorreos.Append("<td><a href='MantenimientoCorreos.aspx?accion=0&idCorreo=" + ctn.IdCorreo + "' Class='btn btn-success'>Modificar</a></td>");
                infoCorreos.Append("<td><a href='MantenimientoCorreos.aspx?accion=1&idCorreo=" + ctn.IdCorreo + "' Class='btn btn-success'>Eliminar</a></td>");
                infoCorreos.Append("</tr>");
            }
            lstCorreos.InnerHtml = infoCorreos.ToString();
        }
    }
}