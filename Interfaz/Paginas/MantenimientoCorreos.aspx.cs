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
    public partial class MantenimientoCorreos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string idCorreo = Request.QueryString["idCorreo"];
            string opc = Request.QueryString["accion"];

            if (int.Parse(opc) == 0)
            {
                lblTitulo.Text = "Modificar";
                btnAccion.Text = "Modificar";
            }
            else
            {
                lblTitulo.Text = "Eliminar";
                btnAccion.Text = "Eliminar";
            }

            ViewState["Accion"] = opc;
            ViewState["ID"] = idCorreo;
        }

        protected void btnAccion_Click(object sender, EventArgs e)
        {
            string opc = (String)ViewState["Accion"];
            string id = (String)ViewState["ID"];
            Contacto iContacto = new Contacto();

            if (int.Parse(opc) == 0)
            {
                iContacto.MantenimientoCorreos(int.Parse(opc), int.Parse(id), txtCorreo.Text);
            }
            else
            {
                iContacto.MantenimientoCorreos(int.Parse(opc), int.Parse(id));
            }
            txtCorreo.Text = "";
        }
    }
}