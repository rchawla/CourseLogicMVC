using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class FlashcardDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public FlashcardDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public List<GenericBE> GetFalshCardSets(int CourseID)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetFlashCardSets");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int64, CourseID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.FlashCardID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.FlashCardTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.FlashCardSubject = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.FlashCardDescription = drList.GetString(3);                 

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.TotalItems = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.FlashCardSetCreateDateTime = drList.GetDateTime(6);

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

        public int SaveFlashCardSet(int CourseID, int AccountID, int FlashCardID, string FlashCardTitle, string FlashCardSubject, string FlashCardDescription, bool IsVotedUpSelected, bool IsFavoriteSelected, bool IsYouAddedSelected, bool IsAssessmentSelected, bool IsChapterSelected, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected, int TotalItems)
        {
            int intFlashCardID = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_AddEditFlashCardSets");                
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int32, AccountID);
                objDB.AddInParameter(objInsertCommand, "@FlashCardID", DbType.Int32, FlashCardID);
                objDB.AddInParameter(objInsertCommand, "@FlashCardTitle", DbType.String, FlashCardTitle);
                objDB.AddInParameter(objInsertCommand, "@FlashCardSubject", DbType.String, FlashCardSubject);
                objDB.AddInParameter(objInsertCommand, "@FlashCardDescription", DbType.String, FlashCardDescription);
                objDB.AddInParameter(objInsertCommand, "@IsVotedUpSelected", DbType.Boolean, IsVotedUpSelected);
                objDB.AddInParameter(objInsertCommand, "@IsFavoriteSelected", DbType.Boolean, IsFavoriteSelected);
                objDB.AddInParameter(objInsertCommand, "@IsYouAddedSelected", DbType.Boolean, IsYouAddedSelected);
                objDB.AddInParameter(objInsertCommand, "@IsAssessmentSelected", DbType.Boolean, IsAssessmentSelected);
                objDB.AddInParameter(objInsertCommand, "@IsChapterSelected", DbType.Boolean, IsChapterSelected);
                objDB.AddInParameter(objInsertCommand, "@CommaSeperatedChapters", DbType.String, CommaSeperatedChapters);                
                objDB.AddInParameter(objInsertCommand, "@IsNotesSelected", DbType.Boolean, IsNotesSelected);
                objDB.AddInParameter(objInsertCommand, "@IsQuestionSelected", DbType.Boolean, IsQuestionSelected);
                objDB.AddInParameter(objInsertCommand, "@IsTermSelected", DbType.Boolean, IsTermSelected);
                objDB.AddInParameter(objInsertCommand, "@IsSummarySelected", DbType.Boolean, IsSummarySelected);
                objDB.AddInParameter(objInsertCommand, "@TotalItems", DbType.Int32, TotalItems);
                objDB.AddOutParameter(objInsertCommand, "@RetVal", DbType.Int32, 1);
                objDB.ExecuteNonQuery(objInsertCommand);
                intFlashCardID = Convert.ToInt32(objDB.GetParameterValue(objInsertCommand,"@RetVal"));
                return intFlashCardID;

            }
            catch (Exception ex)
            {
                intFlashCardID = 0;
                return intFlashCardID;
            }
        }

        public List<GenericBE> GetFlashCardByFlashCardID(int CourseID, int AccountID, int FlashCardID)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetFlashCardByFlashCardID");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int64, CourseID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objSelectCommand, "@FlashCardID", DbType.Int32, FlashCardID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.FlashCardID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.FlashCardTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.FlashCardSubject = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.FlashCardDescription = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.TotalItems = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.CourseID = drList.GetInt32(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.IsQuestion = drList.GetBoolean(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.IsNotes = drList.GetBoolean(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.IsTerms = drList.GetBoolean(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.IsSummary = drList.GetBoolean(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.IsChapter = drList.GetBoolean(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.CommonSeperatedChapter = drList.GetString(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.IsYourAdded = drList.GetBoolean(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.IsVotedUp = drList.GetBoolean(14);

                    if (!drList.IsDBNull(15))
                        GenericEntity.IsFavourted = drList.GetBoolean(15);

                    if (!drList.IsDBNull(16))
                        GenericEntity.IsAssessment = drList.GetBoolean(16);

                    if (!drList.IsDBNull(17))
                        GenericEntity.CreateDate = drList.GetDateTime(17);

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

        public List<GenericBE> PlayFlashCard(int FlashCard, int PageNumber)
        {
            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Play_FlashCardSet");
                objDB.AddInParameter(objSelectCommand, "@FlashCardID", DbType.Int32, FlashCard);
                objDB.AddInParameter(objSelectCommand, "@PageNumber", DbType.Int64, PageNumber);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.FlashCardSetID  = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.FlashCardID = drList.GetInt32(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseItemID = drList.GetInt32(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.SystemObjectID = drList.GetInt32(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.CourseID = drList.GetInt32(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.PageFlag = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.CourseItemTitle = drList.GetString(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.CourseItemDescription = drList.GetString(7);

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

        public List<GenericBE> TempPlay(int FlashCard)
        {
            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_All_FlashCardSetItem");
                objDB.AddInParameter(objSelectCommand, "@FlashCardID", DbType.Int32, FlashCard);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.FlashCardSetID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.FlashCardID = drList.GetInt32(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseItemID = drList.GetInt32(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.SystemObjectID = drList.GetInt32(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.CourseID = drList.GetInt32(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.PageFlag = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.CourseItemTitle = drList.GetString(6);

                    if ((drList.GetInt32(3) == 4) || (drList.GetInt32(3) == 8))
                    {
                        if(!drList.IsDBNull(7))
                        GenericEntity.CourseItemDescription = drList.GetString(7);
                    }
                    else
                    {
                        if (!drList.IsDBNull(8))
                        GenericEntity.CourseItemDescription = drList.GetString(8);
                    }

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


        public List<GenericBE> GetFlashCardSetSelectionItem(int CourseID, int AccountID, bool VotedUp, bool Favorite, bool YouAdded, bool Assessment, bool IsChapter, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected)
        {
            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetItemsForFlashCardSet");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objSelectCommand, "@IsVotedUpSelected", DbType.Boolean, VotedUp);
                objDB.AddInParameter(objSelectCommand, "@IsFavoriteSelected", DbType.Boolean, Favorite);
                objDB.AddInParameter(objSelectCommand, "@IsYouAddedSelected", DbType.Boolean, YouAdded);
                objDB.AddInParameter(objSelectCommand, "@IsAssessmentSelected", DbType.Boolean, Assessment);
                objDB.AddInParameter(objSelectCommand, "@IsChapterSelected", DbType.Boolean, IsChapter);
                objDB.AddInParameter(objSelectCommand, "@CommaSeperatedChapters", DbType.String, CommaSeperatedChapters);
                objDB.AddInParameter(objSelectCommand, "@IsNotesSelected", DbType.Boolean, IsNotesSelected);
                objDB.AddInParameter(objSelectCommand, "@IsQuestionSelected", DbType.Boolean, IsQuestionSelected);
                objDB.AddInParameter(objSelectCommand, "@IsTermSelected", DbType.Boolean, IsTermSelected);
                objDB.AddInParameter(objSelectCommand, "@IsSummarySelected", DbType.Boolean, IsSummarySelected);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseID = drList.GetInt32(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.AccountID = drList.GetInt64(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.CourseItemTitle = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.SystemObjectID = drList.GetInt32(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.SystemObjectName = drList.GetString(5);

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

        public int SaveFlashCardSetItem(int FlashCardID, int CourseItemID)
        {
            int intFlashCardID = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Insert_FlashCardSet");
                objDB.AddInParameter(objInsertCommand, "@FlashCardID", DbType.Int32, FlashCardID);
                objDB.AddInParameter(objInsertCommand, "@CourseItemID", DbType.Int32, CourseItemID);
                intFlashCardID = Convert.ToInt32(objDB.ExecuteNonQuery(objInsertCommand));
                return intFlashCardID;

            }
            catch (Exception ex)
            {
                intFlashCardID = 0;
                return intFlashCardID;
            }
        }

        public int DeleteFlashCardSet(int FlashCardID)
        {
            int Results = 0;
            try
            {
                DbCommand objDeleteCommand = objDB.GetStoredProcCommand("CL_Delete_FlashCardSet");
                objDB.AddInParameter(objDeleteCommand, "@FlashCardID", DbType.Int32, FlashCardID);
                Results = Convert.ToInt32(objDB.ExecuteScalar(objDeleteCommand));
                return Results;
            }
            catch (Exception ex)
            {
                return Results;
            }
        }

        public int DeleteFlashCard(int FlashCardID)
        {
            int Results = 0;
            try
            {
                DbCommand objDeleteCommand = objDB.GetStoredProcCommand("CL_Delete_FlashCard");
                objDB.AddInParameter(objDeleteCommand, "@FlashCardID", DbType.Int32, FlashCardID);
                Results = Convert.ToInt32(objDB.ExecuteScalar(objDeleteCommand));
                return Results;
            }
            catch (Exception ex)
            {
                return Results;
            }
        }
   
    }
}
