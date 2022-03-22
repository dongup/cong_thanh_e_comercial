using eCommerce.Web.Entities.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Web.Entities
{
    public class ProductBrandEntity : BaseEntity
    {
        public ProductBrandEntity() : base()
        {
            Products = new HashSet<ProductEntity>();
            BrandCategories = new HashSet<BrandCategoryEntity>();
        }

        public int? LogoId { get; set; }
        /// <summary>
        /// sort acs
        /// </summary>
        public int Order { get; set; } = 1000;

        public string BrandName { get; set; }

        public virtual ICollection<BrandCategoryEntity> BrandCategories { get; set; }

        [ForeignKey(nameof(LogoId))]
        public virtual FileEntity Logo { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
