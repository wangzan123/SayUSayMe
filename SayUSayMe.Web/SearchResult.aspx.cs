using System;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using SayUSayMe.DAL;
using CatalogAccess = SayUSayMe.BLL.CatalogAccess;

public partial class SearchResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            populateControl();
            MasterPage master = (MasterPage)Master;
            if (Request.QueryString["s"] != null)
            {
                ((TextBox)master.FindControl("txtSearch")).Text = searchTxt;
            }
            else
                return;
        }
    }
    protected string searchTxt;
    public void populateControl()
    {
        searchTxt = HttpUtility.UrlDecode(Request.QueryString["s"]);
        string page = Request.QueryString["page"];
        string allwords = Request.QueryString["allwords"];
        if (page == null) page = "1";
        int howManyPage=1;
        //显示页码
        txtPage.Text = page;

        //得到数据源
        DataTable data = CatalogAccess.SelectResultData(searchTxt, Int32.Parse(page), out howManyPage, allwords);
        if (data.Rows.Count <= 0)
            Response.Write("<script type='text/javascript'>alert('没有找到相关资源！请尝试搜索其他内容^ 0 ^');</script>");
        //调用分页函数
        ShowPageNumber(howManyPage,Int32.Parse(page));
        gridSearch.DataSource = data;
        gridSearch.DataBind();
        Page.DataBind();
    }
    //显示页脚的页码
    public void ShowPageNumber(int howManyPage, int currentNumber)
    {
        System.Collections.Specialized.NameValueCollection query = Request.QueryString;
        string parmName;
        string newQueryString = "?";
        //得到该页面本来所有的querystring
        for (int i = 0; i < query.Count; i++)
        {
            if (query.AllKeys[i] != null)
                if ((parmName = query.AllKeys[i].ToString().ToLower()) != "page")
                    newQueryString += parmName + "=" + query[i] + "&";
        }

        string pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>{$pageNumber}</a></span>";
        string tempUrl = "";

        if (howManyPage > 1 && currentNumber <= howManyPage)
        {
            if ((howManyPage - currentNumber) > GetConfigurationSettings.NumberPerPage)
            {

                for (int i = currentNumber; i <= GetConfigurationSettings.NumberPerPage + currentNumber; i++)
                {
                    tempUrl = pageUrl;
                    if (i == currentNumber)
                    {
                        tempUrl = tempUrl.Replace("{$backColor}", "#0000aa");
                        tempUrl = tempUrl.Replace("{$fontColor}", "#ffffff");
                    }
                    else
                    {
                        tempUrl = tempUrl.Replace("{$backColor}", "");
                        tempUrl = tempUrl.Replace("{$fontColor}", "");
                    }
                    pageNumber.Text += tempUrl.Replace("{$pageNumber}", i.ToString());

                }
                pageNumber.Text += "..." + pageUrl.Replace("{$pageNumber}", howManyPage.ToString());
                pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>下一页</a></span>"; ;
                pageNumber.Text += pageUrl.Replace("{$pageNumber}", (currentNumber + 1).ToString());
            }
            else
            {
                int i;
                if (howManyPage - GetConfigurationSettings.NumberPerPage > 0)
                    i = howManyPage - GetConfigurationSettings.NumberPerPage;
                else
                    i = 1;

                for (; i <= howManyPage; i++)
                {
                    tempUrl = pageUrl;
                    if (i == currentNumber)
                    {
                        tempUrl = tempUrl.Replace("{$backColor}", "#0000aa");
                        tempUrl = tempUrl.Replace("{$fontColor}", "#ffffff");
                    }
                    else
                    {
                        tempUrl = tempUrl.Replace("{$backColor}", "");
                        tempUrl = tempUrl.Replace("{$fontColor}", "");
                    }
                    pageNumber.Text += tempUrl.Replace("{$pageNumber}", i.ToString());

                }

                pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>下一页</a></span>"; ;
                pageNumber.Text += pageUrl.Replace("{$pageNumber}", (currentNumber + 1).ToString());
            }
            ltScript.Text += "<script type='text/javascript'>document.getElementById('pageJump').style.display='';</script>";
        }


    }
    //跳转页按钮
    public void btnPageNumberClick(object sender, EventArgs e)
    {
        System.Collections.Specialized.NameValueCollection query = Request.QueryString;
        string parmName;
        string newQueryString = "?";
        //得到该页面本来所有的querystring
        for (int i = 0; i < query.Count; i++)
        {
            if (query.AllKeys[i] != null)
                if ((parmName = query.AllKeys[i].ToString().ToLower()) != "page")
                    newQueryString += parmName + "=" + query[i] + "&";
        }
        Response.Redirect(Request.Url.AbsolutePath + newQueryString + "page=" + txtPage.Text);
    }
}
