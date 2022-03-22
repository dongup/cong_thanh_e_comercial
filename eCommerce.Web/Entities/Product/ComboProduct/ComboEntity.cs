using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product.ComboProduct
{
    public class ComboEntity : BaseEntity
    {
        public ComboEntity() : base()
        {
            ComboProducts = new HashSet<ComboProductEntity>();
        }

        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GurantyTime { get; set; }
        public string FriendlyUrl { get; set; }
        public string PromoContent { get; set; }
        public string ThumbnailPath { get; set; }

        public virtual ICollection<ComboProductEntity> ComboProducts { get; set; }
        public virtual ICollection<ComboImagesEntity> ComboImages { get; set; }
    }
}
