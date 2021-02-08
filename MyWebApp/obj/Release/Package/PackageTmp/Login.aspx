<%@ Page Title="Login beta" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyWebApp.Login" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap core CSS -->
    <link href="assets/dist/css/bootstrap.css" rel="stylesheet" />
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
    <script type="text/javascript">
        (function () {
            'use strict'

            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }

                        form.classList.add('was-validated')
                    }, false)
                })
        })()
    </script>
    <!-- Custom styles for this template -->
    <link href="Content/Custom/signin.css" rel="stylesheet" />

</head>
<body>
    <main class="form-signin">
        <h1 class="h4 fw-normal fw-bold mb-4 text-bule text-left">Web
            <span class="app">APP</span>
        </h1>
        <div class="loginDiv">
            <form runat="server" class="needs-validation" novalidate>

                <%--<img class="mb-4" src="./Images/Login.svg" alt="" width="72" height="57">--%>
                <h1 class="h3 fw-normal fw-bold">Sign in</h1>
                <p class="text-left">Stay updated on your professional world</p>
                <div class="form-floating mt-4 mb-3">
                    <input type="email" class="form-control" id="inputEmail" runat="server" placeholder="name@example.com" required>
                    <label for="inputEmail">Email address</label>
                    <div class="invalid-feedback">
                        Please provide a valid Id.
                    </div>
                </div>
                <div>
                </div>
                <div class="form-floating">
                    <input type="password" class="form-control" id="inputPassword" runat="server" placeholder="Password" required>
                    <label for="inputPassword">Password</label>
                    <div class="invalid-feedback">
                        Please provide a valid Password.
                    </div>
                </div>
                <div>
                </div>
                <div class="mt-3 mb-3 text-left fw-mid">
                    <a id="fp" href="ForgetPassword.aspx">Forget password?</a>
                </div>
                <button runat="server" class="w-100 btn btn-lg btn-primary br-28" onserverclick="btnLogin_Click" type="submit">Sign in</button>

            </form>

        </div>

        <p class="mt-5 text-muted text-center">© 2017-2020</p>

    </main>
</body>
</html>
