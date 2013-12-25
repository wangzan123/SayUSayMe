using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using SayUSayMe.DAL;
using CatalogAccess = SayUSayMe.BLL.CatalogAccess;
using CatalogAdmin = SayUSayMe.BLL.CatalogAdmin;

public partial class UserControls_AddArticle : System.Web.UI.UserControl
{
    string commentPage = "1";
    
    public const string StatusChangeFilePath = "UserUpload/"; 
    protected void Page_Load(object sender, EventArgs e)
    {
     

        if (!Page.IsPostBack)
        {
            populateControl();
            Page.DataBind();

            switch (this.operateType)
            {
                case "AddArticle":
                    script.Text = "<script type=\"text/javascript\">type='AddArticle';</script>";
                    break;
                case "LeaveWord":
                    script.Text = "<script type=\"text/javascript\">type='LeaveWord';document.getElementById('trClass').style.display=\"none\";document.getElementById('trTitle').style.display=\"none\"; </script>";
                    break;
                case "Apply":
                    script.Text = "<script type=\"text/javascript\">type='Apply';document.getElementById('trClass').style.display=\"none\";</script>";
                    break;
            }
            //更新回复操作 把回复内容读回去
            if (Request.QueryString["reCommentID"] != null)
            {
                script.Text = script.Text + "<script type=\"text/javascript\">var m=document.getElementById('addFileText');m.disabled=true;m.onclick=function(){return false;};</script>";
          
                if (Request.QueryString["page"] == null) { commentPage = "1"; }
                else { commentPage = Request.QueryString["page"]; }
                string commentID = Request.QueryString["reCommentID"].ToString();
                this.ArticleID = Request.QueryString["aid"].ToString();
                DataTable CommentTable=CatalogAccess.GetCommentByCommendID(commentID);
                EditorValue.Value = HttpContext.Current.Server.HtmlDecode(CommentTable.Rows[0]["speakContent"].ToString());
            }
            //引用操作
            if (Request.QueryString["QuoteCommentID"] != null)
            { 
               
                this.ArticleID = Request.QueryString["aid"].ToString();
            }

            //回复回复操作
            if (Request.QueryString["ReplyCommentID"] != null)
            {
                this.ArticleID = Request.QueryString["aid"].ToString();
                
            }
            //更新主题帖操作，先把原来文章的内容读到控件中
            if (Request.QueryString["reWriteArticleID"] != null)
            {
                script.Text = script.Text + "<script type=\"text/javascript\">var m=document.getElementById('addFileText');m.disabled=true;m.onclick=function(){return false;};</script>";
                //先查询文章数据
                DataTable articleData = CatalogAccess.GetArticleContentByID(Request.QueryString["reWriteArticleID"]);
                //填写文章数据
                EditorValue.Value = HttpContext.Current.Server.HtmlDecode(articleData.Rows[0]["articleContent"].ToString());
                int i = 0;
                //选择文章分类
                foreach (ListItem item in droArticleClass.Items)
                {
                    if (item.Value == articleData.Rows[0]["classID"].ToString())//设置默认的分类
                    {
                        droArticleClass.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
                //选择文章板块分类
                if (articleData.Rows[0]["classSort"].ToString() != "-1")
                {
                    droClassSort.DataSource = CatalogAdmin.GetClassSortByID(Int32.Parse(droArticleClass.SelectedValue));
                    droClassSort.DataValueField = "sortID";
                    droClassSort.DataTextField = "sortName";
                    droClassSort.DataBind();
                    i = 0;
                    foreach (ListItem item in droClassSort.Items)
                    {
                        if (item.Value == articleData.Rows[0]["classSort"].ToString())//设置默认的小分类
                        {
                            droClassSort.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                //文章标题
                ArticleTitle.Text = articleData.Rows[0]["articleSubject"].ToString();
                int replyArticleID = -1;
                try
                {
                    replyArticleID = Int32.Parse(Request.QueryString["reWriteArticleID"].ToString());

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //DataTable dt = new DataTable();
                //dt = CatalogAccess.GetArticleFileByID(replyArticleID, "Article");
                //int fileCount = dt.Rows.Count;
                //if (fileCount > 0)
                //{
                //    string scriptStart = "<script type='text/javascript'>" + " document.getElementById('FileUploadPlace').style.display='';addFile();";
                //    string scriptEnd = "</script>";
                //    string scriptMiddle = "addFile();";
                //    //string Description = " var articleFiles=document.getElementsByName('filename');" +"for(var i=0;i<articleFiles.length;i++){articleFiles[i].value=''}";
                //    if(fileCount>1)
                //    {

                //        for (int t = 1; t < fileCount; t++)
                //        {
                //            scriptMiddle+="addFiles(TD);";
                //        }
                //    }
                //    script.Text = scriptStart + scriptMiddle + scriptEnd;
                // }

            }
            
        }
    }
    //回复连接地址
    private string commentLinkText = "";
    public string CommentLinkText
    {
        set { this.commentLinkText = value; }
        get { return this.commentLinkText; }
    }

    //定义页面的操作类型，一种是留言，一种是发布文章
    private string operateType = "AddArticle";
    public string OperateType
    {
        set { this.operateType = value; }
        get { return this.operateType; }
    }
    //当充当留言板的时候，要得到回复的文章ID
    public string ArticleID
    {
        set { this.articleID.Text = value; }
        get { return this.articleID.Text; }
    }
  
    //绑定dropdownlist控件
    public void populateControl()
    {   
        if (Session["userName"] != null)
        {
            //发表文章操作
            if (this.operateType == "AddArticle")
            {
                DataTable data = CatalogAccess.GetArticleClassByUserName(Session["userName"].ToString());

                ListItem item;
                item = new ListItem("请选择分类", "-1");
                droArticleClass.Items.Add(item);
                //绑定文章类别
                foreach (DataRow row in data.Rows)
                {
                    item = new ListItem(row["className"].ToString().Trim(), row["classID"].ToString());
                    droArticleClass.Items.Add(item);
                }
            }
            //申请文章操作
            else if (this.operateType == "Apply")
            {
                ArticleTitle.Text = HttpUtility.UrlDecode(Request.QueryString["name"]);
                ArticleTitle.ReadOnly = true;
            }
        }
    }
    //单击提交按钮，进行判断
    public void GetUserLeaveData(object sender, EventArgs e)
    {
        
        switch (this.OperateType)
        {
            case "AddArticle":
                GetArticle();
                break;
            case "LeaveWord":
                GetArticleComment();
                break;
            case "Apply":
                GetApply();
                break;
            default: break;
                
        }
    }
    //把申请提交到数据库中
    public void GetApply()
    {
        string type="";
        int popedom =-1;
        int id;//申请对象的ID号，方便查询信息
        if(Request.QueryString["pp"]!=null)
            popedom=Int32.Parse(Request.QueryString["pp"]);//--------获取申请的板块权限大小
        string defaultText="";
        if (ArticleTitle.Text.Trim() == "版主申请")//-------------------申请版主
        {
            if (Request.QueryString["bordName"] != null)
                defaultText = "<hr />用户想申请成为该板块的版主：<a href='../Article.aspx?{$bordID}={$id}' target='_blank'>" + Request.QueryString["bordName"] + "</a>";
            if (Request.QueryString["catalogid"] != null)//----------是否申请为大板块版主
            {
                defaultText = defaultText.Replace("{$bordID}", "catalogid");
                defaultText = defaultText.Replace("{$id}", Request.QueryString["catalogid"]);
                type = "catalogid";
            }
            else if (Request.QueryString["classid"] != null)//----------是否申请为小板块版主
            {
                defaultText = defaultText.Replace("{$bordID}", "classid");
                defaultText = defaultText.Replace("{$id}", Request.QueryString["classid"]);
                type = "classid";
            }
        }
        else if (ArticleTitle.Text.Trim() == "上诉申请")//文章被屏蔽上诉
        {
            id = Request.QueryString["id"] == null ? -1 : int.Parse(Request.QueryString["id"]);
            defaultText = "<hr />用户上诉的文章为：<a href='../ArticleContent.aspx?articleid="+id+"' target='_blank'>" +HttpUtility.UrlDecode(Request.QueryString["an"]) + "</a>";
        }
        if (Session["userName"] != null)
        {
            id = Request.QueryString["id"] == null ? -1 : int.Parse(Request.QueryString["id"]);
            if (CatalogAccess.AddApplyData(ArticleTitle.Text.Trim(), Session["userName"].ToString(), Server.HtmlEncode(EditorValue.InnerText+defaultText),(int)EnumEntity.ApplyState.waitForDeal,id,popedom,type))
                Response.Redirect("applySucces.aspx");
            else
                script.Text = "<script type='text/javascript'>alert('提交申请失败');</script>";
        }
    }
    //把文章插入数据库中
    public void GetArticle()
    {
        int n = Request.Files.Count;//附件数量
        int classSortID = -1;//无小分类
        int articleID;          //刚发表发表文章的id
        if(droClassSort.Items.Count>0)  //是否有小分类
            classSortID = Convert.ToInt32(droClassSort.SelectedValue);
        if (droArticleClass.SelectedValue == "-1")  //是否选择左分类
        {
          
            return;
        }
        if (ArticleTitle.Text == "")
        {
          
            return ;
        }
        //修改文章函数
        if (Request.QueryString["reWriteArticleID"] != null)
        {
            if (CatalogAccess.UpdateArticle(Int32.Parse(Request.QueryString["reWriteArticleID"]), classSortID, Int32.Parse(droArticleClass.SelectedValue), ArticleTitle.Text.Trim(), Server.HtmlEncode(EditorValue.InnerText)))
            {
                script.Text = "<script type='text/javascript'>document.getElementById('showWorking').style.display='none';</script>";
                Response.Redirect("SubmitSuccess.aspx?articleid=" + Request.QueryString["reWriteArticleID"]);
            }
            return;
        }


        //-----------------------------发表文章处理模块
     
        //------------------------------------------无附件的发表文章
        if (n == 0)
        {
            if ((articleID = CatalogAccess.AddArticle(Session["userName"].ToString(), classSortID, Int32.Parse(droArticleClass.SelectedValue), ArticleTitle.Text.Trim(), Server.HtmlEncode(EditorValue.InnerText))) > 0)
            {
                Response.Redirect("SubmitSuccess.aspx?articleid=" + articleID.ToString());
            }

        }
        //-----------------------------  有附件的发表文章
        else 
        {
               HttpPostedFile oPostedFile; //单独文件访问

                string[] fileDescription = TxtDescription.Value.Split(',');//分离附件描述

                //-----检查所有附件的扩展名与大小
                for (int i = 0; i < n; i++)
                {   
                    oPostedFile = Request.Files.Get(i);
                    if (CheckFile(oPostedFile) == -1)
                        return;
                }
                //-----检查结束

                //------开始插入数据库
                int temp=-1;
                if ((articleID = CatalogAccess.AddArticle(Session["userName"].ToString(), classSortID, Int32.Parse(droArticleClass.SelectedValue), ArticleTitle.Text.Trim(), Server.HtmlEncode(EditorValue.InnerText))) > 0)
                {
                    for (int j = 0; j < n; j++)
                    {   
                        oPostedFile = Request.Files.Get(j);
                        temp = CatalogAccess.Addfile(oPostedFile, Session["userName"].ToString() + DateTime.Now.ToString(), StatusChangeFilePath, fileDescription[j], -1, articleID);
                        if (temp <= 0)
                        {
                            Literal1.Text = "<script type='text/javascript'>alert(\"附件上传失败！\");</script>";
                            return;
                        }
                    }
                    
                
                
                }
                Literal1.Text = "<script type='text/javascript'>alert('回复成功！');</script>";
                Response.Redirect("SubmitSuccess.aspx?articleid=" + articleID.ToString());
        }
        
    }
    //查询板块分类
    public void ArticleClassChange(object sender, EventArgs e)
    {
        droClassSort.DataSource = CatalogAdmin.GetClassSortByID(Int32.Parse(droArticleClass.SelectedValue));
        droClassSort.DataValueField = "sortID";
        droClassSort.DataTextField = "sortName";
        droClassSort.DataBind();
    }
    //得到发表的回复
    public void GetArticleComment()
    {   int replyCommentID=-1;
        int articleCommentID=-1;
        string useReplyConetent = "";
        if (Session["userName"] != null&&this.ArticleID!="")
        {
            int n = 0;
            n = Request.Files.Count;//附件数量
      
            if (n == 0) //无附件回复
            {   
                //回复回复表
                if (Request.QueryString["ReplyCommentID"] != null) 
                {
                    string p = "1";
                    if (Request.QueryString["page"] == null) { }
                    else { p = Request.QueryString["page"]; }
                    string rid = Request.QueryString["ReplyCommentID"].ToString();
                    if ((replyCommentID = CatalogAccess.AddArticleComment(Int32.Parse(ArticleID), Session["userName"].ToString(), Server.HtmlEncode(EditorValue.InnerText), (int)EnumEntity
                        .ReplyType.ReplyToReply, this.CommentLinkText)) >= 0)
                    {
                        Literal1.Text = "<script type='text/javascript'>alert('回复成功');</script>";
                        Response.Redirect("ArticleContent.aspx?articleid=" + ArticleID + "&page=1#" + replyCommentID);
                        
                    }
                
                }
                //更新回复表
                if (Request.QueryString["reCommentID"] != null)
                {   string cid=Request.QueryString["reCommentID"].ToString();

                    if (CatalogAccess.UpdateComment(Server.HtmlEncode(EditorValue.InnerText), cid) > 0)
                    {
                        Literal1.Text = "<script type='text/javascript'>alert('更新成功');</script>";
                        Response.Redirect("ArticleContent.aspx?articleid=" + ArticleID + "&page=" + commentPage + "#" + cid);
                    }
                }
                //引用回复操作
                if (Request.QueryString["QuoteCommentID"] != null)
                {
                    int quoteID = -1;
                    string QuoteCommentID = Request.QueryString["QuoteCommentID"].ToString();
                    string page = "1";
                    if (Request.QueryString["page"] == null) { }
                    else { page = Request.QueryString["page"]; }
                    if ((quoteID = CatalogAccess.AddArticleComment(Int32.Parse(ArticleID), Session["userName"].ToString(), Server.HtmlEncode(EditorValue.InnerText), (int)EnumEntity
                       .ReplyType.QuoteToReply, this.CommentLinkText)) >= 0)
                    {
                        Literal1.Text = "<script type='text/javascript'>alert('回复成功');</script>";
                        Response.Redirect("ArticleContent.aspx?articleid=" + ArticleID + "&page=1#" + quoteID);

                    }
                
                
                }
                //主题回复类型贴
                else
                {
                    if ((articleCommentID = CatalogAccess.AddArticleComment(Int32.Parse(ArticleID), Session["userName"].ToString(), Server.HtmlEncode(EditorValue.InnerText), (int)EnumEntity
                        .ReplyType.ReplyToArticle, useReplyConetent)) >= 0)
                    {
                        Literal1.Text = "<script type='text/javascript'>alert('回复成功');</script>";
                        Response.Redirect("ArticleContent.aspx?articleid=" + ArticleID + "&page=1#" + articleCommentID.ToString());
                    }


                } 
            }
            else
            {

                HttpPostedFile oPostedFile; //单独文件访问

                string[] fileDescription = TxtDescription.Value.Split(',');//分离附件描述

                //-----检查所有附件的扩展名与大小
                for (int i = 0; i < n; i++)
                {   
                    oPostedFile = Request.Files.Get(i);
                    if (CheckFile(oPostedFile) == -1)
                        return;
                }
                //------开始插入数据库
                int temp=-1;
                if ((articleCommentID = CatalogAccess.AddArticleComment(Int32.Parse(ArticleID), Session["userName"].ToString(), Server.HtmlEncode(EditorValue.InnerText), (int)EnumEntity.ReplyType.ReplyToArticle, useReplyConetent)) >= 0)
                {
                    for (int j = 0; j < n; j++)
                    {   
                        oPostedFile = Request.Files.Get(j);
                        temp = CatalogAccess.Addfile(oPostedFile, Session["userName"].ToString() + DateTime.Now.ToString(), StatusChangeFilePath,fileDescription[j], articleCommentID, -1);
                        if (temp <= 0)
                        {
                            Literal1.Text = "<script type='text/javascript'>alert(\"附件上传失败！\");</script>";
                            return;
                        }
                    }
                }
                Literal1.Text = "<script type='text/javascript'>alert('回复成功！');</script>";
                Response.Redirect("ArticleContent.aspx?articleid=" + ArticleID + "#" + articleCommentID.ToString());
              

            }
            
        }
        else
        {
            script.Text += "<script type='text/javascript'>alert(\"回复失败\");</script>";
            return;
        }
    }

    //-------------附件检查函数
    private int CheckFile(HttpPostedFile Postfile)
    {
        string uploaFileFormat = ".rar|.flash|.rmb|.rmvb|.wav|.mpeg|.avi|.jpg|.gif|.mp3|.mpg|.wmv|.flv|.swf|.txt";
        var extension = Postfile.FileName.Substring(Postfile.FileName.LastIndexOf(".")).ToLower();
        if (uploaFileFormat.IndexOf(extension) == -1)   //是否找到上传附件的扩展名
        {
            Literal1.Text = "<script type='text/javascript'>alert(\"格式不正确\");</script>";
            return -1;
        }
        if (Postfile.ContentLength >= 1024 * 1024)//是否大于1Mb
        {
            Literal1.Text = "<script type='text/javascript'>alert(\"附件大于1Mb,,请更改\");</script>";
            return -1;
        }
        return 1;
    }

    //------------
    //附件上传到服务器函数
    private int UpLoadMoreFile(HttpPostedFile Postfile, string Path)
    {
        string fileName = "";
        if (Postfile.FileName == "")
        {
            return 0;
        }
        else
        {
            fileName = Postfile.FileName;
            fileName = fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\"));
            Postfile.SaveAs(Server.MapPath(Path + fileName));
            return 1;

        }

    }

}
