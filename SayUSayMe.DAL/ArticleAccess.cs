using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using SayUSayMe.Model;

namespace SayUSayMe.DAL
{
   public class ArticleAccess
    {
       /// <summary>
       /// 获取类别名称
       /// </summary>
       /// <returns></returns>
       public static DataTable getsortName ()
       {
           DbCommand comm = GenericDataAccess.CreateCommandText ();
           string sql = "select sortName from dbo.ClassSort";
           comm.CommandText = sql;
           return  GenericDataAccess.ExecuteSelectCommand(comm);

       }

       /// <summary>
       /// 根据类别名字来获取类别的编号
       /// </summary>
       /// <param name="sortName"></param>
       /// <returns></returns>
       public static int GetclassSort (string sortName)
       {
           DbCommand com = GenericDataAccess.CreateCommandText ();
           string sql = "select classID from dbo.ClassSort where sortName='"+sortName+"'";
           com.CommandText = sql;
           return (int)GenericDataAccess.ExecuteScalar (com);
       }

       /// <summary>
       /// 插入新闻
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int InsertNews (News news)
       {
           DbCommand com = GenericDataAccess.CreateCommandText ();
           string sql =
               "insert into dbo.News(userID,classSort,NewsSubject,NewsContent,addDate,NewsPhoto) values("
               +news.userID+","+news.classSort+",'"+news.NewsSubject+"','"+news.NewsContent+"','"+news.addDate+"','"+news.NewsPhoto+"')";

           com.CommandText = sql;
           return GenericDataAccess.ExecuteNonQuery (com);
       }


       /// <summary>
       /// 获取新闻的ID和主题
       /// </summary>
       /// <returns></returns>
       public static DataTable getNewsIDAndSubject()
       {
           //select NewsID,NewsSubject from dbo.News
           DbCommand com = GenericDataAccess.CreateCommandText ();
           string sql = "select NewsID,NewsSubject from dbo.News";
           com.CommandText = sql;
           return GenericDataAccess.ExecuteSelectCommand (com);
       }

       /// <summary>
       /// 获取一个类别的新闻
       /// </summary>
       /// <param name="sortName"></param>
       /// <returns></returns>
       public static DataTable getNewsBysortName (string sortName)
       {
           DbCommand com = GenericDataAccess.CreateCommandText ();
           string sql = "select NewsID,classSort,NewsSubject,NewsContent,addDate,NewsPhoto from News where classSort=(select classID from dbo.ClassSort where sortName='" + sortName + "')";
           com.CommandText = sql;
           return GenericDataAccess.ExecuteSelectCommand (com);
       }

       /// <summary>
       /// 删除新闻
       /// </summary>
       /// <param name="num"></param>
       /// <returns></returns>
       public static int DeleteNews (int num)
       {
           DbCommand com = GenericDataAccess.CreateCommandText ();
           //string sql = "delete  from dbo.News where addDate IN (select top "+num+" addDate FROM   dbo.News order   by  addDate   desc)";
           string sql = "delete  from dbo.News where NewsID IN (select top "+num+" NewsID FROM   dbo.News)";
           com.CommandText = sql;
           return GenericDataAccess.ExecuteNonQuery (com);
       }
    }
}
