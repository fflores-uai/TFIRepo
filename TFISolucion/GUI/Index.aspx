﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TFI.GUI.WebForm1pru" %>

<%@ Register Assembly="ServerControl1" Namespace="ServerControl1" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>

    

    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="true" />
    <asp:SiteMapPath ID="SiteMapPathHome" runat="server" PathSeparator=" > " RenderCurrentNodeAsLink="false">
    </asp:SiteMapPath>

    <form id="form1" runat="server">
    </form>
</body>
</html>