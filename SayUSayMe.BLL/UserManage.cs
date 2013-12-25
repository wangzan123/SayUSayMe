using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayUSayMe.DAL;

namespace SayUSayMe.BLL
{
   public class UserManage
    {
       /// <summary>
       /// 根据用户名查找用户ID
       /// </summary>
       /// <returns></returns>
       public static int GetUserID (string userName)
       {
           return UserAccess.GetUserID (userName);
       }
    }
}
