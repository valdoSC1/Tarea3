<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="Interfaz.Paginas.Contactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .card {
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
            transition: 0.3s;
            border-radius: 5px; /* 5px rounded corners */
            padding: 0px 16px;
            margin: 20px;
            width: 200px;
            height: 140px;
            background-color: white;            
        }

            .card:hover {
                box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
            }

        .container {
            width: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            padding-left:100px;
        }

        .Editar {
            width: 50px;
            background-color: #485c85;
            padding: 8px;
            color: white;
            text-decoration: none;
            transition: 0.3s;
        }

            .Editar:hover {
                box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
                background-color: #bccaf4;
            }

    </style>

    <h2 class="text-center text-primary">Contactos</h2>

    <div class="row" runat="server" id="contactosInfo">        
    </div>

</asp:Content>
