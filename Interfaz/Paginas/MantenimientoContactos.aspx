<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoContactos.aspx.cs" Inherits="Interfaz.Paginas.MantenimientoContactos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

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
            </div>

            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />

            <input id="btnAgregar1" type="button" value="Agregar" />
            <div id="telefonos">                
            </div>

            <div>
                <input type="text" name="ctl00$MainContent$id" value="Hola" required>
                <input type="text" name="ctl00$MainContent$id" value="Holis" required>
                <input type="text" name="ctl00$MainContent$id" value="Bren" required>
            </div>
        </div>
    </div>

    <script>

        const telefonos = document.getElementById("telefonos");
        const btnAgregar = document.getElementById("btnAgregar1");

        btnAgregar.addEventListener('click', e => {
            let div = document.createElement('div');
            div.innerHTML = `<input type"text" name="ctl00$MainContent$id" value="" required`
            telefonos.appendChild(div);
        })


    </script>

</asp:Content>
