using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class BrandCategoryEntity : BaseEntity
    {
        public BrandCategoryEntity() : base()
        {

        }

        public int ProductCategoryId { get; set; }

        public int ProductBrandId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        public virtual CategoryEntity ProductCategory { get; set; }

        [ForeignKey(nameof(ProductBrandId))]
        public virtual ProductBrandEntity ProductBrand { get; set; }
    }
}
