using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.ComponentModel;
using System.Configuration;
using Jiaen.Components;
using Jiaen.BLL;

namespace Jiaen.Controls
{
   public class OrderTypeCheckBoxList:CheckBoxList
    {
       public OrderTypeCheckBoxList()
       {
           this.RepeatDirection = RepeatDirection.Horizontal;
           this.Items.Add(new ListItem("�Ƿ������","0"));
           this.Items.Add(new ListItem("�Ƿ��Ѹ���", "1"));
           this.Items.Add(new ListItem("�Ƿ��ѷ���", "2"));
           this.Items.Add(new ListItem("�Ƿ��ѹ鵵", "3"));
           this.Items.Add(new ListItem("�Ƿ���ȡ������", "4"));
           string orderID=HttpContext.Current.Request.QueryString["orderID"];
           this.Items[0].Selected = Orders.GetOrdersByID(Convert.ToInt64(orderID)).IsPass;
           this.Items[1].Selected = Orders.GetOrdersByID(Convert.ToInt64(orderID)).IsPay;
           this.Items[2].Selected = Orders.GetOrdersByID(Convert.ToInt64(orderID)).IsSended;
           this.Items[3].Selected = Orders.GetOrdersByID(Convert.ToInt64(orderID)).IsFinished;
           this.Items[4].Selected = Orders.GetOrdersByID(Convert.ToInt64(orderID)).IsCancel;
       }
    }
}
