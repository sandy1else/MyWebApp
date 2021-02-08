<%@Page Title="" Async="true" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="HTTPClientAPICall.aspx.cs" Inherits="MyWebApp.Examples.APIPages.HTTPClientAPICall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <asp:Button ID="btnLoad" CssClass="btn btn-info" runat="server" Text="Load Menu" OnClick="btnLoad_Click" />
        <div class="m-4  table-responsive">
            <asp:GridView ID="gvMenu" CssClass="table table-dark"  runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
