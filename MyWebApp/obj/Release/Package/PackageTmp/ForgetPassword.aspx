<%@ Page Title="Forget Password" Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="MyWebApp.ForgetPassword" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap core CSS -->
    <link href="assets/dist/css/bootstrap.css" rel="stylesheet" />
    <!-- Favicons -->

    <meta name="theme-color" content="#7952b3">
    <!-- Custom styles for this template -->
    <link href="Content/Custom/signin.css" rel="stylesheet" />

</head>
<body class="text-left">
    <main class="forget-pass">
        <form runat="server">
            <div class="">
                <div class="dialog">
                    <div class="">
                        <div class="header mb-4">
                            <h1 class="h2 mb-2">First, let's find your account</h1>
                            <h5 class="">Please enter your email or phone</h5>
                        </div>
                        <div class="body">
                            <label for="inputEmail" class="form-label">Email address</label>
                            <input type="email" runat="server" class="form-control" id="inputEmail" placeholder="name@example.com">
                        </div>
                        <div class="footer mt-5 col-auto">
                            <button type="button" class="btn btn-outline-secondary mr-8" runat="server" onserverclick="btnCancel_Click" data-bs-dismiss="">Cancel</button>
                            <button type="button" class="btn btn-primary" runat="server" onserverclick="findAccound_Click" >Find Account</button>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </main>
</body>
</html>
