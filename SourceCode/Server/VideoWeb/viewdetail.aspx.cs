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

public partial class viewdetail : System.Web.UI.Page
{
    string vid;
    
    //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj;

        //定义sql 语句 [查询这张表的所有的数据]

            vid = Request.QueryString["vid"].ToString();
            mj = "select * from [电视剧表] Where 电视剧编号='" +vid+ "'";
            //结果集 对象
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            //集合
            ds = new DataSet();
            //把rs 给了ds
            rs.Fill(ds);
            Image1.ImageUrl = ds.Tables[0].Rows[0]["标题图片地址"].ToString();
            

            FileStream stream = new FileStream(Server.MapPath(ds.Tables[0].Rows[0]["总剧情地址"].ToString()), FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
            TextBox1.Text = reader.ReadToEnd();

            reader.Close();
            stream.Close();

        
    }
  
    protected void Button1_Click(object sender, EventArgs e)
    {
      
        Response.Redirect("viewandload.aspx?vaddress=" +vid+ds.Tables[0].Rows[0]["分集地址1"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" +vid+ds.Tables[0].Rows[0]["分集地址2"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + vid + ds.Tables[0].Rows[0]["分集地址3"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + vid + ds.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + vid + ds.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + vid + ds.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + vid + ds.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + vid + ds.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("storeabstract.aspx");
    }
}
