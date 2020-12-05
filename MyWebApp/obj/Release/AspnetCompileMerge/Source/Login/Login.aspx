<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyWebApp.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../CSS/main.css" rel="stylesheet" />
    <link href="../CSS/factory.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.5.1.js"></script>
    <script src="../js/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="limiter">
            <div class="container-login100" style="background-color: lightgrey">
                <div class="wrap-login100 p-l-110 p-r-110 p-t-62 p-b-33">
                    <div class="login100-form validate-form flex-sb flex-w">
                        <div class="login100-form-title">
                            <asp:Label ID="Label1" CssClass="login100-form-title" runat="server" Text="Sign In"></asp:Label>
                        </div>
                        <div class="p-t-31 p-b-9">
                            <asp:Label ID="Label2" CssClass="txt1" runat="server" Text="LoginId"></asp:Label>
                        </div>
                        <div class="wrap-input100 validate-input">
                            <asp:TextBox CssClass="input100" ID="txtLoginId" runat="server"></asp:TextBox>
                        </div>
                        <div class="p-t-13 p-b-9">
                            <asp:Label ID="Label3" CssClass="txt1" runat="server" Text="Password"></asp:Label>
                            <a class="txt2 bo1 m-l-5">Forgot?</a>
                        </div>
                        <div class="wrap-input100 validate-input">
                            <asp:TextBox CssClass="input100" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="container-login100-form-btn m-t-17">
                            <asp:Button ID="btnLogin" CssClass="login100-form-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                        <div class="container-login100-form-btn m-t-17">
                            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </div>
                        <div class="w-full text-center p-t-55">
                            <span class="txt2">Not a member?</span>
                            <a class="txt2 bo1">Sign up now</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
