using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.ProductCatergory
{
    public class ProductCategoryGroupResponse : BaseModel
    {
        public ProductCategoryGroupResponse()
        {

        }

        public ProductCategoryGroupResponse(ProductCategoryGroupEntity entity) : base(entity)
        {
            GroupName = entity.GroupName;
            Icon = entity.Icon;
            Categories = entity.Categories
                .Select(x => new CategoryResponse(x))
                .OrderBy(x=>x.OrderLevel)
                .ToList();
        }
        public string Icon { get; set; }
        public string GroupName { get; set; }

        public string FriendlyUrl { get; set; }

        public List<CategoryResponse> Categories { get; set; }
    }
}
