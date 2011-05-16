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
    public class FavoriteController : Controller
    {
        //
        // GET: /Favorite/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult FavoriteList()
        {
            long AccountID;
            int CourseID = 0;          
            if (Request.QueryString["CourseID"] != null)
            {
                CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            }

            CourseItem ObjCourseItem = new CourseItem();
            IEnumerable<GenericBE> EntityList = null;
            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                EntityList = ObjCourseItem.GetFavoriteList(AccountID, CourseID);
            }
            if (EntityList.Count() == 0 || EntityList.Count() < 0)
            {
                ViewData["Message"] = "No item added in favorite yet. ";
            }
            return View(EntityList);
        }

    }
}
