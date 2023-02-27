<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroContactos.aspx.cs" Inherits="Interfaz.Paginas.RegistroContactos" %>

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

    <h2 class="text-center text-primary">Registro de contactos</h2>

    <div class="row">
        <div class="col-md-4">
            <label>
                Nombre:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Nombre" ID="txtNombre" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Primer Apellido:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Primer Apellido" ID="txtPrimerApellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Segundo Apellido:<br />
                <asp:TextBox runat="server" pattern="[A-Za-zÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Segundo Apellido" ID="txtSegundoApellido" />
            </label>
        </div>
        <div class="col-md-4">
            <label>
                Facebook:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Facebook" ID="txtFacebook" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Instagram:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Instagram" ID="txtInstagram" />
            </label>
        </div>

        <div class="col-md-4">
            <label>
                Twitter:<br />
                <asp:TextBox runat="server" pattern="[A-Za-z0-9ÁáÉéÍíÓóÚúÑñ]+" MaxLength="20" placeholder="Twitter" ID="txtTwitter" />
            </label>
        </div>

        <div class="col-md-12" id="telefonos" style="display: grid; justify-content: center">
            <label>
                Teléfono:                              
                 <input type="image" src="../recursos/simboloMas.png" alt="Agregar" id="btnAgregarTelefono"><br />
                <input type="text" name="ctl00$MainContent$Telefono" maxlength="20" required pattern="[+()0-9]+" placeholder="85644664" value="">
            </label>
        </div>

        <div class="col-md-12" id="correos" style="display: inline-grid; place-items: center;">
            <label>
                Correo electrónico:         
                <input type="image" src="../recursos/simboloMas.png" alt="Agregar" id="btnAgregarCorreo"><br />
                <input type="text" name="ctl00$MainContent$Correo" maxlength="20" placeholder="ejemplo@gmail.com" value="">
            </label>
        </div>

        <div class="col-md-12" style="display: flex; justify-content: center; align-content: center;">
            <asp:Button Text="Registrar" runat="server" ID="btnRegistrar" Style="margin: 12px 0px 0px 0px" />
        </div>
    </div>

    <script>

        const telefonos = document.getElementById("telefonos");
        const correos = document.getElementById("correos");
        const btnAgregarTelefono = document.getElementById("btnAgregarTelefono");
        const btnAgregarCorreo = document.getElementById("btnAgregarCorreo");

        btnAgregarTelefono.addEventListener('click', e => {
            let div = document.createElement('div');
            div.innerHTML = `<input type="text" name="ctl00$MainContent$Telefono" value="" required>
                            <input type="image" src="../recursos/borrar.png" alt="Eliminar" onclick="eliminar(this,1)">`
            div.setAttribute(
                'style',
                'display:inline-flex;align-items:center;justify-content:center;width:307px'
            );
            telefonos.appendChild(div);
        })

        btnAgregarCorreo.addEventListener('click', e => {
            let div = document.createElement('div');
            div.innerHTML = `<input type="text" name="ctl00$MainContent$Correo" value="" required>
                            <input type="image" src="../recursos/borrar.png" alt="Eliminar" onclick="eliminar(this,2)">`
            div.setAttribute(
                'style',
                'display:inline-flex;align-items:center;justify-content:center;width:307px'
            );
            correos.appendChild(div);
        })

        const eliminar = (e, num) => {
            const div = e.parentNode;
            if (num === 1) {
                telefonos.removeChild(div);
            } else {
                correos.removeChild(div);
            }

        }

    </script>

</asp:Content>
