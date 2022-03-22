using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Web.Entities.Product
{
    public class CatergoryFilterEntity : BaseEntity
    {
        public CatergoryFilterEntity() : base()
        {

        }

        public int ProductCategoryId { get; set; }

        public int PropertyId { get; set; }

        [ForeignKey(nameof(ProductCategoryId))]
        public virtual CategoryEntity ProductCategory { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual PropertyEntity Property { get; set; }
    }
}
