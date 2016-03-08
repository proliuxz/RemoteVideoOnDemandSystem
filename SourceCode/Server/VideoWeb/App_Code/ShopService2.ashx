<%@ WebHandler Language="C#" Class="ShopService2" %>

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

using System.Web.Security;

using System.Data.OleDb;
using System.IO;

public class ShopService2 : IHttpHandler {
    protected static string ConnAcc = System.Configuration.ConfigurationManager.AppSettings["ConnAcc"];
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        //context.Response.Write("Hello World");
        string json = "";
        string state = "0";
        string purchase = "";
        //连接数据库
        string UserName = "b";
        string PassWord = "b";
        string DeviceInfo = "b";
        OleDbConnection myConn = new OleDbConnection(ConnAcc);

        //定义sql 语句 [查询这张表的所有的数据]
        string sql = "select * from [user] where [userid] =" + "'" + UserName + "'" + "and [password]=" + "'" + PassWord + "'";
        //结果集 对象
        OleDbDataAdapter rs = new OleDbDataAdapter(sql, myConn);
        DataSet ds = new DataSet();
        //把rs 给了ds
        int loggedtimes = 0;
        string purchasedvideotitile = "";//视频详细信息，视频标题
        string purchasedvideovalidate = "";//每集视频授权情况，机器码为空或者机器码一致为授权合法为1,否则为0
        string purchasedvideonum = "";//每种产品的集数
        string purchasedproductnum = "";//购买的产品数量
        int videonum = 0;//每种产品的集数
        int productnum = 0;//购买的产品数量
        string purchasedvideogrouptitle = "";
        rs.Fill(ds);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            state = "1";
            loggedtimes = (int)ds.Tables[0].Rows[0]["loggedtimes"] + 1;
            purchase = ds.Tables[0].Rows[0]["purchase"].ToString();

            string sql2 = "select * from [record] where [userid] =" + "'" + UserName + "'";
            OleDbDataAdapter rs2 = new OleDbDataAdapter(sql2, myConn);
            DataSet ds2 = new DataSet();
            rs2.Fill(ds2);
            productnum = ds2.Tables[0].Rows.Count;


            for (int j = 0; j < productnum; j++)
            {
                string grouptitle = ds2.Tables[0].Rows[j]["grouptitle"].ToString();
                purchasedvideogrouptitle += "\"" + "purchasedvideogrouptitle" + j.ToString() + "\"" + ":" + "\"" + grouptitle + "\"";
                if (j < productnum - 1)
                    purchasedvideogrouptitle += ",";

                string sql3 = "select * from [recorddetail] where [userid] =" + "'" + UserName + "' and [grouptitle] =" + "'" + grouptitle + "' ORDER BY [videoindex]";
                OleDbDataAdapter rs3 = new OleDbDataAdapter(sql3, myConn);
                DataSet ds3 = new DataSet();
                rs3.Fill(ds3);
                videonum = ds3.Tables[0].Rows.Count;
                purchasedvideonum += "\"purchasedvideonum" + j.ToString() + "\":\"" + videonum + "\"";//每个视频产品个数
                if (j < productnum - 1)
                    purchasedvideonum += ",";

                for (int i = 0; i < videonum; i++)
                {
                    purchasedvideotitile += "\"purchasedvideotitile" + j.ToString() + i.ToString() + "\":\"" + ds3.Tables[0].Rows[i]["videotitle"].ToString() + "\"";
                    if (j < productnum - 1)
                        purchasedvideotitile += ",";
                    else if (i < videonum - 1)
                        purchasedvideotitile += ",";

                    if (ds3.Tables[0].Rows[i]["deviceid"].ToString() == "" || ds3.Tables[0].Rows[i]["deviceid"].ToString() == DeviceInfo)
                    {
                        purchasedvideovalidate += "\"purchasedvideovalidate" + j.ToString() + i.ToString() + "\":\"1\"";
                        if (j < productnum - 1)
                            purchasedvideovalidate += ",";
                        else if (i < videonum - 1)
                            purchasedvideovalidate += ",";
                    }
                    else
                    {
                        purchasedvideovalidate += "\"purchasedvideovalidate" + j.ToString() + i.ToString() + "\":" + "\"0\"";
                        if (j < productnum - 1)
                            purchasedvideovalidate += ",";
                        else if (i < videonum - 1)
                            purchasedvideovalidate += ",";
                    }
                }
            }
        }
        else
            state = "0";//            "用户名或密码错误";
        myConn.Close();//关闭数据库
        json = @"{" + "\"state\":" + "\"" + state + "\"" + ",\"loggedtimes\":\"" + loggedtimes + "\",\"purchase\":\"" + purchase + "\",\"purchasedproductnum\":\"" + productnum + "\"," + purchasedvideonum + "," + purchasedvideogrouptitle + "," + purchasedvideotitile + "," + purchasedvideovalidate + "}";

        if (state == "1")//合法用户
        {
            myConn.Open();//打开数据库
            string sql2 = "update [user] set loggedtimes='" + loggedtimes + "' where userid='" + UserName + "'";


            OleDbCommand cmd = new OleDbCommand(sql2, myConn);

            cmd.ExecuteNonQuery();

            myConn.Close();//关闭数据库 
        }
        string responseData = json;
        context.Response.Write(responseData);
        context.Response.End();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    } 

}