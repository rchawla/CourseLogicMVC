using System;
using System.Linq;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class CourseWalkthroughController : Controller
    {
        //
        // GET: /CourseWalkthrough/

        public ActionResult Verfiy_Course()
        {
            int CourseID = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["CourseID"]))
            {
                CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            }
            int AccountID = 0;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt32(Request.Cookies["ID"].Value.ToString());
            }
            CourseWalkthroughModel objCourseWalkthroughModel = new CourseWalkthroughModel();
            GenericBE objGenericBE = objCourseWalkthroughModel.GetCourseDetail(AccountID, CourseID).Single();
            objGenericBE.AccountID = AccountID;

            return View(objGenericBE);
        }

    }
}
