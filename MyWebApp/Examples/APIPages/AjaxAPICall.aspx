<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="AjaxAPICall.aspx.cs" Inherits="MyWebApp.Examples.APIPages.AjaxAPICall" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function LoadMenus() {
            $.ajax({
                type: "GET",
                url: 'http://localhost:81/API/Menu/Get',
                data: {},
                crossDomain: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    //alert('Startint API Call');
                },
                success: function (response) {

                    var menus = response;
                    //alert('Success API Call');
                    //Reference GridView Table.
                    var table = $("[id*=gvMenu]");

                    //Reference the Dummy Row.
                    var row = table.find("tr:last-child").clone(true);

                    //Remove the Dummy Row.
                    $("tr", table).not($("tr:first-child", table)).remove();

                    //Loop through the XML and add Rows to the Table.
                    $.each(menus, function (index, item) {

                        row += "<tr><td>" + item.Id +
                            "</td><td>" + item.ParentId +
                            "</td><td>" + item.Name +
                            "</td><td>" + item.URL +
                            "</td><td>" + item.CreatedBy +
                            "</td><td>" + item.CreatedDate +
                            "</td><td>" + item.ModifiedBy +
                            "</td><td>" + item.ModifiedDate +
                            "</td></tr>";
                        //$("td", row).eq(0).html($(this).find("Id").text());
                        //$("td", row).eq(1).html($(this).find("ParentId").text());
                        //$("td", row).eq(2).html($(this).find("Name").text());
                        //$("td", row).eq(3).html($(this).find("URL").text());
                        //$("td", row).eq(4).html($(this).find("CreatedBy").text());
                        //$("td", row).eq(5).html($(this).find("CreatedDate").text());
                        //$("td", row).eq(6).html($(this).find("ModifiedBy").text());
                        //$("td", row).eq(7).html($(this).find("ModifiedDate").text());
                        table.append(row);
                        row = table.find("tr:last-child").clone(true);
                    });
                }
            });
        }
        /*
         function LoadMenus() {
            $.ajax({
                type: "GET",
                url: 'http://localhost:81/API/Menu/Get',
                data: {},
                crossDomain: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    alert('Startint API Call');
                },
                async: true,
                success: function (response) {

                    alert('Success API Call');

                    $("#gvMenu").empty();

                    if (response.length > 0) {
                        //$("#gvMenu").append("<tr>" +
                        //    "<th>Id</th>" +
                        //    "<th>ParentId</th>" +
                        //    "<th>Name</th>" +
                        //    "<th>URL</th>" +
                        //    "<th>CreatedBy</th>" +
                        //    "<th>CreatedDate</th>" +
                        //    "<th>ModifiedBy</th>" +
                        //    "<th>ModifiedDate</th>" +
                        //    "</tr>");
                        for (var i = 0; i < response.length; i++) {

                            $("#gvMenu").append("<tr><td>" +
                                response[i].Id + "</td> <td>" +
                                response[i].ParentId + "</td> <td>" +
                                response[i].Name + "</td> <td>" +
                                response[i].URL + "</td></tr>" +
                                response[i].CreatedBy + "</td></tr>" +
                                response[i].CreatedDate + "</td></tr>" +
                                response[i].ModifiedBy + "</td></tr>" +
                                response[i].ModifiedDate + "</td></tr>");
                        }
                    }
                },
                complete: function () {
                    alert('Complete API Call');
                },
                failure: function (jqXHR, textStatus, errorThrown) {
                    alert("HTTP Status: " + jqXHR.status + "; Error Text: " + jqXHR.responseText); // Display error message
                }
            });
        }
        
        function OnSuccess(r) {
            //Parse the XML and extract the records.
            var menus = r;
            alert('Success API Call');
            //Reference GridView Table.
            var table = $("[id*=gvMenu]");

            //Reference the Dummy Row.
            var row = table.find("tr:last-child").clone(true);

            //Remove the Dummy Row.
            $("tr", table).not($("tr:first-child", table)).remove();

            //Loop through the XML and add Rows to the Table.
            $.each(menus, function () {
                var menus = $(this);
                $("td", row).eq(0).html($(this).find("Id").text());
                $("td", row).eq(1).html($(this).find("ParentId").text());
                $("td", row).eq(2).html($(this).find("Name").text());
                $("td", row).eq(3).html($(this).find("URL").text());
                $("td", row).eq(4).html($(this).find("CreatedBy").text());
                $("td", row).eq(5).html($(this).find("CreatedDate").text());
                $("td", row).eq(6).html($(this).find("ModifiedBy").text());
                $("td", row).eq(7).html($(this).find("ModifiedDate").text());
                table.append(row);
                row = table.find("tr:last-child").clone(true);
            });
        }
        
        function LoadMenus() {
            $.ajax({
                type: "POST",
                url: 'AjaxAPICall.aspx/GetMenus',
                dataType: 'json',
                data: "{'firstName': '" + null + "'}",
                contentType: 'application/json',
                beforeSend: function () {
                    alert('Start Ajax Call');
                },
                success: function (response) {
                    alert('Success Call');
                },
                complete: function () {

                },
                failure: function (jqHXR, txtStatus, errorThrown) {
                    alert(jqHXR.Status + " " + jqHXR.responseText);
                }
            });


        }
        */
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnLoad" CssClass="btn btn-info" runat="server" Text="Load Menu" OnClientClick="LoadMenus()" />
                <div class="m-4  table-responsive">
                    <asp:GridView ID="gvMenu" AutoGenerateColumns="False" CssClass="table table-dark" runat="server">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="ParentId" HeaderText="ParentId" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="URL" HeaderText="URL" />
                            <asp:BoundField DataField="CreatedBy" HeaderText="Created By" />
                            <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
                            <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" />
                            <asp:BoundField DataField="ModifiedDate" HeaderText="Modified Date" />
                        </Columns>
                    </asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
