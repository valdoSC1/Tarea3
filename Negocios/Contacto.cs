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

namespace Negocios
{
    public class Contacto
    {
        private String _IdContacto;
        private String _Nombre;
        private String _PrimerApellido;
        private String _SegundoApellido;
        private String _Facebook;
        private String _Twitter;
        private String _Instragram;
        private String _idTelefono;
        private String _Telefono;
        private String _idCorreo;
        private String _Correo;

        public string IdContacto { get => _IdContacto; set => _IdContacto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string PrimerApellido { get => _PrimerApellido; set => _PrimerApellido = value; }
        public string SegundoApellido { get => _SegundoApellido; set => _SegundoApellido = value; }
        public string Facebook { get => _Facebook; set => _Facebook = value; }
        public string Twitter { get => _Twitter; set => _Twitter = value; }
        public string Instragram { get => Instragram1; set => Instragram1 = value; }
        public string Instragram1 { get => _Instragram; set => _Instragram = value; }
        public string IdTelefono { get => _idTelefono; set => _idTelefono = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string IdCorreo { get => _idCorreo; set => _idCorreo = value; }
        public string Correo { get => _Correo; set => _Correo = value; }

        public void registrarContactos(String idUsuario)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_IngresarContactos(idUsuario, Nombre, PrimerApellido, SegundoApellido, Facebook, Instragram, Twitter);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList consultarUltimoContacto()
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList idContacto = new ArrayList();
                    var infoIdContacto = db.SP_ConsultarUltimoContacto();
                    foreach (Nullable<int> cnt in infoIdContacto.ToList())
                    {
                        idContacto.Add(cnt.Value);
                    }
                    return idContacto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void registrarTelefonos(int idContacto, String telefono)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_IngresarTelefonos(idContacto, telefono);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void registrarCorreos(int idContacto, String correo)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    db.SP_IngresarCorreos(idContacto, correo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList consultarInfoContacto(int idContacto)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();
                    var contactos = db.SP_ConsultarContactos("", idContacto);

                    foreach (SP_ConsultarContactos_Result cnt in contactos.ToList())
                    {
                        Contacto iContacto = new Contacto();                        
                        iContacto.Nombre = cnt.Nombre;
                        iContacto.PrimerApellido = cnt.PrimerApellido;
                        iContacto.SegundoApellido = cnt.SegundoApellido;
                        iContacto.Facebook = cnt.Facebook;
                        iContacto.Instragram = cnt.Instagram;
                        iContacto.Twitter = cnt.Twitter;
                        infoContactos.Add(iContacto);
                    }

                    return infoContactos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList ConsultarContactos(String idUsuario)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();
                    var contactos = db.SP_ConsultarContactos(idUsuario, 0);

                    foreach (SP_ConsultarContactos_Result cnt in contactos.ToList())
                    {
                        Contacto iContacto = new Contacto();
                        iContacto.IdContacto = cnt.IdContacto.ToString();
                        iContacto.Nombre = cnt.Nombre;
                        iContacto.PrimerApellido = cnt.PrimerApellido;
                        iContacto.SegundoApellido = cnt.SegundoApellido;
                        iContacto.Facebook = cnt.Facebook;
                        iContacto.Instragram = cnt.Instagram;
                        iContacto.Twitter = cnt.Twitter;
                        infoContactos.Add(iContacto);
                    }

                    return infoContactos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList ConsultarTelefonos(int idContacto)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();
                    var contactos = db.SP_ConsultarTelefonos(idContacto);

                    foreach (SP_ConsultarTelefonos_Result cnt in contactos.ToList())
                    {
                        Contacto iContacto = new Contacto();
                        iContacto.Telefono = cnt.NumeroTelefono;
                        iContacto.IdTelefono = cnt.TelefonoID.ToString();
                        infoContactos.Add(iContacto);
                    }

                    return infoContactos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ArrayList ConsultarCorreos(int idContacto)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();
                    var contactos = db.SP_ConsultarCorreos(idContacto);

                    foreach (SP_ConsultarCorreos_Result cnt in contactos.ToList())
                    {
                        Contacto iContacto = new Contacto();
                        iContacto.Correo = cnt.CorreoElectronico;
                        iContacto.IdCorreo = cnt.CorreoID.ToString();
                        infoContactos.Add(iContacto);
                    }

                    return infoContactos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void MantenimientoTelefonos(int opc, int idTelefono, string numeroNuevo = "")
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();
                    var contactos = db.SP_MantenimientoTelefono(opc, idTelefono, numeroNuevo);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void MantenimientoCorreos(int opc, int idCorreo, string correoNuevo = "")
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();
                    var contactos = db.SP_MantenimientoCorreo(opc, idCorreo, correoNuevo);
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}
