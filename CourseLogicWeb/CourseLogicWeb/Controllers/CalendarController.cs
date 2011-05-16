using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections;
using CLFacadeLayer;
 


namespace CourseLogicWeb.Controllers
{
    public class CalendarController : Controller
    {
        
        //
        // GET: /Calendar/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseAssessments()
        {
            Int64 CourseID = Convert.ToInt64(Request.QueryString["CourseID"].ToString());
            CalendarDAL objCalendarDAL = new CalendarDAL();
            IList<CalendarBE> tasksList = new List<CalendarBE>();
            Int64 AccountId = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            ViewData["AssTypes"] = objCalendarDAL.GetAssessmentTypeList();

            tasksList = objCalendarDAL.GetCourseAssessment(CourseID,AccountId);
          
            //return Json(rows, JsonRequestBehavior.AllowGet);
            return View(tasksList);
        }
        public JsonResult DisplayMyAssessment(Int64 AccountID)
        {
            CalendarDAL objCalendarDAL = new CalendarDAL();
            IList<CalendarBE> tasksList = new List<CalendarBE>();

            tasksList = objCalendarDAL.GetMyAssessment(AccountID);
           


            var eventList = from e in tasksList

                            select new
                            {


                                id = e.AssessmentID,

                                title = e.Name,

                                description = e.Description,

                                start = DateConv((DateTime)e.DateDue),

                                end = DateConv((DateTime)e.DateDue),

                                Points = e.PointsPossible.ToString(),

                                CourseName = e.CourseTitle.ToString(),

                                TypeID = e.AssessmentTypeID,

                                AssessmentType = e.AssessmentTypeName.ToString(),

                                color=e.color.ToString(),

                                allDay = false
                            };
            var rows = eventList.ToArray();

            //return Json(rows, JsonRequestBehavior.AllowGet);
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DisplayCourseAssessment(int CourseID)
        {
           Int64 AccountId=Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            CalendarDAL objCalendarDAL = new CalendarDAL();
            IList<CalendarBE> tasksList = new List<CalendarBE>();

            tasksList = objCalendarDAL.GetCourseAssessment(CourseID,AccountId);



            var eventList = from e in tasksList

                            select new
                            {
                                
                                id = e.AssessmentID,

                                title = e.Name,

                                description=e.Description,
                                
                                start= DateConv((DateTime) e.DateDue),

                                end = DateConv((DateTime)e.DateDue),

                                Points=e.PointsPossible.ToString(),
                               
                                CourseName=e.CourseTitle.ToString(),

                                TypeID=e.AssessmentTypeID,

                                AssessmentType=e.AssessmentTypeName.ToString(),

                                color=e.color,
                              
                                allDay = false
                            };
            var rows = eventList.ToArray();

            //return Json(rows, JsonRequestBehavior.AllowGet);
            return Json(rows, JsonRequestBehavior.AllowGet);
        }


        public string DateConv(DateTime date)
        {
            DateTime date1 = new DateTime();
            date1 = date;
             string NewDate = date1.ToUniversalTime().ToString("r");
             return NewDate;
        }

        public ActionResult MyAssessments()
        {
            Int64 AccountID = Convert.ToInt64(Request.QueryString["AccountID"]);
            CalendarDAL objCalendarDAL = new CalendarDAL();
            IList<CalendarBE> tasksList = new List<CalendarBE>();
            ViewData["AssTypes"] = objCalendarDAL.GetAssessmentTypeList();

            tasksList = objCalendarDAL.GetMyAssessment(AccountID);

            //return Json(rows, JsonRequestBehavior.AllowGet);
            return View(tasksList);
        }
       
       public ActionResult AddCourseAssessment( String name, String desc,int typeID,string Points,DateTime Duedate,Int64 CourseID)
        {
            CalendarDAL objcal = new CalendarDAL();
            objcal.AddAssessment(name,desc, typeID,Points,Duedate,CourseID);
            return Json(objcal);
        }

      

       
       
    }

}
