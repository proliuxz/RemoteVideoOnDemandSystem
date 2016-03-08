<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewandload.aspx.cs" Inherits="viewandload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="剧集播放及下载</title>
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
     <tr style="height:10%" >
       <td colspan="8" align="center">      
           <asp:Label ID="Label1" runat="server" Font-Names="黑体" Font-Size="32pt" 
               Height="80%" Width="100%"></asp:Label>
           
       </td>
     </tr>
     <tr style="height:70%" >
       <td colspan="8">
            <object id="mediaPlayer" style="border: 7px dotted rgb(192,192,192); LEFT: 0px; TOP: 0px; margin-left: 0px; height: 661px; width: 615px; margin-top: 0px;" 
                        classid="CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95" visible="true">
                            <param name="fileName" value='<%=Session["path"]%>'/>
                            <param name="quality" value="high"/>
                            <param name="autoStart" value="1" />
                            <param name="ShowControls" value="1"/>
<!--是否显示控制,比如播放,停止,暂停-->
<param name="ShowAudioControls" value="1">

<!--是否显示音量控制-->
<param name="ShowDisplay" value="">
<!--显示节目信息,比如版权等-->
<param name="ShowGotoBar" value="">
<!--是否启用上下文菜单-->
<param name="ShowPositionControls" value="">
<!--是否显示往前往后及列表,如果显示一般也都是灰色不可控制-->
<param name="ShowStatusBar" value="">
<!--当前播放信息,显示是否正在播放,及总播放时间和当前播放到的时间-->
<param name="ShowTracker" value="-1">
<!--是否显示当前播放跟踪条,即当前的播放进度条-->
                            </object>
       </td>
     </tr>
   
   
      <tr style="height:10%" >
       <td colspan="8" align="center">      
            <asp:Button ID="Button2" runat="server"  OnClick="download_click" 
                       Height=43px Width=127px onmouseover="changeText(this)" 
                         onmouseout="rechangeText(this)" Text="下载" Font-Size="28pt" />
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
        function changeText(btn) //鼠标移入，更换图片
        {

            // btn.src="./image/点击按键.png";
            btn.style.color = "Black";
            // btn.BackColor="Red";
        }
        function rechangeText(btn)  //鼠标移出，换回原来的图片
        {
            //btn.src="./image/按键.png";
            btn.style.color = "Blue";
        }
    
    </script>
    
 </form>
</body>
</html>
