using System;
using System.Data;
using SayUSayMe.BLL;

public partial class UserControlIndex : System.Web.UI.Page
{
    
    DataTable userData;
    DataTable messagesData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateControls();
            this.DataBind();
        }
    }
    //绑定数据内容
    public void PopulateControls()
    {

        if (Session["userName"] == null)
            Response.Redirect("Default.aspx");
        else
        {
            userData = CatalogAccess.GetUserDetailsByName(Session["userName"].ToString());
            messagesData = CatalogAccess.GetNewMessagesByUserName(Session["userName"].ToString(), false);
            messages.DataSource = messagesData;
            messages.DataBind();
        }
    }
    //绑定页面用户信息
    public string GetUserDetails(string type)
    {
        System.Text.StringBuilder details;
        switch (type)
        {
            case "image":
                return userData.Rows[0]["headPhoto"].ToString();
            case "details":
                details = new System.Text.StringBuilder();
                details.Append("您的用户名: " + userData.Rows[0]["userName"].ToString() + "<br />");
                details.Append("您的等级: " + userData.Rows[0]["gradeID"].ToString() + "<br />");
                details.Append("您的论坛金币: " + userData.Rows[0]["userPurse"].ToString() + "<br />");
                details.Append("您的积分:"+userData.Rows[0]["userScore"].ToString()+"<br />");
                if (Int32.Parse(userData.Rows[0]["userState"].ToString()) == 1)
                    details.Append("您的状态: 正常使用<br />");
                else if (Int32.Parse(userData.Rows[0]["userState"].ToString()) ==0)
                    details.Append("您的状态:<span style='color:red'> 已被禁言</span><br />");
                else 
                    details.Append("您的状态:<span style='color:red'> 已被停用</span><br />");
                details.Append("您注册的日期是: "+userData.Rows[0]["addDate"].ToString()+"<br />");
                return details.ToString() ;
            default:
                return "";

        }
        return "";
    }
    //绑定gridview
    public int GetHowManyMessage()
    {
        return messagesData.Rows.Count;
    }

    protected void messages_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        messages.PageIndex = e.NewPageIndex;
        PopulateControls();
    }
}
