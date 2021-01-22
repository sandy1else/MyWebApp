<%@ Page Title="Login beta" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyWebApp.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
     
    <!-- Bootstrap core CSS -->
    <link href="assets/dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Favicons -->

    <meta name="theme-color" content="#7952b3">
    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
    <!-- Custom styles for this template -->
    <link href="Content/Custom/signin.css" rel="stylesheet" />
</head>
<body class="text-center">

    <main class="form-signin">
        <form runat="server">

            <img class="mb-4" src="./Images/Login.svg" alt="" width="72" height="57">
            <h1 class="h3 mb-3 fw-normal">Please Log In</h1>
            <label for="inputEmail" class="visually-hidden">Email address</label>
            <input runat="server" type="text" id="inputEmail" class="form-control" placeholder="Email address" required="" autofocus="">
            <label for="inputPassword" class="visually-hidden">Password</label>
            <input runat="server" type="password" id="inputPassword" class="form-control" placeholder="Password" required="">
            <div class="checkbox mb-3">
                <label>
                    <input runat="server" id="chkRemember" type="checkbox" value="remember-me">
                    Remember me
               
                </label>
            </div>
            <button runat="server" class="w-100 btn btn-lg btn-primary" onserverclick="btnLogin_Click" type="submit">Log In</button>
            <p class="mt-5 mb-3 text-muted">© 2017-2020</p>

        </form>
    </main>

</body>
</html>
