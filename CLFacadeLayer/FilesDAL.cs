using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class FilesDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public FilesDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        #region Get Method

        public List<GenericBE> GetFiles(int CourseItemID, int CourseID, int SystemObjectID)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetFilesByCourseItemID");
                objDB.AddInParameter(objSelectCommand, "@CourseItemID", DbType.Int32, CourseItemID);
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objSelectCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.FileID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemID = drList.GetInt32(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseID = drList.GetInt32(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.AccountID = drList.GetInt64(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.FileExtensions = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.FileName = drList.GetString(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.SystemObjectID = drList.GetInt32(6);

                    GenericList.Add(GenericEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return GenericList;
            }
            catch (Exception ex)
            {
                return GenericList;
            }
        }

        #endregion

        #region Insert / Update Files Detail

        public void SaveFileDetail(int CourseItemID, int CourseID, int AccountID, int SystemObjectID, string FileExtensions, string FileName)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Insert_FilesDetail");
                objDB.AddInParameter(objInsertCommand, "@CourseItemID", DbType.Int32, CourseItemID);
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int32, AccountID);
                objDB.AddInParameter(objInsertCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);
                objDB.AddInParameter(objInsertCommand, "@FileExtensions", DbType.String, FileExtensions);
                objDB.AddInParameter(objInsertCommand, "@FileName", DbType.String, FileName);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Delete Method

        public void DeleteFiles(int FileID)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_DeleteFilesByFileID");
                objDB.AddInParameter(objInsertCommand, "@FileID", DbType.Int32, FileID);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}
