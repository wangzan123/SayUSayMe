using System;
using System.Web.UI;
using System.Data;
using SayUSayMe.BLL;

public partial class UserControls_ShowCatalog : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateControl();
            
        }
    }

    //绑定数据控件
    public void PopulateControl()
    {
        catalog.DataSource = CatalogAccess.GetArticleCatalog();
        catalog.DataBind();
        Page.DataBind();
    }
    //得到版主
    public string GetBordAdmin(object dataItem, string type)
    {
        DataTable data=null;
        string popedom = Convert.ToString(DataBinder.Eval(dataItem, "popedom"));
        string bordName="";
        string bordType = "catalogid";
        int bordID=-1;
        
        //判断是板块还是子版块
        switch (type)
        {
            case "catalog":
                bordID = Int32.Parse(DataBinder.Eval(dataItem, "catalogID").ToString());
                bordName=DataBinder.Eval(dataItem,"catalogName").ToString();
                bordType = "catalogid";
                data = CatalogAccess.GetBordAdminByID(bordID, "catalog");
                break;
            case "class":
                bordID = Int32.Parse(DataBinder.Eval(dataItem, "classID").ToString());
                bordName=DataBinder.Eval(dataItem,"className").ToString();
                bordType = "classid";
                data = CatalogAccess.GetBordAdminByID(bordID, "class");
                break;
        }
        string returnText = "版主：";
        string user = "<a href='UserHomePage.aspx?id={$userID}'>{$userName}</a>&nbsp;&nbsp;";
         string apply = "<a href='AddArticle.aspx?type=sq&pp=" + popedom + "&" + bordType + "=" + bordID.ToString() + "&bordName=" + System.Web.HttpUtility.UrlEncode(bordName) + "&name=" + System.Web.HttpUtility.UrlEncode("版主申请") + "' onclick='checkUserType(this);return false;'>版主申请</a>";

        
        
        if (data != null)
        {
            if (data.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow row in data.Rows)
                {
                    user = user.Replace("{$userID}", row["userID"].ToString());
                    returnText += user.Replace("{$userName}", row["userName"].ToString());
                    i++;
                }
                if(i<3)
                    returnText += apply;
            }
            else
                return returnText += "<a style='color:red;'>暂缺</a>&nbsp;&nbsp;" +apply;
        }
        return returnText;
    }
    //得到当天的文章数
    public int GetTodayArticleByClassID(object item)
    {
        int classID = Int32.Parse(DataBinder.Eval(item, "classID").ToString());
        return CatalogAccess.GetTodayArticleByClassID(classID);
    }
    //内容绑定url
    public string GetContentUrl(object dataItem)
    {
        int catalogID = Int32.Parse(DataBinder.Eval(dataItem, "catalogID").ToString());
        switch (catalogID)
        {
            case 1:
            case 2:
            case 4: return "Article.aspx?";break;
            case 3: return "DownlCatalog.aspx?";break;
        }
        return "Article.aspx?";
    }

    
    //得到某主题下最新发表的文章
    public string GetSubject(object dataItem)
    {
        DataTable data;
        //主题ID号
        int classID = 0;
        //文章主题
        string subject = "";
        if (Cache[classID.ToString()] != null)
        {
            data = (DataTable)Cache[classID.ToString()];
        }
        else
        {
            classID = Int32.Parse(DataBinder.Eval(dataItem, "classID").ToString());
            data = CatalogAccess.GetLastestArticleByClassID(classID);
            Cache.Insert(classID.ToString(), data, null, DateTime.Now.AddSeconds(2), TimeSpan.Zero);
        }
        if (data.Rows.Count > 0)
            subject = data.Rows[0]["subject"].ToString();
        return subject;
    }
    //得到文章ID
    public int GetArticleID(object dataItem)
    {
        DataTable data;
        //主题ID号
        int classID = 0;
        //文章主题的ID号
        int articleID = 0;
        if (Cache[classID.ToString()] != null)
        {
            data = (DataTable)Cache[classID.ToString()];
        }
        else
        {
            classID = Int32.Parse(DataBinder.Eval(dataItem, "classID").ToString());
            data = CatalogAccess.GetLastestArticleByClassID(classID);
            Cache.Insert(classID.ToString(), data, null, DateTime.Now.AddSeconds(2), TimeSpan.Zero);
        }
        if (data.Rows.Count > 0)
            articleID = Int32.Parse(data.Rows[0]["articleID"].ToString());
        return articleID;
    }
    //作者名
    public string GetUserName(object dataItem)
    {
        DataTable data;
        //主题ID号
        int classID = 0;
        //作者名
        string userName = "";
        if (Cache[classID.ToString()] != null)
        {
            data = (DataTable)Cache[classID.ToString()];
        }
        else
        {
            classID = Int32.Parse(DataBinder.Eval(dataItem, "classID").ToString());
            data = CatalogAccess.GetLastestArticleByClassID(classID);
            Cache.Insert(classID.ToString(), data, null, DateTime.Now.AddSeconds(2), TimeSpan.Zero);
        }
        if (data.Rows.Count > 0)
            userName = data.Rows[0]["userShowName"].ToString();
        return userName;
    }
    //作者ID号
    public int GetUserID(object dataItem)
    {
        DataTable data;
        //主题ID号
        int classID = 0;
        //作者ID
        int userID = 0;
        if (Cache[classID.ToString()] != null)
        {
            data = (DataTable)Cache[classID.ToString()];
        }
        else
        {
            classID = Int32.Parse(DataBinder.Eval(dataItem, "classID").ToString());
            data = CatalogAccess.GetLastestArticleByClassID(classID);
            Cache.Insert(classID.ToString(), data, null, DateTime.Now.AddSeconds(2), TimeSpan.Zero);
        }
        if (data.Rows.Count > 0)
            userID = Int32.Parse(data.Rows[0]["userID"].ToString());

        return userID;
    }
    public string GetDate(object dataItem)
    {
        DataTable data;
        //主题号
        int classID = 0;
        //时间字符串
        DateTime addDate;
        //系统当前时间
        DateTime now;
        //时间间隔
        TimeSpan span;
        if (Cache[classID.ToString()] != null)
        {
            data = (DataTable)Cache[classID.ToString()];
        }
        else
        {
            classID = Int32.Parse(DataBinder.Eval(dataItem, "classID").ToString());
            data = CatalogAccess.GetLastestArticleByClassID(classID);
            Cache.Insert(classID.ToString(), data, null, DateTime.Now.AddSeconds(2), TimeSpan.Zero);
        }
        if (data.Rows.Count > 0)
        {
            addDate = DateTime.Parse(data.Rows[0]["addDate"].ToString());
            now = DateTime.Now;
            span = now.Subtract(addDate);
        }
        else
            return "";

        if (span.Days != 0)
        {
            return span.Days+"天前发表";
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
        return "";

    }

}
