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

public partial class user_PwdRecovery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //MembershipCreateStatus result;
        //result = MembershipCreateStatus.Success;
        //Membership.CreateUser("admin", "123456", "adada", "fasd", "fsad", true, "", out result);
        //MembershipUser memUser = Membership.GetUser();
        //successTxt.Text = memUser.GetPassword("不知道");
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
