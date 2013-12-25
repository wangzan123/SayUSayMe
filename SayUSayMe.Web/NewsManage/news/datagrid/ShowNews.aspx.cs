using System;
using System.Data;
using SayUSayMe.BLL;

public partial class NewsManage_news_datagrid_ShowNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string str = "http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=移动开发";
        //str = str.Substring(str.IndexOf("=") + 1, (str.Length - str.IndexOf("=") - 1));
        string SortName = Request.Url.ToString ();
        SortName = SortName.Substring (SortName.IndexOf ("=") + 1, (SortName.Length - SortName.IndexOf ("=") - 1));
        //Response.Write(SortName);
        DataTable dt = ArticleManage.getNewsBysortName(SortName);

        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
}