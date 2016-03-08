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

public partial class storeabstract : System.Web.UI.Page
{
    //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    string Name1, Name2;
    DataSet ds2, ds3;

    protected void Page_Load(object sender, EventArgs e)
    { 
        
        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj;

        //定义sql 语句 [查询这张表的所有的数据]
   
        mj = "select * from [首页配置] Where ID=1";
        //结果集 对象
        OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
        //集合
        DataSet ds = new DataSet();
        //把rs 给了ds
        rs.Fill(ds);

       
         Name1 = ds.Tables[0].Rows[0]["视频1编号"].ToString();
         Name2 = ds.Tables[0].Rows[0]["视频2编号"].ToString();
        
        string mj2 = "select * from [电视剧表] Where 电视剧编号='" + Name1 + "'";
        //结果集 对象
        OleDbDataAdapter rs2 = new OleDbDataAdapter(mj2, myConn);
        //集合
        ds2 = new DataSet();
        //把rs 给了ds
        rs2.Fill(ds2);

        string mj3 = "select * from [电视剧表] Where 电视剧编号='" + Name2 + "'";
        //结果集 对象
        OleDbDataAdapter rs3 = new OleDbDataAdapter(mj3, myConn);
        //集合
        ds3 = new DataSet();
        //把rs 给了ds
        rs3.Fill(ds3);

            this.Label2.Text = ds2.Tables[0].Rows[0]["电视剧名字"].ToString();
            this.Label8.Text = ds3.Tables[0].Rows[0]["电视剧名字"].ToString();

            this.ImageButton1.ImageUrl = ds2.Tables[0].Rows[0]["剧集图片地址"].ToString() + "1.jpg";
            this.ImageButton2.ImageUrl = ds2.Tables[0].Rows[0]["剧集图片地址"].ToString() + "2.jpg";
            this.ImageButton3.ImageUrl = ds2.Tables[0].Rows[0]["剧集图片地址"].ToString() + "3.jpg";
            this.ImageButton4.ImageUrl = ds2.Tables[0].Rows[0]["剧集图片地址"].ToString() + "4.jpg";

            this.ImageButton5.ImageUrl = ds3.Tables[0].Rows[0]["剧集图片地址"].ToString() + "1.jpg";
            this.ImageButton6.ImageUrl = ds3.Tables[0].Rows[0]["剧集图片地址"].ToString() + "2.jpg";
            this.ImageButton7.ImageUrl = ds3.Tables[0].Rows[0]["剧集图片地址"].ToString() + "3.jpg";
            this.ImageButton8.ImageUrl = ds3.Tables[0].Rows[0]["剧集图片地址"].ToString() + "4.jpg";

            

            this.Label4.Text = getjv(ds2.Tables[0].Rows[0]["分集剧情1"].ToString());
            this.Label5.Text = getjv(ds2.Tables[0].Rows[0]["分集剧情2"].ToString());
            this.Label6.Text = getjv(ds2.Tables[0].Rows[0]["分集剧情3"].ToString());
            this.Label7.Text = getjv(ds2.Tables[0].Rows[0]["分集剧情4"].ToString());

            this.Label10.Text = ds3.Tables[0].Rows[0]["分集剧情1"].ToString();
            this.Label11.Text = ds3.Tables[0].Rows[0]["分集剧情2"].ToString();
            this.Label12.Text = ds3.Tables[0].Rows[0]["分集剧情3"].ToString();
            this.Label13.Text = ds3.Tables[0].Rows[0]["分集剧情4"].ToString();


       
    }
    public string getjv(string str)
    {
        FileStream stream = new FileStream(Server.MapPath(str), FileMode.Open);
        StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("gb2312"));
        string superpig = reader.ReadToEnd();
        reader.Close();
        stream.Close();
        return (superpig);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {   
        Response.Redirect("viewdetail.aspx?vid=" + Name1);
        Response.Redirect("viewdetail.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress="+Name1+ds2.Tables[0].Rows[0]["分集地址1"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name1 + ds2.Tables[0].Rows[0]["分集地址2"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name1 + ds2.Tables[0].Rows[0]["分集地址3"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name1 + ds2.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewdetail.aspx?vid=" + Name2);
        Response.Redirect("viewdetail.aspx");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name2 + ds3.Tables[0].Rows[0]["分集地址1"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name2 + ds3.Tables[0].Rows[0]["分集地址2"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name2 + ds3.Tables[0].Rows[0]["分集地址3"].ToString());
        Response.Redirect("viewandload.aspx");
    }
    protected void ImageButton8_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("viewandload.aspx?vaddress=" + Name2 + ds3.Tables[0].Rows[0]["分集地址4"].ToString());
        Response.Redirect("viewandload.aspx");
    }
}
