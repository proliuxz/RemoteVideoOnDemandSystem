<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classman.aspx.cs" Inherits="classman" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>课程管理</title>
<meta name="viewport" content="width=device-width,user-scalable=no"/>
   
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px; border-top: #000000 0px; border-left: #000000 0px; border-bottom: #000000 0px;" align="center">
     
     <table style="width: 100%;height:100%">
            <tr style="height:150px">
                <td align="center" >
                   <asp:Label ID="Label1" runat="server" Text="课程管理功能菜单" Font-Bold="True" 
                        Font-Size="35pt" ></asp:Label>
                </td>
                
               
            </tr>
            <tr style="height:100px">
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="课程添加"  Font-Size="25pt" 
                        Width="315px" onclick="Button1_Click" BackColor="Transparent" onmouseover="change(this)" onmouseout="rechange(this)" />
                </td>
            </tr>
           
            <tr style="height:100px">
                <td align="center">
                    <asp:Button ID="Button2" runat="server" Text="课程查询"  Font-Size="25pt" 
                        Width="315px" onclick="Button2_Click" BackColor="Transparent" onmouseover="change(this)" onmouseout="rechange(this)" />
                </td>    
                
                
            </tr>
           
            <tr style="height:100px">
                <td align="center">
                    <asp:Button ID="Button3" runat="server" Text="课程信息修改"  Font-Size="25pt" 
                        Width="315px" onclick="Button3_Click" BackColor="Transparent" onmouseover="change(this)" onmouseout="rechange(this)" />
                </td>
                 
                
            </tr>
          
            <tr style="height:100px">
                <td align="center">
                    <asp:Button ID="Button4" runat="server" Text="课程删除"  Font-Size="25pt" 
                        Width="315px" onclick="Button4_Click" BackColor="Transparent"  onmouseover="change(this)" onmouseout="rechange(this)"/>
                </td>
                
                
            </tr>
            <tr style="height:170px">
                <td align="right" colspan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" BackColor="Transparent" 
                        BorderStyle="None" BorderWidth="0px" Height="35px" ImageUrl="./image/按键.png" 
                        OnClick="return_click" onmouseout="rechangeImg(this)" 
                        onmouseover="changeImg(this)" style="margin-right:53px; margin-bottom:80px" 
                        Width="127px" />
                </td>
            </tr>
        </table>
    </div>
     <script type="text/javascript">
         function changeImg(btn) //鼠标移入，更换图片
         {

             btn.src = "./image/点击按键.png";
         }
         function rechangeImg(btn)  //鼠标移出，换回原来的图片
         {
             btn.src = "./image/按键.png";
         }
         function change(btn) //鼠标移入，更换图片
         {


             btn.style.color = "Blue";

         }
         function rechange(btn)  //鼠标移出，换回原来的图片
         {
             //btn.src="./image/按键.png";
             btn.style.color = "Black";
         }
       
    
    </script>
    </form>
    
</body>
</html>
