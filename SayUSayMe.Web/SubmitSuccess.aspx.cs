using System;

public partial class SubmitSuccess : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["articleid"] != null)
        {
            articleID= Request.QueryString["articleid"];
            Page.DataBind();
        }
        
    }
    public string articleID = "";
}
