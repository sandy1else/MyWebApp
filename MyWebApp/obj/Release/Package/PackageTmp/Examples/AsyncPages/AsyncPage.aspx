<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="AsyncPage.aspx.cs" Inherits="MyWebApp.Examples.AsyncPages.AsyncPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <script src="../../Scripts/jquery-3.5.1.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

        <asp:Button ID="btnfisrtAsync" CssClass="btn btn-primary" runat="server" Text="First" OnClick="btnfisrtAsync_Click" />

        <asp:Button ID="btnSecondAsync" CssClass="btn btn-primary" runat="server" Text="Second" OnClick="btnSecondAsync_Click" />

        <asp:Button ID="btnReset" CssClass="btn btn-info" runat="server" Text="Reset" OnClick="btnReset_Click" />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="mt-5">
                    <asp:Button ID="btnThirdAsync" CssClass="btn btn-secondary" runat="server" Text="Third" OnClick="btnThirdAsync_Click" />

                    <asp:Button ID="btnFourthAsync" CssClass="btn btn-secondary" runat="server" Text="Fourth" OnClick="btnFourthAsync_Click" />

                    <asp:Button ID="btnAllInOne" CssClass="btn btn-warning" runat="server" Text="All In One Async" OnClick="btnAllInOne_Click" />
                </div>

                <div class="mt-5">
                    <div id="showFirstDiv">
                        <asp:Label ID="lblone" runat="server" Text="One"></asp:Label>
                    </div>

                    <div id="showSecondDiv">
                        <asp:Label ID="lbltwo" runat="server" Text="Two"></asp:Label>
                    </div>
                </div>

                <div class="mt-5">
                    <div id="showThirdDiv">
                        <asp:Label ID="lblthird" runat="server" Text="Third"></asp:Label>
                    </div>

                    <div id="showFourthDiv">
                        <asp:Label ID="lblfour" runat="server" Text="Fourth"></asp:Label>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnThirdAsync" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnFourthAsync" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAllInOne" EventName="Click" />

            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div>
                    <asp:GridView ID="gvUser" runat="server"></asp:GridView>
                </div>
                <div>
                    <asp:GridView ID="gvGender" runat="server"></asp:GridView>
                </div>
                <div>
                    <asp:GridView ID="gvReligion" runat="server"></asp:GridView>
                </div>
                <div>
                    <asp:GridView ID="gvRole" runat="server"></asp:GridView>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <%--<div class="mt-5">
        <div id="showFirstDiv">
            <asp:Label ID="lblone" runat="server" Text="One"></asp:Label>
        </div>

        <div id="showSecondDiv">
            <asp:Label ID="lbltwo" runat="server" Text="Two"></asp:Label>
        </div>
    </div>--%>

    <div style="text-align: center;">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="true">
            <ProgressTemplate>
                <div class="loading-panel">
                    <div class="loading-container">
                        <img src="<%= this.ResolveUrl("~/Images/loading.gif")%>" />
                    </div>
                </div>
                <%--<img src="../../Images/loading.gif">--%>
            </ProgressTemplate>
        </asp:UpdateProgress>

    </div>

</asp:Content>
