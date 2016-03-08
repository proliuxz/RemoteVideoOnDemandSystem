<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>
<%@ OutputCache Location="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html >
<head runat="server">
    <title>课程选择</title>
 <meta name="viewport" content="width=device-width,user-scalable=no"/>
      
          
    <style type="text/css">
        .style8
        {
            height: 65px;
        }
        .style15
        {
            width: 101px;
            height: 50px;
        }
        .style26
        {
            width: 54px;
        }
        .style27
        {
            width: 204px;
        }
        .style28
        {
            width: 145px;
        }
        .style29
        {
            width: 145px;
            height: 50px;
        }
        .style30
        {
            width: 33px;
        }
        </style>
      
          
  </head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <form id="form1" runat="server" style=" ); background-repeat:no-repeat;width: 640px; height:960px;">  
    <div id="div1" runat="server" 
        style="border: 0px none #000000; width: 640px; height:960px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; " 
        align="center">
     
        <table style="margin-left: 0px; width: 640px; height: 534px;">
         <tr>

                <td colspan="5" valign="bottom" align="left" class="style8" >
                    <asp:Label ID="Label9" runat="server" Text="课程选择" Height="25px"  
                        style="text-align: left;" Font-Bold="True" 
                        Font-Names="黑体" Font-Size="9pt" 
                        ForeColor="#333399" Width="249px"></asp:Label>
                </td>
               
            </tr>
            
            <tr align="left">
                <td class="style30">
                    &nbsp;
                </td>
                
                <td class="style26" >
                    <table  style=" margin-left:0px"; >
                   
                        <tr >
                            <td align="center" class="style29"   >
                               <asp:Image ID="Video1" ImageUrl="./image/video1.jpg" runat="server" Height="50px" Width="100px"  />
                                
                                 </td>
                                 <td valign="bottom" align="left" class="style27" >
                   <asp:Label ID="Label3" runat="server" Text="杜克大学公开课：怪诞行为学" Height="25px"  
                        style="text-align: left;" Font-Bold="True" 
                        Font-Names="黑体" Font-Size="9pt" 
                        ForeColor="#333399" Width="249px"></asp:Label>
                </td>
                 <td align="center" class="style15"   >
                               <asp:ImageButton ID="Download1" ImageUrl="./image/download1.jpg" runat="server" OnClientClick="Msg1(this)" BackColor="Transparent"  
                        onmouseover="changeText(this)" onmouseout="rechangeText(this)"  Height="20px" Width="60px"  />
                                
                                 </td>
                          </tr>
                          
                        <tr>
                            <td align="center" valign="top" class="style28"  >
                                  <asp:Image ID="Video2" ImageUrl="./image/video1.jpg" runat="server" Height="50px" Width="100px"  />
                               
                            </td>
                              <td valign="bottom" align="left" class="style27" >
                   <asp:Label ID="Label1" runat="server" Text="普林斯顿大学公开课：领导能力简介" Height="25px"  
                        style="text-align: left;" Font-Bold="True" 
                        Font-Names="黑体" Font-Size="9pt" 
                        ForeColor="#333399" Width="249px"></asp:Label>
                </td>
                 <td align="center" class="style15"   >
                               <asp:ImageButton ID="Download2" ImageUrl="./image/download1.jpg" runat="server" OnClientClick="Msg2(this)" BackColor="Transparent"  
                        onmouseover="changeText(this)" onmouseout="rechangeText(this)"  Height="20px" Width="60px"  />
                                
                                 </td>
                           
                        </tr>
                          <tr>
                            <td align="center" valign="top" class="style28"  >
                                  <asp:Image ID="Video3" ImageUrl="./image/video1.jpg" runat="server" Height="50px" Width="100px"  />
                               
                            </td>
                              <td valign="bottom" align="left" class="style27" >
                   <asp:Label ID="Label2" runat="server" Text="英国公开大学公开课：60秒宗教探奇" Height="25px"  
                        style="text-align: left;" Font-Bold="True" 
                        Font-Names="黑体" Font-Size="9pt" 
                        ForeColor="#333399" Width="249px"></asp:Label>
                </td>
                 <td align="center" class="style15"   >
                               <asp:ImageButton ID="Download3" ImageUrl="./image/download1.jpg" runat="server" OnClientClick="Msg3(this)" BackColor="Transparent"  
                        onmouseover="changeText(this)" onmouseout="rechangeText(this)" Height="20px" Width="60px"  />
                                
                                 </td>
                           
                        </tr>
                    </table>
                </td>               
            </tr>
         
            <tr style="height:7%">
            <td colspan="5">
                &nbsp;</td>
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
             function changeText(btn) //鼠标移入，更换图片
             {

                 // btn.src="./image/点击按键.png";
                 btn.style.color = "Blue";
                 // btn.BackColor="Red";
             }
             function rechangeText(btn)  //鼠标移出，换回原来的图片
             {
                 //btn.src="./image/按键.png";
                 btn.style.color = "White";
             }
             function Msg1(btn) {

                 window.android.opennetclass("guaidan",13);


             }
             function Msg2(btn) {

                 window.android.opennetclass("lingdao",5);


             }
             function Msg3(btn) {

                 window.android.opennetclass("60miao",4);


             }
             function Msg4(btn) {

                 window.android.opennetclass();


             }
             function Msg5(btn) {

                 window.android.opennetclass();


             }
             function Msg6(btn) {

                 window.android.opennetclass();


             }
             function Msg7(btn) {

                 window.android.opennetclass();


             }
             function Msg8(btn) {

                 window.android.opennetclass();


             } 
        
    </script>
    </form>
</body>
</html>
