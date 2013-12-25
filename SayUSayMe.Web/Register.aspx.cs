using System;
using SayUSayMe.DAL;
using CatalogAccess = SayUSayMe.BLL.CatalogAccess;


public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        userName.Focus();
    }
    public void btnRegisterClick(object sender, EventArgs e)
    {
        if (Session["code"] != null)
        {
            if (confirmID.Text.Trim().ToUpper() == Session["code"].ToString()&&(passWord.Text.Trim()==passWordConfirm.Text.Trim()))//检查验证码
            {
                //判断用户名是否已经存在
                if (CatalogAccess.GetUserByUserName(userName.Text))
                {
                    script.Text = "objUNstate.innerHTML=errorImg.replace(/\\{\\$text\\}/g,'用户名不可以少于6位');";
                    return;
                }
                else
                {
                    if (CatalogAccess.InsertUser(userName.Text.Trim(), passWord.Text.Trim(),GetConfigurationSettings.WebUsers))
                    {
                        script.Text = "<script type='text/javascript'>" +
                                   "document.getElementById('form').style.display='none';" +
                                   "document.getElementById('btnRegister').style.display='none';" +
                                   "document.getElementById('success').style.display='';</script>";
                        Session["userName"] = userName.Text.Trim();
                        return;
                    }

                    else
                    {
                        script.Text = "<script type='text/javascript'>alert('注册失败');</script>";
                        return;
                    }
                }
            }
            else
            {
                script.Text = "<script type='text/javascript'>alert('非法注册');</script>";   
            }
        }
        else
        {
            script.Text = "<script type='text/javascript'>objCode.innerHTML=errorImg.replace(/\\{\\$text\\}/g,'验证码过期');</script>";
        }
    }
}
