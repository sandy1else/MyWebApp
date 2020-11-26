<%@ Page Title="User View" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserReport.aspx.cs" Inherits="MyWebApp.CRUD.reports.UserReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        btn-Smoot {
            font-size: 10px;
            font-weight: bold;
        }
    </style>
    <script src="../../Scripts/jquery-3.5.1.min.js"></script>
    <%--<script src="<%=ResolveUrl("~/scripts/jquery-3.5.1.js") %>" type="text/javascript"></script> --%>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="Label1" ForeColor="Blue" Font-Bold="true" runat="server" Text="Messege : "></asp:Label>
                <asp:Label ID="lblMessege" runat="server" ForeColor="Blue" Font-Bold="true" Text=""></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnProcess" />
        </Triggers>
        <ContentTemplate>
            <div>
                <asp:Button CssClass="btn btn-primary btn-Smoot m-10" ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:Button ID="btnProcess" CssClass="btn btn-primary" runat="server" OnClientClick="CallServer();" Text="Process" OnClick="btnProcess_Click" />

    <asp:Button ID="btnSavePDF" runat="server" Text="Save As PDF" CssClass="btn btn-secondary" OnClick="btnSavePDF_Click" />

    <asp:Button ID="btnDownloadPDF" runat="server" Text="Download" CssClass="btn btn-secondary" OnClick="btnDownloadPDF_Click" />

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <center>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="80%" ProcessingMode="Local">  
                </rsweb:ReportViewer>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnProcess" />
        </Triggers>
        <ContentTemplate>
            <div>
                <asp:Label ID="Label2" ForeColor="Blue" Font-Bold="true" runat="server" Text="Messege : "></asp:Label>
                <asp:Label ID="lblProcessMessege" runat="server" ForeColor="Blue" Font-Bold="true" Text=""></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="div_Loader">
        <asp:Label ID="lblThread" runat="server" ForeColor="Red" Text="Label"></asp:Label>
    </div>

    <asp:Button ID="btnThread" runat="server" Text="Thread" OnClick="btnThread_Click"/>


</asp:Content>
