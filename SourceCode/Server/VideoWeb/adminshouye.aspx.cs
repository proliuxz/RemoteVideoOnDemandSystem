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
using System.IO;

public partial class adminshouye : System.Web.UI.Page
{
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    static string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

            myConn.Open();

            string article = "select * from 首页配置 ";

            OleDbDataAdapter cmd_article = new OleDbDataAdapter(article, myConn);

            DataSet ds = new DataSet();

            cmd_article.Fill(ds);
            TextBox1.Text = ds.Tables[0].Rows[0]["视频1编号"].ToString();
           
            TextBox2.Text = ds.Tables[0].Rows[0]["视频2编号"].ToString();
            path = ds.Tables[0].Rows[0]["广告图片地址"].ToString();

           
        }

    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminindex.aspx");
    }

    protected void updata()
    {
        //更新db
        OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

        myConn.Open();//打开数据库


        string article = "update 首页配置 set 视频1编号 = '" + TextBox1.Text + "',视频2编号 = '" + TextBox2.Text + "' where ID=" + 1;



        OleDbCommand cmd = new OleDbCommand(article, myConn);

        cmd.ExecuteNonQuery();

        myConn.Close();//关闭数据库

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            Label2.Text = "不能为空";
            return;
        }
        else if (TextBox2.Text == "")
        {
            Label5.Text = "不能为空";
            return;
        }
        
        else {
            string gp1 = "0";
            string gp2 = "0";
            OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化
            myConn.Open();
            string article0 = "select grouptype from video where grouptitle='" + TextBox1.Text + "'";
            OleDbDataAdapter cmd_article0 = new OleDbDataAdapter(article0, myConn);
            DataSet ds0 = new DataSet();
            cmd_article0.Fill(ds0);
            if (ds0.Tables[0].Rows.Count == 0)
            {
                Label2.Text = "该视频不存在";
                return;
            }
            else {
                gp1 =  (String)ds0.Tables[0].Rows[0][0];

            }
             string article1 = "select * from videogroup"+gp1+" where title='"+TextBox1.Text+"'";
            OleDbDataAdapter cmd_article1 = new OleDbDataAdapter(article1, myConn);
            DataSet ds1 = new DataSet();
            cmd_article1.Fill(ds1);
      
            if (ds1.Tables[0].Rows.Count == 0)
            {
                Label2.Text = "该视频不存在";
                return;
            }
            else {

                OleDbConnection myConn2 = new OleDbConnection(ConnAcc); //OleDb链接类的实例化
                myConn2.Open();
                string article2 = "select grouptype from video where grouptitle='" + TextBox2.Text + "'";
                OleDbDataAdapter cmd_article2 = new OleDbDataAdapter(article2, myConn);
                DataSet ds2 = new DataSet();
                cmd_article2.Fill(ds2);
                if (ds2.Tables[0].Rows.Count == 0)
                {
                    Label2.Text = "该视频不存在";
                    return;
                }
                else
                {
                    gp2 = (String)ds2.Tables[0].Rows[0][0];
                }
                string article3 = "select * from videogroup" + gp2 + " where title='" + TextBox2.Text + "'";
                OleDbDataAdapter cmd_article3 = new OleDbDataAdapter(article3, myConn2);
                DataSet ds3 = new DataSet();
                cmd_article3.Fill(ds3);
                if (ds3.Tables[0].Rows.Count == 0)
                {
                    Label5.Text = "该编号不存在";
                    return;
                }
                else 
                { 
                    updata();
                    Label2.Text = "已修改";
                    Label5.Text = "已修改";
                    if (this.FileUpload1.PostedFile.FileName == "")
                    {
                        Label7.Text = "不作修改";
                    }
                    else if (this.FileUpload1.PostedFile.FileName.Length > 0)
                    {
                        string exeName = this.FileUpload1.PostedFile.FileName.Substring(this.FileUpload1.PostedFile.FileName.LastIndexOf("."));
                        if (exeName == ".jpg")
                        {
                            string savePath = Server.MapPath(path + "1.jpg");//设置保存路径

                            if (File.Exists(savePath))
                            {
                                System.IO.File.Delete(savePath);
                            }

                            this.FileUpload1.PostedFile.SaveAs(savePath);

                            Label7.Text = "修改已成功";

                        }
                        else
                        {
                            Label2.Text = "文件类型必须为jpg格式";
                            return;
                        }
                    }
                    if (this.FileUpload2.PostedFile.FileName == "")
                    {
                        Label3.Text = "不作修改";
                    }
                    else if (this.FileUpload2.PostedFile.FileName.Length > 0)
                    {
                        string exeName = this.FileUpload2.PostedFile.FileName.Substring(this.FileUpload2.PostedFile.FileName.LastIndexOf("."));
                        if (exeName == ".jpg")
                        {
                            string savePath = Server.MapPath(path + "2.jpg");//设置保存路径

                            if (File.Exists(savePath))
                            {
                                System.IO.File.Delete(savePath);
                            }

                            this.FileUpload1.PostedFile.SaveAs(savePath);

                            Label3.Text = "修改已成功";

                        }
                        else
                        {
                            Label3.Text = "文件类型必须为jpg格式";
                            return;
                        }
                    }
                    if (this.FileUpload3.PostedFile.FileName == "")
                    {
                        Label6.Text = "不作修改";
                    }
                    else if (this.FileUpload3.PostedFile.FileName.Length > 0)
                    {
                        string exeName = this.FileUpload3.PostedFile.FileName.Substring(this.FileUpload3.PostedFile.FileName.LastIndexOf("."));
                        if (exeName == ".jpg")
                        {
                            string savePath = Server.MapPath(path + "3.jpg");//设置保存路径

                            if (File.Exists(savePath))
                            {
                                System.IO.File.Delete(savePath);
                            }

                            this.FileUpload1.PostedFile.SaveAs(savePath);

                            Label6.Text = "修改已成功";

                        }
                        else
                        {
                            Label6.Text = "文件类型必须为jpg格式";
                            return;
                        }
                    }
                    if (this.FileUpload4.PostedFile.FileName == "")
                    {
                        Label8.Text = "不作修改";
                    }
                    else if (this.FileUpload4.PostedFile.FileName.Length > 0)
                    {
                        string exeName = this.FileUpload4.PostedFile.FileName.Substring(this.FileUpload4.PostedFile.FileName.LastIndexOf("."));
                        if (exeName == ".jpg")
                        {
                            string savePath = Server.MapPath(path + "4.jpg");//设置保存路径

                            if (File.Exists(savePath))
                            {
                                System.IO.File.Delete(savePath);
                            }

                            this.FileUpload1.PostedFile.SaveAs(savePath);

                            Label8.Text = "修改已成功";

                        }
                        else
                        {
                            Label8.Text = "文件类型必须为jpg格式";
                            return;
                        }
                    }

                }

                }
            }
           
           
          
        }



    protected void usrcha(object sender, EventArgs e)
    {
        Label2.Text = "";
    }
    protected void passcha(object sender, EventArgs e)
    {
        Label5.Text = "";
    }
}
