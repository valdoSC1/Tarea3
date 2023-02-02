<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="Interfaz.Paginas.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center text-primary">Registro de usuarios</h2>
    <div class="row">
        <div class="col-md-4">
            <label>
                Identificación:<br />
                <asp:TextBox runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123" />
            </label>
        </div>
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
                Contraseña:<br />
                <asp:TextBox ID="txtContrasena" type="password" runat="server" MaxLength="20" pattern="(?=\w*[A-Z])(?=\w*[!@#$%&*])(?=\w*[a-z])\S{3,20}" placeholder="Contraseña" />
                <span>
                    <img role="button" onclick="mostrarContrasena()" src="../recursos/eye.png" alt="Ojo" /></span>
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Estado:<br />
                <asp:DropDownList runat="server" ID="ddlEstado">
                    <asp:ListItem Text="Activo" Value="1" Selected="True" />
                    <asp:ListItem Text="Inactivo" Value="0" />
                </asp:DropDownList>
            </label>
        </div>
        <div class="col-md-12">
            <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" />
        </div>
    </div>

    <script>
        function mostrarContrasena() {
            var tipo = document.getElementById("MainContent_txtContrasena");
            if (tipo.type == "password") {
                tipo.type = "text";
            } else {
                tipo.type = "password";
            }
        }
    </script>

</asp:Content>
