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
   public class EmailFormat:IEmailFormat
    {
       

        public IList<EmailFormatInfo> GetEmailFormat()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<EmailFormatInfo> emails = new List<EmailFormatInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Email_GetEmailFormat");
            while (reader.Read())
            {
                EmailFormatInfo item =GetEmailFormatByID( reader.GetInt32(reader.GetOrdinal("ID")));
                emails.Add(item);
            }
            reader.Close();
            return emails;
        }

        public EmailFormatInfo GetEmailFormatByID(int emailFormatID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            objParams[0].Value = emailFormatID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Email_GetEmailFormatByID", objParams);
            EmailFormatInfo item = new EmailFormatInfo();
            while (reader.Read())
            {
                item.EmailID = reader.GetInt32(reader.GetOrdinal("ID"));
                item.EmailType = reader.GetString(reader.GetOrdinal("EmailType"));
                item.EmailTitle = reader.GetString(reader.GetOrdinal("EmailTitle"));
                item.EmailTemplete = reader.GetString(reader.GetOrdinal("EmailTemplate"));
                item.ExplainInfo = reader.GetString(reader.GetOrdinal("ExplainInfo"));
                item.IsSend = reader.GetBoolean(reader.GetOrdinal("IsSend"));
            }
            reader.Close();
            return item;
        }

        public int UpdateEmailFormat(EmailFormatInfo emailFormat)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@EmailTitle", emailFormat.EmailTitle);
            objParams[1] = new SqlParameter("@EmailTemplate", emailFormat.EmailTemplete);
            objParams[2] = new SqlParameter("@IsSend", emailFormat.IsSend);
            objParams[3] = new SqlParameter("@ID", emailFormat.EmailID);
          return objSqlHelper.ExecuteNonQuery("je_Email_UpdateEmailFormat", objParams);
        }

    }
}
