using System;


public partial class indexPage : System.Web.UI.Page
{
    //页面公开一个字段
    public string TargetPage = "Default.aspx";
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["pg"]!=null)
            TargetPage = Request.QueryString["pg"];//5*1*a*s*p*x
    }
}
