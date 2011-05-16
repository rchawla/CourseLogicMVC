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

    public class AnswerController : Controller
    {
        //
        // GET: /Answer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnswerList(int ParentCourseItemID)
        {
            long AccountID;
            int SystemObjectID = (int)SystemObject.Answers;
            IEnumerable<GenericBE> EntityList = null;
            CourseItem objCourseItem = new CourseItem();
            int QID = ParentCourseItemID;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = objCourseItem.GetAllAnswer(QID, AccountID, SystemObjectID);
            }
            return View(EntityList);
        }

        public ActionResult GetChildByCourseItemID(int AnswerID, int SysObjectId)
        {
            long AccountID;
           // int SystemObjectID = (int)SystemObject.Answers;
            CourseItem objCourseItem = new CourseItem();
            GenericBE objGenericBE = new GenericBE();
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                objGenericBE = objCourseItem.CourseItemDetails(AccountID, SysObjectId, AnswerID).Single(Answer => Answer.CourseItemID == AnswerID);
            }
            return View(objGenericBE);
        }

      
    }
}
