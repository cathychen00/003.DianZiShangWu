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
   public class Review:IReview
    {
        #region IReview 成员

       public IList<ReviewInfo> GetReview(ReviewType rt, int ID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<ReviewInfo> reviews = new List<ReviewInfo>();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@reviewType", SqlDbType.Int, 4);
           objParams[1] = new SqlParameter("@ID", SqlDbType.Int, 4);
           objParams[0].Value = (int)rt;
           objParams[1].Value = ID;
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Reviews_GetReview", objParams);
           while (reader.Read())
           {
               ReviewInfo item = new ReviewInfo();
               item.ReviewID = reader.GetInt32(reader.GetOrdinal("ReviewID"));
               item.BookID = reader.GetInt32(reader.GetOrdinal("bookID"));
               item.PostIP = reader.GetString(reader.GetOrdinal("postIP"));
               item.PostTime = reader.GetDateTime(reader.GetOrdinal("postTime"));
               item.RateID = reader.GetInt32(reader.GetOrdinal("rate"));
               item.UserName = reader.GetString(reader.GetOrdinal("userName"));
               item.StatusID = reader.GetInt32(reader.GetOrdinal("status"));
               item.Content = reader.GetString(reader.GetOrdinal("content"));
               reviews.Add(item);
           }
           reader.Close();

           return reviews;
       }

        public ReviewInfo GetReviewByID(int reviewID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@reviewID", SqlDbType.Int, 4);
            objParams[0].Value = reviewID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Reviews_GetReviewByID", objParams);
            ReviewInfo item = new ReviewInfo();
            while (reader.Read())
            {
                item.ReviewID = reader.GetInt32(reader.GetOrdinal("ReviewID"));
                item.UserName = reader.GetString(reader.GetOrdinal("userName"));
                item.BookID = reader.GetInt32(reader.GetOrdinal("bookID"));
                item.PostIP = reader.GetString(reader.GetOrdinal("postIP"));
                item.PostTime = reader.GetDateTime(reader.GetOrdinal("postTime"));
                item.RateID = reader.GetInt32(reader.GetOrdinal("rate"));
                item.StatusID = reader.GetInt32(reader.GetOrdinal("status"));
                item.Content = reader.GetString(reader.GetOrdinal("content"));
            }
            reader.Close();
            return item;
        }

        public void InsertReview(ReviewInfo r)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@userName", r.UserName);
            objParams[1] = new SqlParameter("@BookID", r.BookID);
            objParams[2] = new SqlParameter("@PostIP", r.PostIP);
            objParams[3] = new SqlParameter("@StatusID", r.StatusID);
            objParams[4] = new SqlParameter("@RateID", r.RateID);
            objParams[5] = new SqlParameter("@Content", r.Content);
            objParams[6] = new SqlParameter("@IsAuthenticated", r.IsAuthenticated);
            objSqlHelper.ExecuteNonQuery("je_Reviews_InsertReview", objParams);
        }

        public int UpdateReview(ReviewInfo r)
        {
            throw new Exception("The method or operation is not implemented.");
        }

       public int DeleteReview(int reviewID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@reviewID", reviewID);
            return objSqlHelper.ExecuteNonQuery("je_Reviews_DeleteReview", objParams);
        }

        #endregion

        #region IReview 成员


        public IList<ReviewInfo> GetUserReview(ReviewType rt, string userName)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<ReviewInfo> reviews = new List<ReviewInfo>();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@reviewType", SqlDbType.Int, 4);
            objParams[1] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            objParams[0].Value = (int)rt;
            objParams[1].Value = userName;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Reviews_GetReview", objParams);

            while (reader.Read())
            {
                ReviewInfo item = new ReviewInfo();
                item.ReviewID = reader.GetInt32(reader.GetOrdinal("ReviewID"));
                item.UserID = reader.GetInt32(reader.GetOrdinal("userName"));
                item.BookID = reader.GetInt32(reader.GetOrdinal("bookID"));
                item.PostIP = reader.GetString(reader.GetOrdinal("postIP"));
                item.PostTime = reader.GetDateTime(reader.GetOrdinal("postTime"));
                item.RateID = reader.GetInt32(reader.GetOrdinal("rate"));
                item.StatusID = reader.GetInt32(reader.GetOrdinal("status"));
                item.Content = reader.GetString(reader.GetOrdinal("content"));
                reviews.Add(item);
            }
            reader.Close();

            return reviews;
        }

        #endregion
    }
}
