using eCommerce.Web.Entities.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Web.Entities
{
    public class ProductCategoryEntity : BaseEntity
    {
        public ProductCategoryEntity()
        {
           
        }

        public int CategoryId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryEntity Category { get; set; }
    }
}
