using eCommerce.Web.Entities;
using eCommerce.Web.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class FolderResponse
    {
        public FolderResponse(ForderEntity forderEntity, bool getFile = false)
        {
            this.Id = forderEntity.Id;
            this.FolderName = forderEntity.ForderName;
            this.ParentId = forderEntity.ParentId;
            if (getFile)
            {
                Files = forderEntity.Files;
            }

        }
        public int Id { get; set; }
        public string FolderName { get; set; }
        public int ParentId { get; set; }
        public List<FileResponse> Files { get; set; }
    }
    public class ForderRequest
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public int ParentId { get; set; }
    }

}
