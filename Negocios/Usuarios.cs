using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocios
{
    public class Usuarios
    {
        private String _Identificacion;
        private String _Nombre;
        private String _PrimerApellido;
        private String _SegundoApellido;
        private String _Contrasena;
        private int _Estado;

        public string Identificacion { get => _Identificacion; set => _Identificacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string PrimerApellido { get => _PrimerApellido; set => _PrimerApellido = value; }
        public string SegundoApellido { get => _SegundoApellido; set => _SegundoApellido = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public int Estado { get => _Estado; set => _Estado = value; }


        public void registrarUsuarios()
        {

            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_IngresarUsuarios(Identificacion, Nombre, PrimerApellido, SegundoApellido, Contrasena, Estado);
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
                    db.SP_ModificarUsuario(Identificacion, Nombre, PrimerApellido, SegundoApellido);
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
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
