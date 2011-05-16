using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class ChildCountController : Controller
    {
        //
        // GET: /ChildCount/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadChildCount(int CourseItemID)
        {
            GenericBE objGenericModel = new GenericBE();
            if (CourseItemID > 0)
            {
                CourseItem objCourseItem = new CourseItem();
                int Childcout = objCourseItem.GetCourseItemChildCount(CourseItemID);
                objGenericModel.CourseItemChildCount = Childcout;
            }

            return View(objGenericModel);
        }

    }
}
