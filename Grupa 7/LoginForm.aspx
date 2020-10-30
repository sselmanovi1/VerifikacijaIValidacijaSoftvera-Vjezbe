<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ooad2020E_schedule.LoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
    </head>
<body>

    <div class="title">
        <h1>E-Schedule</h1>
    </div>
    

   <div class="loginbox" >
        <img src="Images/user.png" alt="Alternate text" class="user"/>
       <h2>Log In Here</h2>
        <form runat="server">
            <asp:Label Text="Username" CssClass="lblusername" runat="server" ID="userameLabel" />
            <asp:TextBox runat="server" CssClass="txtusername" placeholder ="Enter Username" ID="userameTextBox" />
            <asp:Label Text="Password" CssClass="lblpass" runat="server" ID="passwordLabel"/>
            <asp:TextBox runat="server" CssClass="txtpass" placeholder ="**********" TextMode="Password" ID="passwordTextBox" />
            <asp:Button Text="Sign in" CssClass ="btnsubmit" runat="server" ID="signInBtn" OnClick="signInBtn_Click"/>
            <asp:LinkButton Text="Forget Password" CssClass="btnForget" runat="server" ID="forgetLinkBtn"/>
            <asp:Label Text="Incorrect User Credentials" CssClass="lblincorrect" runat="server" ID="incorrectLabel" ForeColor="Red" />
            
        </form>
   </div>
</body>
</html>
