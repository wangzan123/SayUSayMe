using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SayUSayMe.DAL;
using CatalogAdmin = SayUSayMe.BLL.CatalogAdmin;

public partial class Admin_UserControl_DeleteCatalog : System.Web.UI.UserControl
{
    private string state;
    protected void Page_Load(object sender, EventArgs e)
    {
        populateControl();
    }
    public void populateControl()
    {
        DataTable dt;
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }
        string pageNumber = Request.QueryString["page"];
        state = Request.QueryString["state"];
        if (state == null) state = "normal";

        if (pageNumber == null) pageNumber = "1";

        int howManyPage = 1;

        if (state == "normal" || state == "deleted")
        {
            dt = CatalogAdmin.GetCatalogMsgByState(state, int.Parse(pageNumber), out howManyPage);
            
            if (dt.Rows.Count <= 0)
            {
                Response.Write("<script>alert('没有记录!');</script>");
                return;
            }
            else showUserState.DataSource = dt;
        }


        //else if (state == "deleted")
        //{
        //    dt = CatalogAdmin.GetCatalogMsgByState(state, int.Parse(pageNumber), out howManyPage);
        //    if (dt.Rows.Count <= 0)
        //    {
        //        Response.Write("<script>alert('没有记录!');</script>");
        //        return;
        //    }
        //    else showUserState.DataSource = dt;

        //}

        ShowPageNumber(howManyPage, Int32.Parse(pageNumber));
        Page.DataBind();
    }

    //public string GetOperateBtn(object dataItem)
    //{
    //    string deleteOperatorText = "<a href='javascript:' onclick='DeletArticle(\"{$ID}\")'>删除</a>";
    //    string undeleteOperatorText = "<a href='javascript:' onclick='unDeletArticle(\"{$ID}\")'>恢复文章</a>";
    //    string articleID = DataBinder.Eval(dataItem, "articleID").ToString();
    //    if (type == "delete")
    //        return undeleteOperatorText.Replace("{$ID}", articleID);
    //    else
    //        return deleteOperatorText.Replace("{$ID}", articleID);
    //}
    //显示页脚的页码
    public void ShowPageNumber(int howManyPage, int currentNumber)
    {
        pageNumber.Text = "";
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
                if (currentNumber != howManyPage)
                {
                    pageUrl = "<span style='background-color:{$backColor};'><a style='color:{$fontColor};' href='" + Request.Url.AbsolutePath + newQueryString + "page={$pageNumber}'>下一页</a></span>"; ;
                    pageNumber.Text += pageUrl.Replace("{$pageNumber}", (currentNumber + 1).ToString());
                }
            }
        }


    }
    public string StateOperation(string state)
    {
        if (state == "1")
            return "删除";
        else if (state == "0")
            return "恢复";
        else
            return "未知状态！";
    }
    public string ChangeToString(string state)
    {
        if (state == "1")
            return "正常使用";
        else if (state == "0")
            return "已经删除！";
        else
            return "未知状态！";
    }
}

