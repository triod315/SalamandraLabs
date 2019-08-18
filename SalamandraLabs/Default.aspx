<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SalamandraLabs.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Salmandra labs</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Allerta+Stencil"/>
        
</head>
<body>

    <div class="topnav">
        <a class="active" href="/">Home</a>
        <a href="Page.aspx?Tag=csh">C#</a>
        <a href="Page.aspx?Tag=python">Python</a>
        <a href="Page.aspx?Tag=linux">Linux/Unix</a>
        <a href="Page.aspx?Tag=cpp">C++</a>
        <a href="Page.aspx?Tag=net">Networking</a>
        <a href="Page.aspx?Tag=sp">System Programing</a>
        <a href="Page.aspx?Tag=etc">Etc</a>
        <a href="About.aspx">About</a>
        <a href="Login.aspx" style="float:right">Login</a>
    </div>

    <div class="w3-container w3-black w3-center w3-allerta">
            <p class="w3-xxxlarge" style="padding:5%;">
                Salamandra           
            </p>
          
        </div>

    <form id="form1" runat="server">
        <div>
        </div>
    </form>

</body>
</html>
