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

public partial class ordervid : System.Web.UI.Page
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
        string article = "select * from video order by ID";
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
        if (e.CommandName == "Ord")
        {
            if (TextBox3.Text.Length == 0)
            {
                Label4.Text = "用户名为空";
                return;
            }
            if (TextBox3.Text.Length > 0)
            {
                //连接数据库
                OleDbConnection myConn = new OleDbConnection(ConnAcc);
                string mj;

                mj = "select * from [user] Where userid='" + TextBox3.Text + "'";
                //结果集 对象
                OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
                //集合
                DataSet ds = new DataSet();
                //把rs 给了ds
                rs.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Label4.Text = "用户名不存在";
                    return;
                }
                Response.Write("订制");
                /*获取当前行id*/
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string i = row.Cells[0].Text;
                string grouptitle = row.Cells[1].Text;//当前行第一个单元格的值
                string numcount = "select videotitle from video where grouptitle='" + grouptitle + "'";
                myConn.Open();//打开数据库
                string uid = TextBox3.Text;
                string mj3 = "select * from record where userid='" + TextBox3.Text + "'and grouptitle='" + grouptitle + "'";
                //结果集 对象
                rs = new OleDbDataAdapter(mj3, myConn);
                //集合
                ds = new DataSet();
                //把rs 给了ds
                rs.Fill(ds);
                if (ds.Tables[0].Rows.Count ==0)
                {
                    string add1 = "insert into record (userid,grouptitle) values('" + uid + "','" + grouptitle + "')";
                    OleDbCommand cmd = new OleDbCommand(add1, myConn);//创建Command命令对象
                    cmd.ExecuteNonQuery();//执行命令
                }
                string add2 = "insert into recorddetail(videotitle,videoindex,grouptitle,userid) SELECT videotitle,videoindex,grouptitle,'" + uid + "' from video where ID=" + i +"";
                OleDbCommand cmd2 = new OleDbCommand(add2, myConn);
                cmd2.ExecuteNonQuery();
                Label4.Text = "视频订制成功";// "订制视频成功";
                myConn.Close();//关闭数据库
            }
        }
            if (e.CommandName == "Del")
            {
                if (TextBox3.Text.Length == 0)
                {
                    Label4.Text = "用户名为空";
                    return;
                }
                if (TextBox3.Text.Length > 0)
                {
                    //连接数据库
                    OleDbConnection myConn = new OleDbConnection(ConnAcc);
                    string mj;

                    mj = "select * from [user] Where userid='" + TextBox3.Text + "'";
                    //结果集 对象
                    OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
                    //集合
                    DataSet ds = new DataSet();
                    //把rs 给了ds
                    rs.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        Label4.Text = "用户名不存在";
                        return;
                    }
                    Response.Write("取消");
                    /*获取当前行id*/
                    GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                    string grouptitle = row.Cells[1].Text;
                    string videotitle = row.Cells[2].Text;//当前行第一个单元格的值 
                    myConn.Open();//打开数据库
                    string uid = TextBox3.Text;
                    string mj2 = "select * from recorddetail where userid='" + TextBox3.Text + "'and grouptitle='"+grouptitle+"'";
                    //结果集 对象
                    rs = new OleDbDataAdapter(mj2, myConn);
                    //集合
                    ds = new DataSet();
                    //把rs 给了ds
                    rs.Fill(ds);
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        string del1 = "delete * from record where grouptitle='" + grouptitle + "' and userid = '" + uid + "'";
                        OleDbCommand cmd = new OleDbCommand(del1, myConn);//创建Command命令对象
                        cmd.ExecuteNonQuery();//执行命令
                    }
                    string del2 = "delete * from recorddetail where videotitle='" + videotitle+ "' and userid = '" + uid + "'";
                    OleDbCommand cmd2 = new OleDbCommand(del2, myConn);
                    cmd2.ExecuteNonQuery();
                    myConn.Close();//关闭数据库
                    Label4.Text ="取消订制成功";
                }
            }
            Bind();
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classord.aspx");

    }

}
