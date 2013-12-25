using System;
using System.Web.UI.WebControls;

public partial class Article : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPage master = (MasterPage)Master;
        if (Request.QueryString["n"] != null)
            ((Literal)master.FindControl("url")).Text = "&nbsp;»&nbsp;<a href='" + Request.Url + "'>" + System.Web.HttpUtility.UrlDecode(Request.QueryString["n"]) + "</a>";
    } 
}
