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
  public class Help:IHelp
    {
        #region Ihelps 成员

      public IList<HelpInfo> GetHelp()
        {
          
            SqlHelper objSqlHelper = new SqlHelper();
            List<HelpInfo> helps = new List<HelpInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Help_GetHelp");
            while (reader.Read())
            {
                HelpInfo item = GetHelpByID(reader.GetInt32(reader.GetOrdinal("helpID")));
                helps.Add(item);
            }
            reader.Close();
            return helps;
        }

        public HelpInfo GetHelpByID(int helpID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@helpID", SqlDbType.Int, 4);
            objParams[0].Value = helpID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Help_GetHelpByID", objParams);
            HelpInfo item = new HelpInfo();
            while (reader.Read())
            {
                item.HelpID = reader.GetInt32(reader.GetOrdinal("HelpID"));
                item.ClassID = reader.GetInt32(reader.GetOrdinal("ClassID"));
                item.ClassName = reader.GetString(reader.GetOrdinal("ClassName"));
                item.HelpTitle = reader.GetString(reader.GetOrdinal("helpTitle"));
                item.HelpContent = reader.GetString(reader.GetOrdinal("helpContent"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("AddDate"));
            }
            reader.Close();
            return item;
        }

        public void InsertHelp(HelpInfo help)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@ClassID", help.ClassID);
            objParams[1] = new SqlParameter("@HelpTitle", help.HelpTitle);
            objParams[2] = new SqlParameter("@HelpContent", help.HelpContent);
            objSqlHelper.ExecuteNonQuery("je_Help_InsertHelp", objParams);
        }

        public int UpdateHelp(HelpInfo help)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@ClassID", help.ClassID);
            objParams[1] = new SqlParameter("@HelpTitle", help.HelpTitle);
            objParams[2] = new SqlParameter("@HelpContent", help.HelpContent);
            objParams[3] = new SqlParameter("@HelpID", help.HelpID);
            return objSqlHelper.ExecuteNonQuery("je_Help_UpdateHelp", objParams);
        }

        public int DeleteHelp(int helpID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@helpID", helpID);
          return objSqlHelper.ExecuteNonQuery("je_Help_DeleteHelp", objParams);
        }

        #endregion

        #region IHelp 成员


        public IList<HelpInfo> GetClassHelpByID(int classID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<HelpInfo> helps = new List<HelpInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@classID", classID);
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Help_GetClassHelpByID", objParams);
            while (reader.Read())
            {
                HelpInfo item = GetHelpByID(reader.GetInt32(reader.GetOrdinal("helpID")));
                helps.Add(item);
            }
            reader.Close();
            return helps;
        }

        #endregion
    }
}
