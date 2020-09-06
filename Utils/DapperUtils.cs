using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Utils
{
    public class DapperUtils
    {
        /// <summary>
        /// DB 連線
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection("Data Source=localhost\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        /// <summary>
        /// 查詢 SQL 資料
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public object Query(String sql, object param = null)
        {
            object rtn = null;

            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    if (param != null)
                    {
                        rtn = conn.Query(sql, param);
                    }
                    else
                    {
                        rtn = conn.Query(sql);
                    }

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Query err: {ex.Message} \r\n");
            }

            return rtn;

        }

        /// <summary>
        /// 查詢 SQL 資料
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T> Query<T>(String sql, object param = null)
        {
            List<T> rtn = new List<T>();

            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    if (param != null)
                    {
                        rtn = conn.Query<T>(sql, param).ToList();
                    }
                    else
                    {
                        rtn = conn.Query<T>(sql).ToList();
                    }

                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Query<T> err: {ex.Message} \r\n");
            }

            return rtn;

        }


        /// <summary>
        /// 執行 SQL 語法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(String sql, object param = null)
        {
            int rtn = 0;

            try
            {
                using (IDbConnection conn = Connection)
                {
                    conn.Open();

                    if (param != null)
                    {
                        rtn = conn.Execute(sql, param);
                    }
                    else
                    {
                        rtn = conn.Execute(sql);
                    }

                    conn.Close();

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Execute err: {ex.Message} \r\n");
            }
            return rtn;

        }
    }
}
