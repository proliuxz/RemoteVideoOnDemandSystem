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



public partial class adminlotmake : System.Web.UI.Page
{
    static int GetRandomSeed()
    {
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    protected void dellot(object sender, EventArgs e)
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
        int a = Convert.ToInt32(this.TextBox2.Text);
        int b = Convert.ToInt32(this.TextBox3.Text);
        if (a<0||b<0||a>b)
        {
            Label4.Text = "请检查数字范围";
            return;
        }
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj, mj2;
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
        if (check != (b-a+1))
        {
            Label4.Text = "无效集群账号";
            return;
        }
        else
        {
            myConn.Open();//打开数据库
            for (num = a; num <= b; num++)
            {
                uid = TextBox1.Text+ num;
                string article = "delete from [user] where userid= '"+ uid+"'";
                OleDbCommand cmd = new OleDbCommand(article, myConn);
                cmd.ExecuteNonQuery();
            }
            myConn.Close();
            Label4.Text = "删除成功";
        }


    }
    protected void cle(object sender, EventArgs e)
    {
        Label4.Text = null;
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("userdel.aspx");
    }
   
}