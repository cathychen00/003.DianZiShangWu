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
using System.IO;
using System.IO.Compression;
using Jiaen.Components;
using Jiaen.BLL;
public partial class admin_addDownLoad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        //Response.Redirect("downList.aspx");
    }
    protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
    {
        Response.Redirect("downList.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
            FileUpload FileUpload1 = (FileUpload)DetailsView1.FindControl("FileUpload1");
            TextBox fileTxt = (TextBox)DetailsView1.FindControl("fileTxt");
            TextBox flieSize = (TextBox)DetailsView1.FindControl("flieSize");
        
            String path = Server.MapPath("~/Uploads/");

                String fileExtension =
                   System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                try
                {
                    string saveName =  DateTime.Now.ToString("yyyyMMddhhmmss") + fileExtension;
                    FileUpload1.PostedFile.SaveAs(path + saveName);
                    fileTxt.Text = "~/Uploads/" + saveName;
                    flieSize.Text = FileUpload1.PostedFile.ContentLength.ToString();
                }
                catch (Exception ex)
                {
                    
                }
    }


    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //DownLoadInfo down = (DownLoadInfo)e.InputParameters[0];
        //Response.Write(fileSize.Text);
        //down.Size = int.Parse(fileSize.Text);
    }
}
