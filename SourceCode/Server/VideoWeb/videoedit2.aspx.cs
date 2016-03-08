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

public partial class videoedit2 : System.Web.UI.Page
{ //引导数据库连接数据库

    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    static string id;
    static string oldgrouptitle;
    static string oldvideotitle;
    static string oldvideodirname;
    static string oldfilename;
    static string oldgrouptype;
    static int oldvideoindex;
    static int a;
    static int b;
    static int num = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            id = Request.QueryString["ID"];
            OleDbConnection myConn = new OleDbConnection(ConnAcc); //OleDb链接类的实例化

            myConn.Open();

            string vid = "select * from video where ID=" + id + "";
            OleDbDataAdapter cmd_article = new OleDbDataAdapter(vid, myConn);
            DataSet ds = new DataSet();
            cmd_article.Fill(ds);
            Labelgt.Text = ds.Tables[0].Rows[0]["grouptitle"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["videotitle"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["videoindex"].ToString();
            oldgrouptitle = ds.Tables[0].Rows[0]["grouptitle"].ToString();
            oldvideotitle = ds.Tables[0].Rows[0]["videotitle"].ToString();
            oldvideodirname = ds.Tables[0].Rows[0]["videodirname"].ToString();
            oldfilename = ds.Tables[0].Rows[0]["videofilename"].ToString();
            oldgrouptype = ds.Tables[0].Rows[0]["grouptype"].ToString();
            oldvideoindex = Convert.ToInt32(ds.Tables[0].Rows[0]["videoindex"]);     
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = null;
        Label2.Text = null;
        Label3.Text = null;
        Label4.Text = null;
        if (TextBox2.Text != oldvideotitle) 
        {
            if (checkvideoname(TextBox2.Text)==1)
            {
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string updateinfo = "update video set videotitle ='" + TextBox2.Text + "' where ID="+id+"";
            myConn.Open();//打开数据库
            OleDbCommand cmd = new OleDbCommand(updateinfo, myConn);
            cmd.ExecuteNonQuery();
            num++;
            }
        }
        if (TextBox3.Text != oldvideoindex.ToString())
        {
            if (checkvideoindex(TextBox3.Text) == 1)
            {
                if (b < oldvideoindex)
                {
                    
                    OleDbConnection myConn = new OleDbConnection(ConnAcc);
                    myConn.Open();
                    string ups = "update video set videoindex = (videoindex+1) where videoindex>=" + b + " and videoindex<" + oldvideoindex + " and grouptitle='" + oldgrouptitle + "'";
                    OleDbCommand cmd = new OleDbCommand(ups, myConn);
                    cmd.ExecuteNonQuery();
                    string ups2 = "update video set videoindex = " + b + " where ID = " + id + "";
                    OleDbCommand cmd2 = new OleDbCommand(ups2, myConn);
                    cmd2.ExecuteNonQuery();
                }
                if (b > oldvideoindex)
                {
                    OleDbConnection myConn = new OleDbConnection(ConnAcc);
                    myConn.Open();
                    string ups = "update video set videoindex = (videoindex-1) where videoindex>" + oldvideoindex + " and videoindex<=" + b + " and grouptitle='" + oldgrouptitle + "'";
                    OleDbCommand cmd = new OleDbCommand(ups, myConn);
                    cmd.ExecuteNonQuery();
                    LabelBT.Text = ups;
                    string ups2 = "update video set videoindex = " + b + " where ID = " + id + "";
                    OleDbCommand cmd2 = new OleDbCommand(ups2, myConn);
                    cmd2.ExecuteNonQuery();
                }
                num++;
            }
        }
        if (FileUpload14.PostedFile.FileName != "")
        {
            if (checkvid(FileUpload14.PostedFile.FileName) == 1)
            {
                string vidsv = @".\" + oldvideodirname + @"\" + oldfilename;
                System.IO.File.Delete(Server.MapPath(vidsv));
                this.FileUpload14.PostedFile.SaveAs(Server.MapPath(vidsv));
                num++;
            }
        }
        if (num == 0)
        {
            Label1.Text = "视频修改失败";
        }
        else
        {
            Label1.Text = "视频修改成功";
        }
    }
    public int checkvideoindex(string str)
    {
        if (str.Length == 0)
        {
            Label3.Text = "播放顺序不能为空";
            return 0;
        }
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj;
        mj = "select * from video where grouptitle='" + oldgrouptitle + "'";
        OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
        DataSet ds = new DataSet();
        rs.Fill(ds);
        a = ds.Tables[0].Rows.Count;
        b = Convert.ToInt32(TextBox3.Text);
        if (b>a||b<1)
        {
            Label3.Text = "视频顺序不符合规则，请输入1~" + ds.Tables[0].Rows.Count + "";
            return 0;
        }
        else { return 1; }
    }
    public int checkvideoname(string str)
    {
        if (str.Length == 0)
        {
            Label2.Text = "视频名不能为空";
            return 0;
        }
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj;
        mj = "select * from video where videotitle='" + TextBox2.Text + "'";
        OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
        DataSet ds = new DataSet();
        rs.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label2.Text = "视频名已存在";
            return 0;
        }
        else { return 1; }
    }
    public int checkvid(string str)
    {
        if (str == "")
        {
            Label4.Text = "视频地址不能为空";
            return 0;
        }

        else if (str.Substring(str.LastIndexOf(".")) != ".mp4")
        {
            Label4.Text = "视频格式必须为mp4";
            return 0;
        }
        else { return 1; }
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videoedit.aspx");
    }
}
