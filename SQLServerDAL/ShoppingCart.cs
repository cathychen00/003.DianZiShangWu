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
   public class ShoppingCart:IShoppingCart
    {
        #region IShoppingCart ≥…‘±

        public void InsertCart(int bookID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            string userName = GetUserName();
            objParams[0] = new SqlParameter("@userName", userName);
            objParams[1] = new SqlParameter("@bookID", bookID);
            objSqlHelper.ExecuteNonQuery("je_Cart_InsertCart", objParams);

            // Clear session cart
            //HttpContext context = HttpContext.Current;
            //context.Session.Remove("ShoppingCart");
        }

       public void InsertTgCart(int bookID)
       {
           SiteSetting site = new SiteSetting();
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[3];
           string userName = GetUserName();
           objParams[0] = new SqlParameter("@userName", userName);
           objParams[1] = new SqlParameter("@bookID", bookID);
           objParams[2] = new SqlParameter("@quantity", site.GetSiteSettings("jiaen").TgNum);
           objSqlHelper.ExecuteNonQuery("je_Cart_InsertTgCart", objParams);

           // Clear session cart
           //HttpContext context = HttpContext.Current;
           //context.Session.Remove("ShoppingCart");
       }

        public void AuthenticateCart(string anonymousId, string userName)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@anonymousId", anonymousId);
            objParams[1] = new SqlParameter("@userName", userName);
            objSqlHelper.ExecuteNonQuery("je_Cart_AuthenticateCart", objParams);

            // Clear session cart
            //HttpContext context = HttpContext.Current;
            //context.Session.Remove("ShoppingCart");
        }

        public void DeleteCart(int bookID,bool isTg)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[3];
            string userName = GetUserName();
            objParams[0] = new SqlParameter("@userName", userName);
            objParams[1] = new SqlParameter("@bookID", bookID);
            objParams[2] = new SqlParameter("@isTg", isTg);
            objSqlHelper.ExecuteNonQuery("je_Cart_DeleteCart", objParams);
            // Clear session cart
            //HttpContext context = HttpContext.Current;
            //context.Session.Remove("ShoppingCart");
        }

       public void UpdateCart(int bookID, int quantity, bool isTg)
       {
           SqlHelper objSqlHelper = new SqlHelper();
           SqlParameter[] objParams = new SqlParameter[4];
           string userName = GetUserName();
           objParams[0] = new SqlParameter("@userName", userName);
           objParams[1] = new SqlParameter("@bookID", bookID);
           objParams[2] = new SqlParameter("@quantity", quantity);
           objParams[3] = new SqlParameter("@isTg", isTg);
           objSqlHelper.ExecuteNonQuery("je_Cart_UpdateCart", objParams);
           //HttpContext context = HttpContext.Current;
           //context.Session.Remove("ShoppingCart");
       }

      public List<CartInfo> SelectTgCart()
       {
           string userName = GetUserName();
           SqlHelper objSqlHelper = new SqlHelper();
           List<CartInfo> carts = new List<CartInfo>();
           SqlParameter[] objParams = new SqlParameter[1];
           objParams[0] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
           objParams[0].Value = userName;
           SqlDataReader reader = objSqlHelper.ExecuteReader("je_Cart_SelectTgCart", objParams);
           while (reader.Read())
           {
               CartInfo item = new CartInfo();
               item.Id = reader.GetInt32(reader.GetOrdinal("cartId"));
               item.BookName = reader.GetString(reader.GetOrdinal("BookName"));
               item.BookID = reader.GetInt32(reader.GetOrdinal("bookID"));
               item.MemberPrice = reader.GetDecimal(reader.GetOrdinal("bookMemberPrice"));
               item.VipPrice = reader.GetDecimal(reader.GetOrdinal("VipPrice"));
               item.Quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
               carts.Add(item);
           }
           reader.Close();
           return carts;
       }

        public IList<CartInfo> SelectCart()
        {

            string userName = GetUserName();
            SqlHelper objSqlHelper = new SqlHelper();
            List<CartInfo> carts = new List<CartInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            objParams[0].Value = userName;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Cart_SelectCart", objParams);
            while (reader.Read())
            {
                CartInfo item = new CartInfo();
                item.Id = reader.GetInt32(reader.GetOrdinal("cartId"));
                item.BookName = reader.GetString(reader.GetOrdinal("BookName"));
                item.BookID = reader.GetInt32(reader.GetOrdinal("bookID"));
                item.MemberPrice = reader.GetDecimal(reader.GetOrdinal("bookMemberPrice"));
                item.VipPrice = reader.GetDecimal(reader.GetOrdinal("VipPrice"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                carts.Add(item);
            }
            reader.Close();
            return carts;
        }

        #endregion

       private static string GetUserName()
       {
           HttpContext context = HttpContext.Current;
           string userName = context.Request.AnonymousID;
           if (context.Request.IsAuthenticated)
               userName = context.User.Identity.Name;
           return userName;
       }
    }
}
