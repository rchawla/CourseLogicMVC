using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseLogicWeb.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Username is required to login.")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Password is required to login.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsVerified { get; set; }

        public long AccountID { get; set; }

        public string AccountTitle { get; set; }

        public string Email { get; set; }

        public Guid _InvitationKey { get; set; }

        public string Gender { get; set; }

        public Boolean Approved { get; set; }

        public Boolean IsRender { get; set; }

        public Boolean IsEmailSend { get; set; }

        public long InvitationID { get; set; }

        public DateTime? CreateDate { get; set; }

        public string ProfileImage { get; set; }
    }
}