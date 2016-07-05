using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 购物车接口
    /// </summary>
   public interface IShoppingCart
    {
       /// <summary>
       /// 插入购物车信息
       /// </summary>
       /// <param name="bookID"></param>
       void InsertCart(int bookID);

       /// <summary>
       /// 插入团购购物车信息
       /// </summary>
       /// <param name="bookID"></param>
       void InsertTgCart(int bookID);

       /// <summary>
       /// 更新信息
       /// </summary>
       /// <param name="bookID"></param>
       void UpdateCart(int bookID,int quantity,bool isTg);

       /// <summary>
       /// 验证用户
       /// </summary>
       /// <param name="anonymousId"></param>
       /// <param name="userName"></param>
       void AuthenticateCart(string anonymousId, string userName);

       /// <summary>
       /// 删除购物车
       /// </summary>
       /// <param name="bookID"></param>
       /// <returns></returns>
       void DeleteCart(int bookID, bool isTg);

       /// <summary>
       /// 获取购物车信息
       /// </summary>
       /// <returns></returns>
       IList<CartInfo> SelectCart();

       /// <summary>
       /// 获取团购购物车信息
       /// </summary>
       /// <returns></returns>
       List<CartInfo> SelectTgCart();

    }
}
