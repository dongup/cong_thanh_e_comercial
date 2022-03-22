using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class ProductImageEntity : BaseEntity
    {
        public ProductImageEntity() : base()
        {

        }

        public int? ProductId { get; set; }

        public int ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        public virtual FileEntity Image { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }


    }
}
