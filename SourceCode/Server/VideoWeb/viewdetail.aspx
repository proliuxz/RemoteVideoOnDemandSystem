-<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewdetail.aspx.cs" Inherits="viewdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="商城视频浏览</title>
     <meta name="viewport" content="width=device-width,user-scalable=no"/>
 </head>
 <body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
 <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 640px; height:1136px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px ; border-top: #000000 0px ; border-left: #000000 0px ; border-bottom: #000000 0px ;" align="center">
     <table style="width: 90%;height:100%">
      <tr style="height:10%" >
       <td colspan="8" align="left">      
            <asp:ImageButton ID="ImageButton1" runat="server"  OnClick="return_click" 
                       ImageUrl="./image/按键.png" Height=35px Width=127px BackColor="Transparent" 
                       BorderWidth="0px" BorderStyle="None" onmouseover="changeImg(this)" 
                         onmouseout="rechangeImg(this)" />
       </td>
     </tr>
     <tr style="height:20%" >
       <td colspan="8">
           <asp:Image ID="Image1" runat="server" Height="200px" Width="600px" />
       </td>
     </tr>
      <tr style="height:10%">
       <td align="center">
           <asp:Button ID="Button1" runat="server" Text="1" Height="75%" Width="80%" 
               onclick="Button1_Click" />
       </td>
       <td align="center">
           <asp:Button ID="Button2" runat="server" Text="2" Height="75%" Width="80%" 
               onclick="Button2_Click" />
       </td>
        <td align="center">
           <asp:Button ID="Button3" runat="server" Text="3" Height="75%" Width="80%" 
                onclick="Button3_Click" />
       </td>
        <td align="center">
           <asp:Button ID="Button4" runat="server" Text="4" Height="75%" Width="80%" 
                onclick="Button4_Click"/>
       </td>
        <td align="center">
           <asp:Button ID="Button5" runat="server" Text="5" Height="75%" Width="80%" 
                onclick="Button5_Click"/>
       </td>
       <td align="center">
           <asp:Button ID="Button6" runat="server" Text="6" Height="75%" Width="80%" 
               onclick="Button6_Click"/>
       </td>
        <td align="center">
           <asp:Button ID="Button7" runat="server" Text="7" Height="75%" Width="80%" 
                onclick="Button7_Click"/>
       </td>
        <td align="center">
           <asp:Button ID="Button8" runat="server" Text="8" Height="75%" Width="80%" 
                onclick="Button8_Click"/>
       </td>
       
     </tr>
      <tr style="height:10%" align="center">
         <td>
           <asp:Button ID="Button9" runat="server" Text="9" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button10" runat="server" Text="10" Height="75%" Width="80%" 
               />
       </td>
        <td>
           <asp:Button ID="Button11" runat="server" Text="11" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button12" runat="server" Text="12" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button13" runat="server" Text="13" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button14" runat="server" Text="14" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button15" runat="server" Text="15" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button16" runat="server" Text="16" Height="75%" Width="80%"/>
       </td>
       
     </tr>
      <tr style="height:10%" align="center">
         <td>
           <asp:Button ID="Button17" runat="server" Text="Button" Height="75%" Width="80%" />
       </td>
        <td>
           <asp:Button ID="Button18" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button19" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button20" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button21" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button22" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button23" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button24" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
       
     </tr>
      <tr style="height:10%" align="center">
         <td>
           <asp:Button ID="Button25" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button26" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button27" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button28" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button29" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button30" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button31" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
        <td>
           <asp:Button ID="Button32" runat="server" Text="Button" Height="75%" Width="80%"/>
       </td>
       
     </tr>
   
      <tr style="height:30%" >
       <td colspan="8" align="center">      
           <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" TextMode="MultiLine" 
               Height="90%" Width="100%" BorderStyle="None" EnableTheming="True" 
               Font-Names="黑体" Font-Size="24pt"></asp:TextBox>      
       </td>
     </tr>
     
     </table>
        
    </div>
      <script type="text/javascript">
        function changeImg(btn) //鼠标移入，更换图片
        {
           
            btn.src="./image/点击按键.png";
        }
        function rechangeImg(btn)  //鼠标移出，换回原来的图片
        {
            btn.src="./image/按键.png";
        }
    </script>
    </form>
</body>

</html>
