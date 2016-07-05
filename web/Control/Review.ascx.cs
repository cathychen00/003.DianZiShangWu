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
public partial class Control_Review : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            dataList();
        }
    }
    void dataList()
    {
        string bookID = Request.QueryString["bookID"];
        if (bookID != null)
        {
            CollectionPager1.DataSource = Review.GetReview(ReviewType.BookReview, (int.Parse(bookID)));
        }
        CollectionPager1.BindToControl = Repeater1;
        Repeater1.DataSource = CollectionPager1.DataSourcePaged;
    }

    public string getRate(int rate)
    {
        string imgs = "";
        string img = @"<img src='images/art.gif' alt='alt' width='13' height='12' />";
        for (int i = 1; i <= rate; i++)
        {
            imgs += img;
        }
        return imgs;
    }

    public string getStatus(int status)
    {
        string statusName = "";
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
}
