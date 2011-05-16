using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using System.Web.Security;
using System.Data;
using CLFacadeLayer;


namespace CourseLogicWeb.Controllers
{
    public class InvitationController : Controller
    {
        //
        // GET: /Invitation/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InvitationRequest()
        {
            LoginModel objLoginModel = new LoginModel();
            objLoginModel.FirstName = "";
            objLoginModel.LastName = "";
            objLoginModel.Email = "";
            return View(objLoginModel);
        }

        public int CheckEmail(string SchoolEmail)
        {
            int EmailStatus = 0;
            CheckUserEmailExist objCheckUserEmailExist = new CheckUserEmailExist(SchoolEmail);
            EmailStatus = objCheckUserEmailExist.FinialResults;
            return EmailStatus;
        }


        public string SendInvitationRequest(string FirstName, string LastName, string SchoolEmail, string Gender)
        {
            string ResultsStatus = string.Empty;
             //string[] EmailVarify = SchoolEmail.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
             string[] EmailVarify = SchoolEmail.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
             //if (EmailVarify.Contains("edu"))
             if (EmailVarify.Contains(ConfigurationService.ConfigurationService.GetDomainForEmail()))
             {
                 SendInvitationRequest objSendInvitationRequest = new SendInvitationRequest(FirstName, LastName, SchoolEmail, Gender, 0, true);
                 ResultsStatus = objSendInvitationRequest.FinialResults;
                 if (!string.IsNullOrEmpty(ResultsStatus) && ResultsStatus != "Error")
                 {
                     // send invitation request email to user.
                     SendEmail objSendEmail = new SendEmail();
                     Boolean btnIsMailSent = objSendEmail.SendRegistrationApprovalMail(SchoolEmail,ResultsStatus);
                     InvitationRequestDAL objInvitationRequestDAL = new InvitationRequestDAL();
                     objInvitationRequestDAL.UpdateEmailSent(ResultsStatus, btnIsMailSent);
                 }
                 return ResultsStatus;
             }
             else
             {
                 SendInvitationRequest objSendInvitationRequest = new SendInvitationRequest(FirstName, LastName, SchoolEmail, Gender, 0, false);
                 ResultsStatus = objSendInvitationRequest.FinialResults;
                 return ResultsStatus;
             }
        }
    }
}
