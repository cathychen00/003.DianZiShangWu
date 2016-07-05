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
    public class Orders : IOrders
    {
        #region IOrders 成员

        public IList<OrdersInfo> GetAllOrders()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<OrdersInfo> orders = new List<OrdersInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetAllOrders");
            while (reader.Read())
            {
                OrdersInfo item = GetOrdersByID(reader.GetInt64(reader.GetOrdinal("OrderID")));
                orders.Add(item);
            }
            reader.Close();
            return orders;
        }

        /// <summary>
        /// 获取今日订单信息
        /// </summary>
        /// <returns></returns>
        public IList<OrdersInfo> GetTodayOrders()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<OrdersInfo> orders = new List<OrdersInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetTodayOrders");
            while (reader.Read())
            {
                OrdersInfo item = GetOrdersByID(reader.GetInt64(reader.GetOrdinal("OrderID")));
                orders.Add(item);
            }
            reader.Close();
            return orders;
        }

        public IList<OrdersInfo> GetStatusOrders(int state)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@state", SqlDbType.Int);
            objParams[0].Value = state;
            List<OrdersInfo> orders = new List<OrdersInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetStatusOrders",objParams);
            while (reader.Read())
            {
                OrdersInfo item = GetOrdersByID(reader.GetInt64(reader.GetOrdinal("OrderID")));
                orders.Add(item);
            }
            reader.Close();
            return orders;
        }

        public IList<OrdersInfo> GetYearOrders()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<OrdersInfo> orders = new List<OrdersInfo>();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetYearOrders");
            while (reader.Read())
            {
                OrdersInfo item = new OrdersInfo();
                item.Year = reader.GetInt32(reader.GetOrdinal("OrderYear"));
                orders.Add(item);
            }
            reader.Close();
            return orders;
        }

        public OrdersInfo GetOrdersByID(long orderID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@orderID", SqlDbType.BigInt);
            objParams[0].Value = orderID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetOrderByID", objParams);
            OrdersInfo item = new OrdersInfo();
            while (reader.Read())
            {
                item.OrderID = reader.GetInt64(reader.GetOrdinal("OrderID"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("addDate"));
                item.BookPrice = reader.GetDecimal(reader.GetOrdinal("BookPrice"));
                item.SendPrice = reader.GetDecimal(reader.GetOrdinal("SendPrice"));
                item.SumPrice = reader.GetDecimal(reader.GetOrdinal("SumPrice"));
                item.SendType = reader.GetInt32(reader.GetOrdinal("SendType"));
                item.PayType = reader.GetInt32(reader.GetOrdinal("PayType"));
                item.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                item.AddressName = reader.GetString(reader.GetOrdinal("AddressName"));
                item.Telephone = reader.GetString(reader.GetOrdinal("Telephone"));
                item.IsPass = reader.GetBoolean(reader.GetOrdinal("IsPass"));
                item.IsPay = reader.GetBoolean(reader.GetOrdinal("IsPay"));
                item.IsSended = reader.GetBoolean(reader.GetOrdinal("IsSended"));
                item.IsCancel = reader.GetBoolean(reader.GetOrdinal("IsCancel"));
                item.IsFinished = reader.GetBoolean(reader.GetOrdinal("IsFinished"));
                item.Address = reader.GetString(reader.GetOrdinal("Address"));
                item.Post = reader.GetString(reader.GetOrdinal("Post"));
                item.OrderStatus = reader.GetInt32(reader.GetOrdinal("OrderStatus"));
                item.IsTg = reader.GetBoolean(reader.GetOrdinal("IsTg"));
                item.BalancePrice = reader.GetDecimal(reader.GetOrdinal("BalancePrice"));
                item.NeedPayPrice = reader.GetDecimal(reader.GetOrdinal("NeedPayPrice"));
                item.OtherPayPrice = reader.GetDecimal(reader.GetOrdinal("OtherPayPrice"));
                item.TgPrice = reader.GetDecimal(reader.GetOrdinal("TgPrice"));
                item.SendDate = reader.GetDateTime(reader.GetOrdinal("SendDate"));
            }
            reader.Close();
            return item;
        }

        public bool GetBookByID(int bookID, int status)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@bookID", SqlDbType.Int);
            objParams[0].Value = bookID;
            objParams[1] = new SqlParameter("@status", SqlDbType.Int);
            objParams[1].Value = status;
            int bookCount = (int)objSqlHelper.ExecuteScalar("je_Order_GetBookByID", objParams);
            
            bool isHave=true;
            if(bookCount==0)
            {
                isHave = false;
            }
            return isHave;
        }

        public void InsertOrders(OrdersInfo order)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[19];
            //定单编号,用户,送货用户,地址,邮编,电话
            objParams[0] = new SqlParameter("@OrderID", order.OrderID);
            objParams[1] = new SqlParameter("@UserName", order.UserName);
            objParams[2] = new SqlParameter("@AddressName", order.AddressName);
            objParams[3] = new SqlParameter("@Address", order.Address);
            objParams[4] = new SqlParameter("@Post", order.Post);
            objParams[5] = new SqlParameter("@Telephone", order.Telephone);
            //省份,城市,送货方式,付款方式,
            objParams[6] = new SqlParameter("@Province", order.Province);
            objParams[7] = new SqlParameter("@City", order.City);
            objParams[8] = new SqlParameter("@SendType", order.SendType);
            objParams[9] = new SqlParameter("@PayType", order.PayType);
            //是否开发票,图书价格,送货费用,总价格,留言
            objParams[10] = new SqlParameter("@EnableInvoice", order.EnableInvoice);
            objParams[11] = new SqlParameter("@BookPrice", order.BookPrice);
            objParams[12] = new SqlParameter("@SendPrice", order.SendPrice);
            objParams[13] = new SqlParameter("@SumPrice", order.SumPrice);
            objParams[14] = new SqlParameter("@Message", order.Message);
            objParams[15] = new SqlParameter("@IsTg", order.IsTg);
            objParams[16] = new SqlParameter("@BalancePrice", order.BalancePrice);
            objParams[17] = new SqlParameter("@NeedPayPrice", order.NeedPayPrice);
            objParams[18] = new SqlParameter("@TgPrice", order.TgPrice);
            objSqlHelper.ExecuteNonQuery("je_Order_InsertOrders", objParams);
        }

        public IList<OrderDetailInfo> GetDerailByID(long orderID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<OrderDetailInfo> details = new List<OrderDetailInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@orderID", SqlDbType.BigInt);
            objParams[0].Value = orderID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetDerailByID", objParams);
            while (reader.Read())
            {
                OrderDetailInfo item = new OrderDetailInfo();
                item.Id = reader.GetInt32(reader.GetOrdinal("ID"));
                item.OrderID = reader.GetInt64(reader.GetOrdinal("OrderID"));
                item.BookID = reader.GetInt32(reader.GetOrdinal("BookID"));
                item.BookName = reader.GetString(reader.GetOrdinal("BookName"));
                item.Price = reader.GetDecimal(reader.GetOrdinal("bookPrice"));
                item.MemberPrice = reader.GetDecimal(reader.GetOrdinal("MemberPrice"));
                item.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                details.Add(item);
            }
            reader.Close();
            return details;
        }

        public IList<OrdersInfo> GetUserOrders(string userName)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<OrdersInfo> orders = new List<OrdersInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            objParams[0].Value = userName;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetUserOrders", objParams);
            while (reader.Read())
            {
                OrdersInfo item = GetOrdersByID(reader.GetInt64(reader.GetOrdinal("OrderID")));
                orders.Add(item);
            }
            reader.Close();
            return orders;
        }

        public IList<OrdersInfo> GetUserOrders()
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<OrdersInfo> orders = new List<OrdersInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            objParams[0].Value = GetUserName();
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Order_GetUserOrders", objParams);
            while (reader.Read())
            {
                OrdersInfo item = GetOrdersByID(reader.GetInt64(reader.GetOrdinal("OrderID")));
                orders.Add(item);
            }
            reader.Close();
            return orders;
        }

        private static string GetUserName()
        {
            HttpContext context = HttpContext.Current;
            string userName = context.Request.AnonymousID;
            if (context.Request.IsAuthenticated)
                userName = context.User.Identity.Name;
            return userName;
        }

        public int UpdateOrderTypeByID(OrdersInfo order)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[7];
            objParams[0] = new SqlParameter("@orderID", order.OrderID);
            objParams[1] = new SqlParameter("@IsPass", order.IsPass);
            objParams[2] = new SqlParameter("@IsPay", order.IsPay);
            objParams[3] = new SqlParameter("@IsSended", order.IsSended);
            objParams[4] = new SqlParameter("@IsFinished", order.IsFinished);
            objParams[5] = new SqlParameter("@IsCancel", order.IsCancel);
            objParams[6] = new SqlParameter("@OrderStatus", order.OrderStatus);
            return objSqlHelper.ExecuteNonQuery("je_Order_UpdateType", objParams);
        }

        public int UpdateOrderStatusByID(int status, long orderID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@status", status);
            objParams[1] = new SqlParameter("@orderID", orderID);
            return objSqlHelper.ExecuteNonQuery("je_Order_UpdateStatus", objParams);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <returns></returns>
        public int UpdateOrderPayByID(decimal money, long orderID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@payPrice", money);
            objParams[1] = new SqlParameter("@orderID", orderID);
            return objSqlHelper.ExecuteNonQuery("je_Order_UpdatePayOrder", objParams);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <returns></returns>
        public int UpdateOrderDateByID(long orderID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@orderID", orderID);
            return objSqlHelper.ExecuteNonQuery("je_Order_UpdateDateOrder", objParams);
        }
        #endregion
    }
}
