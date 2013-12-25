using System;
using System.Web.UI;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;
using SayUSayMe.DAL;

public partial class UserControls_CustomerDataList : System.Web.UI.UserControl
{
    //用于绑定datalist内容的类
    public class CustomListItem
    {
        //头部绑定的ID号
        private int contentID;
        //datalist的头部显示文字
        private string contentText; 

        //构造函数
        public CustomListItem(int id,string text)
        {
            this.contentID = id;
            this.contentText = text;
        }
        
        public string ContentText
        {
            set { this.contentText = value; }
            get { return this.contentText; }
        }
      
        public int ContentID
        {
            set { this.contentID = value; }
            get { return this.contentID; }
        }
    }

    
    //页面属性
    
    //datalist控件页头的绑定
    private string headText = "";
    private int headID;

    //属性HeadText
    public string HeadText
    {
        set { this.headText = value; }
        get { return this.headText; }
    }
    //属性HeadID
    public int HeadID
    {
        set { this.headID = value; }
        get { return this.headID; }
    }

    //查询命令文本，一般为存储过程名称
    private string commText = "";
    public string CommText
    {
        set { this.commText = value; }
        get { return this.commText; }
    }

    //查询命令
    public DbCommand comm;

    //datalist样式
    private string headStyle = "";
    private string itemStyle = "";

    public string HeadStyle
    {
        get { return this.headStyle; }
        set { this.headStyle = value; }
    }
    public string ItemStyle
    {
        get { return this.itemStyle; }
        set { this.itemStyle = value; }
    }

    //绑定字段名称
    private string contentIDname = "";
    private string contentTextName = "";
    public string ContentIDname
    {
        get { return this.contentIDname; }
        set { this.contentIDname = value; }
    }
    public string ContentTextName
    {
        get { return this.contentTextName; }
        set { this.contentTextName = value; }
    }

    //页面内容绑定的url
    public string contentUrl = "";
    //页面首部绑定url
    public string headUrl = "";
    //页面代码
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    /// <summary>
    /// 绑定数据空间
    /// </summary>
    public void PopulateControl()
    {
        DataTable data = GenericDataAccess.ExecuteSelectCommand(comm);

        CustomListItem[] items=new CustomListItem[data.Rows.Count];

        int i = 0;
        foreach (DataRow row in data.Rows)
        {
            items[i++]=new CustomListItem(Int32.Parse(row[this.contentIDname].ToString()),row[this.contentTextName].ToString());
        }

        this.DataList1.DataSource = items;
        this.DataList1.DataBind();
    }

    private int Columns = 8;
    private RepeatDirection Direction = RepeatDirection.Horizontal;
    //控件的重复方式Vertical,Horizontal
    public RepeatDirection DLRepeatDirection
    {
        set { this.Direction = value; }
        get { return this.Direction; }
        
    }
    public int DLRepeatColumns
    {
        set { this.Columns = value; }
        get { return this.Columns; }
    }
}
