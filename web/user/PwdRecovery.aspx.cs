using System;
using System.Web.Security;

public partial class user_PwdRecovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void change_ServerClick(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        try
        {
            if (user.ChangePassword(oldPasswordTxt.Text, newPasswordTxt.Text))
            {
                successTxt.Text = "成功：密码修改成功!";
            }
            else
            {
                successTxt.Text = "错误：原密码错误，请重新输入";
            }
        }
        catch (Exception ex)
        {
            successTxt.Text = ex.Message;
        }
        
    }
}
