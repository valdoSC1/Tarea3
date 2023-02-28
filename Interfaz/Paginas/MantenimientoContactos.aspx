<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoContactos.aspx.cs" Inherits="Interfaz.Paginas.MantenimientoContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Estilos/toastr.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="../Scripts/toastr.min.js"></script>

    <script type="text/javascript">
        function AlertaModificar() {
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
            toastr["success"]("Se ha modificado la información del contacto", "Información")
        }
        
    </script>

    <nav>
        <div style="display: flex; justify-content: center; align-content: center; margin-top: 50px; gap: 10px" class="nav" id="nav-tab" role="tablist">
            <button class="nav-link active btn" style="background-color: #39ACE7" id="nav-home-tab" data-toggle="tab" data-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Información del contacto</button>
            <button class="nav-link btn" style="background-color: #39ACE7" id="nav-profile-tab" data-toggle="tab" data-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Modificar datos del contacto</button>
            <button class="nav-link btn" style="background-color: #39ACE7" id="nav-contact-tab" data-toggle="tab" data-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Eliminar contacto</button>
        </div>
    </nav>

    <div class="tab-content" id="nav-tabContent">
        <div class="tab-pane fade in active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Información del contacto</h2>
            <div class="container" style="display: grid; place-items: center">
                <img src="../recursos/avatar.png" alt="Avatar">
                <div class="card" style="display: grid; place-items: center" runat="server" id="infoContacto">
                </div>
            </div>
        </div>

        <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Modificar datos</h2>
            <div class="row">
                <div class="col-md-4">
                    <label>
                        Nombre:<br />
                        <asp:TextBox ID="txtNombre" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Nombre" />
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

                <div class="col-md-12" id="telefonos" style="display: grid; justify-content: center" runat="server">
                </div>

                <div class="col-md-12" id="correos" style="display: grid; justify-content: center" runat="server">
                </div>

                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center;">
                    <asp:Button Text="Modificar" runat="server" ID="btnModificar" Style="margin: 12px 0px 0px 0px" />
                </div>

            </div>

        </div>

        <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Eliminar contacto</h2>

            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                <h4 class="text-center">¿Está seguro que desea eliminar este contacto?<br />
                </h4>
            </div>


            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">       
                <input type="button" id="btnEliminar" name="ctl00$MainContent$Eliminar" value="Si" style="background-color: #f50400;margin: 12px 0px 0px 0px" onclick="eliminarContacto()">                
                <input type="hidden" id="opc" name="ctl00$MainContent$Eliminar" value="0">
            </div>
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
            div.innerHTML = `<input type="text" name="ctl00$MainContent$Telefono" value="">
                            <input type="hidden" name="ctl00$MainContent$idTelefono" value="0">
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
            div.innerHTML = `<input type="text" name="ctl00$MainContent$Correo" value="">
                            <input type="hidden" name="ctl00$MainContent$idCorreo" value="0">
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

        function eliminarContacto() {
            const opc = document.getElementById("opc");           
            opc.value = '1';

            __doPostBack('','');
        }

    </script>

</asp:Content>
