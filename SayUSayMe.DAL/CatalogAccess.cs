using System;
using System.Data;
using System.Data.Common;


namespace SayUSayMe.DAL
{
    #region 
 /// <summary>
    ///主要对数据库的查询操作代码
    /// </summary>
    public  class CatalogAccess
    {
        static CatalogAccess ()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }




        /// <summary>
        /// 得到分类信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleCatalog ()
        {
            //创建一个数据库无关的数据库操作命令
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetArticleCatalog";

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        /// <summary>
        /// 根据用户名得到用户可以发言的分类
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public static DataTable GetArticleClassByUserName (string userName)
        {
            //创建命令
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetArticleClassByUserName";

            //新建命令参数
            DbParameter parm = comm.CreateParameter ();
            //参数设置
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        /// <summary>
        /// 得到分类ID下面的子类
        /// </summary>
        /// <param name="catalogID"></param>
        /// <returns></returns>
        public static DataTable GetArticleClassByCatalogID (string catalogID)
        {
            //创建命令
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetArticleClassByCatalogID";

            //新建命令参数
            DbParameter parm = comm.CreateParameter ();
            //参数设置
            parm.ParameterName = "@catalogID";
            parm.DbType = DbType.Int32;
            parm.Value = catalogID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到新闻图片
        public static DataTable GetNewsImg ()
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetNewsImg";

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        public static bool InsertImg (string imgPath, string imgDescription)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "InsertImg";
            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@imgPath";
            parm.DbType = DbType.String;
            parm.Value = imgPath;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@imgDescription";
            parm.DbType = DbType.String;
            parm.Value = imgDescription;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@addTime";
            parm.DbType = DbType.DateTime;
            parm.Value = DateTime.Now;
            comm.Parameters.Add (parm);
            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //显示最新的日志
        public static DataTable GetNewArticle ()
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetNewArticle";
            comm.CommandType = CommandType.StoredProcedure;

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //显示最新的回复
        public static DataTable GetNewArticleComment ()
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetNewArticleComment";

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //通过文章id获取标题
        public static DataTable GetArticleSubjectByID (int articleID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            DbParameter parm;
            comm.CommandText = "GetArticleSubjectByID";

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = articleID;
            //把变量添加到命令中
            comm.Parameters.Add (parm);
            return GenericDataAccess.ExecuteSelectCommand (comm);

        }

        //通过评论id获取评论人名称
        public static DataTable GetUserMessageByCommentID (int CommentID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            DbParameter parm;
            comm.CommandText = "GetUserMessageByCommentID";

            parm = comm.CreateParameter ();
            parm.ParameterName = "@CommentID";
            parm.DbType = DbType.Int32;
            parm.Value = CommentID;
            //把变量添加到命令中
            comm.Parameters.Add (parm);
            return GenericDataAccess.ExecuteSelectCommand (comm);

        }

        //通过分类ID查询所有的文章
        public static DataTable GetArticleByClassID (int classID, int pageNumber, out int howManyPage)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            DbParameter parm;
            comm.CommandText = "GetArticleByClassID";

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            //把变量添加到命令中
            comm.Parameters.Add (parm);

            //每页显示多少条记录
            parm = comm.CreateParameter ();
            parm.ParameterName = "@articlePerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.ArticlePerPage;
            comm.Parameters.Add (parm);

            //页码
            parm = comm.CreateParameter ();
            parm.ParameterName = "@pageNumber";
            parm.DbType = DbType.Int32;
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            //返回的总记录数
            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyArticle";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output; //注意输出参数
            comm.Parameters.Add (parm);

            DataTable data;

            data = GenericDataAccess.ExecuteSelectCommand (comm);
            //先执行查询数据库，在得到返回值
            int howManyArticle = Int32.Parse (comm.Parameters ["@howManyArticle"].Value.ToString ());
            //返回最小整数 ceiling()向上舍入
            howManyPage = (int) Math.Ceiling ((double) howManyArticle/(double) GetConfigurationSettings.ArticlePerPage);

            return data;
        }

        //通过文章ID选择用户详细信息
        public static DataTable GetUserDetailsByArticleID (string articleID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetUserDetailsByArticleID";
            DbParameter parm = comm.CreateParameter ();
            parm.Value = Int32.Parse (articleID);
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //通过文章ID获取文章的内容
        public static DataTable GetArticleContentByID (string articleID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            comm.CommandText = "GetArticleContentByID";
            DbParameter parm = comm.CreateParameter ();
            parm.Value = Int32.Parse (articleID);
            try
            {
                parm.DbType = DbType.Int32;
            }
            catch (Exception ed)
            {
                throw ed;
            }
            parm.ParameterName = "@articleID";
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //通过回复id获得回复的信息
        public static DataTable GetCommentByCommendID (string commentID)
        {
            DbCommand com = GenericDataAccess.CreateCommand ();
            com.CommandText = "GetCommentByCommendID";
            DbParameter parm = com.CreateParameter ();
            parm.Value = Int32.Parse (commentID);
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@commentID";
            com.Parameters.Add (parm);
            return GenericDataAccess.ExecuteSelectCommand (com);
        }

        //更新回复贴
        public static int UpdateComment (string speakConent, string commentID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateComment";
            DbParameter parm;

            //评论内容
            parm = comm.CreateParameter ();
            parm.ParameterName = "@SpeakContent";
            parm.DbType = DbType.String;
            parm.Value = speakConent;
            comm.Parameters.Add (parm);
            //评论id
            parm = comm.CreateParameter ();
            parm.ParameterName = "@CommentID";
            parm.DbType = DbType.Int32;
            parm.Value = Int32.Parse (commentID);
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteNonQuery (comm);

        }

        //通过文章ID查询文章的回复（评论）
        public static DataTable GetArticleTallByID (int articleID, int pageNumber, out int howManyPage)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetArticleTallByID";
            DbParameter parm;

            //文章ID
            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = articleID;
            comm.Parameters.Add (parm);

            //页码
            parm = comm.CreateParameter ();
            parm.ParameterName = "@pageNumber";
            parm.DbType = DbType.Int32;
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            //每页显示多少条记录
            parm = comm.CreateParameter ();
            parm.ParameterName = "@replyPerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.ReplyPerPage;
            comm.Parameters.Add (parm);

            //返回总记录数
            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyReply";
            parm.Direction = ParameterDirection.Output;
            parm.DbType = DbType.Int32;
            comm.Parameters.Add (parm);

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            int howManyReply = Int32.Parse (comm.Parameters ["@howManyReply"].Value.ToString ());
            howManyPage = (int) Math.Ceiling ((double) howManyReply/(double) GetConfigurationSettings.ReplyPerPage);
            return data;
        }

        //通过文章门类ID查询该类的所有文章
        //实现分页功能
        public static DataTable GetArticleByCatalogID (int catalogID, int pageNumber, out int howManyPage)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetArticleByCatalogID";
            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.ParameterName = "@catalogID";
            parm.DbType = DbType.Int32;
            parm.Value = catalogID;

            comm.Parameters.Add (parm);

            //pageNumber
            parm = comm.CreateParameter ();
            parm.ParameterName = "@pageNumber";
            parm.DbType = DbType.Int32;
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            //articlePerPage
            parm = comm.CreateParameter ();
            parm.ParameterName = "@articlePerPage";
            parm.Value = GetConfigurationSettings.ArticlePerPage;
            comm.Parameters.Add (parm);

            //howManyArticle
            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyArticle";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output;
            comm.Parameters.Add (parm);
            DataTable data;

            data = GenericDataAccess.ExecuteSelectCommand (comm);
            int howManyArticle = Int32.Parse (comm.Parameters ["@howManyArticle"].Value.ToString ());

            howManyPage = (int) Math.Ceiling ((double) howManyArticle/(double) GetConfigurationSettings.ArticlePerPage);
            return data;
        }

        //发表文章(没有添加附件)
        public static int AddArticle
            (string userName, int classSortID, int classID, string articleSubject, string articleContent)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddArticle";
            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleSubject";
            parm.DbType = DbType.String;
            parm.Value = articleSubject;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleContent";
            parm.DbType = DbType.AnsiString;
            parm.Value = articleContent;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classSortID";
            parm.DbType = DbType.Int32;
            parm.Value = classSortID;
            comm.Parameters.Add (parm);

            int articleID = -1;
            try
            {
                if (comm.Connection.State != ConnectionState.Open)
                    comm.Connection.Open ();
                articleID = Int32.Parse (GenericDataAccess.ExecuteScalar (comm).ToString ());
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                comm.Connection.Close ();
                comm.Connection.Dispose ();
                comm.Dispose ();
            }
            return articleID;
        }


        //更新文章内容等等（不包括附件）
        public static bool UpdateArticle
            (int articleID, int classSortID, int classID, string articleSubject, string articleContent)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateArticle";
            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = articleID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleSubject";
            parm.DbType = DbType.String;
            parm.Value = articleSubject;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@articleContent";
            parm.DbType = DbType.AnsiString;
            parm.Value = articleContent;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classSortID";
            parm.DbType = DbType.Int32;
            parm.Value = classSortID;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            return false;
        }


        //插入回复留言（不带附件）
        public static int AddArticleComment
            (int articleID, string userName, string speakContent, int replyType, string useReplyConetent)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddArticeComment";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = articleID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.AnsiString;
            parm.ParameterName = "@speakContent";
            parm.Value = speakContent;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@replyType";
            parm.Value = replyType;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.AnsiString;
            parm.ParameterName = "@useReplyContent";
            parm.Value = useReplyConetent;
            comm.Parameters.Add (parm);

            int articleCommentID;
            try
            {
                if (comm.Connection.State != ConnectionState.Open)
                    comm.Connection.Open ();
                articleCommentID = Int32.Parse (comm.ExecuteScalar ().ToString ());
            }
            catch (Exception)
            {
                return -1;
                //throw;
            }
            finally
            {
                comm.Connection.Close ();
                comm.Connection.Dispose ();
                comm.Dispose ();
            }
            return articleCommentID;

        }

        //添加附件
        public static int Addfile
            (
            System.Web.HttpPostedFile oPostedFile, string fileSaveName, string fileUrl, string fileDescription,
            int commentId, int articleId)
        {
            string fileName = "";
            string saveUrl = "";
            //获取附件名称
            fileName = oPostedFile.FileName.Substring (oPostedFile.FileName.LastIndexOf ("\\") + 1);
            //获取保存的路径
            saveUrl = fileUrl + fileName;


            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddFile";
            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@fileSaveName";
            parm.DbType = DbType.String;
            parm.Value = fileSaveName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@fileUrl";
            parm.Value = saveUrl;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@fileDescription";
            parm.Value = fileDescription;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@commentId";
            parm.Value = commentId;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@articleId";
            parm.Value = articleId;
            comm.Parameters.Add (parm);
            int flag = -1;
            try
            {
                //保存到硬盘上

                oPostedFile.SaveAs (System.Web.HttpContext.Current.Server.MapPath (saveUrl));

                if (comm.Connection.State != ConnectionState.Open)
                    comm.Connection.Open ();
                flag = GenericDataAccess.ExecuteNonQuery (comm);
            }
            catch (Exception e)
            {
                throw e;
                //return -1;
            }
            finally
            {
                comm.Connection.Close ();
                comm.Connection.Dispose ();
                comm.Dispose ();
            }
            return flag;
        }

        //得到资源共享区的所有分类
        public static DataTable GetFieldCatalogByClassID (int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetFieldCatalogByClassID";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@classID";
            parm.Value = classID;

            comm.Parameters.Add (parm);
            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到领域中所有内容的分类
        public static DataTable GetCodeFileCatalog (int catalogID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetCodeFileCatalogByCatalogID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@catalogID";
            parm.DbType = DbType.Int32;
            parm.Value = catalogID;

            comm.Parameters.Add (parm);
            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到领域中所有文件的详细信息
        public static DataTable GetFileInfoByFieldID (int fieldID, int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@fieldID";
            parm.DbType = DbType.Int32;
            parm.Value = fieldID;

            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;

            comm.Parameters.Add (parm);

            comm.CommandText = "GetFileInfoByFieldID";

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到领域中,某内容分类的所有文件的详细信息
        public static DataTable GetFileInfoByFieldIDContentID (int fieldID, int contentID, int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@fieldID";
            parm.DbType = DbType.Int32;
            parm.Value = fieldID;

            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@contentID";
            parm.DbType = DbType.Int32;
            parm.Value = contentID;

            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;

            comm.Parameters.Add (parm);
            comm.CommandText = "GetFileInfoByFieldIDContentID";

            return GenericDataAccess.ExecuteSelectCommand (comm);

        }

        //得到下载文件的下载信息
        public static DataTable GetFileDownInfo (int fileID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetFileDownInfo";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@fileID";
            parm.Value = fileID;

            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到当天发表的日志数
        public static int GetTodayArticleByClassID (int classid)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetTodayArticleByClassID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classid;

            comm.Parameters.Add (parm);

            if (comm.Connection.State != ConnectionState.Open)
                comm.Connection.Open ();
            try
            {
                return Int32.Parse (comm.ExecuteScalar ().ToString ());
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                comm.Connection.Close ();
                comm.Connection.Dispose ();
            }
        }

        //得到某主题下最新的文章
        public static DataTable GetLastestArticleByClassID (int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetLastestArticleByClassID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;

            comm.Parameters.Add (parm);
            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到某文章最新的回复
        public static DataTable GetLastestReplyByArticleID (int articleID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetLastestReplyByArticleID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@articleID";
            parm.DbType = DbType.Int32;
            parm.Value = articleID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //得到某分类下面的版块公告  
        public static DataTable GetWarningByClassID (int classID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetWarningByClassID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@classID";
            parm.DbType = DbType.Int32;
            parm.Value = classID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //根据用户名查询某个用户名是否已经被注册
        public static bool GetUserByUserName (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetUserByUserName";

            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.String;
            parm.ParameterName = "@userName";
            parm.Value = userName;
            comm.Parameters.Add (parm);

            if (comm.Connection.State != ConnectionState.Open)
                comm.Connection.Open ();
            DbDataReader read = comm.ExecuteReader ();
            if (read.HasRows)
                return true;
            else
                return false;
        }

        //登陆
        public static int GetRecordByNamePw (string name, string pw)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetRecordByNamePw";

            DbParameter parm;
            parm = comm.CreateParameter ();
            parm.ParameterName = "@name";
            parm.DbType = DbType.String;
            parm.Value = name.Trim ();
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@pw";
            parm.DbType = DbType.String;
            parm.Value = pw.Trim ();
            comm.Parameters.Add (parm);

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            if (data.Rows.Count > 0)
            {
                if (Int32.Parse (data.Rows [0] ["userState"].ToString ()) == 1)
                    return 1;
                else if (Int32.Parse (data.Rows [0] ["userState"].ToString ()) == 0)
                    return 0;
                else
                    return -1;
            }
            else
            {
                return -2;
            }
        }

        //根据附件ID查询附件信息
        public static DataTable GetArticleFileByID (int ID, string type)
        {
            int CID = -1;
            int AID = -1;

            if (type.Equals ("Reply"))
            {
                CID = ID;
            }
            else if (type.Equals ("Article"))
            {
                AID = ID;
            }
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetArticleFileByID";
            DbParameter parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@AID";
            parm.Value = AID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.DbType = DbType.Int32;
            parm.ParameterName = "@CID";
            parm.Value = CID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //查询用户的详细信息
        public static DataTable GetUserDetailsByName (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetUserDetailsByName";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);

        }

        //返回用户的最新消息，被回复了多少条信息
        public static DataTable GetNewMessagesByUserName (string userName, bool worked)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetNewMessagesByUserName";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@worked";
            parm.DbType = DbType.Boolean;
            parm.Value = worked;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //把用户信息表示为已经处理
        public static int UpdateWorkedByID (int commentID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateWorkedByID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@commentID";
            parm.DbType = DbType.Int32;
            parm.Value = commentID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteNonQuery (comm);
        }

        //更新用户的详细信息
        public static bool UpdateUserDetails (string postData, string name)
        {
            string userShowName = "";
            string userPassword = "";
            string PwProblem = "";
            string PwAnswer = "";
            string headPhoto = "";
            string userSex = "";
            string userMajor = "";
            string userAddress = "";
            string userMoblie = "";
            string userMaxim = "";

            string[] postParms = postData.Split ('&');
            string[] parmValue;
            for (int i = 0; i < postParms.Length; i++)
            {
                parmValue = postParms [i].Split ('=');
                switch (parmValue [0])
                {
                    case "userShowName":
                        userShowName = parmValue [1].Trim ();
                        break;
                    case "userPassword":
                        userPassword = parmValue [1].Trim ();
                        break;
                    case "PwProblem":
                        PwProblem = parmValue [1].Trim ();
                        break;
                    case "PwAnswer":
                        PwAnswer = parmValue [1].Trim ();
                        break;
                    case "headPhoto":
                        headPhoto = parmValue [1].Trim ();
                        break;
                    case "boy":
                        userSex = "男";
                        break;
                    case "girl":
                        userSex = "女";
                        break;
                    case "userMajor":
                        userMajor = parmValue [1].Trim ();
                        break;
                    case "userAddress":
                        userAddress = parmValue [1].Trim ();
                        break;
                    case "userMoblie":
                        userMoblie = parmValue [1].Trim ();
                        break;
                    case "userMaxim":
                        userMaxim = parmValue [1].Trim ();
                        break;
                    default:
                        break;
                }
            }

            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "UpdateUserDetails";

            DbParameter parm;
            parm = comm.CreateParameter ();
            parm.ParameterName = "@userShowName";
            parm.DbType = DbType.String;
            parm.Size = 60;
            parm.Value = userShowName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userPassword";
            parm.DbType = DbType.String;
            parm.Size = 40;
            parm.Value = userPassword;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@PwProblem";
            parm.DbType = DbType.String;
            parm.Size = 50;
            parm.Value = PwProblem;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@PwAnswer";
            parm.DbType = DbType.String;
            parm.Size = 20;
            parm.Value = PwAnswer;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@headPhoto";
            parm.DbType = DbType.String;
            parm.Size = 30;
            parm.Value = headPhoto;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userSex";
            parm.DbType = DbType.String;
            parm.Size = 2;
            parm.Value = userSex;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userMajor";
            parm.DbType = DbType.String;
            parm.Size = 60;
            parm.Value = userMajor;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userAddress";
            parm.DbType = DbType.String;
            parm.Size = 60;
            parm.Value = userAddress;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Size = 20;
            parm.Value = name;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userMoblie";
            parm.DbType = DbType.String;
            parm.Value = userMoblie;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userMaxim";
            parm.DbType = DbType.String;
            parm.Value = userMaxim;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;
        }

        //得到用户的详细信息
        public static DataTable GetAllUserDetails (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetAllUserDetails";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Size = 20;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //用户注册
        public static bool InsertUser (string userName, string userPassword, int popedom)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "InsertUser";
            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userPassword";
            parm.DbType = DbType.String;
            parm.Value = userPassword;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@popedom";
            parm.DbType = DbType.Int32;
            parm.Value = popedom;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            else
                return false;

        }

        //得到版主
        public static DataTable GetBordAdminByID (int id, string type)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            DbParameter parm = comm.CreateParameter ();
            switch (type)
            {
                case "catalog":
                    comm.CommandText = "GetCatalogAdminByID";
                    parm.ParameterName = "@catalogID";
                    break;
                case "class":
                    comm.CommandText = "GetClassAdminByID";
                    parm.ParameterName = "@classID";
                    break;
                default:
                    break;
            }
            parm.DbType = DbType.Int32;
            parm.Value = id;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);

        }

        //得到版块的分类
        public static object GetSortNameByID (int sortID)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetSortNameByID";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@sortID";
            parm.DbType = DbType.Int32;
            parm.Value = sortID;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteScalar (comm);
        }

        //用户添加申请
        public static bool AddApplyData
            (
            string applyTitle, string userName, string applyText, int applyState, int applyOriginID, int popedom,
            string popedomType)
        {
            if (popedomType == "catalogid") popedomType = "B";
            else if (popedomType == "classid") popedomType = "C";
            else return false;
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "AddApplyData";

            DbParameter parm;

            parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyTitle";
            parm.DbType = DbType.String;
            parm.Value = applyTitle;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyText";
            parm.DbType = DbType.String;
            parm.Value = applyText;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyState";
            parm.DbType = DbType.Int32;
            parm.Value = applyState;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@applyOriginID";
            parm.DbType = DbType.Int32;
            parm.Value = applyOriginID;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@popedom";
            parm.DbType = DbType.Int32;
            parm.Value = popedom;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@popedomType";
            parm.DbType = DbType.String;
            parm.Value = popedomType;
            comm.Parameters.Add (parm);

            if (GenericDataAccess.ExecuteNonQuery (comm) > 0)
                return true;
            return false;

        }

        //根据用户名查询用户所发表的所有的文章
        public static DataTable GetArticleByUserName (string userName)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "GetArticleByUserName";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@userName";
            parm.DbType = DbType.String;
            parm.Value = userName;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //自动得到输入提示
        public static DataTable SelectAutoCompleteData (string txt, int contentLength, int count)
        {
            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "SelectAutoCompleteData";

            DbParameter parm = comm.CreateParameter ();
            parm.ParameterName = "@inputData";
            parm.DbType = DbType.String;
            parm.Value = txt;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@contentLength";
            parm.DbType = DbType.Int32;
            parm.Value = contentLength;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@record";
            parm.Value = count;
            parm.DbType = DbType.Int32;
            comm.Parameters.Add (parm);

            return GenericDataAccess.ExecuteSelectCommand (comm);
        }

        //显示查询内容
        public static DataTable SelectResultData (string inputTxt, int pageNumber, out int howManyPage, string allwords)
        {

            DbCommand comm = GenericDataAccess.CreateCommand ();
            comm.CommandText = "SelectResultData";

            DbParameter parm = comm.CreateParameter ();
            //parm.ParameterName = "@inputData";
            //parm.DbType = DbType.String;
            //parm.Value = inputTxt;
            //comm.Parameters.Add(parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@contentLength";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.SearchContentLength;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@pageNumber";
            parm.DbType = DbType.Int32;
            parm.Value = pageNumber;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@recordPerPage";
            parm.DbType = DbType.Int32;
            parm.Value = GetConfigurationSettings.SearchPerPageRecord;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@howManyRecord";
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.Output;
            comm.Parameters.Add (parm);

            parm = comm.CreateParameter ();
            parm.ParameterName = "@AllWords";
            parm.DbType = DbType.Boolean;
            parm.Value = allwords.ToUpper () == "TRUE" ? "True" : "False";
            comm.Parameters.Add (parm);

            int howmanywords = 5;
            char[] wordSeparaors = new char[] {',', '.', ' ', ';', '!', '-'};
            string[] words = inputTxt.Split (wordSeparaors, StringSplitOptions.RemoveEmptyEntries);
            int index = 1;
            for (int i = 0; i <= words.GetUpperBound (0) && index <= howmanywords; i++)
            {
                parm = comm.CreateParameter ();
                parm.ParameterName = "@Word" + index.ToString ();
                parm.DbType = DbType.String;
                parm.Value = words [i];
                comm.Parameters.Add (parm);
                index++;

            }

            DataTable data = GenericDataAccess.ExecuteSelectCommand (comm);
            howManyPage =
                (int)
                    Math.Ceiling
                        (
                            ((double) Convert.ToInt32 (comm.Parameters ["@howManyRecord"].Value))
                            /((double) GetConfigurationSettings.SearchPerPageRecord));

            return data;
        }
    }
 #endregion

}
