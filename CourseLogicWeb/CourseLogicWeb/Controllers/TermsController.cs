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
    public class TermsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TermsList()
        {
            long AccountID;
            int CourseID = 10;
            int SystemObjectID = (int)(SystemObject.Terms);
            CourseItem ObjCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = ObjCourseItem.CourseItems(CourseID, SystemObjectID, AccountID);
            }

            return View(EntityList);
        }


        public ActionResult TermByTermID(int TID)
        {
            long AccountID;
            int SystemObjectID = (int)(SystemObject.Terms);
            CourseItem objCourseItem = new CourseItem();
            GenericBE objGenericBE = new GenericBE();

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                objGenericBE = objCourseItem.CourseItemDetails(AccountID, SystemObjectID, TID).Single(Term => Term.CourseItemID == TID);
            }

            return View(objGenericBE);
        }

        public ActionResult DefinitionList(int ParentCourseItemID)
        {
            long AccountID;
            int SystemObjectID = (int)(SystemObject.Definations);
            int TID = ParentCourseItemID;
            CourseItem objCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = objCourseItem.GetAllAnswer(TID, AccountID, SystemObjectID);
            }

            return View(EntityList);
        }

    }
}
