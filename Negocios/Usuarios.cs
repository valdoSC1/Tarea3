using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.Entity.Core.Objects;
using System.Collections;
using System.Data.SqlClient;

namespace Negocios
{
    public class Usuarios
    {
        private String _Identificacion;
        private String _Nombre;
        private String _PrimerApellido;
        private String _SegundoApellido;
        private String _Contrasena;
        private String _Correo;
        private int _Estado;
        private bool credencialValida = false;        

        public string Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string PrimerApellido { get => _PrimerApellido; set => _PrimerApellido = value; }
        public string SegundoApellido { get => _SegundoApellido; set => _SegundoApellido = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public bool CredencialValida { get => credencialValida; set => credencialValida = value; }
        public string Correo { get => _Correo; set => _Correo = value; }

        /// Encripta una cadena
        public void Encriptando()
        {
            string result = string.Empty;
            byte[] OcultarString = System.Text.Encoding.Unicode.GetBytes(Contrasena);
            Contrasena = Convert.ToBase64String(OcultarString);
            
        }

        public void InicioSesion()
        {
            try
            {
                Encriptando();
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ObjectResult<SP_Logueo_Result> objetoUsuario = db.SP_Logueo(Identificacion, Contrasena);

                    if (objetoUsuario.Count() == 1)
                    {
                        credencialValida = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void registrarUsuarios()
        {
            try
            {
                Encriptando();
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_IngresarUsuarios(Identificacion, Nombre, PrimerApellido, SegundoApellido, Contrasena, Estado, Correo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }                
            
        }

        public void modificarUsuarios()
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_ModificarUsuario(Identificacion, Nombre, PrimerApellido, SegundoApellido, Correo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void cambiarContrasenaUsuario()
        {
            try
            {
                Encriptando();
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_CambiarContrasena(Identificacion, Contrasena);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void cambiarEstadoUsuarios()
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_EstadoUsuario(Identificacion, Estado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminarUsuarios()
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1()) 
                {
                    db.SP_EliminarUsuario(Identificacion);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }            
        }

        public ArrayList BuscaUsuario()
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoUsuario = new ArrayList();
                    var usuario = db.SP_BuscarUsuario(Identificacion);
                    foreach (SP_BuscarUsuario_Result user in usuario.ToList())
                    {
                        Usuarios iUsuario = new Usuarios();
                        iUsuario.Nombre = user.Nombre;
                        iUsuario.PrimerApellido = user.Primer_Apellido;
                        iUsuario.SegundoApellido = user.Segundo_Apellido;
                        iUsuario.Correo = user.CorreoElectronico;
                        infoUsuario.Add(iUsuario);
                    }
                    return infoUsuario;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
