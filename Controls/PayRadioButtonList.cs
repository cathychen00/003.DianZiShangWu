using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using Jiaen.Components;
using Jiaen.BLL;


namespace Jiaen.Controls
{
   public class PayRadioButtonList : RadioButtonList
    {
       public PayRadioButtonList()
       {

           if (Address.GetAddressByID().SendType==3)
           {
               this.Items.Add(new ListItem("»õµ½¸¶¿î</td><TD width=80%>", "-1"));
           }
           foreach (PaymentInfo pay in Payment.GetPayment(1))
           {
               this.Items.Add(new ListItem(pay.PayName + "£º</td><TD width=80%>" + pay.Dec, pay.PaymentID.ToString()));
           }

           foreach (PaymentInfo pay in Payment.GetPayment(0))
           {
               this.Items.Add(new ListItem(pay.UserName + "£º</td><TD width=80%>" + pay.Dec, pay.PaymentID.ToString()));

           }
           
       }
    }
}
