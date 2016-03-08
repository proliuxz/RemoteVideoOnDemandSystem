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
public class getindexpicinfo : System.Web.Services.WebService
{

      protected static string ConnAcc = System.Configuration.ConfigurationManager.AppSettings["ConnAcc"];
      [WebMethod]
       [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
       public string indexpicinfo()
        {
          
            //string json = @"{""picurl"":" + picurl + "}";
           string picinfo= @"{";
            //连接数据库
            OleDbConnection myConn = new OleDbConnection(ConnAcc);

            //定义sql 语句 [查询这张表的所有的数据]
            string sql = "select * from [videogroup0] ";
            //结果集 对象
            OleDbDataAdapter rs = new OleDbDataAdapter(sql, myConn);
            DataSet ds = new DataSet();
            //把rs 给了ds
            
            rs.Fill(ds);
            DataTableReader dtr = ds.CreateDataReader();
            int num = 6;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < num; i++)//前6个
                {
                    //picurl += ;
                    picinfo += "picname" + i.ToString() + ":" + ds.Tables[0].Rows[i]["picname"].ToString();
                  
                  
                       picinfo += ",";
                       picinfo += "pictitle" + i.ToString() + ":" + ds.Tables[0].Rows[i]["title"].ToString();
                       picinfo += ",";
                       picinfo += "morepiccompany" + i.ToString() + ":" + ds.Tables[0].Rows[i]["company"].ToString();
                       picinfo += ",";
                   
                    
                }
              
            }
            
            else
                picinfo = "0";//   
   
            sql = "select * from [videogroup1] ";
             rs = new OleDbDataAdapter(sql, myConn);
            ds = new DataSet();
            rs.Fill(ds);
             dtr = ds.CreateDataReader();
   
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < num; i++)//前6个
                {
                    //picurl += ;
                    picinfo += "picname1" + i.ToString() + ":" + ds.Tables[0].Rows[i]["picname"].ToString();


                    picinfo += ",";
                    picinfo += "pictitle1" + i.ToString() + ":" + ds.Tables[0].Rows[i]["title"].ToString();
                    picinfo += ",";
                    picinfo += "morepiccompany1" + i.ToString() + ":" + ds.Tables[0].Rows[i]["company"].ToString();
                    picinfo += ",";
                    

                }
               
            }

            else
                picinfo = "0";//  
            sql = "select * from [videogroup2] ";
            rs = new OleDbDataAdapter(sql, myConn);
            ds = new DataSet();
            rs.Fill(ds);
            dtr = ds.CreateDataReader();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < num; i++)//前6个
                {
                    //picurl += ;
                    picinfo += "picname2" + i.ToString() + ":" + ds.Tables[0].Rows[i]["picname"].ToString();
                    picinfo += ",";
                    picinfo += "pictitle2" + i.ToString() + ":" + ds.Tables[0].Rows[i]["title"].ToString();
                    picinfo += ",";
                    picinfo += "morepiccompany2" + i.ToString() + ":" + ds.Tables[0].Rows[i]["company"].ToString();
                             
                    if (i < num - 1)
                    {
                        picinfo += ",";
                    }

                }
                picinfo += "}";
            }

            else
                picinfo = "0";//  



            myConn.Close();//关闭数据库
            return picinfo;
        }

       
    
}
