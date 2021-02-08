<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyWebApp.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5 text-center text-light">
        <h1>Topic that i try to cover in this projects are below</h1>
    </div>
    <div class="container px-4 px-md-3 text-center">
        <div class="col-md-8 order-md-1 col-lg-7 text-center text-md-start text-light">
            <h1 class="mb-3">Development Tools that i use</h1>
            <p class="lead mb-4  text-light">
                Integrated development environment(IDE) - Visual Studio Community 2019 - Free.<br />
                Relational Database Management System(RDBMS) - SQL Server 2019 Developer.<br />
                Programming Language - C#<br />
                Software Framework - .Net<br />
                Web Server - Internet Information Services 10(IIS)
            </p>

            <p class="lead mb-4  text-light">
                Login.<br />
                Dynamic Hoverable Menu.
                <br />
                Basic RDLC report.<br />
                Session Management.<br />
                Password Encryption.<br />
                Type serilization.<br />
                Using Microsoft Enterprise Library to Data Access from DB.<br />
                Caching for frequent data access.<br />
            </p>
            <h1 class="mb-3">ASP.Net Session State Management</h1>
            <p class="lead mb-4  text-light">
                In-Process Mode<br />
                <p class="ms-3 p-3 mt-n3 rounded tbc-purple">Objects stored in session state must be serializable if the mode is SQL Server. For information on serializable objects, see the SerializableAttribute class</p>
                SQL Server Mode<br />
                <p class="ms-3 p-3 mt rounded tbc-purple">Objects stored in session state must be serializable if the mode is SQL Server. For information on serializable objects, see the SerializableAttribute class</p>
                SQL Server Mode
            </p>
            <h1 class="mb-3">Dependency Injection</h1>
            <p class="lead mb-4  text-light">
                Constructor Injection<br />
                <p class="ms-3 p-3 mt-n3 rounded tbc-purple"></p>
                Setter Injection<br />
                <p class="ms-3 p-3 rounded tbc-purple"></p>
                Interface Injection
            </p>
            <h1 class="mb-3">Serialization</h1>
            <p class="lead mb-4  text-light">
                JSON- JavaScript Object Notation Serialization<br />
                <p class="ms-3 p-3 mt-n3 rounded tbc-purple"></p>
                Binary or XML Serialization<br />
                <p class="ms-3 p-3 mt-n3 rounded tbc-purple"></p>
            </p>
            <h1 class="mb-3">Feature</h1>
            <h1 class="mb-3">Login</h1>
            <p class="lead mb-4  text-light">
                A set of login Id & password is used to login to this web application. Password is encrypted and stored in the sql server 2019. 
            </p>

        </div>

    </div>

</asp:Content>
