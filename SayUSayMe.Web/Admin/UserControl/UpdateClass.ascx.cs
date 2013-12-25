using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using SayUSayMe.DAL;
using CatalogAdmin = SayUSayMe.BLL.CatalogAdmin;

public partial class Admin_UserControl_UpdateClass : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            PopulateControl();
            Page.DataBind();
        }
    }
    //绑定控件
    public void PopulateControl()
    {
        if (Session["userName"] == null)
        {
            Response.Redirect("~/Default.aspx");
            return;
        }
        DataTable data = CatalogAdmin.GetCatalogByUserName(Session["userName"].ToString());
        ListItem item;
        droCatalogName.Items.Clear();
        droCatalogName.Items.Add(new ListItem("请选择","-1"));
    
        foreach (DataRow row in data.Rows)
        {
            item = new ListItem(row["catalogName"].ToString(),row["catalogID"].ToString());
            droCatalogName.Items.Add(item);
        }
    }
    //异步回送
    public void DroCatalogChange(object sender, EventArgs e)
    {
        if (droCatalogName.SelectedValue == "-1") return;
        droClassName.DataSource = CatalogAdmin.GetClassByCatalogID(Int32.Parse(droCatalogName.SelectedValue));
        droClassName.DataTextField = "className";
        droClassName.DataValueField = "classID";
        droClassName.DataBind();
        lstVclassData.DataSource = CatalogAdmin.GetClassByID(Int32.Parse(droClassName.SelectedValue));
        //板块下面的分类
        lsClassSort.DataSource = CatalogAdmin.GetClassSortByID(Int32.Parse(droClassName.SelectedValue));
        lsClassSort.DataTextField = "sortName";
        lsClassSort.DataValueField = "sortID";
        lstVclassData.DataBind();
        Page.DataBind();
    }
    //异步回送
    public void DroClassChange(object sender, EventArgs e)
    {
        lstVclassData.DataSource= CatalogAdmin.GetClassByID(Int32.Parse(droClassName.SelectedValue));
        lsClassSort.DataSource= CatalogAdmin.GetClassSortByID(Int32.Parse(droClassName.SelectedValue));
        lsClassSort.DataTextField = "sortName";
        lsClassSort.DataValueField = "sortID";
        lstVclassData.DataBind();
        Page.DataBind();
    }
    //添加板块分类的按钮单击事件
    public void AddClassSortClick(object sender, EventArgs e)
    {
        if (txtClassSort.Text != "")
            CatalogAdmin.AddClassSort(Int32.Parse(droClassName.SelectedValue), txtClassSort.Text.Trim());
        lsClassSort.DataSource = CatalogAdmin.GetClassSortByID(Int32.Parse(droClassName.SelectedValue));
        lsClassSort.DataTextField = "sortName";
        lsClassSort.DataValueField = "sortID";
        lsClassSort.DataBind();
    }
    //删除板块分类按钮的单击事件
    public void DeleteSortClick(object sender, EventArgs e)
    {
        CatalogAdmin.DeleteClassSort(Int32.Parse(lsClassSort.SelectedValue));
        lsClassSort.DataSource = CatalogAdmin.GetClassSortByID(Int32.Parse(droClassName.SelectedValue));
        lsClassSort.DataBind();
    }
    //得到相片
    public bool GetClassImg(object dataItem,string img)
    {
        string imgsrc = DataBinder.Eval(dataItem, "classImg").ToString();
        if (imgsrc.IndexOf(img)==-1)
            return false;
        else
            return true;
    }
    //更新板块信息
    public void UpdateClassData(object sender, EventArgs e)
    {
        TextBox className=(TextBox)lstVclassData.Items[0].FindControl("className");
        TextBox classDescription = (TextBox)lstVclassData.Items[0].FindControl("classDescription");
        TextBox warning = (TextBox)lstVclassData.Items[0].FindControl("warning");
        //图片选择按钮
        RadioButton newImg = (RadioButton)lstVclassData.Items[0].FindControl("radioNewImg");
        RadioButton normalImg = (RadioButton)lstVclassData.Items[0].FindControl("radioNormalImg");
        string classImgUrl="";
        if (newImg.Checked)
            classImgUrl = "image/articleClass/" + GetConfigurationSettings.newImg;
        else if (normalImg.Checked)
            classImgUrl = "image/articleClass/" + GetConfigurationSettings.normalImg;
       
        if (className.Text != "" && classDescription.Text != "" && warning.Text != "")
        {
            if (CatalogAdmin.UpdateClassData(Int32.Parse(droClassName.SelectedValue), className.Text, classDescription.Text, classImgUrl, warning.Text))
                Response.Redirect("~/admin/Success.aspx");
        }
    }
}
