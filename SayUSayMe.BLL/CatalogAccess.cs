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
    ///主要对数据库的查询操作代码
    /// </summary>
    public static class CatalogAccess
    {
        static CatalogAccess()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 得到分类信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleCatalog()
        {
            //创建一个数据库无关的数据库操作命令

            return SayUSayMe.DAL.CatalogAccess.GetArticleCatalog ();
        }

        /// <summary>
        /// 根据用户名得到用户可以发言的分类
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public static DataTable GetArticleClassByUserName(string userName)
        {

            return SayUSayMe.DAL.CatalogAccess.GetArticleClassByUserName (userName);
        }

        /// <summary>
        /// 得到分类ID下面的子类
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public static DataTable GetArticleClassByCatalogID(string catalogID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleClassByCatalogID (catalogID);
        }

        //得到新闻图片
        public static DataTable GetNewsImg()
        {
            return SayUSayMe.DAL.CatalogAccess.GetNewsImg ();
        }

        public static bool InsertImg(string imgPath, string imgDescription)
        {
            return SayUSayMe.DAL.CatalogAccess.InsertImg (imgPath, imgDescription);
        }

        //显示最新的日志
        public static DataTable GetNewArticle()
        {
            return SayUSayMe.DAL.CatalogAccess.GetNewArticle();
        }

        //显示最新的回复
        public static DataTable GetNewArticleComment()
        {
            return SayUSayMe.DAL.CatalogAccess.GetNewArticleComment();
        }

        //通过文章id获取标题
        public static DataTable GetArticleSubjectByID(int articleID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleSubjectByID(articleID);

        }

        //通过评论id获取评论人名称
        public static DataTable GetUserMessageByCommentID(int CommentID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetUserMessageByCommentID(CommentID);

        }

        //通过分类ID查询所有的文章
        public static DataTable GetArticleByClassID(int classID, int pageNumber, out int howManyPage)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleByClassID(classID,pageNumber,out howManyPage);

        }

        //通过文章ID选择用户详细信息
        public static DataTable GetUserDetailsByArticleID(string articleID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetUserDetailsByArticleID(articleID);
        }

        //通过文章ID获取文章的内容
        public static DataTable GetArticleContentByID(string articleID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleContentByID(articleID);
        }

        //通过回复id获得回复的信息
        public static DataTable GetCommentByCommendID(string commentID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetCommentByCommendID(commentID);
        }

        //更新回复贴
        public static int UpdateComment(string speakConent, string commentID)
        {
            return SayUSayMe.DAL.CatalogAccess.UpdateComment(speakConent, commentID);

        }

        //通过文章ID查询文章的回复（评论）
        public static DataTable GetArticleTallByID(int articleID, int pageNumber, out int howManyPage)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleTallByID(articleID, pageNumber, out howManyPage);
        }

        //通过文章门类ID查询该类的所有文章
        //实现分页功能
        public static DataTable GetArticleByCatalogID(int catalogID, int pageNumber, out int howManyPage)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleByCatalogID(catalogID, pageNumber, out howManyPage);
        }

        //发表文章(没有添加附件)
        public static int AddArticle
            (string userName, int classSortID, int classID, string articleSubject, string articleContent)
        {
            return SayUSayMe.DAL.CatalogAccess.AddArticle
                (userName, classSortID, classID, articleSubject, articleContent);
        }


        //更新文章内容等等（不包括附件）
        public static bool UpdateArticle
            (int articleID, int classSortID, int classID, string articleSubject, string articleContent)
        {
            return SayUSayMe.DAL.CatalogAccess.UpdateArticle
            (articleID, classSortID,classID, articleSubject,articleContent);
        }


        //插入回复留言（不带附件）
        public static int AddArticleComment
            (int articleID, string userName, string speakContent, int replyType, string useReplyConetent)
        {
            return SayUSayMe.DAL.CatalogAccess.AddArticleComment
            (articleID,userName,speakContent, replyType,useReplyConetent);

        }

        //添加附件
        public static int Addfile
            (
            System.Web.HttpPostedFile oPostedFile, string fileSaveName, string fileUrl, string fileDescription,
            int commentId, int articleId)
        {
            return SayUSayMe.DAL.CatalogAccess.Addfile
                (
                    oPostedFile, fileSaveName, fileUrl, fileDescription,
                    commentId, articleId);

        }

        //得到资源共享区的所有分类
        public static DataTable GetFieldCatalogByClassID(int classID)
        {

           return SayUSayMe.DAL.CatalogAccess.GetFieldCatalogByClassID(classID);
        }

        //得到领域中所有内容的分类
        public static DataTable GetCodeFileCatalog(int catalogID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetCodeFileCatalog( catalogID);
        }

        //得到领域中所有文件的详细信息
        public static DataTable GetFileInfoByFieldID(int fieldID, int classID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetFileInfoByFieldID(fieldID,classID);
        }

        //得到领域中,某内容分类的所有文件的详细信息
        public static DataTable GetFileInfoByFieldIDContentID(int fieldID, int contentID, int classID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetFileInfoByFieldIDContentID(fieldID,contentID, classID);

        }

        //得到下载文件的下载信息
        public static DataTable GetFileDownInfo(int fileID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetFileDownInfo(fileID);
        }

        //得到当天发表的日志数
        public static int GetTodayArticleByClassID(int classid)
        {
            return SayUSayMe.DAL.CatalogAccess.GetTodayArticleByClassID(classid);
        }

        //得到某主题下最新的文章
        public static DataTable GetLastestArticleByClassID(int classID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetLastestArticleByClassID(classID);
        }

        //得到某文章最新的回复
        public static DataTable GetLastestReplyByArticleID(int articleID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetLastestReplyByArticleID(articleID);
        }

        //得到某分类下面的版块公告  
        public static DataTable GetWarningByClassID(int classID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetWarningByClassID(classID);
        }

        //根据用户名查询某个用户名是否已经被注册
        public static bool GetUserByUserName(string userName)
        {
            return SayUSayMe.DAL.CatalogAccess.GetUserByUserName(userName);
        }

        //登陆
        public static int GetRecordByNamePw(string name, string pw)
        {
            return SayUSayMe.DAL.CatalogAccess.GetRecordByNamePw(name,pw);
        }

        //根据附件ID查询附件信息
        public static DataTable GetArticleFileByID(int ID, string type)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleFileByID(ID,type);
        }

        //查询用户的详细信息
        public static DataTable GetUserDetailsByName(string userName)
        {
            return SayUSayMe.DAL.CatalogAccess.GetUserDetailsByName( userName);

        }

        //返回用户的最新消息，被回复了多少条信息
        public static DataTable GetNewMessagesByUserName(string userName, bool worked)
        {
            return SayUSayMe.DAL.CatalogAccess.GetNewMessagesByUserName(userName,worked);
        }

        //把用户信息表示为已经处理
        public static int UpdateWorkedByID(int commentID)
        {
            return SayUSayMe.DAL.CatalogAccess.UpdateWorkedByID(commentID);
        }

        //更新用户的详细信息
        public static bool UpdateUserDetails(string postData, string name)
        {

            return SayUSayMe.DAL.CatalogAccess.UpdateUserDetails( postData, name);
           
        }

        //得到用户的详细信息
        public static DataTable GetAllUserDetails(string userName)
        {

            return SayUSayMe.DAL.CatalogAccess.GetAllUserDetails(userName);
        }

        //用户注册
        public static bool InsertUser(string userName, string userPassword, int popedom)
        {

            return SayUSayMe.DAL.CatalogAccess.InsertUser(userName,userPassword,popedom);
        }

        //得到版主
        public static DataTable GetBordAdminByID(int id, string type)
        {

            return SayUSayMe.DAL.CatalogAccess.GetBordAdminByID (id, type);

        }

        //得到版块的分类
        public static object GetSortNameByID(int sortID)
        {
            return SayUSayMe.DAL.CatalogAccess.GetSortNameByID(sortID)
            ;
        }

        //用户添加申请
        public static bool AddApplyData
            (
            string applyTitle, string userName, string applyText, int applyState, int applyOriginID, int popedom,
            string popedomType)
        {
            return SayUSayMe.DAL.CatalogAccess.AddApplyData
                (
                    applyTitle, userName, applyText, applyState, applyOriginID, popedom,
                    popedomType);

        }

        //根据用户名查询用户所发表的所有的文章
        public static DataTable GetArticleByUserName(string userName)
        {
            return SayUSayMe.DAL.CatalogAccess.GetArticleByUserName (userName);
        }

        //自动得到输入提示
        public static DataTable SelectAutoCompleteData(string txt, int contentLength, int count)
        {
            return SayUSayMe.DAL.CatalogAccess.SelectAutoCompleteData(txt, contentLength,count);
        }

        //显示查询内容
        public static DataTable SelectResultData(string inputTxt, int pageNumber, out int howManyPage, string allwords)
        {
            return SayUSayMe.DAL.CatalogAccess.SelectResultData (inputTxt, pageNumber, out howManyPage, allwords);

        }
    }
    #endregion
}
