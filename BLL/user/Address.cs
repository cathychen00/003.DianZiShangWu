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
   public class Address
    {
       private static readonly IAddress addresses = DataAccess.CreateAddress();

       /// <summary>
       /// 获取送货地址列表
       /// </summary>
       /// <returns></returns>
       public static IList<AddressInfo> GetAddress(int userID)
       {
           return addresses.GetAddress(userID);
       }

       /// <summary>
       /// 获取特定送货地址信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static AddressInfo GetAddressByID()
       {
           return addresses.GetAddressByID();
       }

       /// <summary>
       /// 添加送货地址信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertAddress(AddressInfo address)
       {
           addresses.InsertAddress(address);
       }

       /// <summary>
       /// 添加送货地址信息
       /// </summary>
       /// <param name="link"></param>
       public static void InsertAddress(string userName)
       {
           addresses.InsertEmpty(userName);
       }

       /// <summary>
       /// 更新送货地址信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateAddress(AddressInfo address)
       {
         return addresses.UpdateAddress(address);
       }

       /// <summary>
       /// 更新送货方式
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateAddressSend(int sendType)
       {
           return addresses.UpdateAddressSend(sendType);
       }

       /// <summary>
       /// 更新支付方式
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateAddressPay(int payType)
       {
           return addresses.UpdateAddressPay(payType);
       }

       /// <summary>
       /// 删除送货地址信息
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeleteAddress(int addressID)
       {
          return addresses.DeleteAddress(addressID);
       }

       public static int UpdateAddressBalance(decimal balance)
       {
           return addresses.UpdateAddressBalance(balance);
       }
   }
}
