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
   public class SendRadioButtonList:RadioButtonList
    {
       public SendRadioButtonList()
       {
//           string a = @"<TD width=80%>
//                              <P>到货时间：4天送货上门&nbsp;&nbsp;&nbsp;<FONT 
//                              color=#ff6600>（推荐）</FONT><BR>收费标准：<BR>定价合计小于等于40元按 
//                              10 元收取<BR>定价合计大于40元每增加40元续费 4 元</P>";
           //string b="<td><br>&nbsp;［配送价格" + string.Format("{0:c}", send.Price) + "］<br>&nbsp;&nbsp;&nbsp;" + send.Dec;
           foreach (SendInfo send in Send.GetSend())
           {
               this.Items.Add(new ListItem(send.Name + "：</td><TD width=80%>价格" +string.Format("{0:c}",send.Price)+"&nbsp;&nbsp;"+send.Dec, send.SendID.ToString()));
              
           }
       }
    }
}
