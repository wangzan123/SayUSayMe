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
using SayUSayMe.BLL;

public partial class ReplyToReply : System.Web.UI.Page
{
    DataTable atricleTable = new DataTable();
    DataTable commentTable = new DataTable();
    string cid = "";
    string aid = "";
    string p = "1";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script>alert('请先登陆！');</script>");
            Response.Redirect("Default.aspx");
        }
        else if (CatalogAdmin.checkUserState(Session["userName"].ToString().Trim()) == "0")
        {
            Response.Write("<script>alert('你已被禁言！');</script>");
            Response.Redirect("Default.aspx");
        }
        else 
        {
            int AID=0;
            int CID=0;
           
            AddArticle3.OperateType = "LeaveWord";
            cid = Request.QueryString["ReplyCommentID"];
            aid=Request.QueryString["aid"];
            p = Request.QueryString["page"];
            try
            {
                AID=Int32.Parse(aid);
                CID=Int32.Parse(cid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            atricleTable = CatalogAccess.GetArticleSubjectByID(AID);
            commentTable = CatalogAccess.GetUserMessageByCommentID(CID);
            articleContentLabel.Text = GetArticleSubject();
            CommentLinkLabel.Text =GetCommentLink();
            AddArticle3.CommentLinkText = GetCommentLink();

        }
        
    }
    private string GetArticleSubject() 
    {
        return atricleTable.Rows[0]["articleSubject"].ToString();
    }
    private string GetCommentLink()
    {
        return "<b>回复<span style='color:Red'><a href='ArticleContent.aspx?articleid=" + aid + "&page=" + p + "#" + cid + "'>" + commentTable.Rows[0]["UserShowName"].ToString() + "</a></span>的帖子</b>";
    }

}
