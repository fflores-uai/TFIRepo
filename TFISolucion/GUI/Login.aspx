<%@ Page
    Title="Login Page"
    Language="C#"
    MasterPageFile="~/Shared/Layout.Master"
    AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="TFI.GUI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <div class="container">

        <form class="form-signin" runat="server">
            <h2 class="form-signin-heading">INGRESO</h2>

            <label for="inputEmail" class="sr-only">Usuario/Email</label>
            <input type="email" id="inputEmail" class="form-control" placeholder="Usuario/Email" required="" autofocus="" />

            <label for="inputPassword" class="sr-only">Clave</label>
            <input type="password" id="inputPassword" class="form-control" placeholder="Clave" required="" />

            <div class="checkbox">
                <label>
                    <input type="checkbox" value="remember-me" />
                    Recordar
                </label>
            </div>
            <div>
                <p>Olvidaste tu Clave? <a href="#">Click Aqui</a></p>
                <p>Nuevo en el sitio? <a href="#">Registrate</a></p>
            </div>
            <asp:Button ID="btn" CssClass="btn btn-lg btn-primary btn-block" Text="Ingresar" OnClick="btnSubmit_Click" runat="server" />
            <%--<asp:Button ID="btnSubmit" CssClass="btn btn-lg btn-primary btn-block" type="text" runat="server">Ingresar</asp:Button>--%>
        </form>
    </div>

    <%-- <form runat="server" class="form-signin">
        <div class="container">

            <label for="bodyContent_txtUser" class="sr-only">User Name</label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" />
            <br />
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" />
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Accept" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        </div>
    </form>--%>

    <div class="container">
    </div>
</asp:Content>