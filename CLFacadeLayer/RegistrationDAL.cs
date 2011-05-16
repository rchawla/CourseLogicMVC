using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CLFacadeLayer
{
    public class RegistrationDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public RegistrationDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public DataSet RegisterUserWithFacebookDAL(string FirstName, string LastName, long FacebookUserID, Boolean IsFacebook, string PrimaryEmail, string VerificationGuid)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertFacebookUser_Accounts");
                objDB.AddInParameter(objInsertCommand, "@FirstName", DbType.String, FirstName);
                objDB.AddInParameter(objInsertCommand, "@LastName", DbType.String, LastName);
                objDB.AddInParameter(objInsertCommand, "@FacebookUserID", DbType.Int64, FacebookUserID);
                objDB.AddInParameter(objInsertCommand, "@IsFacebookID", DbType.Boolean, IsFacebook);
                objDB.AddInParameter(objInsertCommand, "@PrimaryEmail", DbType.String, PrimaryEmail);
                objDB.AddInParameter(objInsertCommand, "@UserName", DbType.String, FirstName);
                objDB.AddInParameter(objInsertCommand, "@Password", DbType.String, "");
                objDB.AddInParameter(objInsertCommand, "@VerificationGuid", DbType.String, VerificationGuid);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public int VerifyInvitationRequestDAL(string InvitationKey)
        {
            int Result = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Update_Invitation");
                objDB.AddInParameter(objInsertCommand, "@VerificationGuid", DbType.String, InvitationKey);
                Result = Convert.ToInt32(objDB.ExecuteScalar(objInsertCommand));
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }
        }

        public DataSet GetRegisterUserData(string InvitationKey)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Get_InvitationRequestsByInvitationKey");
                objDB.AddInParameter(objInsertCommand, "@VerificationGuid", DbType.String, InvitationKey);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public int CheckUserNameExistDAL(string UserName)
        {
            int Result = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Check_UserNameExists");
                objDB.AddInParameter(objInsertCommand, "@UserName", DbType.String, UserName);
                Result = Convert.ToInt32(objDB.ExecuteScalar(objInsertCommand));
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }
        }

        public int RegisterUserWithOutFacebookDAL(long AccountID, string Username, string Password, string FirstName, string LastName, string PrimaryEmail, string SecondaryEmail, string CellPhone, string VerificationGuid, int CarrierProviderID, long FacebookUserID, Boolean IsFacebookID)
        {
            int Result = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_Accounts");
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objInsertCommand, "@Username", DbType.String, Username);
                objDB.AddInParameter(objInsertCommand, "@Password", DbType.String, Password);
                objDB.AddInParameter(objInsertCommand, "@FirstName", DbType.String, FirstName);
                objDB.AddInParameter(objInsertCommand, "@LastName", DbType.String, LastName);
                objDB.AddInParameter(objInsertCommand, "@PrimaryEmail", DbType.String, PrimaryEmail);
                objDB.AddInParameter(objInsertCommand, "@SecondaryEmail", DbType.String, SecondaryEmail);
                objDB.AddInParameter(objInsertCommand, "@CellPhone", DbType.String, CellPhone);
                objDB.AddInParameter(objInsertCommand, "@VerificationGuid", DbType.String, VerificationGuid);
                objDB.AddInParameter(objInsertCommand, "@CarrierProviderID", DbType.Int32, CarrierProviderID);
                objDB.AddInParameter(objInsertCommand, "@FacebookUserID", DbType.Int64, FacebookUserID );
                objDB.AddInParameter(objInsertCommand, "@IsFacebookID", DbType.Boolean, IsFacebookID);
                Result = Convert.ToInt32(objDB.ExecuteScalar(objInsertCommand));
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }
        }
    }
}
