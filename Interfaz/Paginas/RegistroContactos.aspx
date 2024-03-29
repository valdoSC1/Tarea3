﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroContactos.aspx.cs" Inherits="Interfaz.Paginas.RegistroContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Estilos/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="../Scripts/toastr.min.js"></script>

    <script type="text/javascript">
        function AlertaRegistro() {
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
            toastr["success"]("Se ha registrado el contacto", "Información")
        }

        function Alerta(mensaje) {
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
            toastr["warning"](mensaje, "Información")
        }

    </script>

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

    <br />

    <div class="row">
        <div class="col-md-4">
            <label>
                Nombre:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Nombre" ID="txtNombre" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Primer Apellido:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Primer Apellido" ID="txtPrimerApellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Segundo Apellido:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Segundo Apellido" ID="txtSegundoApellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Facebook:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ ]+" MaxLength="60" title="Solo se permiten usuarios de Facebook válidos" placeholder="Facebook" ID="txtFacebook" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Instagram:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ_]+" MaxLength="30" title="Solo se permiten usuarios de Instagram válidos" placeholder="Instagram" ID="txtInstagram" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Twitter:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ_]+" MaxLength="30" title="Solo se permiten usuarios de Twitter válidos" placeholder="Twitter" ID="txtTwitter" />
            </label>
        </div>

        <div class="col-md-12" id="telefonos" style="display: grid; justify-content: center" runat="server">
        </div>

        <div class="col-md-12" id="correos" style="display: grid; justify-content: center" runat="server">
        </div>

        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center;">
            <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" Style="margin: 12px 0px 0px 0px" />
        </div>
    </div>

    <script>

    const telefonos = document.getElementById("MainContent_telefonos");
    const correos = document.getElementById("MainContent_correos");
    const btnAgregarTelefono = document.getElementById("btnAgregarTelefono");
    const btnAgregarCorreo = document.getElementById("btnAgregarCorreo");

    btnAgregarTelefono.addEventListener('click', e => {
        e.preventDefault();
        let div = document.createElement('div');
        div.innerHTML = `<input type="text" name="ctl00$MainContent$Telefono" maxlength="20" title="Solo se aceptan números telefónicos válidos" pattern="[+()0-9]+" placeholder="85644664" value="">
                            <input type="image" src="../recursos/borrar.png" alt="Eliminar" onclick="return eliminar(this,1);">`
        div.setAttribute(
            'style',
            'display:inline-flex;align-items:center;justify-content:center;width:307px'
        );
        telefonos.appendChild(div);
    })

    btnAgregarCorreo.addEventListener('click', e => {
        e.preventDefault();
        let div = document.createElement('div');
        div.innerHTML = `<input type="text" name="ctl00$MainContent$Correo" maxlength="60" title="Solo se aceptan correos electrónicos válidos" pattern='^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})' placeholder="ejemplo@gmail.com" value="">
                            <input type="image" src="../recursos/borrar.png" alt="Eliminar" onclick="return eliminar(this,2);">`
        div.setAttribute(
            'style',
            'display:inline-flex;align-items:center;justify-content:center;width:307px'
        );
        correos.appendChild(div);
    })

    function eliminar(e, num) {
        const div = e.parentNode;
        const cantTelefono = telefonos.children.length;
        const cantCorreo = correos.children.length;

        if (num === 1) {
            if (cantTelefono > 2) {
                telefonos.removeChild(div);
            } else {
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": true,
                    "positionClass": "toast-top-full-width",
                    "preventDuplicates": true,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr["warning"]("No se puede eliminar, debido a que se necesita mínimo un número de teléfono registrado", "Información")
            }
        } else {
            if (cantCorreo > 2) {
                correos.removeChild(div);
            } else {
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": true,
                    "positionClass": "toast-top-full-width",
                    "preventDuplicates": true,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
                toastr["warning"]("No se puede eliminar, debido a que se necesita mínimo un correo eléctronico registrado", "Información")
            }
        }
        return false;
    }

    </script>

</asp:Content>
