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
using Jiaen.Components;
using Jiaen.BLL;
using Jiaen.Controls;

//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

public partial class Control_bookList : System.Web.UI.UserControl
{
    private BookType type;

    public BookType Type
    {
        set { type = value; }
        get { return type; } 
    }
   
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataList();
        }
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
       
        else if (type == BookType.catID)
        {
            string catID = Request.QueryString["catID"];
            string order = Request.QueryString["order"];
            if (order != null)
            {
                
                    CollectionPager1.DataSource = Book.GetBookByParentID(int.Parse(order), int.Parse(catID));
            }
            else
            {
                
                    CollectionPager1.DataSource = Book.GetBookByParentID((int)OrderType.New, int.Parse(catID));
            }
        }

        else if (type == BookType.cheap)
        {
            string rebate = Request.QueryString["rebate"];
            string tg = Request.QueryString["tg"];
            if (rebate != null)
            {
                CollectionPager1.DataSource = Book.GetCheapBook(int.Parse(rebate));

            }
            else if (tg != null)
            {
                CollectionPager1.DataSource = Book.GetTgBook();
            }
            else
            {
                CollectionPager1.DataSource = Book.GetCheapBook((int)CheapType.All);
            }
        }

        else if (type == BookType.topSale)
        {
            string year = Request.QueryString["year"];
            string month = Request.QueryString["month"];
            string catID = Request.QueryString["catID"];
            if (year != null && month != null && catID != null)
            {
                CollectionPager1.DataSource = Book.GetTopBook(DateTime.Now.Year, DateTime.Now.Month);
            }
            else
            {
                CollectionPager1.DataSource = Book.GetTopBook(int.Parse(year), int.Parse(month), int.Parse(catID), CatType.Small);
            }
        }

        else if (type == BookType.Search)
        {

            string press = Request.QueryString["press"];
            string bookName = Request.QueryString["bookName"];
            string searchType = Request.QueryString["type"];
            string author = Request.QueryString["author"];
            string cat = Request.QueryString["cat"];
            string ISBN = Request.QueryString["ISBN"];
            string price = Request.QueryString["price"];
            string operatorList = Request.QueryString["operator"];
            string Year = Request.QueryString["Year"];
            string Month = Request.QueryString["Month"];
            if (searchType=="0" && press != null)
            {
                CollectionPager1.DataSource = Book.GetSearchBook(int.Parse(searchType), press);
            }
            else if (searchType =="1" && bookName != null)
            {
                CollectionPager1.DataSource = Book.GetSearchBook(int.Parse(searchType), bookName);
            }
            else if (searchType =="2")
            {
               Jiaen.SQLServerDAL.Book a = new Jiaen.SQLServerDAL.Book();
               //Label bookName=(Label)Page.PreviousPage.FindControl("bookName");
               //Label bookPublish = (Label)Page.PreviousPage.FindControl("bookPublish");
               //Label bookAuthor = (Label)Page.PreviousPage.FindControl("bookAuthor");
               //AllCategoryDropDownList bookCategory = (AllCategoryDropDownList)Page.PreviousPage.FindControl("bookCategory");
               //Label bookISBN = (Label)Page.PreviousPage.FindControl("bookISBN");
               //Label bookPrice = (Label)Page.PreviousPage.FindControl("bookPrice");
               //DropDownList operatorList = (DropDownList)Page.PreviousPage.FindControl("operatorList");
               //AllYearDropDownList publishYear = (AllYearDropDownList)Page.PreviousPage.FindControl("publishYear");
               //DropDownList publishMonth = (DropDownList)Page.PreviousPage.FindControl("publishMonth");
                string[] key = new string[9];
                key[0] = bookName;
                key[1] = press;
                key[2] = author;
                key[3] = cat;
                key[4] = ISBN;
                key[5] = price;
                key[6] = operatorList;
                key[7] = Year;
                key[8] = Month;
                CollectionPager1.DataSource = a.GetAdvanceSearchBook(key);
            }
            else
            {
                CollectionPager1.DataSource = Book.GetNewBook(0);
            }
        }
        else if (type == BookType.Teacher)
        {
            string ID = Request.QueryString["ID"];

            if (ID != null)
            {
                CollectionPager1.DataSource = Book.GetTeacherBook(1, int.Parse(ID));
            }
        }
        else if (type == BookType.Catena)
        {
            string ID = Request.QueryString["ID"];

            if (ID != null)
            {
                CollectionPager1.DataSource = Book.GetBookByCatID(6, int.Parse(ID));
            }
            else
            {
                CollectionPager1.DataSource = Book.GetBook(type);
            }
        }
        else
        {
            CollectionPager1.DataSource = Book.GetBook(type);
        }
        CollectionPager1.BindToControl = DataList1;
        DataList1.DataSource = CollectionPager1.DataSourcePaged;
    }
}
