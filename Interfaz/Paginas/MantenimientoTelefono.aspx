<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoTelefono.aspx.cs" Inherits="Interfaz.Paginas.MantenimientoTelefono" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
    </h2>

    <div>
        <asp:Label ID="lblTelefono" runat="server" Text="Ingrese el nuevo teléfono:"></asp:Label>
        <asp:TextBox ID="txtNuevoTelefono" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnAccion" runat="server" Text="Modificar" OnClick="btnAccion_Click" />
    </div>

    <div runat="server" id="hh">
        <input runat="server" type="text" id="txtUsuario" class="fadeIn second">
    </div>

</asp:Content>
