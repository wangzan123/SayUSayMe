using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SayUSayMe.DAL
{
   public class UserAccess
    {
        /// <summary>
        /// 根据用户名查找用户ID
        /// </summary>
        /// <returns></returns>
        public static int GetUserID(string userName)
        {

            DbCommand comm = GenericDataAccess.CreateCommandText ();
            string sql = "select userID from dbo.WebUsers where userName='" + userName + "'";
            comm.CommandText = sql;
            return (int)GenericDataAccess.ExecuteScalar(comm);
        }

    }
}
