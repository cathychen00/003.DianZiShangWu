using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using Jiaen.Components.IDAL;
using Jiaen.Components;
using Jiaen.Components.Utility;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jiaen.SQLServerDAL
{
    /// <summary>
    /// 图书系列操作
    /// </summary>
   public class BookCatena:IBookCatena
    {
        #region IBookCatena 成员

        public IList<BookCatenaInfo> GetCatenas()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<BookCatenaInfo> catenas = new List<BookCatenaInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Ct_GetCatenas");
            while (reader.Read())
            {
                BookCatenaInfo item = new BookCatenaInfo();
                item.CatenaID = reader.GetInt32(reader.GetOrdinal("catenaID"));
                item.CatenaName = reader.GetString(reader.GetOrdinal("catenaName"));
                item.CatenaDec = reader.GetString(reader.GetOrdinal("catenaDec"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
                catenas.Add(item);
            }
            reader.Close();
            return catenas;
        }

       public BookCatenaInfo GetCatenaByID(int catenaID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@catenaID", SqlDbType.Int, 4);
            objParams[0].Value = catenaID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Ct_GetCatenaByID", objParams);
            BookCatenaInfo item = new BookCatenaInfo();
            while (reader.Read())
            {
                item.CatenaID = reader.GetInt32(reader.GetOrdinal("catenaID"));
                item.CatenaName = reader.GetString(reader.GetOrdinal("catenaName"));
                item.CatenaDec = reader.GetString(reader.GetOrdinal("catenaDec"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
            }
            reader.Close();
            return item;
        }

       public void InsertCatena(BookCatenaInfo catena)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@catenaName", StringHelper.convertStr(catena.CatenaName));
            objParams[1] = new SqlParameter("@catenaDec", StringHelper.convertStr(catena.CatenaDec));
            objParams[2] = new SqlParameter("@addDate", DateTime.Now);
            objSqlHelper.ExecuteNonQuery("je_Ct_InsertCatena", objParams);
        }

       public int UpdateCatena(BookCatenaInfo catena)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@catenaName", StringHelper.convertStr(catena.CatenaName));
            objParams[1] = new SqlParameter("@catenaDec", StringHelper.convertStr(catena.CatenaDec));
            objParams[2] = new SqlParameter("@addDate", DateTime.Now);
            objParams[3] = new SqlParameter("@catenaID", catena.CatenaID);
            return objSqlHelper.ExecuteNonQuery("je_Ct_UpdateCatena", objParams);
        }

       public int DeleteCatena(int catenaID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@catenaID", catenaID);
            return objSqlHelper.ExecuteNonQuery("je_Ct_DeleteCatena", objParams);
        }

        #endregion
    }
}
