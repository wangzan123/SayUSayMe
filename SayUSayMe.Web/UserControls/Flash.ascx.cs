using System;
using System.Data;
using System.Text;
using SayUSayMe.BLL;

public partial class UC_Flash : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string linkurl = "ShowImg.aspx";
            //图片地址,图片描述,图片超链接
            StringBuilder sbImagesStr, sbTxtStr, sbLinkStr;
             
            sbImagesStr = new StringBuilder();
            sbTxtStr = new StringBuilder();
            sbLinkStr = new StringBuilder();
            DataTable table = CatalogAccess.GetNewsImg();
            if (table.Rows.Count <= 1)
            {
                 //弹出窗口提示图片不足
                script.Text = "<script type='text/javascript'>document.write('至少需要两张相片才能正确显示幻灯效果');</script>";
                return;
            }
            int ret = 0;
            foreach (DataRow row in table.Rows)
            {
                string NewPic = row["imgUrl"].ToString();

                if (0 == ret)
                {
                    sbImagesStr.Append(NewPic);
                    sbTxtStr.Append(row["imgDescription"].ToString());
                    sbLinkStr.Append(linkurl);
                    ret = 1;
                }
                else
                {
                    //图片地址
                    sbImagesStr.Append("|" + NewPic);
                    sbTxtStr.Append("|" + row["imgDescription"].ToString());
                    sbLinkStr.Append("|" + linkurl);
                }
            }
            ltFiles.Text = sbImagesStr.ToString();
            ltLinks.Text = sbLinkStr.ToString();
            ltTexts.Text = sbTxtStr.ToString();
        }
    }

}
