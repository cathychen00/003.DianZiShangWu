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
public partial class admin_addImageBook : System.Web.UI.Page
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
            //dataBind();
        }
    }

    //void dataBind()
    //{
    //    string edit = Request.QueryString["edit"];
    //    if (edit != null)
    //    {
    //        ImageBookInfo item = new ImageBookInfo();
    //        item = ImageBook.GetImageBookByID(int.Parse(edit));
    //        imageBookURL.Text = item.ImageURL;
    //        LinkUrlTxt.Text = item.LinkURL;
    //        stationList.SelectedValue = item.ImageStation.ToString();
    //        IndexChk.Checked = item.IsMain;
    //        addBtn.Text = "编辑";
    //    }
    //    else
    //    {
    //        addBtn.Text = "新增";
    //    }
    //}
    //protected void addBtn_Click(object sender, EventArgs e)
    //{
    //    string edit = Request.QueryString["edit"];
    //    ImageBookInfo imageBook = new ImageBookInfo();
    //    imageBook.ImageURL = imageBookURL.Text;
    //    imageBook.LinkURL = LinkUrlTxt.Text;
    //    imageBook.ImageStation =int.Parse(stationList.SelectedValue);
    //    imageBook.IsMain = IndexChk.Checked;
        
    //    if (edit != null)
    //    {
    //        imageBook.ImageID = int.Parse(edit);
    //        ImageBook.UpdateImageBook(imageBook);
    //        Response.Redirect("imageBook.aspx");
    //    }
    //    else
    //    {
    //        ImageBook.InsertImageBook(imageBook);
    //        Response.Redirect("imageBook.aspx");
    //    }
    //}
    //protected void ImageUploader1_Uploaded(object sender, EventArgs e)
    //{
    //    successTxt.Text = "上传成功";
    //    imageBookURL.Text = ImageUploader1.PicSavedPath;
    //}

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        Response.Redirect("imageBook.aspx");
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Response.Redirect("imageBook.aspx");
    }
}
