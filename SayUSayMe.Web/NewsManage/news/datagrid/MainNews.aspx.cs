using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;
using SayUSayMe.DAL;

public partial class NewsManage_news_datagrid_MainNews : System.Web.UI.Page
{
   private static  DataTable dt = ArticleManage.getNewsIDAndSubject();
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["userName"] = Session["userName"];
    }
    protected void LinkBtnShowContent_Click(object sender, EventArgs e)
    {
        
    }
}