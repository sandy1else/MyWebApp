<%@ Page Title="Menu Report" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="MenuReport.aspx.cs" Inherits="MyWebApp.CRUD.reports.MenuReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-inline p-2">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="input-group">
                    <asp:Label ID="Label1" CssClass="text-light bg-dark input-group-text" runat="server" Text="Messege"></asp:Label>
                    <asp:Label ID="lblMessege" CssClass="text-light bg-dark form-control" runat="server" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="d-flex justify-content-between">

        <asp:Button CssClass="btn btn-outline-secondary" ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />

        <asp:Button ID="btnDownloadPDF" CssClass="btn btn-bd-primary" runat="server" Text="Download" OnClick="btnDownloadPDF_Click" />

    </div>

    <div class="m-auto mt-md-2 table table-secondary">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <center>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ProcessingMode="Local">  
                </rsweb:ReportViewer>
            </center>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>



</asp:Content>
