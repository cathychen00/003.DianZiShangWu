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

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    UserInfo u = new UserInfo();
    //    u.UserID=int.Parse(Session["userid"].ToString());
    //    u.Email = TextBox2.Text;
    //    Users.UpdateUser(UpdateUserType.Info, u);
    //}
    protected void change_ServerClick(object sender, EventArgs e)
    {
        MembershipUser memUser = Membership.GetUser();
        memUser.Email = emailTxt.Text;
        Membership.UpdateUser(memUser);
        successTxt.Text = "更新成功";
        dataBind();
    }
}
