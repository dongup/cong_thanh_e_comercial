using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class CatergoryFilterResponse : BaseModel
    {
        public CatergoryFilterResponse(CatergoryFilterEntity entity) : base(entity)
        {
            PropertyId = entity.PropertyId;
            ProductCategoryId = entity.ProductCategoryId;
            Property = new PropertyResponse(entity.Property);
        }

        public int ProductCategoryId { get; set; }

        public int PropertyId { get; set; }

        public virtual CategoryResponse ProductCategory { get; set; }

        public virtual PropertyResponse Property { get; set; }
    }
}
