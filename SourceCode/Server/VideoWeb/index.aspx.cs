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

public partial class index : System.Web.UI.Page
{ //引导数据库连接数据库
    protected static string ConnAcc = ConfigurationSettings.AppSettings["ConnAcc"];
    static int current =1;
    static int num = 0;
    static DataSet ds,ds1;

    public void Page_Load(object sender, EventArgs e)
    { 
       

    }
   
   
    protected void down(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("index.aspx");
    }
}