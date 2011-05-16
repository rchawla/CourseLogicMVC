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
    public class SummaryController : Controller
    {
        //
        // GET: /Summary/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SummaryBySummaryID(int SID)
        {
            long AccountID;
            int SystemObjectID = (int)SystemObject.Summary;
            CourseItem objCourseItem = new CourseItem();
            GenericBE objGenericModel = new GenericBE();

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                objGenericModel = objCourseItem.CourseItemDetails(AccountID, SystemObjectID, SID).Single(Summary => Summary.CourseItemID == SID);
            }
            return View(objGenericModel);
        }       

    }
}
