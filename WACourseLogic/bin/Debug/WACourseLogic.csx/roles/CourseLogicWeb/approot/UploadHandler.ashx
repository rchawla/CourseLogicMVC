<%@ WebHandler Language="C#" Class="TheUploadHandler" %>

using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using CuteWebUI;
using CourseLogicWeb.Models;

public class TheUploadHandler : CuteWebUI.MvcHandler
{
    public override UploaderValidateOption GetValidateOption()
    {
        CuteWebUI.UploaderValidateOption option = new UploaderValidateOption();
        option.MaxSizeKB = 100 * 1024;
        option.AllowedFileExtensions = "*.jpg,*.gif,*.png,*.bmp,*.pdf,*.doc,*.docx,*.xls,*.xlsx,*.ppt,*.ppsx";
        return option;
    }

    public override void OnFileUploaded(MvcUploadFile file)
    {

        if (file.FileSize > 10000000)
        {
            file.Delete();
            throw (new Exception("File size should be upto 10 MB"));
        }
        if (string.Equals(Path.GetExtension(file.FileName), ".bmp", StringComparison.OrdinalIgnoreCase))
        {
            file.Delete();
            throw (new Exception("My custom validation error : do not upload bmp"));
        }

        this.SetServerData("this value will pass to javascript api as item.ServerData");

        CourseLogicWeb.FileManagerProvider fs = new CourseLogicWeb.FileManagerProvider();
        string FinalStoreFilePath = fs.GetFileStorePath();
        bool folderExist = System.IO.Directory.Exists(FinalStoreFilePath);

        if (!folderExist)
        {
            System.IO.Directory.CreateDirectory(FinalStoreFilePath);
        }
        else
        {
            if (!string.IsNullOrEmpty(file.FileName))
            {
                System.IO.FileInfo F = new System.IO.FileInfo(FinalStoreFilePath + file.FileName);
                if (F.Exists)
                {
                    F.IsReadOnly = false;
                    F.Delete();
                }
            }
        }
        file.MoveTo(FinalStoreFilePath + file.FileName);
        //  TODO:use methods
        //  to move the file to somewhere
        //file.MoveTo("~/newfolder/" + file.FileName);

        //  or move to somewhere
        //file.CopyTo("~/newfolder/" + file.FileName);

        //  or delete it
        //file.Delete()

        //get the file properties
        //file.FileGuid
        //file.FileSize
        //file.FileName

        //use this method to open an file stream
        //file.OpenStream

    }

    public override void OnUploaderInit(MvcUploader uploader)
    {

    }
}





