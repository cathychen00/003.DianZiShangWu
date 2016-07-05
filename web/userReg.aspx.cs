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
public partial class userReg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            ServiceTxt.Value = SiteSetting.GetSiteSettings("jiaen").ServiceTxt;
        }
    }

    //protected void CreateUserWizard3_CreatedUser(object sender, EventArgs e)
    //{
    //    TextBox userNameTxt =
    //      (TextBox)CreateUserWizard3.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
    //    Address.InsertAddress(userNameTxt.Text);
    //}
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
    protected void agree_ServerClick(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void returnIndex_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void unagree_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
    protected void Button1_ServerClick(object sender, EventArgs e)
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
}
