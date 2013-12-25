using System;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;

public partial class Admin_UserControl_AddClass : System.Web.UI.UserControl
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
        DataTable data = CatalogAdmin.GetCatalogByUserName(Session["userName"].ToString());
        DroCatalog.DataSource = data; 
        ListItem item;

        item = new ListItem("请选择", "-1");

        DroCatalog.Items.Add(item);
        foreach (DataRow row in data.Rows)
        {
            item = new ListItem(row["catalogName"].ToString(), row["catalogID"].ToString());
            DroCatalog.Items.Add(item);
        }
        if (Request.QueryString["type"] == null)
        {
            foreach(ListItem i in DroCatalog.Items)
                if(i.Text==HttpUtility.UrlDecode(Request.QueryString["type"]))
                {
                    i.Selected = true;
                    break;
                }
        }

    }
    //添加类别按钮
    public void btnAddClassClick(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (DroCatalog.SelectedValue != "-1")//判断是否选择了大板块
            {
                try 
                {	        
                    int classID=CatalogAdmin.AddClass(Int32.Parse(DroCatalog.SelectedValue), className.Text.Trim(), classDescription.Text.Trim(),classImg.SelectedValue, warning.Text.Trim());
                    foreach(ListItem item in lsClassSort.Items)
                        CatalogAdmin.AddClassSort(classID,item.Text);
                    Response.Redirect("Success.aspx");
                }
                catch (Exception eg)
                {
                    
	                script.Text = "<script type='text/javascript'>alert('添加失败');</script>";
                }
                
            }
            else
                script.Text="<script type='text/javascript'>alert('请选择您想添加子版块到哪个版块');</script>";
        }
    }
    //添加板块分类
    public void AddClassSortClick(object sender, EventArgs e)
    {
        lsClassSort.Items.Add(new ListItem(classSort.Text.Trim()));
    }
    //删除板块分类
    public void DeleteClassSort(object sender, EventArgs e)
    {
        lsClassSort.Items.Remove(lsClassSort.SelectedItem);
    }
}
