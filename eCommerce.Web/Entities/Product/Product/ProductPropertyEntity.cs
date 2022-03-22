using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class ProductPropertyEntity : BaseEntity
    {
        public ProductPropertyEntity() : base()
        {
            PropertyValues = new HashSet<ProductPropertyValueEntity>();
        }

        public int ProductId { get; set; }

        public int PropertyId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual PropertyEntity Property { get; set; }

        public virtual ICollection<ProductPropertyValueEntity> PropertyValues { get; set; }
    }
}
