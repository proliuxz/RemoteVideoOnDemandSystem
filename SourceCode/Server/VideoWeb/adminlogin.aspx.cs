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
public partial class adminlogin : System.Web.UI.Page
{
     protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];

    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void regis(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length == 0)
        {
            Label4.Text = "用户名为空";
            return;
        }

        if (TextBox2.Text.Length == 0)
        {
            Label5.Text = "密码为空";
            return;
        }
        if ((TextBox2.Text.Length > 0) && (TextBox1.Text.Length > 0))
        {   
            
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj, mj2;

            mj2 = "select * from [用户登录] Where 用户名='" + TextBox1.Text + "'";
            //结果集 对象
            OleDbDataAdapter rs2 = new OleDbDataAdapter(mj2, myConn);
            //集合
            DataSet ds2 = new DataSet();
            //把rs 给了ds
            rs2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label4.Text = "用户名已存在";
                return;
            }
            else
            {
                mj = "select * from [管理员]";
                //结果集 对象
                OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
                //集合
                DataSet ds = new DataSet();
                //把rs 给了ds
                rs.Fill(ds);
                int num = ds.Tables[0].Rows.Count + 1;
              


                myConn.Open();//打开数据库

                string add = "insert into 管理员 (ID,用户名,密码) values('" + num + "','" + TextBox1.Text.ToString() + "','" + TextBox2.Text.ToString() + "')";

                OleDbCommand cmd = new OleDbCommand(add, myConn);//创建Command命令对象

                cmd.ExecuteNonQuery();//执行命令
                Label5.Text = "注册成功,请登录";
            }
        }
    }
    protected void usrlogin(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length == 0)
        {
            Label4.Text = "用户名为空";
            return;
        }

        if (TextBox2.Text.Length == 0)
        {
            Label5.Text = "密码为空";
            return;
        }

        if (TextBox1.Text.Length > 0)
        {
            //连接数据库
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj;

            mj = "select * from [管理员] Where 用户名='" + TextBox1.Text + "'";
            //结果集 对象
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            //集合
            DataSet ds = new DataSet();
            //把rs 给了ds
            rs.Fill(ds);
            if (ds.Tables[0].Rows.Count==0)
            {
                Label4.Text = "用户名不存在";
                return;
            }
            else if (ds.Tables[0].Rows.Count >0)
            {
                if (TextBox2.Text.Equals(ds.Tables[0].Rows[0]["密码"].ToString()))
                {
                    Response.Redirect("adminindex.aspx");
                }
                else { Label5.Text = "密码错误"; }
            }
        }

    }
    protected void usercha(object sender, EventArgs e)
    {
        Label4.Text = null;
    }
    protected void passcha(object sender, EventArgs e)
    {
        Label5.Text = null;
    }


}
