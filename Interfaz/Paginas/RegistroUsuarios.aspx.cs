using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = new Usuarios();
                iUsuario.Identificacion = txtId.Text;
                iUsuario.Nombre = txtNombre.Text;
                iUsuario.PrimerApellido = txtPApellido.Text;
                iUsuario.SegundoApellido = txtSApellido.Text;
                iUsuario.Contrasena = txtContrasena.Text;
                iUsuario.Correo = txtEmail.Text;
                iUsuario.Estado = Int32.Parse(ddlEstado.SelectedValue);
                iUsuario.registrarUsuarios();
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void btnBuscarM_Click(object sender, EventArgs e)
        {

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = new Usuarios();
                iUsuario.Identificacion = txtIdM.Text;
                iUsuario.Nombre = txtNombreM.Text;
                iUsuario.PrimerApellido = txtPApellidoM.Text;
                iUsuario.SegundoApellido = txtSApellidoM.Text;
                iUsuario.modificarUsuarios();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnCambiarContra_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = new Usuarios();
                iUsuario.Identificacion = txtIdC.Text;
                iUsuario.Contrasena = txtContrasenaModificar.Text;
                iUsuario.cambiarContrasenaUsuario();
            }
            catch (Exception)
            {
                throw;
            }
            

        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = new Usuarios();
                iUsuario.Identificacion = txtIdE.Text;
                iUsuario.Estado = Int32.Parse(dllCambioEstado.SelectedValue);
                iUsuario.cambiarEstadoUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios iUsuario = new Usuarios();
                iUsuario.Identificacion = txtIdE.Text;
                iUsuario.cambiarEstadoUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}