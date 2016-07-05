using System;
using System.Web.Security;
using Jiaen.BLL;

/// <summary>
/// 会员注册页面
/// </summary>
public partial class userReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //服务条款
            ServiceTxt.Value = SiteSetting.GetSiteSettings("jiaen").ServiceTxt;
        }
    }


    #region 同意条款
    protected void agree_ServerClick(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    #endregion

    #region 不同意条款
    protected void unagree_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    #endregion

    #region 检测会员名是否存在
    protected void btnCheckName_ServerClick(object sender, EventArgs e)
    {
        if (Membership.GetUser(userTxt.Value) != null)
        {
            Label1.Text = "此用户已被注册，请选择其他用户名";
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
        }
    }
    #endregion

    protected void change_ServerClick(object sender, EventArgs e)
    {
        if (validateNum.Value == Session["CheckCode"].ToString())
        {
            MembershipCreateStatus status;
            Membership.CreateUser(userTxt.Value, password.Value, email.Value, question.Value, answer.Value, true, out status);
            if (status == MembershipCreateStatus.Success)
            {
                try
                {
                    EmailSend es = new EmailSend();
                    es.sendRegEmail(email.Value, userTxt.Value, password.Value);
                }
                catch (Exception ee)
                {
                }
                finally
                {
                    MultiView1.ActiveViewIndex = 3;
                    Address.InsertAddress(userTxt.Value);
                    Roles.AddUserToRole(userTxt.Value, "Member");
                }

            }
            if (status == MembershipCreateStatus.DuplicateEmail)
            {
                DuplicateEmailTxt.Text = "此Email已被注册，请选择填写Email";
            }
        }
        else
        {
            validateNumTxt.Text = "验证码输入有误,请重新输入验证码";
        }
    }

    #region 返回首页
    protected void returnIndex_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    #endregion
}
