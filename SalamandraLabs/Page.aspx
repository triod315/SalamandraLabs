﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="SalamandraLabs.Page" %>

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
        <a href="/">Home</a>
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
            <!--<p class="w3-xxxlarge">
                Salamandra           
            </p>-->
        <asp:Label ID="Label1" runat="server" Text="Label" style="display:block; margin-left:auto;margin-right:auto;text-align:center;font-size:26pt;"></asp:Label>
       
            <!--<p class="w3-xxlarge">
                The web site is under construction
            </p>
            <p class="w3-xlarge">
                triod315@gmail.com
            </p>-->
        </div>


    <form id="form1" runat="server">
        <div class="w3-container w3-black w3-center w3-allerta">
            <asp:Label ID="Label2" runat="server" Text="Salamandra" CssClass="w3-xxlarge" style="padding-bottom:2%;"></asp:Label>
        </div>
    </form>

    
</body>
</html>
