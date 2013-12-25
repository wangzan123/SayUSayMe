using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;

public partial class UserControls_NewArticle : System.Web.UI.UserControl
{
    //初始化绑定类型
    public string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            populateControl();
        }
    }


    public string GetCommentID(object dataItem)
    {

        if (type == "Comment")
        {
            return "#" + DataBinder.Eval(dataItem, "commentID").ToString();
        }
        return "";
    }
    //绑定datalist控件
    public void populateControl()
    {
        //动态选择数据源
        if (type == "Article")
            ShowNewArticle.DataSource = CatalogAccess.GetNewArticle();
        if (type == "Comment")
            ShowNewArticle.DataSource = CatalogAccess.GetNewArticleComment();
        ShowNewArticle.DataBind();
    }

    //返回图片地址
    public string GetItemPic(int index)
    {
        string picSrc = "image/Itemimages/{$index}.gif";
        return picSrc.Replace("{$index}", index.ToString());
    }
}