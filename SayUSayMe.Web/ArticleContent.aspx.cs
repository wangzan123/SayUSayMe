using System;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using SayUSayMe.DAL;
using CatalogAccess = SayUSayMe.BLL.CatalogAccess;
using CatalogAdmin = SayUSayMe.BLL.CatalogAdmin;

public partial class ArticleContent : System.Web.UI.Page
{
    string p = "";
    DataTable ArticleTable;
    DataTable UserTable;
    DataTable ArticleTallTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        AddArticle2.OperateType = "LeaveWord";
        setMesu();
        if (!IsPostBack)
        {
            
            populateControls();
            //MasterPage master = (MasterPage)Master;
            //if (ArticleTable != null)
            //{
            //    if (Request.QueryString["n"] != null)
            //    {
                    
            //        ((Literal)master.FindControl("url")).Text = "&nbsp;»&nbsp;<a href='Article.aspx?" + Url + "'>" + System.Web.HttpUtility.UrlDecode(Request.QueryString["n"]) + "</a>&nbsp;»&nbsp;" +
            //                                                    "<a href='" + this.Request.Url + "'>" + ArticleTable.Rows[0]["articleSubject"].ToString() + "</a>";
            //    }
            //}
            
        }
        
    }
    public void setMesu()
    {
        string aid = Request.QueryString["articleid"];
        if(aid==null) return ;
        DbCommand   com=GenericDataAccess.CreateCommand();
        com.CommandText="GetMessageByArticleID";
        DbParameter pam=com.CreateParameter();
        pam.DbType=DbType.Int32;
        pam.ParameterName="@articleid";
        pam.Value=Convert.ToInt32(aid);
        com.Parameters.Add(pam);
       DataTable dt= GenericDataAccess.ExecuteSelectCommand(com);
       string Url = "classid=" + dt.Rows[0]["classID"].ToString() + "&n=" + System.Web.HttpUtility.UrlEncode(dt.Rows[0]["className"].ToString());
       MasterPage master = (MasterPage)Master;
       ((Literal)master.FindControl("url")).Text = "&nbsp;»&nbsp;<a href='Article.aspx?" + Url + "'>" + System.Web.HttpUtility.UrlDecode(dt.Rows[0]["className"].ToString()) + "</a>&nbsp;»&nbsp;" +
                                                                "<a href='" + this.Request.Url + "'>" + dt.Rows[0]["articleSubject"].ToString() + "</a>";
    
    }

    private void ExecuteSelectCommand(DbCommand com)
    {
        throw new NotImplementedException();
    }
    //绑定控件
    public void populateControls()
    {
        if (Request.QueryString["articleid"] == null)
            return;

        string articleID = Request.QueryString["articleid"];
        string pageNumber = Request.QueryString["page"];
        if (pageNumber == null) pageNumber = "1";
        p = pageNumber;
        txtPage.Text = pageNumber;
        UserTable = new DataTable();
        ArticleTable = new DataTable();
        ArticleTallTable = new DataTable();
        int Aid = 0;
        try { Aid = Int32.Parse(articleID); }
        catch (Exception e)
        {
            AricleIDExceptionScript.Text = "<script type='text/javascript'>alert('文章id非法');</script>";
            Response.Redirect("Default.aspx");
        }
        ArticleTable = CatalogAccess.GetArticleContentByID(articleID);//帖子内容
        if (ArticleTable.Rows.Count <= 0) 
        {
            AricleIDExceptionScript.Text = "<script type='text/javascript'>alert('文章不存在');</script>";
            Response.Redirect("Default.aspx");
        }
        UserTable = CatalogAccess.GetUserDetailsByArticleID(articleID);//用户资料

        //绑定帖子回复表
        int howManyPage=1;
        ArticleTallTable = CatalogAccess.GetArticleTallByID(Int32.Parse(articleID),Int32.Parse(pageNumber), out howManyPage);
        ShowPageNumber(howManyPage,Int32.Parse( pageNumber));

        showReturn.DataSource = ArticleTallTable;
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

        string pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>{$pageNumber}</a></span>"; ;
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
    //显示回复的用户信息(评论用户)
    public string GetUserGradePic(object dataItem)
    {
        int[] level = new int[4];
        level[0] = Int32.Parse(ArticleTallTable.Rows[0]["level1"].ToString());
        level[1] = Int32.Parse(ArticleTallTable.Rows[0]["level2"].ToString());
        level[2] = Int32.Parse(ArticleTallTable.Rows[0]["level3"].ToString());
        level[3] = Int32.Parse(ArticleTallTable.Rows[0]["level4"].ToString());
        string imgHtml = "<img src='{$url}' />";
        StringBuilder userGradePic = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            if (level[i] > 0)
                for (int j = 1; j <= level[i]; j++)
                    userGradePic.Append(imgHtml.Replace("{$url}", GetConfigurationSettings.LevelPic(i)));
        }
        return userGradePic.ToString();
    }
    //得到用户属性(发表文章的用户)
    public string GetUserDetails(string type)
    {
        if (UserTable == null)
            return "";
        if (UserTable.Rows.Count > 0)
        {
            switch (type)
            {
                //用户名
                case "userName":
                    if (Session["userName"] != null)
                        if (UserTable.Rows[0]["userName"].ToString() == Session["userName"].ToString())
                        {
                            if (Int32.Parse(ArticleTable.Rows[0]["state"].ToString()) != (int)EnumEntity.ArticleState.articleDeleteState)
                            {
                               // script.Text = "<script type='text/javascript'>document.getElementById('replyOperation').innerHTML+='&nbsp;<a href=\"AddArticle.aspx?reWriteArticleID=" + ArticleTable.Rows[0]["articleID"].ToString() + "\">修改</a>';var showreply=document.getElementById('showreply');showreply.style.display='';document.getElementById('addreply').style.display='none';</script>";
                     
                            }
                                
                                
                            else
                                script.Text = "<script type='text/javascript'>document.getElementById('replyOperation').innerHTML+='&nbsp;<a href=\"AddArticle.aspx?type=sq&id=" + Request.QueryString["articleid"] + "&name=" + HttpUtility.UrlEncode("上诉申请") + "&an=" + HttpUtility.UrlEncode(ArticleTable.Rows[0]["articleSubject"].ToString()) + "\">对删除质疑，上诉申请</a>';</script>";
                        }
                    
                    return UserTable.Rows[0]["userShowName"].ToString();
                //用户等级
                case "userGradePic":
                    int[] level = new int[4];
                    level[0] =Int32.Parse( UserTable.Rows[0]["level1"].ToString());
                    level[1] =Int32.Parse( UserTable.Rows[0]["level2"].ToString());
                    level[2] =Int32.Parse( UserTable.Rows[0]["level3"].ToString());
                    level[3] =Int32.Parse( UserTable.Rows[0]["level4"].ToString());
                    string imgHtml = "<img src='{$url}' />";
                    StringBuilder userGradePic = new StringBuilder();
                    for (int i = 0; i < 4; i++)
                    {
                        if(level[i]>0)
                            for(int j=0;j<level[i];j++)
                                userGradePic.Append(imgHtml.Replace("{$url}",GetConfigurationSettings.LevelPic(i)));
                    }
                    return userGradePic.ToString();
                //用户个性签名
                case "userShowName":
                    return UserTable.Rows[0]["userShowName"].ToString();
                //用户头像
                case "headPhoto":
                    return  UserTable.Rows[0]["headPhoto"].ToString();
                default: return "";
            }
        }
        return "";
        
    }
    //文章属性
    public string GetArticleContent(string type)
    {
        if (ArticleTable == null)
            return "";
        if (ArticleTable.Rows.Count > 0)
        {
            //当文章被删除时，用户自己可以浏览文章内容，系统管理员可以浏览文章内容
            if (Session["userName"] != null)
            {
                if (CatalogAdmin.GetUserRoleByName(Session["userName"].ToString()) == GetConfigurationSettings.SysAdmin || UserTable.Rows[0]["userName"].ToString() == Session["userName"].ToString())
                {
                    switch (type)
                    {
                        case "subject":
                            return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleSubject"].ToString());
                        case "content":
                            if (Int32.Parse(ArticleTable.Rows[0]["state"].ToString()) == (int)EnumEntity.ArticleState.articleDeleteState)//------判断文章状态
                                return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleContent"].ToString() + "<hr /><span style='color:red;'>此文章已被删除</span>");
                            else if (Int32.Parse(UserTable.Rows[0]["userState"].ToString()) == (int)EnumEntity.UserState.deleteState)
                                  return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleContent"].ToString())+"<span class='file' style='margin:5px 30px; padding:4px 8px; color:red; font-size:13px; position:absolute;'>该用户被禁言！</span>";
                            else
                                return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleContent"].ToString());
                        case "date":
                            return ArticleTable.Rows[0]["addDate"].ToString();
                        case "articleID":
                            return ArticleTable.Rows[0]["articleID"].ToString();
                        default: return "";
                    }
                }
            }
            //游客浏览非文章删除状态
            if (Int32.Parse(ArticleTable.Rows[0]["state"].ToString()) != (int)EnumEntity.ArticleState.articleDeleteState)
            {
                switch (type)
                {
                    case "subject":
                        return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleSubject"].ToString());
                    case "content":
                        if (Int32.Parse(UserTable.Rows[0]["userState"].ToString()) == (int)EnumEntity.UserState.deleteState)
                            return "<span class='file' style='margin:5px 30px; padding:4px 8px; color:red; font-size:13px; position:absolute;'>该用户被禁言！</span>";
                        else
                            return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleContent"].ToString());
                        //if(Int32.Parse(ArticleTable.Rows[0]["state"].ToString())== (int)EnumEntity.ArticleState.articleDeleteState)  
                        //    return HttpContext.Current.Server.HtmlDecode(ArticleTable.Rows[0]["articleContent"].ToString()+ "<hr /><span style='color:red;'>此文章已被删除</span>");
                        //else
                            
                    case "date":
                        return ArticleTable.Rows[0]["addDate"].ToString();
                    case "articleID":
                        return ArticleTable.Rows[0]["articleID"].ToString();
                    default: return "";
                }
            }
            //游客浏览删除状态
            else
                switch (type)
                {
                    case "subject":
                    case "date":
                    case "articleID":
                        return "";
                    case "content":
                        return "<span class='file' style='margin:5px 30px; padding:4px 8px; color:red; font-size:13px; position:absolute;'>你所浏览的文章已被管理员删除</span>";
                    default: return "";
                }
        }
        return "";
    }
    //得到有主题的附件
    public string GetArticleFiles(string AID) 
    {   int ID=0;
        string fileLink = "";
        DataTable FileTable = new DataTable();
        try { ID = Int32.Parse(AID); }
        catch (Exception e) 
        {
            return fileLink;
        }
        
        FileTable = CatalogAccess.GetArticleFileByID(ID, "Article");
        for (int i = 0; i < FileTable.Rows.Count; i++)
        {
            fileLink += "<a href='" + FileTable.Rows[i]["fileUrl"].ToString() + "'><img src='image/rar.gif' style='border:0px' />&nbsp;&nbsp;" + FileTable.Rows[i]["fileDescription"].ToString() + "</a><br/>";
        }
        return fileLink;


    }
    //得到回复的附件
    public string GetFile(object dataItem,string type)
    {   
        string fileLink="";
        DataTable FileTable = new DataTable();
        int ID = 0;
        if (type.Equals("Reply"))
        {
            if ((ID = Int32.Parse(DataBinder.Eval(dataItem, "commentID").ToString())) != -1)
            {
                FileTable = CatalogAccess.GetArticleFileByID(ID, "Reply");
            }
            for (int i = 0; i < FileTable.Rows.Count; i++)
            {
                fileLink += "<a href='" + FileTable.Rows[i]["fileUrl"].ToString() + "'><img src='image/rar.gif' style='border:0px' />&nbsp;&nbsp;" + FileTable.Rows[i]["fileDescription"].ToString() + "</a><br/>";
            }
            return fileLink;
        }
        else { return ""; }
        return "";

  
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
    //引用回复同回复回复操作
    public string CommentOperation(string cid, string cname,string type)
    {
        int id = 0;
        string aID = Request.QueryString["articleid"].ToString();
        try 
        { 
            id = Int32.Parse(cid);
        }
        catch (Exception e)
        {
            replyCommentScirpt.Text = "<script type='text/javascript'>alert('文章不存在');</script>";
           
            Response.Redirect("Default.aspx");
        }
        if (Session["userName"] == null)
        {
            if ("quote".Equals(type)) 
            {
                return "<a href='javascript:' onclick=\"alert('请登陆再引用留言');return false;\">引用</a>";
            
            }
            else if ("replyComment".Equals(type)) 
            {
                return "<a href='javascript:' onclick=\"alert('请登陆再回复');return false;\">回复</a>";
            }
            
        }
        else 
        {
            if ("quote".Equals(type))
            {
                return "<a href='QuoteToReply.aspx?QuoteCommentID=" + cid + "&aid=" + aID + "&page=" + p + "'>引用</a>";

            }
            else if ("replyComment".Equals(type))
            {
                return "<a href='ReplyToReply.aspx?ReplyCommentID=" + cid + "&aid=" + aID + "&page=" + p + "'>回复</a>";
            }
        }
        return "";
       
    }
    //返回更新回复的链接
    public string UpdateComment(string cid,string cname)
    {
        string aID = Request.QueryString["articleid"].ToString();
        
        int id = 0;
        try { id = Int32.Parse(cid); }
        catch (Exception e) 
        {
            script.Text = "<script type='text/javascript'>alert('文章不存在');</script>";
            Response.Redirect("Default.aspx");
        }
        if (Session["userName"] == null)
        {
            return "";

        }
        else 
        {   
            if (cname.Equals(Session["userName"]))
            {
                
                return "&nbsp;&nbsp;<img src='image/pencil.png'/>&nbsp;" + "<a href='UpdateReply.aspx?reCommentID=" + cid + "&aid=" + aID + "&page=" + p + "'>修改</a>";
            }
        }
        return "";
    
    }
    public string UpdateArticleLink(string name)
    {
        if (Session["userName"] == null)
        {
            return "";

        }
        else
        {
            if (name.Equals(Session["userName"].ToString()))
            {
                return "&nbsp;&nbsp;&nbsp;<img src='image/pencil.png'/>" + "<a href='AddArticle.aspx?reWriteArticleID=" + ArticleTable.Rows[0]["articleID"].ToString() + "\'>修改</a>";
               
            }
            else
            {
                return "";
            }


        }

    }
    public string GetReplyContent(string content,string state)
    {
        if (state == "1")
            return content;
        else if (state == "0")
            return "该用户被禁言！";
        else if (state == "2")
            return "该用户已停用！";
        else
            return "";
    }
}
