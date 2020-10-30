<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessorForm.aspx.cs" Inherits="ooad2020E_schedule.ProfessorForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="professorStyle1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="split left">
  <div class="centered">
    <asp:ImageButton ID="ImageButtonLeft" runat="server" CssClass ="imageButtonRight" Height="800px" Width="800px" ImageUrl="~/Images/lectures.jpg"
        OnClick="imgBtnLeft_Click"/>
       <%--
    <h2 style="color:black;font-size:120%;" >Lectures</h2>
    <p style="color:black;font-size:60%;">Click To Add Lectures</p>
           --%> 
  </div>
</div>

<div class="split right">
  <div class="centered">
      <asp:ImageButton ID="ImageButtonRight" runat="server" CssClass ="imageButtonRight" Height="800px" Width="800px" ImageUrl="~/Images/1761201.jpg"/>
    <%-- <h2 style="color:black;font-size:120%;"">Tutorials</h2>
    <p style="color:black;font-size:60%;" >Click To Add Tutorials</p> --%> 
  </div>
</div>
    </form>
</body>
</html>

