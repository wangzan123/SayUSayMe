using System;
using System.Configuration;


namespace SayUSayMe.DAL
{
    /// <summary>
    /// 主要得到配置文件的配置信息
    /// </summary>
    public static class GetConfigurationSettings
    {

        //静态缓存
        //数据库连接字符串
        private static string dbConnectionString;
        //数据库提供程序
        private static string dbProviderName;
        //设置每页显示文章数
        private static int articlePerPage;
        //一页中显示多少条文章回复
        private static int replyPerPage;
        //在一个页中显示多少个数字
        private static int numberPerPage;
        //显示等级图片
        private static string[] levelPic;

        //用户权限(四种角色，普通用户，版主用户，模块管理员用户，系统管理员用户)
        private static int bordAdmin; //版主 
        private static int moduleAdmin; //模块管理员
        private static int sysAdmin; //系统管理员
        private static int webUsers; //普通用户
        //角色权限
        //版主              
        private static bool bordAminDeleteArticle;
        private static bool bordAdminStopUser;
        //模块管理员
        private static bool moduleAdminDeleteArticle;
        private static bool moduleAdminStopUser;
        //系统管理员
        private static bool sysAdminDeleteArticle;
        private static bool sysAdminStopUser;

        //输入内容提示配置
        private static int autoCompleteRecord;
        private static int searchContentLength;
        //静态构造函数
        static GetConfigurationSettings ()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings ["DbconnectionString"].ConnectionString;
            dbProviderName = ConfigurationManager.ConnectionStrings ["DbconnectionString"].ProviderName;
            articlePerPage = Int32.Parse (ConfigurationManager.AppSettings ["articlePerPage"]);
            numberPerPage = Int32.Parse (ConfigurationManager.AppSettings ["numberPerPage"]);
            replyPerPage = Int32.Parse (ConfigurationManager.AppSettings ["replyPerPage"]);
            //等级图片
            levelPic = new string[4];
            levelPic [0] = ConfigurationManager.AppSettings ["level1Pic"];
            levelPic [1] = ConfigurationManager.AppSettings ["level2Pic"];
            levelPic [2] = ConfigurationManager.AppSettings ["level3Pic"];
            levelPic [3] = ConfigurationManager.AppSettings ["level4Pic"];
            //用户角色标示
            //根据角色标示，先判断用户属于哪个角色
            bordAdmin = Int32.Parse (ConfigurationManager.AppSettings ["bordAdmin"]);
            moduleAdmin = Int32.Parse (ConfigurationManager.AppSettings ["moduleAdmin"]);
            sysAdmin = Int32.Parse (ConfigurationManager.AppSettings ["sysAdmin"]);
            webUsers = Int32.Parse (ConfigurationManager.AppSettings ["webUsers"]);
            //再判断该角色是否有删除文章，停用用户的权力（普通用户只有发表文章，发表评论的权限）
            bordAminDeleteArticle = bool.Parse (ConfigurationManager.AppSettings ["bordAminDeleteArticle"]);
            bordAdminStopUser = bool.Parse (ConfigurationManager.AppSettings ["bordAdminStopUser"]);
            moduleAdminDeleteArticle = bool.Parse (ConfigurationManager.AppSettings ["moduleAminDeleteArticle"]);
            moduleAdminStopUser = bool.Parse (ConfigurationManager.AppSettings ["moduleAdminStopUser"]);
            sysAdminDeleteArticle = bool.Parse (ConfigurationManager.AppSettings ["sysAminDeleteArticle"]);
            sysAdminStopUser = bool.Parse (ConfigurationManager.AppSettings ["sysAdminStopUser"]);

            //得到配置文件中提示框的配置信息
            autoCompleteRecord = Convert.ToInt32 (ConfigurationManager.AppSettings ["autoCompleteRecord"]);
            searchContentLength = Convert.ToInt32 (ConfigurationManager.AppSettings ["searchContentLength"]);
        }

        //文章的几种状态
        //已经处理
        //被删除
        //刚刚发表没有处理
        public static int ArticleCheckedState
        {
            get { return Int32.Parse (ConfigurationManager.AppSettings ["articleCheckedState"]); }
        }

        public static int ArticleDeleteState
        {
            get { return Int32.Parse (ConfigurationManager.AppSettings ["articleDeleteState"]); }
        }

        public static int ArticleNormalState
        {
            get { return Int32.Parse (ConfigurationManager.AppSettings ["articleNormalState"]); }
        }

        //返回查询内容的长度和提示内容的条数
        public static int AutoCompleteRecord
        {
            get { return autoCompleteRecord; }

        }

        public static int SearchContentLength
        {
            get { return searchContentLength; }
        }

        //得到子版块前面的例图
        public static string newImg
        {
            get { return ConfigurationManager.AppSettings ["newImg"]; }
        }

        public static string normalImg
        {
            get { return ConfigurationManager.AppSettings ["normalImg"]; }
        }

        //静态类属性属于静态类成员，在静态类成员第一次调用的时候就被创建，而且一直没有被销毁
        //等级图片
        public static string LevelPic (int i)
        {
            return levelPic [i];
        }

        //四种角色标示
        public static int BrodAdmin
        {
            get { return bordAdmin; }
        }

        public static int ModuleAdmin
        {
            get { return moduleAdmin; }
        }

        public static int SysAdmin
        {
            get { return sysAdmin; }
        }

        public static int WebUsers
        {
            get { return webUsers; }
        }

        //每页显示多少条查询记录
        public static int SearchPerPageRecord
        {
            get { return Int32.Parse (ConfigurationManager.AppSettings ["searchPerPageRecord"]); }
        }

        //角色权限分配
        //版主
        public static bool BordAdminDeleteArticle
        {
            get { return bordAminDeleteArticle; }
        }

        public static bool BordAdminStopUsers
        {
            get { return bordAdminStopUser; }
        }

        //模块管理员
        public static bool ModuleAdminDeleteArticle
        {
            get { return moduleAdminDeleteArticle; }
        }

        public static bool ModuleAdminStopUser
        {
            get { return moduleAdminStopUser; }
        }

        //系统管理员
        public static bool SysAdminDeleteArticle
        {
            get { return sysAdminDeleteArticle; }
        }

        public static bool SysAdminStopUser
        {
            get { return sysAdminStopUser; }
        }

        //连接字符串
        public static string DbConnectionString
        {
            get { return dbConnectionString; }
        }

        //数据提供程序
        public static string DbProviderName
        {
            get { return dbProviderName; }
        }

        //每一页显示多少篇文章
        public static int ArticlePerPage
        {
            get { return articlePerPage; }
        }

        //每一页显示多少个数字（分页数字）
        public static int NumberPerPage
        {
            get { return numberPerPage; }
        }

        //每一页显示多少条回复
        public static int ReplyPerPage
        {
            get { return replyPerPage; }
        }

    }

}