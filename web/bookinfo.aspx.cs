using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
public partial class bookinfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteInit();
        }
    }

    void SiteInit()
    {
        string bookID = Request.QueryString["bookID"];
        if (bookID != null)
        {
            reviewTxt.Text = Review.GetReview(ReviewType.BookReview, (int.Parse(bookID))).Count.ToString();
        }
        allreview.HRef = "ReviewInfo.aspx?bookID=" +Request.QueryString["bookID"];
        if (Request.IsAuthenticated)
        {
            
            loginUrl.Visible = false;
            reviewName.Text = User.Identity.Name;
            reviewName.Enabled = false;
        }
        else
        {
            reviewName.Text = "匿名用户";
        }
    }
    public IList<BookInfo> bookList(string bookName)
    {
        return Book.GetCatBookByID(bookName);
    }

    public string getRate(int rate)
    {
        string imgs = "";
        if (rate > 0)
        {
            string img = @"<img src='images/art.gif' alt='alt' width='13' height='12' />";
            for (int i = 1; i <= rate; i++)
            {
                imgs += img;
            }
        }
        return imgs;
    }

    public string getCatName(int CatID)
    {
        return Category.GetCategoryByID(CatID).CategoryName;
    }

    public string getStock(int stock)
    {
        string stockTxt = "";
        if (stock > 0)
        {
            stockTxt = "库存充足";
        }
        else
        {
            stockTxt = "<font color=red>缺货</font>";
        }
        return stockTxt;
    }

    public string getStatus(int status)
    {
        string statusName="";
        if (status == 0)
        {
            statusName = "读者";
        }
        else if (status == 1)
        {
            statusName = "译者";
        }
        else if (status == 2)
        {
            statusName = "作者";
        }
        return statusName;
    }


    protected void addBtn_Click(object sender, EventArgs e)
    {
        string bookID = Request.QueryString["bookID"];
        if (validateNum.Text == Session["CheckCode"].ToString())
        {
            Jiaen.Components.ReviewInfo review = new Jiaen.Components.ReviewInfo();
            review.UserName = reviewName.Text;
            review.StatusID = int.Parse(statusList.SelectedValue);
            review.RateID = int.Parse(rateList.SelectedValue);
            review.Content = contentTxt.Text;
            review.IsAuthenticated = Request.IsAuthenticated;
            review.BookID = int.Parse(bookID);
            review.PostIP = Globals.IPAddress;
            Review.InsertReview(review);
            Book.UpdateCount(CountType.ReviewCount, int.Parse(bookID));
            Book.UpdateCount(CountType.Rate, int.Parse(bookID));
            Repeater2.DataBind();
            Response.Redirect("bookInfo.aspx?bookID=" + int.Parse(bookID));
        }
        else
        {
            validateNumTxt.Text = "验证码输入有误,请重新输入验证码";
        }
    }

    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        string bookID = Request.QueryString["bookID"];
        Book.UpdateCount(CountType.BookReadCount, int.Parse(bookID));
    }
}
