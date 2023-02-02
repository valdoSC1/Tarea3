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
            try
            {
                Usuarios iUsuario = new Usuarios();
                
                ArrayList infoUsuarios = new ArrayList();
                infoUsuarios = iUsuario.BuscaUsuario();

                StringBuilder Usuarios = new StringBuilder();
                foreach (Usuarios user in infoUsuarios)
                {
                    txtNombreM.Text = user.Nombre;
                    txtPApellidoM.Text = user.PrimerApellido;
                    txtSApellidoM.Text = user.SegundoApellido;
                    txtCorreo.Text = user.Correo;
                }
                this.modificar.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                iUsuario.Identificacion = txtIdentificacionEliminar.Text;
                iUsuario.eliminarUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}