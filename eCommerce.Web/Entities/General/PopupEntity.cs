using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Generals
{
    public class PopupEntity : BaseEntity
    {
        public PopupEntity() : base()
        {
                
        }

        public int ImageId { get; set; }

        public string Link { get; set; }
        public string BannerNgang { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public bool IsShow { get; set; }

        public bool IsModal { get; set; }

        [ForeignKey(nameof(ImageId))]
        public FileEntity Image { get; set; }
    }
}
