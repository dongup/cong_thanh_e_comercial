using eCommerce.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class FileResponse : BaseModel
    {
        public FileResponse(FileEntity entity)
        {
            if (entity == null)
                return;

            Id = entity.Id;
            FilePath = entity.FilePath;
            FileName = entity.FileName;
            ThumbNailPath = entity.ThumbNailPath;
            FileSize = entity.FileSize;
            FileType = entity.FileType;
        }

        public FileResponse()
        {

        }
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public string ThumbNailPath { get; set; }

        public double FileSize { get; set; }

        public string FileType { get; set; }
    }
}
