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
   public class SendArea:ISendArea
    {
        #region ISendArea ≥…‘±

        public IList<SendAreaInfo> GetSendArea()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<SendAreaInfo> sendAreas = new List<SendAreaInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Area_GetArea");
            while (reader.Read())
            {
                SendAreaInfo item = GetSendAreaByID(reader.GetInt32(reader.GetOrdinal("AreaID")));
                sendAreas.Add(item);
            }
            reader.Close();
            return sendAreas;
        }

       public IList<SendAreaInfo> GetSendArea(int type, int areaID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<SendAreaInfo> sendAreas = new List<SendAreaInfo>();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
           objParams[1] = new SqlParameter("@areaID", SqlDbType.Int, 4);
           objParams[0].Value = type;
           objParams[1].Value = areaID;
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Area_GetArea",objParams);
           while (reader.Read())
           {
               SendAreaInfo item = GetSendAreaByID(reader.GetInt32(reader.GetOrdinal("AreaID")));
               sendAreas.Add(item);
           }
           reader.Close();
           return sendAreas;
       }

       public SendAreaInfo GetSendAreaByID(int sendAreaID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@sendAreaID", SqlDbType.Int, 4);
            objParams[0].Value = sendAreaID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Area_GetAreaByID", objParams);
            SendAreaInfo item = new SendAreaInfo();
            while (reader.Read())
            {
                item.AreaID = reader.GetInt32(reader.GetOrdinal("AreaID"));
                item.Name = reader.GetString(reader.GetOrdinal("Name"));
                item.Code = reader.GetString(reader.GetOrdinal("Code"));
                item.Dec = reader.GetString(reader.GetOrdinal("Dec"));
                item.ParentID = reader.GetInt32(reader.GetOrdinal("ParentID"));
                item.IsSended = reader.GetBoolean(reader.GetOrdinal("IsSended"));
            }
            reader.Close();
            return item;
        }

        public void InsertSendArea(SendAreaInfo send)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[5];
            objParams[0] = new SqlParameter("@Name", send.Name);
            objParams[1] = new SqlParameter("@Code", send.Code);
            objParams[2] = new SqlParameter("@ParentID", send.ParentID);
            objParams[3] = new SqlParameter("@Dec", StringHelper.convertStr(send.Dec));
            objParams[4] = new SqlParameter("@IsSended", send.IsSended);
            objSqlHelper.ExecuteNonQuery("je_Area_InsertArea", objParams);
        }

        public int UpdateSendArea(SendAreaInfo send)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@Name", send.Name);
            objParams[1] = new SqlParameter("@Code", send.Code);
            objParams[2] = new SqlParameter("@ParentID", send.ParentID);
            objParams[3] = new SqlParameter("@Dec", StringHelper.convertStr(send.Dec));
            objParams[4] = new SqlParameter("@IsSended", send.IsSended);
            objParams[5] = new SqlParameter("@AreaID", send.AreaID);
          return objSqlHelper.ExecuteNonQuery("je_Area_UpdateArea", objParams);
        }

        public int DeleteSendArea(int AreaID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@AreaID", AreaID);
           return objSqlHelper.ExecuteNonQuery("je_Area_DeleteArea", objParams);
        }

        #endregion
    }
}
