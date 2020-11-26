<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="WebSocketPage.aspx.cs" Inherits="MyWebApp.WebSocketPages.WebSocketPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            "use strict";

            if (Modernizr.websockets) {
                $("#Status").append("WebSockets is supported. Click the Connect button.");
            }

            if (!window.WebSocket && window.MozWebSocket) {
                window.WebSocket = window.MozWebSocket;
            }

            $('#connect').click(function () {
                var count;
                var connection;

                var host = "ws://localhost/SimpleEventingHandler/SimpleEventingService.ashx";
                //var host = "ws://localhost/SimpleEventingService/SimpleEventingService.svc";

                connection = new WebSocket(host);

                connection.onopen = function () {
                    $(".btn").css("color", "green");
                }

                connection.onmessage = function (message) {
                    var data = window.JSON.parse(message.data);
                    $("<li/>").html(data).appendTo($('#messages'));
                };
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Simple Event Sample</h2>
        <input type="button" id="connect" value="Connect" class="btn" />
        <p id="Status"></p>
        <ul id="messages" />
    </div>
</asp:Content>
