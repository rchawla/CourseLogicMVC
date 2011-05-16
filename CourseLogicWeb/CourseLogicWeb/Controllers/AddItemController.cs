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
    public class AddItemController : Controller
    {
        //
        // GET: /AddItem/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadAddItem(int CourseItemID, int CourseID, string SystemObjectName, string IsCourseHomePage)
        {
            GenericBE objGenericModel = new GenericBE();
            int SystemObjectID = (int)Enum.Parse(typeof(SystemObject), SystemObjectName);
            if (CourseItemID <= 0)
            {
                // load default answer new answer
                //objGenericModel.ParentCourseItemID = ParentCID;
                objGenericModel.CourseID = CourseID;
                objGenericModel.SystemObjectName = SystemObjectName;
                objGenericModel.CourseID = CourseID;
                objGenericModel.IsAddItem = true;
                objGenericModel.IsCourseHomePage = Convert.ToInt32(IsCourseHomePage);
                //return View(objGenericModel);
            }
            else if (CourseItemID > 0)
            {
                // Call Database and get value 
                long AccountID;
                CourseItem objCourseItem = new CourseItem();

                if (Request.Cookies["ID"] != null)
                {
                    AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                    objGenericModel = objCourseItem.CourseItemDetails(AccountID, SystemObjectID, CourseItemID).Single();
                }
                objGenericModel.IsAddItem = false;
                objGenericModel.IsCourseHomePage = Convert.ToInt32(IsCourseHomePage);
            }
            using (CuteWebUI.MvcUploader uploader = new CuteWebUI.MvcUploader(System.Web.HttpContext.Current))
            {
                uploader.UploadUrl = Response.ApplyAppPathModifier("~/UploadHandler.ashx");
                //the data of the uploader will render as <input type='hidden' name='myuploader'> 
                uploader.Name = "myuploader";
                uploader.AllowedFileExtensions = "*.jpg,*.gif,*.png,*.bmp,*.doc,*.docx,*.pdf,*.xls,*.xlsx,*.ppt,*.ppsx";

                //allow select multiple files
                uploader.MultipleFilesUpload = true;

                uploader.ManualStartUpload = true;

                //tell uploader attach a button
                uploader.InsertButtonID = "uploadbutton";

                //prepair html code for the view
                ViewData["uploaderhtml"] = uploader.Render();

            }
            return View(objGenericModel);
        }

        //
        // POST: /AddItem/LoadAddItem
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult LoadAddItem(GenericBE model)
        {
            //return View(model);
            return RedirectToAction("LoadAddItem", new { CourseItemID = model.CourseItemID, CourseID = model.CourseID, SystemObjectName = model.SystemObjectName });
        }

        public void SaveAddItem(int CourseItemID, int CourseID, string CourseItemTitle, string ItemDesc, int Chapter, int Section, int PageNumber, string systemobjectName, int AccountID)
        {
            // Save CourseItem
            string Search = "$%comma";
            string replace = "'";
            if (!string.IsNullOrEmpty(ItemDesc))
            {
                ItemDesc = ItemDesc.Replace(Search, replace);
            }
            CourseItem objCourseItem = new CourseItem();
            int? parentid = null;
            int? result = null;
            int SystemObjectID = (int)Enum.Parse(typeof(SystemObject), systemobjectName);
            result =  objCourseItem.SaveCourseItem(CourseItemID, CourseID, AccountID, SystemObjectID, systemobjectName, ItemDesc, parentid, CourseItemTitle, Chapter, Section, PageNumber);

            string strFile = "~/Images/TempAttachment/" + Convert.ToInt64(AccountID).ToString() + "/";
            string FileToMove = "~/Images/" + systemobjectName + "/" + result + "/";
            bool folderExist = System.IO.Directory.Exists(Server.MapPath(strFile));

            #region Move Files To Corresponding Folder From Temparory Folder

            if (folderExist)
            {
                string[] files = System.IO.Directory.GetFiles(Server.MapPath(strFile));

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    string fileName = "";
                    string destFile = "";
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);

                    bool FileToMoveFolderExist = System.IO.Directory.Exists(Server.MapPath(FileToMove));
                    if (!FileToMoveFolderExist)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(FileToMove));
                        destFile = System.IO.Path.Combine(FileToMove, fileName);
                        System.IO.FileInfo F = new System.IO.FileInfo(Server.MapPath(FileToMove + fileName.ToString()));
                        if (F.Exists)
                        {
                            F.IsReadOnly = false;
                            F.Delete();
                        }
                        System.IO.File.Copy(s, Server.MapPath(destFile), true);
                        System.IO.File.Delete(Server.MapPath(strFile + fileName));
                    }
                    else
                    {
                        destFile = System.IO.Path.Combine(FileToMove, fileName);
                        System.IO.FileInfo F = new System.IO.FileInfo(Server.MapPath(FileToMove + fileName.ToString()));
                        if (F.Exists)
                        {
                            F.IsReadOnly = false;
                            F.Delete();
                        }
                        System.IO.File.Copy(s, Server.MapPath(destFile), true);
                        System.IO.File.Delete(Server.MapPath(strFile + fileName));
                    }

                    #region Save Files Detail Into Database
                    // Save File detail into Data Base
                    string FileExtensions = null;
                    string DBFileName = null;
                    DBFileName = fileName;
                    char[] ch = { '.' };
                    string[] str1 = fileName.Split(ch);
                    FileExtensions = str1[1].ToString();
                    FilesDAL objFileDAL = new FilesDAL();
                    objFileDAL.SaveFileDetail(Convert.ToInt32(result), CourseID, AccountID, SystemObjectID, FileExtensions, DBFileName);
                    #endregion
                }
                System.IO.Directory.Delete(Server.MapPath(strFile));
            }

            #endregion
        }

        #region Simple 2 - Upload multiple files

        public PartialViewResult Attachment(string myuploader)
        {
            using (CuteWebUI.MvcUploader uploader = new CuteWebUI.MvcUploader(System.Web.HttpContext.Current))
            {
                uploader.UploadUrl = Response.ApplyAppPathModifier("~/UploadHandler.ashx");
                //the data of the uploader will render as <input type='hidden' name='myuploader'> 
                uploader.Name = "myuploader";
                uploader.AllowedFileExtensions = "*.jpg,*.gif,*.png,*.bmp,*.doc,*.docx";

                //allow select multiple files
                uploader.MultipleFilesUpload = true;

                uploader.ManualStartUpload = true;

                //tell uploader attach a button
                uploader.InsertButtonID = "uploadbutton";

                //prepair html code for the view
                ViewData["uploaderhtml"] = uploader.Render();


                string Path = Server.MapPath("~/Images/Guest/");
                //if it's HTTP POST:
                if (!string.IsNullOrEmpty(myuploader))
                {
                    List<string> processedfiles = new List<string>();
                    //for multiple files , the value is string : guid/guid/guid 
                    foreach (string strguid in myuploader.Split('/'))
                    {
                        Guid fileguid = new Guid(strguid);
                        CuteWebUI.MvcUploadFile file = uploader.GetUploadedFile(fileguid);
                        if (file != null)
                        {
                            //you should validate it here:

                            //now the file is in temporary directory, you need move it to target location
                            //file.MoveTo("~/myfolder/" + file.FileName);
                            System.IO.FileInfo F = new System.IO.FileInfo(Server.MapPath("~/Images/Guest/" + file.FileName.ToString()));
                            {
                                if (F.Exists)
                                {
                                    F.IsReadOnly = false;
                                    F.Delete();
                                }
                            }

                            file.MoveTo(Path + file.FileName);
                            processedfiles.Add(file.FileName);
                        }
                    }
                    if (processedfiles.Count > 0)
                    {
                        ViewData["UploadedMessage"] = string.Join(",", processedfiles.ToArray()) + " have been processed.";
                    }
                }
            }
            return PartialView();
        }

        #endregion
    }
}
