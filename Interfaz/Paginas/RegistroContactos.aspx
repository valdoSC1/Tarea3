<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroContactos.aspx.cs" Inherits="Interfaz.Paginas.RegistroContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center text-primary">Registro de contactos</h2>

    <div class="row">
        <div class="col-md-4">
            <label>
                Nombre:<br />
                <asp:TextBox runat="server" pattern="[0-9]+" MaxLength="20" placeholder="Nombre" />
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
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Instagram:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Twitter:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Teléfono: <asp:ImageButton ID="imgAgregar" runat="server" ImageUrl="~/recursos/simboloMas.png" OnClick="imgAgregar_Click" /><br />
                     
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>                        
            <asp:PlaceHolder runat="server" ID="phTelefonos"></asp:PlaceHolder>
        </div>
    </div>
   
</asp:Content>
