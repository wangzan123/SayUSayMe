using System;
using System.Web;
using System.Web.UI.WebControls;
using SayUSayMe.BLL;

public partial class WebEditor_Upload_Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int intTypeID = Convert.ToInt32(Request["type"]);
            intTypeID = 1;
            string strPath = "", strType = "";
            int intMaxSize = 0;
            int intWidth = 0;
            string strNote1 = "", strCaption = "文件上传";
            string strNote2 = "<li>转载他人内容涉及侵权纠纷时，你将为此承担一切法律责任；</li><li>转载的的内容不可违反国家法律法规！</li>";

            string strJScript_Ok = Request.QueryString["ok"];
            
            string strJScript_Cancle = Request["cancle"];
            if (strJScript_Cancle != null && strJScript_Cancle != "")
            {
                this.btnCancle1.Attributes.Add("onclick", strJScript_Cancle + ";return false");
            }
            if (intTypeID != null)
            {
                switch (intTypeID)
                {
                    //适合上传各种类型的文件
                    case 1:
                        strPath = "Files/";
                        intMaxSize = 1024 * 10;
                        strType = ".JPG|.PNG|.BMP|.GIF|";
                        strCaption = "图片文件上传";
                        strNote1 = "<li>允许上传的文件类型为{$filetype};</li><li>允许上传的文件最大为{$maxsize};";
                        break;
                }
            }
            this.Caption.Text = strCaption;
            strNote1=strNote1.Replace("{$filetype}", strType);
            this.showMessage.Text = intMaxSize > 1024 ? strNote1.Replace("{$maxsize}", (intMaxSize / 1024).ToString().Trim() + "MB") : strNote1.Replace("{$maxsize}", intMaxSize.ToString().Trim() + "KB");
            this.showMessage.Text += strNote2;

            ViewState["strPath"] = strPath;
            ViewState["intMaxSize"] = intMaxSize;
            ViewState["strType"] = strType;
            ViewState["jsScript"] = strJScript_Ok;
            
        }
    }
    public void btnOK1_Click(object sender, EventArgs e)
    {
        ClassFileUpload upload = new ClassFileUpload();
        upload.fUpload = ImgUpload;
        upload.FileType = ViewState["strType"].ToString();
        upload.MaxSize = Int32.Parse(ViewState["intMaxSize"].ToString());
        upload.FilePath = ViewState["strPath"].ToString();
        ViewState["imgPath"] = ImgUpload.PostedFile.FileName;

        string strJscript = ViewState["jsScript"] != null ? ViewState["jsScript"].ToString().Trim() : "";
        
        if (upload.UploadBegin()&&strJscript!=""&&CatalogAccess.InsertImg("WebEditor/Upload/" + upload.FileName,""))
        {

            strJscript = strJscript.Replace("{$filename}", "WebEditor/Upload/" + upload.FileName);
            
            strJscript="<script type=\"text/javascript\">"+strJscript+"</script>";

            Response.Write(strJscript);
        }
        upload = null;
    }

    public class ClassFileUpload
    {
        /// <summary>
        /// 空的构造函数
        /// </summary>
        public ClassFileUpload()
        { }
        #region
        //实例变量
        private string 
            _FileName,
            _FilePath,
            _FileType;
        private int
            _MaxSize,
            _Width,
            _Height;
        private FileUpload
            _fUpload;
        //属性
        //保存的文件名
        public string FileName
        {
            get{return _FileName;}
            set{_FileName=value;}
        }
        //保持路径
        public string FilePath
        {
            get{return _FilePath;}
            set{_FilePath=value;}
        }
        //文件类型
        public string FileType
        {
            get{return _FileType;}
            set{_FileType=value;}
        }
        //记录最大文件大小
        public int MaxSize
        {
            get{return _MaxSize;}
            set{_MaxSize=value;}
        }
        //记录图片的高度
        public int Height
        {
            get{return _Height;}
            set{_Height=value;}
        }
        //记得图片的宽度
        public int Width
        {
            get{return _Width;}
            set{_Width=value;}
        }
        //上传文件控件对象
        public FileUpload fUpload
        {
            get { return _fUpload; }
            set { _fUpload = value; }
        }
#endregion
        public void MsgBox(string message)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('"+message+"')</script>");
        }

        public bool UploadBegin()
        {
            if (fUpload.HasFile)
            {
                string strSourceFile = this.fUpload.PostedFile.FileName;
                string strSourceFileType = strSourceFile.Substring(strSourceFile.LastIndexOf('.')).ToLower();
                if (this.FileType.ToLower().IndexOf(strSourceFileType) == -1)
                {
                    MsgBox("对不起,文件类型不符合");
                    return false;
                }
                if (this.fUpload.FileBytes.Length > this.MaxSize * 1024)
                {
                    MsgBox("对不起,文件太大");
                    return false;
                }
                Guid name = Guid.NewGuid();
                this.FileName = this.FilePath +name.ToString()+this.fUpload.PostedFile.FileName.Substring(this.fUpload.PostedFile.FileName.LastIndexOf("\\")+1);
                try
                {
                    this.fUpload.SaveAs(System.Web.HttpContext.Current.Server.MapPath(this.FileName));
                   
                        return true;
                   
                }
                catch (Exception)
                {

                    throw;
                    
                }
            }
            else
            {
                MsgBox("没有添加文件");
                return false;
            }
        } 

    }
}
