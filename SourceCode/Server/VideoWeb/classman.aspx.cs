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

public partial class classman : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("classadd.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("classquery.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("classedit.aspx");

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("classdel.aspx");

    }
    protected void return_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminindex.aspx");
    }
}
