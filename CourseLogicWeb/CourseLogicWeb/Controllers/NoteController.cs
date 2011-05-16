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
    public class NoteController : Controller
    {
        //
        // GET: /Note/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoteList()
        {
            long AccountID;
            int CourseID = 10;
            int SystemObjectID = (int)SystemObject.Notes;
            CourseItem ObjCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList =  ObjCourseItem.CourseItems(CourseID, SystemObjectID, AccountID);
            }
            return View(EntityList);
        }

        public ActionResult NoteByNoteID(int NID)
        {
            long AccountID;
            int SystemObjectID = (int)SystemObject.Notes;
            CourseItem objCourseItem = new CourseItem();
            GenericBE objGenericModel = new GenericBE();

            if (Request.Cookies["ID"] != null)
            {
                 AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                 objGenericModel = objCourseItem.CourseItemDetails(AccountID, SystemObjectID, NID).Single(Note => Note.CourseItemID == NID);
            }
            return View(objGenericModel);
        }       

    }
}
