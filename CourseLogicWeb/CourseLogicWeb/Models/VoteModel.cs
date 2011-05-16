using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CLFacadeLayer;

namespace CourseLogicWeb.Models
{
    public class VoteModel
    {
        public int CountUp { get; set; }
        public int CountDown { get; set; }
        public int TotalVotes { get; set; }
        public int VoteUpDisplay { get; set; }
        public int VoteDownDisplay { get; set; }
        public int StarCount { get; set; }
        public int StarDisplay { get; set; }
    }

    public class VoteUp
    {
        VoteStarDAL objVoteDAL = new VoteStarDAL();
        DataSet objDS = new DataSet();
        public IEnumerable<VoteModel> _VoteList;

        public VoteUp(long AssociatedID, string SystemObjectName, long AccountID, long CourseID)
        {
            objDS = objVoteDAL.InsertUpdateVoteUp(AssociatedID, SystemObjectName, AccountID, CourseID);
            if (objDS.Tables.Count > 0)
            {
                _VoteList = ConvertToEnumerableList(objDS.Tables[0]);
            }
        }
    
        private IEnumerable<VoteModel> ConvertToEnumerableList(DataTable dataTable)
        {
            List<VoteModel> VoteUpList = new List<VoteModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                VoteModel objVoteModel = new VoteModel
                {
                    TotalVotes = Convert.ToInt32(row["TotalVotes"]),
                    CountUp = Convert.ToInt32(row["CountUp"]),
                    CountDown = Convert.ToInt32(row["CountDown"]),
                    VoteUpDisplay = Convert.ToInt32(row["CountUp"]),
                    VoteDownDisplay = Convert.ToInt32(row["CountDown"]),
                    StarCount = Convert.ToInt32(row["StarCount"]),
                    StarDisplay = Convert.ToInt32(row["StarDisplay"]),
                    
                };
                VoteUpList.Add(objVoteModel);
            }
            return (IEnumerable<VoteModel>)VoteUpList;
        }
    }

    public class VoteDown
    {
        VoteStarDAL objVoteDAL = new VoteStarDAL();
        DataSet objDS = new DataSet();
        public IEnumerable<VoteModel> _VoteList;

        public VoteDown(long AssociatedID, string SystemObjectName, long AccountID, long CourseID)
        {
            objDS = objVoteDAL.InsertUpdateVoteDown(AssociatedID, SystemObjectName, AccountID, CourseID);
            if (objDS.Tables.Count > 0)
            {
                _VoteList = ConvertToEnumerableList(objDS.Tables[0]);
            }
        }

        private IEnumerable<VoteModel> ConvertToEnumerableList(DataTable dataTable)
        {
            List<VoteModel> VoteUpList = new List<VoteModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                VoteModel objVoteModel = new VoteModel
                {
                    TotalVotes = Convert.ToInt32(row["TotalVotes"]),
                    CountUp = Convert.ToInt32(row["CountUp"]),
                    CountDown = Convert.ToInt32(row["CountDown"]),
                    VoteUpDisplay = Convert.ToInt32(row["CountUp"]),
                    VoteDownDisplay = Convert.ToInt32(row["CountDown"]),
                    StarCount = Convert.ToInt32(row["StarCount"]),
                    StarDisplay = Convert.ToInt32(row["StarDisplay"]),
                };
                VoteUpList.Add(objVoteModel);
            }
            return (IEnumerable<VoteModel>)VoteUpList;
        }
    }

    public class Star
    {
        VoteStarDAL objVoteDAL = new VoteStarDAL();
        DataSet objDS = new DataSet();
        public IEnumerable<VoteModel> _VoteStarList;

        public Star(long AssociatedID, string SystemObjectName, long AccountID, long CourseID)
        {
            objDS = objVoteDAL.InsertUpdateStar(AssociatedID, SystemObjectName, AccountID, CourseID);
            if (objDS.Tables.Count > 0)
            {
                _VoteStarList = ConvertToEnumerableList(objDS.Tables[0]);
            }
        }

        private IEnumerable<VoteModel> ConvertToEnumerableList(DataTable dataTable)
        {
            List<VoteModel> VoteStarList = new List<VoteModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                VoteModel objVoteModel = new VoteModel
                {
                    TotalVotes = Convert.ToInt32(row["TotalVotes"]),
                    CountUp = Convert.ToInt32(row["CountUp"]),
                    CountDown = Convert.ToInt32(row["CountDown"]),
                    VoteUpDisplay = Convert.ToInt32(row["CountUp"]),
                    VoteDownDisplay = Convert.ToInt32(row["CountDown"]),
                    StarCount = Convert.ToInt32(row["StarCount"]),
                    StarDisplay = Convert.ToInt32(row["StarDisplay"]),
                };
                VoteStarList.Add(objVoteModel);
            }
            return (IEnumerable<VoteModel>)VoteStarList;
        }
    }
}