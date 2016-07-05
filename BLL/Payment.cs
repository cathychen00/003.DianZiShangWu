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
   public class Payment
    {
       private static readonly IPayment payments = DataAccess.CreatePayment();

       /// <summary>
       /// 获取支付方式
       /// </summary>
       /// <returns></returns>
     public static IList<PaymentInfo> GetPayment(int payType)
       {
           return payments.GetPayment(payType);
       }

       /// <summary>
       /// 获取特定支付方式
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static PaymentInfo GetPaymentByID(int paymentID)
       {
           return payments.GetPaymentByID(paymentID);
       }

       /// <summary>
       /// 添加支付方式
       /// </summary>
       /// <param name="link"></param>
       public static void InsertPayment(PaymentInfo payment)
       {
           payments.InsertPayment(payment);
       }

       /// <summary>
       /// 更新支付方式
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int UpdatePayment(PaymentInfo payment)
       {
           return payments.UpdatePayment(payment);
       }

       /// <summary>
       /// 删除支付方式
       /// </summary>
       /// <param name="link"></param>
       /// <returns></returns>
       public static int DeletePayment(PaymentInfo payment)
       {
           return payments.DeletePayment(payment);
       }
    }
}
