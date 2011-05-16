using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class QuestionController : Controller
    {
        //
        // GET: /Question/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuestionList()
        {
            long AccountID;
            int CourseID = 10;
            int SystemObjectID = (int)SystemObject.Questions;
            CourseItem ObjCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = ObjCourseItem.CourseItems(CourseID, SystemObjectID, AccountID);
            }

            return View(EntityList);
        }

        public ActionResult QuestionListNew()
        {
            long AccountID;
            int CourseID = 10;
            int SystemObjectID = (int)SystemObject.Questions;
            CourseItem ObjCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = ObjCourseItem.CourseItems(CourseID, SystemObjectID, AccountID);
            }
            return View(EntityList);
        }

        public ActionResult QuestionByQuestionID(int QID)
        {
            long AccountID;
            int SystemObjectID = (int)SystemObject.Questions;
            CourseItem objCourseItem = new CourseItem();
            GenericBE objGenericBE = new GenericBE();
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                objGenericBE = objCourseItem.CourseItemDetails(AccountID, SystemObjectID, QID).Single(Question => Question.CourseItemID == QID);
            }
            return View(objGenericBE);
        }

        public ActionResult btnSave()
        {
            return RedirectToAction("QuestionDetailByQuestionID");
        }
    }
}
