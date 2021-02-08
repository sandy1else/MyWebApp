<%@ Page Title="User View" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserReport.aspx.cs" Inherits="MyWebApp.CRUD.reports.UserReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">

    <script src="../../Scripts/jquery-3.5.1.min.js"></script>

    <script type="text/javascript">

        function TestJson() {

            let student = {
                name: 'John',
                age: 30,
                isAdmin: false,
                courses: ['html', 'css', 'js'],
                wife: null
            };

            let json = JSON.stringify(student);

            alert(typeof json); // we've got a string!

            alert(json);
        }

        function CallServer() {

            let student = {
                name: 'John',
                age: 30,
                isAdmin: false,
                courses: ['html', 'css', 'js'],
                wife: null
            };

            let json = JSON.stringify(student);

            alert(typeof json); // we've got a string!

            alert(json);


            var txt = "Hello";


            $.ajax({
                url: 'UserReport.aspx/LenthyProcess',
                data: "{'firstName': '" + txt + "'}",
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                beforeSend: function () {
                    Show(); // Show loader icon  
                },
                success: function (response) {
                    // Looping over emloyee list and display it 

                    alert('Success');
                    $('#lblThread').val = response.data;
                },
                complete: function () {
                    Hide(); // Hide loader icon  
                },
                failure: function (jqXHR, textStatus, errorThrown) {
                    alert("Status: " + jqXHR.status + "; Error: " + jqXHR.responseText); // Display error message  
                }
            });
        }

        function Show() {
            $('#div_Loader').show();
        }

        function Hide() {
            $('#div_Loader').hide();
        }
    </script>

</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-inline p-2">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div class="input-group">
                    <asp:Label ID="Label1" CssClass="text-light bg-dark  input-group-text" runat="server" Text="Messege"></asp:Label>
                    <asp:Label ID="lblMessege" CssClass="text-light bg-dark form-control" runat="server" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="d-flex justify-content-between">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button CssClass="btn btn-outline-secondary" ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnProcess" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:Button ID="btnProcess" CssClass="btn btn-outline-primary" runat="server" OnClientClick="CallServer();" Text="Process" OnClick="btnProcess_Click" />

        <asp:Button ID="btnSavePDF" CssClass="btn btn-outline-secondary" runat="server" Text="Save As PDF" OnClick="btnSavePDF_Click" />

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

    <div class="d-inline p-2 ">

        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnProcess" />
            </Triggers>
            <ContentTemplate>
                <div class="input-group">
                    <asp:Label ID="Label2" CssClass="text-light bg-dark input-group-text" runat="server" Text="Messege : "></asp:Label>
                    <asp:Label ID="lblProcessMessege" CssClass="text-light bg-dark form-control" runat="server" Text=""></asp:Label>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="d-inline" id="div_Loader">
        <asp:Label ID="lblThread" runat="server" CssClass="text-light bg-dark form-control" Text="Label"></asp:Label>
    </div>

    <div class="d-flex mt-4">
        <asp:Button ID="btnThread" runat="server" CssClass="btn btn-outline-primary" Text="Thread" OnClick="btnThread_Click" />
    </div>


</asp:Content>
