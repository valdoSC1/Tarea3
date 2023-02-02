﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Tarea3Entities1 : DbContext
    {
        public Tarea3Entities1()
            : base("name=Tarea3Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contacto> Contactoes { get; set; }
        public virtual DbSet<Contacto_Usuario> Contacto_Usuario { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Telefono> Telefonoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual int SP_CambiarContrasena(string id, string contrasena)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CambiarContrasena", idParameter, contrasenaParameter);
        }
    
        public virtual int SP_EliminarUsuario(string id)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EliminarUsuario", idParameter);
        }
    
        public virtual int SP_EstadoUsuario(string id, Nullable<int> estado)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EstadoUsuario", idParameter, estadoParameter);
        }
    
        public virtual int SP_IngresarUsuarios(string id, string nombre, string primer_Apellido, string segundo_Apellido, string contrasena, Nullable<int> estadoID, string correo)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primer_ApellidoParameter = primer_Apellido != null ?
                new ObjectParameter("Primer_Apellido", primer_Apellido) :
                new ObjectParameter("Primer_Apellido", typeof(string));
    
            var segundo_ApellidoParameter = segundo_Apellido != null ?
                new ObjectParameter("Segundo_Apellido", segundo_Apellido) :
                new ObjectParameter("Segundo_Apellido", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            var estadoIDParameter = estadoID.HasValue ?
                new ObjectParameter("EstadoID", estadoID) :
                new ObjectParameter("EstadoID", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_IngresarUsuarios", idParameter, nombreParameter, primer_ApellidoParameter, segundo_ApellidoParameter, contrasenaParameter, estadoIDParameter, correoParameter);
        }
    
        public virtual int SP_ModificarUsuario(string id, string nombre, string primer_Apellido, string segundo_Apellido)
        {
            var idParameter = id != null ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primer_ApellidoParameter = primer_Apellido != null ?
                new ObjectParameter("Primer_Apellido", primer_Apellido) :
                new ObjectParameter("Primer_Apellido", typeof(string));
    
            var segundo_ApellidoParameter = segundo_Apellido != null ?
                new ObjectParameter("Segundo_Apellido", segundo_Apellido) :
                new ObjectParameter("Segundo_Apellido", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ModificarUsuario", idParameter, nombreParameter, primer_ApellidoParameter, segundo_ApellidoParameter);
        }
    
        public virtual ObjectResult<string> SP_Logueo(string identificacion, string contrasena)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Logueo", identificacionParameter, contrasenaParameter);
        }
    
        public virtual ObjectResult<string> SP_Logueo1(string identificacion, string contrasena)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("contrasena", contrasena) :
                new ObjectParameter("contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Logueo1", identificacionParameter, contrasenaParameter);
        }
    
        public virtual ObjectResult<SP_BuscarUsuario_Result> SP_BuscarUsuario(string identificacion)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_BuscarUsuario_Result>("SP_BuscarUsuario", identificacionParameter);
        }
    
        public virtual ObjectResult<SP_ConsultarContactos_Result> SP_ConsultarContactos(string idUsuario)
        {
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_ConsultarContactos_Result>("SP_ConsultarContactos", idUsuarioParameter);
        }
    
        public virtual int SP_EliminarContacto(Nullable<int> idContacto)
        {
            var idContactoParameter = idContacto.HasValue ?
                new ObjectParameter("idContacto", idContacto) :
                new ObjectParameter("idContacto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_EliminarContacto", idContactoParameter);
        }
    
        public virtual int SP_IngresarContactos(string idUsuario, string nombre, string primer_Apellido, string segundo_Apellido, string facebook, string instagram, string twitter)
        {
            var idUsuarioParameter = idUsuario != null ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primer_ApellidoParameter = primer_Apellido != null ?
                new ObjectParameter("Primer_Apellido", primer_Apellido) :
                new ObjectParameter("Primer_Apellido", typeof(string));
    
            var segundo_ApellidoParameter = segundo_Apellido != null ?
                new ObjectParameter("Segundo_Apellido", segundo_Apellido) :
                new ObjectParameter("Segundo_Apellido", typeof(string));
    
            var facebookParameter = facebook != null ?
                new ObjectParameter("Facebook", facebook) :
                new ObjectParameter("Facebook", typeof(string));
    
            var instagramParameter = instagram != null ?
                new ObjectParameter("Instagram", instagram) :
                new ObjectParameter("Instagram", typeof(string));
    
            var twitterParameter = twitter != null ?
                new ObjectParameter("Twitter", twitter) :
                new ObjectParameter("Twitter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_IngresarContactos", idUsuarioParameter, nombreParameter, primer_ApellidoParameter, segundo_ApellidoParameter, facebookParameter, instagramParameter, twitterParameter);
        }
    
        public virtual int SP_IngresarCorreos(Nullable<int> idContacto, string correo)
        {
            var idContactoParameter = idContacto.HasValue ?
                new ObjectParameter("idContacto", idContacto) :
                new ObjectParameter("idContacto", typeof(int));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_IngresarCorreos", idContactoParameter, correoParameter);
        }
    
        public virtual int SP_IngresarTelefonos(Nullable<int> idContacto, string numeroTelefono)
        {
            var idContactoParameter = idContacto.HasValue ?
                new ObjectParameter("idContacto", idContacto) :
                new ObjectParameter("idContacto", typeof(int));
    
            var numeroTelefonoParameter = numeroTelefono != null ?
                new ObjectParameter("NumeroTelefono", numeroTelefono) :
                new ObjectParameter("NumeroTelefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_IngresarTelefonos", idContactoParameter, numeroTelefonoParameter);
        }
    
        public virtual int SP_MantenimientoCorreo(Nullable<int> opc, Nullable<int> idCorreo, string correoNuevo)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("opc", opc) :
                new ObjectParameter("opc", typeof(int));
    
            var idCorreoParameter = idCorreo.HasValue ?
                new ObjectParameter("idCorreo", idCorreo) :
                new ObjectParameter("idCorreo", typeof(int));
    
            var correoNuevoParameter = correoNuevo != null ?
                new ObjectParameter("CorreoNuevo", correoNuevo) :
                new ObjectParameter("CorreoNuevo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_MantenimientoCorreo", opcParameter, idCorreoParameter, correoNuevoParameter);
        }
    
        public virtual int SP_MantenimientoTelefono(Nullable<int> opc, Nullable<int> idTelefono, string numeroNuevo)
        {
            var opcParameter = opc.HasValue ?
                new ObjectParameter("opc", opc) :
                new ObjectParameter("opc", typeof(int));
    
            var idTelefonoParameter = idTelefono.HasValue ?
                new ObjectParameter("idTelefono", idTelefono) :
                new ObjectParameter("idTelefono", typeof(int));
    
            var numeroNuevoParameter = numeroNuevo != null ?
                new ObjectParameter("NumeroNuevo", numeroNuevo) :
                new ObjectParameter("NumeroNuevo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_MantenimientoTelefono", opcParameter, idTelefonoParameter, numeroNuevoParameter);
        }
    
        public virtual int SP_ModificarContacto(Nullable<int> idContacto, string nombre, string primer_Apellido, string segundo_Apellido, string facebook, string instagram, string twitter)
        {
            var idContactoParameter = idContacto.HasValue ?
                new ObjectParameter("idContacto", idContacto) :
                new ObjectParameter("idContacto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primer_ApellidoParameter = primer_Apellido != null ?
                new ObjectParameter("Primer_Apellido", primer_Apellido) :
                new ObjectParameter("Primer_Apellido", typeof(string));
    
            var segundo_ApellidoParameter = segundo_Apellido != null ?
                new ObjectParameter("Segundo_Apellido", segundo_Apellido) :
                new ObjectParameter("Segundo_Apellido", typeof(string));
    
            var facebookParameter = facebook != null ?
                new ObjectParameter("Facebook", facebook) :
                new ObjectParameter("Facebook", typeof(string));
    
            var instagramParameter = instagram != null ?
                new ObjectParameter("Instagram", instagram) :
                new ObjectParameter("Instagram", typeof(string));
    
            var twitterParameter = twitter != null ?
                new ObjectParameter("Twitter", twitter) :
                new ObjectParameter("Twitter", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ModificarContacto", idContactoParameter, nombreParameter, primer_ApellidoParameter, segundo_ApellidoParameter, facebookParameter, instagramParameter, twitterParameter);
        }
    
        public virtual ObjectResult<SP_BuscarUsuario1_Result> SP_BuscarUsuario1(string identificacion)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_BuscarUsuario1_Result>("SP_BuscarUsuario1", identificacionParameter);
        }
    }
}
