using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Data;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;
using System.Web;
namespace Jiaen.Components.Utility
{
    /// <summary>
    /// �ʼ�������
    /// </summary>
    public class MailUtility
    {

        //��ȡSMTP����
        public MailSettings GetSmtpSettings()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            SmtpSection smtp = (SmtpSection)config.GetSection("system.net/mailSettings/smtp");
            MailSettings SmtpSettings;
            SmtpSettings.MailServer = smtp.Network.Host;
            SmtpSettings.MailUser = smtp.Network.UserName;
            SmtpSettings.MailPassword = smtp.Network.Password;
            SmtpSettings.MailFrom = smtp.From;
            SmtpSettings.MailPort = smtp.Network.Port;

            return SmtpSettings;
        }

        //�����֤
        private NetworkCredential GetCredentials(MailSettings SmtpSettings)
        {
            string user = SmtpSettings.MailUser;
            string PassWord = SmtpSettings.MailPassword;
            NetworkCredential myCredentials = new NetworkCredential(user, PassWord);
            return myCredentials;
        }

        
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="MsgTo">����Ŀ���ַ</param>
        /// <param name="MsgSubject">��������</param>
        /// <param name="MsgText">����</param>
        public void SetMail(string MsgTo,string MsgSubject, string MsgText)
        {
            MailSettings SmtpSettings;
            SmtpSettings = GetSmtpSettings();
            SmtpClient SmptCl = new SmtpClient(SmtpSettings.MailServer, SmtpSettings.MailPort);
            SmptCl.Credentials = GetCredentials(SmtpSettings);
            MailMessage MailMsg = new MailMessage(SmtpSettings.MailFrom, MsgTo);
            MailMsg.BodyEncoding = Encoding.UTF8;
            MailMsg.Subject = MsgSubject;
            MailMsg.Body = MsgText;
            MailMsg.IsBodyHtml = true;
            SmptCl.Send(MailMsg);
        }
    }
    /// <summary>
    /// �ʼ�����
    /// </summary>
    public struct MailSettings
    {
        public string MailServer;
        public int MailPort;
        public string MailFrom;
        public string MailUser;
        public string MailPassword;

    }
}
