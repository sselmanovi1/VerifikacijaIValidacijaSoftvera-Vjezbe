<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessorForm1.aspx.cs" Inherits="ooad2020E_schedule.LecturesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="ProfessorForm1.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">
        <%--
    <div class="greetingsLabelDiv">
        <asp:Label ID="greetingsLabel" runat="server" Text="  Welcome Profesorko Profesorovic" Font-Size="50px"  ></asp:Label>
    </div>
            --%> 
   <div class="split left">
  <div class="centered">
    <asp:ImageButton ID="ImageButtonLeft" runat="server" CssClass ="imageButtonLeft" Height="800px" Width="800px" ImageUrl="~/Images/lecturesBtn.jpg" OnClick="imgBtnLeft_Click"/>
       
  </div>
</div>

<div class="split right">
  <div class="centered">
      <asp:ImageButton ID="ImageButtonRight" runat="server" CssClass ="imageButtonRight" Height="800px" Width="800px" ImageUrl="~/Images/tutorialsBtn.jpg" OnClick="imgBtnRight_Click"/>
    <%--
      <h2 style="color:black;font-size:120%;"">Tutorials</h2>
    <p style="color:black;font-size:60%;" >Click To Add Tutorials</p> --%> 
  </div>
</div>
    </form>
</body>
</html>
