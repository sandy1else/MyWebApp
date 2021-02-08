<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="MyWebApp.CRUD.MenuPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="p-5 border rounded border-light">
        <div class="d-flex">
            <div class="w-100">
                <div class="m-3">
                    <asp:TreeView ID="tvMenu" ShowExpandCollapse="true" ShowLines="true" ExpandDepth="0" OnSelectedNodeChanged="tvMenu_SelectedNodeChanged" OnTreeNodePopulate="tvMenu_TreeNodePopulate" PopulateNodesFromClient="true" runat="server"></asp:TreeView>
                </div>

                <div>
                    <asp:Label ID="lblMenuURL" runat="server" Text=""></asp:Label>
                </div>
                <div class="m-3">
                    <asp:Button ID="btnEdit" CssClass="btn btn-primary" Enabled="false" runat="server" Text="Edit" OnClick="btnEdit_Click" />
                    <asp:Button ID="btnDelete" CssClass="btn btn-danger" Enabled="false" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnAddNew" CssClass="btn btn-info" Enabled="false" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
                    <asp:Button ID="btnAddNewRoot" CssClass="btn btn-secondary" runat="server" Text="Add New Root" OnClick="btnAddNewRoot_Click" />
                </div>

                <div class="d-grid gap-2 m-3">
                    <asp:HiddenField ID="hdnParentMenuId" runat="server" Value="0" />
                    <asp:HiddenField ID="hdnMenuId" runat="server" Value="0" />
                    <asp:Label for="txtMenuName" CssClass="form-label text-light" ID="Label1" runat="server" Text="Menu Title"></asp:Label>
                    <asp:TextBox CssClass="text-light bg-dark form-control" ID="txtMenuName" runat="server"></asp:TextBox>

                </div>
                <div class="d-grid gap-2 m-3">
                    <asp:Label ID="Label2" CssClass="form-label  text-light" runat="server" Text="Menu URL"></asp:Label>
                    <asp:TextBox CssClass="text-light bg-dark form-control" ID="txtMenuURL" runat="server"></asp:TextBox>
                </div>

                <div class="d-grid gap-2 col-6 m-3">
                    <asp:Button ID="btnSave" CssClass="btn btn-info" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
            <div class="p-1 w-100" style="border-left: 1px solid #0094ff">
                <div class="d-grid gap-2 m-3">
                    <asp:Label ID="Label3" CssClass="form-label  text-light" runat="server" Text="Messege"></asp:Label>
                    <asp:TextBox CssClass="text-light bg-dark form-control" ID="txtMessage" runat="server"></asp:TextBox>
                </div>

            </div>

        </div>
    </div>

</asp:Content>
