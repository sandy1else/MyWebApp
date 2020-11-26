<%@ Page Title="User View" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserReport.aspx.cs" Inherits="MyWebApp.CRUD.reports.UserReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label1" ForeColor="Blue" Font-Bold="true" runat="server" Text="Messege : "></asp:Label>
                <asp:Label ID="lblMessege" runat="server" ForeColor="Blue" Font-Bold="true"  Text=""></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="80%" ProcessingMode="Local">  
                </rsweb:ReportViewer>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel> 

</asp:Content>
