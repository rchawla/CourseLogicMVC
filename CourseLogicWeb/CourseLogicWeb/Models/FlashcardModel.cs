using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CLFacadeLayer;


namespace CourseLogicWeb.Models
{
    public class FlashcardModel
    {
        #region PrivateMember
        FlashcardDAL objFlashCardSetDAL = new FlashcardDAL();
        DataSet objDS = new DataSet();
        private IEnumerable<GenericBE> _FlashCardSetList;
        #endregion

        #region PublicMethod
        public IEnumerable<GenericBE> FlashCardSets(int CourseID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objFlashCardSetDAL.GetFalshCardSets(CourseID);
            return EntityList;
        }

        public int SaveFlashCardSet(int CourseID, int AccountID, int FlashCardID, string FlashCardTitle, string FlashCardSubject, string FlashCardDescription, bool IsVotedUpSelected, bool IsFavoriteSelected, bool IsYouAddedSelected, bool IsAssessmentSelected, bool IsChapterSelected, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected, int TotalItems)
        {
            int FlashCard = objFlashCardSetDAL.SaveFlashCardSet(CourseID, AccountID, FlashCardID, FlashCardTitle, FlashCardSubject, FlashCardDescription, IsVotedUpSelected, IsFavoriteSelected, IsYouAddedSelected, IsAssessmentSelected, IsChapterSelected, CommaSeperatedChapters, IsNotesSelected, IsQuestionSelected, IsTermSelected, IsSummarySelected,TotalItems);
            return FlashCard;
        }

        public IEnumerable<GenericBE> GetFlashCardByFlashCardID(int CourseID, int AccountID, int FlashCardID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objFlashCardSetDAL.GetFlashCardByFlashCardID(CourseID, AccountID, FlashCardID);
            return EntityList;
        }

        public IEnumerable<GenericBE> PlayFlashCard(int FlashCard, int PageNumber)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objFlashCardSetDAL.PlayFlashCard(FlashCard, PageNumber);
            return EntityList;
        }

        public IEnumerable<GenericBE> GetFlashCardSetSelectionItem(int CourseID, int AccountID, bool VotedUp, bool Favorite, bool YouAdded, bool Assessment, bool IsChapter, string CommaSeperatedChapters, bool IsNotesSelected, bool IsQuestionSelected, bool IsTermSelected, bool IsSummarySelected)
        {
            IEnumerable<GenericBE> Entitylist;
            Entitylist = objFlashCardSetDAL.GetFlashCardSetSelectionItem(CourseID, AccountID, VotedUp, Favorite, YouAdded, Assessment, IsChapter, CommaSeperatedChapters, IsNotesSelected, IsQuestionSelected, IsTermSelected, IsSummarySelected);
            return Entitylist;
        }

        public int SaveFlashCardSetItem(int FlashCardID, int CourseItemID)
        {
            int FlashCardSetID = objFlashCardSetDAL.SaveFlashCardSetItem(FlashCardID, CourseItemID);
            return FlashCardSetID;
        }

        public int DeleteFlashCardSet(int FlashCardID)
        {
            int Result = 0;
            Result = objFlashCardSetDAL.DeleteFlashCardSet(FlashCardID);
            return Result;
        }

        public int DeleteFlashCard(int FlashCard)
        {
            int Results = 0;
            Results = objFlashCardSetDAL.DeleteFlashCard(FlashCard);
            return Results;
        }

        public IEnumerable<GenericBE> TempPlay(int FlashCard)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objFlashCardSetDAL.TempPlay(FlashCard);
            return EntityList;
        }
        #endregion
    }
}