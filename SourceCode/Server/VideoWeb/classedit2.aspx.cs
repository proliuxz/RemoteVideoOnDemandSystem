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
using System.Text;
using System.IO;

public partial class classedit2 : System.Web.UI.Page
{ //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    static string id;
    static string oldtitle;
    static string oldvideodirname;
    static string oldvideocontent;
    static string oldcompany;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            id = Request.QueryString["ID"];
            OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

            myConn.Open();

            string usr = "select * from videogroup0 where ID=" + id + "";
            OleDbDataAdapter cmd_article = new OleDbDataAdapter(usr, myConn);
            DataSet ds = new DataSet();
            cmd_article.Fill(ds);
            TextBox1.Text = ds.Tables[0].Rows[0]["title"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["videodirname"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["videocontent"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["company"].ToString();
            oldtitle = TextBox1.Text;
            oldvideodirname = TextBox3.Text;
            oldvideocontent = TextBox2.Text;
            oldcompany = TextBox5.Text;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newtitle = TextBox1.Text;
        string newvideodirname = TextBox3.Text;
        string newvideocontent = TextBox2.Text;
        string newcompany = TextBox5.Text;
        int num = 0;
        Label3.Text = null;
        Label4.Text = null;
        Label5.Text = null;
        if (oldtitle != newtitle)
        {
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj;
            mj = "select * from videogroup0 Where title='" + TextBox1.Text + "'";
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            DataSet ds = new DataSet();
            rs.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Label2.Text = "课程名称已存在";
            }
            else
            {
                string edittitle = "update videogroup0 set title = '" + newtitle + "' where id = " + id + "";
                myConn.Open();//打开数据库
                //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

                OleDbCommand cmd = new OleDbCommand(edittitle, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();//关闭数据库
                num++;
            }
        }
        if (newvideodirname != oldvideodirname)
        {
            if (Directory.Exists(Server.MapPath(TextBox3.Text)))
            {
                Label2.Text = "存储文件夹被占用";
                return;
            }
            else
            {
                string oldpath = Server.MapPath(oldvideodirname);
                string path = Server.MapPath(TextBox3.Text);
                string oldpicpath = Server.MapPath(@".\image\"+oldvideodirname+".jpg");
                string picpath = Server.MapPath(@".\image\" + TextBox3.Text + ".jpg");
                string picadd = @"image\" + TextBox3.Text + ".jpg";
                string picadd2 =TextBox3.Text + ".jpg";
                System.IO.Directory.Move(oldpath, path);
                System.IO.File.Move(oldpicpath, picpath);
                OleDbConnection myConn = new OleDbConnection(ConnAcc);
                string updateinfo = "update videogroup0 set picurl ='" + picadd + "',picname='"+picadd2+"',videodirname = '"+TextBox3.Text+"' where ID="+id+"";
                myConn.Open();//打开数据库
                //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

                OleDbCommand cmd = new OleDbCommand(updateinfo, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();//关闭数据库
                 num++;
            }
        }
        if (oldvideocontent != newvideocontent)
        {
                OleDbConnection myConn = new OleDbConnection(ConnAcc);
                string up= "update videogroup0 set videocontent = '" + newvideocontent + "' where id = " + id + "";
                myConn.Open();//打开数据库
                //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

                OleDbCommand cmd = new OleDbCommand(up, myConn);
                cmd.ExecuteNonQuery();
                myConn.Close();//关闭数据库
                num++;
        }
        if (oldcompany != newcompany)
        {
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string up = "update videogroup0 set company = '" + newcompany + "' where id = " + id + "";
            myConn.Open();//打开数据库
            //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

            OleDbCommand cmd = new OleDbCommand(up, myConn);
            cmd.ExecuteNonQuery();
            myConn.Close();//关闭数据库
             num++;
        }
        if(FileUpload14.PostedFile.FileName != "")
        {
            if(checkpic(FileUpload14.PostedFile.FileName)==1)
            {
                   string pic = @".\image\" + TextBox3.Text +".jpg";
                   System.IO.File.Delete(Server.MapPath(pic));
                   this.FileUpload14.PostedFile.SaveAs(Server.MapPath(pic));
            num++;
            }
        }
        if(num==0)
        {

            Label2.Text = "课程修改失败";
        }
        else
        {
            Label2.Text = "课程修改成功";
        }
    }
    public int checkpic(string str)
        {
     
        if (str.Substring(str.LastIndexOf(".")) != ".jpg")
        {
            Label4.Text = "图片必须为jpg";
            return -1;
        }
        else { return 1; }
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("classedit.aspx");
    }
}
