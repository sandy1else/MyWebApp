<%@ Page Title="Religion" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ReligionPage.aspx.cs" Inherits="MyWebApp.CRUD.ReligionPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Blue" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnRefresh" CssClass="btn btn-primary" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
    </div>

    <div class="mt-4 table-responsive">
        <asp:GridView ID="gvReligion" CssClass="table table-dark" runat="server">
        </asp:GridView>
    </div>

</asp:Content>
