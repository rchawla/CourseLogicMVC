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
using System.IO;

namespace CourseLogicWeb.Controllers
{
    public class FileUploadController : Controller
    {
        //
        // GET: /FileUpload/


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            ProfileModel objProfile = new ProfileModel();
            UsersBE UserEntities = new UsersBE();
            string strFileExtention = string.Empty;
            bool IsFileOk = false;
            long AccountID = 0;
            ViewData["Message"] = "";
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
            }

            UserEntities = objProfile.GetAccountDetailsByAccountID(AccountID);

            #region File Upload Created By Manish Dhakecha
            try
            {
                if (file.ContentLength > 0)
                {
                    string[] strArryAllowExtention = { ".gif", ".jpeg", ".jpg", ".png", ".bmp" };
                    strFileExtention = System.IO.Path.GetExtension(file.FileName).ToLower();
                    for (int i = 0; i < strArryAllowExtention.Length; i++)
                    {
                        if (strFileExtention == strArryAllowExtention[i])
                        {
                            IsFileOk = true;
                            break;
                        }
                    }
                    if (IsFileOk)
                    {

                        string PreviousImageName = UserEntities.ProfileImage;

                        string strFile = "~/Images/ProfileImage/" + Convert.ToInt64(AccountID).ToString() + "/";
                        bool folderExist = System.IO.Directory.Exists(Server.MapPath(strFile));

                        if (!folderExist)
                        {
                            System.IO.Directory.CreateDirectory(Server.MapPath(strFile));
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(PreviousImageName.ToString()))
                            {
                                System.IO.FileInfo F = new System.IO.FileInfo(Server.MapPath(strFile + PreviousImageName.ToString()));
                                if (F.Exists)
                                {
                                    F.IsReadOnly = false;
                                    F.Delete();
                                }
                            }
                        }
                        var fileName = Path.GetFileName(file.FileName);
                        strFile = strFile + fileName;
                        System.IO.FileInfo F1 = new System.IO.FileInfo(Server.MapPath(strFile));
                        if (F1.Exists)
                        {
                            F1.IsReadOnly = false;
                        }
                        var path = Path.Combine(Server.MapPath(strFile), fileName);

                        file.SaveAs(Server.MapPath(strFile));

                        objProfile.UpdateProfileImage(AccountID, Path.GetFileName(file.FileName));

                        Response.Cookies.Remove("PImage");
                        HttpCookie cookie = new HttpCookie("PImage", fileName.ToString());
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        ViewData["Message"] = "Invalid File";
                    }
                }
            }
            catch (Exception ex)
            {
            }
            #endregion
            return Redirect("~/Profile/EditProfile");
        }

   

        public ActionResult ProfilePictureUpload()
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
    }
}
