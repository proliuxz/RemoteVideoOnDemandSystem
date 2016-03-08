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

public partial class adminusr : System.Web.UI.Page
{
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];

    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }
    protected void Bind()
    {
        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc);

        //定义sql 语句 [查询这张表的所有的数据]
        string article = "select * from [user] order by ID";
        //结果集 对象
        OleDbDataAdapter rs = new OleDbDataAdapter(article, myConn);
        //集合
        DataSet ds = new DataSet();
        //把rs 给了ds
        rs.Fill(ds);
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Bind();
    }

    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("userman.aspx");

    }
}
