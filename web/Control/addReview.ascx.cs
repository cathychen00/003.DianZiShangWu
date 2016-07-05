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
using Jiaen.BLL;
using Jiaen.Components;
public partial class Control_addReview : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Init();
        }
    }

    void Init()
    {
      
        if (Request.IsAuthenticated)
        {
            loginUrl.Visible = false;

            reviewName.Text = Page.User.Identity.Name;
            reviewName.Enabled = false;
        }
        else
        {
            reviewName.Text = "匿名用户";
        }
    }

    protected void addBtn_Click(object sender, EventArgs e)
    {
        if (validateNum.Text == Session["CheckCode"].ToString())
        {
            string bookID = Request.QueryString["bookID"];
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
            Response.Redirect("ReviewInfo.aspx?bookID=" + review.BookID);
        }
        else
        {
            validateNumTxt.Text = "验证码输入有误,请重新输入验证码";
        }

    }
}
