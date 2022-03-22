using eCommerce.Web.Entities.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Web.Entities
{
    public class PropertyValueEntity : BaseEntity
    {
        public int PropertyId { get; set; }

        public int ValueId { get; set; }

        [ForeignKey(nameof(PropertyId))]
        public virtual PropertyEntity Property { get; set; }

        [ForeignKey(nameof(ValueId))]
        public virtual ValueEntity Value { get; set; }
    }
}