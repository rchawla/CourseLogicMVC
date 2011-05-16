using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CLFacadeLayer;

namespace CourseLogicWeb.Models
{
    public class AssessmentModel 
    {
        //
        // GET: /AssessmentModel/

        AssessmentDAL objAssessmentDAL = new AssessmentDAL();

        public IEnumerable<CalendarBE> GetAssessment(Int64 CourseID)
        {
            IEnumerable<CalendarBE> EntityList;
            EntityList = objAssessmentDAL.GetAssessmentList(CourseID);
            return EntityList;
        }

        public IEnumerable<CalendarBE> GetTopCourseAssessment(Int64 CourseID)
        {
           
            IEnumerable<CalendarBE> EntityList;
            EntityList = objAssessmentDAL.GetTopCourseAssessmentList(CourseID);
            return EntityList;
        }

        public IEnumerable<CalendarBE> GetTopAssessment(Int64 AccountID)
        {

            IEnumerable<CalendarBE> EntityList;
            EntityList = objAssessmentDAL.GetTopAssessmentList(AccountID);
            return EntityList;
        } 

       
        public IEnumerable<CalendarBE> GetCourseColor(Int64 AccountID)
        {
            CalendarDAL objCal = new CalendarDAL();
            IEnumerable<CalendarBE> EntityList;
            EntityList = objCal.GetCourseColor(AccountID);
            return EntityList;
        }
    }
}
