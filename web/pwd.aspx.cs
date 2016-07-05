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

public partial class pwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //MembershipUser u = Membership.GetUser("admin", false);
        //string a = u.GetPassword("89459871");
        //Response.Write(a);
    }

    protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
    {

        //e.Message.Body = string.Format("<% UserName %>Password: <% Password %>", TextBox1.Text);
    }
}
