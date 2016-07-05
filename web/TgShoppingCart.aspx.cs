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
public partial class TgShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Insert();
            sumCount();
        }
        
    }

    void Insert()
    {
        string bookID = Request.QueryString["bookID"];
        if (bookID != null)
        {
            if (Book.GetBookByID(int.Parse(bookID)).Stock <= 0)
            {
                JScript.Alertto("此书库存不足，正在补货中", "default.aspx");
            }
            else if (Book.GetBookByID(int.Parse(bookID)).IsExpect)
            {
                JScript.Alertto("此书为期书,无法购买", "default.aspx");
            }
            else if (!Book.GetBookByID(int.Parse(bookID)).IsRelease)
            {
                JScript.Alertto("此书不参与团购,无法购买", "default.aspx");
            }
            else
            {
                Jiaen.BLL.ShoppingCart.InsertTgCart(int.Parse(bookID));
                Response.Redirect("TgShoppingCart.aspx");
            }
        }
    }

    void sumCount()
    {
        if (GridView1.Rows.Count == 0)
        {
            numTxt.Text = "0";
            allNumTxt.Text = "0";
            CartPriceTxt.Text = string.Format("{0:c}", 0);
            tgAllPriceTxt.Text = string.Format("{0:c}", 0);
            Session["tgorderPrice"] = CartPriceTxt.Text;
            Session["tgPrice"] = tgAllPriceTxt.Text;
        }
    }

    protected void deleteBtn_Click(object sender, ImageClickEventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            int bookID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            Jiaen.BLL.ShoppingCart.DeleteCart(bookID,true);
        }
        GridView1.DataBind();
        sumCount();
    }

    protected void updateBtn_Click(object sender, ImageClickEventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            TextBox quantityTxt = ((TextBox)GridView1.Rows[rowindex].Cells[0].FindControl("quantityTxt"));
            int bookID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            int quantity = Convert.ToInt32(quantityTxt.Text);
            Jiaen.BLL.ShoppingCart.UpdateCart(bookID, quantity,true);
        }
        GridView1.DataBind();
        sumCount();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        int a = 0;
        decimal sumPirceTxt = 0;
        decimal backSumPrice = 0;
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            ((RangeValidator)GridView1.Rows[rowindex].Cells[0].FindControl("RangeValidator1")).MinimumValue = SiteSetting.GetSiteSettings("jiaen").TgNum.ToString();
           
            TextBox quantityTxt = ((TextBox)GridView1.Rows[rowindex].Cells[0].FindControl("quantityTxt"));

            Label Price = ((Label)GridView1.Rows[rowindex].Cells[0].FindControl("Price"));
            Label vipPrice = ((Label)GridView1.Rows[rowindex].Cells[0].FindControl("vipPrice"));
            Decimal PirceTxt = Convert.ToDecimal(Price.Text);
            Decimal vipPriceTxt = Convert.ToDecimal(vipPrice.Text);

            int quantity = Convert.ToInt32(quantityTxt.Text);
            a += quantity;
            decimal allPirce = PirceTxt * quantity;
            decimal backPrice = vipPriceTxt * quantity;
            sumPirceTxt += allPirce;
            backSumPrice += backPrice;
            //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
        }

        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Separator)
        {
            //int quantity = int.Parse(e.Row.Cells[2].Text);
            Label allPirceTxt = ((Label)e.Row.FindControl("allPirceTxt"));
            Label Price = ((Label)e.Row.FindControl("vipPrice"));
            Decimal PirceTxt = Convert.ToDecimal(Price.Text);
            TextBox quantity = ((TextBox)e.Row.FindControl("quantityTxt"));
            int num = int.Parse(quantity.Text);
            Price.Text = PirceTxt.ToString().Substring(0, 5);
            allPirceTxt.Text = string.Format("{0:c}", PirceTxt * num);

        }
        numTxt.Text = GridView1.Rows.Count.ToString();
        allNumTxt.Text = a.ToString();
        CartPriceTxt.Text = string.Format("{0:c}", sumPirceTxt);
        tgAllPriceTxt.Text = string.Format("{0:c}", backSumPrice);
        Session["tgorderPrice"] = CartPriceTxt.Text;
        Session["tgPrice"] = tgAllPriceTxt.Text;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (GridView1.Rows.Count > 0)
        {
            Response.Redirect("tgshoppingorder.aspx");
        }
        else
        {
            Label1.Text = "商品数量不得少于0";
        }
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
        GridView1.DataBind();
        sumCount();
    }
}
