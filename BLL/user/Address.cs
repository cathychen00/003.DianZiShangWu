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
       /// ��ȡ�ͻ���ַ�б�
       /// </summary>
       /// <returns></returns>
       public static IList<AddressInfo> GetAddress(int userID)
       {
           return addresses.GetAddress(userID);
       }

       /// <summary>
       /// ��ȡ�ض��ͻ���ַ��Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static AddressInfo GetAddressByID()
       {
           return addresses.GetAddressByID();
       }

       /// <summary>
       /// ����ͻ���ַ��Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertAddress(AddressInfo address)
       {
           addresses.InsertAddress(address);
       }

       /// <summary>
       /// ����ͻ���ַ��Ϣ
       /// </summary>
       /// <param name="link"></param>
       public static void InsertAddress(string userName)
       {
           addresses.InsertEmpty(userName);
       }

       /// <summary>
       /// �����ͻ���ַ��Ϣ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateAddress(AddressInfo address)
       {
         return addresses.UpdateAddress(address);
       }

       /// <summary>
       /// �����ͻ���ʽ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateAddressSend(int sendType)
       {
           return addresses.UpdateAddressSend(sendType);
       }

       /// <summary>
       /// ����֧����ʽ
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdateAddressPay(int payType)
       {
           return addresses.UpdateAddressPay(payType);
       }

       /// <summary>
       /// ɾ���ͻ���ַ��Ϣ
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
