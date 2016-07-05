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
   public class Address:IAddress
    {
        #region IAddress ≥…‘±

        public IList<AddressInfo> GetAddress(int userID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<AddressInfo> Addresss = new List<AddressInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userID", SqlDbType.Int, 4);
            objParams[0].Value = userID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Ad_GetAddress", objParams);
            while (reader.Read())
            {
                AddressInfo item = new AddressInfo();
                item.AddressID = reader.GetInt32(reader.GetOrdinal("addressID"));
                item.AddressName = reader.GetString(reader.GetOrdinal("addressName"));
                item.Address = reader.GetString(reader.GetOrdinal("address"));
                item.Post = reader.GetString(reader.GetOrdinal("Post"));
                item.Telephone = reader.GetString(reader.GetOrdinal("Telephone"));
                item.IsDefault = reader.GetBoolean(reader.GetOrdinal("isDefault"));
                item.Province = reader.GetString(reader.GetOrdinal("Province"));
                item.City = reader.GetString(reader.GetOrdinal("City"));
                item.SendType = reader.GetInt32(reader.GetOrdinal("SendType"));
                item.Name = reader.GetString(reader.GetOrdinal("Name"));
                Addresss.Add(item);
            }
            reader.Close();
            return Addresss;
        }

       private static string GetUserName()
       {
           HttpContext context = HttpContext.Current;
           string userName = context.Request.AnonymousID;
           if (context.Request.IsAuthenticated)
               userName = context.User.Identity.Name;
           return userName;
       }

        public AddressInfo GetAddressByID()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userName", SqlDbType.VarChar);

            objParams[0].Value = GetUserName();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Ad_GetAddressByID", objParams);
            AddressInfo item = new AddressInfo();
            while (reader.Read())
            {
                item.UserName = reader.GetString(reader.GetOrdinal("userName"));
                item.AddressName = reader.GetString(reader.GetOrdinal("addressName"));
                item.Address = reader.GetString(reader.GetOrdinal("address"));
                item.Post = reader.GetString(reader.GetOrdinal("Post"));
                item.Telephone = reader.GetString(reader.GetOrdinal("Telephone"));
                item.Province = reader.GetString(reader.GetOrdinal("Province"));
                item.City = reader.GetString(reader.GetOrdinal("City"));
                item.SendType = reader.GetInt32(reader.GetOrdinal("SendType"));
                item.PayType = reader.GetInt32(reader.GetOrdinal("PayType"));
                item.Name = reader.GetString(reader.GetOrdinal("Name"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
                item.Balance = reader.GetDecimal(reader.GetOrdinal("Balance"));
            }
            reader.Close();
            return item;
        }

        public void InsertAddress(AddressInfo address)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@addressName", address.AddressName);
            objParams[1] = new SqlParameter("@address", address.Address);
            objParams[2] = new SqlParameter("@post", address.Post);
            objParams[3] = new SqlParameter("@telephone", address.Telephone);
            objParams[4] = new SqlParameter("@isDefault", false);
            objParams[5] = new SqlParameter("@addDate", DateTime.Now);
            objParams[6] = new SqlParameter("@userName", address.UserName);
            objSqlHelper.ExecuteNonQuery("je_Ad_InsertAddress", objParams);
        }

       public void InsertEmpty(string userName)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[5];
           objParams[0] = new SqlParameter("@addressName", userName);
           objParams[1] = new SqlParameter("@address", string.Empty);
           objParams[2] = new SqlParameter("@post", string.Empty);
           objParams[3] = new SqlParameter("@telephone", string.Empty);
           objParams[4] = new SqlParameter("@userName", userName);
           objSqlHelper.ExecuteNonQuery("je_Ad_InsertAddress", objParams);
       }

        public int UpdateAddress(AddressInfo address)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@addressName", address.AddressName);
            objParams[1] = new SqlParameter("@address", address.Address);
            objParams[2] = new SqlParameter("@addressPost", address.Post);
            objParams[3] = new SqlParameter("@telephone", address.Telephone);
            objParams[4] = new SqlParameter("@UserName", GetUserName());
            objParams[5] = new SqlParameter("@Province", address.Province);
            objParams[6] = new SqlParameter("@City", address.City);
            return objSqlHelper.ExecuteNonQuery("je_Ad_UpdateAddress", objParams);
        }

       public int UpdateAddressSend(int sendType)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@sendType", sendType);
           objParams[1] = new SqlParameter("@UserName", GetUserName());
           return objSqlHelper.ExecuteNonQuery("je_Ad_UpdateAddressSend", objParams);
       }

       public int UpdateAddressPay(int payType)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@payType", payType);
           objParams[1] = new SqlParameter("@UserName", GetUserName());
           return objSqlHelper.ExecuteNonQuery("je_Ad_UpdateAddressPay", objParams);
       }

       public int UpdateAddressBalance(decimal balance)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[2];
           objParams[0] = new SqlParameter("@balance", balance);
           objParams[1] = new SqlParameter("@UserName", GetUserName());
           return objSqlHelper.ExecuteNonQuery("je_Ad_UpdateAddressBalance", objParams);
       }

        public int DeleteAddress(int addressID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@addressID", addressID);
            return objSqlHelper.ExecuteNonQuery("je_Ad_DeleteAddress", objParams);
        }

        #endregion
    }
}
