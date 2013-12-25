using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using SayUSayMe.DAL;

namespace SayUSayMe.BLL
{
    #region
    /// <summary>
    ///CatalogAdmin主要是后台对数据库的更改
    /// </summary>
    public static class CatalogAdmin
    {
        static CatalogAdmin()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        //更新大板块状态
        public static bool updateCatalogStateBycid(int cid, int cstate)
        {
            return SayUSayMe.DAL.CatalogAdmin.updateCatalogStateBycid(cid,cstate);
        }

        //更新小板块状态
        public static bool updateClassStateBycid(int cid, int cstate)
        {
            return SayUSayMe.DAL.CatalogAdmin.updateClassStateBycid( cid, cstate);
        }

        //得到简短的模块信息
        public static DataTable GetShortCatalogByUN(string userName)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetShortCatalogByUN(userName);
        }

        //根据ID号查询详细的模块信息
        public static DataTable GetArticleCatalogByID(int catalogID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetArticleCatalogByID( catalogID);
        }

        //得到简短的分类信息
        public static DataTable GetShortClassByCataID(int catalogID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetShortClassByCataID( catalogID);
        }

        //得到版主信息
        public static DataTable GetBordAminByID(int catalogID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetBordAminByID(catalogID);
        }

        //获得用户状态
        public static DataTable GetUserStateByAdmin
            (string userName, int pageNumber, int userState, out int howManyPage)
        {

            return SayUSayMe.DAL.CatalogAdmin.GetUserStateByAdmin
            (userName, pageNumber, userState, out  howManyPage);
        }

        // 更新用户状态
        public static bool updateUserState(string uid, string type)
        {
            return SayUSayMe.DAL.CatalogAdmin.updateUserState(uid,  type);
        }

        //更新模块信息
        public static bool UpdateCatalogData(int catalogID, string postData)
        {
            return SayUSayMe.DAL.CatalogAdmin.UpdateCatalogData(catalogID,postData);
          
        }

        //更新子版块信息
        public static bool UpdateClassData
            (int classID, string className, string classDescription, string classImg, string warning)
        {

            return SayUSayMe.DAL.CatalogAdmin.UpdateClassData
            ( classID,className,classDescription,classImg,warning);
        }

        //添加模块
        public static bool AddCatalog(string catalogName, string indexUrl, string catalogDescription)
        {
            return SayUSayMe.DAL.CatalogAdmin.AddCatalog(catalogName,indexUrl,catalogDescription);
        }

        //添加子版块
        public static int AddClass
            (int catalogID, string className, string classDescription, string classImg, string warning)
        {
            return SayUSayMe.DAL.CatalogAdmin.AddClass
            (catalogID, className, classDescription,classImg,warning);
        }

        //版主查看文章
        public static DataTable BordAdminGetArticle
            (string userName, int pageNumber, int articleState, out int howManyPage)
        {
            return SayUSayMe.DAL.CatalogAdmin.BordAdminGetArticle
                (userName, pageNumber, articleState, out howManyPage);
        }

        //更新文章等级
        public static bool updateArticleGradeByID(int aricleID, int articleGrade)
        {
            return SayUSayMe.DAL.CatalogAdmin.updateArticleGradeByID( aricleID,articleGrade);
        }

        //删除文章
        public static bool SetArticleStateByID(int articleID, string operate)
        {
            return SayUSayMe.DAL.CatalogAdmin.SetArticleStateByID(articleID, operate);
        }

        //标识文章被处理
        public static bool CheckArticleByID(int articleID)
        {
            return SayUSayMe.DAL.CatalogAdmin.CheckArticleByID( articleID);
        }

        //检查用户当前状态
        public static string checkUserState(string name)
        {
            return SayUSayMe.DAL.CatalogAdmin.checkUserState( name);
        }

        public static DataTable GetCatalogMsgByState(string state, int pageNumber, out int howManyPage)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetCatalogMsgByState(state,pageNumber, out  howManyPage);
        }

        //版主查看用户信息
        public static DataTable BordAdminGetUserByID(int userID)
        {
            return SayUSayMe.DAL.CatalogAdmin.BordAdminGetUserByID( userID);
        }

        //判断大小版主板块
        public static string GetPopedomType(string userName)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetPopedomType( userName);

        }

        //判断用户的角色
        public static int GetUserRoleByName(string userName)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetUserRoleByName(userName);

        }

        //根据用户名，返回用户管理的
        public static DataTable GetCatalogByUserName(string userName)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetCatalogByUserName( userName);
        }

        //根据板块ID，返回板块下面的子版块
        public static DataTable GetClassByCatalogID(int catalogID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetClassByCatalogID(catalogID);
        }

        //根据分类ID返回分类的详细信息
        public static DataTable GetClassByID (int classID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetClassByID (classID);
        }

        //得到版块下面的分类
        public static DataTable GetClassSortByID(int classID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetClassSortByID(classID);
        }

        //添加板块下面的分类
        public static bool AddClassSort(int classID, string sortName)
        {
            return SayUSayMe.DAL.CatalogAdmin.AddClassSort(classID,sortName);
        }

        //删除板块下面的分类
        public static bool DeleteClassSort(int sortID)
        {
            return SayUSayMe.DAL.CatalogAdmin.DeleteClassSort(sortID);
        }

        //得到申请的分类
        public static DataTable GetApplyTitle()
        {
            return SayUSayMe.DAL.CatalogAdmin.GetApplyTitle();
        }

        //得到申请的详细内容
        public static DataTable GetApplyDataByTitle(string title, int applyState)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetApplyDataByTitle(title,applyState);
        }

        //得到申请人的详细信息
        public static DataTable GetApplyUserDetails(int userID)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetApplyUserDetails( userID);

        }

        //处理申请
        public static bool UpdateApply(int applyID, string failedText, string type)
        {
            return SayUSayMe.DAL.CatalogAdmin.UpdateApply(applyID, failedText, type);

        }

        //添加用户等级
        public static bool AddUserGrade(int gradeID, int level1, int level2, int level3, int level4, int gradeScore)
        {
            return SayUSayMe.DAL.CatalogAdmin.AddUserGrade( gradeID, level1, level2, level3, level4,gradeScore);
        }

        //获得小板块状态
        public static DataTable GetClassByCatalogIDClassState
            (int catalogID, int pageNumber, out int howManyPage, int classState)
        {
            return SayUSayMe.DAL.CatalogAdmin.GetClassByCatalogIDClassState
                (catalogID, pageNumber, out howManyPage, classState);

        }
    }
    #endregion
}
