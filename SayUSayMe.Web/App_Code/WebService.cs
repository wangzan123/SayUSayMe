using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using SayUSayMe.BLL;
using SayUSayMe.Model;


/// <summary>
///WebService 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    //检查用户名是否存在
    [WebMethod]
    public int CheckUserName(string userName)
    {
        //当有人使用了则返回一
        if (CatalogAccess.GetUserByUserName(userName.Trim()))
            return 1;
        else//否则返回0
            return 0;
    }
    //核对验证码
    [WebMethod(EnableSession=true)]
    public int CheckCodeNumber(string code)
    {
        if (Session["code"] != null&&code!=null)
        {
            if (code.Trim().ToUpper() == Session["code"].ToString())
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }
    //登录函数
    [WebMethod(EnableSession = true)]
    public int Login(string name,string password)
    {
        int state=CatalogAccess.GetRecordByNamePw(name.Trim(), password.Trim());
        if (state == 1)//正常
        {
            Session["userName"] = name.Trim();
            Session["state"] = state;
            return 1;
        }
        else if (state == 0)//禁言
        {
            Session["userName"] = name.Trim();
            Session["state"] = state;
            return 0;
        }
        else if (state == -1)//停用
            return -1;
        else        //不存在
            return -2;
    }
    //判断是否登录
    [WebMethod(EnableSession = true)]
    public string CheckLoginState()
    {
        
       if (Session["userName"] != null)
           return Session["userName"].ToString();
       else
                return "";
    }
    //更新大板块状态
    [WebMethod(EnableSession = true)]
    public string updateCatalogState(int cid,int cstate)
    {

        if (Session["userName"] != null)
        {
            if (CatalogAdmin.updateCatalogStateBycid(cid, (cstate == 0 ? 1 : 0)))
                return "success";
            else
                return "";
        }
        else
            return "";
    }

    //更新小板块状态
    [WebMethod(EnableSession = true)]
    public string updateClassState(int cid, int cstate)
    {

        if (Session["userName"] != null)
        {
            if (CatalogAdmin.updateClassStateBycid(cid, (cstate == 0 ? 1 : 0)))
                return "success";
            else
                return "";
        }
        else
            return "";
    }


    [WebMethod(EnableSession = true)]
    public string CheckUserState()
    {
        if (Session["userName"] != null)
        {
            if (CatalogAdmin.checkUserState(Session["userName"].ToString()) == "1")//正常使用
                return "success";
            else if (CatalogAdmin.checkUserState(Session["userName"].ToString()) == "0")//禁言
                return "fobidden";
            else if (CatalogAdmin.checkUserState(Session["userName"].ToString()) == "-1")//停用
                return "stop";
            else return "";
        }
        else
            return "";
    
    }
    //判断登陆
    [WebMethod(EnableSession = true)]
    public string CheckLogined()
    {
        if (Session["userName"] != null)
            return Session["userName"].ToString();
        else
            return "";
    }
    //判断用户角色
    [WebMethod(EnableSession=true)]
    public int CheckUserType()
    {
        return CatalogAdmin.GetUserRoleByName(Session["userName"].ToString());
    }
    //退出登录函数
    [WebMethod(EnableSession = true)]
    public void LoginOut()
    {
        if (Session["userName"] != null)
            Session.Remove("userName");
    } 
    //用户已经查看了回复信息，添加处理
    [WebMethod]
    public int Worked(string commentID)
    {
        if (CatalogAccess.UpdateWorkedByID(Int32.Parse(commentID)) > 0)
            return 1;
        else
            return 0;
    }
    //用户提交更新数据
    [WebMethod(EnableSession = true)]
    public int UpdateUserDetails(string postData)
    {
        if(CatalogAccess.UpdateUserDetails(postData,Session["userName"].ToString()))
            return 1;
        return 0;
    }
    //删除文章
    [WebMethod]
    public int SetArticleStateByID(string articleID,string type)
    {
        if (CatalogAdmin.SetArticleStateByID(Int32.Parse(articleID), type))
            return 1;
        else
            return 0;
    }
    //更新文章等级
    [WebMethod]
    public int updateArticleGradeByID(string aricleID, string articleGrade)
    {
        if (CatalogAdmin.updateArticleGradeByID(Int32.Parse(aricleID), (Int32.Parse(articleGrade) == 0 ? 1 : 0)))
        {
            return 1;
        }
        else return 0;
    
    }
    //检查文章
    [WebMethod]
    public int CheckArticleByID(string articleID)
    {
        if(CatalogAdmin.CheckArticleByID(Int32.Parse(articleID)))
            return 1;
        else
            return 0;
    }
    //查看用户信息
    [WebMethod]
    public string GetUserData(string userID)
    {
        DataTable data = CatalogAdmin.BordAdminGetUserByID(Int32.Parse(userID));
        System.Text.StringBuilder userText = new System.Text.StringBuilder();
        userText.Append("<hr /><table border=\"0\">");
        userText.Append("<tr><td><b>用户名注册名：</b></td><td>"+data.Rows[0]["userName"].ToString()+"</td></tr>");
        userText.Append("<tr><td><b>用户论坛使用名：</b></td><td>" + data.Rows[0]["userShowName"].ToString() + "</td></tr>");  
        if(Int32.Parse(data.Rows[0]["userState"].ToString())==0)
            userText.Append("<tr><td><b>用户状态：</b></td><td>已被停用</td></tr>");            
        else
            userText.Append("<tr><td><b>用户状态：</b></td><td>正常使用</td></tr>");

        userText.Append("<tr><td><b>用户积分：</b></td><td>" + data.Rows[0]["userScore"].ToString() + "</td></tr>");
                
        switch(Int32.Parse(data.Rows[0]["popedom"].ToString()))
        {
            case 0:
                userText.Append("<tr><td><b>用户角色：</b></td><td>系统管理员</td></tr>");
                break;
            case -1:
                userText.Append("<tr><td><b>用户角色：</b></td><td>普通用户</td></tr>");
                break;
            default:
                userText.Append("<tr><td><b>用户角色：</b></td><td>版主</td></tr>");
                break;
        }
        userText.Append("<tr><td><b>用户性别：</b></td><td>" + data.Rows[0]["userSex"].ToString() + "</td></tr>");
        userText.Append("<tr><td><b>用户职业：</b></td><td>" + data.Rows[0]["userMajor"].ToString() + "</td></tr>");
        userText.Append("<tr><td><b>用户地址：</b></td><td>" + data.Rows[0]["userAddress"].ToString() + "</td></tr>");
        userText.Append("</table><hr />");
        return userText.ToString(); 
    }
    //返回子版块信息
    [WebMethod()]
    public System.Collections.Generic.List<ArticleClassData> GetClassByCatalogID(string catalogID)
    {
        DataTable data = CatalogAdmin.GetClassByCatalogID(Int32.Parse(catalogID));
        System.Collections.Generic.List<ArticleClassData> lists = new System.Collections.Generic.List<ArticleClassData>();
        foreach (DataRow row in data.Rows)
        {
            lists.Add(new ArticleClassData(row["classID"].ToString(),row["className"].ToString()));
        }
        return lists;
    }
    //更新板块信息
    [WebMethod()]
    public int UpdateCatalogData(string catalogID, string postData)
    {
        if (CatalogAdmin.UpdateCatalogData(Int32.Parse(catalogID), postData))
            return 1;
        else
            return 0;

    }
    //得到申请的信息
    [WebMethod()]
    public string GetApplyTitle()
    {
        DataTable data= CatalogAdmin.GetApplyTitle();
        string returnString = "";
        foreach (DataRow row in data.Rows)
        {
            returnString += row[0].ToString() + "&";
        }
        return returnString;
    }
    //查找申请用户详细信息
    [WebMethod]
    public string GetApplyUserDetails(int userID)
    {
        string template = "<table>" +
                          "<tr><td>论坛用户名：</td><td>{$userName}</td></tr>" +
                          "<tr><td>用户注册名：</td><td>{$userShowName}</td></tr>" +
                          "<tr><td>用户注册时间：</td><td>{$userAddDate}</td></tr>" +
                          "<tr><td>用户状态：</td><td>{$userState}</td></tr>" +
                          "<tr><td>用户积分：</td><td>{$userScore}</td></tr>" +
                          "<tr><td>发表文章数：</td><td>{$articleSum}</td></tr>" +
                          "<tr><td>格言：</td><td>{$userMaxim}</td></tr>" +
                          "<tr><td>手机号码：</td><td>{$userMoblie}</td></tr>" +
                          "<tr><td>用户性别：</td><td>{$userSex}</td></tr>" +
                          "<tr><td>用户职业：</td><td>{$userMajor}</td></tr>" +
                          "<tr><td>用户住址：</td><td>{$userAddress}</td></tr>" +
                          "</table>";
        DataTable data = CatalogAdmin.GetApplyUserDetails(userID);
        if(data!=null)
        {
            DataRow row = data.Rows[0];
            //论坛用户使用名
            if(row["userName"].ToString()!="")
                template=template.Replace("{$userName}",row["userName"].ToString());
            else
                template=template.Replace("{$userName}","无");
            //用户注册名
            if(row["userShowName"].ToString()!="")
                template=template.Replace("{$userShowName}",row["userShowName"].ToString());
            else
                template=template.Replace("{$userShowName}","无");
            //用户注册时间
            template = template.Replace("{$userAddDate}", Convert.ToDateTime(row["addDate"].ToString()).ToLongDateString());
            
            //用户状态
            if(row["userState"].ToString()=="0")
                template=template.Replace("{$userState}","已被停用");
            else
                template=template.Replace("{$userState}","正常使用");
            //用户积分
            template=template.Replace("{$userScore}", row["userScore"].ToString());
            //发表文章数
            template=template.Replace("{$articleSum}",row["articleSum"].ToString());
            //用户格言
            if (row["userMaxim"].ToString() != "")
                template = template.Replace("{$userMaxim}", row["userMaxim"].ToString());
            else
                template = template.Replace("{$userMaxim}", "无");
            //手机号码
            if(row["userMoblie"].ToString()!="")
                template=template.Replace("{$userMoblie}",row["userMoblie"].ToString());
            else
                template=template.Replace("{$userMoblie}","无");
            //用户性别
            if(row["userSex"].ToString()!="")
                template=template.Replace("{$userSex}",row["userSex"].ToString());
            else
                template=template.Replace("{$userSex}","未填写");
            //用户专业
            if (row["userMajor"].ToString() != "")
                template = template.Replace("{$userMajor}", row["userMajor"].ToString());
            else
                template=template.Replace("{$userMajor}","未填写");
            //用户住址
            if (row["userAddress"].ToString() != "")
                template = template.Replace("{$userAddress}", row["userAddress"].ToString());
            else
                template = template.Replace("{$userAddress}", "未填写");
        }
        return template;

    }
    [WebMethod]
    public int UpdateApply(int applyID, string failedText, string type)
    {
        if (CatalogAdmin.UpdateApply(applyID, failedText, type)) 
            return 1; 
        else return 0;
    }
    //输入提示
    [WebMethod]
    public string[] GetCompleteData(string prefixText, int count)
    {
        DataTable data = CatalogAccess.SelectAutoCompleteData(prefixText, 1, count);
        List<string> items = new List<string>(data.Rows.Count);
        for (int i = 0; i <data.Rows.Count; i++)
        {
            items.Add(data.Rows[i]["articleSubject"].ToString());
        }
        return items.ToArray();
    }
    //更新用户状态
    [WebMethod()]
    public int UpdateUserStateByAdmin(string uid,string type)
    {
        if (CatalogAdmin.updateUserState(uid, type))
            return 1;
        else return 0;
    }
    
}

