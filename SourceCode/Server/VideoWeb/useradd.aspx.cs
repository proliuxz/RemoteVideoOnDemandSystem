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

using System.Data.OleDb;
public partial class usradd : System.Web.UI.Page
{
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    //方法
    protected void Page_Load(object sender, EventArgs e)
    { 
    }
   
    protected void reglot(object sender, EventArgs e)
    {
        if (TextBox6.Text.Length == 0)
        {
            Label7.Text = "前缀为空";
            return;
        }

        if (TextBox9.Text.Length == 0 || TextBox11.Text.Length == 0)
        {
            Label7.Text = "请检查数字范围";
            return;
        }
        int a = Convert.ToInt32(TextBox9.Text);
        int b = Convert.ToInt32(TextBox11.Text);
        if (a < 0 || b < 0 || a > b)
        {
            Label7.Text = "请检查数字范围";
            return;
        }
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj, mj2;
        string uid;
        int num = a;
        int check = 0;
        uid = TextBox6.Text + num;
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

        if (check > 0)
        {
            Label7.Text = "部分用户名被占用";
            return;
        }
        else
        {

            mj = "select * from [user]";
            //结果集 对象
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            myConn.Open();//打开数据库
            char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            for (num = a; num <= b; num++)
            {
                Random random = new Random(GetRandomSeed());
                string pwd=null;
                for(int pwdi=0;pwdi<6;pwdi++)
                {
                int pwdnum = random.Next(0,62);
                pwd = pwd + constant[pwdnum];
                }
                uid = TextBox6.Text + num;
                string add = "insert into [user] (userid,[password],loggedtimes) values('" + uid + "','" + pwd + "',0)";
                OleDbCommand cmd = new OleDbCommand(add, myConn);//创建Command命令对象
                cmd.ExecuteNonQuery();//执行命令
            }
            myConn.Close();
            Label7.Text = "添加成功";
        }
    }
    static int GetRandomSeed()
    {
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);
    }
 
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length == 0)
        {
            Label2.Text = "用户名不能为空";
            return;
        }

        if (TextBox3.Text.Length == 0)
        {
            Label3.Text = "密码不能为空";
            return;
        }
        if ((TextBox3.Text.Length > 0) && (TextBox1.Text.Length > 0))
        {
            //连接数据库
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj, mj2;

            mj2 = "select * from [user] Where userid='" + TextBox1.Text + "'";
            //结果集 对象
            OleDbDataAdapter rs2 = new OleDbDataAdapter(mj2, myConn);
            //集合
            DataSet ds2 = new DataSet();
            //把rs 给了ds
            rs2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                Label2.Text = "用户名已存在";
                return;
            }
            else
            {

                mj = "select * from [user]";
                //结果集 对象
                OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
                myConn.Open();//打开数据库
                string add = "insert into [user] (userid,[password],loggedtimes) values('" + TextBox1.Text.ToString() + "','" + TextBox3.Text.ToString() + "',0)";
                OleDbCommand cmd = new OleDbCommand(add, myConn);//创建Command命令对象

                cmd.ExecuteNonQuery();//执行命令

                Label2.Text = "添加成功";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = null;
        TextBox3.Text = null;
        TextBox6.Text = null;
        TextBox9.Text = null;
        TextBox11.Text = null;
        Label7.Text = null;
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("userman.aspx");
    }
}
