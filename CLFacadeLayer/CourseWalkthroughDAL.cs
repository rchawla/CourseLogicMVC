using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class CourseWalkthroughDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public CourseWalkthroughDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public List<GenericBE> GetCourseDetail(long AccountID, int CourseID)
        {
            List<GenericBE> StudentCoursesList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetCourseByCourseIDForCourseIntroduction");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE CoursesEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        CoursesEntity.CourseID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        CoursesEntity.Prefix = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        CoursesEntity.CourseTitle = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        CoursesEntity.CourseNumber = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        CoursesEntity.Course_Section = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        CoursesEntity.Year = drList.GetInt32(5);

                    if (!drList.IsDBNull(6))
                        CoursesEntity.IsCourseVerfiy = drList.GetBoolean(6);


                    StudentCoursesList.Add(CoursesEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return StudentCoursesList;
            }
            catch (Exception ex)
            {
                return StudentCoursesList;
            }
        }
    }
}
