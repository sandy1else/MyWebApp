﻿<%@ Page Title="Gender" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="GenderPage.aspx.cs" Inherits="MyWebApp.CRUD.GenderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
         <asp:Label ID="lblMessage" runat="server" ForeColor="Blue" Text=""></asp:Label>
     </div>
    <div>
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
    </div>
    
    <div>
        <asp:GridView ID="gvGender" runat="server" >

        </asp:GridView>
    </div>

</asp:Content>