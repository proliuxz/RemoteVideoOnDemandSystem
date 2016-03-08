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
using System.IO;
using System.Text;

using System.Data.OleDb;

public partial class companyadd : System.Web.UI.Page
{
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    //方法

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int checktitle(string str)
    {
        if (str.Length == 0)
        {
            Label2.Text = "企业名称不能为空";
            return -1;
        }
        else
        {

            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj;
            mj = "select * from company Where companyname='" + TextBox1.Text + "'";
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            DataSet ds = new DataSet();
            rs.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = "企业已存在";
                return -1;
            }
            else { return 1; }
        }

    }
  
    public int checkcontent(string str)
    {
        if (str == "")
        {
            Label2.Text = "企业简介不能为空";
            return -1;
        }
        else { return 1; }
    }
    public int checktelephone(string str)
    {
        if (str == "")
        {
            Label2.Text = "联系电话不能为空";
            return -1;
        }
        else { return 1; }
    }
    public int checkpic(string str)
    {
        if (str == "")
        {
            Label4.Text = "图片地址不能为空";
            return -1;
        }

        else if (str.Substring(str.LastIndexOf(".")) != ".jpg")
        {
            Label4.Text = "图片必须为jpg";
            return -1;
        }
        else if (FileUpload14.PostedFile.ContentLength > 200000)
        {
            Label4.Text = "图片过大，请上传小于200K的图片";
            return -1;
        }
        else { return 1; }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = null;
        Label4.Text = null;
        if (checktitle(TextBox1.Text) == 1)
        {
            if (checktelephone(TextBox3.Text) == 1)
            {
                if (checkcontent(TextBox2.Text) == 1)
                {
                        if (checkpic(FileUpload14.PostedFile.FileName) == 1)
                        {
                            OleDbConnection myConn = new OleDbConnection(ConnAcc);
                            myConn.Open();//打开数据库
                            string add = "insert into company (companyname,telephone,content) values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox2.Text + "')";
                            OleDbCommand cmd = new OleDbCommand(add, myConn);//创建Command命令对象
                            cmd.ExecuteNonQuery();
                            string usr = "select * from company where companyname='" + TextBox1.Text + "'";
                            OleDbDataAdapter cmd_article = new OleDbDataAdapter(usr, myConn);
                            DataSet ds = new DataSet();
                            cmd_article.Fill(ds);
                            string picname = ds.Tables[0].Rows[0]["id"].ToString();
                            string pic = @".\image\company\" + picname + ".jpg";
                            this.FileUpload14.PostedFile.SaveAs(Server.MapPath(pic));
                            string edittitle = "update company set pic = '" + picname + ".jpg' where companyname = '" + TextBox1.Text + "'";
                            //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);
                            OleDbCommand cmd2 = new OleDbCommand(edittitle, myConn);
                            cmd2.ExecuteNonQuery();
                            Label2.Text = "添加成功";
                            TextBox1.Text = null;
                            TextBox2.Text = null;
                            TextBox3.Text = null;
                        }//pic
                }//content
            }//dirname
        }//Title
    }//botton
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("companyman.aspx");
    }
}
