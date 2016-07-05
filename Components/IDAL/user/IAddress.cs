using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 用户送货信息接口
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// 获取送货地址列表
        /// </summary>
        /// <returns></returns>
        IList<AddressInfo> GetAddress(int userID);

        /// <summary>
        /// 获取特定送货地址信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        AddressInfo GetAddressByID();

        /// <summary>
        /// 添加送货地址信息
        /// </summary>
        /// <param name="link"></param>
        void InsertAddress(AddressInfo Address);

        /// <summary>
        /// 更新送货地址信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateAddress(AddressInfo Address);

        /// <summary>
        /// 更新送货方式
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateAddressSend(int sendType);

        int UpdateAddressPay(int payType);

        /// <summary>
        /// 删除送货地址信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteAddress(int AddressID);

        void InsertEmpty(string userName);

        int UpdateAddressBalance(decimal balance);

    }
}
