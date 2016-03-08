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
public partial class adminvideo : System.Web.UI.Page
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
        string article = "select * from videogroup0 order by ID";
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

            //获取当前行id
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string grouptitle = row.Cells[0].Text;//当前行第一个单元格的值 

            
             OleDbConnection myConn2 = new OleDbConnection(ConnAcc);    
            string article2 = "select * from videogroup0 where title='"+grouptitle+"'";      
            OleDbDataAdapter rs2 = new OleDbDataAdapter(article2, myConn2);      
            DataSet ds2 = new DataSet();       
            rs2.Fill(ds2);
            System.IO.File.Delete(Server.MapPath(@".\" + ds2.Tables[0].Rows[0]["picurl"].ToString()));
            System.IO.Directory.Delete(Server.MapPath(@".\" + ds2.Tables[0].Rows[0]["videodirname"].ToString()), true);
            
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            myConn.Open();//打开数据库
            string article3 = "delete from video where grouptitle='" + grouptitle+"'";
            OleDbCommand cmd3 = new OleDbCommand(article3, myConn);
            cmd3.ExecuteNonQuery();

            string article4 = "delete from videogroup0 where title='" + grouptitle + "'";
            OleDbCommand cmd4 = new OleDbCommand(article4, myConn);
            cmd4.ExecuteNonQuery();


            myConn.Close();//关闭数据库*/
        }

        if (e.CommandName == "Edit")
        {

            
            Response.Write("编辑");

            //获取当前行id
            GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
            string grouptitle = row.Cells[0].Text;//当前行第一个单元格的值 

            Response.Redirect("videoedit.aspx?grouptitle=" + grouptitle + "");
        }



        Bind();
    }
   

    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminindex.aspx");

    }
}