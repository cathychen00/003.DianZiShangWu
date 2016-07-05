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
public partial class preview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox fileTxt = (TextBox)DetailsView1.FindControl("fileTxt");
            TextBox flieSize = (TextBox)DetailsView1.FindControl("flieSize");
            fileTxt.Text = string.Empty;
            flieSize.Text = "0";
        }
    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
    {
        DetailsView1.Visible = false;
        LinkButton1.Visible = true;
        LinkButton1.Text = "上传成功";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean fileOK = false;
        bool filesizeOK = false;
        FileUpload FileUpload1 = (FileUpload)DetailsView1.FindControl("FileUpload1");
        TextBox fileTxt = (TextBox)DetailsView1.FindControl("fileTxt");
        TextBox flieSize = (TextBox)DetailsView1.FindControl("flieSize");
        Button btn = (Button)DetailsView1.FindControl("Button1");
        Label Label1 = (Label)DetailsView1.FindControl("Label1");
        String path = Server.MapPath("~/Uploads/");
       
        String fileExtension =
           System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
        //判断类型
        String[] allowedExtensions = 
                { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".rar", ".zip", ".pdf" };
        for (int i = 0; i < allowedExtensions.Length; i++)
        {
            if (fileExtension == allowedExtensions[i])
            {
                fileOK = true;
            }

        }
        if (fileOK)
        {
            if (FileUpload1.FileBytes.Length <= 1048576 * 3)
            {
                filesizeOK = true;
            }
            else
            {
                LinkButton1.Text = "文件必须小于3m";
            }
            //开始上传
            if (filesizeOK)
            {
                try
                {
                    string saveName = DateTime.Now.ToString("yyyyMMddhhmmss") + fileExtension;
                    FileUpload1.PostedFile.SaveAs(path + saveName);
                    fileTxt.Text = "~/Uploads/" + saveName;
                    flieSize.Text = FileUpload1.PostedFile.ContentLength.ToString();
                    FileUpload1.Visible = false;
                    btn.Visible = false;
                    Label1.Visible = true;
                    Label1.Text = "上传成功";
                    Label2.Visible = false;
                    LinkButton1.Visible = false;
                }
                catch (Exception ex)
                {
                    Label1.Text = "上传失败";
                }
            }
        }
        else
        {
            Label2.Visible = true;
        }
    }

    protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        TextBox fileTxt = (TextBox)DetailsView1.FindControl("fileTxt");
        TextBox flieSize = (TextBox)DetailsView1.FindControl("flieSize");
        DownLoadInfo down = (DownLoadInfo)e.InputParameters[0];
        down.DownURL = fileTxt.Text;
        down.Size =int.Parse(flieSize.Text);
        down.ID = 6;
        
    }
}
