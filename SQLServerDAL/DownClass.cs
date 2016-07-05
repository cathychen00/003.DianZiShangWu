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
   public class DownClass:IDownClass
    {
        #region IDownClass ≥…‘±

        public IList<DownClassInfo> GetDownClass()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<DownClassInfo> helpClass = new List<DownClassInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_DC_GetDownClass");
            while (reader.Read())
            {
                DownClassInfo item = GetDownClassByID(reader.GetInt32(reader.GetOrdinal("catID")));
                helpClass.Add(item);
            }
            reader.Close();
            return helpClass;
        }

        public DownClassInfo GetDownClassByID(int classID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@catID", SqlDbType.Int, 4);
            objParams[0].Value = classID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_DC_GetDownClassByID", objParams);
            DownClassInfo item = new DownClassInfo();
            while (reader.Read())
            {
                item.ID = reader.GetInt32(reader.GetOrdinal("catID"));
                item.ClassName = reader.GetString(reader.GetOrdinal("catName"));
                item.Order = reader.GetInt32(reader.GetOrdinal("Order"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("AddDate"));
            }
            reader.Close();
            return item;
        }

        public void InsertDownClass(DownClassInfo downClass)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@catName", downClass.ClassName);
            objSqlHelper.ExecuteNonQuery("je_DC_InsertDownClass", objParams);
        }

        public int UpdateDownClass(DownClassInfo downClass)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@catName", downClass.ClassName);
            objParams[1] = new SqlParameter("@catID", downClass.ID);
           return objSqlHelper.ExecuteNonQuery("je_DC_UpdateDownClass", objParams);
        }

        public int DeleteDownClass(DownClassInfo downClass)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@catID", downClass.ID);
            return objSqlHelper.ExecuteNonQuery("je_DC_DeleteDownClass", objParams);
        }

        #endregion
    }
}
