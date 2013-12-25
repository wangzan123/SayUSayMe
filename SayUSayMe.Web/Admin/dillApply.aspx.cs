using System;
using System.Web.UI;
using SayUSayMe.DAL;
using CatalogAdmin = SayUSayMe.BLL.CatalogAdmin;

public partial class Admin_dillApply : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            PopulateControl();
        //Response.Write(System.Web.HttpUtility.UrlDecode(Request.QueryString["name"]));
    }
    public string type = "delete";
    //绑定数据
    public void PopulateControl()
    {
        if(Request.QueryString["name"]!=null)
            ShowApply.DataSource = CatalogAdmin.GetApplyDataByTitle(System.Web.HttpUtility.UrlDecode(Request.QueryString["name"]),(int)EnumEntity.ApplyState.waitForDeal);
        Page.DataBind();
    }
    //查询批准的申请
    public void ViewSuccessData(object sender,EventArgs e)
    {
        ShowApply.DataSource = CatalogAdmin.GetApplyDataByTitle("版主申请", (int)EnumEntity.ApplyState.applySuccess);
        success.Enabled = false;
        failed.Enabled = true;
        waitfor.Enabled = true;
        Page.DataBind();
    }

    //查询拒绝的申请
    public void ViewFailData(object sender, EventArgs e)
    {
        this.type = "showDelete";
        ShowApply.DataSource = CatalogAdmin.GetApplyDataByTitle("版主申请", (int)EnumEntity.ApplyState.applyFailed);
        success.Enabled = true;
        failed.Enabled = false;
        waitfor.Enabled =true; 
        Page.DataBind();
        
    }
    //查询等待的申请
    public void ViewWaitData(object sender, EventArgs e)
    {
        ShowApply.DataSource = CatalogAdmin.GetApplyDataByTitle("版主申请", (int)EnumEntity.ApplyState.waitForDeal);
        success.Enabled = true;
        failed.Enabled = true;
        waitfor.Enabled = false;
        Page.DataBind();
    }
    public string GetOperator(object dataItem)
    {
        string deleteText = "<a href=\"javascript:\" onclick=\"ApplyDeal(this,{$id},'refuse')\">拒绝申请</a>";
        string showDeleteText="<a href=\"javascript:\" onclick=\"DisplayRefuseData('failedTextPlace{$id}',this)\">查看拒绝原因</a>";
        int id=Int32.Parse( DataBinder.Eval(dataItem, "applyID").ToString());
        switch (this.type)
        {
            case "delete":
                return deleteText.Replace("{$id}", id.ToString());
            case "showDelete":
                return showDeleteText.Replace("{$id}", id.ToString());
        }
        return "";
    }
}
