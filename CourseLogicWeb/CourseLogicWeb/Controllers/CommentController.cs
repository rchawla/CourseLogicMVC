using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadComments(long AssociatedID, string SystemObjectName, long AccountID, Boolean CommentFlag,int CourseID)
        {
            CourseItem objCourseItem = new CourseItem();
            return View(objCourseItem.GetAllComments(AssociatedID, SystemObjectName, AccountID, CommentFlag, CourseID));
        }

        public ActionResult CommentByCommentID(int CID, string SystemObjectName, long AccountID, int ParentID, int CourseID, int IsBlank)
        {
            GenericBE objGenericModel = new GenericBE();
            if (ParentID > 0 && CID <= 0)
            {
                if (IsBlank > 0)
                {
                    objGenericModel.CourseItemID = 0;
                    objGenericModel.CourseItemDescription = "";
                    objGenericModel.ParentCourseItemID = ParentID;
                    objGenericModel.SystemObjectName = SystemObjectName;
                    objGenericModel.AccountID = AccountID;
                    objGenericModel.SystemObjectID = 12;
                    objGenericModel.CourseID = CourseID;
                    objGenericModel.PageNumber = 1;
                    objGenericModel.IsBlankComment = 1;
                }
                else if (IsBlank <= 0)
                {
                    objGenericModel.CourseItemID = 0;
                    objGenericModel.CourseItemDescription = "";
                    objGenericModel.ParentCourseItemID = ParentID;
                    objGenericModel.SystemObjectName = SystemObjectName;
                    objGenericModel.AccountID = AccountID;
                    objGenericModel.SystemObjectID = 12;
                    objGenericModel.CourseID = CourseID;
                    objGenericModel.PageNumber = 1;
                    objGenericModel.IsBlankComment = 0;
                }
            }
            else if (ParentID > 0 && CID > 0)
            {
                CourseItem objCourseItem = new CourseItem();
                objGenericModel = objCourseItem.EditComments(CID, SystemObjectName, AccountID);
                objGenericModel.IsBlankComment = 0;
            }
            return View(objGenericModel);
        }

        public void SaveComment(int CourseItemID, int CourseID, int AccountID, int SystemObjectID, string SystemObjectName, string CommentDesc, int ParentCourseItemID)
        {
            CourseItem objCourseItem = new CourseItem();
            objCourseItem.SaveComment(CourseItemID, CourseID, AccountID, SystemObjectID, SystemObjectName, CommentDesc, ParentCourseItemID);
        }

        public void DeleteComments(int CourseItemID)
        {
            CourseItem objCourseItem = new CourseItem();
            objCourseItem.DeleteItems(CourseItemID);
        }
    }
}
