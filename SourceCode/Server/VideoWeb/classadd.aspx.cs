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

public partial class classadd : System.Web.UI.Page
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
            Label2.Text = "课程名称不能为空";
            return -1;
        }
        else
        {

            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj;
            mj = "select * from videogroup0 Where title='" + TextBox1.Text + "'";
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            DataSet ds = new DataSet();
            rs.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = "课程已存在";
                return -1;
            }
            else { return 1; }
        }

    }
    public int checkdirname(string str)
    {
        if (str.Length == 0)
        {
            Label2.Text = "课程视频存储位置不能为空";
            return -1;
        }
        else
        {

            if (Directory.Exists(Server.MapPath(TextBox3.Text)))             
            {
                Label2.Text = "存储文件夹被占用";
                return -1;
            }
            else { return 1; }
        }

    }
    public int checkcontent(string str)
    {
        if (str == "")
        {
            Label2.Text = "课程简介不能为空";
            return -1;
        }
        else { return 1; }
    }
    public int checkcompany(string str)
    {
        if (str == "")
        {
            Label2.Text = "所处公司不能为空";
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
        Label2.Text = "";
        Label4.Text = "";
        if (checktitle(TextBox1.Text) == 1)
        {
            if (checkdirname(TextBox3.Text) == 1)
                {
                    if (checkcontent(TextBox2.Text) == 1)
                    {
                        if (checkcompany(TextBox2.Text) == 1)
                        {
                        if (checkpic(FileUpload14.PostedFile.FileName)==1)
                        {
                            string pic = @".\image\" + TextBox3.Text +".jpg";
                            string picadd = @"image\" + TextBox3.Text + ".jpg";
                            string dir = @".\"+ TextBox3.Text;
                            OleDbConnection myConn = new OleDbConnection(ConnAcc);
                            myConn.Open();//打开数据库
                            string add = "insert into videogroup0 (title,picurl,picname,videodirname,videocontent,company) values('" + TextBox1.Text + "','" + picadd + "','" + TextBox3.Text + ".jpg','" + TextBox3.Text + "','" + TextBox2.Text + "' ,'" + TextBox5.Text + "')";
                            OleDbCommand cmd = new OleDbCommand(add, myConn);//创建Command命令对象
                            cmd.ExecuteNonQuery();//执行命令    
                            DirectoryInfo di = Directory.CreateDirectory(Server.MapPath(dir));
                            this.FileUpload14.PostedFile.SaveAs(Server.MapPath(pic));
                                            
                            Label2.Text = "添加成功";
                            TextBox1.Text = null;
                            TextBox2.Text = null;
                            TextBox3.Text = null;
                            TextBox5.Text = null;
                            }//pic
                        }//company
                    }//content
                }//dirname
            }//Title
        }//botton
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classman.aspx");
    }
}
