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
                    Home.Visible = true;
                    About.Visible = true;
                    Contact.Visible = true;
                    Contactos.Visible = true;
                }
                else
                {

                }
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}