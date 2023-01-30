<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="Interfaz.Paginas.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-primary">Registro de usuarios</h2>
    <div class="row">
        <div class="col-md-4">
            <label>
                Identificación:<br/>
                <asp:TextBox runat="server" />
            </label>            
        </div>
        <div class="col-md-4">
            <label>
                Nombre:<br/>
                <asp:TextBox runat="server" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Primer Apellido:<br/>
                <asp:TextBox runat="server" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Segundo Apellido:<br/>
                <asp:TextBox runat="server" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Contraseña:<br/>
                <asp:TextBox runat="server" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Estado:<br/>
                <asp:TextBox runat="server" />
            </label>
        </div>
        <div class="d-flex py-5">
            <asp:Button Text="Registrar" runat="server" />
        </div>
    </div>

</asp:Content>
