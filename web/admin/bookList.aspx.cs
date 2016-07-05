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
public partial class admin_bookList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind();
        }
    }

    void dataBind()
    {
        if (AllCategoryDropDownList1.SelectedValue == "0" && searchKey.Text==string.Empty)
        {
            GridView1.DataSource = Book.GetBook(BookType.newBook);
        }
        else if (searchKey.Text != string.Empty)
        {
            GridView1.DataSource = Book.GetSearchBook(1, searchKey.Text);
        }
        else
        {
            GridView1.DataSource = Book.GetBookByParentID(1, int.Parse(AllCategoryDropDownList1.SelectedValue));
        }
        GridView1.DataBind();
    }

    public string getStock(int stock)
    {
        string stockTxt = "<font color=red>"+stock.ToString()+"</font>";
        if (stock > 5)
        {
            stockTxt = stock.ToString();
        }
        return stockTxt;
    }
    
    protected void Button3_Click(object sender, EventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            if (ischeck)
            {
                if (Orders.GetBookByID(intfavID, 1))
                {
                    JScript.Alert("此书已经有人购买，请不要删除.你可以修改此书信息");
                }
                else
                {
                    Book.DeleteBook(intfavID);
                    if (Orders.GetBookByID(intfavID, 2))
                    {
                        FavBook.DeleteFavBookByID(intfavID);
                    }

                }
                //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
            }
        }
        dataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int rowindex = 0; rowindex < this.GridView1.Rows.Count; rowindex++)
        {
            bool ischeck = ((CheckBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("chk")).Checked;
            string price = ((TextBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("Price")).Text;
            string memberPrice = ((TextBox)this.GridView1.Rows[rowindex].Cells[0].FindControl("MemberPrice")).Text;
            int intfavID = Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value);
            if (ischeck)
            {
                BookInfo book = new BookInfo();
                book.Price = Convert.ToDecimal(price);
                book.MemberPrice = Convert.ToDecimal(memberPrice);
                book.BookID = intfavID;
                Book.UpdatePrice(book);
                //删除Convert.ToInt32(this.GridView1.DataKeys[rowindex].Value)
            }
        }
        dataBind();
    }
   
   
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        dataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = Book.GetSearchBook(1, searchKey.Text);
        GridView1.DataBind();
    }
    protected void DropDownList1_TextChanged(object sender, EventArgs e)
    {
        searchKey.Text = string.Empty;
        dataBind();
    }
}
