using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearchClick(object sender, EventArgs e)
    {
        if (txtSearch.Text.Length <= 0) return;
        if (CB_Search.Checked)
            Response.Redirect("SearchResult.aspx?s=" + HttpUtility.UrlEncode(txtSearch.Text) + "&allwords=true");
        else
            Response.Redirect("SearchResult.aspx?s=" + HttpUtility.UrlEncode(txtSearch.Text) + "&allwords=false");
    }
}
