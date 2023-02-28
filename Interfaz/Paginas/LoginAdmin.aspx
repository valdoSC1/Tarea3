<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="Interfaz.Paginas.LoginAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="wrapper fadeInDown">
        <div id="formContent">
            <h2>Administración</h2>
            <input runat="server" type="text" id="txtUsuario" class="fadeIn second" name="login" placeholder="Usuario" maxlength="20">
            <input runat="server" type="password" id="txtContrasena" class="fadeIn third" name="pass" placeholder="Contraseña" maxlength="20">
            <asp:Button ID="btnInicioSesion" runat="server" Text="Iniciar Sesión"/>
        </div>
    </div>

</asp:Content>
