using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class Authenticator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = (Usuarios)Session["CredencialesValidas"];
                Administradores iAdmin = (Administradores)Session["CredencialesValidasAdmin"];

                Usuarios iUsuarioValidado = (Usuarios)Session["LogueoValido"];
                Administradores iAdminValidado = (Administradores)Session["LogueoValidoAdmin"];

                if (iUsuario == null && iAdmin == null)
                {
                    Response.Redirect("~/Paginas/InicioSesion", false);
                }
                else if (iUsuarioValidado != null || iAdminValidado != null)
                {
                    Response.Redirect("~/Default", false);
                }
                else
                {
                    string codigoGenerado = (string)Session["codigo"];
                    string intentos = (string)Session["intentos"];

                    if ((iUsuarioValidado == null || iAdminValidado == null) && codigoGenerado == null && intentos == null)
                    {
                        string correo = "";
                        string codigo = generarCodigo();
                        if (iUsuario != null)
                        {
                            correo = iUsuario.Correo;
                            this.correo.InnerHtml = "<p>" + correo + "</p>";
                        }
                        else if (iAdmin != null)
                        {
                            correo = iAdmin.Correo;
                            this.correo.InnerHtml = "<p>" + correo + "</p>";
                        }
                        enviarCorreo(correo, codigo);
                        Session["codigo"] = codigo;
                        Session["intentos"] = "3";
                    }

                    if (Page.IsPostBack)
                    {
                        int intentosNum = int.Parse(intentos);
                        intentosNum = validarCodigo(codigoGenerado, intentosNum);
                        if (intentosNum != -2)
                        {
                            if (intentosNum < 1)
                            {
                                string correo = "";
                                string codigo = generarCodigo();
                                if (iUsuario != null)
                                {
                                    correo = iUsuario.Correo;
                                    this.correo.InnerHtml = "<p>" + correo + "</p>";
                                }
                                else if (iAdmin != null)
                                {
                                    correo = iAdmin.Correo;
                                    this.correo.InnerHtml = "<p>" + correo + "</p>";
                                }
                                enviarCorreo(correo, codigo);
                                Session["codigo"] = codigo;
                                Session["intentos"] = "3";
                                txtCodigo.Value = "";

                                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaOtroCorreo()", true);
                            }
                            else if (intentosNum != -2)
                            {
                                string mensaje = "El código es incorrecto. Inténtalo de nuevo, te queda(n) " + intentosNum.ToString() + " intento(s)";
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaCodigo('{mensaje}')", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        private string generarCodigo()
        {
            try
            {
                string codigo = "";

                Random random = new Random();
                string numeros = "0123456789";

                int index;
                for (int i = 0; i < 6; i++)
                {
                    index = random.Next(numeros.Length);
                    codigo += numeros.Substring(index, 1);
                }

                return codigo;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return "";
            }
        }

        private void enviarCorreo(string correo, string codigo)
        {
            try
            {
                string asuntoCorreo = "Tu código de inicio de sesión de dos factores";
                string cuerpoCorreo = "<h1 style=\"text-align:center; color: rgb(0,0,0)\">Tu código de inicio de sesión de dos <br> factores: <br>" + codigo + "</h1>";

                SmtpClient smtp = new SmtpClient()
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential()
                    {
                        UserName = "amongera31@gmail.com",
                        Password = "juxowtdupxsqnudu"
                    }
                };

                MailAddress from = new MailAddress("amongera31@gmail.com");
                MailMessage mensaje = new MailMessage()
                {
                    From = from,
                    Subject = asuntoCorreo,
                    IsBodyHtml = true,
                    Body = cuerpoCorreo,
                };

                mensaje.To.Add(correo);
                smtp.Send(mensaje);                
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        private int validarCodigo(string codigo, int intentos)
        {
            try
            {                
                if (txtCodigo.Value.Trim() == codigo)
                {
                    Usuarios iUsuario = (Usuarios)Session["CredencialesValidas"];
                    Administradores iAdmin = (Administradores)Session["CredencialesValidasAdmin"];

                    if (iUsuario != null)
                    {
                        Session["LogueoValido"] = iUsuario;
                    }
                    else if (iAdmin != null)
                    {
                        Session["LogueoValidoAdmin"] = iAdmin;
                    }
                    Session["codigo"] = null;
                    Session["intentos"] = null;
                    Response.Redirect("~/Default", false);
                    return -2;
                }
                else
                {
                    intentos--;
                    Session["intentos"] = intentos.ToString();                    
                    return intentos;
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return -1;
            }
        }
    }
}