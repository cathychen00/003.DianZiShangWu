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
   
   public class SiteDynamic:ISiteDynamic
    {
        #region ISiteDynamic ≥…‘±

       public IList<SiteDynamicInfo> GetSiteDynamic(SiteDynamicType sdType)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           List<SiteDynamicInfo> dynamics = new List<SiteDynamicInfo>();
           SqlParameter[] objParams = new SqlParameter[1];
           objParams[0] = new SqlParameter("@sdType", SqlDbType.Int, 4);
           objParams[0].Value = (int)sdType;
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Dy_GetSiteDynamic", objParams);

           while (reader.Read())
           {
               SiteDynamicInfo item = new SiteDynamicInfo();
               item.DynamicID = reader.GetInt32(reader.GetOrdinal("dynamicID"));
               item.DynamicTitle = reader.GetString(reader.GetOrdinal("dynamicTitle"));
               item.DynamicContent = reader.GetString(reader.GetOrdinal("dynamicContent"));
               item.DynamicCss = reader.GetString(reader.GetOrdinal("titleCss"));
               item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
               dynamics.Add(item);
           }
           reader.Close();
           return dynamics;
       }

        public SiteDynamicInfo GetSiteDynamicByID(int siteDynamicID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@dynamicID", SqlDbType.Int, 4);
            objParams[0].Value = siteDynamicID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Dy_GetSiteDynamicByID", objParams);
            SiteDynamicInfo item = new SiteDynamicInfo();
            while (reader.Read())
            {
                item.DynamicID = reader.GetInt32(reader.GetOrdinal("dynamicID"));
                item.DynamicTitle = reader.GetString(reader.GetOrdinal("dynamicTitle"));
                item.DynamicContent = reader.GetString(reader.GetOrdinal("dynamicContent"));
                item.ReadCount = reader.GetInt32(reader.GetOrdinal("ReadCount"));
                item.DynamicCss = reader.GetString(reader.GetOrdinal("titleCss"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
            }
            reader.Close();
            return item;
        }

        public void InsertSiteDynamic(SiteDynamicInfo siteDynamic)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@dynamicTitle", siteDynamic.DynamicTitle);
            objParams[1] = new SqlParameter("@titleCss", siteDynamic.DynamicCss);
            objParams[2] = new SqlParameter("@dynamicContent", siteDynamic.DynamicContent);
            objParams[3] = new SqlParameter("@addDate", DateTime.Now);
            objSqlHelper.ExecuteNonQuery("je_Dy_InsertSiteDynamic", objParams);
        }

        public int UpdateSiteDynamic(SiteDynamicInfo siteDynamic)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@dynamicID", siteDynamic.DynamicID);
            objParams[1] = new SqlParameter("@dynamicTitle", siteDynamic.DynamicTitle);
            objParams[2] = new SqlParameter("@titleCss", siteDynamic.DynamicCss);
            objParams[3] = new SqlParameter("@dynamicContent", siteDynamic.DynamicContent);
            return objSqlHelper.ExecuteNonQuery("je_Dy_UpdateSiteDynamic", objParams);
        }

        public int DeleteSiteDynamic(int siteDynamicID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@dynamicID", siteDynamicID);
            return objSqlHelper.ExecuteNonQuery("je_Dy_DeleteSiteDynamic", objParams);
        }

        #endregion
    }
}
