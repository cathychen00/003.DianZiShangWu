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
    /// 标题样式操作
    /// </summary>
   public class TitleCss:ITitleCss
    {
        #region ITitleCss 成员

        public IList<TitleCssInfo> GetTitleCss()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<TitleCssInfo> tcs = new List<TitleCssInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Tc_GetTitleCss");
            while (reader.Read())
            {
                TitleCssInfo item = new TitleCssInfo();
                item.TitleCssID = reader.GetInt32(reader.GetOrdinal("cssID"));
                item.TitleCssName = reader.GetString(reader.GetOrdinal("cssName"));
                item.TitleCssDec = reader.GetString(reader.GetOrdinal("cssDec"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
                tcs.Add(item);
            }
            reader.Close();
            return tcs;
        }

        public TitleCssInfo GetTitleCssByID(int titleCssID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@cssID", SqlDbType.Int, 4);
            objParams[0].Value = titleCssID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Tc_GetTitleCssByID", objParams);
            TitleCssInfo item = new TitleCssInfo();
            while (reader.Read())
            {
                item.TitleCssID = reader.GetInt32(reader.GetOrdinal("cssID"));
                item.TitleCssName = reader.GetString(reader.GetOrdinal("cssName"));
                item.TitleCssDec = reader.GetString(reader.GetOrdinal("cssDec"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
            }
            reader.Close();
            return item;
        }

        public void InsertTitleCss(TitleCssInfo titleCss)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            objParams[0] = new SqlParameter("@CssName", StringHelper.convertStr(titleCss.TitleCssName));
            objParams[1] = new SqlParameter("@CssDec", StringHelper.convertStr(titleCss.TitleCssDec));
            objParams[2] = new SqlParameter("@addDate", DateTime.Now);
            objSqlHelper.ExecuteNonQuery("je_Tc_InsertTitleCss", objParams);
        }

        public int UpdateTitleCss(TitleCssInfo titleCss)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@cssName", StringHelper.convertStr(titleCss.TitleCssName));
            objParams[1] = new SqlParameter("@cssDec", StringHelper.convertStr(titleCss.TitleCssDec));
            objParams[2] = new SqlParameter("@addDate", DateTime.Now);
            objParams[3] = new SqlParameter("@cssID", titleCss.TitleCssID);
            return objSqlHelper.ExecuteNonQuery("je_Tc_UpdateTitleCss", objParams);
        }

        public int DeleteTitleCss(int titleCssID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@cssID", titleCssID);
            return objSqlHelper.ExecuteNonQuery("je_Tc_DeleteTitleCss", objParams);
        }

        #endregion
    }
}
