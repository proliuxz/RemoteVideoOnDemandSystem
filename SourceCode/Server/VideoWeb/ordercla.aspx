<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ordercla.aspx.cs" Inherits="ordercla" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订制课程</title>
<meta name="viewport" content="width=device-width,user-scalable=no"/>
   
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <asp:Label ID="Label5" runat="server" Font-Size="18pt" Text="-" 
                                    Width="250px"></asp:Label>
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px; border-top: #000000 0px; border-left: #000000 0px; border-bottom: #000000 0px;" align="center">
        <table style="width: 100%;height:100%">
            <tr style="height:150px" >
                <td align="center" colspan="3">
                   <asp:Label ID="Label1" runat="server" Text="订制课程" Font-Bold="True" 
                        Font-Size="29pt" ForeColor="#0033CC" ></asp:Label>
                </td>
            </tr>
             <tr style="height:100px">
                 <td style="width:140px" >
                    
                </td>
                 <td align="left">
                 <asp:Label ID="Label2" runat="server" Text="用户名" Font-Size="26pt"></asp:Label>                   
                 <asp:TextBox ID="TextBox3" runat="server" Height="37px" Width="215px" 
                 Font-Size="20pt"></asp:TextBox>
                 <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Tsext="" Font-Size="26pt"></asp:Label>
            </td>
            </tr>
            <tr style="height:350px">
                 <td style="width:140px" >
                    
                </td>
                 <td align="center">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                         OnRowCommand="GridView1_RowCommand" AllowPaging="True" BorderStyle="None" 
                         Font-Size="16pt" Height="321px" Width="986px" 
                          OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" >
            <Columns>
                 <asp:BoundField DataField="ID" HeaderText="课程编号" ControlStyle-Width="240px" ItemStyle-Width="240px" >
                  <ControlStyle Width="240px"></ControlStyle>
                  <ItemStyle Width="240px"></ItemStyle>
               </asp:BoundField>
                
                <asp:BoundField DataField="title" HeaderText="课程名称" ControlStyle-Width="240px" ItemStyle-Width="240px" >
                  <ControlStyle Width="240px"></ControlStyle>
                  <ItemStyle Width="240px"></ItemStyle>
               </asp:BoundField>
               
                <asp:BoundField DataField="picurl" HeaderText="图片存储位置" ControlStyle-Width="240px" ItemStyle-Width="240px" >
                  <ControlStyle Width="240px"></ControlStyle>
                  <ItemStyle Width="240px"></ItemStyle>
                </asp:BoundField>
               
               
               
                <asp:BoundField DataField="videodirname" HeaderText="课程视频所在文件夹" ControlStyle-Width="240px" ItemStyle-Width="240px" >
                  <ControlStyle Width="240px"></ControlStyle>
                  <ItemStyle Width="240px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="videocontent" HeaderText="课程简介" ControlStyle-Width="600px" ItemStyle-Width="600px" >
                  <ControlStyle Width="600px"></ControlStyle>
                  <ItemStyle Width="600px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="company" HeaderText="课程所属公司" ControlStyle-Width="240px" ItemStyle-Width="240px" >
                  <ControlStyle Width="240px"></ControlStyle>
                  <ItemStyle Width="240px"></ItemStyle>
                </asp:BoundField>
                
                <asp:TemplateField>
                <HeaderTemplate>
                  选项
                </HeaderTemplate>
                <ItemTemplate >
   
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Ord" Width="100px">订制</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="Del" Width="100px">取消</asp:LinkButton>
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
            <tr>
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
