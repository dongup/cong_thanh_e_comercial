using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product.ProductCategory
{
    public class FilterEntity : BaseEntity
    {
        public FilterEntity()
        {

        }

        public string Name { get; set; }

        public ICollection<PropertyValueEntity> PropertyFilters { get; set; }
    }
}
