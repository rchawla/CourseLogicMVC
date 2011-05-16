using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;


namespace CLFacadeLayer
{
    public class CoursesDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public CoursesDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public List<GenericBE> GetStudentCourses(long AccountID)
        {
            List<GenericBE> StudentCoursesList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetStudentCourses");
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

        public List<GenericBE> GetCoursesByCourseID(int CourseID)
        {
            List<GenericBE> CourseDetailsList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetCourseByCourseID");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
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

                    CourseDetailsList.Add(CoursesEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return CourseDetailsList;
            }
            catch (Exception ex)
            {
                return CourseDetailsList;
            }
        }

        public List<GenericBE> Search_CoursesList(int StudentAccountID, string Prefix, string CourseNumber, string CourseTitle, string CourseSection, int SchoolID, int TermID, int Year, int PageNumber)
        {
            List<GenericBE> CourseDetailsList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Search_CoursesList");
                objDB.AddInParameter(objSelectCommand, "@StudentAccountID", DbType.Int64, StudentAccountID);
                objDB.AddInParameter(objSelectCommand, "@SearchText", DbType.String, CourseTitle);
                objDB.AddInParameter(objSelectCommand, "@Section", DbType.String, CourseSection);
                objDB.AddInParameter(objSelectCommand, "@Number", DbType.String, CourseNumber);
                objDB.AddInParameter(objSelectCommand, "@Prefix", DbType.String, Prefix);
                objDB.AddInParameter(objSelectCommand, "@PageNumber", DbType.Int32, PageNumber); 
                objDB.AddInParameter(objSelectCommand, "@SchoolID", DbType.Int32, SchoolID);
                objDB.AddInParameter(objSelectCommand, "@TermID", DbType.Int32, TermID);
                objDB.AddInParameter(objSelectCommand, "@Year", DbType.Int32, Year);

                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE CoursesEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        CoursesEntity.CourseID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        CoursesEntity.CourseTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        CoursesEntity.Course_Section = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        CoursesEntity.CourseNumber = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        CoursesEntity.Prefix = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        CoursesEntity.TermName = drList.GetString(5);

                    if (!drList.IsDBNull(6))
                        CoursesEntity.SchoolName = drList.GetString(6);

                    if (!drList.IsDBNull(7))
                        CoursesEntity.Year = drList.GetInt32(7);

                    if (!drList.IsDBNull(8))
                        CoursesEntity.SearchCoursePageNumber = drList.GetInt32(8);

                    if (!drList.IsDBNull(9))
                        CoursesEntity.TotalCourses = drList.GetInt32(9);

                    CourseDetailsList.Add(CoursesEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return CourseDetailsList;
            }
            catch (Exception ex)
            {
                return CourseDetailsList;
            }
        }

        public List<GenericBE> Get_Courses()
        {
            List<GenericBE> CourseDetailsList = new List<GenericBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_Courses");


                objDS = objDB.ExecuteDataSet(objSelectCommand);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    GenericBE CoursesEntity = new GenericBE();

                    if (!drList.IsDBNull(0))
                        CoursesEntity.CourseID = drList.GetInt32(0);

                    if (!drList.IsDBNull(1))
                        CoursesEntity.CourseTitle = drList.GetString(1);

                    if (!drList.IsDBNull(2))
                        CoursesEntity.Course_Section = drList.GetString(2);

                    if (!drList.IsDBNull(3))
                        CoursesEntity.CourseNumber = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        CoursesEntity.Prefix = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        CoursesEntity.TermName = drList.GetString(5);

                    if (!drList.IsDBNull(6))
                        CoursesEntity.SchoolName = drList.GetString(6);

                    if (!drList.IsDBNull(7))
                        CoursesEntity.Year = drList.GetInt32(7);

                    CourseDetailsList.Add(CoursesEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return CourseDetailsList;
            }
            catch (Exception ex)
            {
                return CourseDetailsList;
            }
        }

        public void SaveStudentCourse(int AccountID, int CourseID)
        {
            try
            {
                DbCommand objInsertCommand = objDB.GetStoredProcCommand("CL_InsertUpdate_StudentCourses");
                objDB.AddInParameter(objInsertCommand, "@CourseID", DbType.Int32, CourseID);
                objDB.AddInParameter(objInsertCommand, "@StudentAccountID", DbType.Int64, AccountID);
                objDB.ExecuteNonQuery(objInsertCommand);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
