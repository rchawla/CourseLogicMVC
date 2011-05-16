using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class AccountsDAL
    {

        Database objDB = null;
        DataSet objDS = new DataSet();

        public AccountsDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }


        public DataSet CheckAccountExists(string UserName, string Password)
        {
            Database objDB = null;
            DataSet objDS = new DataSet();
            try
            {
                objDB = DatabaseFactory.CreateDatabase();
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Check_UserExists");
                objDB.AddInParameter(objInsertCommand, "@UserName", DbType.String, UserName);
                objDB.AddInParameter(objInsertCommand, "@Password", DbType.String, Password);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public DataSet FacebookUserExit(long FacebookUID)
        {
            Database objDB = null;
            DataSet objDS = new DataSet();
            try
            {
                objDB = DatabaseFactory.CreateDatabase();
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Check_FacebookUserExists");
                objDB.AddInParameter(objInsertCommand, "@FacebookUserID", DbType.Int64, FacebookUID);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public UsersBE GetAccountDetailsByAccountID(long AccountID)
        {
            UsersBE UserEntities = new UsersBE();
            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetAccountDetailByAccountID");
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);
                while (drList.Read())
                {
                    if (!drList.IsDBNull(0))
                        UserEntities.AccountID  = drList.GetInt64(0);

                    if (!drList.IsDBNull(1))
                        UserEntities.FirstName  = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        UserEntities.LastName = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        UserEntities.PrimaryEmail  = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        UserEntities.SecondaryEmail  = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        UserEntities.Password  = drList.GetString(5);

                    if (!drList.IsDBNull(6))
                        UserEntities.ProfileImage = drList.GetString(6);

                    if (!drList.IsDBNull(7))
                        UserEntities.UserName  = drList.GetString (7);

                    if (!drList.IsDBNull(8))
                        UserEntities.CellPhone  = drList.GetString(8);

                    if (!drList.IsDBNull(9))
                        UserEntities.IsVerified  = drList.GetBoolean (9);

                    if (!drList.IsDBNull(10))
                        UserEntities.VerificationGuid  = drList.GetGuid (10);

                    if (!drList.IsDBNull(11))
                        UserEntities.CreateDate  = drList.GetDateTime (11);

                    if (!drList.IsDBNull(12))
                        UserEntities.CarrierID  = drList.GetInt32 (12);

                    if (!drList.IsDBNull(13))
                        UserEntities.FacebookUserID  = drList.GetInt64(13);

                    if (!drList.IsDBNull(14))
                        UserEntities.IsFacebookID = drList.GetBoolean(14);

                    if (!drList.IsDBNull(15))
                        UserEntities.CarrierProviderListID  = drList.GetInt32(15);

                    if (!drList.IsDBNull(16))
                        UserEntities.IsAdmin = drList.GetBoolean(16);

                    if (!drList.IsDBNull(17))
                        UserEntities.IsFirstTime = drList.GetBoolean(17);

                }

                if (!drList.IsClosed)
                    drList.Close();

                return UserEntities;
            }
            catch (Exception ex)
            {
                return UserEntities;
            }
        }

        public void UpdateProfileImage(long AccountID, string  ProfileImage)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Update_ProfileImageInAccounts");
                objDB.AddInParameter(objInsertCommand, "@ProfileImage", DbType.String, ProfileImage);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {
            }
        }


        /* function made by heema bhatt*/
        public DataSet getPassword(string userId, string mailId)
        {

            Database objDB = null;
            DataSet objDS = new DataSet();
            try
            {
                objDB = DatabaseFactory.CreateDatabase();
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Get_Password");
                objDB.AddInParameter(objInsertCommand, "@username", DbType.String, userId);
                objDB.AddInParameter(objInsertCommand, "@emailid", DbType.String, mailId);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                //pwd = objDS.Tables[0].Rows[0]["Password"].ToString();
                //return pwd;
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }

        }

        /*end of function*/
    }
}
