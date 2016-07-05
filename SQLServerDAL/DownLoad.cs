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
   public class DownLoad:IDownLoad
    {
        #region IDownLoad 成员

        public IList<DownLoadInfo> GetDownLoad()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<DownLoadInfo> downLoads = new List<DownLoadInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_DL_GetDownLoad");
            while (reader.Read())
            {
                DownLoadInfo item = GetDownLoadByID(reader.GetInt32(reader.GetOrdinal("DownID")));
                downLoads.Add(item);
            }
            reader.Close();
            return downLoads;
        }

       public IList<DownLoadInfo> GetCBDownLoad()
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<DownLoadInfo> downLoads = new List<DownLoadInfo>();
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_DL_GetCBDownLoad");
           while (reader.Read())
           {
               DownLoadInfo item = GetDownLoadByID(reader.GetInt32(reader.GetOrdinal("DownID")));
               downLoads.Add(item);
           }
           reader.Close();
           return downLoads;
       }

        /// <summary>
        /// 获取分类下载文件列表
        /// </summary>
        /// <returns></returns>
       public IList<DownLoadInfo> GetDownLoadByCat(int catID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[1];
           objParams[0] = new SqlParameter("@catID", SqlDbType.Int, 4);
           objParams[0].Value = catID;
           List<DownLoadInfo> downLoads = new List<DownLoadInfo>();
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_DL_GetDownLoadByCat", objParams);
           while (reader.Read())
           {
               DownLoadInfo item = GetDownLoadByID(reader.GetInt32(reader.GetOrdinal("DownID")));
               downLoads.Add(item);
           }
           reader.Close();
           return downLoads;
       }

        /// <summary>
        /// 获取下载排行
        /// </summary>
        /// <returns></returns>
       public IList<DownLoadInfo> GetTopDownLoad()
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<DownLoadInfo> downLoads = new List<DownLoadInfo>();
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_DL_GetTopDownLoad");
           while (reader.Read())
           {
               DownLoadInfo item = GetDownLoadByID(reader.GetInt32(reader.GetOrdinal("DownID")));
               downLoads.Add(item);
           }
           reader.Close();
           return downLoads;
       }

        public DownLoadInfo GetDownLoadByID(int downLoadID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@downID", SqlDbType.Int, 4);
            objParams[0].Value = downLoadID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_DL_GetDownLoadByID", objParams);
            DownLoadInfo item = new DownLoadInfo();
            while (reader.Read())
            {
                item.ID = reader.GetInt32(reader.GetOrdinal("catID"));
                item.ClassName = reader.GetString(reader.GetOrdinal("catName"));
                item.DownID = reader.GetInt32(reader.GetOrdinal("DownID"));
                item.DownName = reader.GetString(reader.GetOrdinal("DownName"));
                item.Rate = reader.GetInt32(reader.GetOrdinal("Rate"));
                item.Size = reader.GetInt32(reader.GetOrdinal("Size"));
                item.Author = reader.GetString(reader.GetOrdinal("Author"));
                item.Dec = reader.GetString(reader.GetOrdinal("Dec"));
                item.DownURL = reader.GetString(reader.GetOrdinal("DownURL"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("AddDate"));
                item.DownCount = reader.GetInt32(reader.GetOrdinal("DownCount"));
            }
            reader.Close();
            return item;
        }

        public void InsertDownLoad(DownLoadInfo downLoad)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@catID", downLoad.ID);
            objParams[1] = new SqlParameter("@DownName", downLoad.DownName);
            objParams[2] = new SqlParameter("@Rate", downLoad.Rate);
            objParams[3] = new SqlParameter("@Author", downLoad.Author);
            objParams[4] = new SqlParameter("@Size", downLoad.Size);
            objParams[5] = new SqlParameter("@Dec", downLoad.Dec);
            objParams[6] = new SqlParameter("@DownURL", downLoad.DownURL);
            objSqlHelper.ExecuteNonQuery("je_DL_InsertDownLoad", objParams);
        }

        public int UpdateDownLoad(DownLoadInfo downLoad)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[8];
            objParams[0] = new SqlParameter("@catID", downLoad.ID);
            objParams[1] = new SqlParameter("@DownName", downLoad.DownName);
            objParams[2] = new SqlParameter("@Rate", downLoad.Rate);
            objParams[3] = new SqlParameter("@Author", downLoad.Author);
            objParams[4] = new SqlParameter("@Size", downLoad.Size);
            objParams[5] = new SqlParameter("@Dec", downLoad.Dec);
            objParams[6] = new SqlParameter("@DownURL", downLoad.DownURL);
            objParams[7] = new SqlParameter("@DownID", downLoad.DownID);
            return objSqlHelper.ExecuteNonQuery("je_DL_UpdateDownLoad", objParams);
        }

        /// <summary>
        /// 更新数字信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       public int UpdateCount(int type,int ID)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@ID", type);
           objParams[1] = new SqlParameter("@ID", ID);
           return objSqlHelper.ExecuteNonQuery("je_DL_UpdateCount", objParams);
       }

        public int DeleteDownLoad(DownLoadInfo downLoad)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@DownID", downLoad.DownID);
            return objSqlHelper.ExecuteNonQuery("je_DL_DeleteDownLoad", objParams);
        }

        #endregion
    }
}
