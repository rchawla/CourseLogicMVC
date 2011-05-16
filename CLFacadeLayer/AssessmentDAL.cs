using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;

namespace CLFacadeLayer
{
    public class AssessmentDAL
    {
        Database objDB = null;
        DataSet objDS = new DataSet();

         public AssessmentDAL()
        {
            objDB = DatabaseFactory.CreateDatabase();
        }
       
         public List<CalendarBE> GetAssessmentList(Int64 CourseID)
         {
             List<CalendarBE> GenericList = new List<CalendarBE>();

             try
             {
                 DbCommand objSelectCommand = objDB.GetStoredProcCommand("Get_AssessmentsByCourseID");
                 objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                 
                
                 IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                 while (drList.Read())
                 {
                     CalendarBE GenericEntity = new CalendarBE();

                     if (!drList.IsDBNull(0))
                         GenericEntity.AssessmentID = drList.GetInt32(0);

                     if (!drList.IsDBNull(1))
                         GenericEntity.CourseDetailID = drList.GetInt32(1);

                     if (!drList.IsDBNull(2))
                         GenericEntity.AssessmentTypeID = drList.GetInt32(2);

                     if (!drList.IsDBNull(3))
                         GenericEntity.Name = drList.GetString(3);

                     if (!drList.IsDBNull(4))
                         GenericEntity.Description = drList.GetString(4);

                     if (!drList.IsDBNull(5))
                         GenericEntity.DateDue = drList.GetDateTime(5);

                     if (!drList.IsDBNull(6))
                         GenericEntity.PointsPossible = drList.GetString(6);

                  
                     if (!drList.IsDBNull(9))
                         GenericEntity.DateAdded=drList.GetDateTime(9);

                     if (!drList.IsDBNull(13))
                         GenericEntity.AssessmentTypeName = drList.GetString(13);
                    
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

         public List<CalendarBE> GetTopCourseAssessmentList(Int64 CourseID)
         {
             List<CalendarBE> GenericList = new List<CalendarBE>();
             

             try
             {
                 DbCommand objSelectCommand = objDB.GetStoredProcCommand("Get_UpcomingAssessmentsByCourseID");
                 objDB.AddInParameter(objSelectCommand, "@CourseID", DbType.Int32, CourseID);
                
                 IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                 while (drList.Read())
                 {
                     CalendarBE GenericEntity = new CalendarBE();

                     if (!drList.IsDBNull(0))
                         GenericEntity.AssessmentID = drList.GetInt32(0);

                     if (!drList.IsDBNull(1))
                         GenericEntity.CourseDetailID = drList.GetInt32(1);

                     if (!drList.IsDBNull(2))
                         GenericEntity.AssessmentTypeID = drList.GetInt32(2);

                     if (!drList.IsDBNull(3))
                         GenericEntity.Name = drList.GetString(3);

                     if (!drList.IsDBNull(4))
                         GenericEntity.Description = drList.GetString(4);

                     if (!drList.IsDBNull(5))
                         GenericEntity.DateDue = drList.GetDateTime(5);

                     if (!drList.IsDBNull(6))
                         GenericEntity.PointsPossible = drList.GetString(6);

                  
                     if (!drList.IsDBNull(9))
                         GenericEntity.DateAdded=drList.GetDateTime(9);
                   
                     if (!drList.IsDBNull(11))
                         GenericEntity.AssessmentTypeName = drList.GetString(11);

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

         public List<CalendarBE> GetTopAssessmentList(Int64 AccountID)
         {
             List<CalendarBE> GenericList = new List<CalendarBE>();


             try
             {
                 DbCommand objSelectCommand = objDB.GetStoredProcCommand("Get_UpcomingAssessments");
                 objDB.AddInParameter(objSelectCommand, "@AccountID", DbType.Int64, AccountID);

                 IDataReader drList = objDB.ExecuteReader(objSelectCommand);

                 while (drList.Read())
                 {
                     CalendarBE GenericEntity = new CalendarBE();

                     if (!drList.IsDBNull(0))
                         GenericEntity.AssessmentID = drList.GetInt32(0);

                     if (!drList.IsDBNull(1))
                         GenericEntity.CourseDetailID = drList.GetInt32(1);

                     if (!drList.IsDBNull(2))
                         GenericEntity.AssessmentTypeID = drList.GetInt32(2);

                     if (!drList.IsDBNull(3))
                         GenericEntity.Name = drList.GetString(3);

                     if (!drList.IsDBNull(4))
                         GenericEntity.Description = drList.GetString(4);

                     if (!drList.IsDBNull(5))
                         GenericEntity.DateDue = drList.GetDateTime(5);

                     if (!drList.IsDBNull(6))
                         GenericEntity.PointsPossible = drList.GetString(6);

                     if (!drList.IsDBNull(10))
                         GenericEntity.AccountID = drList.GetInt64(10);

                     if (!drList.IsDBNull(12))
                         GenericEntity.AssessmentTypeName = drList.GetString(12);

                     if (!drList.IsDBNull(13))
                         GenericEntity.CourseTitle = drList.GetString(13);

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
