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
    public class CourseWalkthroughModel
    {

        #region PrivateMember
        CourseWalkthroughDAL objCoursesDAL = new CourseWalkthroughDAL();
        DataSet objDS = new DataSet();
        private IEnumerable<GenericBE> _CourseItemList;
        #endregion


        #region PublicMethod
        public IEnumerable<GenericBE> GetCourseDetail(long AccountID, int CourseID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objCoursesDAL.GetCourseDetail(AccountID, CourseID);
            return EntityList;
        }
        #endregion
    }
}