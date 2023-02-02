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
    </style>

    <div id="informacion" runat="server">
    </div>

    <br />
    <br />

    <div>
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

    <div>
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
