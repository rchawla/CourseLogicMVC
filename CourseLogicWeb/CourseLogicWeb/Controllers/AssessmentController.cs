using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class AssessmentController : Controller
    {
        //
        // GET: /Assessment/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Assessment/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Assessment/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Assessment/Create

       
        public ActionResult AssessmentList()
        {
            long AccountID;
           
            AssessmentModel objAssessmentM = new AssessmentModel();
            int intRecords = 0;

            IEnumerable<CalendarBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = objAssessmentM.GetTopAssessment(AccountID);
                intRecords = objAssessmentM.GetTopAssessment(AccountID).Count();
            }

            if (intRecords <= 0)
            {
                ViewData["Message"] = "No Assessment is available yet. Be the one to create Assessment.";
            }

            return View(EntityList);

        }
        
        //
        // GET: /Assessment/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Assessment/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Assessment/Delete/5

        public ActionResult CourseColor()
        {
            
            AssessmentModel objAssessmentM = new AssessmentModel();
            long AccountID = 0;
          
            IEnumerable<CalendarBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value);
                EntityList = objAssessmentM.GetCourseColor(AccountID);
                
            }

            return View(EntityList);

        }

        public ActionResult CourseWiseAssessment()
        {
            long AccountID;
            Int64 CourseID =Convert.ToInt64(Request.QueryString["CourseID"]);
           
            AssessmentModel objAssessmentM = new AssessmentModel();
            int intRecords = 0;
           
            IEnumerable<CalendarBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = objAssessmentM.GetTopCourseAssessment(CourseID);
                intRecords = objAssessmentM.GetTopCourseAssessment(CourseID).Count();
            }
           
            if (intRecords <= 0)
            {
                ViewData["Message"] = "No Assessment is available yet. Be the one to create Assessment.";
            }
             
            return View(EntityList);
      
        }
        //
        // POST: /Assessment/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
