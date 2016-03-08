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
using System.Text;
using System.IO;

public partial class usredit : System.Web.UI.Page
{ //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    static string id;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            id = Request.QueryString["ID"];
            OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

            myConn.Open();

            string usr = "select * from [user] where ID="+ id + "";

            OleDbDataAdapter cmd_article = new OleDbDataAdapter(usr, myConn);

            DataSet ds = new DataSet();

            cmd_article.Fill(ds);
            Label4.Text = ds.Tables[0].Rows[0]["userid"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["password"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["loggedtimes"].ToString();
            Label2.Text = "不可改项";
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

        myConn.Open();//打开数据库


        string article = "update [user] set [password]='" + TextBox2.Text.ToString() + "', loggedtimes='" + TextBox3.Text.ToString() + "'  where userid='" + Label4.Text.ToString() + "'";
        
     
        //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

        OleDbCommand cmd = new OleDbCommand(article, myConn);

        cmd.ExecuteNonQuery();

        myConn.Close();//关闭数据库


    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("useredit.aspx");
    }
}
