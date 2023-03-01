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
            try
            {
                Contacto iContacto = new Contacto();
                string idContacto = Request.QueryString["idContacto"];
                string opc = Request.Form["ctl00$MainContent$Eliminar"];
                
                if (opc == null || opc == "0")
                {
                    string rawTelefonos = Request.Form["ctl00$MainContent$Telefono"];
                    string rawCorreos = Request.Form["ctl00$MainContent$Correo"];
                    string rawIDTelefonos = Request.Form["ctl00$MainContent$idTelefono"];
                    string rawIDCorreos = Request.Form["ctl00$MainContent$idCorreo"];
                    ArrayList correos;
                    ArrayList telefonos;
                    if (rawTelefonos != null && rawCorreos != null)
                    {
                        if (validarVacios(txtNombre.Text) || validarVacios(txtPrimerApellido.Text) || validarVacios(txtSegundoApellido.Text) || validarVacios(txtFacebook.Text) || validarVacios(txtInstagram.Text) || validarVacios(txtTwitter.Text) || validarCamposDinamicos(rawTelefonos) || validarCamposDinamicos(rawCorreos))
                        {
                            generarCampos(rawTelefonos, rawCorreos, rawIDTelefonos, rawIDCorreos);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "validar", "cambiarClase();", true);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "Alerta('Por favor verifique los datos que desea ingresar, no pueden estar vacíos');", true);                            
                        }
                        else
                        {
                            telefonos = iContacto.ConsultarTelefonos(int.Parse(idContacto));
                            correos = iContacto.ConsultarCorreos(int.Parse(idContacto));
                            modificarContacto(rawTelefonos, rawCorreos, rawIDTelefonos, rawIDCorreos, idContacto, telefonos, correos);

                            telefonos = iContacto.ConsultarTelefonos(int.Parse(idContacto));
                            correos = iContacto.ConsultarCorreos(int.Parse(idContacto));
                            consultarDatosContacto(idContacto, telefonos, correos);
                        }
                    }
                    else
                    {
                        telefonos = iContacto.ConsultarTelefonos(int.Parse(idContacto));
                        correos = iContacto.ConsultarCorreos(int.Parse(idContacto));
                        consultarDatosContacto(idContacto, telefonos, correos);
                    }
                }
                else
                {
                    eliminarContacto(idContacto);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }

        private bool validarVacios(string dato)
        {
            try
            {
                if (dato.Trim().Length == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool validarCamposDinamicos(string datos)
        {
            string[] datosValidar = datos.Split(',');

            foreach (string dato in datosValidar)
            {
                if (dato.Trim().Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void generarCampos(string rawTelefonos, string rawCorreos, string rawIDTelefonos, string rawIDCorreos)
        {
            StringBuilder infotelefonos = new StringBuilder();
            StringBuilder infoCorreos = new StringBuilder();

            infotelefonos.Append("<label>");
            infotelefonos.Append("Teléfono:");
            infotelefonos.Append("<input type = \"image\" src=\"../recursos/simboloMas.png\" alt=\"Agregar\" id=\"btnAgregarTelefono\"><br/>");
            infotelefonos.Append("</label>");

            infoCorreos.Append("<label>");
            infoCorreos.Append("Correo electrónico:");
            infoCorreos.Append("<input type = \"image\" src=\"../recursos/simboloMas.png\" alt=\"Agregar\" id=\"btnAgregarCorreo\"><br/>");
            infoCorreos.Append("</label>");

            if (rawTelefonos != null && rawCorreos != null)
            {
                string[] telefonos = rawTelefonos.Split(',');
                string[] correos = rawCorreos.Split(',');
                string[] idTelefonos = rawIDTelefonos.Split(',');
                string[] idCorreos = rawIDCorreos.Split(',');

                for (int i = 0; i < telefonos.Length; i++)
                {
                    infotelefonos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                    infotelefonos.Append("<input type=\"text\" name=\"ctl00$MainContent$Telefono\" maxlength=\"20\" title=\"Solo se aceptan números telefónicos válidos\" pattern=\"[+()0-9]+\" placeholder=\"85644664\" value='" + telefonos[i] + "'>");
                    infotelefonos.Append("<input type=\"hidden\" name=\"ctl00$MainContent$idTelefono\" value='" + idTelefonos[i] + "'>");
                    infotelefonos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,1);\">");
                    infotelefonos.Append("</div>");
                }

                for (int i = 0; i < correos.Length; i++)
                {
                    infoCorreos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                    infoCorreos.Append("<input type=\"text\" name=\"ctl00$MainContent$Correo\" maxlength=\"60\" title=\"Solo se aceptan correos electrónicos válidos\" pattern='^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})' placeholder=\"ejemplo@gmail.com\" value='" + correos[i] + "'>");
                    infoCorreos.Append("<input type=\"hidden\" name=\"ctl00$MainContent$idCorreo\" value='" + idCorreos[i] + "'>");
                    infoCorreos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,2);\">");
                    infoCorreos.Append("</div>");
                }
            }
            else
            {
                infotelefonos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                infotelefonos.Append("<input type=\"text\" name=\"ctl00$MainContent$Telefono\" maxlength=\"20\" title=\"Solo se aceptan números telefónicos válidos\" pattern=\"[+()0-9]+\" placeholder=\"85644664\" value=''>");
                infotelefonos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,1);\">");
                infotelefonos.Append("</div>");

                infoCorreos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                infoCorreos.Append("<input type=\"text\" name=\"ctl00$MainContent$Correo\" maxlength=\"60\" title=\"Solo se aceptan correos electrónicos válidos\" pattern='^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})' placeholder=\"ejemplo@gmail.com\" value=''>");
                infoCorreos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,2);\">");
                infoCorreos.Append("</div>");
            }
            this.telefonos.InnerHtml = infotelefonos.ToString();
            this.correos.InnerHtml = infoCorreos.ToString();
        }

        private void consultarDatosContacto(string idContacto, ArrayList telefonos, ArrayList correos)
        {
            try
            {
                StringBuilder infoContacto = new StringBuilder();
                StringBuilder infotelefonos = new StringBuilder();
                StringBuilder infoCorreos = new StringBuilder();
                Contacto iContacto = new Contacto();
                ArrayList infoContactos = iContacto.consultarInfoContacto(int.Parse(idContacto));

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
                        infotelefonos.Append("<input type=\"text\" name=\"ctl00$MainContent$Telefono\" maxlength=\"20\" title=\"Solo se aceptan números telefónicos válidos\" pattern=\"[+()0-9]+\" placeholder=\"85644664\" value='" + ctnTel.Telefono + "'>");
                        infotelefonos.Append("<input type=\"hidden\" name=\"ctl00$MainContent$idTelefono\" value='" + ctnTel.IdTelefono + "'>");
                        infotelefonos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,1);\">");
                        infotelefonos.Append("</div>");

                        infoContacto.Append("<p>" + ctnTel.Telefono + "</p>");
                    }

                    infoContacto.Append("<h5><b>Correo electrónico:</b></h5>");

                    infoCorreos.Append("<label>");
                    infoCorreos.Append("Correo electrónico:");
                    infoCorreos.Append("<input type = \"image\" src=\"../recursos/simboloMas.png\" alt=\"Agregar\" id=\"btnAgregarCorreo\"><br/>");
                    infoCorreos.Append("</label>");

                    foreach (Contacto ctnCorreo in correos)
                    {
                        infoCorreos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                        infoCorreos.Append("<input type=\"text\" name=\"ctl00$MainContent$Correo\" maxlength=\"60\" title=\"Solo se aceptan correos electrónicos válidos\" pattern='^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})' placeholder=\"ejemplo@gmail.com\" value='" + ctnCorreo.Correo + "'>");
                        infoCorreos.Append("<input type=\"hidden\" name=\"ctl00$MainContent$idCorreo\" value='" + ctnCorreo.IdCorreo + "'>");
                        infoCorreos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,2);\">");
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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }

        private void modificarContacto(string rawTelefonos, string rawCorreos, string rawIDTelefonos, string rawIDCorreos, string idContacto, ArrayList listaOriginalTelefonos, ArrayList listaOriginalCorreos)
        {
            try
            {
                Contacto iContacto = new Contacto
                {
                    IdContacto = idContacto,
                    Nombre = txtNombre.Text,
                    PrimerApellido = txtPrimerApellido.Text,
                    SegundoApellido = txtSegundoApellido.Text,
                    Facebook = txtFacebook.Text,
                    Instragram = txtInstagram.Text,
                    Twitter = txtTwitter.Text
                };

                iContacto.modificarContactos();

                string[] telefonos = rawTelefonos.Split(',');
                string[] correos = rawCorreos.Split(',');
                string[] idTelefonos = rawIDTelefonos.Split(',');
                string[] idCorreos = rawIDCorreos.Split(',');
                if (telefonos.Length != listaOriginalTelefonos.Count)
                {
                    for (int i = 0; i < idTelefonos.Length; i++)
                    {
                        if (int.Parse(idTelefonos[i]) > 0)
                        {
                            iContacto.MantenimientoTelefonos(0, int.Parse(idTelefonos[i]), telefonos[i]);
                        }
                        else
                        {
                            iContacto.registrarTelefonos(int.Parse(idContacto), telefonos[i]);
                        }
                    }

                    foreach (Contacto ctnTel in listaOriginalTelefonos)
                    {
                        if (!idTelefonos.Contains(ctnTel.IdTelefono))
                        {
                            iContacto.MantenimientoTelefonos(1, int.Parse(ctnTel.IdTelefono));
                        }
                    }
                }
                else
                {
                    actualizarTelefonos(telefonos, listaOriginalTelefonos);
                }

                if (correos.Length != listaOriginalCorreos.Count)
                {
                    for (int i = 0; i < idCorreos.Length; i++)
                    {
                        if (int.Parse(idCorreos[i]) > 0)
                        {
                            iContacto.MantenimientoCorreos(0, int.Parse(idCorreos[i]), correos[i]);
                        }
                        else
                        {
                            iContacto.registrarCorreos(int.Parse(idContacto), correos[i]);
                        }
                    }

                    foreach (Contacto ctnCorreo in listaOriginalCorreos)
                    {
                        if (!idCorreos.Contains(ctnCorreo.IdCorreo))
                        {
                            iContacto.MantenimientoCorreos(1, int.Parse(ctnCorreo.IdCorreo));
                        }
                    }
                }
                else
                {
                    actualizarCorreos(correos, listaOriginalCorreos);
                }

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaModificar()", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }

        private void actualizarTelefonos(string[] telefonos, ArrayList listaOriginalTelefonos)
        {
            try
            {
                Contacto iContacto = new Contacto();
                int i = 0;
                foreach (Contacto ctnTel in listaOriginalTelefonos)
                {
                    iContacto.MantenimientoTelefonos(0, int.Parse(ctnTel.IdTelefono), telefonos[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }

        private void actualizarCorreos(string[] correos, ArrayList listaOriginalCorreos)
        {
            try
            {
                Contacto iContacto = new Contacto();
                int i = 0;
                foreach (Contacto ctnCorreo in listaOriginalCorreos)
                {
                    iContacto.MantenimientoCorreos(0, int.Parse(ctnCorreo.IdCorreo), correos[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }

        private void eliminarContacto(string idContacto)
        {
            try
            {
                Contacto iContacto = new Contacto();
                iContacto.IdContacto = idContacto;
                iContacto.eliminarContactos();

                Response.Redirect("~/Paginas/Contactos?estado=0", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
            }
        }
    }
}