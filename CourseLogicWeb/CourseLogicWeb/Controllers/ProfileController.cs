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
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CurrentCourses()
        {
            long AccountID = 0;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            }
            CoursesModel objCoursesModel = new CoursesModel();
            int RecordCount = objCoursesModel.StudentCourses(AccountID).Count();
            if (RecordCount == 0)
            {
                ViewData["Message"] = "There is no course added in your profile yet.Please click link below to add course in your profile.";
            }
            return View(objCoursesModel.StudentCourses(AccountID));
        }

        public ActionResult EditProfile()
        {
            long AccountID = 0;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            }
            ProfileModel objProfile = new ProfileModel();
            UsersBE UserEntities = new UsersBE();
            UserEntities = objProfile.GetAccountDetailsByAccountID(AccountID);
            return View(UserEntities);
        }

        public int SaveProfile(string FirstName, string LastName, string PrimaryEmail, string SecondaryEmail, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            long AccountID = 0;
            string RetrivePassword = string.Empty;

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            }

            ProfileModel objProfile = new ProfileModel();

            int ID = objProfile.SaveProfile(AccountID, FirstName, LastName, PrimaryEmail, SecondaryEmail, NewPassword);

            return ID;
        }
    }
}
