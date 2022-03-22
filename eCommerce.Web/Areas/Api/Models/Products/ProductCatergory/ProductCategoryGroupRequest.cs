using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.ProductCatergory
{
    public class ProductCategoryGroupRequest : ProductCategoryGroupResponse
    {
        public ProductCategoryGroupRequest()
        {

        }

        public ProductCategoryGroupEntity CopyTo(ProductCategoryGroupEntity entity)
        {
            base.CopyTo(entity);
            entity.GroupName = GroupName;
            entity.Icon = Icon;
            return entity;
        }

        public List<int> CategoryIds { get; set; }

        protected new List<CategoryResponse> Categories { get; set; }
    }
}
