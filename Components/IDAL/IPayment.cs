using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 支付方式接口
    /// </summary>
    public interface IPayment
    {

        /// <summary>
        /// 获取支付方式
        /// </summary>
        /// <returns></returns>
        IList<PaymentInfo> GetPayment(int payType);

        /// <summary>
        /// 获取特定支付方式
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        PaymentInfo GetPaymentByID(int paymentID);

        /// <summary>
        /// 添加支付方式
        /// </summary>
        /// <param name="link"></param>
        void InsertPayment(PaymentInfo payment);

        /// <summary>
        /// 更新支付方式
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdatePayment(PaymentInfo payment);

        /// <summary>
        /// 删除支付方式
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeletePayment(PaymentInfo payment);

    }
}
