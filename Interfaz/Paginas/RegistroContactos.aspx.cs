using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class RegistroContactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
                Administradores iAdmin = (Administradores)Session["LogueoValidoAdmin"];

                if (iUsuario == null && iAdmin == null)
                {
                    Session["codigo"] = null;
                    Response.Redirect("~/Paginas/InicioSesion", false);
                }
                else if (iAdmin != null)
                {
                    Response.Redirect("~/Default", false);
                }
                else
                {
                    string telefonos = Request.Form["ctl00$MainContent$Telefono"];
                    string correos = Request.Form["ctl00$MainContent$Correo"];

                    if (telefonos != null && correos != null)
                    {
                        if (validarVacios(txtNombre.Text) || validarVacios(txtPrimerApellido.Text) || validarVacios(txtSegundoApellido.Text) || validarVacios(txtFacebook.Text) || validarVacios(txtInstagram.Text) || validarVacios(txtTwitter.Text) || validarCamposDinamicos(telefonos) || validarCamposDinamicos(correos))
                        {
                            generarCampos(telefonos, correos);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "Alerta('Por favor verifique los datos que desea ingresar, no pueden estar vacíos')", true);
                        }
                        else if (validar(txtNombre.Text) || validar(txtPrimerApellido.Text) || validar(txtSegundoApellido.Text) || validar(txtFacebook.Text) || validar(txtInstagram.Text) || validar(txtTwitter.Text) || validarSQL(telefonos) || validarSQL(correos))
                        {
                            generarCampos(telefonos, correos);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "Alerta('Por favor verifique los datos que desea ingresar');", true);
                        }
                        else
                        {
                            registrarContacto(telefonos, correos);
                            generarCampos(null, null);
                        }
                    }
                    else
                    {
                        generarCampos(telefonos, correos);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        private bool validar(string dato)
        {
            try
            {
                if (Regex.IsMatch(dato.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(dato.ToUpper(), "\'|\""))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return false;
            }
        }

        private bool validarSQL(string datos)
        {
            try
            {
                string[] datosValidar = datos.Split(',');

                foreach (string dato in datosValidar)
                {
                    if (Regex.IsMatch(dato.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(dato.ToUpper(), "\'|\""))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return false;
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
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return false;
            }
        }

        private bool validarCamposDinamicos(string datos)
        {
            try
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
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return false;
            }
        }

        private void registrarContacto(string telefonos, string correos)
        {
            try
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

                string[] telefono = telefonos.Split(',');
                string[] correo = correos.Split(',');

                foreach (string t in telefono)
                {
                    iContacto.registrarTelefonos(idContacto, t);
                }

                foreach (string c in correo)
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
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        private void generarCampos(string rawTelefonos, string rawCorreos)
        {
            try
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

                    foreach (string tel in telefonos)
                    {
                        infotelefonos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                        infotelefonos.Append("<input type=\"text\" name=\"ctl00$MainContent$Telefono\" maxlength=\"20\" title=\"Solo se aceptan números telefónicos válidos\" pattern=\"[+()0-9]+\" placeholder=\"85644664\" value='" + tel + "'>");
                        infotelefonos.Append("<input type=\"image\" src=\"../recursos/borrar.png\" alt=\"Eliminar\" onclick=\"return eliminar(this,1);\">");
                        infotelefonos.Append("</div>");
                    }

                    foreach (string correo in correos)
                    {
                        infoCorreos.Append("<div style='display:inline-flex;align-items:center;justify-content:center;width:307px'>");
                        infoCorreos.Append("<input type=\"text\" name=\"ctl00$MainContent$Correo\" maxlength=\"60\" title=\"Solo se aceptan correos electrónicos válidos\" pattern='^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})' placeholder=\"ejemplo@gmail.com\" value='" + correo + "'>");
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
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);                
            }
        }
    }
}