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

public partial class adminlotvideo : System.Web.UI.Page
{
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];

    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        Bind();
        //this.GridView1.DataBind();
    }
    protected void Bind()
    {
        //连接数据库
        OleDbConnection myConn = new OleDbConnection(ConnAcc);

        //定义sql 语句 [查询这张表的所有的数据]
        string article = "select distinct [title] from videogroup0";
        OleDbDataAdapter rs = new OleDbDataAdapter(article,myConn);
        //集合
        DataSet ds = new DataSet();
        //把rs 给了ds
        rs.Fill(ds);
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (TextBox1.Text.Length == 0)
        {
            Label4.Text = "前缀为空";
            return;
        }

        if (TextBox2.Text.Length == 0 || TextBox3.Text.Length == 0)
        {
            Label4.Text = "请检查数字范围";
            return;
        }
        int a = Convert.ToInt32(TextBox2.Text);
        int b = Convert.ToInt32(TextBox3.Text);
        if (a < 0 || b < 0 || a > b)
        {
            Label4.Text = "请检查数字范围";
            return;
        }
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj2;
        string uid;
        int num = a;
        int check = 0;
        uid = TextBox1.Text + num;
        mj2 = "select * from [user] Where userid = '" + uid + "'";
        //结果集 对象
        for (num = a; num <= b; num++)
        {
            OleDbDataAdapter rs2 = new OleDbDataAdapter(mj2, myConn);
            //集合
            DataSet ds2 = new DataSet();
            //把rs 给了ds
            rs2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
                check++;
        }
        if (check!=(b-a+1))
        {   
            Label4.Text = "部分用户名不存在";
            return;
        }
        else
        {
            if (e.CommandName == "ord")
            {
                int numm = 0;
                Response.Write("ord");
                //获取当前行id
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string grouptitle = row.Cells[0].Text;//当前行第一个单元格的值
                myConn.Open();//打开数据库
                string numcount = "select videotitle from video where grouptitle='"+ grouptitle +"'";
                OleDbDataAdapter rs3 = new OleDbDataAdapter(numcount, myConn);
                //集合
                DataSet ds3 = new DataSet();
                //把rs 给了ds
                rs3.Fill(ds3);
                numm = ds3.Tables[0].Rows.Count;
                for (num = a; num <= b; num++)
                {
                    uid = TextBox1.Text + num;
                    {
                        string add = "insert into [record] (userid,grouptitle) values('" + uid + "','" + grouptitle + "')";
                        OleDbCommand cmd = new OleDbCommand(add, myConn);//创建Command命令对象
                        cmd.ExecuteNonQuery();//执行命令
                    }
                    for (int i = 1; i <= numm; i++)
                    {
                        string add2 = "insert into recorddetail (videotitle,videoindex,grouptitle,userid) SELECT videotitle,videoindex,grouptitle,'" + uid + "' from video where grouptitle='" + grouptitle + "' AND videoindex="+ i +"";
                        OleDbCommand cmd2 = new OleDbCommand(add2, myConn);
                        cmd2.ExecuteNonQuery();
                    }
                }
                Label4.Text = "订制视频成功";
                myConn.Close();//关闭数据库
                
            }

            if (e.CommandName == "noo")
            {
                Response.Write("noo");
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).Parent.Parent;
                string grouptitle = row.Cells[0].Text;//当前行第一个单元格的值 
                myConn.Open();//打开数据库
                for (num = a; num <= b; num++)
                {
                    uid = TextBox1.Text + num;
                    {
                        string del1 = "delete from record where grouptitle='" + grouptitle + "'AND userid='" + uid + "'";
                        OleDbCommand cmd1 = new OleDbCommand(del1, myConn);
                        cmd1.ExecuteNonQuery();
                        string del2 = "delete from recorddetail where grouptitle='" + grouptitle + "'AND userid='" + uid + "'";
                        OleDbCommand cmd2 = new OleDbCommand(del2, myConn);
                        cmd2.ExecuteNonQuery();
                    }
                }
                myConn.Close();//关闭数据库  
                Label4.Text = "取消订制成功";
            }
            Bind();
        }
    }
    protected void cle(object sender, EventArgs e)
    {
        Label4.Text = null;
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classord.aspx");

    }
}