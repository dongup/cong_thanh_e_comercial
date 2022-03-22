using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product.ProductGroup
{
    public class ProductGroupEntity:BaseEntity
    {
        public int ProductId { get; set; }
        public virtual ProductEntity Product { get; set; }
        public int GroupId { get; set; }
        public virtual GroupEntity Group { get; set; }
    }
}
