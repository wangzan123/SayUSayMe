using System;
using System.Data;
using SayUSayMe.BLL;

public partial class EditUserDetails : System.Web.UI.Page
{
    DataTable userData;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateData();
        }
    }
    public void PopulateData()
    {
        if (Session["userName"] != null)
            userData = CatalogAccess.GetAllUserDetails(Session["userName"].ToString());
        else
            Response.Redirect("Default.aspx");
        Page.DataBind();
    }
    //处理页面绑定数据
    public string GetDetails(string type)
    {
        if (userData == null||Session["userName"]==null)
            return "";
        else
            if (userData.Rows.Count > 0)
            {
                if (userData.Rows[0]["userSex"].ToString() == "女")
                    script.Text = "<script type='text/javascript'>document.getElementById('girl').checked='checked';</script>";
                else
                    script.Text = "<script type='text/javascript'>document.getElementById('boy').checked='checked';</script>";
                switch (type)
                {
                    case "userName":
                        return Session["userName"].ToString();
                    case "userShowName":
                        return userData.Rows[0]["userShowName"].ToString();
                    case "userMajor":
                        return userData.Rows[0]["userMajor"].ToString();
                    case "userAddress":
                        return userData.Rows[0]["userAddress"].ToString();
                    case "userMoblie":
                        return userData.Rows[0]["userMoblie"].ToString();
                    case "userMaxim":
                        return userData.Rows[0]["userMaxim"].ToString();
                    default:
                        return "";
                }
            }
        return "";
    }
}
