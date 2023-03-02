<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Interfaz.Paginas.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Estilos/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="../Scripts/toastr.min.js"></script>

     <script type="text/javascript">
         function AlertaValidar() {
             toastr.options = {
                 "closeButton": true,
                 "debug": false,
                 "newestOnTop": false,
                 "progressBar": true,
                 "positionClass": "toast-top-full-width",
                 "preventDuplicates": true,
                 "onclick": null,
                 "showDuration": "2000",
                 "hideDuration": "4000",
                 "timeOut": "5000",
                 "extendedTimeOut": "3000",
                 "showEasing": "swing",
                 "hideEasing": "linear",
                 "showMethod": "fadeIn",
                 "hideMethod": "fadeOut"
             }
             toastr["warning"]("Usuario y/o contraseña incorrectos", "Información")
         }

        function Credenciales(){
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-full-width",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "2000",
                "hideDuration": "4000",
                "timeOut": "5000",
                "extendedTimeOut": "3000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["warning"]("Usuario y/o contraseña incorrectos", "Información")
        }

         function CredencialesVacias() {
             toastr.options = {
                 "closeButton": true,
                 "debug": false,
                 "newestOnTop": false,
                 "progressBar": true,
                 "positionClass": "toast-top-full-width",
                 "preventDuplicates": true,
                 "onclick": null,
                 "showDuration": "2000",
                 "hideDuration": "4000",
                 "timeOut": "5000",
                 "extendedTimeOut": "3000",
                 "showEasing": "swing",
                 "hideEasing": "linear",
                 "showMethod": "fadeIn",
                 "hideMethod": "fadeOut"
             }
             toastr["warning"]("Usuario y/o contraseña no pueden estar vacíos", "Información")
         }
     </script>
    <div class="wrapper fadeInDown">
        <div id="formContent">

            <input runat="server" type="text" id="txtUsuario" class="fadeIn second" name="login" placeholder="Usuario" pattern="[0-9]+" title="Solo se permiten números en este campo" maxlength="20">
            <input runat="server" type="password" id="txtContrasena" class="fadeIn third" name="pass" placeholder="Contraseña" maxlength="20">
            <asp:Button ID="btnInicioSesion" runat="server" Text="Iniciar Sesión" OnClick="btnInicioSesion_Click" />

        </div>
    </div>
</asp:Content>
