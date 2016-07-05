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
using TW.Web.UI;
public partial class admin_addBook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            string edit = Request.QueryString["edit"];
            if (edit != null)
            {
                DetailsView1.DefaultMode = DetailsViewMode.Edit;
            }
            else
            {
                DetailsView1.DefaultMode = DetailsViewMode.Insert;
            }
            
        }
    }

    //void dataBind()
    //{
    //    string edit = Request.QueryString["edit"];
    //    BookInfo book = new BookInfo();
    //    if (edit != null)
    //    {
    //        book = Book.GetBookByID(int.Parse(edit));
    //        BookNameTxt.Text = book.BookName;
    //        AllCategoryDropDownList1.SelectedValue = book.Category.ToString();
    //        PriceTxt.Text = string.Format("{0:n}", book.Price);
    //        MemberPriceTxt.Text = string.Format("{0:n}", book.MemberPrice);
    //        BigImageTxt.Text = book.BookImage;
    //        SmallImageTxt.Text = book.BookSmallImage;
    //        //库存数量，是否发布，是否推荐，是否特价，是否热卖，是否允许评论
    //        StockTxt.Text = book.Stock.ToString();
    //        ReleaseChk.Checked = book.IsRelease;
    //        GoodChk.Checked = book.IsGood;
    //        CheapChk.Checked = book.IsCheap;
    //        SaleGoodChk.Checked = book.IsSaleGood;
    //        ReviewEnableChk.Checked = book.ReviewEnable;
    //        //图书简介，作者，出版时间，国际编号，出版社，页数，版次
    //        SmallBookDecTxt.Text=book.SmallBookDec;
    //        BookAuthorTxt.Text=book.BookAuthor;
    //        PublishTimeTxt.Text=book.PublishTime.ToString();
    //        BookISBNTxt.Text=book.BookISBN;
    //        BookPublishTxt.Text=book.BookPublish;
    //        BookPagesTxt.Text=book.BookPages.ToString();
    //        BookEditionsTxt.Text=book.BookEditions;
    //        ExpectChk.Checked= book.IsExpect;
    //        searchTxt.Text=book.SearchKey;
    //        ClassSummaryTxt.Text=book.BookDec;
    //        BookAddBtn.Text = "编辑";
    //    }
    //    else
    //    {
    //        PriceTxt.Text = "0";
    //        MemberPriceTxt.Text = "0";
    //        StockTxt.Text = "0";
    //        BookPagesTxt.Text = "0";
    //        PublishTimeTxt.Text = DateTime.Now.ToShortDateString();
            
    //        BookAddBtn.Text = "新增";
    //    }
    //}

    //protected void BookAddBtn_Click(object sender, EventArgs e)
    //{
    //    string edit = Request.QueryString["edit"];

    //    BookInfo book = new BookInfo();
    //    //图书名字，分类，价格，会员价格,大图,小图
    //    book.BookName = BookNameTxt.Text;
    //    book.Category =int.Parse(AllCategoryDropDownList1.SelectedValue);
    //    book.Price =Convert.ToDecimal(PriceTxt.Text);
    //    book.MemberPrice = Convert.ToDecimal(MemberPriceTxt.Text);
    //    book.BookImage = BigImageTxt.Text;
    //    book.BookSmallImage = SmallImageTxt.Text;
    //    //库存数量，是否发布，是否推荐，是否特价，是否热卖，是否允许评论
    //    book.Stock =int.Parse(StockTxt.Text);
    //    book.IsRelease = ReleaseChk.Checked;
    //    book.IsGood = GoodChk.Checked;
    //    book.IsCheap = CheapChk.Checked;
    //    book.IsSaleGood = SaleGoodChk.Checked;
    //    book.ReviewEnable = ReviewEnableChk.Checked;
    //    //图书简介，作者，出版时间，国际编号，出版社，页数，版次
    //    book.SmallBookDec =SmallBookDecTxt.Text;
    //    book.BookAuthor =BookAuthorTxt.Text;
    //    book.PublishTime =Convert.ToDateTime(PublishTimeTxt.Text);
    //    book.BookISBN= BookISBNTxt.Text;
    //    book.BookPublish = BookPublishTxt.Text;
    //    book.BookPages = Convert.ToInt32(BookPagesTxt.Text);
    //    book.BookEditions = BookEditionsTxt.Text;
    //    //
    //    book.IsExpect = ExpectChk.Checked;
    //    book.SearchKey = searchTxt.Text;
    //    book.BookDec = ClassSummaryTxt.Text;
    //    if (edit != null)
    //    {
    //        book.BookID = int.Parse(edit);
    //        Book.UpdateBook(book);
    //        Response.Redirect("bookList.aspx");
    //    }
    //    else
    //    {
    //        Book.InsertBook(book);
    //        Response.Redirect("bookList.aspx");
    //    }
        
    //}
    protected void ImageUploader1_Uploaded(object sender, EventArgs e)
    {
        TextBox BookImage =(TextBox)DetailsView1.FindControl("BookImage");
        TextBox BookSmallImage = (TextBox)DetailsView1.FindControl("BookSmallImage");
        ImageUploader ImageUploader1 = (ImageUploader)DetailsView1.FindControl("ImageUploader1");
        Label successTxt = (Label)DetailsView1.FindControl("successTxt");
        successTxt.Text = "上传成功";
        BookImage.Text = ImageUploader1.PicSavedPath;
        BookSmallImage.Text = ImageUploader1.PicThumbSavedPath;
    }
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        //Response.Redirect("bookList.aspx");
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        //Response.Redirect("bookList.aspx");
    }
    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        ImageUploader ImageUploader1 = (ImageUploader)DetailsView1.FindControl("ImageUploader1");
        SiteSettings site = SiteSetting.GetSiteSettings("jiaen");
        ImageUploader1.WatermarkText = site.WatermarkText;
        ImageUploader1.WatermarkImage = site.WatermarkFileName;
        ImageUploader1.WatermarkType = (TW.Web.UI.WatermarkType)site.WatermarkType;
    }
}
