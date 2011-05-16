using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CLFacadeLayer;
using CourseLogicWeb.Cryptography;
namespace CourseLogicWeb.Models
{
    public class ProfileModel
    {
        #region PrivateMember
        AccountsDAL objAccountDAL = new AccountsDAL();
        RegistrationDAL objRegistrationDAL = new RegistrationDAL();
        #endregion

        public UsersBE GetAccountDetailsByAccountID(long AccountID)
        {
            UsersBE EntityList;
            EntityList = objAccountDAL.GetAccountDetailsByAccountID(AccountID);
            return EntityList;
        }

        public int SaveProfile(long AccountID, string FirstName, string LastName, string PrimaryEmail, string SecondaryEmail, string NewPassword)
        {

            ProfileModel objProfile = new ProfileModel();
            UsersBE UserEntities = new UsersBE();
            string Password;
            UserEntities = objProfile.GetAccountDetailsByAccountID(AccountID);
            string UserName = UserEntities.UserName;
            if (!string.IsNullOrEmpty(NewPassword))
            {
                Password = Cryptography.Cryptography.Encrypt(NewPassword);
            }
            else
            {
                Password = UserEntities.Password;
            }
            string Cellphone = UserEntities.CellPhone;
            string VerificationGuid = UserEntities.VerificationGuid.ToString();
            int  CarrierProviderListID = UserEntities.CarrierProviderListID;
            long FacebookUserID = UserEntities.FacebookUserID;
            bool IsFacebookID = UserEntities.IsFacebookID;

            int ID = objRegistrationDAL.RegisterUserWithOutFacebookDAL(AccountID, UserName, Password, FirstName, LastName, PrimaryEmail, SecondaryEmail, Cellphone, VerificationGuid, CarrierProviderListID, FacebookUserID, IsFacebookID);

            return ID;
        }

        public void UpdateProfileImage(long AccountID, string ProfileImage)
        {
            objAccountDAL.UpdateProfileImage(AccountID, ProfileImage);
        }

    }
}