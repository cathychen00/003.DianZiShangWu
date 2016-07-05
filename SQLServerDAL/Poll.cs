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
   public class Poll:IPoll
    {
        #region IPoll ≥…‘±

        public IList<PollInfo> GetPoll()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<PollInfo> pl = new List<PollInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Poll_GetPoll");
            while (reader.Read())
            {
                PollInfo item = GetPollByID(reader.GetInt32(reader.GetOrdinal("PollID")));
                pl.Add(item);
            }
            reader.Close();
            return pl;
        }

       public IList<PollInfo> GetTopPoll(int type)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[1];
           List<PollInfo> pl = new List<PollInfo>();
           objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
           objParams[0].Value = type;
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Poll_GetTopPoll", objParams);
           while (reader.Read())
           {
               PollInfo item = GetPollByID(reader.GetInt32(reader.GetOrdinal("PollID")));
               pl.Add(item);
           }
           reader.Close();
           return pl;
       }

       public PollInfo GetPollByID(int pollID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@pollID", SqlDbType.Int, 4);
            objParams[0].Value = pollID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Poll_GetPollByID", objParams);
            PollInfo item = new PollInfo();
            while (reader.Read())
            {
                item.PollID = reader.GetInt32(reader.GetOrdinal("PollID"));
                item.Title = reader.GetString(reader.GetOrdinal("Title"));
                item.Items = reader.GetString(reader.GetOrdinal("Items"));
                item.InIndex = reader.GetBoolean(reader.GetOrdinal("InIndex"));
                item.IsMultiple = reader.GetBoolean(reader.GetOrdinal("Multiple"));
                item.Num = reader.GetString(reader.GetOrdinal("voteNum"));
                item.CanView = reader.GetBoolean(reader.GetOrdinal("canView"));
            }
            reader.Close();
            return item;
        }

        public void InsertPoll(PollInfo poll)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@Title", poll.Title);
            objParams[1] = new SqlParameter("@Items", poll.Items);
            objParams[2] = new SqlParameter("@voteNum", poll.Num);
            objParams[3] = new SqlParameter("@Multiple", poll.IsMultiple);
            objParams[4] = new SqlParameter("@canView", poll.CanView);
            objParams[5] = new SqlParameter("@inIndex", poll.InIndex);
            objSqlHelper.ExecuteNonQuery("je_Poll_InsertPoll", objParams);
        }

       public int UpdatePoll(PollInfo poll)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@Title", poll.Title);
            objParams[1] = new SqlParameter("@Items", poll.Items);
            objParams[2] = new SqlParameter("@voteNum", poll.Num);
            objParams[3] = new SqlParameter("@Multiple", poll.IsMultiple);
            objParams[4] = new SqlParameter("@canView", poll.CanView);
            objParams[5] = new SqlParameter("@inIndex", poll.InIndex);
            objParams[6] = new SqlParameter("@PollID", poll.PollID);
            return objSqlHelper.ExecuteNonQuery("je_Poll_UpdatePoll", objParams);
        }


       public int UpdatePollNum(PollInfo poll)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@voteNum", poll.Num);
           objParams[1] = new SqlParameter("@PollID", poll.PollID);
           return objSqlHelper.ExecuteNonQuery("je_Poll_UpdatePollNum", objParams);
       }


       public int DeletePoll(int pollID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@pollID", pollID);
            return objSqlHelper.ExecuteNonQuery("je_Poll_DeletePoll", objParams);
        }

        #endregion
    }
}
