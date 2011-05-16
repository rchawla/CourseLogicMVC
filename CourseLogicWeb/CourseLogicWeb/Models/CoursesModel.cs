using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CLFacadeLayer;
using System.Web.Mvc;
using CourseLogicWeb.Models;

namespace CourseLogicWeb.Models
{
    public class CoursesModel
    {
        #region PrivateMember
        CoursesDAL objCoursesDAL = new CoursesDAL();
        DataSet objDS = new DataSet();
        private IEnumerable<GenericBE> _CourseItemList;
        #endregion

        #region PublicMethod
        public IEnumerable<GenericBE> StudentCourses(long AccountID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCoursesDAL.GetStudentCourses(AccountID);
            return EntityList;
        }

        public IEnumerable<GenericBE> CourseByCourseID(int CourseID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCoursesDAL.GetCoursesByCourseID(CourseID);
            return EntityList;
        }

        public IEnumerable<GenericBE> Search_CoursesList(int StudentAccountID, string Prefix, string CourseNumber, string CourseTitle, string CourseSection, int SchoolID, int TermID, int Year, int PageNumber)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCoursesDAL.Search_CoursesList(StudentAccountID, Prefix, CourseNumber, CourseTitle, CourseSection, SchoolID, TermID, Year, PageNumber);
            return EntityList;
        }

        public IEnumerable<GenericBE> Get_Courses()
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCoursesDAL.Get_Courses();
            return EntityList;
        }

        public void SaveStudentCourse(int AccountID, int CourseID)
        {
            objCoursesDAL.SaveStudentCourse(AccountID, CourseID);
        }

        #endregion
    }
}