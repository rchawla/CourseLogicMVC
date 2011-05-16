using System;
using System.Linq;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class CourseHomeController : Controller
    {
        //
        // GET: /CourseHome/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseHome()
        {
            int intCourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            int IsTopVoted = 0;
            int PageNumber = 1;
            if (!string.IsNullOrEmpty(Request.QueryString["IsTopVoted"]))
            {
                IsTopVoted = Convert.ToInt32(Request.QueryString["IsTopVoted"]);
            }
            if (!string.IsNullOrEmpty(Request.QueryString["PageNumber"]))
            {
                PageNumber = Convert.ToInt32(Request.QueryString["PageNumber"]);
            }
            CourseItem objCourseItem = new CourseItem();
            int intRecords = 0;
            intRecords = objCourseItem.GetCourseHomeDetails(intCourseID, IsTopVoted, PageNumber).Count();
            if (intRecords <= 0)
            {
                ViewData["Message"] = "Be the first to collaborate.";
            }
            return View(objCourseItem.GetCourseHomeDetails(intCourseID, IsTopVoted, PageNumber));
        }

        public ActionResult DiscussionListingCourseHome(int CourseID, int SystemobjectID, int PageNumber, int TopVoted, int MyAdded)
        {
            CourseItem objCourseItem = new CourseItem();
            int AccountID = 0;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt32(Request.Cookies["ID"].Value.ToString());
            }
            return View(objCourseItem.GetDiscussionListingCourseHome(CourseID, AccountID ,SystemobjectID,PageNumber,TopVoted,MyAdded));
        }
    }
}
