using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;

namespace Server
{
    class DataBaseController
    {
        //"Data Source='BDServer.sdf'"
        static SqlCeConnection sql = new SqlCeConnection("Data Source='BDServer.sdf'");

        public DataBaseController()
        {

        }

        public static string SelectQuery(string Attribute, string Table, string Where = null)
        {
            
            string Result = null;

            if(Where != null) { Where = " WHERE " + Where; }

            SqlCeCommand com = new SqlCeCommand("", sql)
            {
                CommandText = "SELECT " + Attribute + " FROM " + Table + Where + ""
            };

            sql.Open();

            using (SqlCeDataReader DReader = com.ExecuteReader())
            {
                while (DReader.Read())
                {
                    Result += DReader[0].ToString() + ";";
                }
            }

            sql.Close();

            if(Result != null)
            {
                Result = Result.Substring(0, Result.Length - 1);
                return Result;
            }
            else
            {
                throw new SelectQueryException("Result is null");
            }
            
        }

        public static void InsertQuery(string Table, string Attributes, string Condition)
        {
            
            SqlCeCommand com = new SqlCeCommand("", sql) {
                CommandText = "INSERT INTO " + Table + " (" + Attributes + ")" + " VALUES (" + Condition + ");"
            };

            sql.Open();

            com.ExecuteNonQuery();

            sql.Close();
        }

        public static void DeleteQuery(string Attributes, string Table, string Where = null)
        {
            
            if (Where != null) { Where = " WHERE " + Where; }

            SqlCeCommand com = new SqlCeCommand("", sql)
            {
                CommandText = "DELETE " + Attributes + " FROM " + Table + Where
            };

            sql.Open();

            com.ExecuteNonQuery();

            sql.Close();
        }

        public static void UpdateQuery(string Table, string Attributes, string Where = null)
        {
            
            if (Where != null) { Where = " WHERE " + Where; }

            SqlCeCommand com = new SqlCeCommand("", sql)
            {
                CommandText = "UPDATE " + Table + " SET " + Attributes + Where
            };

            sql.Open();

            com.ExecuteNonQuery();

            sql.Close();
        }

        public static string IdDistributor(string Table, string Attribute)
        {
            
            string Result = null;

            SqlCeCommand com = new SqlCeCommand("", sql)
            {
                CommandText = "SELECT MAX(" + Attribute + ") FROM " + Table + ";"
            };

            sql.Open();

            using (SqlCeDataReader DReader = com.ExecuteReader())
            {
                while (DReader.Read())
                {
                    Result += DReader[0].ToString();
                }
            }

            sql.Close();

            return Convert.ToString(Convert.ToInt32(Result) + 1);
        }

    }


    [Serializable]
    public class SelectQueryException: Exception
    {
        public SelectQueryException() { }
        public SelectQueryException(string message) : base(message) { }
        public SelectQueryException(string message, Exception inner) : base(message, inner) { }
        protected SelectQueryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
