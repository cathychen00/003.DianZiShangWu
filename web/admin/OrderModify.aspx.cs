using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
using Jiaen.Controls;
public partial class admin_OrderModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void saveOrder_ServerClick(object sender, EventArgs e)
    {
        OrderTypeCheckBoxList orderTypeList = (OrderTypeCheckBoxList)FormView2.FindControl("OrderTypeCheckBoxList1");
        OrdersInfo order = new OrdersInfo();
        order.IsPass = orderTypeList.Items[0].Selected;
        order.IsPay = orderTypeList.Items[1].Selected;
        order.IsSended = orderTypeList.Items[2].Selected;
        order.IsFinished = orderTypeList.Items[3].Selected;
        order.IsCancel = orderTypeList.Items[4].Selected;
        order.OrderID = Convert.ToInt64(Request.QueryString["orderID"]);
        OrdersInfo orders = Orders.GetOrdersByID(order.OrderID);
        for (int ChBox = 0; ChBox < orderTypeList.Items.Count; ChBox++)
        {
            if (orderTypeList.Items[ChBox].Selected == true)
            {
                order.OrderStatus = ChBox;
            }
        }
        if (!orders.IsSended && order.IsSended)
        {
            //库存
            foreach (OrderDetailInfo detail in Orders.GetDerailByID(order.OrderID))
            {
                Book.UpdateStockCount(detail.BookID, detail.Quantity);
            }
        }
        //if (!orders.IsPay && orderTypeList.Items[1].Selected)
        //{
        //    Orders.UpdateOrderPayByID(orders.NeedPayPrice, order.OrderID);
        //    decimal BalancePrice=(orders.BookPrice-orders.TgPrice)*-1;
        //    Address.UpdateAddressBalance(BalancePrice);
        //}
        if (!orders.IsSended && orderTypeList.Items[2].Selected)
        {
            Orders.UpdateOrderDateByID(order.OrderID);
        }
        Orders.UpdateOrderTypeByID(order);
        Response.Redirect("orderList.aspx");
    }
}
        
        

      


