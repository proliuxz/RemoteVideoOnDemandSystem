<%@ Page Language="C#" AutoEventWireup="true" CodeFile="storeabstract.aspx.cs" Inherits="storeabstract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商城视频浏览</title>
     <meta name="viewport" content="width=device-width,user-scalable=no"/>
    
</head>
<body style="margin-left: 0px; margin-top: 0px; margin-right: 0px; margin-bottom: 0px ">
    <form id="form1" runat="server" >  
    <div id="div1" runat="server" style="width: 640px; height:1136px;  margin-left: 0px; margin-right:  0px; margin-top: 0px; border-right: #000000 0px; border-top: #000000 0px; border-left: #000000 0px; border-bottom: #000000 0px;" align="center">
     
    
        <table style="width: 100%;height:100%">
            <tr style="height:15%">
                <td align="center">
                    <!--<asp:Label ID="Label1" runat="server" Text="电视剧频道" Font-Bold="False" 
                        Font-Names="黑体" Font-Size="40pt" Height="104%" Width="100%"></asp:Label>
                        -->
                     <iframe frameborder="no" height="180" src="Default2.aspx" width="600"></iframe> 
                </td>              
            </tr>
            <tr style="height:40%">
              <td>
               <table style="width: 90%; height: 100%;">
                 <tr style="height:10%; vertical-align:middle">
                    <td align="left"  valign="middle">
                      <asp:Label ID="Label2" runat="server" Text="" Font-Bold="False" 
                        Font-Names="黑体" Font-Size="26pt" Height="120%" Width="69%"></asp:Label>
                        </td>
                    <td align="right">
                        <asp:Button
                            ID="Button1" runat="server" Text="更多>>   " Font-Bold="False" 
                        Font-Names="黑体" Font-Size="22pt" Height="92%" Width="45%" 
                            BackColor="Transparent" BorderStyle="None" onclick="Button1_Click"/>
                     </td>
                  </tr>
                  <tr style="height:27%">
                    <td >
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="194px" Width="300px"  
                            ImageAlign="AbsMiddle" 
                            onclick="ImageButton1_Click"/></td>
                      <td >
                        <asp:ImageButton ID="ImageButton2" runat="server" Height="194px" Width="300px"   
                               ImageAlign="AbsMiddle" 
                              onclick="ImageButton2_Click"/></td>
                  </tr>
                  <tr style="height:18%">
                     <td >
                        
                        <asp:Label ID="Label4" runat="server" Height="100%" Width="100%" Text=""></asp:Label>
                                </td>
                     <td >
                        <asp:Label ID="Label5" runat="server"  Height="100%" Width="100%"  Text=""></asp:Label>
                                </td>
                  </tr>
                  <tr style="height:27%">
                    <td >
                       <asp:ImageButton ID="ImageButton3" runat="server" Height="194px" Width="300px"   
                             onclick="ImageButton3_Click"/></td>
                    <td >
                        <asp:ImageButton ID="ImageButton4" runat="server" Height="194px" 
                            Width="300px"   onclick="ImageButton4_Click"/></td>
                  </tr>
                  <tr style="height:18%">
                    <td >
                        <asp:Label ID="Label6" runat="server" Height="100%" Width="100%"  Text=""></asp:Label>
                                </td>
                    <td >
                        <asp:Label ID="Label7" runat="server" Height="100%" Width="100%" Text=""></asp:Label>
                                </td>
                  </tr>
              </table>         
              </td>
            </tr>
            <tr style="height:40%">              
               <td>
                <table style="width: 90%; height: 100%;">
                 <tr style="height:10%; vertical-align:middle">
                    <td align="left"  valign="middle">
                      <asp:Label ID="Label8" runat="server" Text="" Font-Bold="False" 
                        Font-Names="黑体" Font-Size="26pt" Height="120%" Width="69%"></asp:Label>
                        </td>
                    <td align="right">
                       <asp:Button
                            ID="Button2" runat="server" Text="更多>>   " Font-Bold="False" 
                        Font-Names="黑体" Font-Size="22pt" Height="97%" Width="45%" 
                            BackColor="Transparent" BorderStyle="None" onclick="Button2_Click"/>
                     </td>
                  </tr>
                  <tr style="height:27%">
                    <td >
                        <asp:ImageButton ID="ImageButton5" runat="server" Height="194px" 
                            Width="300px"    onclick="ImageButton5_Click" /></td>
                      <td >
                        <asp:ImageButton ID="ImageButton6" runat="server" Height="194px" Width="300px"   
                               onclick="ImageButton6_Click" /></td>
                  </tr>
                  <tr style="height:18%">
                    <td >
                        <asp:Label ID="Label10" runat="server" Height="100%" Width="100%" Text=""></asp:Label>
                                </td>
                     <td >
                        <asp:Label ID="Label11" runat="server" Height="100%" Width="100%"  Text=""></asp:Label>
                                </td>
                  </tr>
                  <tr style="height:27%">
                     <td >
                       <asp:ImageButton ID="ImageButton7" runat="server" Height="194px" Width="300px"    
                             onclick="ImageButton7_Click"/></td>
                     <td >
                        <asp:ImageButton ID="ImageButton8" runat="server" Height="194px" Width="300px"   
                             onclick="ImageButton8_Click"/></td>
                  </tr>
                  <tr style="height:18%">
                    <td >
                        <asp:Label ID="Label12" runat="server" Height="100%" Width="100%" Text=""></asp:Label>
                                </td>
                     <td >
                        <asp:Label ID="Label13" runat="server" Height="100%" Width="100%"  Text=""></asp:Label>
                                </td>
                  </tr>
              </table>          
              </td>
            </tr>
             <tr style="height:5%" align="center">
                
                <td align="center">
                    &nbsp;下拉刷新...</td>
            </tr>
        </table>
    </div>
    </form>
     
</body>
</html>
