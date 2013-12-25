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

public partial class QuoteToReply : System.Web.UI.Page
{
    DataTable Atable = new DataTable();
    DataTable Ctable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Literal1.Text = "<script type=\"text/javascript\">alert('请先登陆！');</script>";
            //Response.Write("<script>alert('请先登陆！');</script>");
            Response.Redirect("Default.aspx");
        }
        else if (CatalogAdmin.checkUserState(Session["userName"].ToString().Trim()) == "0")
        {
            //Response.Write("<script>alert('你已被禁言！');</script>");
            Literal1.Text = "<script type=\"text/javascript\">alert('你已被禁言！');</script>";

            Response.Redirect("Default.aspx");
        }
        else
        {
            string oldSpeakContent = "";
            string link="";
            string speakContent="";
            AddArticle1.OperateType = "LeaveWord";
            int articleid = -1;
            int quoteid = -1;
            int page = 1;
            string qid = Request.QueryString["QuoteCommentID"].ToString();
            string aid = Request.QueryString["aid"].ToString();
            string p = Request.QueryString["page"].ToString();
            try
            {
                articleid = Int32.Parse(aid);
                quoteid = Int32.Parse(qid);
                page = Int32.Parse(p);
            }
            catch (Exception eg)
            {
                Response.Redirect("Default.aspx");
            }
            Ctable = CatalogAccess.GetUserMessageByCommentID(quoteid);
            Atable = CatalogAccess.GetArticleSubjectByID(articleid);
            link="<b><span style='color:Red'><a href='ArticleContent.aspx?articleid=" + aid + "&page=" + p + "#" + qid + "'>" + Ctable.Rows[0]["UserShowName"].ToString() + "</a></span>的帖子</b>";
            articleSuject.Text = Atable.Rows[0]["articleSubject"].ToString();

            oldSpeakContent = HttpContext.Current.Server.HtmlDecode(Ctable.Rows[0]["speakContent"].ToString());
            if (oldSpeakContent.Length > 100)
            {
                speakContent = oldSpeakContent.Substring(0, 100);
            }
            else 
            {
                speakContent = oldSpeakContent;
            }
            quoteContent.Text = speakContent+ "。。。" + "<a href='ArticleContent.aspx?articleid=" + aid + "&page=" + p + "#" + qid + "'><img src='image/back.gif'/></a>";
            articleSuject.Text = Atable.Rows[0]["articleSubject"].ToString();
            AddArticle1.CommentLinkText = "<fieldset><legend>" + "引用“" + link + "”" + "</legend>" + oldSpeakContent + "</fieldset>";
           
        }
    }
}
