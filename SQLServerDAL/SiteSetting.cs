using System;
using Jiaen.Components.IDAL;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.IO;
using System.Collections;
using System.Data.SqlClient;
using Jiaen.Components;
namespace Jiaen.SQLServerDAL
{
    public class SiteSetting:ISiteSetting
    {
        #region ISiteSetting 成员

        public SiteSettings GetSiteSettings(string applicationName)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@applicationName", SqlDbType.VarChar, 100);
            objParams[0].Value = applicationName;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Site_GetSiteSetting", objParams);
            SiteSettings settings = new SiteSettings();
            while (reader.Read())
            {
                settings = PopulateSiteSettingsFromIDataReader(reader);
            }
            reader.Close();
            return settings;
        }

        /// <summary>
        /// 将DataReader数据转换为SiteSettings类实例
        /// </summary>
        /// <param name="dr">DataReader数据</param>
        /// <returns>返回SiteSettings类实例</returns>
        private static SiteSettings PopulateSiteSettingsFromIDataReader(IDataReader dr)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            SiteSettings settings = new SiteSettings();
            MemoryStream ms = new MemoryStream();
            Byte[] b;

            b = (byte[])dr["Settings"];

            // Read the byte array into a memory stream
            //
            ms.Write(b, 0, b.Length);

            // Set the memory stream position to the beginning of the stream
            //
            ms.Position = 0;

            // Set the internal hashtable
            //
            settings.Settings = (Hashtable)binaryFormatter.Deserialize(ms);
            return settings;
        }

        public int SaveSiteSettings(SiteSettings siteSettings)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] b;
            binaryFormatter.Serialize(ms, siteSettings.Settings);

            // Set the position of the MemoryStream back to 0
            //
            ms.Position = 0;

            // Read in the byte array
            //
            b = new Byte[ms.Length];
            ms.Read(b, 0, b.Length);
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@siteSettings", b);

            return objSqlHelper.ExecuteNonQuery("je_Site_SaveSiteSetting", objParams);
        }

        public void InsertSiteSettings(SiteSettings siteSettings)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] b;
            binaryFormatter.Serialize(ms, siteSettings.Settings);

            // Set the position of the MemoryStream back to 0
            //
            ms.Position = 0;

            // Read in the byte array
            //
            b = new Byte[ms.Length];
            ms.Read(b, 0, b.Length);
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Name", "");
            objParams[1] = new SqlParameter("@siteSettings", b);

            objSqlHelper.ExecuteNonQuery("je_Site_InsertSiteSettings", objParams);
        }

        #endregion
    }
}
