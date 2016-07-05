using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components.Utility;
using Jiaen.Components;
using Jiaen.BLL;
public partial class topsale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitList();
            dataList();
        }
    }

    void InitList()
    {
        string year = Request.QueryString["year"];
        string month = Request.QueryString["month"];
        if (year != null && month != null)
        {
            YearDropDownList1.SelectedValue = year;
            MonthDropDownList1.SelectedValue = month;
        }
        else
        {
            YearDropDownList1.SelectedValue = DateTime.Now.Year.ToString();
            MonthDropDownList1.SelectedValue = DateTime.Now.Month.ToString();
        }

    }

    void dataList()
    {
        string sortType = Request.QueryString["sorttype"];
        string strSmallSort = Request.QueryString["smallSort"];
        string year = Request.QueryString["year"];
        string month = Request.QueryString["month"];
        if (strSmallSort!=null)
        {
            int intyear = int.Parse(YearDropDownList1.SelectedValue);
            int intmonth = int.Parse(MonthDropDownList1.SelectedValue);
            int smallSort = int.Parse(strSmallSort);
            Repeater1.DataSource = Book.GetTopBook(intyear, intmonth, smallSort, CatType.Small);
        }
        
        else if (year != null && month != null)
        {
            Repeater1.DataSource = Book.GetTopBook(int.Parse(year), int.Parse(month));
        }
        else
        {
            Repeater1.DataSource = Book.GetTopBook(DateTime.Now.Year, DateTime.Now.Month);
        }
        Repeater1.DataBind();
    }

    public IList<CategoryInfo> dataCategory(int id)
    {
        return Category.GetCategory(CategoryType.ParesentBook, id);
    }

    protected void Repeater3_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "catSet")
        {
            string index = e.CommandArgument.ToString();
            string url = "topsale.aspx?year=" + YearDropDownList1.SelectedValue;
            url += "&month=" + MonthDropDownList1.SelectedValue;
            url += "&smallSort=" + index;
            Response.Redirect(url);
            MonthDropDownList1.SelectedValue = Request.QueryString["year"].ToString();
            
        }
        //Label CategoryID = (Label)e.Item.FindControl("CategoryID");
        //LinkButton lbtnSelected = ((LinkButton)e.CommandSource);
        
       
        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = "topsale.aspx?year=" + YearDropDownList1.SelectedValue;
        url += "&month=" + MonthDropDownList1.SelectedValue;
        Response.Redirect(url);
    }
}
