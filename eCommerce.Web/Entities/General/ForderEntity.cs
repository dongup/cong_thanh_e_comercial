using eCommerce.Web.Areas.Api.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.General
{
    public class ForderEntity : BaseEntity
    {
        public string ForderName { get; set; }
        public int ParentId { get; set; }
        public virtual List<FileResponse> Files { get; set; }
    }
}
