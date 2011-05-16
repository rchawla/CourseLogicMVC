using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CLFacadeLayer
{
   public class CalendarBE
    {
        public int id { get; set; }

        public string title { get; set; }

        public DateTime end { get; set; }

        public DateTime start { get; set; }

        public string url { get; set; }

        public object description { get; set; }

        /*Assessment Entities*/
        public int AssessmentID { get; set; }
        public int CourseDetailID { get; set; }
        public string CourseTitle { get; set; }
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
        public bool IsAddedToMyProfile { get; set; }
        public Int64 AccountID { get; set; }
        public string color { get; set; }
    }
}
