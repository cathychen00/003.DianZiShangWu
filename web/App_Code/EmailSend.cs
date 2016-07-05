using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Jiaen.Components;
using Jiaen.BLL;
using Jiaen.Components.Utility;
using System.IO;
/// <summary>
/// EmailSend 的摘要说明
/// </summary>
public class EmailSend
{

   public readonly string siteName = SiteSetting.GetSiteSettings("jiane").SiteName;
    
    
    /// <summary>
    /// 注册发送
    /// </summary>
   public void sendRegEmail(string email,string userName,string pwd)
    {
        EmailFormatInfo emailFormat = EmailFormat.GetEmailFormatByID(1);
        if (emailFormat.IsSend)
        {
            MailUtility ma = new MailUtility();
            string subject = string.Format(emailFormat.EmailTitle, userName);
            string body = string.Format(emailFormat.EmailTemplete, userName, siteName, pwd);
            ma.SetMail(email, subject, body);
        }
    }

    /// <summary>
    /// 定单生成
    /// </summary>
    public void sendOrderEmail(string orderID, string money)
    {
        MembershipUser user = Membership.GetUser();
        EmailFormatInfo emailFormat = EmailFormat.GetEmailFormatByID(4);
        if (emailFormat.IsSend)
        {
            MailUtility ma = new MailUtility();
            string subject = string.Format(emailFormat.EmailTitle, siteName);
            string body = string.Format(emailFormat.EmailTemplete, siteName, user.UserName, orderID, money);
            ma.SetMail(user.Email, subject, body);
        }
    }

    /// <summary>
    /// 找回密码
    /// </summary>
    public void sendPwdEmail()
    {
        EmailFormatInfo emailFormat = EmailFormat.GetEmailFormatByID(2);
        string path = HttpContext.Current.Request.PhysicalApplicationPath + "/PasswordRecoveryMail.txt";
        string appendText = HttpContext.Current.Server.HtmlDecode(emailFormat.EmailTemplete);
        File.WriteAllText(path, appendText,System.Text.Encoding.UTF8);
    }
}
