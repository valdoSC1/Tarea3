<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroContactos.aspx.cs" Inherits="Interfaz.Paginas.RegistroContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        th, td {
            padding: 5px 15px;
            text-align: center;
        }

        tr:nth-child(even) {
            background-color: #ddd;
        }
    </style>

    <h2 class="text-center text-primary">Registro de contactos</h2>

    <div class="row">
        <div class="col-md-4">
            <label>
                Nombre:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Nombre" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Primer Apellido:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Primer Apellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Segundo Apellido:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Facebook:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Instagram:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Twitter:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>

        <div class="col-md-12">
            <label>
                Teléfono:
                <asp:ImageButton ID="imgAgregar" runat="server" ImageUrl="~/recursos/simboloMas.png" OnClick="imgAgregar_Click" /><br />
                <asp:TextBox runat="server" MaxLength="20" pattern="[+()0-9]+" placeholder="85644664" ID="txtTelefono"/>
            </label>
        </div>
        <div>
            <asp:PlaceHolder ID="plhTelefonos" runat="server"></asp:PlaceHolder>
        </div>

        <div class="col-md-12">
            <label>
                Correo:
                <asp:ImageButton ID="imgAgregarCorreo" runat="server" ImageUrl="~/recursos/simboloMas.png" OnClick="imgAgregarCorreo_Click" /><br />
                <asp:TextBox TextMode="Email" runat="server" MaxLength="20" placeholder="ejemplo@gmail.com" ID="txtCorreo" />
            </label>
        </div>

        <div>
            <asp:PlaceHolder ID="plhCorreo" runat="server"></asp:PlaceHolder>
        </div>

    </div>
</asp:Content>
