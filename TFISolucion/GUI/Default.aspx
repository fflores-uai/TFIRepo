<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TFI.GUI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script src="Scripts/thirdparty/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">

    <input id="lblNombre" value="nombre" runat="server"/>

    <label id="lblIngles" runat="server">Nombre</label>
</asp:Content>