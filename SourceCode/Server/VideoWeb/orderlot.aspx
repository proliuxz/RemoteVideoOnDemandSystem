<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderlot.aspx.cs" Inherits="adminlotvideo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px; border-top: #000000 0px; border-left: #000000 0px; border-bottom: #000000 0px;" align="center">
     
        <table style="width: 100%;height:100%">
            <tr style="height:35%; width:100%">
                <td align="center">
                    <asp:Label ID="Label1" runat="server" Text="批量视频订制" Font-Bold="True" 
                        Font-Size="30pt"></asp:Label>
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
                    </table>

            <table style="width: 100%;height:100%">
            <tr style="height:350px">
                 <td style="width:140px" >
                    
                </td>
                 <td align="center">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                         OnRowCommand="GridView1_RowCommand" AllowPaging="True" BorderStyle="None" 
                         Font-Size="16pt" Height="321px" Width="986px" 
                          OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" >
            <Columns>
                 <asp:BoundField DataField="title" HeaderText="课程名称" ControlStyle-Width="200px" ItemStyle-Width="200px" >
                  <ControlStyle Width="200px"></ControlStyle>
                  <ItemStyle Width="200px"></ItemStyle>
               </asp:BoundField> 
                <asp:TemplateField>
                <HeaderTemplate>
                  选项
                </HeaderTemplate>
                <ItemTemplate >
   
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("title") %>' CommandName="ord" Width="100px">订制</asp:LinkButton> 
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("title") %>' CommandName="noo" Width="100px">取消</asp:LinkButton>
   
                </ItemTemplate>
               </asp:TemplateField>
            </Columns>
                        <PagerStyle BackColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#3333CC" />
                        <HeaderStyle BackColor="#666699" />
                        <AlternatingRowStyle BackColor="#CCFFFF" />
        </asp:GridView>
                </td>
                 
                <td style="width:140px" >
                    
                </td>
                
            </tr>
              <tr style="height:100px">
                <td align="right" colspan="3">
                     
                   <asp:ImageButton ID="ImageButton1" runat="server"  OnClick="return_click" 
                       ImageUrl="./image/按键.png" Height=35px Width=127px BackColor="Transparent" 
                       BorderWidth="0px" BorderStyle="None" onmouseover="changeImg(this)" 
                         onmouseout="rechangeImg(this)" style="margin-right:53px;  margin-bottom:40px"/>
                </td>
                
               
            </tr>
            <tr style="height:120px">
                <td align="center" colspan="3">
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
