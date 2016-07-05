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

public partial class Control_Search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string userName = Request.AnonymousID;
        if (Request.IsAuthenticated)
        {
            userName = Page.User.Identity.Name;
        }
        string[] roles = Roles.GetRolesForUser(userName);
        if (roles.Length > 1)
        {
            HyperLink link = (HyperLink)LoginView1.FindControl("HyperLink1");
            link.Visible = true;
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SearchBook.aspx?type=1&bookName=" + txtKeyWord.Value);
    }
    
}
