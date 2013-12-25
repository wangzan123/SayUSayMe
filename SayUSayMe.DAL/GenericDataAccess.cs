using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;


namespace SayUSayMe.DAL
{
    /// <summary>
    /// 所有底层数据库访问代码
    /// </summary>
    public static class GenericDataAccess
    {
        //无参数构造函数
        static GenericDataAccess()
        { }

        /// <summary>
        /// 创造所有数据库都通用的数据库操作命令
        /// </summary>
        /// <returns>数据库操作命令</returns>
        public static DbCommand CreateCommand()
        {
            //得到配置文件中的数据库连接字符串
            string dbConnectionString = GetConfigurationSettings.DbConnectionString;

            //得到配置文件中的数据库提供程序
            string dbProviderName = GetConfigurationSettings.DbProviderName;

            DbProviderFactory factory = DbProviderFactories.GetFactory(dbProviderName);

            //创建连接
            DbConnection conn = factory.CreateConnection();

            //配置数据库连接属性
            conn.ConnectionString = dbConnectionString;
            DbCommand comm = conn.CreateCommand();
            //设置命令类型
            comm.CommandType = CommandType.StoredProcedure;

            return comm;
        }

        /// <summary>
        /// 创造所有数据库都通用的数据库操作命令
        /// </summary>
        /// <returns>数据库操作命令</returns>
        public static DbCommand CreateCommandText()
        {
            //得到配置文件中的数据库连接字符串
            string dbConnectionString = GetConfigurationSettings.DbConnectionString;

            //得到配置文件中的数据库提供程序
            string dbProviderName = GetConfigurationSettings.DbProviderName;

            DbProviderFactory factory = DbProviderFactories.GetFactory(dbProviderName);

            //创建连接
            DbConnection conn = factory.CreateConnection();

            //配置数据库连接属性
            conn.ConnectionString = dbConnectionString;
            DbCommand comm = conn.CreateCommand();
            //设置命令类型
            comm.CommandType = CommandType.Text;

            return comm;
        }

        /// <summary>
        /// 执行所有的查询命令
        /// </summary>
        /// <param name="command">数据库命令</param>
        /// <returns>datatable型</returns>
        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable table;

            try
            {
                //当没有打开连接就先打开数据库连接
                if (command.Connection.State != ConnectionState.Open)
                    command.Connection.Open();

                DbDataReader read = command.ExecuteReader();
                table = new DataTable();
                //把数据加载到table变量
                table.Load(read);
            }
            catch (Exception e)
            {
                //这里应该添加错误处理程序
                throw e;
            }
            finally
            {
                command.Connection.Close();
            }

            return table;
        }

        /// <summary>
        /// 执行插入，更新等命令
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(DbCommand comm)
        {
            try
            {
                if (comm.Connection.State != ConnectionState.Open)
                    comm.Connection.Open();
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
            }
        }
        /// <summary>
        /// 执行只返回第一行第一列的命令
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public static object ExecuteScalar(DbCommand comm)
        {
            try
            {
                if (comm.Connection.State != ConnectionState.Open)
                    comm.Connection.Open();
                return comm.ExecuteScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
                comm.Dispose();
            }

        }
    }
}
