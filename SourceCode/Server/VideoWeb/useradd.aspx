<%@ Page Language="C#" AutoEventWireup="true" CodeFile="useradd.aspx.cs" Inherits="usradd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加用户</title>
    <meta name="viewport" content="width=device-width,user-scalable=no"/>
    
    </head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px "> 
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:360px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px ; border-top: #000000 0px ; border-left: #000000 0px ; border-bottom: #000000 0px ;" align="center">
     <table style="width: 100%;height:100%">
        <tr style="height:50px">
            <td style="width:140px" rowspan="2">
            </td>
            <td style="width:1000px"  >
                <asp:Label ID="Label1" runat="server" Text="添加用户" Font-Bold="False" 
                Font-Names="黑体" Font-Size="20pt"></asp:Label>
            </td>
            <td style="width:140px" rowspan="2">
            </td>
        </tr>
        <tr style="height:100px">
            <td style="width:1000px">
                <table style="width: 1000px">
                    <tr style="height:80px;font-size: 20pt;">
                        <td style="width:200px; " align="left">
                       用户名：
                        </td>
                        <td style="width:500px" align="left">
                            <asp:TextBox ID="TextBox1" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                        </td>
                        <td style="width:300px"align="left">
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Height="40px" Width="280px"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height:80px;font-size: 20pt;">
                        <td style="width:200px" align="left">
                            密码：
                        </td>
                        <td style="width:500px" align="left">
                         <asp:TextBox ID="TextBox3" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                        </td>
                        <td style="width:300px"align="left">
                        &nbsp;
                        &nbsp;
                        <asp:Label ID="Label3" runat="server" ForeColor="Red" Height="40px" Width="280px"></asp:Label>
                        </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr style="height:50px">
                <td>
                </td>
                 <td style="width:1280px"  colspan="3" align="left">
                 <asp:Button ID="Button1" runat="server" Text="添加" 
                    style="margin-right:200px; margin-bottom:80px" Height="35px" Width="127px" 
                    BackColor="Transparent" Font-Size="16pt" ForeColor="Black" onmouseover="change(this)" 
                    onmouseout="rechange(this)" onclick="Button1_Click" />
                 <asp:Button ID="Button2" runat="server" Text="清空" 
                    style="margin-right:200px; margin-bottom:80px" Height="35px" Width="127px" 
                    BackColor="Transparent" Font-Size="16pt" ForeColor="Black" onmouseover="change(this)" 
                    onmouseout="rechange(this)" onclick="Button2_Click" />
                 </td>
            </tr>
        <tr style="height:50px">
            <td style="width:140px" rowspan="2">
            </td>
            <td style="width:1000px"  >
                <asp:Label ID="Label4" runat="server" Text="批量添加用户" Font-Bold="False" 
                Font-Names="黑体" Font-Size="20pt"></asp:Label>
            </td>
            <td style="width:140px" rowspan="2">
            </td>
        </tr>
        <tr style="height:100px">
            <td style="width:1000px">
                <table style="width: 1000px">
                    <tr style="height:80px;font-size: 20pt;">
                        <td style="width:200px; " align="left">
                        <asp:Label ID="Label5" runat="server" ForeColor="BLACK" Height="40px" Width="280px" Text="前缀"></asp:Label>
                        </td>
                        <td style="width:500px" align="left">
                            <asp:TextBox ID="TextBox6" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                        </td>
                        <td style="width:50px" align="left">
                        <asp:Label ID="Label20" runat="server" ForeColor="BLACK" Height="40px" Width="50px"></asp:Label>
                        </td>
                        <td style="width:300px"align="left">
                        <asp:Label ID="Label7" runat="server" ForeColor="RED" Height="40px" Width="280px"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height:80px;font-size: 20pt;">
                        <td style="width:200px" align="left">
                        <asp:Label ID="Label8" runat="server" ForeColor="BLACK" Height="40px" Width="280px" Text="数字范围"></asp:Label>
                        </td>
                        <td style="width:500px" align="left">
                         <asp:TextBox ID="TextBox9" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                        </td>
                        <td style="width:50px" align="left">
                        <asp:Label ID="Label10" runat="server" ForeColor="BLACK" Height="40px" Width="50px" Text="—"></asp:Label>
                        </td>
                        <td style="width:500px" align="left">
                         <asp:TextBox ID="TextBox11" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                        </td>
                        <td style="width:300px"align="left">
                        &nbsp;
                        &nbsp;
                        </td>
                    </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                 <td style="width:1280px"  colspan="3" align="left">
                 <asp:Button ID="Button3" runat="server" Text="添加" 
                    style="margin-right:200px; margin-bottom:80px" Height="35px" Width="127px" 
                    BackColor="Transparent" Font-Size="16pt" ForeColor="Black" onmouseover="change(this)" 
                    onmouseout="rechange(this)" onclick="reglot" />
                 <asp:Button ID="Button4" runat="server" Text="清空" 
                    style="margin-right:200px; margin-bottom:80px" Height="35px" Width="127px" 
                    BackColor="Transparent" Font-Size="16pt" ForeColor="Black" onmouseover="change(this)" 
                    onmouseout="rechange(this)" onclick="Button2_Click" />
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

        function ch
            </td>图片
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
