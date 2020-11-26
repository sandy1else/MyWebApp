<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="MyWebApp.CRUD.MenuPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:TreeView ID="tvMenu" ShowExpandCollapse="true" ShowLines="true" ExpandDepth="0" OnSelectedNodeChanged="tvMenu_SelectedNodeChanged" OnTreeNodePopulate="tvMenu_TreeNodePopulate" PopulateNodesFromClient="true" runat="server"></asp:TreeView>
    </div> 

    <div>
        <asp:Label ID="lblMenuURL" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnEdit" Enabled="false" runat="server" Text="Edit" OnClick="btnEdit_Click" />
        <asp:Button ID="btnDelete" Enabled="false" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnAddNew" Enabled="false" runat="server" Text="Add New" OnClick="btnAddNew_Click" />
        <asp:Button ID="btnAddNewRoot" runat="server" Text="Add New Root" OnClick="btnAddNewRoot_Click" />
    </div>

    <div>
        <asp:HiddenField ID="hdnParentMenuId" runat="server" Value="0" />
        <asp:HiddenField ID="hdnMenuId" runat="server" Value="0" />
        <asp:Label ID="Label1" runat="server" Text="Menu Title"></asp:Label>
        <asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>

    </div>
    <div>
        <asp:Label ID="Label2" runat="server" Text="Menu URL"></asp:Label>
        <asp:TextBox ID="txtMenuURL" runat="server"></asp:TextBox>
    </div>

    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
</asp:Content>
