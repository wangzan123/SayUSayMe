using System;
using System.Data;
using System.Data.Common;



namespace SayUSayMe.DAL
{
    #region
    /// <summary>
    ///CatalogAdmin主要是后台对数据库的更改
    /// </summary>
    public static class CatalogAdmin
    {
        static CatalogAdmin ()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //更新大板块状态
        public static bool updateCatalogStateBycid (int cid, int cstate)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "updateCatalogStateBycid";
            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@cid";
            parm.Value = cid;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@cstate";
            parm.Value = cstate;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //更新小板块状态
        public static bool updateClassStateBycid (int cid, int cstate)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "updateClassStateBycid";
            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@cid";
            parm.Value = cid;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@cstate";
            parm.Value = cstate;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //得到简短的模块信息
        public static DataTable GetShortCatalogByUN (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetShortCatalogByUN";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Size = 20;
            parm.Value = userName.Trim ();
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //根据ID号查询详细的模块信息
        public static DataTable GetArticleCatalogByID (int catalogID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetArticleCatalogByID";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@catalogID";
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到简短的分类信息
        public static DataTable GetShortClassByCataID (int catalogID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetShortClassByCataID";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@catalogID";
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到版主信息
        public static DataTable GetBordAminByID (int catalogID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetBordAminByID";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@catalogID";
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //获得用户状态
        public static DataTable GetUserStateByAdmin
            (string userName, int pageNumber, int userState, out int howManyPage)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "BorderAdminGetUserState";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@userName";
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@pageNumber";
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@UserPerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.ArticlePerPage;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@UserState";
            parm.Value = userState;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyUsers";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output;
            comm.Parameters.Add (parm);

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            //得到返回的行数
            int howManyUsers = Int32.Parse (comm.Parameters ["@howManyUsers"].Value.ToString ());
            //计算出页码
            howManyPage = (int) Math.Ceiling ((double) howManyUsers/(double) GetConfigurationSettings.ArticlePerPage);

            return data;

        }

        // 更新用户状态
        public static bool updateUserState (string uid, string type)
        {
            int u;
            try
            {
                u = Convert.ToInt32 (uid);
            }
            catch (Exception ex)
            {
                return false;
            }
            DbCommand dbcom = GenericDataAccess.CreateCommand ();
            dbcom.CommandText = "updateUserState";
            DbParameter pam = dbcom.CreateParameter ();
            pam.DbType = DbType.Int32;
            pam.ParameterName = "@userID";
            pam.Value = u;
            dbcom.Parameters.Add (pam);

            pam = dbcom.CreateParameter ();
            pam.DbType = DbType.Int32;
            pam.ParameterName = "@userState";
            if (type == "forbiden")
                pam.Value = 0;
            else if (type == "normal")
                pam.Value = 1;
            dbcom.Parameters.Add (pam);
            if (GenericDataAccess.ExecuteNonQuery (dbcom) > 0)
                return true;
            else
                return false;
        }

        //更新模块信息
        public static bool UpdateCatalogData (int catalogID, string postData)
        {
            string catalogName = "";
            string indexUrl = "";
            string catalogDescription = "";

            string[] postParm = postData.Split ('&');
            string[] postValue;
            for (int i = 0; i < postParm.Length; i++)
            {
                postValue = postParm [i].Split ('=');
                switch (postValue [0])
                {
                    case "catalogName":
                        catalogName = postValue [1].Trim ();
                        break;
                    case "catalogDescription":
                        catalogDescription = postValue [1].Trim ();
                        break;
                    case "indexUrl":
                        indexUrl = postValue [1].Trim ();
                        break;
                    default:
                        break;
                }
            }

            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateCatalogData";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@catalogID";
            parm.DbType = DbType.Int32;
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@catalogName";
            parm.Value = catalogName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@indexUrl";
            parm.Value = indexUrl;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@catalogDescription";
            parm.DbType = DbType.String;
            parm.Value = catalogDescription;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //更新子版块信息
        public static bool UpdateClassData
            (int classID, string className, string classDescription, string classImg, string warning)
        {

            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateClassData";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@className";
            parm.DbType = DbType.String;
            parm.Value = className;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classDescription";
            parm.DbType = DbType.String;
            parm.Value = classDescription;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classImg";
            parm.DbType = DbType.String;
            parm.Value = classImg;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@warning";
            parm.DbType = DbType.String;
            parm.Value = warning;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //添加模块
        public static bool AddCatalog (string catalogName, string indexUrl, string catalogDescription)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddCatalog";
            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@catalogName";
            parm.Value = catalogName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@indexUrl";
            parm.Value = indexUrl;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@catalogDescription";
            parm.DbType = DbType.String;
            parm.Value = catalogDescription;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@needPopedom";
            parm.DbType = DbType.Int32;

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //添加子版块
        public static int AddClass
            (int catalogID, string className, string classDescription, string classImg, string warning)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddClass";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@catalogID";
            parm.DbType = DbType.Int32;
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@className";
            parm.DbType = DbType.String;
            parm.Value = className;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classDescription";
            parm.DbType = DbType.String;
            parm.Value = classDescription;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classImg";
            parm.DbType = DbType.String;
            parm.Value = classImg;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@warning";
            parm.DbType = DbType.String;
            parm.Value = warning;
            comm.Parameters.Add (parm);

            return Int32.Parse (GenericDataAccess.ExecuteScalar (comm).ToString ());
        }

        //版主查看文章
        public static DataTable BordAdminGetArticle
            (string userName, int pageNumber, int articleState, out int howManyPage)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "BordAdminGetArticle";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articlePerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.ArticlePerPage;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@pageNumber";
            parm.DbType = DbType.Int32;
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleState";
            parm.DbType = DbType.Int32;
            parm.Value = articleState;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyArticle";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output;
            comm.Parameters.Add (parm);

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            //得到返回的行数
            int howManyArticle = Int32.Parse (comm.Parameters ["@howManyArticle"].Value.ToString ());
            //计算出页码
            howManyPage = (int) Math.Ceiling ((double) howManyArticle/(double) GetConfigurationSettings.ArticlePerPage);

            return data;
        }

        //更新文章等级
        public static bool updateArticleGradeByID (int aricleID, int articleGrade)
        {
            DbCommand com = GenericDataAccess.CreateCommand ();
            com.CommandText = "updateArticleGradeByID";
            DbParameter parm = com.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = aricleID;
            com.Parameters.Add (parm);

            parm = com.CreateParameter ();
            parm.ParameterName = "@articleGrade";
            parm.DbType = DbType.Int32;
            parm.Value = articleGrade;
            com.Parameters.Add (parm);
            if (GenericDataAccess.ExecuteNonQuery (com) > 0)
                return true;
            else
                return false;
        }

        //删除文章
        public static bool SetArticleStateByID (int articleID, string operate)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "SetArticleStateByID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = articleID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@state";
            parm.DbType = DbType.Int32;
            if (operate == "delete")
                parm.Value = GetConfigurationSettings.ArticleDeleteState;
            else if (operate == "undelete")
                parm.Value = GetConfigurationSettings.ArticleNormalState;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //标识文章被处理
        public static bool CheckArticleByID (int articleID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "CheckArticleByID";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@articleID";
            parm.Value = articleID;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //检查用户当前状态
        public static string checkUserState (string name)
        {
            DbCommand com = GenericDataAccess.CreateCommand ();
            com.CommandText = "GetUserStateByName";
            DbParameter pam = com.CreateParameter ();
            pam.ParameterName = "@userName";
            pam.DbType = DbType.String;
            pam.Value = name;
            com.Parameters.Add (pam);
            DataTable dt = GenericDataAccess.ExecuteSelectCommand (com);
            if (dt.Rows.Count <= 0)
                return "";
            else
                return dt.Rows [0] [0].ToString ().Trim ();
        }

        public static DataTable GetCatalogMsgByState (string state, int pageNumber, out int howManyPage)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetCatalogMsgByState";
            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@catalogState";

            if (state == "normal")
                parm.Value = 1;
            else if (state == "deleted")
                parm.Value = 0;
            else
                parm.Value = -1;
            comm.Parameters.Add (parm);
            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@pageNumber";
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@CatalogPerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.ArticlePerPage;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyCatalogs";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output;
            comm.Parameters.Add (parm);

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            //得到返回的行数
            int howManyCatalog = Int32.Parse (comm.Parameters ["@howManyCatalogs"].Value.ToString ());
            //计算出页码
            howManyPage = (int) Math.Ceiling ((double) howManyCatalog/(double) GetConfigurationSettings.ArticlePerPage);

            return data;
        }

        //版主查看用户信息
        public static DataTable BordAdminGetUserByID (int userID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "BordAdminGetUserByID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userID";
            parm.DbType = DbType.String;
            parm.Value = userID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //判断大小版主板块
        public static string GetPopedomType (string userName)
        {
            DbCommand com = GenericDataAccess.CreateCommand ();
            com.CommandText = "GetPopedomType";
            DbParameter pam = com.CreateParameter ();
            pam.DbType = DbType.String;
            pam.ParameterName = "@userName";
            pam.Value = userName;
            com.Parameters.Add (pam);
            return GenericDataAccess.ExecuteScalar (com).ToString ().Trim ();

        }

        //判断用户的角色
        public static int GetUserRoleByName (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetUserRoleByName";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            if (comm.Connection.State != ConnectionState.Open)
                comm.Connection.Open ();

            if (Int32.Parse (comm.ExecuteScalar ().ToString ()) == GetConfigurationSettings.SysAdmin)
                return GetConfigurationSettings.SysAdmin;
            else if (Int32.Parse (comm.ExecuteScalar ().ToString ()) == GetConfigurationSettings.WebUsers)
                return GetConfigurationSettings.WebUsers;
            else
                return GetConfigurationSettings.BrodAdmin;

        }

        //根据用户名，返回用户管理的
        public static DataTable GetCatalogByUserName (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetCatalogByUserName";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //根据板块ID，返回板块下面的子版块
        public static DataTable GetClassByCatalogID (int catalogID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetClassByCatalogID";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@catalogID";
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //根据分类ID返回分类的详细信息
        public static DataTable GetClassByID (int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetClassByID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到版块下面的分类
        public static DataTable GetClassSortByID (int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetClassSortByID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //添加板块下面的分类
        public static bool AddClassSort (int classID, string sortName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddClassSort";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@sortName";
            parm.DbType = DbType.String;
            parm.Value = sortName;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            return false;
        }

        //删除板块下面的分类
        public static bool DeleteClassSort (int sortID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "DeleteClassSort";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@sortID";
            parm.DbType = DbType.Int32;
            parm.Value = sortID;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            return false;
        }

        //得到申请的分类
        public static DataTable GetApplyTitle ()
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetApplyTitle";

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到申请的详细内容
        public static DataTable GetApplyDataByTitle (string title, int applyState)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetApplyDataByTitle";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@title";
            parm.DbType = DbType.String;
            parm.Value = title;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyState";
            parm.DbType = DbType.Int32;
            parm.Value = applyState;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到申请人的详细信息
        public static DataTable GetApplyUserDetails (int userID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetApplyUserDetails";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userID";
            parm.DbType = DbType.Int32;
            parm.Value = userID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //处理申请
        public static bool UpdateApply (int applyID, string failedText, string type)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateApply";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@applyID";
            parm.DbType = DbType.Int32;
            parm.Value = applyID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyFailedText";
            parm.DbType = DbType.String;
            if (type == "accept")
                parm.Value = "";
            else
                parm.Value = failedText;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyState";
            parm.DbType = DbType.Int32;
            switch (type)
            {
                case "accept":
                    parm.Value = (int) EnumEntity.ApplyState.applySuccess;
                    break;
                case "refuse":
                    parm.Value = (int) EnumEntity.ApplyState.applyFailed;
                    break;
            }
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return
                    false;

        }

        //添加用户等级
        public static bool AddUserGrade (int gradeID, int level1, int level2, int level3, int level4, int gradeScore)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddUserGrade";
            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.ParameterName = "@gradeID";
            parm.DbType = DbType.Int32;
            parm.Value = gradeID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@level1";
            parm.DbType = DbType.Int32;
            parm.Value = level1;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@level2";
            parm.DbType = DbType.Int32;
            parm.Value = level2;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@level3";
            parm.DbType = DbType.Int32;
            parm.Value = level3;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@level4";
            parm.DbType = DbType.Int32;
            parm.Value = level4;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@gradeScore";
            parm.DbType = DbType.Int32;
            parm.Value = gradeScore;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //获得小板块状态
        public static DataTable GetClassByCatalogIDClassState
            (int catalogID, int pageNumber, out int howManyPage, int classState)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetClassByCatalogIDClassState";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@catalogID";
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@pageNumber";
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@ClassPerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.ArticlePerPage;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@classState";
            parm.Value = classState;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyPage";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output;
            comm.Parameters.Add (parm);

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            //得到返回的行数
            int howManyUsers = Int32.Parse (comm.Parameters ["@howManyPage"].Value.ToString ());
            //计算出页码
            howManyPage = (int) Math.Ceiling ((double) howManyUsers/(double) GetConfigurationSettings.ArticlePerPage);

            return data;

        }
    }
    #endregion

}

