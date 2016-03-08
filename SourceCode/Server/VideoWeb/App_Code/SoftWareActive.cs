using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Services;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Data.OleDb;
using System.IO;
/// <summary>
///getpicurl 的摘要说明
/// </summary>
[WebService(Namespace = "http://192.168.1.127:81/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ToolboxItem(false)]
[System.Web.Script.Services.ScriptService]

//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class SoftWareActive : System.Web.Services.WebService
{

    protected static string ConnAcc5 = System.Configuration.ConfigurationManager.AppSettings["ConnAcc"];
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string regist(String DeviceInfo, String UserName, String VideoInfo)
    {
        string json = @"{""sn"":";

        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc5);

        //定义sql 语句 [查询这张表的所有的数据]
        string sql = "select * from [record] where [userid] =" + "'" + UserName + "'" + "and [videohash]=" + "'" + VideoInfo + "'";
        //结果集 对象
        OleDbDataAdapter rs = new OleDbDataAdapter(sql, myConn);
        DataSet ds = new DataSet();
        //把rs 给了ds

        rs.Fill(ds);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["deviceid"].ToString() =="" || ds.Tables[0].Rows[0]["deviceid"].ToString() == DeviceInfo)
            //如果设备Id为空（第一次注册）或者等于用户提交的设备id（以前用此设备注册过，重新注册）
            {
                String str = DeviceInfo + VideoInfo + "myvideo";
                String md5value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");//32位
                json += md5value + "}";
             
            }
            else
                json += "failed}";

        }

        else
            json += "failed}";//            "用户名或videoinfo错误或者非法设备";
        myConn.Close();//关闭数据库
        //记录deviceid
        if (ds.Tables[0].Rows[0]["deviceid"].ToString() =="")
        {
            myConn.Open();//打开数据库
            string sql2 = "update record set deviceid='" + DeviceInfo + "' where userid='" + UserName + "' and videohash=" + "'" + VideoInfo + "'";


            OleDbCommand cmd = new OleDbCommand(sql2, myConn);

            cmd.ExecuteNonQuery();

            myConn.Close();//关闭数据库 
        }
      
        
        return json;

    }



}
