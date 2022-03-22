using eCommerce.Web.Entities.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class FileEntity : BaseEntity
    {
        public FileEntity() : base()
        {

        }
        public int? ForderId { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public string ThumbNailPath { get; set; }

        public double FileSize { get; set; }

        public string FileType { get; set; }
      
        //[ForeignKey(nameof(ForderId))]
        //public virtual ForderEntity Forder { get; set; }
    }
}
