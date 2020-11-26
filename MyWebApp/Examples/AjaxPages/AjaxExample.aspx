<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="AjaxExample.aspx.cs" Inherits="MyWebApp.Examples.AjaxPages.AjaxExample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="../../Scripts/jquery-3.5.1.min.js"></script>

    <script type="text/javascript">
        function FirstF() {
            var txt = "Sandip";

            alert('First Ajax Call');
            $.ajax({
                url: 'AjaxExample.aspx/LoadFirst',
                type: 'POST',
                dataType: 'json',
                data: "{'firstName': '" + null + "'}",
                contentType: 'application/json',
                beforeSend: function () {

                },
                success: function (response) {

                    alert('Success First');
                },
                complete: function () {

                },
                failure: function (jqHXR, txtStatus, errorThrown) {
                    alert(jqHXR.Status + " " + jqHXR.responseText);
                }
            });


        }



        function SecondF() {
            var txt = "Kabiraz";

            alert('Second Ajax Call');
            $.ajax({
                url: 'AjaxExample.aspx/LoadSecond',
                type: 'POST',
                dataType: 'json',
                data: "{'firstName': '" + null + "'}",
                contentType: 'application/json',
                beforeSend: function () {

                },
                success: function (response) {

                    alert('Success Second');
                },
                complete: function () {

                },
                failure: function (jqHXR, txtStatus, errorThrown) {
                    alert(jqHXR.Status + " " + jqHXR.responseText);
                }
            });


        }

        function ThirdF() {
            var txt = "Somthing";

            alert('Third Ajax Call');
            $.ajax({
                url: 'AjaxExample.aspx/LoadThird',
                type: 'POST',
                dataType: 'json',
                data: "{'firstName': '" + null + "'}",
                contentType: 'application/json',
                beforeSend: function () {

                },
                success: function (response) {
                    alert('Success Third');
                },
                complete: function () {

                },
                failure: function (jqHXR, txtStatus, errorThrown) {
                    alert(jqHXR.Status + " " + jqHXR.responseText);
                }
            });


        }

        function FourF() {
            var txt = "Somthing";

            alert('Four Ajax Call');
            $.ajax({
                url: 'AjaxExample.aspx/LoadFour',
                type: 'POST',
                dataType: 'json',
                data: "{'firstName': '" + null + "'}",
                contentType: 'application/json',
                beforeSend: function () {

                },
                success: function (response) {
                    alert('Success Four');
                },
                complete: function () {

                },
                failure: function (jqHXR, txtStatus, errorThrown) {
                    alert(jqHXR.Status + " " + jqHXR.responseText);
                }
            });


        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="margin: 10px;">
                    <asp:Button ID="btnFirst" CssClass="btn btn-info" runat="server" Text="First Process" OnClientClick="FirstF();" />

                    <asp:Button ID="btnSecond" CssClass="btn btn-info" runat="server" Text="Second Process" OnClientClick="SecondF();" />

                    <asp:Button ID="btnThird" CssClass="btn btn-info" runat="server" Text="Third Process" OnClientClick="ThirdF();" />

                    <asp:Button ID="Button1" CssClass="btn btn-info" runat="server" Text="Four Process" OnClientClick="FourF();" />
                </div>

                <div id="firstDiv">
                    <asp:Label ID="lblOne" runat="server" Text="Label"></asp:Label>
                </div>

                <div id="secondDiv">
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
