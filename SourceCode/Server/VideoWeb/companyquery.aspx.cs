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

public partial class companyquery : System.Web.UI.Page
{
    string article;
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    protected void Page_Load(object sender, EventArgs e)
    {
        String x1 = Request.QueryString["x1"];
        String x2 = Request.QueryString["x2"];
        if (x2 == null)
        {
            article = "select * from company order by ID";
        }
        else
        {
            if (x1 == "所有")
            {
                article = "select * from company where companyname like '%" + x2 + "%' or telephone like '%" + x2 + "%' or content like '%" + x2 + "%'";
            }
            if (x1 == "企业名称")
            {
                article = "select * from company where companyname like '%" + x2 + "%'";
            }
            if (x1 == "联系电话")
            {
                article = "select * from company where telephone like '%" + x2 + "%'";
            }
            if (x1 == "企业简介")
            {
                article = "select * from company where content like '%" + x2 + "%'";
            }
        }
        Bind();
    }

    protected void Bind()
    {
        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc);

        //定义sql 语句 [查询这张表的所有的数据]
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
        //this.GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Bind();
    }

    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("companyman.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_url;
        s_url = "companyquery.aspx?x1=" + DropDwonList1.Text + "&x2=" + TextBox1.Text + "";
        Response.Redirect(s_url);
    }
}
