<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usersdel.aspx.cs" Inherits="adminlotmake" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>批量用户创建删除</title>
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px; border-top: #000000 0px; border-left: #000000 0px; border-bottom: #000000 0px;" align="center">
     
        <table style="width: 100%;height:100%">
            <tr style="height:35%; width:100%">
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="批量用户删除" Font-Bold="True" 
                        Font-Size="42pt"></asp:Label>
                </td>
               
            </tr>
            <tr style="height:40%; width:100%">
                <td align="center">
                    <table style="width: 80%; height:70%">
                        <tr>
                            <td width="40%" >
                                <asp:Label ID="Label2" runat="server" Text="前缀" Font-Size="26pt"></asp:Label>
                               
                            </td>
                            <td class="style1" >
                                
                                <asp:TextBox ID="TextBox1" runat="server" Height="37px" Width="215px" 
                                    OnTextChanged="cle" Font-Size="20pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="Label4" runat="server" Font-Size="18pt" Text=" " 
                                    ForeColor="#FF0066" Width="250px"></asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="Label3" runat="server" Text="数字编号" Font-Size="26pt"></asp:Label>
                                
                            </td>
                            <td class="style1" >
                                
                                <asp:TextBox ID="TextBox2" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode<=57))||(event.keyCode==46)) {event.returnValue=true;}  else{event.returnValue=false;}" MaxLength="15" Height="37px" Width="215px" 
                                    OnTextChanged="cle" Font-Size="20pt"></asp:TextBox>
                            </td>
                            <td>
                               
                                <asp:Label ID="Label5" runat="server" Font-Size="18pt" Text="-" 
                                    Width="250px"></asp:Label>
                            </td>
                            <td class="style1" >
                                
                                <asp:TextBox ID="TextBox3" runat="server" OnKeyPress="if(((event.keyCode>=48)&&(event.keyCode<=57))||(event.keyCode==46)) {event.returnValue=true;}  else{event.returnValue=false;}" MaxLength="15" Height="37px" Width="215px" 
                                    OnTextChanged="cle" Font-Size="20pt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td >
                            </td>
                            <td class="style1" >
                                <asp:Button ID="Button2" runat="server" Text="删除" Font-Size="26pt" 
                                    Height="46px" Width="125px"  OnClick="dellot" onmouseout="rechange(this)" 
                        onmouseover="change(this)"/>
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
