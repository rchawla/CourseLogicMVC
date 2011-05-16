using System;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CLFacadeLayer
{
    public class InvitationRequestDAL
    {
         Database objDB = null;
        DataSet objDS = new DataSet();

        public InvitationRequestDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public int CheckUserEmailExistDAL(string SchoolEmail)
        {
            int Result = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Check_UserEmailExists");
                objDB.AddInParameter(objInsertCommand, "@Email", DbType.String, SchoolEmail);
                Result = Convert.ToInt32(objDB.ExecuteScalar(objInsertCommand));
                return Result;
            }
            catch (Exception ex)
            {
                return Result;
            }
        }

        public string InsertUpdate_InvitationRequests(string FirstName, string LastName, string SchoolEmail, string Gender, long AccountID, Boolean IsApproved)
        {
            string Result = string.Empty;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Insert_InvitationRequests");
                objDB.AddInParameter(objInsertCommand, "@FirstName", DbType.String, FirstName);
                objDB.AddInParameter(objInsertCommand, "@LastName", DbType.String, LastName);
                objDB.AddInParameter(objInsertCommand, "@Email", DbType.String, SchoolEmail);
                objDB.AddInParameter(objInsertCommand, "@Gender", DbType.String, Gender);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objInsertCommand, "@Approved", DbType.Boolean, IsApproved);
                Result = Convert.ToString(objDB.ExecuteScalar(objInsertCommand));
                return Result;
            }
            catch (Exception ex)
            {
                Result = "Error";
                return Result;
            }
        }

        public void UpdateEmailSent(string InvitationKey, Boolean blnIsMailSent)
        {            
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_UpdateEmailSent");
                objDB.AddInParameter(objInsertCommand, "@VerificationGuid", DbType.String, InvitationKey);
                objDB.AddInParameter(objInsertCommand, "@IsMailSent", DbType.Boolean, blnIsMailSent);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {                
            }
        }
    }
}
