using System;
using SayUSayMe.BLL;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            int intRole = CatalogAdmin.GetUserRoleByName(Session["userName"].ToString());
            string popemtype = CatalogAdmin.GetPopedomType(Session["userName"].ToString());

            if (intRole == 0 && popemtype == "A")
            {
                Session["role"] = popemtype;
                Response.Redirect("AdminSys.aspx");
            }
            else if (intRole < 0)
                Response.Redirect("~/Default.aspx");

            else if (intRole > 0 && popemtype == "B")
            {
                Session["role"] = popemtype;
                Response.Redirect("CatalogAdmin.aspx");
            }
                

            else if (intRole > 0 && popemtype == "C")
            {
                Session["role"] = popemtype;
                Response.Redirect("BordAdmin.aspx");
            }
               

        }
        else
            Response.Redirect("~/Default.aspx");
    }
}
