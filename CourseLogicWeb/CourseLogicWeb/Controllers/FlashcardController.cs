using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Text.RegularExpressions;
using CourseLogicWeb.Models;
using CLFacadeLayer;

namespace CourseLogicWeb.Controllers
{
    public class FlashcardController : Controller
    {
        //
        // GET: /Flashcard/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetFlashCardSets(int CourseID)
        {
            FlashcardModel objFlashcard = new FlashcardModel();
            int intRecords = 0;
            intRecords = objFlashcard.FlashCardSets(CourseID).Count();
            if (intRecords <= 0)
            {
                ViewData["Message"] = "No flashcard set is available yet. Be the one to create flashcard.";
            }
            return View(objFlashcard.FlashCardSets(CourseID));
        }

        //public ActionResult SaveFlashCardSet(int CourseID, int AccountID, int FlashCardID, string FlashCardTitle, string FlashCardSubject, string FlashCardDescription, bool VotedUp, bool Favorite, bool YouAdded, bool Assessment, bool IsChapter, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected)
        public int SaveFlashCardSet(int CourseID, int AccountID, int FlashCardID, string FlashCardTitle, string FlashCardSubject, string FlashCardDescription, bool VotedUp, bool Favorite, bool YouAdded, bool Assessment, bool IsChapter, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected, int TotalItems)
        {
            FlashcardModel objFlashCard = new FlashcardModel();
            int intFlashCardID = objFlashCard.SaveFlashCardSet(CourseID, AccountID, FlashCardID, FlashCardTitle, FlashCardSubject, FlashCardDescription, VotedUp, Favorite, YouAdded, Assessment, IsChapter, CommaSeperatedChapters, IsNotesSelected, IsQuestionSelected, IsTermSelected, IsSummarySelected,TotalItems);
            return intFlashCardID;
            //return RedirectToAction("SelectItems", new { FID = intFlashCardID});
        }

        public ActionResult GetFlashCardByFlashCardID(int CourseID, int AccountID, int FlashCardID)
        {
            FlashcardModel objFlashcard = new FlashcardModel();
            GenericBE objGenericBE = new GenericBE();
            if (FlashCardID > 0)
            {
                objGenericBE = objFlashcard.GetFlashCardByFlashCardID(CourseID, AccountID, FlashCardID).Single();
                //return View(objFlashcard.GetFlashCardByFlashCardID(CourseID, AccountID, FlashCardID));
            }
            else
            {
                objGenericBE.AccountID = AccountID;
                objGenericBE.CourseID = CourseID;
                objGenericBE.FlashCardID = 0;
                objGenericBE.IsAssessment = false;
                objGenericBE.IsChapter = false;
                objGenericBE.IsFavourted = false;
                objGenericBE.IsNotes = false;
                objGenericBE.IsQuestion = false;
                objGenericBE.IsSummary = false;
                objGenericBE.IsTerms = false;
                objGenericBE.IsVotedUp = false;
                objGenericBE.IsYourAdded = false;
            }
            return View(objGenericBE);
            //return RedirectToAction("CreateFlashCardSet", new { CourseID = CourseID, AccountID = AccountID, FlashCardID = FlashCardID });
        }

        public ActionResult SelectItems(int FlashCardId)
        {

            return View();
        }

        public ActionResult PlayFlashCard(int FlashCard, int PageNumber, Boolean IsBoth)
        {
            FlashcardModel objFlashCard = new FlashcardModel();
            GenericBE objGenericBE = new GenericBE();
            objGenericBE = objFlashCard.PlayFlashCard(FlashCard, PageNumber).Single();
            objGenericBE.PageNumber = PageNumber;
            objGenericBE.IsBoth = IsBoth;
            return View(objGenericBE);
        }

        public ActionResult GetFlashCardSetSelectionItem(int CourseID, int AccountID, bool VotedUp, bool Favorite, bool YouAdded, bool Assessment, bool IsChapter, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected)
        {
            FlashcardModel objFlashCard = new FlashcardModel();
            return View(objFlashCard.GetFlashCardSetSelectionItem(CourseID, AccountID, VotedUp, Favorite, YouAdded, Assessment, IsChapter, CommaSeperatedChapters, IsNotesSelected, IsQuestionSelected, IsTermSelected, IsSummarySelected));
        }

        public int SaveFlashCardSetItem(int FlashCardID, string CourseItemID)
        {
            FlashcardModel objFlashCard = new FlashcardModel();
            int Temp = 0;
            if (!string.IsNullOrEmpty(CourseItemID))
            {
                string[] SplitCourseItemID = CourseItemID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int TotalCount = SplitCourseItemID.Count();
                int DeleteResult = objFlashCard.DeleteFlashCardSet(FlashCardID);
                if (DeleteResult == 1)
                {
                    for (int i = 0; i < TotalCount; i++)
                    {
                        // Call Sp To Insert FlashCardSet Data;
                        int TempInsertID = 0;
                        TempInsertID = objFlashCard.SaveFlashCardSetItem(FlashCardID, Convert.ToInt32(SplitCourseItemID[i]));
                        if (TempInsertID <= 0)
                        {
                            return Temp = 0;
                        }
                    }
                    return Temp = 1;
                }
            }
            return Temp;
        }

        public ActionResult DeleteFlashCard(int CourseID, int FlashCard)
        {
            FlashcardModel objFlashCard = new FlashcardModel();
            int Results = objFlashCard.DeleteFlashCard(FlashCard);
            return RedirectToAction("GetFlashCardSets", new { CourseID = CourseID });
        }

        public ActionResult TempPlay(int FlashCard)
        {
            FlashcardModel objFlashCard = new FlashcardModel();
            return View(objFlashCard.TempPlay(FlashCard));
        }
    }
}

