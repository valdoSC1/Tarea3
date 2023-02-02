using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Interfaz.Paginas
{
    public partial class RegistroContactos : System.Web.UI.Page
    {
        ArrayList telefonos = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            LiteralControl textBox = new LiteralControl();
            textBox.Text = "<asp:TextBox runat='server' ID='txtDynamic' />";
            phTelefonos.Controls.Add(textBox);
        }
    }
}