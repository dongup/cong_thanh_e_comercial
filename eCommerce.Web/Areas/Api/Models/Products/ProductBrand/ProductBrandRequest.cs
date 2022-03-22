using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Models
{
    public class ProductBrandRequest : BaseModel
    {

        public ProductBrandRequest()
        {

        }

        public ProductBrandRequest(ProductBrandEntity entity) : base(entity)
        {

        }

        public ProductBrandEntity CopyTo(ProductBrandEntity entity)
        {
            base.CopyTo(entity);
            entity.BrandName = BrandName;
            entity.LogoId = LogoId;
            entity.BrandCategories = CategoryIds.Select(x => new BrandCategoryEntity()
            {
                ProductCategoryId = x
            }).ToList();

            return entity;
        }

        public List<int> CategoryIds { get; set; }

        public string BrandName { get; set; }

        public int LogoId { get; set; }
    }

}
