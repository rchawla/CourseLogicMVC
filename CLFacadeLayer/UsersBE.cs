using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CLFacadeLayer
{
    public class UsersBE
    {
        public long AccountID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public string ProfileImage { get; set; }
        public string Password { get; set; }

        public string  UserName { get; set; }
        public string CellPhone { get; set; }
        public bool  IsVerified { get; set; }
        public Guid  VerificationGuid { get; set; }
        public DateTime  CreateDate { get; set; }
        public TimeSpan  TimeStamp { get; set; }
        public int  CarrierID { get; set; }


        public long FacebookUserID { get; set; }
        public bool  IsFacebookID { get; set; }
        public int   CarrierProviderListID { get; set; }
        public bool  IsAdmin { get; set; }
        public bool  IsFirstTime { get; set; }
      

    }
}
