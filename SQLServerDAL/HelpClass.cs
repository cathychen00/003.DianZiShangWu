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
    public class HelpClass:IHelpClass
    {
        #region IHelpClass ≥…‘±

        public IList<HelpClassInfo> GetHelpClass()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<HelpClassInfo> helpClass = new List<HelpClassInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_HC_GetHelpClass");
            while (reader.Read())
            {
                HelpClassInfo item = GetHelpClassByID(reader.GetInt32(reader.GetOrdinal("ClassID")));
                helpClass.Add(item);
            }
            reader.Close();
            return helpClass;
        }

        public IList<HelpClassInfo> GetMainHelpClass()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<HelpClassInfo> helpClass = new List<HelpClassInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_HC_GetMainHelpClass");
            while (reader.Read())
            {
                HelpClassInfo item = GetHelpClassByID(reader.GetInt32(reader.GetOrdinal("ClassID")));
                helpClass.Add(item);
            }
            reader.Close();
            return helpClass;
        }

        public HelpClassInfo GetHelpClassByID(int HelpClassID)
        {
            SqlHelper objSqlHelper = new SqlHelper();

            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ClassID", SqlDbType.Int, 4);
            objParams[0].Value = HelpClassID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_HC_GetHelpClassByID", objParams);
            HelpClassInfo item = new HelpClassInfo();
            while (reader.Read())
            {
                item.ClassID = reader.GetInt32(reader.GetOrdinal("ClassID"));
                item.ClassName = reader.GetString(reader.GetOrdinal("ClassName"));
                item.Order = reader.GetInt32(reader.GetOrdinal("Order"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("AddDate"));
                item.IsVisible = reader.GetBoolean(reader.GetOrdinal("IsVisible"));
            }
            reader.Close();
            return item;
        }

        public void InsertHelpClass(HelpClassInfo HelpClass)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@ClassName", HelpClass.ClassName);
            objParams[1] = new SqlParameter("@IsVisible", HelpClass.IsVisible);
            objSqlHelper.ExecuteNonQuery("je_HC_InsertHelpClass", objParams);
        }

        public int UpdateHelpClass(HelpClassInfo HelpClass)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@ClassName", HelpClass.ClassName);
            objParams[1] = new SqlParameter("@ClassID", HelpClass.ClassID);
            objParams[2] = new SqlParameter("@IsVisible", HelpClass.IsVisible);
            return objSqlHelper.ExecuteNonQuery("je_HC_UpdateHelpClass", objParams);
        }

        public int DeleteHelpClass(HelpClassInfo HelpClass)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@classID", HelpClass.ClassID);
            return objSqlHelper.ExecuteNonQuery("je_HC_DeleteHelpClass", objParams);
        }

        #endregion
    }
}
