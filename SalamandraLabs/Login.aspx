<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SalamandraLabs.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Salmandra login</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Allerta+Stencil"/>
</head>
<body>

    <div class="w3-container w3-black w3-center w3-allerta">
            <p class="w3-xxxlarge">
                Salamandra login           
            </p>
    </div>

    <form id="form1" runat="server">
        <div>
            <p class="login">Login</p>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="login_textbox"></asp:TextBox>

            <p class="login">Password</p>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="login_textbox" TextMode="Password"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="login_button" OnClick="Button1_Click" />
        <hr />
        <asp:Button ID="Button2" runat="server" Text="Register" CssClass="login_button"/>
    </form>
    
   
        
</body>
</html>
