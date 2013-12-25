using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using SayUSayMe.BLL;
using SayUSayMe.Model;

namespace NewsManage.news.datagrid
{
    public partial class NewsManageNewsDatagridManageNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定文本数据
                DataTable dt = ArticleManage.getsortName();
                DDLclassSort.DataSource = dt;
                //.DataTextField 
                DDLclassSort.DataTextField = "sortName";
                DDLclassSort.DataBind();

             
            }
         

        }
        protected void BtnAddNews_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty (txtNewsContent.Text.Trim ())
                    || string.IsNullOrEmpty (TxtNewsSubject.Text.Trim ()))
                {
                    Response.Write ("<script>alert('添加新闻每项都不能为空哦~')</script>");
                }
                #region 插入一条新闻
                #region 图片的处理代码
                if (FileUpload1.HasFile)
                {
                    Session["imge"] = FileUpload1.FileBytes;
                    showImage.ImageUrl = "ImageHandler.ashx";
                }

                System.Drawing.Image image;
                byte[] mybyte = (byte[])Session["imge"];
                MemoryStream mymemorystream = new MemoryStream(mybyte, 0, mybyte.Length);
                image = System.Drawing.Image.FromStream(mymemorystream);
                System.Drawing.Bitmap bit = new System.Drawing.Bitmap(image.Width, image.Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bit);
                g.DrawImage(image, new Rectangle(0, 0, bit.Width, bit.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

                image.Dispose();
                string pathExist = this.Page.MapPath("Uploads/new/");
                if (!Directory.Exists(pathExist))
                {
                    Directory.CreateDirectory(pathExist);
                }
                #endregion
                News news = new News();
                if (!string.IsNullOrEmpty(Session["userName"].ToString()))
                {
                    string userName = Session["userName"].ToString();
                    news.userID = UserManage.GetUserID(userName);
                    news.NewsContent = txtNewsContent.Text.Trim();
                    news.NewsSubject = TxtNewsSubject.Text.Trim();
                    news.addDate = DateTime.Now.Date;
                    news.classSort = ArticleManage.GetclassSort(DDLclassSort.SelectedValue.ToString());

                    #region 上传图片的处理代码
                    string filename = DateTime.Now.Ticks + ".jpg";
                    string newPath = pathExist + filename;
                    news.NewsPhoto = filename;
                    bit.Save(newPath);
                    bit.Dispose();

                    #endregion

                    //for (int i = 0; i < 300; i++)
                    //{
                    //    ArticleManage.InsertNews (news);
                    //}
                    if (ArticleManage.InsertNews(news) != 0)
                    {
                        Response.Write("<script>alert('添加成功~~');location.href = 'http://localhost:27265/SayUSayMe.Web/Default.aspx';</script>");

                    }
                    else
                    {
                        Response.Write("<script>alert('检测到您未登录，前往登陆页~~~');location.href = 'http://localhost:27265/SayUSayMe.Web/Default.aspx'</script>");
                    }
                }
                else
                {
                    Response.Redirect("../../../Default.aspx");
                }

                #endregion  
            }
            catch (Exception ee)
            {

                Response.Write("<script>alert('发生异常："+ee.Message+"~~');location.href = 'http://localhost:27265/SayUSayMe.Web/Default.aspx';</script>");
            }
          
        }
        protected void BtnDeleteNews_Click(object sender, EventArgs e)
        {
            int DeleteNumber = Convert.ToInt32(DDL_DeleteNews.SelectedValue);

            switch (DeleteNumber)
            {
                case 10:
                    try
                    {
                        
                         Response.Write("<script>alert('已经删除"+ArticleManage.DeleteNews (10)+"条新闻~~')</script>");
                    }
                    catch 
                    {
                        
                       Response.Write("<script>alert('删除新闻失败~~')</script>");
                    }
                 
                    break;

                case 30:
                    try
                    {

                        Response.Write("<script>alert('已经删除" + ArticleManage.DeleteNews(30) + "条新闻~~')</script>");
                    }
                    catch
                    {

                        Response.Write("<script>alert('删除新闻失败~~')</script>");
                    }
                    break;
                case 50:
                    try
                    {

                        Response.Write("<script>alert('已经删除" + ArticleManage.DeleteNews(50) + "条新闻~~')</script>");
                    }
                    catch
                    {

                        Response.Write("<script>alert('删除新闻失败~~')</script>");
                    }
                    break;
                case 100:
                    try
                    {

                        Response.Write("<script>alert('已经删除" + ArticleManage.DeleteNews(100) + "条新闻~~')</script>");
                    }
                    catch
                    {

                        Response.Write("<script>alert('删除新闻失败~~')</script>");
                    }
                    break;
                default: Response.Write("<script>alert('删除新闻失败~~')</script>"); break;

            }
        }
}
}