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

public partial class UpdateReply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Response.Write("<script type='text/javascript'>alert('你还没有登陆！');</script>");
            Response.Redirect("Default.aspx");
        }
        else 
        {
            AddArticle1.OperateType = "LeaveWord";
        }

    }
 
}
