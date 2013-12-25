using System;
using SayUSayMe.BLL;

public partial class Admin_UserControl_AddCatalog : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userName"] != null)
        //{
        //    if (Int32.Parse(Session["role"].ToString()) != GetConfigurationSettings.SysAdmin)
        //    {
        //        script.Text = "<script type='text/javascript'>alert('您没有权限查看此页');</script>";
        //        Response.Redirect("Default.aspx");
        //    }

        //}
        //else
        //    Response.Redirect("~/Default.aspx"); 
        
    }
    //添加板块
    public void BtnAddClick(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (CatalogAdmin.AddCatalog(catalogName.Text.Trim(), indexUrl.Text.Trim(), catalogDescription.Text.Trim()))
                script.Text = "<script type='text/javascript'>if(confirm('添加成功，此版块还没有子板块，是否马上添加子版块？'))location.href='AddClass.aspx?type=" +System.Web.HttpUtility.UrlEncode(catalogName.Text.Trim())+ "'</script>";
            else
                script.Text = "<script type='text/javascript'>alert('添加失败');</script>";
        }
    }
}
