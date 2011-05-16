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
    public class DeleteItemsController : Controller
    {
        //
        // GET: /DeleteItems/

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteItems()
        {
            QuestionController c = new QuestionController();
            int CourseItemID = Convert.ToInt32(Request.Form["hdnCourseItemID"]);
            string SystemObjectName = Request.Form["hdnSystemObjectName"];
            int CourseID = Convert.ToInt32(Request.Form["hdnCourseID"]);
            int IsCourseHomePage = Convert.ToInt32(Request.Form["hdnIsCourseHomePage"]);
            string ControllerName = Request.Form["hdnCName"];
            int ParentID = Convert.ToInt32(Request.Form["hdnParentID"]);
            CourseItem objCourseItem = new CourseItem();
            objCourseItem.DeleteItems(CourseItemID);
            long AccountID = 0;

            if (Request.QueryString["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.QueryString["ID"]);
            }
            if (IsCourseHomePage == 1)
            {
                //return Redirect("http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                //return RedirectToAction("RedirectPage", "Registration", "http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                return RedirectToAction("RedirectChild", new { CourseID });
            }
            else
            {
                if (ControllerName == ControllerNames.QuestionByQuestionID.ToString() && SystemObjectName == SystemObject.Answers.ToString())
                {
                    //question page when answer is deleted 
                    return Redirect("http://localhost:3061/Question/QuestionByQuestionID?QID=" + ParentID + "&CourseID=" + CourseID);
                }
                else if (ControllerName == ControllerNames.QuestionByQuestionID.ToString() && SystemObjectName == SystemObject.Questions.ToString())
                {
                    //CourseHome page when Question is deleted 
                    //return Redirect("http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                    return RedirectToAction("RedirectChild", new { CourseID });
                }
                else if (ControllerName == ControllerNames.TermByTermID.ToString() && SystemObjectName == SystemObject.Terms.ToString())
                {
                    //CourseHome page when Terms is deleted 
                    //return Redirect("http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                    return RedirectToAction("RedirectChild", new { CourseID });
                }
                else if (ControllerName == ControllerNames.TermByTermID.ToString() && SystemObjectName == SystemObject.Definations.ToString())
                {
                    //CourseHome page when Question is deleted 
                    return Redirect("http://localhost:3061/Terms/TermByTermID?TID=" + ParentID + "&CourseID=" + CourseID);
                }
                else if (ControllerName == ControllerNames.DiscussionByDiscussionID.ToString() && SystemObjectName == SystemObject.Discussion.ToString())
                {
                    //CourseHome page when Discussion is deleted 
                    //return Redirect("http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                    return RedirectToAction("RedirectChild", new { CourseID });
                }
                else if (ControllerName == ControllerNames.NoteByNoteID.ToString() && SystemObjectName == SystemObject.Notes.ToString())
                {
                    //CourseHome page when Note is deleted 
                    //return Redirect("http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                    return RedirectToAction("RedirectChild", new { CourseID });
                }
                else if (ControllerName == ControllerNames.SummaryBySummaryID.ToString() && SystemObjectName == SystemObject.Summary.ToString())
                {
                    //CourseHome page when Summary is deleted 
                    //return Redirect("http://localhost:3061/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0");
                    return RedirectToAction("RedirectChild", new { CourseID });
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult RedirectChild(int CourseID)
        {
            ViewData["URL"] = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0" + "&PageNumber=1";
            return View();
        }
    }
}
