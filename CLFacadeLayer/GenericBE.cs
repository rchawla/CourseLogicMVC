using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLFacadeLayer
{
    public class GenericBE
    {
        public int CourseItemID { get; set; }
        public int CourseID { get; set; }
        public long AccountID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Boolean IsActive { get; set; }
        public int SystemObjectID { get; set; }
        public string SystemObjectName { get; set; }
        public int StarCount { get; set; }
        public int VoteCount { get; set; }
        public int CommentCount { get; set; }
        public string CourseItemTitle { get; set; }
        public string CourseItemDescription { get; set; }
        public int CourseItemChildCount { get; set; }
        public int ParentCourseItemID { get; set; }
        public int FlagCount { get; set; }
        public int Chapter { get; set; }
        public int Section { get; set; }
        public int PageNumber { get; set; }
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public int PageFlag { get; set; }
        public int VoteUpDisplay { get; set; }
        public int VoteDownDisplay { get; set; }
        public int StarDisplay { get; set; }
        public string PostedDate { get; set; }

        /*Courses Entity*/
        public string Prefix { get; set; }
        public string CourseTitle { get; set; }
        public string CourseNumber { get; set; }
        public string TermName { get; set; }
        public string SchoolName { get; set; }
        public int Year { get; set; }
        public int SchoolID { get; set; }
        public int TermID { get; set; }
        public string  Course_Section { get; set; }
        public Boolean IsCourseVerfiy { get; set; }
        /*Add Edit Entity*/
        public Boolean IsAddItem { get; set; }

        /* Add Entity For to Check whether Item is Loaded on CourseHomePage or Not */
        public int IsCourseHomePage { get; set; }

        /* Add Entity to check whether is blank comment or not */
        public int IsBlankComment { get; set; }

        /* Add Entity for CourseHome Page Middle Panel Paging concept */
        public int TotalCourseHomeItemNumber { get; set; }
        public int CourseHomePageNumber { get; set; }

        /* Add Entity for Search Course Paging*/
        public int TotalCourses { get; set; }
        public int SearchCoursePageNumber { get; set; }

        /*FlashCard Entities*/
        public string FlashCardTitle { get; set; }
        public string FlashCardSubject { get; set; }
        public string FlashCardDescription { get; set; }        
        public int TotalItems { get; set; }
        public int FlashCardID { get; set; }
        public DateTime FlashCardSetCreateDateTime { get; set; }
        public int FlashCardSetID { get; set; }
        public Boolean IsBoth { get; set; }
        public Boolean IsQuestion { get; set; }
        public Boolean IsNotes { get; set; }
        public Boolean IsTerms { get; set; }
        public Boolean IsSummary { get; set; }
        public Boolean IsAssessment { get; set; }
        public Boolean IsChapter { get; set; }
        public string CommonSeperatedChapter { get; set; }
        public Boolean IsVotedUp { get; set; }
        public Boolean IsFavourted { get; set; }
        public Boolean IsYourAdded { get; set; }

        /* Add Student Courses Rank Entitites */
        public string Discussion_Rank { get; set; }
        public string Note_Rank { get; set; }
        public string QA_Rank { get; set; }
        public string TD_Rank { get; set; }
        public string Summary_Rank { get; set; }
        public string Class_Rank { get; set; }

        /* Add Entities For My Added Check */
        public Boolean IsMyAdded { get; set; }


        /* Add Entities For Files Detail */
        public string FileExtensions { get; set; }
        public string FileName { get; set; }
        public int FileID { get; set; }
        public string FilePath { get; set; }

        /*Assessment Entities*/
        public int AssessmentID { get; set; }
        public int CourseDetailID { get; set; }
        public int AssessmentTypeID { get; set; }
        public string AssessmentTypeName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateDue { get; set; }
        public string PointsPossible { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? ADateDeleted { get; set; }

        public int ParentAsessmentID { get; set; }

        public int RevisionCount { get; set; }
    }
}