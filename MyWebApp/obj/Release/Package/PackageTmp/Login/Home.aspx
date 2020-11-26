<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyWebApp.Login.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/factory.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>This is Home Page</h1>
        <asp:Label ID="lblCurrentUser" runat="server" Text="User :"></asp:Label>
        <asp:Label ID="lblLoginId" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
