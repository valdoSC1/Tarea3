﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class Contactos1 : System.Web.UI.Page
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
                    string contactoEliminado = Request.QueryString["estado"];
                    string eliminado = (string)Session["Eliminado"];

                    if (eliminado != null)
                    {
                        Session["Eliminado"] = null;
                        Response.Redirect("~/Paginas/Contactos", false);
                    }

                    Contacto iContacto = new Contacto();
                    ArrayList infoContactos = iContacto.ConsultarContactos(iUsuario.Identificacion);
                    StringBuilder Contactos = new StringBuilder();

                    foreach (Contacto ctn in infoContactos)
                    {
                        Contactos.Append("<div class=\"col-sm-6 col-md-4\">");
                        Contactos.Append("<div class=\"card border-white\" style=\"height: 150px\">");
                        Contactos.Append("<div class=\"card-header\" style='display: grid; place-items: center'>");
                        Contactos.Append("<img src=\"../recursos/avatar.png\" alt=\"Avatar\" style=\"width: 45px; height: 45px\">");
                        Contactos.Append("</div>");
                        Contactos.Append("<div class=\"card-body\" style='display: grid; place-items: center'>");
                        Contactos.Append("<h4><a href='MantenimientoContactos?idContacto=" + ctn.IdContacto + "'><b>" + ctn.Nombre + " " + ctn.PrimerApellido + " " + ctn.SegundoApellido + "</b></a></h4>");
                        Contactos.Append("</div>");
                        Contactos.Append("</div>");
                        Contactos.Append("</div>");
                    }

                    contactosInfo.InnerHtml = Contactos.ToString();

                    if (contactoEliminado != null && eliminado == null)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaEliminar()", true);
                        Session["Eliminado"] = "eliminado";
                    }
                }               
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }
    }
}