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
public partial class Control_catBook : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataList();
        }
    }

    private BookType type;

    public BookType Type
    {
        set { type = value; }
        get { return type; }
    }

    void dataList()
    {
        
        if (type == BookType.newBook)
        {
            string order = Request.QueryString["order"];
            if (order != null)
            {
                CollectionPager1.DataSource = Book.GetNewBook(int.Parse(order));
            }
            else
            {
                CollectionPager1.DataSource = Book.GetNewBook((int)OrderType.New);
            }
        }
        else if(type == BookType.catID)
        {
            string catID = Request.QueryString["catID"];
            string order = Request.QueryString["order"];
            if (order != null)
            {
                CollectionPager1.DataSource = Book.GetBookByCatID(int.Parse(order), int.Parse(catID));
            }
            else
            {
                CollectionPager1.DataSource = Book.GetBookByCatID((int)OrderType.New, int.Parse(catID));
            }
        }
        else
        {
             CollectionPager1.DataSource = Book.GetBook(Type);
        }
            CollectionPager1.BindToControl = DataList1;
            DataList1.DataSource = CollectionPager1.DataSourcePaged;
    }
}
