<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Practive.aspx.cs" Inherits="MyWebApp.Practive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<!-- For the hover styles of the Menu control to  -->
<!-- work correctly, you must include this head   -->
<!-- element.                                     -->
<head runat="server">
    <title>Menu DynamicHoverStyle Example</title>
</head>

<body>
    <form id="form1" runat="server">

        <h3>Menu DynamicHoverStyle Example</h3>

        <asp:Menu ID="NavigationMenu"
            StaticDisplayLevels="2"
            StaticSubMenuIndent="10"
            Orientation="Vertical"
            Target="_blank"
            runat="server">

            <DynamicHoverStyle BackColor="LightSkyBlue"
                ForeColor="Black" />
            <DynamicMenuItemStyle BackColor="LightSkyBlue"
                ForeColor="Black"
                BorderStyle="Solid"
                BorderWidth="1"
                BorderColor="Black" />
            <DynamicMenuStyle BackColor="LightSkyBlue" CssClass="dmenu" />
            <Items>
                <asp:MenuItem NavigateUrl="Home.aspx"
                    Text="Home"
                    ToolTip="Home">
                    <asp:MenuItem NavigateUrl="Music.aspx"
                        Text="Music"
                        ToolTip="Music">
                        <asp:MenuItem NavigateUrl="Classical.aspx"
                            Text="Classical"
                            ToolTip="Classical" />
                        <asp:MenuItem NavigateUrl="Rock.aspx"
                            Text="Rock"
                            ToolTip="Rock" />
                        <asp:MenuItem NavigateUrl="Jazz.aspx"
                            Text="Jazz"
                            ToolTip="Jazz" />
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Movies.aspx"
                        Text="Movies"
                        ToolTip="Movies">
                        <asp:MenuItem NavigateUrl="Action.aspx"
                            Text="Action"
                            ToolTip="Action" />
                        <asp:MenuItem NavigateUrl="Drama.aspx"
                            Text="Drama"
                            ToolTip="Drama" />
                        <asp:MenuItem NavigateUrl="Musical.aspx"
                            Text="Musical"
                            ToolTip="Musical" />
                    </asp:MenuItem>
                </asp:MenuItem>
            </Items>

        </asp:Menu>

    </form>
</body>
</html>
