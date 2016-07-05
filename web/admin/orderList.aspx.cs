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

public partial class admin_orderList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataClass();
        }
    }

    public static string orderStatus(bool type, string status)
    {
        if (type)
        {
            return "[已" + status+"]";
        }
        else
        {
            return "[未" + status + "]";
        }
    }

    void dataClass()
    {

        string state = Request.QueryString["state"];
        if (state != null)
        {
            switch (state)
            {
                case "1":
                    navi0.Attributes["class"] = "Current_Item";
                    break;

                case "2":
                    navi1.Attributes["class"] = "Current_Item";
                    break;

                case "3":
                    navi2.Attributes["class"] = "Current_Item";
                    break;

                case "4":
                    navi3.Attributes["class"] = "Current_Item";
                    break;
                case "5":
                    navi4.Attributes["class"] = "Current_Item";
                    break;

                case "0":
                    navi5.Attributes["class"] = "Current_Item";
                    break;
                case "6":
                    navi6.Attributes["class"] = "Current_Item";
                    break;
            }
        }
        else
        {
            navi0.Attributes["class"] = "Current_Item";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (searchKey.Text != string.Empty)
        {
            ObjectDataSource1.SelectMethod = "GetOrdersByID";
            ObjectDataSource1.SelectParameters.Clear();
            ObjectDataSource1.SelectParameters.Add("orderID", searchKey.Text);
            if (Jiaen.BLL.Orders.GetOrdersByID(Int64.Parse(searchKey.Text)).OrderID == 0)
            {
                emptyData.Text = "未找到此订单";
                emptyData.Visible = true;
                GridView1.Visible = false;
            }
        }
        else
        {
            ObjectDataSource1.SelectMethod = "GetStatusOrders";
        }
        GridView1.DataBind();
    }
}
