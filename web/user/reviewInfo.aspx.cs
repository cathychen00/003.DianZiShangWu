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
public partial class user_review : System.Web.UI.Page
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
        //int id=int.Parse(Session["userid"].ToString());
        //CollectionPager1.DataSource = Review.GetReview(ReviewType.UserReview,"AA");
        //CollectionPager1.BindToControl =DataList1;
        //DataList1.DataSource = CollectionPager1.DataSourcePaged;
    }
        
}
