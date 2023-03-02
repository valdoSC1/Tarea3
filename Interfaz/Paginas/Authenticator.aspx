<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authenticator.aspx.cs" Inherits="Interfaz.Paginas.Authenticator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Estilos/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="../Scripts/toastr.min.js"></script>

    <script type="text/javascript">
        function AlertaCodigo() {
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
            toastr["warning"]("El código es incorrecto. Inténtalo de nuevo", "Información")
        }
    </script>

    <br />

    <div style="display: grid; justify-content: center; align-items: center">
        <h2 class="text-center text-primary">Verificación en dos pasos</h2>

        <div style='display: grid; place-items: center'>
            <h4 style="text-align: center">Este paso extra nos indica que eres tú
                <br />
                quien está intentando iniciar sesión</h4>
        </div>

        <div style='display: grid; place-items: center'>
            <img src="../recursos/avatar.png" alt="Avatar" style="width: 45px; height: 45px">
        </div>

        <div style='display: grid; place-items: center; padding-top: 8px' runat="server" id="correo">
        </div>

        <div style='display: grid; place-items: center'>
            <h4 style="text-align: center">Se acaba de enviar un código al
                <br />
                correo electrónico asociado a
                <br />
                está cuenta</h4>
        </div>

        <div style='display: grid; place-items: center'>
            <input style="border-color: dimgray" autocomplete="off" runat="server" type="text" id="txtCodigo" name="login" placeholder="Escribe el código" pattern="[0-9]+" title="Solo se permiten números en este campo" maxlength="6">
        </div>

        <div style='display: grid; place-items: center'>
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" />
        </div>

    </div>

</asp:Content>
