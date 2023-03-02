using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Negocios;

namespace Interfaz.Paginas
{
    public partial class WebForm1 : System.Web.UI.Page
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
                else if (iUsuario != null)
                {
                    Response.Redirect("~/Default", false);
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        public bool validar(string dato)
        {
            try
            {
                if (Regex.IsMatch(dato.ToUpper(), @"\b(SELECT|FROM|WHERE|DELETE|UPDATE|INSERT|;|OR)\b") || Regex.IsMatch(dato.ToUpper(), "\'|\""))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return false;
            }
        }

        public bool validarVacios(string dato)
        {
            try
            {
                if (dato.Trim().Length == 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return false;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar(txtId.Text) || validar(txtNombre.Text) || validar(txtPApellido.Text) || validar(txtSApellido.Text) || validar(txtContrasena.Text) || validar(txtEmail.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);
                }
                else if (validarVacios(txtId.Text) || validarVacios(txtNombre.Text) || validarVacios(txtPApellido.Text) || validarVacios(txtSApellido.Text) || validarVacios(txtContrasena.Text) || validarVacios(txtEmail.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaVacios()", true);
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

                    txtId.Text = "";
                    txtNombre.Text = "";
                    txtPApellido.Text = "";
                    txtSApellido.Text = "";
                    txtContrasena.Text = "";
                    txtEmail.Text = "";
                    ddlEstado.SelectedValue = "1";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaRegistro()", true);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == null)
                {
                    Session["Error"] = ex;
                    Response.Redirect("~/Paginas/PaginaError", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
                }                
            }
        }

        protected void btnBuscarM_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarVacios(txtIdM.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaVacios()", true);
                }
                else if (validar(txtIdM.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdM.Text;
                    ArrayList infoUsuarios = new ArrayList();
                    infoUsuarios = iUsuario.BuscaUsuario();

                    if (infoUsuarios.Count > 0)
                    {
                        foreach (Usuarios user in infoUsuarios)
                        {
                            txtNombreM.Text = user.Nombre;
                            txtPApellidoM.Text = user.PrimerApellido;
                            txtSApellidoM.Text = user.SegundoApellido;
                            txtCorreo.Text = user.Correo;
                        }
                        this.modificar.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaNoEncontrado('No se encontró el usuario')", true);
                        txtNombreM.Text = "";
                        txtPApellidoM.Text = "";
                        txtSApellidoM.Text = "";
                        txtCorreo.Text = "";
                        this.modificar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar(txtIdM.Text) || validar(txtNombreM.Text) || validar(txtPApellidoM.Text) || validar(txtSApellidoM.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);
                }
                else if (validarVacios(txtIdM.Text) || validarVacios(txtNombreM.Text) || validarVacios(txtPApellidoM.Text) || validarVacios(txtSApellidoM.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaVacios()", true);
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
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        protected void btnCambiarContra_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar(txtIdC.Text) || validar(txtContrasenaModificar.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);
                }
                else if (validarVacios(txtIdC.Text) || validarVacios(txtContrasenaModificar.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaVacios()", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdC.Text;
                    iUsuario.Contrasena = txtContrasenaModificar.Text;

                    ArrayList infoUsuarios = iUsuario.BuscaUsuario();
                    if (infoUsuarios.Count > 0)
                    {
                        iUsuario.cambiarContrasenaUsuario();

                        txtIdC.Text = "";
                        txtContrasenaModificar.Text = "";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaContrasena()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaNoEncontrado('No se encontró el usuario')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar(txtIdE.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);
                }
                else if (validarVacios(txtIdE.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaVacios()", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdE.Text;

                    ArrayList infoUsuarios = iUsuario.BuscaUsuario();
                    if (infoUsuarios.Count > 0)
                    {
                        iUsuario.Estado = Int32.Parse(dllCambioEstado.SelectedValue);
                        iUsuario.cambiarEstadoUsuarios();

                        txtIdE.Text = "";
                        dllCambioEstado.SelectedValue = "1";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaEstado()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaNoEncontrado('No se encontró el usuario')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validar(txtIdentificacionEliminar.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaValidar()", true);
                }
                else if (validarVacios(txtIdentificacionEliminar.Text))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaVacios()", true);
                }
                else
                {
                    Usuarios iUsuario = new Usuarios();
                    iUsuario.Identificacion = txtIdentificacionEliminar.Text;

                    ArrayList infoUsuarios = iUsuario.BuscaUsuario();
                    if (infoUsuarios.Count > 0)
                    {
                        iUsuario.eliminarUsuarios();

                        txtIdentificacionEliminar.Text = "";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaEliminar()", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", "AlertaNoEncontrado('No se encontró el usuario')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == null)
                {
                    Session["Error"] = ex;
                    Response.Redirect("~/Paginas/PaginaError", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toast", $"AlertaError('{ex.InnerException.Message}')", true);
                }
            }
        }

        protected void txtGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                txtContrasena.Text = GeneraPalabra();
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
            }
        }

        public string GeneraPalabra()
        {
            try
            {
                Random random = new Random();
                string abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                string numeros = "0123456789";
                string especiales = "!@#$%&*";
                string Generado = "";
                int index;
                for (int i = 0; i < 6; i++)
                {
                    index = random.Next(abecedario.Length);
                    Generado = Generado + abecedario.Substring(index, 1);
                }

                if (!Regex.IsMatch(Generado, "[a-z]+"))
                {
                    int remplazar = random.Next(0, 6);
                    index = random.Next(27, abecedario.Length);
                    Generado = Generado.Remove(remplazar, 1);
                    Generado = Generado.Insert(remplazar, abecedario.Substring(index, 1));
                }

                if (!Regex.IsMatch(Generado, "[A-Z]+"))
                {
                    int remplazar = random.Next(0, 6);
                    index = random.Next(0, 27);
                    Generado = Generado.Remove(remplazar, 1);
                    Generado = Generado.Insert(remplazar, abecedario.Substring(index, 1));
                }

                index = random.Next(numeros.Length);
                Generado = Generado + numeros.Substring(index, 1);
                index = random.Next(especiales.Length);
                Generado = Generado + especiales.Substring(index, 1);
                return Generado;
            }
            catch (Exception ex)
            {
                Session["Error"] = ex;
                Response.Redirect("~/Paginas/PaginaError", false);
                return "";
            }
        }
    }
}