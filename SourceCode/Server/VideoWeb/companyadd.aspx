    <%@ Page Language="C#" AutoEventWireup="true" CodeFile="companyadd.aspx.cs" Inherits="companyadd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>企业添加</title>
    <meta name="viewport" content="width=device-width,user-scalable=no"/>
    
    </head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px "> 
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px ; border-top: #000000 0px ; border-left: #000000 0px ; border-bottom: #000000 0px ;" align="center">
     <table style="width: 100%;height:100%">
     <tr style="height:150px">
       <td style="width:40px" rowspan="2">
       </td>
       <td style="width:1200px"  >
           <asp:Label ID="Label1" runat="server" Text="企业添加" Font-Bold="False" 
               Font-Names="黑体" Font-Size="XX-Large"></asp:Label>
       </td>
       <td style="width:40px" rowspan="2">
       </td>
     </tr>
      <tr style="height:400px">
       
       <td style="width:1200px"  >
           <table style="width: 1200px;height:400px">
               <tr style="height:50px;font-size: 20pt;">
                   <td style="width:200px; " align="left">
                       企业名称：
                   </td>
                   <td style="width:800px" align="left" colspan="6">
                        <asp:TextBox ID="TextBox1" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                   </td>
                   <td style="width:200px"align="left">
                       
                       <asp:Label ID="Label2" runat="server" ForeColor="Red" Height="40px" Width="180px"></asp:Label>
                   </td>
               </tr>
               <tr style="height:50px;font-size: 20pt;">
                    <td style="width:200px" align="left">
                        联系电话：
                   </td>
                   <td style="width:800px" align="left" colspan="6">
                         <asp:TextBox ID="TextBox3" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                   </td>
                   <td style="width:200px"align="left">
                       &nbsp;
                       &nbsp;
                       <asp:Label ID="Label3" runat="server" ForeColor="Red" Height="40px" Width="180px"></asp:Label>
                   </td>
               </tr>
               <tr style="height:50px;font-size: 20pt;">
                    <td style="width:200px" align="left">
                        企业简介：
                   </td>
                   <td style="width:800px" align="left" colspan="6">
                         <asp:TextBox ID="TextBox2" runat="server" Font-Size="20pt" Height="120px" 
                            Width="480px" TextMode="MultiLine"></asp:TextBox>
                   </td>
               </tr>
               <tr style="height:50px;font-size: 20pt;">
                    <td style="width:270px; " align="left" colspan="2">
                       企业图片：
                   </td>
                   <td style="width:260px" align="left" colspan="2">
                       <asp:FileUpload ID="FileUpload14" runat="server" Height="30px" Width="260px" />
                   </td>
                   <td style="width:200px"align="left">
                       
                       <asp:Label ID="Label4" runat="server" ForeColor="Red" Height="40px" Width="180px"></asp:Label>
                   </td>
               </tr>
 
               <tr style="height:50px">
                   <td colspan="8">
                       <asp:Button ID="Button1" runat="server" Text="添加" 
               style="margin-right:400px; margin-bottom:80px" Height="35px" Width="127px"
               BackColor="Transparent" Font-Size="16pt" ForeColor="Black" onmouseover="change(this)" 
                         onmouseout="rechange(this)" onclick="Button1_Click" />
                   </td>
                   
               </tr>
           </table>
      </td>
     <tr style="height:170px">
       
       <td style="width:1280px"  colspan="3" align="right">
         <asp:ImageButton ID="ImageButton1" runat="server"  OnClick="return_click" 
                       ImageUrl="./image/按键.png" Height=35px Width=127px  BackColor="Transparent" 
                       BorderWidth="0px" BorderStyle="None" onmouseover="changeImg(this)" 
                         onmouseout="rechangeImg(this)" style="margin-right:53px; margin-bottom:80px"/>
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

            btn.style.color = "Black";
        }
    </script>

    </form>
</body>
</html>
