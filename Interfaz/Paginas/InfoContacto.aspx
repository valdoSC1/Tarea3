<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InfoContacto.aspx.cs" Inherits="Interfaz.Paginas.InfoContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        th, td {
            padding: 5px 15px;
            text-align: center;
        }

        tr:nth-child(even) {
            background-color: #ddd;
        }

        .card {           
            transition: 0.3s;
        }

            .card:hover {
                box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
            }

        .container {
            padding: 2px 16px;
        }
    </style>

    <h2 class="text-center text-primary" style="margin-bottom: 25px">Información del contacto</h2>

    <div class="container">
        <img src="" alt="Avatar" style="width: 100%">
        <div class="card" style="display: grid; place-items: center">
            <h4><b>John Doe</b></h4>
            <p>Architect & Engineer</p>
        </div>
    </div>

    

    <div class="row">
        <div class="col-md-4">
            <label>
                Nombre:<br />
                <asp:TextBox ID="txtNombre" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Nombre" ReadOnly="True" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Primer Apellido:<br />
                <asp:TextBox ID="txtPrimerApellido" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Primer Apellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Segundo Apellido:<br />
                <asp:TextBox ID="txtSegundoApellido" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Facebook:<br />
                <asp:TextBox ID="txtFacebook" runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="60" placeholder="Facebook" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Instagram:<br />
                <asp:TextBox ID="txtInstagram" runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="30" placeholder="Instagram" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Twitter:<br />
                <asp:TextBox ID="txtTwitter" runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="30" placeholder="Twitter" />
            </label>
        </div>

        <br />
        <br />

        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center;">
            <asp:Button Text="Modificar datos" runat="server" ID="btnModificar" Style="margin: 12px 0px 0px 0px" />
        </div>
    </div>

    <br />
    <br />

    <div style="display: grid; place-items: center">
        <table id="tblTelefonos">
            <thead>
                <tr style="background-color: lightpink">
                    <th>Teléfono</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="lstTelefonos" runat="server">
            </tbody>
        </table>
    </div>

    <br />
    <br />

    <div style="display: grid; place-items: center">
        <table id="tblCorreos">
            <thead>
                <tr style="background-color: lightpink">
                    <th>Correo</th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody id="lstCorreos" runat="server">
            </tbody>
        </table>
    </div>

</asp:Content>
