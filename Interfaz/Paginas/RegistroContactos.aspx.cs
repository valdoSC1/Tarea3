using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;

namespace Interfaz.Paginas
{    
    public partial class RegistroContactos : System.Web.UI.Page
    {
       private List<string> listaControles
        {
            get
            {
                if (ViewState["controls"] == null)
                {
                    ViewState["controls"] = new List<string>();
                }
                return (List<string>)ViewState["controls"];
            }
       }
        private int siguienteId
        {
            get
            {
                return listaControles.Count + 1; 
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);

            foreach (string txtID in listaControles)
            {               
                TextBox txt = new TextBox();
                txt.ID = txtID;
                plhTelefonos.Controls.Add(txt);               
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int uu = 1;
                Session["txtTelefonoID"] = uu;
            }
            string id = Request.QueryString["id"];            
            if (id != null)
            {
                eliminarTelefono(int.Parse(id));
                refrescarTelefonosAgregados();
            }                       
        }

        protected void imgAgregar_Click(object sender, ImageClickEventArgs e)
        {
            ArrayList telefonos = (ArrayList)Session["telefonosContactos"];
            if (telefonos == null)
            {
                telefonos = new ArrayList();
                agregarTelefono(telefonos, txtTelefono.Text);
            } else
            {
                agregarTelefono(telefonos, txtTelefono.Text);
            }                                                                               
        }

        public void agregarTelefono(ArrayList telefonos, string numeroTelefono)
        {
            try
            {               
                TextBox txtBox = new TextBox();
                txtBox.ID = "txtBox" + siguienteId.ToString();               
                plhTelefonos.Controls.Add(txtBox);

                listaControles.Add(txtBox.ID);

                /*
                int uu = (int)Session["txtTelefonoID"];
                TextBox txtTelefono = new TextBox();
                txtTelefono.ID = txtTelefono + uu.ToString();
                plhTelefonos.Controls.Add(txtTelefono);
                plhTelefonos.Controls.Add(new LiteralControl("<br><br>"));
                uu++;
                
                
                Session["txtTelefonoID"] = uu;
                
                /*
                telefonos.Add(numeroTelefono);
                StringBuilder estructura = new StringBuilder();

                for (int i = 0; i < telefonos.Count; i++)
                {
                    estructura.Append("<tr>");
                    estructura.Append("<td>" + telefonos[i] + "</td>");
                    estructura.Append("<td><a href='RegistroContactos.aspx?id=" + i + "'\">Eliminar</a></td>");
                    estructura.Append("</tr>");
                }

                telefonosAgregados.InnerHtml = estructura.ToString();
                Session["telefonosContactos"] = telefonos;
                */
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }            
        }

        public void eliminarTelefono(int id)
        {
            ArrayList telefonos = (ArrayList)Session["telefonosContactos"];
            telefonos.RemoveAt(id);
            Session["telefonosContactos"] = telefonos;
        }

        public void refrescarTelefonosAgregados()
        {
            ArrayList telefonos = (ArrayList)Session["telefonosContactos"];
            StringBuilder estructura = new StringBuilder();

            for (int i = 0; i < telefonos.Count; i++)
            {
                estructura.Append("<tr>");
                estructura.Append("<td>" + telefonos[i] + "</td>");
                estructura.Append("<td><a href='RegistroContactos.aspx?id=" + i + "'\">Eliminar</a></td>");
                estructura.Append("</tr>");
            }

            //telefonosAgregados.InnerHtml = estructura.ToString();
        }

        protected void imgAgregarCorreo_Click(object sender, ImageClickEventArgs e)
        {          
            TextBox txtBox = new TextBox();
            txtBox.ID = "txtBox" + siguienteId.ToString();
            txtBox.Attributes.Add("placeholder", "896494");
            plhCorreo.Controls.Add(txtBox);           
           
            //listaControles.Add(txtBox.ID);
        }
    }
}