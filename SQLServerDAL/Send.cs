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
   public class Send:ISend
    {
        #region ISend ≥…‘±

        public IList<SendInfo> GetSend()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<SendInfo> sends = new List<SendInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Send_GetSend");
            while (reader.Read())
            {
                SendInfo item = new SendInfo();
                item.SendID = reader.GetInt32(reader.GetOrdinal("sendID"));
                item.Name = reader.GetString(reader.GetOrdinal("Name"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                item.Dec = reader.GetString(reader.GetOrdinal("Dec"));
                sends.Add(item);
            }
            reader.Close();
            return sends;
        }

        public SendInfo GetSendByID(int sendID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@sendID", SqlDbType.Int, 4);
            objParams[0].Value = sendID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Send_GetSendByID", objParams);
            SendInfo item = new SendInfo();
            while (reader.Read())
            {
                item.SendID = reader.GetInt32(reader.GetOrdinal("sendID"));
                item.Name = reader.GetString(reader.GetOrdinal("Name"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                item.Dec = reader.GetString(reader.GetOrdinal("Dec"));
            }
            reader.Close();
            return item;
        }

        public void InsertSend(SendInfo send)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@Name", send.Name);
            objParams[1] = new SqlParameter("@Price", send.Price);
            objParams[2] = new SqlParameter("@Dec", StringHelper.convertStr(send.Dec));
            objSqlHelper.ExecuteNonQuery("je_Send_InsertSend", objParams);
        }

        public int UpdateSend(SendInfo send)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@Name", send.Name);
            objParams[1] = new SqlParameter("@Price", send.Price);
            objParams[2] = new SqlParameter("@Dec", StringHelper.convertStr(send.Dec));
            objParams[3] = new SqlParameter("@sendID", send.SendID);
           return objSqlHelper.ExecuteNonQuery("je_Send_UpdateSend", objParams);
        }

        public int DeleteSend(int SendID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@sendID", SendID);
            return objSqlHelper.ExecuteNonQuery("je_Send_DeleteSend", objParams);
        }

        #endregion
    }
}
