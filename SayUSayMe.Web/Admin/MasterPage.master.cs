using System;
using SayUSayMe.BLL;


public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            string scriptText="<script type='text/javascript'>document.getElementById('helloText').innerHTML='{$userName}{$userType}';</script>";
            int intRole = CatalogAdmin.GetUserRoleByName(Session["userName"].ToString());
            Session["role"] = intRole;
            if (intRole == 0)
                script.Text = scriptText.Replace("{$userName}", Session["userName"].ToString()).Replace("{$userType}", "系统管理员");
            else 
                script.Text = scriptText.Replace("{$userName}", Session["userName"].ToString()).Replace("{$userType}", "版主");
        }
        if (!Page.IsPostBack)
            Page.DataBind();
    }
}
