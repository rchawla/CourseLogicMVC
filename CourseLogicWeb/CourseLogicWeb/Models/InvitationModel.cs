using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CLFacadeLayer;

namespace CourseLogicWeb.Models
{

    public class InvitationGender
    {
        public string Text {get; set;}
        public string Value {get; set;}
    }
    public class InvitationModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public Guid _InvitationKey { get; set; }

        public string Gender { get; set; }

        public Boolean Approved { get; set; }

        public Boolean IsRender { get; set; }

        public Boolean IsEmailSend { get; set; }

        public long AccountID { get; set; }

        public long InvitationID { get; set; }

        public DateTime? CreateDate { get; set; }

        //public List<InvitationGender> item = new List<InvitationGender>();
    }

    public class CheckUserEmailExist
    {
        InvitationRequestDAL objInvitationRequestDAL = new InvitationRequestDAL();
        public Int32 FinialResults = 0;

        public CheckUserEmailExist(string SchoolEmail)
        {
            Int32 Result = 0;
            Result = objInvitationRequestDAL.CheckUserEmailExistDAL(SchoolEmail);
            FinialResults = Result;
        }
    }

    public class SendInvitationRequest
    {
        InvitationRequestDAL objInvitationRequestDAL = new InvitationRequestDAL();
        public string FinialResults = string.Empty;
        public SendInvitationRequest(string FirstName, string LastName, string SchoolEmail, string Gender,long AccountID, Boolean IsApproved)
        {
            string Results = string.Empty;
            Results = objInvitationRequestDAL.InsertUpdate_InvitationRequests(FirstName, LastName, SchoolEmail, Gender,AccountID, IsApproved);
            FinialResults = Results;
        }
    }
}