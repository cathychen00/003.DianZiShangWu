using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 订单信息接口
    /// </summary>
   public interface IOrders
    {

        /// <summary>
        /// 获取订单
        /// </summary>
        /// <returns></returns>
       IList<OrdersInfo> GetAllOrders();

       /// <summary>
       /// 获取状态订单
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetStatusOrders(int state);

       /// <summary>
       /// 根据时间获取订单信息
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetYearOrders();

       /// <summary>
       /// 获取今日订单信息
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetTodayOrders();

       /// <summary>
       /// 获取用户订单
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetUserOrders(string userName);

       /// <summary>
       /// 获取用户订单
       /// </summary>
       /// <returns></returns>
       IList<OrdersInfo> GetUserOrders();

        /// <summary>
        /// 获取订单详细信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       OrdersInfo GetOrdersByID(long orderID);

        /// <summary>
        /// 添加订单信息
        /// </summary>
        /// <param name="link"></param>
       void InsertOrders(OrdersInfo order);

       /// <summary>
       /// 获取订单产品信息
       /// </summary>
       /// <returns></returns>
       IList<OrderDetailInfo> GetDerailByID(long orderID);

       /// <summary>
       /// 更新订单信息
       /// </summary>
       /// <returns></returns>
       int UpdateOrderTypeByID(OrdersInfo order);

       /// <summary>
       /// 更新订单状态
       /// </summary>
       /// <returns></returns>
       int UpdateOrderStatusByID(int status,long orderID);

       /// <summary>
       /// 更新订单状态
       /// </summary>
       /// <returns></returns>
       int UpdateOrderPayByID(decimal money, long orderID);

       /// <summary>
       /// 更新订单日期
       /// </summary>
       /// <param name="orderID"></param>
       /// <returns></returns>
       int UpdateOrderDateByID(long orderID);

       /// <summary>
       /// 根据状态获取订单图书信息
       /// </summary>
       /// <param name="bookID"></param>
       /// <param name="status"></param>
       /// <returns></returns>
       bool GetBookByID(int bookID,int status);
    }
}
