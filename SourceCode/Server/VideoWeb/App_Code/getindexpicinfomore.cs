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
public class getindexpicinfomore : System.Web.Services.WebService
{

      protected static string ConnAcc1 = System.Configuration.ConfigurationManager.AppSettings["ConnAcc"];
      [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
      public string indexpicinfomore(int grouptype)
      {
          int group = grouptype;
          string tablename = "";
          if (group == 0)
              tablename = "[videogroup0]";
          else if (group == 1)
              tablename = "[videogroup1]";
          else
              tablename = "[videogroup2]";

          //string json = @"{""picurl"":" + picurl + "}";
          string picinfo = @"{";
          //连接数据库
          OleDbConnection myConn = new OleDbConnection(ConnAcc1);

          //定义sql 语句 [查询这张表的所有的数据]
          string sql = "select * from " + tablename;
          //结果集 对象
          OleDbDataAdapter rs = new OleDbDataAdapter(sql, myConn);
          DataSet ds = new DataSet();
          //把rs 给了ds

          rs.Fill(ds);


          int num = ds.Tables[0].Rows.Count;
          picinfo += "morevideonum:" + num;
          picinfo += ",";
          if (ds != null && num > 0)
          {
              for (int i = 0; i < num; i++)//
              {
                  //picurl += ;
                  picinfo += "morepicname" + i.ToString() + ":" + ds.Tables[0].Rows[i]["picname"].ToString();
                  picinfo += ",";
                  picinfo += "morepiccompany" + i.ToString() + ":" + ds.Tables[0].Rows[i]["company"].ToString();
                  picinfo += ",";
                  picinfo += "morepictitle" + i.ToString() + ":" + ds.Tables[0].Rows[i]["title"].ToString();
                  if (i < num - 1)
                  {
                      picinfo += ",";
                  }


              }

              picinfo += "}";
          }

          else
              picinfo += "}";


          myConn.Close();//关闭数据库
          return picinfo;
      }

       
    
}
