<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classquery.aspx.cs" Inherits="classquery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>课程查询</title>
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px "> 
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 1280px; height:720px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px ; border-top: #000000 0px ; border-left: #000000 0px ; border-bottom: #000000 0px ;" align="center">
     <table style="width: 100%;height:100%">
     <tr style="height:150px">
       <td style="width:40px" rowspan="2">
       </td>
       <td style="width:1200px"  >
           <asp:Label ID="Label1" runat="server" Text="课程查询" Font-Bold="False" 
               Font-Names="黑体" Font-Size="XX-Large"></asp:Label>
       </td>
       <td style="width:40px" rowspan="2">
       </td>
     </tr>
       <tr align="center">
       <td style="width:1200px"  >
           <table >
               <tr >
                   <td style="width:200px; " align="center" valign="top">
                    <asp:DropDownList ID="DropDwonList1" runat="server"  Height="40px" Width="200px" Font-Size="20pt">
                        <asp:ListItem>所有</asp:ListItem>
                        <asp:ListItem>课程名称</asp:ListItem>
                        <asp:ListItem>图片名</asp:ListItem>
                        <asp:ListItem>存储文件夹</asp:ListItem>
                        <asp:ListItem>课程简介</asp:ListItem>
                        <asp:ListItem>所属公司</asp:ListItem>
                    </asp:DropDownList>
                   </td>
                   <td style="width:480px" align="center" colspan="6" valign="top">
                        <asp:TextBox ID="TextBox1" runat="server" Font-Size="20pt" Height="40px" 
                            Width="480px"></asp:TextBox>
                   </td>
                   <td style="width:200px"align="center" valign="top" >
                        <asp:Button ID="Button2" runat="server" Text="查询" 
                        Height="35px" Width="127px"
                        BackColor="Transparent" Font-Size="16pt" ForeColor="Black" onmouseover="change(this)" 
                        onmouseout="rechange(this)" align="left" onclick="Button1_Click" />
                       
                   </td>
               </tr>
           </table>
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
                 <asp:BoundField DataField="ID" HeaderText="课程编号" ControlStyle-Width="200px" ItemStyle-Width="200px" >
                  <ControlStyle Width="200px"></ControlStyle>
                  <ItemStyle Width="200px"></ItemStyle>
               </asp:BoundField>
                
                <asp:BoundField DataField="title" HeaderText="课程名称" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
               </asp:BoundField>
               
                <asp:BoundField DataField="picurl" HeaderText="图片存储地址" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="videodirname" HeaderText="视频存储文件夹" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="videocontent" HeaderText="视频简介" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="company" HeaderText="所属公司" ControlStyle-Width="300px" ItemStyle-Width="300px" >
                  <ControlStyle Width="300px"></ControlStyle>
                  <ItemStyle Width="300px"></ItemStyle>
                </asp:BoundField>
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
