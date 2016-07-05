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

public partial class ReviewInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
}
