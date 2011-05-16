using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class VoteController : Controller
    {
        //
        // GET: /Vote/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VoteUp()
        {
            int AssociatedID = Convert.ToInt32(Request.Params["AssociatedId"]);
            int PostedByAccountID = Convert.ToInt32(Request.Params["AccID"]);
            string SystemObjectName = Request.Params["SysObjectName"];
            long CourseID = Convert.ToInt64(Request.Params["CID"]);
            long AccountID;
            GenericBE objGenericModel = new GenericBE();

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());

                VoteUp objVoteup = new VoteUp(AssociatedID, SystemObjectName, AccountID, CourseID);
                VoteModel objVoteModel = objVoteup._VoteList.Single();
                objGenericModel.VoteCount = objVoteModel.TotalVotes;
                objGenericModel.SystemObjectName = SystemObjectName;
                objGenericModel.CourseItemID = Convert.ToInt32(AssociatedID);
                objGenericModel.AccountID = Convert.ToInt32(PostedByAccountID);
                objGenericModel.CourseID = Convert.ToInt32(CourseID);
                objGenericModel.VoteUpDisplay = Convert.ToInt32(objVoteModel.CountUp);
                objGenericModel.VoteDownDisplay = Convert.ToInt32(objVoteModel.CountDown);
                objGenericModel.StarCount = Convert.ToInt32(objVoteModel.StarCount);
                objGenericModel.StarDisplay = objVoteModel.StarDisplay;
            }
            return PartialView("Vote", objGenericModel);


        }

        public ActionResult VoteDown()
        {
            int PostedByAccountID = Convert.ToInt32(Request.Params["AccID"]);
            int AssociatedID = Convert.ToInt32(Request.Params["AssociatedId"]);
            string SystemObjectName = Request.Params["SysObjectName"];
            long CourseID = Convert.ToInt64(Request.Params["CID"]);
            long AccountID;
            GenericBE objGenericModel = new GenericBE();

            if (Request.Cookies["ID"] != null)
            {
                AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                VoteDown objVoteDown = new VoteDown(AssociatedID, SystemObjectName, AccountID, CourseID);
                VoteModel objVoteModel = objVoteDown._VoteList.Single();
               
                objGenericModel.VoteCount = objVoteModel.TotalVotes;
                objGenericModel.SystemObjectName = SystemObjectName;
                objGenericModel.CourseItemID = Convert.ToInt32(AssociatedID);
                objGenericModel.AccountID = Convert.ToInt32(PostedByAccountID);
                objGenericModel.CourseID = Convert.ToInt32(CourseID);
                objGenericModel.VoteUpDisplay = Convert.ToInt32(objVoteModel.CountUp);
                objGenericModel.VoteDownDisplay = Convert.ToInt32(objVoteModel.CountDown);
                objGenericModel.StarCount = objVoteModel.StarCount;
                objGenericModel.StarDisplay = objVoteModel.StarDisplay;
            }
            return PartialView("Vote", objGenericModel);

        }

        public ActionResult Star()
        {
            int PostedByAccountID = Convert.ToInt32(Request.Params["AccID"]);
            int AssociatedID = Convert.ToInt32(Request.Params["AssociatedId"]);
            string SystemObjectName = Request.Params["SysObjectName"];
            long CourseID = Convert.ToInt64(Request.Params["CID"]);
            long AccountID;

             GenericBE objGenericModel = new GenericBE();

             if (Request.Cookies["ID"] != null)
             {
                 AccountID = Convert.ToInt64(Request.Cookies["ID"].Value.ToString());
                 Star objStar = new Star(AssociatedID, SystemObjectName, AccountID, CourseID);
                 VoteModel objVoteModel = objStar._VoteStarList.Single();
                
                 objGenericModel.VoteCount = objVoteModel.TotalVotes;
                 objGenericModel.SystemObjectName = SystemObjectName;
                 objGenericModel.CourseItemID = Convert.ToInt32(AssociatedID);
                 objGenericModel.AccountID = Convert.ToInt32(PostedByAccountID);
                 objGenericModel.CourseID = Convert.ToInt32(CourseID);
                 objGenericModel.VoteUpDisplay = Convert.ToInt32(objVoteModel.CountUp);
                 objGenericModel.VoteDownDisplay = Convert.ToInt32(objVoteModel.CountDown);
                 objGenericModel.StarCount = objVoteModel.StarCount;
                 objGenericModel.StarDisplay = objVoteModel.StarDisplay;
             }
            return PartialView("Vote", objGenericModel);
        }
    }
}
