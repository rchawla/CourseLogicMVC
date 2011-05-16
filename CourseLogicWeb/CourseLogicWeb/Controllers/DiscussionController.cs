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
    public class DiscussionController : Controller
    {
        //
        // GET: /Discussion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DiscussionList()
        {
            long AccountID;
            int CourseID = 10;
            int SystemObjectID = (int)SystemObject.Discussion;
            CourseItem ObjCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = ObjCourseItem.CourseItems(CourseID, SystemObjectID, AccountID);
            }
            return View(EntityList);
        }

        public ActionResult DiscussionByDiscussionID(int DID)
        {
            long AccountID;
            int SystemObjectID = (int)SystemObject.Discussion;
            GenericBE objGenericModel = new GenericBE();
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                CourseItem objCourseItem = new CourseItem();
                objGenericModel = objCourseItem.CourseItemDetails(AccountID, SystemObjectID, DID).Single(DiscussionID => DiscussionID.CourseItemID == DID);
            }
            return View(objGenericModel);
        }

    }
}
