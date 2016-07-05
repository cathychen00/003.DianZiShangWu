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
using System.Net.Configuration;
using Jiaen.BLL;
public partial class admin_smtpServer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    void bind()
    {
        SmtpSection smtp=SiteSetting.getSMTP();
        host.Text = smtp.Network.Host;
        userName.Text = smtp.Network.UserName;
        password.Text = smtp.Network.Password;
        from.Text = smtp.From;
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SiteSetting.saveSMTP(host.Text, userName.Text, password.Text, from.Text);
        bind();
    }
}
