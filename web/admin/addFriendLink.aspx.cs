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

//该源码下载自www.51aspx.com(５１ａｓｐｘ．ｃｏｍ)

public partial class admin_addFriendLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dataBind();
        }
    }

    void dataBind()
    {
        string edit = Request.QueryString["edit"];
        if (edit != null)
        {
            FriendLinkInfo f = new FriendLinkInfo();
            f = FriendLink.GetLinkByID(int.Parse(edit));
            LinkNameTxt.Text = f.LinkName;
            LinkIndexChk.Checked = f.IsMain;
            LinkUrlTxt.Text = f.LinkURL;
            LinkLogoTxt.Text = f.LinkLogo;
            LinkAddBtn.Text = "编辑";
        }
        else
        {
            LinkAddBtn.Text = "新增";
        }
    }

    protected void LinkAddBtn_Click(object sender, EventArgs e)
    {
        string edit = Request.QueryString["edit"];
        FriendLinkInfo f = new FriendLinkInfo();
        f.LinkName = LinkNameTxt.Text;
        f.IsMain = LinkIndexChk.Checked;
        f.LinkURL = LinkUrlTxt.Text;
        f.LinkLogo = LinkLogoTxt.Text;
        if (edit != null)
        {
            f.LinkID = int.Parse(edit);
            FriendLink.UpdateLink(f);
            Response.Redirect("friendLink.aspx");
        }
        else
        {
            FriendLink.InsertLink(InsertLinkType.Arrowed, f);
            Response.Redirect("friendLink.aspx");
        }

    }
}
