<%@ Page Title="Gender" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="GenderPage.aspx.cs" Inherits="MyWebApp.CRUD.GenderPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <div>
         <asp:Label ID="lblMessage" runat="server" ForeColor="Blue" Text=""></asp:Label>
     </div>
    <div>
        <asp:Button ID="btnRefresh" CssClass="btn btn-primary" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
    </div>
    
    <div  class="m-4  table-responsive">
        <asp:GridView ID="gvGender" CssClass="table table-dark" runat="server" >

        </asp:GridView>
    </div>

</asp:Content>
