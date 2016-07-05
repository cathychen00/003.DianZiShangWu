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
    class GuestBook : IGuestBook
    {
        #region IGuestBook ≥…‘±

        public IList<GuestBookInfo> GetGuestBook(int userID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<GuestBookInfo> gbs = new List<GuestBookInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userID", SqlDbType.Int, 4);
            objParams[0].Value = userID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Gb_GetGuestBook", objParams);
            while (reader.Read())
            {
                GuestBookInfo item = new GuestBookInfo();
                item.GbID = reader.GetInt32(reader.GetOrdinal("gbID"));
                item.Title = reader.GetString(reader.GetOrdinal("gbTitle"));
                item.Content = reader.GetString(reader.GetOrdinal("gbContent"));
                item.UserName = reader.GetString(reader.GetOrdinal("gbUserName"));
                item.Email = reader.GetString(reader.GetOrdinal("gbEmail"));
                item.PostTime = reader.GetDateTime(reader.GetOrdinal("gbAddTime"));
                item.SendUserID = reader.GetInt32(reader.GetOrdinal("sendUserID"));
                gbs.Add(item);
            }
            reader.Close();
            return gbs;
        }

        public GuestBookInfo GetGuestBookByID(int gbID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@gbID", SqlDbType.Int, 4);
            objParams[0].Value = gbID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Gb_GetGuestBookByID", objParams);
            GuestBookInfo item = new GuestBookInfo();
            while (reader.Read())
            {
                item.GbID = reader.GetInt32(reader.GetOrdinal("gbID"));
                item.Title = reader.GetString(reader.GetOrdinal("gbTitle"));
                item.Content = reader.GetString(reader.GetOrdinal("gbContent"));
                item.UserName = reader.GetString(reader.GetOrdinal("gbUserName"));
                item.Email = reader.GetString(reader.GetOrdinal("gbEmail"));
                item.PostTime = reader.GetDateTime(reader.GetOrdinal("gbAddTime"));
            }
            reader.Close();
            return item;
        }

        public void InsertGuestBook(GuestBookInfo g)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@gbTitle", g.Title);
            objParams[1] = new SqlParameter("@gbContent", g.Content);
            objParams[2] = new SqlParameter("@gbUserName", g.UserName);
            objParams[3] = new SqlParameter("@gbEmail", g.Email);
            objParams[4] = new SqlParameter("@gbAddTime", g.PostTime);
            objParams[5] = new SqlParameter("@userID", g.UserID);
            objSqlHelper.ExecuteNonQuery("je_Gb_InsertGuestBook", objParams);
        }

        public int DeleteGuestBookByID(int gbID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@gbID", gbID);
            return objSqlHelper.ExecuteNonQuery("je_Gb_DeleteGuestBookByID", objParams);
        }

        #endregion
    }
}
