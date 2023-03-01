<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="Interfaz.Paginas.WebForm1" %>

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
            toastr["success"]("Se ha registrado el usuario", "Información")
        }

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
            toastr["success"]("Se ha modificado la información del usuario", "Información")
        }

        function AlertaContrasena() {
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
            toastr["success"]("Se ha modificado la contraseña del usuario", "Información")
        }

        function AlertaEstado() {
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
            toastr["success"]("Se ha modificado el estado de la cuenta del usuario", "Información")
        }

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
            toastr["success"]("Se ha eliminado el usuario", "Información")
        }

        function AlertaError(mensaje) {
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
            toastr["error"](mensaje, "Información")
        }

        function AlertaNoEncontrado(mensaje) {
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

        function AlertaVacios(){
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
            toastr["warning"]("Por favor verifique los datos que desea ingresar, no pueden estar vacíos.", "Información")
        }

        function AlertaValidar() {
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
            toastr["warning"]("Por favor verifique los datos que desea ingresar.", "Información")
        }
    </script>

    <nav>
        <div style="display: flex; justify-content: center; align-content: center; margin-top: 50px; gap: 10px" class="nav" id="nav-tab" role="tablist">
            <button class="nav-link active btn" style="background-color: #39ACE7" id="nav-home-tab" data-toggle="tab" data-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Registrar Usuario</button>
            <button class="nav-link btn" style="background-color: #39ACE7" id="nav-profile-tab" data-toggle="tab" data-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Modificar Usuario</button>
            <button class="nav-link btn" style="background-color: #39ACE7" id="nav-contact-tab" data-toggle="tab" data-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Modificar Contraseña</button>
            <button class="nav-link btn" style="background-color: #39ACE7" id="nav-estado-tab" data-toggle="tab" data-target="#nav-estado" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Cambiar Estado</button>
            <button class="nav-link btn" style="background-color: #39ACE7" id="nav-eliminar-tab" data-toggle="tab" data-target="#nav-eliminar" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Eliminar Usuario</button>
        </div>
    </nav>
    <div class="tab-content" id="nav-tabContent">
        <div class="tab-pane fade" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <h2 class="text-center text-primary" style="margin-bottom: 25px">Registro de usuarios</h2>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Identificación:<br />
                                <asp:TextBox ID="txtId" runat="server" pattern="[0-9]+" MaxLength="20" title="Solo se permiten números en este campo" placeholder="101230123" />
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Nombre:<br />
                                <asp:TextBox ID="txtNombre" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Nombre" />
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Primer Apellido:<br />
                                <asp:TextBox ID="txtPApellido" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Primer Apellido" />
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Segundo Apellido:<br />
                                <asp:TextBox ID="txtSApellido" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Segundo Apellido" />
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Contraseña:<br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtContrasena" type="password" runat="server" MaxLength="20" pattern="(?=\w*[A-Z])(?=\w*[!@#$%&*])(?=\w*[a-z])\S{3,20}" placeholder="Contraseña" />
                                        <span>
                                            <img role="button" onclick="mostrarContrasena(MainContent_txtContrasena)" src="../recursos/eye.png" alt="Ojo" /></span>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="txtGenerar" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>

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
                        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                            <label>
                                Correo Electrónico:<br />
                                <asp:TextBox ID="txtEmail" type="email" runat="server" MaxLength="60" pattern="^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" title="Solo se aceptan correos electrónicos válidos" placeholder="ejemplo@gmail.com" />
                            </label>
                        </div>

                        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                            <asp:Button Text="Generar Contraseña" runat="server" ID="txtGenerar" OnClick="txtGenerar_Click" />
                        </div>

                        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                            <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                        </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnRegistrar" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <h2 class="text-center text-primary" style="margin-bottom: 25px">Modificar usuarios</h2>
                <div class="col-md-12">
                    <div style="display: flex; justify-content: center; align-content: center">
                        <label class="text-center">
                            Indique la identificación del usuario
                    <br />
                            que desea modificar:<br />
                            <asp:TextBox ID="txtIdM" runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123"/>
                        </label>
                    </div>
                    <div style="display: flex; justify-content: center; align-content: center">
                        <asp:Button ID="btnBuscarM" Text="Buscar" runat="server" Style="background-color: #f36b39" OnClick="btnBuscarM_Click" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCambiar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="row" id="modificar" runat="server" visible="false">
                    <div class="col-md-4">
                        <label>
                            Nombre:<br />
                            <asp:TextBox ID="txtNombreM" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Nombre" />
                        </label>
                    </div>
                    <div class="col-md-4">
                        <label>
                            Primer Apellido:<br />
                            <asp:TextBox ID="txtPApellidoM" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Primer Apellido" />
                        </label>
                    </div>
                    <div class="col-md-4">
                        <label>
                            Segundo Apellido:<br />
                            <asp:TextBox ID="txtSApellidoM" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" title="Solo se permiten letras en este campo" placeholder="Segundo Apellido" />
                        </label>
                    </div>
                    <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                        <label>
                            Correo Electrónico:<br />
                            <asp:TextBox ID="txtCorreo" runat="server" pattern="^([a-zA-Z0-9_\-\.]+)@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" MaxLength="60" title="Solo se aceptan correos electrónicos válidos" placeholder="ejemplo@gmail.com" />
                        </label>
                    </div>
                    <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                        <asp:Button ID="btnCambiar" Text="Modificar" runat="server" Style="background-color: #f36b39" OnClick="btnCambiar_Click" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarM" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <h2 class="text-center text-primary" style="margin-bottom: 25px">Modificar contraseña</h2>
                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                    <label class="text-center">
                        Indique la identificación del usuario
                    <br />
                        que desea modificar:<br />
                        <asp:TextBox ID="txtIdC" runat="server" pattern="[0-9]+" MaxLength="20" title="Solo se permiten números en este campo" placeholder="101230123"/>
                    </label>
                </div>

                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                    <label class="text-center">
                        Contraseña nueva:<br />
                        <asp:TextBox ID="txtContrasenaModificar" type="password" runat="server" MaxLength="20" pattern="(?=\w*[A-Z])(?=\w*[!@#$%&*])(?=\w*[a-z])\S{3,20}" placeholder="Contraseña" />
                        <span>
                            <img role="button" onclick="mostrarContrasena(MainContent_txtContrasenaModificar)" src="../recursos/eye.png" alt="Ojo" /></span>
                    </label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCambiarContra" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
            <asp:Button ID="btnCambiarContra" Text="Cambiar" runat="server" Style="background-color: #f36b39" OnClick="btnCambiarContra_Click" />
        </div>

    </div>

    <div class="tab-pane fade" id="nav-estado" role="tabpanel" aria-labelledby="nav-home-tab">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <h2 class="text-center text-primary" style="margin-bottom: 25px">Cambiar estado</h2>

                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                    <label>
                        Identificación:<br />
                        <asp:TextBox ID="txtIdE" runat="server" pattern="[0-9]+" MaxLength="20" title="Solo se permiten números en este campo" placeholder="101230123"/>
                    </label>
                </div>

                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                    <label>
                        Estado:<br />
                        <asp:DropDownList runat="server" ID="dllCambioEstado">
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                        </asp:DropDownList>
                    </label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCambiarEstado" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>

        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
            <asp:Button ID="btnCambiarEstado" Text="Cambiar estado" runat="server" Style="background-color: #f36b39" OnClick="btnCambiarEstado_Click" />
        </div>
    </div>

    <div class="tab-pane fade" id="nav-eliminar" role="tabpanel" aria-labelledby="nav-home-tab">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <h2 class="text-center text-primary col-md-12" style="margin-bottom: 25px">Eliminar usuario</h2>
                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                    <label class="text-center">
                        Indique la identificación del usuario que desea eliminar.<br />
                        <asp:TextBox ID="txtIdentificacionEliminar" runat="server" pattern="[0-9]+" MaxLength="20" title="Solo se permiten números en este campo" placeholder="101230123"/>
                    </label>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnEliminar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
            <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" Style="background-color: #f50400" OnClick="btnEliminar_Click" />
        </div>
    </div>

    <script>
        function mostrarContrasena(nombre) {
            console.log(nombre.id);
            var tipo = document.getElementById(nombre.id);
            if (tipo.type == "password") {
                tipo.type = "text";
            } else {
                tipo.type = "password";
            }
        }

    </script>
</asp:Content>
