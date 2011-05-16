using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Text;
using System.Text.RegularExpressions;
using CourseLogicWeb.Models;
using CuteWebUI;
using CuteWebUI.Design;
using System.IO;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class FilesController : Controller
    {
        //
        // GET: /Files/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FileDisplay(int CourseItemID, int CourseID, int SystemObjectID)
        {
            FilesDAL objFilesDAL = new FilesDAL();
            return View(objFilesDAL.GetFiles(CourseItemID,CourseID,SystemObjectID));
        }

        public void DeleteFiles(int FileID, string FileName, int CourseItemID, int SystemObjectID, int CourseID)
        {
            FilesDAL objFilesDAL = new FilesDAL();
            string ItemType = null;
            if (SystemObjectID == Convert.ToInt32(SystemObject.Discussion))
            {
                ItemType = "~/Images/" + SystemObject.Discussion + "/" + CourseItemID + "/";
            }
            if (SystemObjectID == Convert.ToInt32(SystemObject.Questions))
            {
                ItemType = "~/Images/" + SystemObject.Questions + "/" + CourseItemID + "/";
            }
            if (SystemObjectID == Convert.ToInt32(SystemObject.Terms))
            {
                ItemType = "~/Images/" + SystemObject.Terms + "/" + CourseItemID + "/";
            }
            if (SystemObjectID == Convert.ToInt32(SystemObject.Summary))
            {
                ItemType = "~/Images/" + SystemObject.Summary + "/" + CourseItemID + "/";
            }
            if (SystemObjectID == Convert.ToInt32(SystemObject.Notes))
            {
                ItemType = "~/Images/" + SystemObject.Notes + "/" + CourseItemID + "/";
            }
            string FileToMove = ItemType;
            bool folderExist = System.IO.Directory.Exists(Server.MapPath(FileToMove));
            if (folderExist)
            {
                System.IO.FileInfo F = new System.IO.FileInfo(Server.MapPath(FileToMove + FileName));
                if (F.Exists)
                {
                    F.IsReadOnly = false;
                    F.Delete();
                    objFilesDAL.DeleteFiles(FileID);
                }
            }
        }
    }
}
