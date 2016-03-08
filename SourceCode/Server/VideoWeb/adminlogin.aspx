
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理员登录</title>
 <meta name="viewport" content="width=device-width,user-scalable=no"/>
    <style type="text/css">
        .style1
        {
            width: 331px;
        }
    </style>
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px; border-top: #000000 0px; border-left: #000000 0px; border-bottom: #000000 0px;" align="center">
     
        <table style="width: 100%;height:100%">
            <tr style="height:35%; width:100%">
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="视频商城管理员登录" Font-Bold="True" 
                        Font-Size="42pt"></asp:Label>
                </td>
               
            </tr>
            <tr style="height:40%; width:100%">
                <td align="center">
                    <table style="width: 80%; height:70%">
                        <tr>
                            <td width="40%" >
                                <asp:Label ID="Label2" runat="server" Text="用户名" Font-Size="26pt"></asp:Label>
                               
                            </td>
                            <td class="style1" >
                                
                                <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="215px" 
                                    OnTextChanged="usercha" Font-Size="20pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Size="18pt" Text=" " 
                                    ForeColor="#FF0066" Width="250px"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="Label3" runat="server" Text="密码" Font-Size="26pt"></asp:Label>
                                
                            </td>
                            <td class="style1" >
                                <asp:TextBox ID="TextBox2" runat="server" Height="38px" Width="215px" OnTextChanged="passcha"  Font-Size="20pt" TextMode="Password"></asp:TextBox>
                                
                            </td>
                            <td>
                               
                                <asp:Label ID="Label5" runat="server" Font-Size="18pt" Text=" " 
                                    Width="250px" ForeColor="#FF0066"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                 <asp:Button ID="Button1" runat="server" Text="注册" Font-Size="26pt" 
                                    Height="46px" Width="125px"  OnClick="regis" onmouseout="rechange(this)" 
                        onmouseover="change(this)"/>
                            </td>
                            <td class="style1" >
                                <asp:Button ID="Button2" runat="server" Text="登陆" Font-Size="26pt" 
                                    Height="46px" Width="125px"  OnClick="usrlogin" onmouseout="rechange(this)" 
                        onmouseover="change(this)"/>
                            </td>
                            <td>
                                &nbsp;
                               
                            </td>
                        </tr>
                    </table>
                </td>
               
            </tr>
            <tr style="height:25%">
                <td>
                    &nbsp;
                </td>
               
            </tr>
        </table>
    
    </div>
    <script type="text/javascript">
       
          function change(btn) //鼠标移入，更换图片
        {
           
          
          btn.style.color="Blue";
         
        }
        function rechange(btn)  //鼠标移出，换回原来的图片
        {
            //btn.src="./image/按键.png";
            btn.style.color ="Black"; 
        }
       
    
    </script>
    </form>
</body>
</html>
