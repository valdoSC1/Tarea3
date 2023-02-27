<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="Interfaz.Paginas.Contactos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Estilos/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="../Scripts/toastr.min.js"></script>

    <script type="text/javascript">
        function AlertaEliminar() {
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-top-full-width",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "2000",
                "hideDuration": "4000",
                "timeOut": "5000",
                "extendedTimeOut": "3000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr["success"]("Se ha eliminado el contacto con éxito", "Información")
        }

    </script>

    <style>
        a {
            cursor: pointer;
            color: teal;
        }

            a:hover {
                text-decoration: underline;
            }

            a:visited {
                color: teal;
            }
    </style>

    <h2 class="text-center text-primary">Contactos</h2>

    <br />

    <div class="row" runat="server" id="contactosInfo">
        <div class="col-sm-6 col-md-4">
            <div class="card border-white" style="height: 150px">
                <div class="card-header" style='display: grid; place-items: center'>
                    <img src="../recursos/avatar.png" alt="Avatar" style="width: 45px; height: 45px">
                </div>
                <div class="card-body" style='display: grid; place-items: center'>
                    <h4><a href='MantenimientoContactos?idContacto=3'><b>Didier Hidalgo Chacón</b></a></h4>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
