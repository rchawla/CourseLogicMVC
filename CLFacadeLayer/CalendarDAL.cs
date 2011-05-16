using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class CalendarDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

        public CalendarDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }

        public List<CalendarBE> GetMyAssessment(Int64 AccountID)
        {

            List<CalendarBE> GenericList = new List<CalendarBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_Get_MyAssessment");
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    CalendarBE GenericEntity = new CalendarBE();


                    if (!drList.IsDBNull(0))
                        GenericEntity.AssessmentID = drList.GetInt32(0);


                    if (!drList.IsDBNull(3))
                        GenericEntity.Name = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.Description = drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.DateDue = drList.GetDateTime(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.PointsPossible = drList.GetString(6);
                    else
                        GenericEntity.PointsPossible = string.Empty;


                    if (!drList.IsDBNull(7))
                        GenericEntity.CourseTitle = drList.GetString(7);
                    else
                        GenericEntity.CourseTitle = string.Empty;

                  
                    if (!drList.IsDBNull(11))
                        GenericEntity.AccountID = drList.GetInt64(11);

                    if (!drList.IsDBNull(13))
                        GenericEntity.AssessmentTypeName = drList.GetString(13);

                    if (!drList.IsDBNull(14))
                        GenericEntity.color= drList.GetString(14);


                    GenericList.Add(GenericEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return GenericList;
            }
            catch (Exception ex)
            {
                return GenericList;
            }


        }

        public List<CalendarBE> GetCourseColor(Int64 AccountID)
        {

            List<CalendarBE> GenericList = new List<CalendarBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("CL_GetStudentCourses");
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    CalendarBE GenericEntity = new CalendarBE();


                    if (!drList.IsDBNull(0))
                        GenericEntity.CourseDetailID = drList.GetInt32(0);


                    if (!drList.IsDBNull(2))
                        GenericEntity.CourseTitle = drList.GetString(2);

                    if (!drList.IsDBNull(4))
                        GenericEntity.color = drList.GetString(4);


                    GenericList.Add(GenericEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return GenericList;
            }
            catch (Exception ex)
            {
                return GenericList;
            }


        }

        public List<CalendarBE> GetCourseAssessment(Int64 CourseID,Int64 AccountID)
        {
                
            List<CalendarBE> GenericList = new List<CalendarBE>();

            try
            {
                DbCommand objSelectCommand = objDB.GetStoredProcCommand("Get_AssessmentsByCourseID");
                objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int64, CourseID);
                objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);
                IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                while (drList.Read())
                {
                    CalendarBE GenericEntity = new CalendarBE();

                    if (!drList.IsDBNull(0))
                        GenericEntity.AssessmentID = drList.GetInt32(0);


                    if (!drList.IsDBNull(3))
                        GenericEntity.Name = drList.GetString(3);

                    if (!drList.IsDBNull(4))
                        GenericEntity.Description= drList.GetString(4);

                    if (!drList.IsDBNull(5))
                        GenericEntity.DateDue = drList.GetDateTime(5);

                    if (!drList.IsDBNull(6))
                        GenericEntity.PointsPossible = drList.GetString(6);
                    else
                        GenericEntity.PointsPossible = string.Empty;
               

                    if (!drList.IsDBNull(7))
                        GenericEntity.CourseTitle = drList.GetString(7);
                    else
                        GenericEntity.CourseTitle = string.Empty;

                    if (!drList.IsDBNull(13))
                        GenericEntity.AssessmentTypeName = drList.GetString(13);

                    if (!drList.IsDBNull(11))
                        GenericEntity.AccountID = drList.GetInt64(11);

                    if (!drList.IsDBNull(14))
                        GenericEntity.color = drList.GetString(14);
                   

                    GenericList.Add(GenericEntity);
                }

                if (!drList.IsClosed)
                    drList.Close();

                return GenericList;
            }
            catch (Exception ex)
            {
                return GenericList;
            }


        }
        
        public void AddAssessment(String name,String desc, int type,string Points,DateTime Duedate,Int64 CourseID)
        {
            DbCommand cmd = objDB.GetStoredProcCommand("InsertUpdate_Assessments");


            objDB.AddInParameter(cmd, "@Name", DbType.String, name);
            objDB.AddInParameter(cmd, "@Description", DbType.String, desc);
            objDB.AddInParameter(cmd, "@AssessmentTypeID", DbType.Int16, type);
            objDB.AddInParameter(cmd, "@PointsPossible", DbType.String, Points);
            objDB.AddInParameter(cmd, "@DateDue", DbType.DateTime, Duedate);
            objDB.AddInParameter(cmd, "@CourseID", DbType.Int64, CourseID);
            objDB.ExecuteNonQuery(cmd);

        }

        public List<GenericBE> GetAssessmentTypeList()
         {
             List<GenericBE> GenericList = new List<GenericBE>();

             try
             {
                 DbCommand objSelectCommand = objDB.GetStoredProcCommand("Get_AssessmentTypes");
                
                 IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                 while (drList.Read())
                 {
                     GenericBE GenericEntity = new GenericBE();

                     if (!drList.IsDBNull(0))
                         GenericEntity.AssessmentTypeName = drList.GetString(2);

                     if (!drList.IsDBNull(1))
                         GenericEntity.AssessmentTypeID = drList.GetInt32(0);

                     GenericList.Add(GenericEntity);
                 }

                 if (!drList.IsClosed)
                     drList.Close();

                 return GenericList;
             }
             catch (Exception ex)
             {
                 return GenericList;
             }
         }

    }
}
