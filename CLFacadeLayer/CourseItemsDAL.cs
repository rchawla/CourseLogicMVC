using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class CourseItemsDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public CourseItemsDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public List<GenericBE> GetAllItems(int CourseID, int IsTopVoted, int PageNumber)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_AllItemList");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int64, CourseID);
                objDB.AddInParameter(objSelectCommand, "@TopVoted", DbType.Int64, IsTopVoted);
                objDB.AddInParameter(objSelectCommand, "@PageNumber", DbType.Int32, PageNumber);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseItemDescription = drList.GetString(2).Replace("&amp;", "&");

                    if (!drList.IsDBNull(3))
                        GenericEntity.CreateDate = drList.GetDateTime(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.CourseID = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.IsActive = drList.GetBoolean(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.UserName = drList.GetString(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.CourseItemChildCount = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.StarCount = drList.GetInt32(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.VoteCount = drList.GetInt32(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.CommentCount = drList.GetInt32(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.ProfileImage = drList.GetString(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.SystemObjectID = drList.GetInt32(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.SystemObjectName = drList.GetString(14);

                    if (!drList.IsDBNull(15))
                        GenericEntity.ParentCourseItemID = drList.GetInt32(15);

                    if (!drList.IsDBNull(3))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(3));

                    if (!drList.IsDBNull(16))
                        GenericEntity.CourseHomePageNumber = drList.GetInt32(16);

                    if (!drList.IsDBNull(17))
                        GenericEntity.TotalCourseHomeItemNumber = drList.GetInt32(17);

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

        public List<GenericBE> GetItemList(int CourseID, int SystemObjectID, long AccountID)
        {
            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_ItemList");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objSelectCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseItemDescription = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.CreateDate = drList.GetDateTime(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.CourseID = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.IsActive = drList.GetBoolean(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.UserName = drList.GetString(7);


                    if (!drList.IsDBNull(8))
                        GenericEntity.CourseItemChildCount = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.StarCount = drList.GetInt32(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.VoteCount = drList.GetInt32(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.CommentCount = drList.GetInt32(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.ProfileImage = drList.GetString(12);

                    if (!drList.IsDBNull(3))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(3));

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

        public List<GenericBE> GetItemByItemID(int CourseItemID, int SystemObjectID, long AccountID)
        {
            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_ItemDetailsByID");
                objDB.AddInParameter(objSelectCommand, "@CourseItemID", DbType.Int32, CourseItemID);
                objDB.AddInParameter(objSelectCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);

                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseItemDescription = drList.GetString(2).Replace("&amp;", "&");

                    if (!drList.IsDBNull(3))
                        GenericEntity.CreateDate = drList.GetDateTime(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.CourseID = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.IsActive = drList.GetBoolean(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.UserName = drList.GetString(7);


                    if (!drList.IsDBNull(8))
                        GenericEntity.CourseItemChildCount = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.StarCount = drList.GetInt32(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.VoteCount = drList.GetInt32(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.CommentCount = drList.GetInt32(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.ProfileImage = drList.GetString(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.VoteUpDisplay = drList.GetInt32(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.VoteDownDisplay = drList.GetInt32(14);

                    if (!drList.IsDBNull(15))
                        GenericEntity.SystemObjectName = drList.GetString(15);

                    if (!drList.IsDBNull(16))
                        GenericEntity.StarDisplay = drList.GetInt32(16);

                    if (!drList.IsDBNull(17))
                        GenericEntity.ParentCourseItemID  = drList.GetInt32(17);

                    if (!drList.IsDBNull(3))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(3));

                    if (!drList.IsDBNull(18))
                        GenericEntity.Chapter = drList.GetInt32(18);

                    if (!drList.IsDBNull(19))
                        GenericEntity.Section = drList.GetInt32(19);

                    if (!drList.IsDBNull(20))
                        GenericEntity.PageNumber = drList.GetInt32(20);

                    if (!drList.IsDBNull(21))
                        GenericEntity.Discussion_Rank = drList.GetString(21);

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

        public List<GenericBE> GetChildByParentID(int QID, long AccountID, int SystemObjectID)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_ChildByParentID");
                objDB.AddInParameter(objSelectCommand, "@ParentCourseItemID", DbType.Int32, QID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objSelectCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);

                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemDescription = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CreateDate = drList.GetDateTime(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.AccountID = drList.GetInt64(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.UserName = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.StarCount = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.VoteCount = drList.GetInt32(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.CommentCount = drList.GetInt32(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.ProfileImage = drList.GetString(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.VoteUpDisplay = drList.GetInt32(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.VoteDownDisplay = drList.GetInt32(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.SystemObjectName = drList.GetString(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.CourseID = drList.GetInt32(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.ParentCourseItemID = drList.GetInt32(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.StarDisplay = drList.GetInt32(14);

                    if (!drList.IsDBNull(2))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(2));

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

        public List<GenericBE> LoadComments(long AssociatedID, string SystemObjectName, long AccountID, Boolean IsLoadTwoComments)
        {
            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Get_CommentsByAssociatedID");
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@AssociatedID", DbType.Int32, AssociatedID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objInsertCommand, "@IsLoadTwoComment", DbType.Boolean, IsLoadTwoComments);
                // objDS = objDB.ExecuteDataSet(objInsertCommand);

                IDataReader drList = objDB.ExecuteReader(objInsertCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemDescription = drList.GetString(1).Replace("#||#", "\'");

                    if (!drList.IsDBNull(2))
                        GenericEntity.CreateDate = drList.GetDateTime(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.ParentCourseItemID = drList.GetInt32(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.UserName = drList.GetString(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.CommentCount = drList.GetInt32(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.VoteCount = drList.GetInt32(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.VoteUpDisplay = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.SystemObjectName = drList.GetString(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.CourseID = drList.GetInt32(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.SystemObjectID = drList.GetInt32(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.StarCount = drList.GetInt32(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.ProfileImage = drList.GetString(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.Discussion_Rank = drList.GetString(14);

                    if (!drList.IsDBNull(2))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(2));

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

        public GenericBE CommentByCommentID(int CID, string SystemObjectName, long AccountID)
        {

            //GenericBE GenericList = new GenericBE();
            GenericBE GenericEntity = new GenericBE();
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_Get_CommentsByCommentID");
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@AssociatedID", DbType.Int32, CID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int64, AccountID);
                //  objDS = objDB.ExecuteDataSet(objInsertCommand);

                IDataReader drList = objDB.ExecuteReader(objInsertCommand);

                while (drList.Read())
                {

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemDescription = drList.GetString(1).Replace("#||#", "\'"); ;

                    if (!drList.IsDBNull(2))
                        GenericEntity.CreateDate = drList.GetDateTime(2);

                    if (!drList.IsDBNull(3))
                        GenericEntity.ParentCourseItemID = drList.GetInt32(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.UserName = drList.GetString(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.CommentCount = drList.GetInt32(6);


                    if (!drList.IsDBNull(7))
                        GenericEntity.VoteCount = drList.GetInt32(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.VoteUpDisplay = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.SystemObjectName = drList.GetString(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.CourseID = drList.GetInt32(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.SystemObjectID = drList.GetInt32(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.StarCount = drList.GetInt32(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.ProfileImage = drList.GetString(13);

                }

                if (!drList.IsClosed)
                    drList.Close();

                return GenericEntity;
            }
            catch (Exception ex)
            {
                return GenericEntity;
            }
        }

        public void SaveComment(int CourseItemID, int CourseID, int AccountID, int SystemObjectID, string SystemObjectName, string CommentDesc, int ParentCourseItemID)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_Comments");
                objDB.AddInParameter(objInsertCommand, "@CommentID", DbType.Int32, CourseItemID);
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int32, AccountID);
                objDB.AddInParameter(objInsertCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@Comment", DbType.String, CommentDesc);
                objDB.AddInParameter(objInsertCommand, "@ParentCourseItemID", DbType.Int32, ParentCourseItemID);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {
            }
        }

        public DataSet LoadEditorByCourseItemID(int CID, int ParentCID, long AccountID)
        {
            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_ChildByCoursItemID");
                objDB.AddInParameter(objSelectCommand, "@ParentCourseItemID", DbType.Int32, ParentCID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDB.AddInParameter(objSelectCommand, "@CourseItemID", DbType.Int32, CID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                return objDS;
            }
            catch (Exception ex)
            {
                return objDS;
            }
        }

        public int SaveCourseItems(int CourseItemID, int CourseID, int AccountID, int SystemObjectID, string SystemObjectName, string CommentDesc, int? ParentCourseItemID, string CourseItemTitle, int? Chapter, int? Section, int? PageNumber)
        {
            int ParentID = 0;
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_CourseItems");
                objDB.AddInParameter(objInsertCommand, "@CourseItemID", DbType.Int32, CourseItemID);
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objInsertCommand, "@AccountID", DbType.Int32, AccountID);
                objDB.AddInParameter(objInsertCommand, "@SystemObjectID", DbType.Int32, SystemObjectID);
                objDB.AddInParameter(objInsertCommand, "@SystemObjectName", DbType.String, SystemObjectName);
                objDB.AddInParameter(objInsertCommand, "@CourseItemDescription", DbType.String, CommentDesc);
                objDB.AddInParameter(objInsertCommand, "@CourseItemTitle", DbType.String, CourseItemTitle);
                objDB.AddInParameter(objInsertCommand, "@ParentCourseItemID", DbType.Int32, ParentCourseItemID);
                objDB.AddInParameter(objInsertCommand, "@Chapter", DbType.Int32, Chapter);
                objDB.AddInParameter(objInsertCommand, "@Section", DbType.Int32, Section);
                objDB.AddInParameter(objInsertCommand, "@PageNumber", DbType.Int32, PageNumber);
                ParentID = Convert.ToInt32(objDB.ExecuteScalar(objInsertCommand));
                ///ParentID = Convert.ToInt32(objDB.ExecuteNonQuery(objInsertCommand));
                return ParentID;
            }
            catch (Exception ex)
            {
                return ParentID;
            }
        }

        public int GetChildCountByCourseItemID(int CourseItemID)
        {

            //  List<GenericBE> GenericList = new List<GenericBE>();
            int ChildCount = 0;

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_ChildCount");
                objDB.AddInParameter(objSelectCommand, "@CourseItemID", DbType.Int32, CourseItemID);

                ChildCount = Convert.ToInt32(objDB.ExecuteScalar(objSelectCommand));

                //while (drList.Read())
                //{
                //    GenericBE GenericEntity = new GenericBE();

                //    if (!drList.IsDBNull(0))
                //        GenericEntity.CourseItemID = drList.GetInt32(0);

                //    GenericList.Add(GenericEntity);
                //}

                //if (!drList.IsClosed)
                //    drList.Close();

                return ChildCount;
            }
            catch (Exception ex)
            {
                return ChildCount;
            }
        }

        public List<GenericBE> GetFavoriteList(long AccountID, int CourseID)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_FavoritesListbyCourseIDAccountID");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
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
                        GenericEntity.CreateDate = drList.GetDateTime(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.DateDeleted  = drList.GetDateTime(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.IsActive = drList.GetBoolean(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.SystemObjectID = drList.GetInt32(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.SystemObjectName = drList.GetString(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.StarCount = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.VoteCount = drList.GetInt32(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.CommentCount = drList.GetInt32(10);
                    
                    if (!drList.IsDBNull(11))
                        GenericEntity.CourseItemTitle = drList.GetString(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.CourseItemDescription = drList.GetString(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.CourseItemChildCount = drList.GetInt32(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.ParentCourseItemID = drList.GetInt32(14);

                    if (!drList.IsDBNull(15))
                        GenericEntity.FlagCount  = drList.GetInt32(15);

                    if (!drList.IsDBNull(16))
                        GenericEntity.Chapter = drList.GetInt32(16);                  

                    if (!drList.IsDBNull(17))
                        GenericEntity.Section  = drList.GetInt32(17);

                    if (!drList.IsDBNull(18))
                        GenericEntity.PageNumber  = drList.GetInt32(18);

                    if (!drList.IsDBNull(19))
                        GenericEntity.UpdatedDate  = drList.GetDateTime(19);

                    if (!drList.IsDBNull(20))
                        GenericEntity.ProfileImage  = drList.GetString (20);


                    if (!drList.IsDBNull(3))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(3));

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

        public List<GenericBE> GetDiscussionListingCourseHome(int CourseID, int AccountID, int SystemobjectID, int PageNumber, int TopVoted, int MyAdded)
        {

            List<GenericBE> GenericList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetItem_By_ItemType");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int64, CourseID);
                objDB.AddInParameter(objSelectCommand, "@TopVoted", DbType.Int64, TopVoted);
                objDB.AddInParameter(objSelectCommand, "@MyAdded", DbType.Int32, MyAdded);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int32, AccountID);
                objDB.AddInParameter(objSelectCommand, "@PageNumber", DbType.Int32, PageNumber);
                objDB.AddInParameter(objSelectCommand, "@sysID", DbType.Int32, SystemobjectID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE GenericEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseItemID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        GenericEntity.CourseItemTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseItemDescription = drList.GetString(2).Replace("&amp;", "&");

                    if (!drList.IsDBNull(3))
                        GenericEntity.CreateDate = drList.GetDateTime(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.AccountID = drList.GetInt64(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.CourseID = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.IsActive = drList.GetBoolean(6);

                    if (!drList.IsDBNull(7))
                        GenericEntity.UserName = drList.GetString(7);

                    if (!drList.IsDBNull(8))
                        GenericEntity.ProfileImage = drList.GetString(8);

                    if (!drList.IsDBNull(9))
                        GenericEntity.SystemObjectID = drList.GetInt32(9);

                    if (!drList.IsDBNull(10))
                        GenericEntity.SystemObjectName = drList.GetString(10);

                    if (!drList.IsDBNull(11))
                        GenericEntity.ParentCourseItemID = drList.GetInt32(11);

                    if (!drList.IsDBNull(12))
                        GenericEntity.VoteCount = drList.GetInt32(12);

                    if (!drList.IsDBNull(13))
                        GenericEntity.CommentCount = drList.GetInt32(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.PageNumber = drList.GetInt32(14);

                    if (!drList.IsDBNull(15))
                        GenericEntity.Section = drList.GetInt32(15);

                    if (!drList.IsDBNull(16))
                        GenericEntity.Chapter = drList.GetInt32(16);

                    if (!drList.IsDBNull(17))
                        GenericEntity.StarDisplay = drList.GetInt32(17);

                    if (!drList.IsDBNull(18))
                        GenericEntity.CourseHomePageNumber = drList.GetInt32(18);

                    if (!drList.IsDBNull(19))
                        GenericEntity.Discussion_Rank = drList.GetString(19);

                    if (!drList.IsDBNull(20))
                        GenericEntity.PageFlag = drList.GetInt32(20);

                    if (!drList.IsDBNull(3))
                        GenericEntity.PostedDate = GetTimeSpan(drList.GetDateTime(3));

                    if (MyAdded == 1)
                        GenericEntity.IsMyAdded = true;

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

        public void DeleteItems(int CourseItemID)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_DeleteItems");
                objDB.AddInParameter(objInsertCommand, "@CourseItemID", DbType.Int32, CourseItemID);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {
            }
        }


        #region GetTimeSpan
        public string GetTimeSpan(DateTime PostedDate)
        {
            string strTimeSpan = string.Empty;
            TimeSpan timeSpan = new TimeSpan();
            try
            {
                timeSpan = DateTime.Now.Subtract(PostedDate);
                timeSpan.Duration();

                if (timeSpan.Days >= 1)
                {
                    strTimeSpan = timeSpan.Days.ToString() + " days ago";
                }
                else if (timeSpan.Hours >= 1)
                {
                    strTimeSpan = timeSpan.Hours.ToString() + " hours ago";
                }
                else
                {
                    strTimeSpan = timeSpan.Minutes.ToString() + " mins ago";
                }
            }
            catch (Exception ex)
            {
            }

            return strTimeSpan;
        }
        #endregion
    }
}
