using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// �û��ͻ���Ϣ�ӿ�
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// ��ȡ�ͻ���ַ�б�
        /// </summary>
        /// <returns></returns>
        IList<AddressInfo> GetAddress(int userID);

        /// <summary>
        /// ��ȡ�ض��ͻ���ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        AddressInfo GetAddressByID();

        /// <summary>
        /// ����ͻ���ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertAddress(AddressInfo Address);

        /// <summary>
        /// �����ͻ���ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateAddress(AddressInfo Address);

        /// <summary>
        /// �����ͻ���ʽ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateAddressSend(int sendType);

        int UpdateAddressPay(int payType);

        /// <summary>
        /// ɾ���ͻ���ַ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteAddress(int AddressID);

        void InsertEmpty(string userName);

        int UpdateAddressBalance(decimal balance);

    }
}
