using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class EditorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadEditor(int CID, int ParentCID, int CourseID, string SystemObjectName)
        {
            GenericBE objGenericModel = new GenericBE();


            if ( ParentCID  == 0)
            {
                // load default answer new answer
                objGenericModel.ParentCourseItemID = CID ;
                objGenericModel.CourseID = CourseID;
                objGenericModel.SystemObjectName = SystemObjectName;
                //return View(objGenericModel);
            }
            else if (ParentCID > 0)
            {
                // Call Database and get value 
                long AccountID = 0;
                if (Request.Cookies["ID"] != null)
                {
                    AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                }
                LoadEditor objLoadEditor = new LoadEditor(CID, ParentCID, AccountID);
                objGenericModel = objLoadEditor._LoadEditor.Single();
                //return View(objGenericModel);
            }
            return View(objGenericModel);
        }

        public void SaveChildItem(int CourseItemID, int CourseID, string AnswerDesc, int ParentCourseItemID, string CourseItemTitle, string systemobjectName)
        {
            int AccountID;
            string EncodeDescription = HttpUtility.HtmlDecode(AnswerDesc);
            CourseItem objCourseItem = new CourseItem();
            int SystemObjectId = (int)Enum.Parse(typeof(SystemObject), systemobjectName);

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt32(Request.Cookies["ID"].Value.ToString());
                if (ParentCourseItemID == 0)
                {
                    //for new ans
                    ParentCourseItemID = CourseItemID;
                    CourseItemID = 0;
                    objCourseItem.SaveCourseItem(CourseItemID, CourseID, AccountID, SystemObjectId, systemobjectName, EncodeDescription, ParentCourseItemID, CourseItemTitle,0,0,0);
                }
                else
                {
                    //for edit 
                    objCourseItem.SaveCourseItem(CourseItemID, CourseID, AccountID, SystemObjectId, systemobjectName, EncodeDescription, ParentCourseItemID, CourseItemTitle,0,0,0);

                }
            }
        }
    }
}
