<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessorTutorialsForm.aspx.cs" Inherits="ooad2020E_schedule.ProfessorTutorialsForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="TutorialsStyleProf.css" rel="stylesheet" />
    <style type="text/css">
        #inputNumberTutorials {
            width: 67px;
            height: 35px;
            margin-left: 10px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">

    <div>

    </div>
    
    <div class="courseSelection">
        <asp:Label ID="selectCourseLabel" runat="server" Text="Select Course:"  Height="35px" Width="300px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="33px" style="margin-left: 40px" ></asp:Label>
        <asp:DropDownList ID="selectCourseListView" runat="server" Width="172px" Height="35px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="33px" style="margin-left: 92px">
            <asp:ListItem>OOAD</asp:ListItem>
            <asp:ListItem>AFJ</asp:ListItem>
            <asp:ListItem>IEK</asp:ListItem>
        </asp:DropDownList>
    </div>
        
    <div class="numberSelection">
        <asp:Label ID="selectNumberLabel" runat="server" Text="Insert Number of tutorials:"  Height="35px" Width="384px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="33px" style="margin-left: 40px" ></asp:Label>
        <input id="inputNumberTutorials" type="text"  />
        <asp:Button ID="saveNumberBtn" runat="server" style="margin-left: 24px" Text="Save" Height="41px" BackColor="White" Font-Bold="True" Font-Names="Times New Roman" Width="73px" />
    </div>

    <div class="dayTimeCourseLabels">
       <asp:Label ID="dayLabel" runat="server" Text="Day"  Height="50px" Width="56px" Font-Bold="True" Font-Italic="True" Font-Names="Times New Roman" Font-Size="50px" style="margin-left: 410px" Font-Underline="True" ></asp:Label>
        <asp:Label ID="timeLabel" runat="server" Text="Time"  Height="50px" Width="56px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="50px" style="margin-left: 410px"  Font-Underline="True"></asp:Label>
        <asp:Label ID="Label1" runat="server" Text="Course"  Height="50px" Width="56px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="50px" style="margin-left: 410px"  Font-Underline="True"></asp:Label>

    </div>

    <div class="dayTimeCourseListViews">

        <asp:RadioButtonList ID="RadioButtonListDays" runat="server" Height="35px" Font-Bold="True" Font-Names="Times New Roman"
            Font-Size="40px" style="margin-left: 334px; margin-top:50px;  text-align:center"  >
            <asp:ListItem>Monday</asp:ListItem>
            <asp:ListItem>Tuesday</asp:ListItem>
            <asp:ListItem>Wednesday</asp:ListItem>
            <asp:ListItem>Thursday</asp:ListItem>
            <asp:ListItem>Friday</asp:ListItem>
            <asp:ListItem>Saturday</asp:ListItem>
            <asp:ListItem>Sunday</asp:ListItem>
        </asp:RadioButtonList>

    </div>
    </form>
</body>
</html>