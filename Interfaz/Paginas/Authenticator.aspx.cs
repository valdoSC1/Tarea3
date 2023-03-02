﻿using System;
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
                if ((iUsuarioValidado == null || iAdminValidado == null) && codigoGenerado == null)
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
                }
            }
        }

        private string generarCodigo()
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

        private void enviarCorreo(string correo, string codigo)
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

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigo = (string)Session["codigo"];
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
                Response.Redirect("~/Default", false);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaCodigo()", true);
            }
        }
    }
}