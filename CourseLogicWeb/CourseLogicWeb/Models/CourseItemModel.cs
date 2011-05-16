using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CLFacadeLayer;


namespace CourseLogicWeb.Models
{
    public class CourseItem
    {
        #region PrivateMember
        CourseItemsDAL objCourseItemsDAL = new CourseItemsDAL();
        DataSet objDS = new DataSet();
        private IEnumerable<GenericBE> _CourseItemList;
        #endregion

        #region PublicMethod

        #region GetMethod

        public IEnumerable<GenericBE> CourseItems(int CourseID, int SystemObjectID, long AccountID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCourseItemsDAL.GetItemList(CourseID, SystemObjectID, AccountID);
            return EntityList;
        }

        public IEnumerable<GenericBE> CourseItemDetails(long AccountID, int SystemObjectID, int DiscussionID)
        {
            IEnumerable<GenericBE> EntityList;

            EntityList = objCourseItemsDAL.GetItemByItemID(DiscussionID, SystemObjectID, AccountID);
            return EntityList;
        }

        public IEnumerable<GenericBE> GetCourseHomeDetails(int CourseID, int IsTopVoted, int PageNumber)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCourseItemsDAL.GetAllItems(CourseID, IsTopVoted, PageNumber);
            return EntityList;
        }

        public IEnumerable<GenericBE> GetAllComments(long AssociatedID, string SystemObjectName, long AccountID, Boolean IsLoadTwoComments, int CourseID)
        {
            List<GenericBE> EntityList;
            EntityList = objCourseItemsDAL.LoadComments(AssociatedID, SystemObjectName, AccountID, IsLoadTwoComments);
            if (EntityList.Count == 0)
            {
                EntityList = SetCommentDefault(AssociatedID, CourseID);
            }
            return EntityList;
        }

        public List<GenericBE> SetCommentDefault(long AssociatedID, int CourseID)
        {
            List<GenericBE> _CommentList = new List<GenericBE>();
            GenericBE objGenericModel = new GenericBE
            {
                CourseItemID = 0,
                ParentCourseItemID = Convert.ToInt32(AssociatedID),
                CourseID = CourseID,
            };
            _CommentList.Add(objGenericModel);
            return _CommentList;
        }

        public IEnumerable<GenericBE> GetAllAnswer(int AssociatedID, long AccountID, int SystemObjectID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCourseItemsDAL.GetChildByParentID(AssociatedID, AccountID, SystemObjectID);
            return EntityList;
        }

        public int GetCourseItemChildCount(int CourseItemID)
        {
            return objCourseItemsDAL.GetChildCountByCourseItemID(CourseItemID);
        }

        public IEnumerable<GenericBE> GetFavoriteList(long AccountID, int CourseID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCourseItemsDAL.GetFavoriteList(AccountID, CourseID);
            return EntityList;
        }

        public IEnumerable<GenericBE> GetDiscussionListingCourseHome(int CourseID, int AccountID, int SystemobjectID, int PageNumber, int TopVoted, int MyAdded)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCourseItemsDAL.GetDiscussionListingCourseHome(CourseID, AccountID, SystemobjectID, PageNumber, TopVoted, MyAdded);
            
            return EntityList;
        }

        #endregion

        #region Insert/Update Method

        public GenericBE EditComments(int CID, string SystemObjectName, long AccountID)
        {
            GenericBE EntityList;
            EntityList = objCourseItemsDAL.CommentByCommentID(CID, SystemObjectName, AccountID);
            return EntityList;
        }

        public void SaveComment(int CourseItemID, int CourseID, int AccounID, int SystemObjectID, string SystemObjectName, string CommentDesc, int ParentCourseItemID)
        {
            objCourseItemsDAL.SaveComment(CourseItemID, CourseID, AccounID, SystemObjectID, SystemObjectName, CommentDesc, ParentCourseItemID);
        }

        public int SaveCourseItem(int CourseItemID, int CourseID, int AccounID, int SystemObjectID, string SystemObjectName, string CommentDesc, int? ParentCourseItemID, string CourseItemTitle, int? Chapter, int? Section, int? PageNUmber)
        {
            int ParentID = 0;
            int ChildItemID = 0;
            if (SystemObjectName == SystemObject.Terms.ToString())
            {
                ParentID = objCourseItemsDAL.SaveCourseItems(CourseItemID, CourseID, AccounID, SystemObjectID, SystemObjectName, "", ParentCourseItemID, CourseItemTitle, Chapter, Section, PageNUmber);
            }
            else
            {
                ParentID = objCourseItemsDAL.SaveCourseItems(CourseItemID, CourseID, AccounID, SystemObjectID, SystemObjectName, CommentDesc, ParentCourseItemID, CourseItemTitle, Chapter, Section, PageNUmber);
            }
            if (ParentID > 0)
            {
                if (!string.IsNullOrEmpty(CommentDesc))
                {
                    if (SystemObjectName == SystemObject.Terms.ToString())
                    {
                        // save Definination call
                        int SysID = (int)Enum.Parse(typeof(SystemObject), SystemObject.Definations.ToString());
                        ChildItemID = SaveChildCourseItemFromSaveCourseItem(0, CourseID, AccounID, SysID, SystemObject.Definations.ToString(), CommentDesc, ParentID, "", Chapter, Section, PageNUmber);
                    }
                    /* Made Chnage on 10-1-2011 not to enter answer on every edit of question 
                    if (SystemObjectName == SystemObject.Questions.ToString())
                    {
                        // save Answer Call
                        int SysID = (int)Enum.Parse(typeof(SystemObject), SystemObject.Answers.ToString());
                        ChildItemID = SaveChildCourseItemFromSaveCourseItem(0, CourseID, AccounID, SysID, SystemObject.Answers.ToString(), CommentDesc, ParentID, "", Chapter, Section, PageNUmber);
                    }
                     * */
                }
            }
            return ParentID;
        }

        public int SaveChildCourseItemFromSaveCourseItem(int CourseItemID, int CourseID, int AccounID, int SystemObjectID, string SystemObjectName, string CommentDesc, int? ParentCourseItemID, string CourseItemTitle, int? Chapter, int? Section, int? PageNUmber)
        {
            int ChildItemID = 0;
            ChildItemID = objCourseItemsDAL.SaveCourseItems(CourseItemID, CourseID, AccounID, SystemObjectID, SystemObjectName, CommentDesc, ParentCourseItemID, CourseItemTitle, Chapter, Section, PageNUmber);
            return ChildItemID;
        }

        #endregion

        

        #region Delete Method

        public void DeleteItems(int CourseItemID)
        {
            objCourseItemsDAL.DeleteItems(CourseItemID);
        }

        #endregion

        #endregion


    }
}