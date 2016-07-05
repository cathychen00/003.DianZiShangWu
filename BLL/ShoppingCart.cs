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
   public class ShoppingCart
    {
       private static readonly IShoppingCart carts = DataAccess.CreateShoppingCart();

       /// <summary>
       /// 插入信息
       /// </summary>
       /// <param name="bookID"></param>
      public static void InsertCart(int bookID)
       {
           carts.InsertCart(bookID);
       }

       public static void UpdateCart(int bookID, int quantity, bool isTg)
       {
           carts.UpdateCart(bookID, quantity, isTg);
       }


       /// <summary>
       /// 验证用户
       /// </summary>
       /// <param name="anonymousId"></param>
       /// <param name="userName"></param>
       public static void AuthenticateCart(string anonymousId, string userName)
       {
           carts.AuthenticateCart(anonymousId, userName);
       }

       /// <summary>
       /// 删除购物车
       /// </summary>
       /// <param name="bookID"></param>
       /// <returns></returns>
       public static void DeleteCart(int bookID, bool isTg)
       {
           carts.DeleteCart(bookID, isTg);
       }

       /// <summary>
       /// 从session中获取
       /// </summary>
       /// <returns></returns>
       public static IList<CartInfo> SelectCart()
       {
          return carts.SelectCart();
       }

       public static List<CartInfo> SelectTgCart()
       {
           return carts.SelectTgCart();
       }

       public static void InsertTgCart(int bookID)
       {
           carts.InsertTgCart(bookID);
       }
    }
}
