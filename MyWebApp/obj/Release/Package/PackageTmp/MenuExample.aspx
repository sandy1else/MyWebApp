<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuExample.aspx.cs" Inherits="MyWebApp.MenuExample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<!-- For the hover styles of the Menu control to  -->
<!-- work correctly, you must include this head   -->
<!-- element.                                     -->
<head runat="server">
    <title>Menu Declarative Example</title>
</head>

<body>
    <form id="form1" runat="server">

        <h3>Menu Declarative Example</h3>

        <!-- Use declarative syntax to create the   -->
        <!-- menu structure. Submenu items are      -->
        <!-- created by nesting them in parent menu -->
        <!-- items.                                 -->
        <asp:Menu ID="NavigationMenu"
            DisappearAfter="5000"
            StaticDisplayLevels="1"
            MaximumDynamicDisplayLevels="4"
            StaticSubMenuIndent="10"
            Orientation="Horizontal"
            Font-Names="Arial"
            Target="_blank"
            runat="server">

            <StaticMenuItemStyle BackColor="LightSteelBlue"
                ForeColor="Black" />
            <StaticHoverStyle BackColor="Red" />
            <DynamicMenuItemStyle BackColor="Black"
                ForeColor="Silver" />
            <DynamicHoverStyle BackColor="LightSkyBlue"
                ForeColor="Black" />

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
                            ToolTip="Jazz">
                            <asp:MenuItem NavigateUrl="JazzOne.aspx"
                                Text="Jazz One"
                                ToolTip="Jazz One">
                                <asp:MenuItem NavigateUrl="JazzChildOne.aspx"
                                    Text="Jazz Child One"
                                    ToolTip="Jazz Child One" />
                                <asp:MenuItem NavigateUrl="JazzChildTwo.aspx"
                                    Text="Jazz Child Two"
                                    ToolTip="Jazz Child Two" />
                                <asp:MenuItem NavigateUrl="JazzChildThree.aspx"
                                    Text="Jazz Child Three"
                                    ToolTip="Jazz Child Three" />
                            </asp:MenuItem>
                        </asp:MenuItem>
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
