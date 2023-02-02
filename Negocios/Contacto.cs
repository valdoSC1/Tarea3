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

        public string IdContacto { get => _IdContacto; set => _IdContacto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string PrimerApellido { get => _PrimerApellido; set => _PrimerApellido = value; }
        public string SegundoApellido { get => _SegundoApellido; set => _SegundoApellido = value; }
        public string Facebook { get => _Facebook; set => _Facebook = value; }
        public string Twitter { get => _Twitter; set => _Twitter = value; }
        public string Instragram { get => _Instragram; set => _Instragram = value; }

        public ArrayList ConsultarContactos(String idUsuario)
        {
            try
            {
                using (Tarea3Entities1 db = new Tarea3Entities1())
                {
                    ArrayList infoContactos = new ArrayList();                    
                    var contactos = db.SP_ConsultarContactos(idUsuario);
                    
                    foreach (SP_ConsultarContactos_Result cnt in contactos.ToList())
                    {
                        Contacto iContacto = new Contacto();
                        iContacto.Nombre = cnt.Nombre;
                        iContacto.PrimerApellido = cnt.PrimerApellido;
                        iContacto.SegundoApellido = cnt.SegundoApellido;
                        infoContactos.Add(iContacto);
                    }

                    return infoContactos;

                }
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
