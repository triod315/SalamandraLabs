<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SalamandraLabs.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Salmandra admin</title>
    <link rel="stylesheet" href="style.css" />
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Allerta+Stencil"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>

             <div class="w3-container w3-black w3-center w3-allerta">
           
                <asp:Label ID="Label1" runat="server" Text="Label" style="display:block; margin-left:auto;margin-right:auto;text-align:center;font-size:26pt;"></asp:Label>
       
            </div>

            <div class="whoareyou">
                <asp:Label ID="Label2" runat="server" Text="Login"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                <br />
                <asp:Label ID="Label4" runat="server" Text="email"></asp:Label>
            </div>

            <div class="new_article">
                <p class="narticle">Create article</p>
                <p class="narticle">Name</p>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="crtextbox"></asp:TextBox>
                <p class="narticle">Task</p>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="crtextbox" Height="68px" TextMode="MultiLine"></asp:TextBox>

                <p class="narticle">Tag</p>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="crbutton"></asp:DropDownList>
                <p class="narticle">Solution link</p>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="crtextbox" TextMode="Url"></asp:TextBox>

                <p class="narticle">Code link</p>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="crtextbox" TextMode="Url"></asp:TextBox>

                <p class="narticle">Files link</p>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="crtextbox" TextMode="Url"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Create" CssClass="crbutton" OnClick="Button1_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
