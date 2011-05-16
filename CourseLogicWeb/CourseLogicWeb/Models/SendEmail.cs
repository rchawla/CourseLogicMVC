using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Xml;

namespace CourseLogicWeb.Models
{
    public class SendEmail
    {
        string strFromEmail = "";
        string strSubject = "";
        string strBody = "";
        Boolean blnIsMailSent = false;
        
        public Boolean SendRegistrationApprovalMail(string ToEmail, string InvitationKey)
        {
            try
            {
                //Read template and replace required values
                string strRegistrationURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + "/Registration/Index?ActivationKey=" + InvitationKey;
                string physicalPath = HttpContext.Current.Server.MapPath("..//EmailTemplates//RegistrationApproval.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(physicalPath);
                XmlNode root = doc.DocumentElement;
                strFromEmail = root.SelectSingleNode("FromAddress").ChildNodes[0].Value;
                strSubject = root.SelectSingleNode("Subject").ChildNodes[0].Value;
                strBody = root.SelectSingleNode("Body").ChildNodes[0].Value;
                strBody = strBody.Replace("##RegistrationURL##", strRegistrationURL);               

                blnIsMailSent = SendMail(strFromEmail, ToEmail, "", "", strSubject, strBody);

                return blnIsMailSent;
            }
            catch (Exception ex)
            {
                return blnIsMailSent;
            }
        }

        /*functino made by heema*/
        public Boolean sendRecoveredPasswordMail(string userId, string mailId, string password)
        {
            try
            {
                string physicalPath = HttpContext.Current.Server.MapPath("..//EmailTemplates//RecoverPassword.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(physicalPath);
                XmlNode root = doc.DocumentElement;
                strFromEmail = root.SelectSingleNode("FromAddress").ChildNodes[0].Value;
                strSubject = root.SelectSingleNode("Subject").ChildNodes[0].Value;
                strBody = root.SelectSingleNode("Body").ChildNodes[0].Value;
                strBody = strBody.Replace("##UserName##", userId);
                strBody = strBody.Replace("##Password##", password);

                blnIsMailSent = SendMail(strFromEmail, mailId, "", "", strSubject, strBody);

                return blnIsMailSent;
            }
            catch (Exception ex)
            {
                return blnIsMailSent;
            }

        }
        /*end of function*/


        public Boolean SendMail(string FromEmail, string ToEmail, string CCEmail, string BCCEmail, string Subject, string Body)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = ConfigurationManager.AppSettings["SMTP"];
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"]);

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.UseDefaultCredentials = true;
                smtpClient.EnableSsl = true;   
                smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FromEmail"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());                
                
                MailMessage mail = new MailMessage();
                mail.To.Add(ToEmail);
                mail.From = new MailAddress(strFromEmail);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                smtpClient.Send(mail);
                return true;
            }
            catch (SmtpException smtpex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



    }
}