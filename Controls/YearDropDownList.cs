using System;
using System.IO;
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
   public class YearDropDownList:DropDownList
    {
       public YearDropDownList()
       {
           foreach (OrdersInfo order in Orders.GetYearOrders())
           {
               this.Items.Add(new ListItem(order.Year.ToString()+"Äê", order.Year.ToString()));
           }
       }
    }
}
