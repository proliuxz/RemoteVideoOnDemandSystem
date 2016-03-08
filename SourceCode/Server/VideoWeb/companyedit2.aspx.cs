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

public partial class companyedit2 : System.Web.UI.Page
{ //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    static string id;
    static string oldcompanyname;
    static string oldtelephone;
    static string oldcontent;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            id = Request.QueryString["ID"];
            OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

            myConn.Open();

            string usr = "select * from company where ID=" + id + "";
            OleDbDataAdapter cmd_article = new OleDbDataAdapter(usr, myConn);
            DataSet ds = new DataSet();
            cmd_article.Fill(ds);
            TextBox1.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["telephone"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["content"].ToString();
            oldcompanyname = TextBox1.Text;
            oldtelephone = TextBox3.Text;
            oldcontent = TextBox2.Text;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newcompanyname = TextBox1.Text;
        string newtelephone = TextBox3.Text;
        string newcontent = TextBox2.Text;
  
        int num = 0;
        Label3.Text = null;
        Label4.Text = null;
        
         if (newcompanyname != oldcompanyname)
         {
             OleDbConnection myConn = new OleDbConnection(ConnAcc);
             string mj;
             mj = "select * from company where companyname='" + TextBox1.Text + "'";
             OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
             DataSet ds = new DataSet();
             rs.Fill(ds);
             if (ds.Tables[0].Rows.Count > 0)
             {
                 Label2.Text = "该企业名称已存在";
             }
             else
             {
                 string edittitle = "update company set companyname = '" + TextBox1.Text + "' where id = " + id + "";
                 myConn.Open();//打开数据库
                 //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

                 OleDbCommand cmd = new OleDbCommand(edittitle, myConn);
                 cmd.ExecuteNonQuery();
                 myConn.Close();//关闭数据库
                 num++;
             }
         }
         if (oldtelephone != newtelephone)
         {
                 OleDbConnection myConn = new OleDbConnection(ConnAcc);
                 string edittelephone = "update company set telephone = '" + TextBox3.Text + "' where id = " + id + "";
                 myConn.Open();//打开数据库
                 //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

                 OleDbCommand cmd = new OleDbCommand(edittelephone, myConn);
                 cmd.ExecuteNonQuery();
                 myConn.Close();//关闭数据库
                 num++;
         }
         if (oldcontent != newcontent)
         {
             OleDbConnection myConn = new OleDbConnection(ConnAcc);
             string up = "update company set content = '" + TextBox2.Text + "' where id = " + id + "";
             myConn.Open();//打开数据库
             //SqlDataAdapter cmdarticle = new SqlDataAdapter(article,myConn);

             OleDbCommand cmd = new OleDbCommand(up, myConn);
             cmd.ExecuteNonQuery();
             myConn.Close();//关闭数据库
             num++;
         }
         if (FileUpload14.PostedFile.FileName != "")
         {
             if (checkpic(FileUpload14.PostedFile.FileName) == 1)
             {
                 string pic = @".\image\company\" + id + ".jpg";
                 System.IO.File.Delete(Server.MapPath(pic));
                 this.FileUpload14.PostedFile.SaveAs(Server.MapPath(pic));
                 num++;
             }
         }
         if (num == 0)
         {

             Label2.Text = "企业修改失败";
         }
         else
         {
             Label2.Text = "企业修改成功";
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
        Response.Redirect("companyedit.aspx");
    }
}
