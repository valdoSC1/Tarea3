<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarios.aspx.cs" Inherits="Interfaz.Paginas.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <nav>
        <div style="display: flex; justify-content: center; align-content: center; margin-top:50px; gap:10px" class="nav" id="nav-tab" role="tablist">
            <button class="nav-link active btn" style="background-color:#39ACE7" id="nav-home-tab" data-toggle="tab" data-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Registrar Usuario</button>
            <button class="nav-link btn" style="background-color:#39ACE7"  id="nav-profile-tab" data-toggle="tab" data-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Modificar Usuario</button>
            <button class="nav-link btn" style="background-color:#39ACE7"  id="nav-contact-tab" data-toggle="tab" data-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Modificar Contraseña</button>            
            <button class="nav-link btn" style="background-color:#39ACE7"  id="nav-estado-tab" data-toggle="tab" data-target="#nav-estado" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Cambiar Estado</button>
            <button class="nav-link btn" style="background-color:#39ACE7"  id="nav-eliminar-tab" data-toggle="tab" data-target="#nav-eliminar" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Eliminar Usuario</button>
        </div>
    </nav>
    <div class="tab-content" id="nav-tabContent">
        <div class="tab-pane fade" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Registro de usuarios</h2>
            <div class="row">
                <div class="col-md-4">
                    <label>
                        Identificación:<br />
                        <asp:TextBox ID="txtId" runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123" />
                    </label>
                </div>
                <div class="col-md-4">
                    <label>
                        Nombre:<br />
                        <asp:TextBox ID="txtNombre" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Nombre" />
                    </label>
                </div>
                <div class="col-md-4">
                    <label>
                        Primer Apellido:<br />
                        <asp:TextBox ID="txtPApellido" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Primer Apellido" />
                    </label>
                </div>
                <div class="col-md-4">
                    <label>
                        Segundo Apellido:<br />
                        <asp:TextBox ID="txtSApellido" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
                    </label>
                </div>
                <div class="col-md-4">
                    <label>
                        Contraseña:<br />
                        <asp:TextBox ID="txtContrasena" type="password" runat="server" MaxLength="20" pattern="(?=\w*[A-Z])(?=\w*[!@#$%&*])(?=\w*[a-z])\S{3,20}" placeholder="Contraseña" />
                        <span>
                            <img role="button" onclick="mostrarContrasena(MainContent_txtContrasena)" src="../recursos/eye.png" alt="Ojo" /></span>
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
                        <asp:TextBox ID="txtEmail" type="email" runat="server" MaxLength="60" placeholder="Email" />
                        <span>
                            <img role="button" onclick="mostrarContrasena(MainContent_txtContrasena)" src="../recursos/eye.png" alt="Ojo" /></span>
                    </label>
                </div>
                <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                    <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" OnClick="btnRegistrar_Click" />
                </div>
            </div>
        </div>

        <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Modificar Usuarios</h2>
            <div class="col-md-12">
                <div style="display: flex; justify-content: center; align-content: center">
                    <label class="text-center">
                        Indique la identificación del usuario
                    <br />
                        que desea modificar:<br />
                        <asp:TextBox ID="txtIdM" runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123" />
                    </label>
                </div>
                <div style="display: flex; justify-content: center; align-content: center">
                    <asp:Button ID="btnBuscarM" Text="Buscar" runat="server" Style="background-color: #f36b39" OnClick="btnBuscarM_Click" />
                </div>
            </div>

            <div class="row" id="modificar" runat="server" visible="false">
                <div class="col-md-4">
                    <label>
                        Nombre:<br />
                        <asp:TextBox ID="txtNombreM" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Nombre" />
                    </label>
                </div>
                <div class="col-md-4">
                    <label>
                        Primer Apellido:<br />
                        <asp:TextBox ID="txtPApellidoM" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Primer Apellido" />
                    </label>
                </div>
                <div class="col-md-4">
                    <label>
                        Segundo Apellido:<br />
                        <asp:TextBox ID="txtSApellidoM" runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" />
                    </label>
                </div>
                <div style="display: flex; justify-content: center; align-content: center">
                    <asp:Button ID="btnCambiar" Text="Buscar" runat="server" Style="background-color: #f36b39" OnClick="btnCambiar_Click" />
                </div>
            </div>
        </div>

        <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Modificar Contraseña</h2>
            <div class="col-md-6">
                <div style="display: flex; justify-content: end; align-content: center">
                    <label class="text-center">
                        Indique la identificación del usuario
                    <br />
                        que desea modificar:<br />
                        <asp:TextBox ID="txtIdC" runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123" />
                    </label>
                </div>
            </div>

            <div class="col-md-6" style="display: flex; justify-content: start; align-content: center">
                <label>
                    Contraseña nueva:<br />
                    <asp:TextBox ID="txtContrasenaModificar" type="password" runat="server" MaxLength="20" pattern="(?=\w*[A-Z])(?=\w*[!@#$%&*])(?=\w*[a-z])\S{3,20}" placeholder="Contraseña" />
                    <span>
                        <img role="button" onclick="mostrarContrasena(MainContent_txtContrasenaModificar)" src="../recursos/eye.png" alt="Ojo" /></span>
                </label>
            </div>

            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                <asp:Button ID="btnCambiarContra" Text="Cambiar" runat="server" Style="background-color: #f36b39" OnClick="btnCambiarContra_Click" />
            </div>

        </div>

        <div class="tab-pane fade" id="nav-estado" role="tabpanel" aria-labelledby="nav-home-tab">
            <h2 class="text-center text-primary" style="margin-bottom: 25px">Cambiar estado</h2>

            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                <label>
                    Identificación:<br />
                    <asp:TextBox ID="txtIdE" runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123" />
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

            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                <asp:Button ID="btnCambiarEstado" Text="Cambiar estado" runat="server" Style="background-color: #f36b39" OnClick="btnCambiarEstado_Click"/>
            </div>
        </div>

        <div class="tab-pane fade" id="nav-eliminar" role="tabpanel" aria-labelledby="nav-home-tab">
            <h2 class="text-center text-primary col-md-12" style="margin-bottom: 25px">Eliminar usuario</h2>
            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                <label class="text-center">
                    Indique la identificación del usuario que desea eliminar.<br />
                    <asp:TextBox ID="txtIdentificacionEliminar" runat="server" pattern="[0-9]+" MaxLength="20" placeholder="101230123" />
                </label>
            </div>
            <div class="col-md-12" style="display: flex; justify-content: center; align-content: center">
                <asp:Button ID="btnEliminar" Text="Eliminar" runat="server" Style="background-color: #f50400" OnClick="btnEliminar_Click"/>
            </div>
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
