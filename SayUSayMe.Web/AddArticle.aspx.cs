using System;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;

public partial class AddArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 

        MasterPage master = (MasterPage)Master;
        Literal urlControl=(Literal)master.FindControl("url");

        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先登陆！');</script>");
            Response.Redirect("Default.aspx");
        }
        else if (CatalogAdmin.checkUserState(Session["userName"].ToString().Trim()) == "0")
        {
            Response.Write("<script>alert('你已被禁言！');</script>");
            Response.Redirect("Default.aspx");
        }
        if (Request.QueryString["type"] != null && Request.QueryString["type"] == "sq")
        {
            AddArticle2.OperateType = "Apply";
            urlControl.Text += "&nbsp;?&nbsp;申请";
        }
        else
        {
            AddArticle2.OperateType = "AddArticle";
            urlControl.Text += "&nbsp;?&nbsp;发帖";
        }
 #endregion
    }
    
}
