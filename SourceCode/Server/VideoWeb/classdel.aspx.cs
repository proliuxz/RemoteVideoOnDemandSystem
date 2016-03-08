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

public partial class classdel : System.Web.UI.Page
{
    string article;
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    protected void Page_Load(object sender, EventArgs e)
    {
        String x1 = Request.QueryString["x1"];
        String x2 = Request.QueryString["x2"];
        if (x2 == null)
        {
            article = "select * from videogroup0 order by ID";
        }
        else
        {
            if (x1 == "所有")
            {
                article = "select * from videogroup0 where title like '%" + x2 + "%' or picurl like '%" + x2 + "%' or videodirname like '%" + x2 + "%' or videocontent like '%" + x2 + "%' or company like '%" + x2 + "%'";
            }
            if (x1 == "课程名称")
            {
                article = "select * from videogroup0 where title like '%" + x2 + "%'";
            }
            if (x1 == "图片名")
            {
                article = "select * from videogroup0 where picurl like '%" + x2 + "%'";
            }
            if (x1 == "存储文件夹")
            {
                article = "select * from videogroup0 where videodirname like '%" + x2 + "%'";
            }
            if (x1 == "课程简介")
            {
                article = "select * from videogroup0 where videocontent like '%" + x2 + "%'";
            }
            if (x1 == "所属公司")
            {
                article = "select * from videogroup0 where company like '%" + x2 + "%'";
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
        if (e.CommandName == "Del")
        {

            Response.Write("删除");
            /*获取当前行id*/
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string id = row.Cells[0].Text;//当前行第一个单元格的值
            OleDbConnection myConn2 = new OleDbConnection(ConnAcc);
            string article2 = "select * from videogroup0 where ID=" + id + "";
            OleDbDataAdapter rs2 = new OleDbDataAdapter(article2, myConn2);
            DataSet ds2 = new DataSet();
            rs2.Fill(ds2);
            System.IO.File.Delete(Server.MapPath(@".\" + ds2.Tables[0].Rows[0]["picurl"].ToString()));
            System.IO.Directory.Delete(Server.MapPath(@".\" + ds2.Tables[0].Rows[0]["videodirname"].ToString()), true);
            myConn2.Close();
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            myConn.Open();//打开数据库
            string article = "delete from videogroup0 where ID=" + id;
            OleDbCommand cmd = new OleDbCommand(article, myConn);
            cmd.ExecuteNonQuery();
            myConn.Close();//关闭数据库
            Label2.Text="删除成功";
        }
        Bind();
    }

    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classman.aspx");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string s_url;
        s_url = "classdel.aspx?x1=" + DropDwonList1.Text + "&x2=" + TextBox1.Text + "";
        Response.Redirect(s_url);
    }
}
