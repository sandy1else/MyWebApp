<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="AjaxAPICallJSON.aspx.cs" Inherits="MyWebApp.Examples.APIPages.AjaxAPICallJSON" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function LoadMenus() {
            $.ajax({
                type: "GET",
                url: 'http://localhost:81/API/Menu/GetJSOMMenus',
                data: {},
                crossDomain: true,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                beforeSend: function () {
                    //alert('Startint API Call');
                },
                success: function (response) {

                    var menus = $.parseJSON(response);;
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
