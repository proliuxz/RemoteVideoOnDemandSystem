<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>使用Javascript脚本循环播放图片</title>
    </head>
    <body style="margin: 0px; padding-bottom: 0px; padding-left: 0px; padding-right: 0px; padding-top: 0px;">
        <script type="text/javascript">
            var focus_width = 600;
            var focus_height = 180;
            var text_height = 0;
            var swf_height = focus_height + text_height;
            var pics = 'image/1.jpg|image/2.jpg|image/3.jpg|image/4.jpg';
            var links = '||';
            var texts = '';
            var banner = '<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="image/banner.swf"><param name="quality" value="high"><param name="bgcolor" value="#DADADA">';
            document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
            document.write(banner);
            document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
            document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
            document.write('</object>');
        </script>
    </body>
</html>