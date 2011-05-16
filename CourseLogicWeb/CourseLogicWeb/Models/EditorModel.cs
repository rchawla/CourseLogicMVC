using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CLFacadeLayer;

namespace CourseLogicWeb.Models
{
    public class EditorModel
    {
    }

    public class LoadEditor
    {
        DataSet objDS = new DataSet();
        CourseItemsDAL objCourseItemsDAL = new CourseItemsDAL();
        public IEnumerable<GenericBE> _LoadEditor;

        public LoadEditor(int CID, int ParentCID, long AccountID)
        {
            DataTable dt = new DataTable();
            objDS = objCourseItemsDAL.LoadEditorByCourseItemID(CID, ParentCID, AccountID);

            if (objDS.Tables.Count > 0)
            {
                _LoadEditor = ConvertToEnumerableList(objDS.Tables[0]);
            }
        }

        private IEnumerable<GenericBE> ConvertToEnumerableList(DataTable dataTable)
        {
            List<GenericBE> _AnswerLoad = new List<GenericBE>();
            foreach (DataRow row in dataTable.Rows)
            {
                GenericBE objGenericModel = new GenericBE
                {
                    CourseItemID = Convert.ToInt32(row["CourseItemID"]),
                    CourseItemDescription = row["CourseItemDescription"].ToString(),
                    CreateDate = Convert.ToDateTime(row["CreateDate"]).Date,
                    ParentCourseItemID = Convert.ToInt32(row["ParentCourseItemID"]),
                    AccountID = Convert.ToInt64(row["AccountID"]),
                    UserName = row["FullName"].ToString(),
                    CommentCount = Convert.ToInt32(row["CommentCount"]),
                    VoteCount = Convert.ToInt32(row["VoteCount"]),
                    VoteUpDisplay = Convert.ToInt32("0"),
                    SystemObjectName = row["SystemObjectName"].ToString(),
                    SystemObjectID = Convert.ToInt32(row["SystemObjectID"]),
                    CourseID = Convert.ToInt32(row["CourseID"]),
                    StarDisplay = Convert.ToInt32("0"),
                    StarCount = Convert.ToInt32("0"),
                };
                _AnswerLoad.Add(objGenericModel);
            }
            return (IEnumerable<GenericBE>)_AnswerLoad;
        }
    }
}