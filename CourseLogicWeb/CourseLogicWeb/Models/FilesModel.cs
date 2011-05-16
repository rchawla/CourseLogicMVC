using System;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using CLFacadeLayer;

namespace CourseLogicWeb.Models
{
    public class FilesModel 
    {

        #region PrivateMember
        FilesDAL objFilesDAL = new FilesDAL();
        DataSet objDS = new DataSet();
        private IEnumerable<GenericBE> _CourseItemList;
        #endregion

        #region Get Method

        public IEnumerable<GenericBE> FileList(int CourseItemID, int CourseID, int SystemObjectID)
        {
            IEnumerable<GenericBE> EntityList;
            EntityList = objFilesDAL.GetFiles(CourseItemID, CourseID, SystemObjectID);
            return EntityList;
        }


        #endregion

        #region Insert/Update Files Detail Method

        public void SaveFileDetail(int CourseItemID, int CourseID, int AccounID, int SystemObjectID, string FileExtensions, string FileName)
        {
            objFilesDAL.SaveFileDetail(CourseItemID, CourseID, AccounID, SystemObjectID, FileExtensions, FileName);
        }

        #endregion

        #region Delete Files Method

        public void DeleteFiles(int FileID, string FileName, int CourseItemID, int SystemObjectID, int CourseID)
        {
            objFilesDAL.DeleteFiles(FileID);
        }

        #endregion
    }
}
