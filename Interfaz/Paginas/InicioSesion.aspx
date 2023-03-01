<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="Interfaz.Paginas.InicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper fadeInDown">
        <div id="formContent">

            <input runat="server" type="text" id="txtUsuario" class="fadeIn second" name="login" placeholder="Usuario" pattern="[0-9]+" title="Solo se permiten números en este campo" maxlength="20">
            <input runat="server" type="password" id="txtContrasena" class="fadeIn third" name="pass" placeholder="Contraseña" maxlength="20">
            <asp:Button ID="btnInicioSesion" runat="server" Text="Iniciar Sesión" OnClick="btnInicioSesion_Click" />

        </div>
    </div>
</asp:Content>
