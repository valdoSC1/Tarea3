using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public bool validar(string dato)
        {
            if (Regex.IsMatch(dato.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(dato.ToUpper(), "\'|\""))
            {
                return true;
            }
            return false;
        }

        public bool validarVacios(string dato)
        {
            if (dato.Trim().Length==0)
            {
                return true;
            }
            return false ;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {                            
                if (validar(txtId.Text) || validar(txtNombre.Text) || validar(txtPApellido.Text) || validar(txtSApellido.Text) || validar(txtContrasena.Text) || validar(txtEmail.Text))
                {
                    // Mostrar un mensaje de error y limpiar el textbox
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar.');", true);
                } else if(validarVacios(txtId.Text) || validarVacios(txtNombre.Text) || validarVacios(txtPApellido.Text) || validarVacios(txtSApellido.Text) || validarVacios(txtContrasena.Text) || validarVacios(txtEmail.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar, no pueden estar vacíos.');", true);
                }
                else
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
                
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "Alerta()", true);
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
                iUsuario.Identificacion = txtIdM.Text;
                ArrayList infoUsuarios = new ArrayList();
                infoUsuarios = iUsuario.BuscaUsuario();
               
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
                if (validar(txtIdM.Text) || validar(txtNombreM.Text) || validar(txtPApellidoM.Text) || validar(txtSApellidoM.Text))
                {
                    // Mostrar un mensaje de error y limpiar el textbox
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar.');", true);
                }
                else if (validarVacios(txtIdM.Text) || validarVacios(txtNombreM.Text) || validarVacios(txtPApellidoM.Text) || validarVacios(txtSApellidoM.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar, no pueden estar vacíos.');", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdM.Text;
                    iUsuario.Nombre = txtNombreM.Text;
                    iUsuario.PrimerApellido = txtPApellidoM.Text;
                    iUsuario.SegundoApellido = txtSApellidoM.Text;
                    iUsuario.Correo = txtCorreo.Text;
                    iUsuario.modificarUsuarios();

                    txtIdM.Text = "";
                    txtNombreM.Text = "";
                    txtPApellidoM.Text = "";
                    txtSApellidoM.Text = "";
                    txtCorreo.Text = "";

                    this.modificar.Visible = false;

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaModificar()", true);                    
                }
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

                if (validar(txtIdC.Text) || validar(txtContrasenaModificar.Text))
                {
                    // Mostrar un mensaje de error y limpiar el textbox
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar.');", true);
                }
                else if (validarVacios(txtIdC.Text) || validarVacios(txtContrasenaModificar.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar, no pueden estar vacíos.');", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdC.Text;
                    iUsuario.Contrasena = txtContrasenaModificar.Text;
                    iUsuario.cambiarContrasenaUsuario();
                }
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
                if (validar(txtIdE.Text))
                {
                    // Mostrar un mensaje de error y limpiar el textbox
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar.');", true);
                }
                else if (validarVacios(txtIdE.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar, no pueden estar vacíos.');", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdE.Text;
                    iUsuario.Estado = Int32.Parse(dllCambioEstado.SelectedValue);
                    iUsuario.cambiarEstadoUsuarios();

                }
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
                if (validar(txtIdentificacionEliminar.Text))
                {
                    // Mostrar un mensaje de error y limpiar el textbox
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar.');", true);
                }
                else if (validarVacios(txtIdentificacionEliminar.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", "javascript:alert('Por favor verifique los datos que desea ingresar, no pueden estar vacíos.');", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdentificacionEliminar.Text;
                    iUsuario.eliminarUsuarios();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", $"javascript:alert('{ex.Message}');", true);
            }
        }

        protected void txtGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                txtContrasena.Text = GeneraPalabra();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GeneraPalabra()
        {
            Random random = new Random();
            string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string numeros = "0123456789";
            string especiales = "!@#$%";
            string Generado = "";
            int index;
            for (int i = 0; i < 6; i++)
            {
                index = random.Next(abecedario.Length);
                Generado = Generado + abecedario.Substring(index, 1);
            }
            index = random.Next(numeros.Length);
            Generado = Generado + numeros.Substring(index, 1);
            index = random.Next(especiales.Length);
            Generado = Generado + especiales.Substring(index, 1);
            return Generado;
        }
    }
}