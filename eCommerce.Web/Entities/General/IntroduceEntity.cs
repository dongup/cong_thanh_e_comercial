using eCommerce.Web.Entities.Post;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.General
{
    public class IntroduceEntity : BaseEntity
    {
        public string BannerImages { get; set; }

        public string Introduction { get; set; }

        public string ProductCategories { get; set; }

        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual PostEntity Post { get; set; }
    }
}
