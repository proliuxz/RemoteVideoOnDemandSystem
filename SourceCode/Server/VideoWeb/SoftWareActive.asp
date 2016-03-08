
<%@LANGUAGE="VBSCRIPT" CODEPAGE="936"%>
<!--#include virtual="md5.asp"-->
<%
    'http://192.168.1.127:81/1.mp4
	'reqstr = request.Form("ID")用于Post方法
	'reqstr = request.QueryString("ID")用于Get方法
	'通用方法
	DeviceInfo = request("DeviceInfo")
   UserName = request("UserName")
   VideoInfo = request("VideoInfo")
  
 
   	set adocon = Server.Createobject("adodb.connection")
	adocon.open"Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & Server.MapPath("App_Data\videostore.mdb")
	set rs=server.createobject("adodb.recordset")

	response.write json(DeviceInfo,UserName,VideoInfo)
	'函数json：读取ID为id的记录，将所有字段做成json


Function json(DeviceInfo,UserName,VideoInfo)
		
       sql="select * from [record] where [userid]=" & "'" & UserName & "'"
        	
  
		rs.open sql, adocon, 1, 1
 
  ' Dim md5value
 
 if rs.recordcount>0 then
  
  ' str=DeviceInfo+UserName+VideoInfo+"myvideo"
    str=DeviceInfo+VideoInfo+"myvideo"
   md5value=md5(str)
   
   else 
  md5value="failed"
  end if

  
   json = "{"& chr(34) & "sn" & chr(34) & ":" & chr(34) & md5value  & chr(34) & "}"
End Function
 %>