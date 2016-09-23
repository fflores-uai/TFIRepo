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

    <form runat="server" class="form-signin">
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
    </form>


    <div class="container">

        

    </div>

</asp:Content>