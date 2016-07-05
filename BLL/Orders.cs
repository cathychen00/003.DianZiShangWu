using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;

namespace Jiaen.BLL
{
    [DataObjectAttribute]
    public class Orders
    {
        private static readonly IOrders orders = DataAccess.CreateOrders();

        /// <summary>
        /// 获取订单
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetAllOrders()
        {
            return orders.GetAllOrders();
        }

        /// <summary>
        /// 获取今日订单信息
        /// </summary>
        /// <returns></returns>
        IList<OrdersInfo> GetTodayOrders()
        {
            return orders.GetTodayOrders();
        }

        public static IList<OrdersInfo> GetStatusOrders(int state)
        {
            return orders.GetStatusOrders(state);
        }
        /// <summary>
        /// 获取订单详细信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static OrdersInfo GetOrdersByID(long orderID)
        {
            return orders.GetOrdersByID(orderID);
        }

        /// <summary>
        /// 获取时间年
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetYearOrders()
        {
            return orders.GetYearOrders();
        }

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="link"></param>
        public static void InsertOrders(OrdersInfo order)
        {
            orders.InsertOrders(order);
        }

        /// <summary>
        /// 获取订单产品信息
        /// </summary>
        /// <returns></returns>
        public static IList<OrderDetailInfo> GetDerailByID(long orderID)
        {
            return orders.GetDerailByID(orderID);
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetUserOrders(string userName)
        {
            return orders.GetUserOrders(userName);
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <returns></returns>
        public static IList<OrdersInfo> GetUserOrders()
        {
            return orders.GetUserOrders();
        }

        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <returns></returns>
        public static int UpdateOrderTypeByID(OrdersInfo order)
        {
            return orders.UpdateOrderTypeByID(order);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <returns></returns>
        public static int UpdateOrderStatusByID(int status, long orderID)
        {
            return orders.UpdateOrderStatusByID(status, orderID);
        }

        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <returns></returns>
        public static int UpdateOrderPayByID(decimal money, long orderID)
        {
            return orders.UpdateOrderPayByID(money, orderID);
        }

        public static int UpdateOrderDateByID(long orderID)
        {
            return orders.UpdateOrderDateByID(orderID);
        }

        public static bool GetBookByID(int bookID, int status)
        {
            return orders.GetBookByID(bookID,status);
        }
    }
}
