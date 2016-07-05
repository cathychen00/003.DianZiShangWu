using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ���ﳵ�ӿ�
    /// </summary>
   public interface IShoppingCart
    {
       /// <summary>
       /// ���빺�ﳵ��Ϣ
       /// </summary>
       /// <param name="bookID"></param>
       void InsertCart(int bookID);

       /// <summary>
       /// �����Ź����ﳵ��Ϣ
       /// </summary>
       /// <param name="bookID"></param>
       void InsertTgCart(int bookID);

       /// <summary>
       /// ������Ϣ
       /// </summary>
       /// <param name="bookID"></param>
       void UpdateCart(int bookID,int quantity,bool isTg);

       /// <summary>
       /// ��֤�û�
       /// </summary>
       /// <param name="anonymousId"></param>
       /// <param name="userName"></param>
       void AuthenticateCart(string anonymousId, string userName);

       /// <summary>
       /// ɾ�����ﳵ
       /// </summary>
       /// <param name="bookID"></param>
       /// <returns></returns>
       void DeleteCart(int bookID, bool isTg);

       /// <summary>
       /// ��ȡ���ﳵ��Ϣ
       /// </summary>
       /// <returns></returns>
       IList<CartInfo> SelectCart();

       /// <summary>
       /// ��ȡ�Ź����ﳵ��Ϣ
       /// </summary>
       /// <returns></returns>
       List<CartInfo> SelectTgCart();

    }
}
