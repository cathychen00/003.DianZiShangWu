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
   public class Payment:IPayment
    {
        #region IPayment 成员

        public IList<PaymentInfo> GetPayment(int payType)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<PaymentInfo> payments = new List<PaymentInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@payType", SqlDbType.Int, 4);
            objParams[0].Value = payType;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Pay_GetPayment", objParams);

            while (reader.Read())
            {
                PaymentInfo item = GetPaymentByID(reader.GetInt32(reader.GetOrdinal("paymentID")));

                payments.Add(item);
            }
            reader.Close();
            return payments;
        }



        public PaymentInfo GetPaymentByID(int paymentID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@paymentID", SqlDbType.Int, 4);
            objParams[0].Value = paymentID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Pay_GetPaymentID", objParams);
            PaymentInfo item = new PaymentInfo();
            while (reader.Read())
            {
                item.PaymentID = reader.GetInt32(reader.GetOrdinal("paymentID"));
                item.PayName = reader.GetString(reader.GetOrdinal("paymentName"));
                item.PayType = reader.GetInt32(reader.GetOrdinal("paymentType"));
                item.OnLinePayType = reader.GetInt32(reader.GetOrdinal("OnLinePayType"));
                item.UserName = reader.GetString(reader.GetOrdinal("userName"));
                item.PrivateKey = reader.GetString(reader.GetOrdinal("PrivateKey"));
                item.PartnerID = reader.GetString(reader.GetOrdinal("PartnerID"));
                item.Dec = reader.GetString(reader.GetOrdinal("Dec"));
                item.Status = reader.GetBoolean(reader.GetOrdinal("Status"));
            }
            reader.Close();
            return item;
        }

        public void InsertPayment(PaymentInfo payment)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@UserName", payment.UserName);
            objParams[1] = new SqlParameter("@Dec", payment.Dec);
            objSqlHelper.ExecuteNonQuery("je_Pay_InsertPayment", objParams);
        }

        public int UpdatePayment(PaymentInfo payment)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[5];
            objParams[0] = new SqlParameter("@UserName", payment.UserName);
            objParams[1] = new SqlParameter("@Dec", payment.Dec);
            objParams[2] = new SqlParameter("@PrivateKey", payment.PrivateKey);
            objParams[3] = new SqlParameter("@PartnerID", payment.PartnerID);
            objParams[4] = new SqlParameter("@PaymentID", payment.PaymentID);
            return objSqlHelper.ExecuteNonQuery("je_Pay_UpdatePayment", objParams);
        }

       public int UpdateOnLinePayment(PaymentInfo payment)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[5];
           objParams[0] = new SqlParameter("@dynamicTitle", payment.PayName);
           objParams[1] = new SqlParameter("@titleCss", payment.Dec);
           objParams[2] = new SqlParameter("@titleCss", payment.UserName);
           objParams[3] = new SqlParameter("@dynamicTitle", payment.PrivateKey);
           objParams[4] = new SqlParameter("@titleCss", payment.PaymentID);
          return objSqlHelper.ExecuteNonQuery("je_Pay_DeletePayment", objParams);
       }

       public int DeletePayment(PaymentInfo payment)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@paymentID", payment.PaymentID);
            return objSqlHelper.ExecuteNonQuery("je_Pay_DeletePayment", objParams);
        }

        #endregion
    }
}
