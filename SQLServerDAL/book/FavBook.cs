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
   public class FavBook:IFavBook
    {

        #region IFavBook ≥…‘±

        public IList<FavBookInfo> GetFavBooks()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<FavBookInfo> fbs = new List<FavBookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userName", SqlDbType.VarChar);
            objParams[0].Value = GetUserName();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_FBook_GetFavBooks", objParams);
            while (reader.Read())
            {
                FavBookInfo item = new FavBookInfo();
                item.FavID = reader.GetInt32(reader.GetOrdinal("favID"));
                item.BookID = reader.GetInt32(reader.GetOrdinal("BookID"));
                item.BookName = reader.GetString(reader.GetOrdinal("BookName"));
                item.BookImage = reader.GetString(reader.GetOrdinal("BookImage"));
                item.BookSmallImage = reader.GetString(reader.GetOrdinal("BookSmallImage"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("bookPrice"));
                item.MemberPrice = reader.GetDecimal(reader.GetOrdinal("bookMemberPrice"));
                fbs.Add(item);
            }
            reader.Close();
            return fbs;
        }

       public void InsertFavBook(int bookID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@bookID", bookID);
            objParams[1] = new SqlParameter("@userName", GetUserName());
            objSqlHelper.ExecuteNonQuery("je_FBook_InsertFavBooks", objParams);
        }

        public int DeleteFavBook(int favID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@favID", favID);
           return objSqlHelper.ExecuteNonQuery("je_FBook_DeleteFavBooks", objParams);
        }

       public int DeleteFavBookByID(int bookID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[1];
           objParams[0] = new SqlParameter("@bookID", bookID);
           return objSqlHelper.ExecuteNonQuery("je_FBook_DeleteFavBooksByID", objParams);
       }

       private static string GetUserName()
       {
           HttpContext context = HttpContext.Current;
           string userName = context.Request.AnonymousID;
           if (context.Request.IsAuthenticated)
               userName = context.User.Identity.Name;
           return userName;
       }

        #endregion
    }
}
