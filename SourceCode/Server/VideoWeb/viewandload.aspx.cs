using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Data.OleDb;
using System.Collections.Generic;
using System.Text;
using System.IO;

public partial class viewandload : System.Web.UI.Page
{
    String vaddress,vid2,num;
    //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
   
    protected void Page_Load(object sender, EventArgs e)
    {
      
        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj;

        //定义sql 语句 [查询这张表的所有的数据]

       
            
            vid2= Request.QueryString["vaddress"].ToString().Substring(0,3);
            vaddress= Request.QueryString["vaddress"].ToString().Substring(3);
            string vv = Request.QueryString["vaddress"].ToString();
            num = Request.QueryString["vaddress"].ToString().Substring(vv.Length-5);

            mj = "select * from [电视剧表] Where 电视剧编号='" + vid2 + "'";
            //结果集 对象
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            //集合
            DataSet ds = new DataSet();
            //把rs 给了ds
            rs.Fill(ds);
            Label1.Text = "正在播放<<"+ds.Tables[0].Rows[0]["电视剧名字"].ToString()+">>";
            Session["path"] =Server.MapPath(vaddress);
          
           
        
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {  
        Response.Redirect("viewdetail.aspx?vid=" + vid2);
        Response.Redirect("viewdetail.aspx");
    
    }
   
    protected void download_click(object sender, EventArgs e)
    {   
        Response.ContentType = "video/mp4";
        Response.AddHeader("Content-Disposition", "attachment;filename="+vid2+"-"+num);
        string filename = Server.MapPath(vaddress);
        Response.TransmitFile(filename);
    }
}
