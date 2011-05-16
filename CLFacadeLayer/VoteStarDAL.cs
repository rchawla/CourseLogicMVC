using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace CLFacadeLayer
{
    public class VoteStarDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public VoteStarDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public DataSet InsertUpdateVoteUp(long AssociatedID, string SystemObjectName, long AccountID, long CourseID)
        {           
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_VoteUp");
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@AssociatedID", DbType.Int32, AssociatedID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int64, CourseID);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public DataSet InsertUpdateVoteDown(long AssociatedID, string SystemObjectName, long AccountID, long CourseID)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_VoteDown");
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@AssociatedID", DbType.Int32, AssociatedID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int64, CourseID);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public DataSet InsertUpdateStar(long AssociatedID, string SystemObjectName, long AccountID, long CourseID)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_Star");
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@AssociatedID", DbType.Int32, AssociatedID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int64, CourseID);
                objDS = objDB.ExecuteDataSet(objInsertCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

    }
}
