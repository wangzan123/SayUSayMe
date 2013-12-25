using System;
using System.Text;
using System.Web.UI;
using System.Data;
using SayUSayMe.DAL;
using CatalogAdmin = SayUSayMe.BLL.CatalogAdmin;

public partial class UserControls_ShowArticle : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        populateControl();
    }
    private string type;
    //绑定数据控件
    public void populateControl()
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }
        string pageNumber = Request.QueryString["page"];
        type = Request.QueryString["type"];
        if (type == null)type = "new";

        if (pageNumber == null) pageNumber = "1";

        int howManyPage=1;
        #region
     
        //string publishOperatorText="<a href=\"javascript:\" onclick=\"Publish(<%# Eval(\"articleID\") %>)\">上报</a>";
        
        //StringBuilder scriptText = new StringBuilder();
        //scriptText.Append("<script type='text/javascript'>");
        //scriptText.Append("var obj=document.getElementById('deleteOrNot');");
        ////根据用户角色确定给与什么操作
        //switch (CatalogAdmin.GetUserRoleByName("lijian"))
        //{
        //    case 0:
        //        if (GetConfigurationSettings.SysAdminDeleteArticle)
        //        {
        //            scriptText.Append("obj.innerHTML='<a href=\"javascript:\" onclick=\"DeletArticle(<%# Eval(\"articleID\")%>)\">删除</a>'");
        //        }
        //        else
        //        {
        //            scriptText.Append("obj.innerHTML='" + publishOperatorText + "'");
        //        }
        //        break;
        //    case -1:
        //        break;
        //    default:
        //        if (GetConfigurationSettings.BordAdminDeleteArticle)
        //        {
        //            scriptText.Append("obj.innerHTML='<a href=\"javascript:\" onclick=\"DeletArticle(<%# Eval(\"articleID\")%>)\">删除</a>'");
        //        }
        //        else
        //        {
        //            scriptText.Append("obj.innerHTML='" + publishOperatorText + "'");
        //        }
        //        break;  
        //}

        //scriptText.Append("</script>");
        //ltScript.Text = scriptText.ToString();
        #endregion
        if (type == "new")
            ShowArticle.DataSource = CatalogAdmin.BordAdminGetArticle(Session["userName"].ToString(), int.Parse(pageNumber), GetConfigurationSettings.ArticleNormalState, out howManyPage);
 
        else if (type == "history")
            ShowArticle.DataSource = CatalogAdmin.BordAdminGetArticle(Session["userName"].ToString(), int.Parse(pageNumber), GetConfigurationSettings.ArticleCheckedState, out howManyPage);
     
     
        else if (type == "delete")
            ShowArticle.DataSource = CatalogAdmin.BordAdminGetArticle(Session["userName"].ToString(), int.Parse(pageNumber), GetConfigurationSettings.ArticleDeleteState, out howManyPage);
    
        ShowPageNumber(howManyPage, Int32.Parse(pageNumber));
        Page.DataBind();
    }

    public string GetOperateBtn(object dataItem)
    {
        string deleteOperatorText = "<a href='javascript:' onclick='DeletArticle(\"{$ID}\")'>删除</a>";
        string undeleteOperatorText = "<a href='javascript:' onclick='unDeletArticle(\"{$ID}\")'>恢复文章</a>";
        string articleID =DataBinder.Eval(dataItem, "articleID").ToString();
        if (type=="delete")
            return undeleteOperatorText.Replace("{$ID}",articleID);
        else
            return deleteOperatorText.Replace("{$ID}",articleID);
    }
    //显示页脚的页码
    public void ShowPageNumber(int howManyPage, int currentNumber)
    {
        pageNumber.Text = "";
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

        string pageUrl="<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>{$pageNumber}</a></span>";;
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
                if (currentNumber != howManyPage)
                {
                    pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>下一页</a></span>"; ;
                    pageNumber.Text += pageUrl.Replace("{$pageNumber}", (currentNumber + 1).ToString());
                }
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
                if (currentNumber!= howManyPage)
                {
                    pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>下一页</a></span>"; ;
                    pageNumber.Text += pageUrl.Replace("{$pageNumber}", (currentNumber + 1).ToString());
                }
            }
        }
        
        
    }
    protected void ShowArticle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected string showArticleGrade(string article_grade)
    {
        if (article_grade == "0")
            return "加精";
        else
            return "取消加精";
    }
}
