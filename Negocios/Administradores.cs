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
    public class Administradores
    {
        private String _CodigoUsuario;
        private String _Contrasena;
        private bool credencialValida = false;

        public string CodigoUsuario { get => _CodigoUsuario; set => _CodigoUsuario = value; }
        public string Contrasena { get => _Contrasena; set => _Contrasena = value; }
        public bool CredencialValida { get => credencialValida; set => credencialValida = value; }

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
                    ObjectResult<SP_LogueoAdmin_Result> objetoUsuario = db.SP_LogueoAdmin(CodigoUsuario, Contrasena);

                    if (objetoUsuario.Count() == 1)
                    {
                        CredencialValida = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
