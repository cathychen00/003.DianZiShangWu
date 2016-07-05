using System;
using System.Web.Security;

/// <summary>
/// 会员中心-修改资料
/// </summary>
public partial class user_showInfo : System.Web.UI.Page
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
        MembershipUser memUser = Membership.GetUser();
        emailTxt.Text = memUser.Email;
        userTxt.Text = memUser.UserName;
    }

    protected void change_ServerClick(object sender, EventArgs e)
    {
        MembershipUser memUser = Membership.GetUser();
        memUser.Email = emailTxt.Text;
        Membership.UpdateUser(memUser);
        successTxt.Text = "更新成功";
        dataBind();
    }
}
