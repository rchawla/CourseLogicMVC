using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CLFacadeLayer;

namespace CourseLogicWeb.Models
{
    public class RegistrationModel
    {
    }

    public class RegisterUserWithFacebook
    {
        RegistrationDAL objRegistrationDAL = new RegistrationDAL();
        DataSet objDS = new DataSet();
        public IEnumerable<LoginModel> _RegUserList;

        public RegisterUserWithFacebook(string FirstName, string LastName, long FacebookUserID, Boolean IsFacebookID, string PrimayEmail, string VerificationGuid)
        {
            objDS = objRegistrationDAL.RegisterUserWithFacebookDAL(FirstName, LastName, FacebookUserID, IsFacebookID, PrimayEmail,VerificationGuid);
            if (objDS.Tables.Count > 0)
            {
                _RegUserList = ConvertToEnumerableList(objDS.Tables[0]);
            }
        }

        private IEnumerable<LoginModel> ConvertToEnumerableList(DataTable dataTable)
        {
            List<LoginModel> RegUserList = new List<LoginModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                LoginModel objRegUserModel = new LoginModel
                {
                    AccountID = Convert.ToInt64(row["AccountID"]),
                };
                RegUserList.Add(objRegUserModel);
            }
            return (IEnumerable<LoginModel>)RegUserList;
        }

       
    }

    public class VerifyInvitation
    {
        RegistrationDAL objRegistrationDAL = new RegistrationDAL();
        public Int32 FinialResults = 0;

        public VerifyInvitation(string InvitationKey)
        {
            Int32 Result = 0;
            Result = objRegistrationDAL.VerifyInvitationRequestDAL(InvitationKey);
            FinialResults = Result;
        }
    }

    public class GetRegisterUserData
    {
        RegistrationDAL objRegistrationDAL = new RegistrationDAL();
        DataSet objDS = new DataSet();
        public IEnumerable<RegisterModel> _RegisterUserList;

        public GetRegisterUserData(string ActivationKey)
        {
            objDS = objRegistrationDAL.GetRegisterUserData(ActivationKey);
            if (objDS.Tables.Count > 0)
            {
                _RegisterUserList = ConvertToEnumerableList(objDS.Tables[0]);
            }
        }

        private IEnumerable<RegisterModel> ConvertToEnumerableList(DataTable dataTable)
        {
            List<RegisterModel> RegUserList = new List<RegisterModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                RegisterModel objRegUserModel = new RegisterModel
                {
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["Email"].ToString(),
                    VerificationGuid = row["InvitationKey"].ToString(),
                };
                RegUserList.Add(objRegUserModel);
            }
            return (IEnumerable<RegisterModel>)RegUserList;
        }
    }

    
    public class CheckUserNameExist
    {
        RegistrationDAL objRegistrationDAL = new RegistrationDAL();
        public Int32 FinialResults = 0;

        public CheckUserNameExist(string UserName)
        {
            Int32 Result = 0;
            Result = objRegistrationDAL.CheckUserNameExistDAL(UserName);
            FinialResults = Result;
        }
    }

    public class RegisterUserWithOutFacebook
    {
        RegistrationDAL objRegistrationDAL = new RegistrationDAL();
        public Int32 FinialResults = 0;

        public  RegisterUserWithOutFacebook(long AccountID, string Username, string Password, string FirstName, string LastName, string PrimaryEmail, string SecondaryEmail, string CellPhone, string VerificationGuid, int CarrierProviderID, long FacebookUserID, Boolean IsFacebookID)
        {
            Int32 Result = 0;
            Result = objRegistrationDAL.RegisterUserWithOutFacebookDAL(AccountID, Username, Password, FirstName, LastName, PrimaryEmail, SecondaryEmail, CellPhone, VerificationGuid, CarrierProviderID, FacebookUserID, IsFacebookID);
            FinialResults = Result;
        }
    }
     
}

