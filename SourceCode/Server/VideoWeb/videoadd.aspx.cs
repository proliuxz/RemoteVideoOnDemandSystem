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

public partial class videoadd : System.Web.UI.Page
{
    OleDbConnection myConn = new OleDbConnection(ConnAcc);
    static int num;
    static int tb;
    static string videodirname;

    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    //方法

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OleDbConnection myConn = new OleDbConnection(ConnAcc);
            string mj;

            //定义sql 语句 [查询这张表的所有的数据]
            mj = "select * from videogroup0 order by ID";
            //结果集 对象
            OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
            //集合
            DataSet ds = new DataSet();
            //把rs 给了ds
            rs.Fill(ds);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "title";
            DropDownList1.DataValueField = "title";
            DropDownList1.DataBind();
            DropDownList1.Visible = true;
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
     
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mj;
        int nameno;
        mj = "select * from videogroup0 where title='" + DropDownList1.Text + "'";
        OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
        DataSet ds = new DataSet();
        rs.Fill(ds);
        videodirname = ds.Tables[0].Rows[0]["videodirname"].ToString();
        if (checkvideoname(TextBox2.Text)+checkvideoindex(TextBox3.Text)+checkvid(FileUpload14.PostedFile.FileName)==3)
        {
            myConn.Open();//打开数据库
            if (num != tb)
            {
                    string ups = "update video set videoindex = (videoindex+1) where videoindex>=" + tb + " and grouptitle='" + DropDownList1.Text + "'";
                    OleDbCommand cmd = new OleDbCommand(ups, myConn);
                    cmd.ExecuteNonQuery();
            }
            nameno=num;
            while (checkna(nameno, videodirname))
            {
                nameno++;
            }
            
            string add = "insert into video(grouptitle,videotitle,videodirname,videofilename,grouptype,videoindex) SELECT title,'"+TextBox2.Text+"',videodirname,'"+nameno+".mp4',0,"+tb+" from videogroup0 where title = '"+DropDownList1.Text+"'";
            //string add = "insert into recorddetail(videotitle,videoindex,grouptitle,userid) SELECT videotitle,videoindex,grouptitle,'" + uid + "' from video where grouptitle='" + grouptitle + "' AND videoindex=" + i + "";
            OleDbCommand cmd2 = new OleDbCommand(add, myConn);//创建Command命令对象
            cmd2.ExecuteNonQuery();//执行命令
            string vidsv = @".\" + videodirname + @"\"+nameno+".mp4";
            this.FileUpload14.PostedFile.SaveAs(Server.MapPath(vidsv));
            Label1.Text = "添加成功";
            TextBox2.Text = null;
            TextBox3.Text = null;

        
        }
    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("videoman.aspx");
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
    public int checkvideoindex(string str)
    {
        if (str.Length == 0)
        {
            Label3.Text = "播放顺序不能为空";
            return 0;
        }
        OleDbConnection myConn = new OleDbConnection(ConnAcc);
        string mj;
        mj = "select * from video where grouptitle='" + DropDownList1.Text + "'";
        OleDbDataAdapter rs = new OleDbDataAdapter(mj, myConn);
        DataSet ds = new DataSet();
        rs.Fill(ds);
        num = ds.Tables[0].Rows.Count + 1;
        tb = Convert.ToInt32(TextBox3.Text);
        if (ds.Tables[0].Rows.Count + 1 <Convert.ToInt32(TextBox3.Text) || Convert.ToInt32(TextBox3.Text) <= 0)
        {
            Label3.Text = "视频顺序不符合规则，请输入1~"+ds.Tables[0].Rows.Count+"";
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
    public bool checkna(int x,string dirname)
    { 
        string addr = dirname+@"\"+x+".mp4";

        if (File.Exists(Server.MapPath(addr)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
