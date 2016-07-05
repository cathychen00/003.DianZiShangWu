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
public partial class user_favBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addCart();
            addFav();
        }
    }

    void addCart()
    {
        string bookID = Request.QueryString["buyID"];
        if (bookID != null)
        {
           Jiaen.BLL.ShoppingCart.InsertCart(int.Parse(bookID));
            Response.Redirect("../ShoppingCart.aspx");
        }
    }

    void addFav()
    {
        string bookID = Request.QueryString["bookID"];
        if (bookID != null)
        {
            FavBook.InsertFavBook(int.Parse(bookID));
            Response.Redirect("favBookInfo.aspx");
        }
    }

    protected void deleteBtn_Click(object sender, EventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            if (ischeck)
            {
                FavBook.DeleteFavBook(intfavID);
                //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
            }
        }
        GridView1.DataBind();
    }
    protected void AddToCartBtn_Click(object sender, EventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            string bookID = ((Label)this.GridView1.Rows[rowindex].Cells[0].FindControl("bookID")).Text;
            if (ischeck)
            {
                Jiaen.BLL.ShoppingCart.InsertCart(int.Parse(bookID));
                //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
            }
        }
        GridView1.DataBind();
    }
}
