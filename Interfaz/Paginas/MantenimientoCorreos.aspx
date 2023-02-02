<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoCorreos.aspx.cs" Inherits="Interfaz.Paginas.MantenimientoCorreos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>
        <asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label>
    </h2>

    <div>
        <asp:Label ID="lblCorreo" runat="server" Text="Ingrese el nuevo correo:"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnAccion" runat="server" Text="Modificar" OnClick="btnAccion_Click" />
    </div>

</asp:Content>
