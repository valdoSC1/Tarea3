using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
namespace Interfaz
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios iUsuario = (Usuarios)Session["LogueoValido"];
            try
			{
                if (iUsuario != null)
                {
                    RegistroUsuarios.Visible = true;
                    RegistroContactos.Visible = true;
                    Contactos.Visible = true;
                    LoginAdmin.Visible = false;
                }
                else
                {
                    LoginAdmin.Visible = true;
                }
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}