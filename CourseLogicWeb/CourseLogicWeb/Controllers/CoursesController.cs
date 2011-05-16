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
    public class CoursesController : Controller
    {
        //
        // GET: /Courses/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentCourses()
        {
            long AccountID = 0;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            }
            CoursesModel objCoursesModel = new CoursesModel();
            
            return View(objCoursesModel.StudentCourses(AccountID));
        }

        public ActionResult CourseByCourseID(int CourseDetail)
        {
            int CID = Convert.ToInt32(Request.QueryString["CourseID"]);
            CoursesModel objCoursesModel = new CoursesModel();
            GenericBE objGenericBE = objCoursesModel.CourseByCourseID(CID).Single(Course => Course.CourseID == CID);
            if (CourseDetail == 1)
            {
                objGenericBE.IsBoth = true;
            }
            return View(objGenericBE);
        }


        public ActionResult CourseList(int StudentAccountID, string Prefix, string CourseNumber, string CourseTitle, string CourseSection, int SchoolID, int TermID, int Year, bool IsSearch)
        {
            IEnumerable<GenericBE> EntityList = null;
            CoursesModel objCoursesModel = new CoursesModel();

            int PageNumber = 1;
            if (!string.IsNullOrEmpty(Request.QueryString["PageNumber"]))
            {
                PageNumber = Convert.ToInt32(Request.QueryString["PageNumber"]);
            }

            EntityList = objCoursesModel.Search_CoursesList(StudentAccountID, Prefix, CourseNumber, CourseTitle, CourseSection, SchoolID, TermID, Year, PageNumber);

            if (EntityList.Count() == 0 || EntityList.Count() < 0)
            {
                ViewData["Message"] = "No matching record found. Please re-define search criteria.";
            }

            return View(EntityList);
        }

        public ActionResult SearchCourse()
        {
            GenericBE objGenericBE = new GenericBE();
            long AccountID = 0;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value);
            }
            objGenericBE.AccountID = AccountID;
            objGenericBE.Prefix = "";
            objGenericBE.CourseTitle = "";
            objGenericBE.CourseNumber = "";
            objGenericBE.SchoolID = 0;
            objGenericBE.Course_Section = "";
            objGenericBE.TermID = 0;
            return View(objGenericBE);
        }

        public void SaveStudentCourse(int AccountID, int CourseID)
        {
            CoursesModel objCourse = new CoursesModel();
            objCourse.SaveStudentCourse(AccountID, CourseID);
        }

    }
}
