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

public partial class userman : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("useradd.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("userquery.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("useredit.aspx");

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("userdel.aspx");

    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminindex.aspx");
    }
}
