using System;
using System.Text;
using System.Web.UI;
using System.Data;
using SayUSayMe.DAL;
using CatalogAccess = SayUSayMe.BLL.CatalogAccess;

public partial class UserControls_ShowArticle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            populateControl();
            GetWarningText();

            this.DataBind();
        }
    }
    //论坛版块公告
    public string GetWarningText()
    {
        string classID = Request.QueryString["classid"];
        if (classID != null)
        {
            DataTable table = CatalogAccess.GetWarningByClassID(Int32.Parse(classID));

            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["warning"].ToString();
            }
        }
        else
        {
            ltScript.Text = "<script type='text/javascript'>document.getElementById('warning').style.display='none';</script>";
        }
       return "";
    }
    //是否显示最新的图片
    public string GetNewImage(object dataItem)
    {
        DateTime addDate =DateTime.Parse(DataBinder.Eval(dataItem, "addDate").ToString());
        DateTime nowDate = DateTime.Now;
        TimeSpan span = new TimeSpan();
        span = nowDate.Subtract(addDate);
        if (span.Days < 2)
            return "<img src='image/new2.gif' />";
        else
            return "";

    }
    //绑定数据控件
    public void populateControl()
    {
        if (Request.QueryString["classid"]!=null)
        {
            string classID = Request.QueryString["classid"];
            string pageNumber = Request.QueryString["page"];
            if (pageNumber == null) pageNumber = "1";
            txtPage.Text = pageNumber;

            int howManyPage = 1;
            ShowArticle.DataSource = CatalogAccess.GetArticleByClassID(Int32.Parse(classID),Int32.Parse(pageNumber),out howManyPage);

            ShowPageNumber(howManyPage,Int32.Parse(pageNumber));
        }
        if (Request.QueryString["catalogid"]!=null)
        {

            string catalogID = Request.QueryString["catalogid"];

            string pageNumber = Request.QueryString["page"];
            if (pageNumber == null) pageNumber = "1";
            int howManyPage = 1;
            ShowArticle.DataSource = CatalogAccess.GetArticleByCatalogID(Int32.Parse(catalogID), Int32.Parse(pageNumber), out howManyPage);

            ShowPageNumber(howManyPage,Int32.Parse(pageNumber));
        }
        
        ShowArticle.DataBind();
    }
    //得到最新的回复
    public string GetLastestReply(object dataItem,string type)
    {
        int articleID = Int32.Parse(DataBinder.Eval(dataItem, "articleID").ToString());
        DataTable data ;
        if(Cache[articleID.ToString()]!=null)
        {
            data=(DataTable)Cache[articleID.ToString()];
        }
        else
        {
            data= CatalogAccess.GetLastestReplyByArticleID(articleID);
            Cache.Insert(articleID.ToString(), data, null, DateTime.Now.AddSeconds(1), TimeSpan.Zero);
        }
        if (data.Rows.Count > 0)
        {
            switch (type)
            {
                case "replyShortText":
                    return data.Rows[0]["replyShortText"].ToString();
                case "userShowName":
                    return data.Rows[0]["userShowName"].ToString();
                case "replyDate":
                    DateTime addDate = DateTime.Parse(data.Rows[0]["addDate"].ToString());
                    DateTime newTime = DateTime.Now;
                    TimeSpan span = new TimeSpan();
                    span = newTime.Subtract(addDate);

                    if (span.Days != 0)
                    {
                        return span.Days + "天前发表";
                    }
                    else if (span.Hours != 0)
                    {
                        return span.Hours + "小时前发表";
                    }
                    else
                    {
                        if (span.Minutes > 1)
                            return span.Minutes + "分钟前发表";
                        else
                            return "1分钟前发表";
                    }
                case "articleID":
                    return data.Rows[0]["articleID"].ToString();

            }
        }
        return "";
    }
    //显示页脚的页码
    public void ShowPageNumber(int howManyPage, int currentNumber)
    {
        System.Collections.Specialized.NameValueCollection query=Request.QueryString;
        string parmName;
        string newQueryString="?";
        //得到该页面本来所有的querystring
        for(int i=0;i<query.Count;i++)
        {
            if(query.AllKeys[i]!=null)
                if((parmName=query.AllKeys[i].ToString().ToLower())!="page")
                    newQueryString+=parmName+"="+query[i]+"&";
        }

        string pageUrl="<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>{$pageNumber}</a></span>";
        string tempUrl = "";
        
        if (howManyPage > 1&&currentNumber<=howManyPage)
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
                pageNumber.Text +=pageUrl.Replace("{$pageNumber}", (currentNumber+1).ToString());
            }
            else
            {
                int i;
                if (howManyPage - GetConfigurationSettings.NumberPerPage > 0)
                    i = howManyPage - GetConfigurationSettings.NumberPerPage;
                else
                    i = 1;

                for ( ; i <= howManyPage; i++)
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
                pageNumber.Text += pageUrl.Replace("{$pageNumber}", (currentNumber+1).ToString());
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
    protected void ShowArticle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public string checkGrade(string articleGrade)
    {
        if (articleGrade == "1")
            return "<img src='image/jiajing.png'/>";
        else
            return "<img src='image/topicnew.gif'/>";
    }
}
