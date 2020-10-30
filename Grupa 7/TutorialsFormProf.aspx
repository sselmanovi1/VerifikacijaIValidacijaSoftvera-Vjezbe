<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorialsFormProf.aspx.cs" Inherits="ooad2020E_schedule.TutorialsFormProf" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

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
    <style type="text/css">
        #RadioButtonListDays {
            font-size: 35px;
            text-align: center; 
        }
    </style>
    <style>  
            #leftbox { 
                float:left;  
                width:33%; 
                height:280px; 
            } 
            #middlebox{ 
                float:left;  
                width:33%; 
                height:280px; 
            } 
            #rightbox{ 
                float:right; 
                width:33%; 
                height:280px; 
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
        <asp:Image ID="profilePicture" runat="server" ImageUrl="~/Images/profilePicture.png"  Height="50px"  Width="50px" style="margin-left: 65%" />
    </div>
        
    <div class="numberSelection">
        <asp:Label ID="selectNumberLabel" runat="server" Text="Insert Number of tutorials:"  Height="35px" Width="384px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="33px" style="margin-left: 40px" ></asp:Label>
        <asp:TextBox ID="textBoxNumber" runat="server" Width="68px" style="margin-left: 8px" ></asp:TextBox>
        <asp:Button ID="saveNumberBtn" runat="server" style="margin-left: 24px; margin-top: 0px;" Text="Save" Height="41px" BackColor="White" Font-Bold="True" Font-Names="Times New Roman" Width="73px" OnClick="saveNumberBtn_Click" />
        
    </div>

    <div class="dayTimeCourseLabels">
       <asp:Label ID="dayLabel" runat="server" Text="Day"  Height="50px" Width="56px" Font-Bold="True" Font-Italic="True" Font-Names="Times New Roman" Font-Size="50px" style="margin-left: 410px" Font-Underline="True" ></asp:Label>
        <asp:Label ID="timeLabel" runat="server" Text="Time"  Height="50px" Width="56px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="50px" style="margin-left: 450px"  Font-Underline="True"></asp:Label>
        <asp:Label ID="classroomLabel" runat="server" Text="Classroom"  Height="50px" Width="56px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Font-Size="50px" style="margin-left: 384px"  Font-Underline="True"></asp:Label>

    </div>

    <div id = "boxes"> 
            <div id = "leftbox"> 
                <asp:RadioButtonList ID="RadioButtonListDays" runat="server" Height="35px" Font-Bold="True" Font-Names="Times New Roman"
                    Font-Size="40px" style="margin-left: 335px; margin-top:50px;  text-align:center"  >
                    <asp:ListItem>Monday</asp:ListItem>
                    <asp:ListItem>Tuesday</asp:ListItem>
                    <asp:ListItem>Wednesday</asp:ListItem>
                    <asp:ListItem>Thursday</asp:ListItem>
                    <asp:ListItem>Friday</asp:ListItem>
                    <asp:ListItem>Saturday</asp:ListItem>
                    <asp:ListItem>Sunday</asp:ListItem>
                </asp:RadioButtonList>
            </div>  
              
            <div id = "middlebox"> 
                <asp:RadioButtonList ID="RadioButtonListTimes" runat="server" Height="35px" Font-Bold="True" Font-Names="Times New Roman"
                    Font-Size="40px" style="margin-left: 279px; margin-top:50px;  text-align:center"  >
                    <asp:ListItem>09:00</asp:ListItem>
                    <asp:ListItem>10:00</asp:ListItem>
                    <asp:ListItem>11:00</asp:ListItem>
                    <asp:ListItem>12:00</asp:ListItem>
                    <asp:ListItem>13:00</asp:ListItem>
                    <asp:ListItem>14:00</asp:ListItem>
                    <asp:ListItem>15:00</asp:ListItem>
                    <asp:ListItem>16:00</asp:ListItem>
                    <asp:ListItem>17:00</asp:ListItem>
                    <asp:ListItem>18:00</asp:ListItem>
                    <asp:ListItem>19:00</asp:ListItem>
                </asp:RadioButtonList>
            </div> 
              
            <div id = "rightbox"> 
            <asp:RadioButtonList ID="RadioButtonListClassrooms" runat="server" Height="35px" Font-Bold="True" Font-Names="Times New Roman"
                Font-Size="40px" style="margin-left: 152px; margin-top:50px;  text-align:center"  >
                <asp:ListItem>S1</asp:ListItem>
                <asp:ListItem>S2</asp:ListItem>
                <asp:ListItem>S3</asp:ListItem>
                <asp:ListItem>S4</asp:ListItem>
                <asp:ListItem>S5</asp:ListItem>
                <asp:ListItem>S6</asp:ListItem>
                <asp:ListItem>S7</asp:ListItem>
            </asp:RadioButtonList> 
            </div> 
        </div> 
         <div class="nextDiv" style="margin-left: 950px; margin-top:33%">
                    <asp:Label ID="numberOfFinishedLabel" runat="server" Text="m/n" 
                        Height="35px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="40px" ></asp:Label>
                    <asp:Button ID="btnNext" runat="server" Text="Next" Height="41px" 
                    Width="101px" Font-Bold="True" Font-Names="Times New Roman" Font-Size="30px" 
                        OnClick="btnNext_Click" style="margin-left: 772px" CausesValidation="False"/>
        </div>
    </form>
</body>
</html>

