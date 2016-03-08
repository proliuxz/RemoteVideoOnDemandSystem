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

public partial class userdel : System.Web.UI.Page
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
        //this.GridView1.DataBind();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {

            Response.Write("删除");
            /*获取当前行id*/
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string id = row.Cells[0].Text;//当前行第一个单元格的值 
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            myConn.Open();//打开数据库
            string article = "delete from [user] where ID=" + id;
            OleDbCommand cmd = new OleDbCommand(article, myConn);
            cmd.ExecuteNonQuery();
            string path = Server.MapPath(row.Cells[3].Text);
            System.IO.File.Delete(path);
            myConn.Close();//关闭数据库
        }

        if (e.CommandName == "Edit")
        {

            Response.Write("编辑");

            /*获取当前行id*/
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string id = row.Cells[0].Text;//当前行第一个单元格的值 
            Response.Redirect("usredit.aspx?ID=" + id + "");
        }



        Bind();
    }

    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("userman.aspx");

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("usersdel.aspx");

    }
}
