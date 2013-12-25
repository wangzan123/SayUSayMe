using System;
using System.Data;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;

public partial class Admin_UserControl_UpdateCatalog : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            PopulateControl();
    }
    //绑定数据
    public void PopulateControl()
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }
        DataTable data=CatalogAdmin.GetCatalogByUserName(Session["userName"].ToString());
        droCatalog.DataSource=data;
        ListItem item=new ListItem("请选择","-1");
        droCatalog.Items.Add(item);
        foreach(DataRow row in data.Rows)
        {
            item=new ListItem(row["catalogName"].ToString(),row["catalogID"].ToString());
            droCatalog.Items.Add(item);
        }

    }
    public void droCatalogChange(object sender, EventArgs e)
    {
        if (Int32.Parse(droCatalog.SelectedValue) == -1)
            return;
        catalogDataTable.DataSource = CatalogAdmin.GetArticleCatalogByID(Int32.Parse(droCatalog.SelectedValue));
        catalogDataTable.DataBind();
    }
}
