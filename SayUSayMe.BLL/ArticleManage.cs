using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SayUSayMe.DAL;
using SayUSayMe.Model;

namespace SayUSayMe.BLL
{
   public class ArticleManage
    {

       /// <summary>
       /// 获取类别名称
       /// </summary>
       /// <returns></returns>
       public static DataTable getsortName ()
       {
          return ArticleAccess.getsortName ();
       }


       /// <summary>
       /// 根据类别名字来获取类别的编号
       /// </summary>
       /// <param name="sortName"></param>
       /// <returns></returns>
       public static int GetclassSort (string sortName)
       {
           return ArticleAccess.GetclassSort (sortName);
       }


       /// <summary>
       /// 插入新闻
       /// </summary>
       /// <param name="news"></param>
       /// <returns></returns>
       public static int InsertNews (News news)
       {
           return ArticleAccess.InsertNews (news);
       }


       /// <summary>
       /// 获取新闻的ID和主题
       /// </summary>
       /// <returns></returns>
       public static DataTable getNewsIDAndSubject ()
       {
           return ArticleAccess.getNewsIDAndSubject ();
       }


       /// <summary>
       /// 获取一个类别的新闻
       /// </summary>
       /// <param name="sortName"></param>
       /// <returns></returns>
       public static DataTable getNewsBysortName (string sortName)
       {
           return ArticleAccess.getNewsBysortName (sortName);
       }

       /// <summary>
       /// 删除新闻
       /// </summary>
       /// <param name="num"></param>
       /// <returns></returns>
       public static int DeleteNews (int num)
       {
           return ArticleAccess.DeleteNews (num);
       }
    }
}
