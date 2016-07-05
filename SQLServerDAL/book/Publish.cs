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
    /// 出版社信息操作
    /// </summary>
   public class Publish:IPublish
    {
        #region IPublish 成员

        public IList<PublishInfo> GetPublishs()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<PublishInfo> publishs = new List<PublishInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Pb_GetPublishs");
            while (reader.Read())
            {
                PublishInfo item = GetPublishByID(reader.GetInt32(reader.GetOrdinal("publishID")));
               
                publishs.Add(item);
            }
            reader.Close();
            return publishs;
        }

       public IList<PublishInfo> GetMainPublishs()
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<PublishInfo> publishs = new List<PublishInfo>();
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Pb_GetMainPublishs");
           while (reader.Read())
           {
               PublishInfo item = GetPublishByID(reader.GetInt32(reader.GetOrdinal("publishID")));
               publishs.Add(item);
           }
           reader.Close();
           return publishs;
       }

        public PublishInfo GetPublishByID(int publishID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@publishID", SqlDbType.Int, 4);
            objParams[0].Value = publishID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Pb_GetPublishByID", objParams);
            PublishInfo item = new PublishInfo();
            while (reader.Read())
            {
                item.PublishID = reader.GetInt32(reader.GetOrdinal("publishID"));
                item.PublishName = reader.GetString(reader.GetOrdinal("publishName"));
                item.PublishDec = reader.GetString(reader.GetOrdinal("publishDec"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"));
            }
            reader.Close();
            return item;
        }

       public void InsertPublish(PublishInfo publish)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@publishName", StringHelper.convertStr(publish.PublishName));
            objParams[1] = new SqlParameter("@publishDec", StringHelper.convertStr(publish.PublishDec));
            objParams[2] = new SqlParameter("@IsMain", publish.IsMain);
            objSqlHelper.ExecuteNonQuery("je_Pb_InsertPublish", objParams);
        }

        public int UpdatePublish(PublishInfo publish)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@publishName", StringHelper.convertStr(publish.PublishName));
            objParams[1] = new SqlParameter("@publishDec", StringHelper.convertStr(publish.PublishDec));
            objParams[2] = new SqlParameter("@IsMain", publish.IsMain);
            objParams[3] = new SqlParameter("@publishID", publish.PublishID);
            return objSqlHelper.ExecuteNonQuery("je_Pb_UpdatePublish", objParams);
        }

        public int DeletePublish(int publishID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@publishID", publishID);
            return objSqlHelper.ExecuteNonQuery("je_Pb_DeletePublish", objParams);
        }

        #endregion
    }
}
